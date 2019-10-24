using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Component : System.Web.UI.Page
{

    //connection to the database 
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");
    protected void Page_Load(object sender, EventArgs e)
    {
        //check the session
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
        {
            Control LogoutLink = this.Master.FindControl("LogoutLink");
            LogoutLink.Visible = true;

            Control userDislay = this.Master.FindControl("usernameDisplay");
            var user = (Label)Master.FindControl("usernameDisplay");
            user.Text = Session["user"].ToString();

            //btndelete.Enabled = false;
            //FillGridView();


        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (sqlconnection.State == System.Data.ConnectionState.Closed)
                sqlconnection.Open();
            SqlCommand sqlcmd = new SqlCommand("ProductCreateOrUpdate", sqlconnection);
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@CompnentId", hfProductId.Value == "" ? 0 : Convert.ToInt32(hfProductId.Value));
            sqlcmd.Parameters.AddWithValue("@Name",txtComponentDescription.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Description",txtComponentDescription.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Quantity",TxtQuantity.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Unit Price", TxtPrice.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Availability", TxtAvailability.Text.Trim());


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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            lblsuccessmassage.Text = "An Error occured while connecting to the DB";
        }
    }

    private void FillGridView()
    {

        GridViewRow row = ComponentGrid.SelectedRow;
       txtComponentname.Text = row.Cells[1].Text;
       txtComponentDescription.Text = row.Cells[2].Text;
        TxtQuantity.Text = row.Cells[3].Text;
        TxtPrice.Text = row.Cells[4].Text;
        TxtAvailability.Text = row.Cells[5].Text;

        //    //txtQuantity2.ReadOnly = false;
        throw new NotImplementedException();
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();
    }
    public void clear()
    {
        hfProductId.Value = "";
        txtComponentname.Text = txtComponentname.Text = "";
        txtComponentDescription.Text = txtComponentDescription.Text = "";
        TxtQuantity.Text = TxtQuantity.Text = "";
        TxtPrice.Text = TxtPrice.Text = "";
        TxtAvailability.Text = TxtAvailability.Text = "";

        //txtpr.Text = txtprodes.Text = "";
        lblerrormessage.Text = lblsuccessmassage.Text = "";
        btnsave.Text = "Save";
        btnclear.Enabled = true;

    }

    protected void productGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = ComponentGrid.SelectedRow;
        txtComponentname.Text = row.Cells[1].Text;
        txtComponentDescription.Text = row.Cells[2].Text;
        TxtQuantity.Text = row.Cells[3].Text;
        TxtPrice.Text = row.Cells[4].Text;
        TxtAvailability.Text = row.Cells[5].Text;

        //txtQuantity2.ReadOnly = false;
    }
}