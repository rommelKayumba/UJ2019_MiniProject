<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
* {
  box-sizing: border-box;
}

/* Add padding to containers */
.container {
  padding: 16px;
  background-color: white;
}

/* Full-width input fields */
input[type=text], input[type=password] {
  width: 100%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}

input[type=text]:focus, input[type=password]:focus {
  background-color: #ddd;
  outline: none;
}

/* Overwrite default styles of hr */
hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

/* Set a style for the submit button */
.registerbtn {
  background-color: #4CAF50;
  color: white;
  padding: 16px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}

.registerbtn:hover {
  opacity: 1;
}

/* Add a blue text color to links */
a {
  color: dodgerblue;
}

/* Set a grey background color and center the text of the "sign in" section */
.signin {
  background-color: #f1f1f1;
  text-align: center;
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form>
  <div class="container">
    <h1 style="color:#006699">Register new User</h1>
      
    <p>Please fill in this form to create a new user.</p>
    <hr>

      <div>
           <label style="color:#006699" for="email"><b>Username</b></label>
      <asp:TextBox ID="txtRegUser" placeholder="Enter Username" runat="server"></asp:TextBox>
      </div>
   

      <div>
           <label style="color:#006699" for="psw"><b>Password</b></label>
            <asp:TextBox ID="txtRegPassword" placeholder="Enter password" runat="server"></asp:TextBox>
      </div>
   
    
    <hr>
    <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>
      <asp:Button ID="btnRegister" style="background-color:#4caf50; width: 70%;color:white;padding:14px 20px;margin:8px 0;margin-left:150px;border:none;cursor:pointer" runat="server" Text="Register" />
  </div>
  
  <div class="container signin">
    <p>Already have an account? <a href="Login.aspx">Sign in</a>.</p>
  </div>
</form>

</asp:Content>

