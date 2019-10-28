using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class clerkcViewOrder : System.Web.UI.Page
{
    private DatabaseHelper dbHelper;

    //connection to the database 
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");

    protected void Page_Load(object sender, EventArgs e)
    {
        FillGridView();

    }
    protected void lnk_edit(object sender, EventArgs e)
    {
        dbHelper = new DatabaseHelper();
        int orderId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        OrderObj tempOrder = dbHelper.getOrderById(orderId);
        Session["tempOrder"] = tempOrder;
        Response.Redirect("PlaceOrder.aspx?pageFunction=E&role=clerk");
    }

    protected void lnk_cancel(object sender, EventArgs e)
    {
        dbHelper = new DatabaseHelper();
        int orderId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        OrderObj tempOrder = dbHelper.getOrderById(orderId);
        tempOrder.isActive = "C";
        dbHelper.setActiveOfOrder(tempOrder);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    protected void lnk_process(object sender, EventArgs e)
    {
        dbHelper = new DatabaseHelper();
        int orderId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        OrderObj tempOrder = dbHelper.getOrderById(orderId);
        tempOrder.isActive = "A";
        dbHelper.setActiveOfOrder(tempOrder);
        List<ProductObj> tempProducts = tempOrder.products;
        for (int i = 0; i < tempProducts.Count; i++)
        {
            ProductObj tempProduct = tempProducts[i];
            tempProduct.inStock -= tempOrder.amounts[i];
            dbHelper.editProduct(tempProducts[i]);
        }

        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }



    void FillGridView()
    {
        dbHelper = new DatabaseHelper();
        List<OrderObj> orders = dbHelper.getAllOrders();
        productGrid.DataSource = orders;
        productGrid.DataBind();
    }
}