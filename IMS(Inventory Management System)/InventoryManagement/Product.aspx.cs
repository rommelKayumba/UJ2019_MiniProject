﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Product : System.Web.UI.Page
{
    //connection to the database 
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");
        //sql commande variable 
    SqlCommand cmd;
     //sql adatpter variable 
    SqlDataAdapter da;
     //data set variable 
    DataSet ds;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //check the session
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
        { try
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
        //check connection state. if closed, open it 
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        
        
        //Product drop down list
        string productquery = "SELECT ProductId,ProductName FROM Product";
        cmd = new SqlCommand(productquery, sqlconnection);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "product");
        DropDownProduct.DataSource = ds.Tables["product"];
        DropDownProduct.DataTextField = "ProductName";
        DropDownProduct.DataValueField = "ProductId";
        DropDownProduct.DataBind();

       
            string supplierquery = "SELECT SupplierId,CompanyName FROM Supplier";
            cmd = new SqlCommand(supplierquery, sqlconnection);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "supplier");
            DropDownSupplier.DataSource = ds.Tables["supplier"];
            DropDownSupplier.DataTextField = "CompanyName";
            DropDownSupplier.DataValueField = "SupplierId";
            DropDownSupplier.DataBind();

        ///close connection
        sqlconnection.Close();


    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();
    }
   
    //this function on btnclear event, it clears all the fields
    //if user has made any mistake and help them to correct their mistakes
    public void clear()
    {
        hfProductId.Value = "";
        txtproname.Text = txtprodes.Text = "";
        lblerrormessage.Text = lblsuccessmassage.Text = "";
        btnsave.Text = "Save";
        btndelete.Enabled = true;
        
    }

   
    protected void btnsave_Click(object sender, EventArgs e)
    {

        if (sqlconnection.State == ConnectionState.Closed)
        sqlconnection.Open();
        SqlCommand sqlcmd = new SqlCommand("ProductCreateOrUpdate",sqlconnection);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.Parameters.AddWithValue("@ProductId",hfProductId.Value==""?0:Convert.ToInt32(hfProductId.Value));
        sqlcmd.Parameters.AddWithValue("@ProductName",txtproname.Text.Trim());
        sqlcmd.Parameters.AddWithValue("@ProductDescription",txtprodes.Text.Trim());
        sqlcmd.ExecuteNonQuery();
        sqlconnection.Close();
        string ProductId = hfProductId.Value;
        clear();

        if (ProductId == "")
            lblsuccessmassage.Text = "Saved Successfully";
        else
            lblsuccessmassage.Text = "Updated Successfully";
        FillGridView();
    }

    //fill the gridview with all the products and details abou the products
    void FillGridView()
    {
        if (sqlconnection.State == ConnectionState.Closed) 
            sqlconnection.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("ProductViewAll",sqlconnection);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        sqlconnection.Close();
        productGrid.DataSource = dtbl;
        productGrid.DataBind();
    }

    /*
     * When select any product in the list, it gets all the details about the product and display them in the add a new product section
     * first you get the prodcut ID and convert into integer
     * check state of the connection to the database 
     * if close, open the connection
     * get the command of the sql procedure that stores the product details
     * fill the fields on the form
     */
    protected void lnk_onClick(object sender, EventArgs e)
    {
        int ProductId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        if (sqlconnection.State == ConnectionState.Closed) 
        sqlconnection.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("ProductViewById", sqlconnection);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@ProductId", ProductId);
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        sqlconnection.Close();
        hfProductId.Value = ProductId.ToString();
        txtproname.Text = dtbl.Rows[0]["ProductName"].ToString();
        txtprodes.Text = dtbl.Rows[0]["ProductDescription"].ToString();
        btnsave.Text = "Update";
        btndelete.Enabled = true;
        
        
    }

    //Delete any product from the database and get instant update in the list of products
    protected void btndelete_Click(object sender, EventArgs e)
    {
        //Test if the connection to the database is still open or closed
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        //get the command which trigers the sql procedure to delete the select element of field of product
        SqlCommand sqlcmd = new SqlCommand("ProductDeleteById",sqlconnection);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        //get the product when you select
        sqlcmd.Parameters.AddWithValue("@ProductId",Convert.ToInt32(hfProductId.Value));
        //execute the command
        sqlcmd.ExecuteNonQuery();
        sqlconnection.Close();
        clear();
        FillGridView();
        lblsuccessmassage.Text = "Deleted Successfully";
    }
}
