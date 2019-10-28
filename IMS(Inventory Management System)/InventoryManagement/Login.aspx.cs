using System;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    //connection to the database 
    static SqlConnection sqlconnection = new SqlConnection(@"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4D736_uj2019;User Id=DB_A4D736_uj2019_admin;Password=rommel123456;");

    protected void Page_Load(object sender, EventArgs e)
    {
       Control LogoutLink = this.Master.FindControl("LogoutLink");

        LogoutLink.Visible = false;

        Control userDislay = this.Master.FindControl("usernameDisplay");

        var user = (Label)Master.FindControl("usernameDisplay");

        user.Text = "";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
    int Role = 0;
        bool success = false;
    
        //try catch to check if the conncetion to the database if closed 
        try
        {
            sqlconnection.Close();

        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            sqlconnection.Open();
            string checkquery = "Select * from Login where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(checkquery, sqlconnection);
            using (SqlDataReader mr = cmd.ExecuteReader())
            {
                if (mr.HasRows)
                {
                    while (mr.Read())
                    {
                        success = true;
                        Role = (int) mr["Role"];
               
                
                       
                    }
                }
            }

         
            //int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (success)
            {
                //creates a session
                Session["user"] = txtUserName.Text.Trim();
                Session["Role"] = Role;

                if (Role == 4)
                {
                    Session["level"] = "Customer";
                }
                if(Role == 3)
                {
                    Session["level"] = "Stock";
                }
                if (Role == 2)
                {
                    Session["level"] = "Manager";
                }
                if (Role == 1)
                {
                    Session["level"] = "Admin";

                }

                Response.Redirect("Home.aspx");

            }
            else
            {
                //lebel error if the login is not succeful. if user input incorrect username or password 
                lblerror.Text = "Login Failed. Incorrect Username or Password!";
            }
            sqlconnection.Close();

        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            
        }

    }

    // Thi sbutton refreshs the the fields .of user name and password 
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
    }
}
