using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    static SqlConnection sqlcon = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand("SupplierCreateOrUpdate", sqlcon);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        // sqlcmd.Parameters.AddWithValue("@Username", == "" ? 0 : Convert.ToInt32(hfSupplierId.Value));
        sqlcmd.Parameters.AddWithValue("@Username", txtRegUser.Text.Trim());
        sqlcmd.Parameters.AddWithValue("@TradeNo", txtRegPassword.Text.Trim());
        // sqlcmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
        //sqlcmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
        sqlcmd.ExecuteNonQuery();
        sqlcon.Close(); } // To check sql procedure in smarterASP online
        //string SupplierId = hfSupplierId.Value;
       // clear();

        //if (SupplierId == "")
          //  lblsuccessmassage.Text = "Saved Successfully";
        //else
            //lblsuccessmassage.Text = "Updated Successfully";
        //FillGridView();

    }
//}