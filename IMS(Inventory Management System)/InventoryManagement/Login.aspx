<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        body {font-family: Arial, Helvetica, sans-serif;}
form {border: 3px solid #f1f1f1;}

input[type=text], input[type=password] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

button {
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
}

button:hover {
  opacity: 0.8;
}

.cancelbtn {
  width: auto;
  padding: 10px 18px;
  background-color: #f44336;
}

.imgcontainer {
  text-align: center;
  margin: 24px 0 12px 0;
}

img.avatar {
  width: 40%;
  border-radius: 50%;
}

.container {
  padding: 16px;
}

span.psw {
  float: right;
  padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
  span.psw {
     display: block;
     float: none;
  }
  .cancelbtn {
     width: 100%;
  }
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div style="margin-left:250px;margin-right:250px"> 
       
        <div class="auto-style42">
            <h2 style="text-align:center"> Login </h2>
            
        </div>
        <div class="container">
            <label for="uname"><b> Username</b></label>
            <asp:TextBox  ID="txtUserName" placeholder="Enter Username" runat="server"></asp:TextBox>
            


            <label for="psw"><b> Password</b></label>
            <asp:TextBox ID="txtPassword" placeholder="Enter Password" runat="server"></asp:TextBox>
        
            <asp:Button ID="btnLogin" style="background-color:#4caf50; width: 100%;color:white;padding:14px 20px;margin:8px 0;border:none;cursor:pointer" runat="server"  Text="Login" OnClick="btnLogin_Click" />
           <div>
               <label>
                <asp:CheckBox ID="CheckBox1" runat="server"/>
                Remember Me
            </label>
           </div>

        </div>

       <div class="container" style="background-color:white">
                           
           <asp:Button CssClass="cancelbtn" ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" ForeColor="White"/>

           <asp:Label ID="lblerror" runat="server" ForeColor="#CC0000"></asp:Label>

       </div>
              
       </div>
           
</asp:Content>

