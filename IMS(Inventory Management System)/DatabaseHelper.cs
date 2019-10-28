using System;
using System.Collections.Generic;
using System.Data;
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
        string sqlquery = "SELECT * FROM Compatibility";
        
        List<CompatibilityObj> compatibiityRules = new List<CompatibilityObj>();
        try
        {
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconnection);
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
        string sqlquery = "SELECT * FROM Compatibility WHERE ComponentAID = @selectedID OR ComponentBID = @selectedIDii";

        List<CompatibilityObj> compatibiityRules = new List<CompatibilityObj>();
        try
        {
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@selectedID", selectedID);
            sqlCommand.Parameters.AddWithValue("@selectedIDii", selectedID);
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
        if (sqlconnection.State == ConnectionState.Closed) sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        if (sqlDataReader.Read())
        {
            product.productId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ProductId"));
            product.productName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductName"));
            product.prodcutDescription = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductDescription"));
           // var x = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("Product_Price"));
            product.productPrice = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("Product_Price"));
            product.inStock = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
        }

 
        sqlDataReader.Close();
        sqlconnection.Close();

        return product;
    }

    public List<ProductObj> getAllProducts()
    {
        List<ProductObj> products = new List<ProductObj>();

        SqlCommand sqlCommand = new SqlCommand("Select * FROM Product", sqlconnection);
        if (sqlconnection.State == ConnectionState.Closed) sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        while (sqlDataReader.Read())
        {
            ProductObj product = new ProductObj();
            product.productId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ProductId"));
            product.productName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductName"));
            product.prodcutDescription = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductDescription"));
            // var x = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("Product_Price"));
            product.productPrice = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("Product_Price"));
            product.inStock = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
            products.Add(product);
        }


        sqlDataReader.Close();
        sqlconnection.Close();

        return products;
    }

    public ProductObj getProductByName(string selectedID)
    {
        ProductObj product = new ProductObj();

        SqlCommand sqlCommand = new SqlCommand("Select * FROM Product WHERE ProductName = @ProductName", sqlconnection);
        sqlCommand.Parameters.AddWithValue("@ProductName", selectedID);
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
            string queryStrng = "INSERT INTO [Order](userName, orderDate, isActive, orderCost) VALUES(@userName, @orderDate, @isActive, @orderCost)";
            SqlCommand sqlCommand = new SqlCommand(queryStrng, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@userName", order.userName);
            sqlCommand.Parameters.AddWithValue("@orderDate", order.orderDate);
            sqlCommand.Parameters.AddWithValue("@isActive", order.isActive);
            sqlCommand.Parameters.AddWithValue("@orderCost", order.orderCost);
            sqlconnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception error)
        {
            throw error;
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
            string queryStrng = "UPDATE [Order] SET isActive = @isActive, orderCost = @orderCost, cancelReason = @cancelReason, resolveDate = @resolveDate WHERE orderId = @orderId";
            SqlCommand sqlCommand = new SqlCommand(queryStrng, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@orderId", order.orderId);
            sqlCommand.Parameters.AddWithValue("@isActive", order.isActive);
            sqlCommand.Parameters.AddWithValue("@orderCost", order.orderCost);
            if (order.cancelReason == null)
            {
                sqlCommand.Parameters.AddWithValue("@cancelReason", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@cancelReason", order.cancelReason);
            }

            if (order.resolveDate == null)
            {
                sqlCommand.Parameters.AddWithValue("@resolveDate", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@resolveDate", order.resolveDate);
            }
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
            throw error;
        }
        finally
        {
            sqlconnection.Close();
        }
        return true;
    }

    public bool editProduct(ProductObj product)
    {
        try
        {
            sqlconnection.Open();
            SqlCommand sqlcmd = new SqlCommand("ProductCreateOrUpdate", sqlconnection);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@ProductId", product.productId);
            sqlcmd.Parameters.AddWithValue("@ProductName",product.productName);
            sqlcmd.Parameters.AddWithValue("@ProductDescription", product.prodcutDescription);
            sqlcmd.Parameters.AddWithValue("@Quantity", product.inStock);
            sqlcmd.Parameters.AddWithValue("@Product_Price", product.productPrice);
            sqlcmd.ExecuteNonQuery();
        }
        catch (Exception ex)
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
        setActiveOfOrder(order);
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
            int realOrderId = getOrderByLast().orderId;
            string queryStrng = "INSERT INTO OrderProductBridge(orderId, productId, amount) VALUES(@orderId, @productId, @amount)";
            List<ProductObj> products = order.products;
            List<int> amounts = order.amounts;
            int orderId = order.orderId;
            SqlCommand sqlCommand = new SqlCommand();
            sqlconnection.Open();
            sqlCommand.Connection = sqlconnection;
            for (int i = 0; i < products.Count; i++)
            {
                sqlCommand.CommandText = queryStrng;
                sqlCommand.Parameters.AddWithValue("@orderId", realOrderId);
                sqlCommand.Parameters.AddWithValue("@productId", products[i].productId);
                sqlCommand.Parameters.AddWithValue("@amount", amounts[i]);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
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
        SqlCommand sqlCommand = new SqlCommand("Select * FROM [Order] WHERE orderId = @orderId", sqlconnection);
        sqlCommand.Parameters.AddWithValue("@orderId", orderId);
        sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.Read())
        {
            order.orderId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("orderId"));
            order.userName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("userName"));
            order.orderDate = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("orderDate"));
            order.orderCost = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("orderCost"));
            string isActve = sqlDataReader.GetString(sqlDataReader.GetOrdinal("isActive"));
            if (isActve == "A")
            {
                order.isActive = "FINALIZED";
            }
            else if (isActve == "C")
            {
                order.isActive = "CANCELLED";
            }
            else if (isActve == "P")
            {
                order.isActive = "PENDING";
            }
        }
        sqlDataReader.Close();
        sqlconnection.Close();
        order.products = getProductsByOrderId(orderId);
        order.amounts = tempAmounts;
        tempAmounts = new List<int>();
        
        return order;
    }

    public List<OrderObj> getAllPendingOrders()
    {
        List<OrderObj> orders = new List<OrderObj>();
        SqlCommand sqlCommand = new SqlCommand("Select * FROM [Order] WHERE isActive = @isActive", sqlconnection);
        sqlconnection.Open();
        sqlCommand.Parameters.AddWithValue("@isActive", 'P');
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            OrderObj order = new OrderObj();
            order.orderId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("orderId"));
            order.userName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("userName"));
            order.orderDate = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("orderDate"));
            order.orderCost = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("orderCost"));
            string isActve = sqlDataReader.GetString(sqlDataReader.GetOrdinal("isActive"));
            if (isActve == "A")
            {
                order.isActive = "FINALIZED";
            }
            else if (isActve == "C")
            {
                order.isActive = "CANCELLED";
            }
            else if (isActve == "P")
            {
                order.isActive = "PENDING";
            }
            orders.Add(order);
        }
        sqlDataReader.Close();
        sqlconnection.Close();
        return orders;
    }

    public List<OrderObj> getAllOrders()
    {
        List<OrderObj> orders = new List<OrderObj>();
        SqlCommand sqlCommand = new SqlCommand("Select * FROM [Order]", sqlconnection);
        sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            OrderObj order = new OrderObj();
            order.orderId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("orderId"));
            order.userName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("userName"));
            order.orderDate = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("orderDate"));
            order.orderCost = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("orderCost"));
            string isActve = sqlDataReader.GetString(sqlDataReader.GetOrdinal("isActive"));
            if (isActve == "A")
            {
                order.isActive = "FINALIZED";
            } else if (isActve == "C")
            {
                order.isActive = "CANCELLED";
            } else if (isActve == "P")
            {
                order.isActive = "PENDING";
            }
            orders.Add(order);
        }
        sqlDataReader.Close();
        sqlconnection.Close();
       
        return orders;
    }

    public OrderObj getOrderByLast()
    {
        OrderObj order = new OrderObj();
        SqlCommand sqlCommand = new SqlCommand("Select TOP 1 * FROM [Order] ORDER BY orderId DESC", sqlconnection);
        sqlconnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.Read())
        {
            order.orderId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("orderId"));
            order.userName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("userName"));
            order.orderDate = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("orderDate"));
            order.orderCost = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("orderCost"));
        }

        sqlconnection.Close();
        order.products = getProductsByOrderId(order.orderId);
        order.amounts = tempAmounts;
        tempAmounts = new List<int>();
        return order;
    }
    public List<ProductObj> getProductsByOrderId(int orderId)
    {
        List<ProductObj> products = new List<ProductObj>();
        List<int> ids = new List<int>();
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
            ids.Add(productId);
        }
        sqlconnection.Close();

        for(int i = 0; i < ids.Count; i++)
        {

            products.Add(getProduct(ids[i] + ""));
        }

;        return products;
    }

    public List<OrderObj> getOrdersByUserId(string userName)
    {
        List<OrderObj> orders = new List<OrderObj>();
        List<int> orderIds = new List<int>();
        SqlCommand sqlCommand = new SqlCommand("Select * FROM [Order] WHERE userName = @userName", sqlconnection);
        sqlconnection.Open();
        sqlCommand.Parameters.AddWithValue("@userName", userName);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            int orderId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("orderId"));
            orderIds.Add(orderId);
            
        }
        sqlconnection.Close();

        foreach(int id in orderIds)
        {
            orders.Add(getOrderById(id));
        }

        return orders;
    }



}