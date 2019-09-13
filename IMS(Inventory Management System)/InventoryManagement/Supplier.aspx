<%@ Page Title="Supplier" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Supplier.aspx.cs" Inherits="Supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
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
       .auto-style44 {
           height: 38px;
       }
       .auto-style45 {
           height: 30px;
       }
       .auto-style46 {
           height: 39px;
       }
       .auto-style47 {
           color: #000066;
           width: 579px;
       }
       .auto-style48 {
           margin-left: 0;
       }
       .auto-style49 {
           width: 154px;
       }
       .auto-style50 {
           height: 30px;
           width: 124px;
       }
       .auto-style51 {
           height: 30px;
           width: 154px;
       }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="auto-style41">
         <div style="align-content:center;height:32px;margin-top:20px;text-align:center" >
             <h3 class="auto-style52" style="font-size: xx-large; color: #003399">Register Suppliers</h3>
         </div>


         <div>
        <asp:HiddenField ID="hfSupplierId" runat="server" />
    <table class="auto-style47" style="border: thin solid #CCCCCC; align-content:flex-end; margin-left:30%">
        <tr>
            <td class="auto-style45" colspan="1" style="font-size: medium; font-family: Arial, Helvetica, sans-serif">Company Name:</td>
            <td class="auto-style51" colspan="2">
                <asp:TextBox ID="txtComName" runat="server" Width="344px" Height="31px"></asp:TextBox>
            </td>
        </tr>
        <tr>>
            <td class="auto-style45" colspan="1">Trading Licence No :</td>
            <td class="auto-style45" colspan="2">
                <asp:TextBox ID="txtTradeLiNo" runat="server" Width="344px" CssClass="auto-style48" Height="31px"></asp:TextBox>
            </td>
        </tr>
        <tr>>
            <td  colspan="1">Cell Number:</td>
            <td class="auto-style45" colspan="2">
                <asp:TextBox ID="txtMobileNo" runat="server" Width="344px" Height="31px"></asp:TextBox>
            </td>
        </tr>
        <tr>>
            <td class="auto-style45" colspan="1">Address:</td>
            <td class="auto-style45" colspan="2">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" MaxLength="99" Width="128px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td class="auto-style46">
                <asp:Button ID="btnsave" style="border-style: none; border-color: inherit; border-width: medium; background-color:#4caf50; color:white; padding:14px 20px; margin:8px 0; cursor:pointer" runat="server" Text="Save" Font-Bold="True" OnClick="btnsave_Click" Width="120px" Height="42px" />
            </td>
            <td class="auto-style49">
                <asp:Button ID="btndelete" style="border-style: none; border-color: inherit; border-width: medium; background-color:#f44336; color:white; padding:14px 20px;margin:8px 10px; cursor:pointer;" runat="server" Text="Delete" Width="120px" Height="42px" Font-Bold="True" OnClick="btndelete_Click" />
            </td>
            <td class="auto-style50">
                <asp:Button ID="btnclear" style="border-style: none; border-color: inherit; border-width: medium; background-color:#1f2021; color:white; padding:14px 20px;margin:8px 10px; cursor:pointer" runat="server" Width="120px" Height="42px" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" />
            </td>
            <td class="auto-style44">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblsuccessmassage" runat="server" Text="" ForeColor="Green"></asp:Label>
                <asp:Label ID="lblerrormessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
             </div>
         <div style="align-content:center;height:32px;margin-top:20px;text-align:center">
        <h4>
            
            <span style="color: #003399; font-size: xx-large">List of Suppliers</span><br />
        
        </h4>
             </div>
        <div class="container">
        <asp:GridView ID="supplierGrid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" Height="194px" Width="634px">
            <AlternatingRowStyle BackColor="White" />
            <columns>
                <asp:BoundField Datafield="SupplierId" HeaderText="Supplier Id" />
                <asp:BoundField Datafield="CompanyName" HeaderText="Company Name" />
                <asp:BoundField Datafield="TradeNo" HeaderText="Trade Licence No" />
                <asp:BoundField Datafield="MobileNo" HeaderText="Mobile Number" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("SupplierId") %>' OnClick="lnk_onClick">Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Green" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
            <br />
        </div>
</div>
</asp:Content>

