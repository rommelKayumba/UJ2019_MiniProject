﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Supplier : System.Web.UI.Page
{
    //connetion to the database 
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");

    //load user session
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
        {
            btndelete.Enabled = false;
            FillGridView();
        }
    }

    //function that collect and fill the gridview with suppliers informations
    void FillGridView()
    {
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("SupplierViewAll", sqlconnection);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        sqlconnection.Close();
        supplierGrid.DataSource = dtbl;
        supplierGrid.DataBind();
       
    }

    // Event to save supplier's information to the database 
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        SqlCommand sqlcmd = new SqlCommand("SupplierCreateOrUpdate", sqlconnection);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.Parameters.AddWithValue("@SupplierId", hfSupplierId.Value == "" ? 0 : Convert.ToInt32(hfSupplierId.Value));
        sqlcmd.Parameters.AddWithValue("@CompanyName", txtComName.Text.Trim());
        sqlcmd.Parameters.AddWithValue("@TradeNo", txtTradeLiNo.Text.Trim());
        sqlcmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
        sqlcmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
        sqlcmd.ExecuteNonQuery();
        sqlconnection.Close();
        string SupplierId = hfSupplierId.Value;

        clear();

        //check if the save was succefull 
        if (SupplierId == "")
            lblsuccessmassage.Text = "Saved Successfully";
        else
            lblsuccessmassage.Text = "Updated Successfully";
        FillGridView();
    }

    //on selection of speciific supplier
    //collect suppliers information
    //display them in the formload
    protected void lnk_onClick(object sender, EventArgs e)
    {
        int SupplierId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("SupplierViewById", sqlconnection);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@SupplierId", SupplierId);
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        sqlconnection.Close();
        hfSupplierId.Value = SupplierId.ToString();
        txtComName.Text = dtbl.Rows[0]["CompanyName"].ToString();
        txtTradeLiNo.Text = dtbl.Rows[0]["TradeNo"].ToString();
        txtMobileNo.Text = dtbl.Rows[0]["MobileNo"].ToString();
        txtAddress.Text = dtbl.Rows[0]["Address"].ToString();
        btnsave.Text = "Update";
        btndelete.Enabled = true;


    }

    //Event on click all fields are cleared 
    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();
    }

    //function that clears all the fields of the form load 
    public void clear()
    {
        hfSupplierId.Value = "";
        txtComName.Text = txtAddress.Text=txtMobileNo.Text =txtTradeLiNo.Text= "";

        lblerrormessage.Text = lblsuccessmassage.Text = "";
        btnsave.Text = "Save";
        btndelete.Enabled = true;

    }

//Event on click delet suppliers information on the database 
    protected void btndelete_Click(object sender, EventArgs e)
    {
        if (sqlconnection.State == ConnectionState.Closed)
            sqlconnection.Open();
        SqlCommand sqlcmd = new SqlCommand("SupplierDeleteById", sqlconnection);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.Parameters.AddWithValue("@SupplierId", Convert.ToInt32(hfSupplierId.Value));
        sqlcmd.ExecuteNonQuery();
        sqlconnection.Close();
        clear();
        FillGridView();
        lblsuccessmassage.Text = "Deleted Successfully";
    }
}