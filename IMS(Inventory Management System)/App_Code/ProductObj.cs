using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Component
/// </summary>
public class ProductObj
{
    public int productId { get; set; }
    public string productName { get; set; }
    public string prodcutDescription { get; set; }
    public int inStock { get; set; }
    public float productPrice { get; set; }

    public ProductObj()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ProductObj(int productId, string productName, string prodcutDescription, int inStock, float productPrice)
    {
        this.productId = productId;
        this.productName = productName;
        this.prodcutDescription = prodcutDescription;
        this.inStock = inStock;
        this.productPrice = productPrice;
    }

}