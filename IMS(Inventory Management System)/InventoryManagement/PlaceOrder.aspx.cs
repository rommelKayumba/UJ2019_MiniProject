using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class PlaceOrder : System.Web.UI.Page
{
    //connection to the database 
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");

    //sql commande variable 
    SqlCommand cmd;

    //sql adatpter variable 
    SqlDataAdapter da;

    //data set variable 
    DataSet ds;

    public string validator;


    OrderObj order;

    DatabaseHelper dbHelper;

    ProductObj tempProductObj;

    string pageFunction;

    double totalCost = 0;
    //check user session
    protected void Page_Load(object sender, EventArgs e)
    {
        pageFunction = Request.QueryString["pageFunction"];
        order = Session["tempOrder"] as OrderObj;
         if (order == null || pageFunction == null && !IsPostBack)
        {
            order = new OrderObj();
            Session["tempOrder"] = null;
        }
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
        {
            
            try
            {
                
                filldropdownlist();
                if(order.products != null || order.products.Count > 0) FillGridView();
                Control LogoutLink = this.Master.FindControl("LogoutLink");
                LogoutLink.Visible = true;
                Control userDislay = this.Master.FindControl("usernameDisplay");
                var user = (Label)Master.FindControl("usernameDisplay");
                user.Text = Session["user"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                lblsuccessmassage.Text = "An Error occured while retrieving the Purchase List";
            }

        }
        

    }


    protected void filldropdownlist()
    {
        DataTable dtbl = new DataTable();

        try
        {

            SqlCommand sqlCommand = new SqlCommand("Select * FROM Product WHERE Quantity > 0", sqlconnection);
            sqlconnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            dtbl.Load(sqlDataReader);
            sqlDataReader.Close();
            sqlconnection.Close();
        }
        catch (Exception error)
        {
            throw error;
        }

        if (!IsPostBack)
        {
            DdList.DataSource = dtbl;
            DdList.DataValueField = "ProductId";
            DdList.DataTextField = "ProductName";
            DdList.DataBind();
        }


    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dbHelper = new DatabaseHelper();
        tempProductObj = dbHelper.getProduct(DdList.SelectedValue);
        List<int> numberList = Enumerable.Range(1, tempProductObj.inStock).ToList();
       // List<int> numberList = Enumerable.Range(1, 5).ToList();
        drplstQuantity.DataSource = numberList;
        drplstQuantity.DataBind();
        txtOthers.Text = tempProductObj.prodcutDescription;
        txtPrice.Text = tempProductObj.productPrice + "";
        Session["tempProductObj"] = tempProductObj;
    }


    //Event to save for any purchase of product by user and update gridview
    protected void btnsave_Click(object sender, EventArgs e)
    {
    tempProductObj = Session["tempProductObj"] as ProductObj;
        List<ProductObj> displayProducts = new List<ProductObj>();
        if (tempProductObj != null)
        {
            if(Session["tempOrder"] != null)
            {
                 validator = validateOrder(tempProductObj);

            }
            if (validator != null)
            {
                lblerrormessage.Text = validator;
            }
            else
            {
                bool newProdcut = true;
                List<int> originalStocks = new List<int>();
                List<double> originalPrice = new List<double>();

                //add quantity if user chooses two of the same values


                int quantity = Convert.ToInt32(drplstQuantity.SelectedValue);

                
              
              
                
                

                for (int i = 0; i < order.products.Count; i++)
                {
                    if (order.products[i].productId == tempProductObj.productId)
                    {
                        newProdcut = false;
                        displayProducts = order.products;
                        order.amounts[i] += quantity;
                        displayProducts[i].productPrice = order.amounts[i] * order.products[i].productPrice;
                        displayProducts[i].inStock = order.amounts[i];
                    }
                }

                if (newProdcut == true)
                {
                    order.amounts.Add(quantity);
                    order.products.Add(tempProductObj); //temp holding this
                    displayProducts = order.products;

                    //for (int i = 0; i < displayProducts.Count; i++)
                    //{
                    int lastItemIdx = displayProducts.Count - 1;
                    if(lastItemIdx >= 0)
                    {
                        displayProducts[lastItemIdx].productPrice = order.amounts[lastItemIdx] * order.products[lastItemIdx].productPrice;
                        displayProducts[lastItemIdx].inStock = order.amounts[lastItemIdx];
                    }
                    //}
                }
                //displayProducts = order.products;

                

                //tempProductObj.inStock = quantity;
                //tempProductObj.productPrice = quantity * tempProductObj.productPrice;


                order.orderCost = getCost(order, displayProducts);
                lblTotalCost.Text = "R" + order.orderCost;
                Session["tempOrder"] = order;
            }
        }
            purchaseGrid.DataSource = displayProducts;
        purchaseGrid.DataBind();      

    }

    //function to fill up the gridview
    void FillGridView()
    {
        List<ProductObj> displayProducts = order.products;
        for(int i = 0; i < displayProducts.Count; i++)
        {
            displayProducts[i].productPrice = order.products[i].productPrice * order.amounts[i]; //temp hlding for cost
        }

        purchaseGrid.DataSource = displayProducts;
        purchaseGrid.DataBind();
        lblTotalCost.Text = "R" + order.orderCost;

    }

    //Event to delete any purchase 
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (sqlconnection.State == ConnectionState.Closed)
                sqlconnection.Open();
            SqlCommand cmd = new SqlCommand("PurchaseDeleteById", sqlconnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PurchaseId", Convert.ToInt32(hfPurchaseId.Value));
            cmd.ExecuteNonQuery();
            sqlconnection.Close();
            hfPurchaseId.Value = "";
            drplstQuantity.Text = txtOthers.Text = "";
            FillGridView();
            lblsuccessmassage.Text = "Delete Successfully";

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            lblsuccessmassage.Text = "An Error occured while deleting the purchase";
        }


    }

    //event to clear fileds 
    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();
    }

    
        protected void btnSubmitOrder(object sender, EventArgs e)
    {
        dbHelper = new DatabaseHelper();
        order = Session["tempOrder"] as OrderObj;
        order.userName = Session["user"] as string;
        order.isActive = "P";
        order.orderDate = DateTime.Now;

        if(order.orderId != 0)
        {
            dbHelper.editOrder(order);
        } else
        {
            dbHelper.saveOrder(order);
        }
    }

    //function that clears all the fields 
    public void clear()
    {
        hfPurchaseId.Value = "";
        drplstQuantity.Text = txtOthers.Text = "";

        lblerrormessage.Text = lblsuccessmassage.Text = "";
        btnsave.Text = "Save";
        btndelete.Enabled = true;

    }

    //event to select a given purchase and filled the fields with the purchase details
    //
    protected void lnk_onClick(object sender, EventArgs e)
    {
        

    }

    protected void purchaseGrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownProduct_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private string validateOrder(ProductObj product)
    {
        dbHelper = new DatabaseHelper();
        OrderObj order = Session["tempOrder"] as OrderObj;
        List<ProductObj> products = order.products;
        List<string> compatibilityRules = dbHelper.getExistingRules(product.productId + "");
        foreach (ProductObj Iproduct in products)
        {
           if(compatibilityRules.Count > 0)
            {
                for (int i = 0; i < compatibilityRules.Count; i++)
                {
                    if (Iproduct.productName == compatibilityRules[i])
                    {

                        return "You can not order " + dbHelper.getProductByName(compatibilityRules[i]).productName + " with " + product.productName;

                    }
                }
            }
        }
        return null;
    }

    private double getCost(OrderObj order, List<ProductObj> displayProduct)
    {
       if(order.products.Count > 0)
        {
            List<ProductObj> products = order.products;
            List<int> amounts = order.amounts;
            for (int i = 0; i < order.products.Count; i++)
            {
                totalCost += products[i].productPrice;
            }
        }
       
        return totalCost;
    }
}