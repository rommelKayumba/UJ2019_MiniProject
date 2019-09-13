﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Sales : System.Web.UI.Page

{
    //Database connection
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");

    /*
     * sql adapter variable 
     * data table vaiable
     */
    static SqlDataAdapter adapter;
    static DataTable databl;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        else if (!IsPostBack)
        {
            TextBox3.ReadOnly = txtQuantity1.ReadOnly = txtQuantity2.ReadOnly = true;
            btnsale.Enabled = false;
           

            FillGridView();
        }
    }
    
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetSearch(string prefixText)
    {
       
        string str = "select Product.ProductName,Supplier.CompanyName, Sum(Purchase.Quantity) as total from Product inner join Purchase on Product.ProductId = Purchase.ProductId inner join Supplier on Purchase.SupplierId = Supplier.SupplierId where Product.ProductName like '" + prefixText + "%' group by product.ProductName, Supplier.CompanyName";
        adapter = new SqlDataAdapter(str, sqlconnection);
        databl = new DataTable();
        adapter.Fill(databl);
        List<string> Output = new List<string>();
        for (int i = 0; i < databl.Rows.Count; i++)
            Output.Add(databl.Rows[i][0].ToString());
        return Output;
    }

   //clear the fields
    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();        
    }

    //function that clears all the fields of the search section
    protected void clear()
    {
        TextBox3.ReadOnly = txtQuantity1.ReadOnly = txtQuantity2.ReadOnly = true;
        TextBox2.Text = TextBox3.Text = txtQuantity1.Text = txtQuantity2.Text = "";
        btnsale.Enabled = false;
    }

    //search function
    //execute the sql procedure
    //search trough the prodcut table
    //get the details about thhe prodcut 
    protected void Search()
    {
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();


        string query = "select Product.ProductName,Supplier.CompanyName, Sum(Purchase.Quantity) as total from Product inner join Purchase on Product.ProductId = Purchase.ProductId inner join Supplier on Purchase.SupplierId = Supplier.SupplierId where Product.ProductName like '" + TextBox2.Text + "%' group by product.ProductName, Supplier.CompanyName";
        SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlconnection);

        DataSet ds = new DataSet();
        sqlDa.Fill(ds);

        searchGrid.DataSource = ds;
        searchGrid.DataBind();
        sqlconnection.Close();

        txtQuantity1.ReadOnly = txtQuantity2.ReadOnly = true;
        btnsale.Enabled = true;
        
    }
   

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        searchGrid.Visible = true;
        this.Search();
    }


    //function to serach sppeciific sale details 
    protected void searchGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = searchGrid.SelectedRow;
        TextBox3.Text = row.Cells[1].Text;
        txtQuantity1.Text = row.Cells[2].Text;

        txtQuantity2.ReadOnly = false;
    }


    //function to insert or save sales data into sales table in the database
    protected void SaveSell()
    {
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        string insertquery = "insert into Sales (SalesProductName, SalesCompanyName, SalesQuantity) values ('"+TextBox2.Text+ "','"+TextBox3.Text+ "','"+txtQuantity2.Text+"')";
        SqlCommand cmd1 = new SqlCommand(insertquery, sqlconnection);
        cmd1.ExecuteNonQuery();
        sqlconnection.Close();
        
        //filled the gridview with the saved data
       FillGridView();
      
        

    }

    //function to collect data from sales table and insert them into the gridview
    void FillGridView()
    {
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        string sales_grid_query = "Select SalesProductName, SalesCompanyName, SalesQuantity from Sales";
        SqlCommand cmd2 = new SqlCommand(sales_grid_query, sqlconnection);
        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        sqlconnection.Close();
        SalesGrid.DataSource = dt;
        SalesGrid.DataBind();

    }

    //event to sele any product in the inventory
    // select the product
    //check the quantity left of the prooduct
    //specify the exact quantity of product to sale
    //once sold update the quantity of product left
    protected void btnsell_Click1(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtQuantity1.Text) >= Convert.ToInt32(txtQuantity2.Text))
        {

            if (sqlconnection.State == ConnectionState.Closed)
                sqlconnection.Open();
            String updateQuery = "Update Purchase set Purchase.Quantity = Purchase.Quantity -'" + txtQuantity2.Text + "' from Product inner join Purchase on Product.ProductId = Purchase.ProductId inner join Supplier on Purchase.SupplierId = Supplier.SupplierId Where Product.ProductName = '" + TextBox2.Text + "' and Supplier.CompanyName = '" + TextBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(updateQuery, sqlconnection);
            cmd.ExecuteNonQuery();

            sqlconnection.Close();

            SaveSell();
            this.clear();


            lblsuccessmassage.Text = "Sell Successfully!";
            lblerrormessage.Text = "";
        }
        else
            lblerrormessage.Text = "Sell Quantity does not available.\n Please Check Available Quantity";

    }
}