using System;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    //connection to the database 
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //try catch to check if the conncetion to the database if closed 
        try
        {
            sqlconnection.Close();

        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        sqlconnection.Open();
        string checkquery = "Select count(1) from Login where Username='"+txtUserName.Text+"' and Password='"+txtPassword.Text.Trim()+"'";
        SqlCommand cmd = new SqlCommand(checkquery,sqlconnection);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count == 1)
        {
           //creates a session
            Session["user"] = txtUserName.Text.Trim();
            Response.Redirect("Home.aspx");
            
        }
        else
        {
            //lebel error if the login is not succeful. if user input incorrect username or password 
            lblerror.Text = "Login Failed. Incorrect Username or Password!";
        }
        sqlconnection.Close();
    }

    // Thi sbutton refreshs the the fields .of user name and password 
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
    }
}