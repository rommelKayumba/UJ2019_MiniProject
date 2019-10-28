using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
         string level = Session["level"] as string;

           
        FillGridView();
    }
     protected void lnk_edit(object sender, EventArgs e)
    {
        dbHelper = new DatabaseHelper();
        int orderId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        OrderObj tempOrder = dbHelper.getOrderById(orderId);
        Session["tempOrder"] = tempOrder;
        Response.Redirect("PlaceOrder.aspx?pageFunction=E");
    }
    
     protected void lnk_cancel(object sender, EventArgs e)
    {
        dbHelper = new DatabaseHelper();
        int orderId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        OrderObj tempOrder = dbHelper.getOrderById(orderId);
        tempOrder.isActive ="C";
        dbHelper.setActiveOfOrder(tempOrder);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
}
