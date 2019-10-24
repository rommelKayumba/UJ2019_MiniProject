using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Compatibility : System.Web.UI.Page
{
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");
    string selectedID;
    DatabaseHelper dbHelper;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtbl = new DataTable();
        
        try
        {

            SqlCommand sqlCommand = new SqlCommand("Select * FROM Product", sqlconnection);
            sqlconnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            dtbl.Load(sqlDataReader);
            sqlDataReader.Close();
            sqlconnection.Close();
        }
        catch (Exception error)
        {
            throw error;
        }

        if (!IsPostBack)
        {
            DdList.DataSource = dtbl;
            DdList.DataValueField = "ProductId";
            DdList.DataTextField = "ProductName";
            DdList.DataBind();
        }

    }

    public void populateCheckBox(string selectedID)
    {
        List<ProductObj> products = new List<ProductObj>();
        dbHelper = new DatabaseHelper();
        try
        {
            SqlCommand sqlCommand = new SqlCommand("Select * FROM Product WHERE ProductId <> " + selectedID, sqlconnection);
            sqlconnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<string> compatibilityRules = dbHelper.getExistingRulesbyID(selectedID);
            while (sqlDataReader.Read())
            {
                ProductObj product = new ProductObj();
                product.productId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ProductId"));
                product.productName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductName"));

                if (!compatibilityRules.Contains(product.productId + ""))
                {
                    products.Add(product);
                }

            }

            sqlDataReader.Close();
            sqlconnection.Close();
        }
        catch (Exception error)
        {
            throw error;
        }
        
        CheckBoxList1.DataSource = products;
        //CheckBoxList1.DataValueField = 'productId';
        //CheckBoxList1.DataTextField = 'productName';
        CheckBoxList1.DataBind();

        populateRulesList(selectedID);
    }

    private void populateRulesList(string selectedID)
    {
        dbHelper = new DatabaseHelper();
        List<string> lstCompatibility = new List<string>();
        lstCompatibility = dbHelper.getExistingRules(selectedID);
        LtRules.DataSource = lstCompatibility;
        LtRules.DataBind();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        selectedID = DdList.SelectedValue + "";
        populateCheckBox(selectedID);
    }

    protected void btnSubmit_Event(object sender, EventArgs e)
    {

        List<string> checkedIDs = new List<string>();



        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                checkedIDs.Add(CheckBoxList1.Items[i].Value + "");
            }
        }

        foreach (string id in checkedIDs)
        {
            saveCompatbailityValue(DdList.SelectedValue + "", id);
        }


    }

    private void saveCompatbailityValue(string selectedID, string checkedIDs)
    {
        string sqlquery = "INSERT INTO  Compatibility (ComponentAID,ComponentBID) VALUES( " + selectedID + "," + checkedIDs + ")";
        try
        {
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconnection);
            sqlconnection.Open();
            sqlCommand.ExecuteReader();
            sqlconnection.Close();
            txtResult.Text = "Compatibillity Rule Saved!!";
        }
        catch (Exception error)
        {
            throw error;
        }
    }


    




}