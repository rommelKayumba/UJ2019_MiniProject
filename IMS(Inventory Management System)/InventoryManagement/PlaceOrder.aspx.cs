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

    OrderObj order;

    DatabaseHelper dbHelper;

    ProductObj tempProductObj;

    double totalCost = 0;
    //check user session
    protected void Page_Load(object sender, EventArgs e)
    {
        order = Session["tempOrder"] as OrderObj;
        if (order == null)
        {
            order = new OrderObj();
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
                FillGridView();
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

            SqlCommand sqlCommand = new SqlCommand("Select * FROM Product", sqlconnection);
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
        //List<int> numberList = Enumerable.Range(1, tempProductObj.inStock).ToList();
        List<int> numberList = Enumerable.Range(1, 5).ToList();
        drplstQuantity.DataSource = numberList;
        drplstQuantity.DataBind();
        lblDescription.Text = tempProductObj.prodcutDescription;
        Session["tempProductObj"] = tempProductObj;
    }


    //Event to save for any purchase of product by user and update gridview
    protected void btnsave_Click(object sender, EventArgs e)
    {
        tempProductObj = Session["tempProductObj"] as ProductObj;
        if (tempProductObj != null)
        {
            string validator = validateOrder(tempProductObj);
            if(validator){
                lblerrormessage.Text = validator;
            }
            else{
                int quantity = Convert.ToInt32(drplstQuantity.SelectedValue);
                tempProductObj.inStock = quantity;
                order.products.Add(tempProductObj); //temp holding this
                order.amounts.Add(quantity);
                Session["tempOrder"] = order;
            }
        }
        purchaseGrid.DataSource = order.products;
        purchaseGrid.DataBind(); 


        //try
        //{
        //    //check connection
        //    //if closed, open it 
        //    if (sqlconnection.State == ConnectionState.Closed)
        //        sqlconnection.Open();

        //    //command to create or update any purchase by executing the appropriate sql proocedure
        //    SqlCommand sqlcmd = new SqlCommand("PurchaseCreateOrUpdate", sqlconnection);
        //    sqlcmd.CommandType = CommandType.StoredProcedure;
        //    sqlcmd.Parameters.AddWithValue("@PurchaseId", hfPurchaseId.Value == "" ? 0 : Convert.ToInt32(hfPurchaseId.Value));
        //    sqlcmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(drplstQuantity.Text.Trim()));
        //    sqlcmd.Parameters.AddWithValue("@Others", txtOthers.Text);
        //    sqlcmd.ExecuteNonQuery();
        //    sqlconnection.Close();
        //    string PurchaseId = hfPurchaseId.Value;


        //    if (PurchaseId == "")
        //        lblsuccessmassage.Text = "Saved Successfully";
        //    else
        //        lblsuccessmassage.Text = "Updated Successfully";
        //    FillGridView();
        //    clear();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    lblsuccessmassage.Text = "An Error occured while Saving/Updating the purchase";
        //}



    }

    //function to fill up the gridview
    void FillGridView()
    {
        //if (sqlconnection.State == ConnectionState.Closed)
        //    sqlconnection.Open();


        //SqlDataAdapter sqlDa = new SqlDataAdapter("ViewPurchaseGrid", sqlconnection);
        //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //DataTable dtbl = new DataTable();
        //sqlDa.Fill(dtbl);
        //sqlconnection.Close();
        //purchaseGrid.DataSource = dtbl;
        //purchaseGrid.DataBind();

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
        order.isActive = 'P';
        order.orderDate = DateTime.Now;
        dbHelper.saveOrder(order);
        Session["tempOrder"] = null;
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

    private boolean validateOrder(ProductObj product){
        OrderObj order = Session["tempProd"];
        List<ProductObj> products = order.products; 
        List<string> compatibilityRules = getExistingRules(product.productId);
        foreach(ProductObj product in products){
            int foundIndex = compatibilityRules.FindIndex(product.productId);
            if(foundIndex >= 0){
                return "Cannot Order " + getProduct(compatibilityRules[foundIndex]).productName + " with " + product.productName;
            }
        }
        return null;

    }
}