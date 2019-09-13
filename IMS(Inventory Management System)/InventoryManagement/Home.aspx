<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
.container {
  position: relative;
  width: 100%;
  max-width: 400px;
}

.container img {
  width: 100%;
  height: auto;

}


.button {
  background-color:#006699;
  border:none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 20px;
  margin: 4px 2px;
  cursor: pointer;
  border-radius:50%;
}


.container .btn {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  background-color: #555;
  color: white;
  font-size: 16px;
  padding: 12px 24px;
  border: none;
  cursor: pointer;<asp:Button ID="Button1" CssClass="button" runat="server" Text="Purchases" style="left: 33%; top: 14%; width: 329px; height: 68px;" OnClick="Button1_Click" />
  border-radius: 5px;
  text-align: center;
}

.container .btn:hover {
  background-color: black;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="background-color:#4caf50;padding:14px 20px">
        <div  style="margin-top:30px;margin-bottom:20px">
              
        </div>

        <div style="margin-top:20px;margin-bottom:20px">
              <asp:Button ID="Button2" CssClass="button" runat="server" Text="sales" style="left: 33%; top: 46%; width: 329px; height: 68px;" OnClick="Button2_Click" />

        </div>

        <div style="margin-top:20px;margin-bottom:20px">
              <asp:Button ID="Button4" CssClass="button" runat="server"  Text="Products" style="left: 33%; top: 63%; width: 329px; height: 68px;" OnClick="Button4_Click" />

        </div>

        <div style="margin-top:20px;margin-bottom:20px">
        <asp:Button ID="Button3" CssClass="button" runat="server" Text="Suppliers" style="left: 33%; top: 29%; width: 329px; height: 68px;" OnClick="Button3_Click" />

        </div>

       </div>
</asp:Content>

