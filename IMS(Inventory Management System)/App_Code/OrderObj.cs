using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderObj
/// </summary>
public class OrderObj
{
    public int orderId;
    public int userId;
    public DateTime orderDate;
    public List<ProductObj> products;
    public List<int> amounts;
    public bool isActive;
    public string cancelReason;
    public DateTime resolveDate;
    

    public OrderObj()
    {
        products = new List<ProductObj>();
        amounts = new List<int>();
    }
}