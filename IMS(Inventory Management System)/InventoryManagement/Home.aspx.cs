using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        Control LogoutLink = this.Master.FindControl("LogoutLink");
        LogoutLink.Visible = true;

    
        LogoutLink.Visible = true;


        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }else
        {
            Control userDislay = this.Master.FindControl("usernameDisplay");
            var user = (Label) Master.FindControl("usernameDisplay");
            user.Text = Session["user"].ToString();

        }

        if (Session["Role"] != null)
        {
            if (Convert.ToInt32(Session["Role"]) == 1)
            {
                lblWelcome.InnerText = "You are Logged in as an Admin";
                btnEntries.Visible = false;
                btncliens.Visible = false;
                btnSales.Visible = false;
                btnSupplier.Visible = false;
                btnPurchase.Visible = false;
            }

            if (Convert.ToInt32(Session["Role"]) == 4)
            {
                lblWelcome.InnerText = "You are Logged in as a Client";

                btnEntries.Visible = false;
                btncliens.Visible = false;
                btnSales.Visible = false;
                btnSupplier.Visible = false;
                btnProduct.Visible = false;
                btnStocks.Visible = false;
              
                
            }

            if (Convert.ToInt32(Session["Role"]) == 3)
            {
                lblWelcome.InnerText = "You are Logged in as a Clerck";
                btnEntries.Visible = false;
                btnSupplier.Visible = false;
                btnProduct.Visible = false;
                btnSales.Visible = false;
                btnMatching.Visible = false;
                btncliens.Visible = false;
                
            }


            if (Convert.ToInt32(Session["Role"]) == 2)
            {
                lblWelcome.InnerText = "You are Logged in as a Manager";
               
                btncliens.Visible = false;
                btnSales.Visible = false;
                btnSupplier.Visible = false;
                btnProduct.Visible = false;
                btnMatching.Visible = false;
                btnPurchase.Visible = false;

            }



        }



    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Product.aspx");
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Supplier.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sale.aspx");
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Purchase.aspx");
    }
}
