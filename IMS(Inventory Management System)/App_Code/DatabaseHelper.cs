using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseHelper
/// </summary>
public class DatabaseHelper
{
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");
    string selectedID;
    List<int> tempAmounts;

    public DatabaseHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<string> getExistingRules(string selectedID)
    {
        string sqlquery = "SELECT * FROM Compatibility WHERE ComponentAID = @selectedID OR ComponentBID = @selectedID";
        
        List<CompatibilityObj> compatibiityRules = new List<CompatibilityObj>();
        try
        {
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@selectedID", selectedID);
            sqlconnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            while (sqlDataReader.Read())
            {
                CompatibilityObj compatibility = new CompatibilityObj();
                compatibility.ComponentAID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ComponentAID"));
                compatibility.ComponentBID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ComponentBID"));
                compatibiityRules.Add(compatibility);
            }
        }
        catch (Exception error)
        {
            throw error;
        } finally
        {
            sqlconnection.Close();
        }

        List<string> products = new List<string>();

        foreach(CompatibilityObj temcomp in compatibiityRules)
        {
            if (temcomp.ComponentAID + "" != selectedID)
            {
                products.Add(getProduct((temcomp.ComponentAID + "")).productName);
            }
        }

        return products;
    }

    public List<string> getExistingRulesbyID(string selectedID)
    {
        string sqlquery = "SELECT * FROM Compatibility WHERE ComponentAID = @selectedID OR ComponentBID = @selectedID";

        List<CompatibilityObj> compatibiityRules = new List<CompatibilityObj>();
        try
        {
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@selectedID", selectedID);
            sqlconnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            while (sqlDataReader.Read())
            {
                CompatibilityObj compatibility = new CompatibilityObj();
                compatibility.ComponentAID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ComponentAID"));
                compatibility.ComponentBID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ComponentBID"));
                compatibiityRules.Add(compatibility);
            }
        }
        catch (Exception error)
        {
            throw error;
        }
        finally
        {
            sqlconnection.Close();
        }

        List<string> products = new List<string>();

        foreach (CompatibilityObj temcomp in compatibiityRules)
        {
            if (temcomp.ComponentAID + "" != selectedID)
            {
                products.Add(getProduct((temcomp.ComponentAID + "")).productId + "");
            }
        }

        return products;
    }

    public ProductObj getProduct(string selectedID)
    {
        ProductObj product = new ProductObj();

        SqlCommand sqlCommand = new SqlCommand("Select * FROM Product WHERE ProductId = " + selectedID, sqlconnection);
        sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        if (sqlDataReader.Read())
        {
            product.productId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ProductId"));
            product.productName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductName"));
            product.prodcutDescription = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductDescription"));
            product.productPrice = 1;
            product.inStock = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
        }

 
        sqlDataReader.Close();
        sqlconnection.Close();

        return product;
    }

    //ORDER CODE HERE

    public bool saveOrder(OrderObj order)
    {
        try
        {
            string queryStrng = "INSERT INTO Orders(orderId, userId, orderDate, isActive) VALUES(@orderId, @userId, @orderDate, @isActive)";
            SqlCommand sqlCommand = new SqlCommand(queryStrng, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@orderId", order.orderId);
            sqlCommand.Parameters.AddWithValue("@userId", order.userId);
            sqlCommand.Parameters.AddWithValue("@orderDate", order.orderDate);
            sqlCommand.Parameters.AddWithValue("@isActive", order.isActive);
            sqlconnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception error)
        {
            return false;
        }
        finally
        {
            sqlconnection.Close();
        }
        bool savedtoBridge = saveToOrderProductBridge(order);
        if (!savedtoBridge)
        {
            return false;
        }

        return true;
    
    }

    public bool setActiveOfOrder(OrderObj order)
    {
        try
        {
            string queryStrng = "UPDATE Orders SET isActive = @isActive WHERE orderId = @orderId";
            SqlCommand sqlCommand = new SqlCommand(queryStrng, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@orderId", order.orderId);
            sqlCommand.Parameters.AddWithValue("@isActive", order.isActive);
            sqlconnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception error)
        {
            return false;
        }
        finally
        {
            sqlconnection.Close();
        }
        return true;
    }

    public bool deleteOrderProductBridge(OrderObj order)
    {
        try
        {
            string queryStrng = "DELETE FROM OrderProductBridge WHERE orderId = @orderId";
            int orderId = order.orderId;
            SqlCommand sqlCommand = new SqlCommand(queryStrng, sqlconnection);
            sqlconnection.Open();
            sqlCommand.Parameters.AddWithValue("@orderId", orderId);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception error)
        {
            return false;
        }
        finally
        {
            sqlconnection.Close();
        }
        return true;
    }

    public bool editOrder(OrderObj order)
    {
        bool isDeleted = deleteOrderProductBridge(order);
        bool isUpdated = saveToOrderProductBridge(order);
        if(isDeleted && isUpdated)
        {
            return true;
        }
        return false;
    }

    public bool saveToOrderProductBridge(OrderObj order)
    {
        try
        {
            string queryStrng = "INSERT INTO OrderProductBridge(orderId, productId, amount) VALUES(@orderId, @productId, @amount)";
            List<ProductObj> products = order.products;
            List<int> amounts = order.amounts;
            int orderId = order.orderId;
            SqlCommand sqlCommand = new SqlCommand(queryStrng, sqlconnection);
            sqlconnection.Open();
            for (int i = 0; i < products.Count; i++)
            {
                sqlCommand.Parameters.AddWithValue("@orderId", orderId);
                sqlCommand.Parameters.AddWithValue("@productId", products[i].productId);
                sqlCommand.Parameters.AddWithValue("@amount", amounts[i]);
                sqlCommand.ExecuteNonQuery();
            }
        }
        catch (Exception error)
        {
            return false;
        }
        finally
        {
            sqlconnection.Close();
        }
        return true;
    }

    public OrderObj getOrderById(int orderId)
    {
        OrderObj order = new OrderObj();
        SqlCommand sqlCommand = new SqlCommand("Select * FROM Order WHERE orderId = @orderId", sqlconnection);
        sqlCommand.Parameters.AddWithValue("@orderId", orderId);
        sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.Read())
        {
            order.orderId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("orderId"));
            order.userId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("userId"));
            order.orderDate = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("orderDate"));
        }
        order.products = getProductsByOrderId(orderId);
        order.amounts = tempAmounts;
        tempAmounts = new List<int>();
        return order;
    }

    public List<ProductObj> getProductsByOrderId(int orderId)
    {
        List<ProductObj> products = new List<ProductObj>();
        tempAmounts = new List<int>();
        OrderObj order = new OrderObj();
        SqlCommand sqlCommand = new SqlCommand("Select * FROM OrderProductBridge WHERE orderId = @orderId", sqlconnection);
        sqlCommand.Parameters.AddWithValue("@orderId", orderId);
        sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while(sqlDataReader.Read())
        {
            ProductObj product = new ProductObj();
            int productId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("productId"));
            tempAmounts.Add(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("amount")));
            products.Add(getProduct(productId + ""));
        }
        return products;
    }

    public List<OrderObj> getOrdersByUserId(int userId)
    {
        List<OrderObj> orders = new List<OrderObj>();
        SqlCommand sqlCommand = new SqlCommand("Select * FROM Order WHERE userId = @userId", sqlconnection);
        sqlconnection.Open();
        sqlCommand.Parameters.AddWithValue("@userId", userId);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.Read())
        {
            int orderId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("orderId"));
            orders.Add(getOrderById(orderId));
        }
        return orders;
    }
}