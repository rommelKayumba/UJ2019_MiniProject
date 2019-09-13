<%@ Page Title="Sales" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales.aspx.cs" Inherits="Sales" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
    .auto-style41 {
        text-align: center;
    }
    .auto-style42 {
        width: 100%;
    }
    .auto-style44 {
        text-align: left;
    }
        .auto-style51 {
            text-align: center;
        }
        .auto-style52 {
            color: #003399;
            font-weight: normal;
        }
           .auto-style54 {
            text-align: left;
            text-decoration: none;
        }
        .auto-style55 {
            color: #003399;
            text-align: center;
        }
        .auto-style56 {
            width: 100%;
            height: 140px;
        }
        .auto-style59 {
            width: 65%;
        }
         .auto-style77 {
            width: 5%;
        }
           .auto-style79 {
            width: 5%;
        }
          .auto-style78 {
            height: 30px;
        }
        
        .auto-style60 {
            width: 173px;
            text-align: center;
        }
        .auto-style65 {
            width: 10%;
            height: 30px;
        }
        .auto-style68 {
            width: 173px;
            color: #0033CC;
            height: 26px;
            text-align: right;
        }
        .auto-style69 {
            width: 28px;
            height: 30px;
        }
        .auto-style71 {
            color: #0033CC;
            text-align: center;
        }
        .auto-style72 {
            width: 65%;
            height: 26px;
            text-align: center;
            color: #003399;
        }
        .auto-style73 {
            width: 15%;
            color: #0033CC;
            text-align: right;
        }
        .auto-style74 {
            color: #0033CC;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
   <div class="auto-style54">
    <h3 class="auto-style55" style="font-size: xx-large">Sales</h3>
       <div class="auto-style44">
           
           <table class="auto-style56">
               <tr>
                   <td class="auto-style78">&nbsp;</td>
                   <td class="auto-style65">
                       &nbsp;</td>
                   <td class="auto-style65">
                       &nbsp;</td>
                   <td class="auto-style72" colspan="2"><strong>Search Results</strong></td>
                   <td class="auto-style79">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style74">
                       Search Product Name:</td>
                   <td class="auto-style71">
                <asp:TextBox ID="TextBox2" Width="128px" runat="server" OnTextChanged="TextBox2_TextChanged" AutoPostBack="True" Height="28px"></asp:TextBox>
                       <ajaxToolkit:AutoCompleteExtender ID="TextBox2_AutoCompleteExtender" runat="server" MinimumPrefixLength="1" ServiceMethod="GetSearch" TargetControlID="TextBox2">
                       </ajaxToolkit:AutoCompleteExtender>
                   </td>
                   <td class="auto-style77" rowspan="7">&nbsp;
                        
                   </td>
                   <td class="auto-style59" rowspan="7" style="border:thin solid #003300">
            <asp:GridView ID="searchGrid" runat="server" AutoGenerateColumns="False" AutoPostBack="true" HorizontalAlign="Center" OnSelectedIndexChanged="searchGrid_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="199px" Width="448px">
                <AlternatingRowStyle BackColor="White" />
                <columns>
                    <asp:BoundField Datafield="ProductName" HeaderText="Product Name" />
                    <asp:BoundField Datafield="CompanyName" HeaderText="Company Name" />
                    <asp:BoundField Datafield="total" HeaderText="Available Quantity" />
                    <asp:TemplateField>
                      
                    </asp:TemplateField>
                   
                    <asp:ButtonField CommandName="Select" Text="select" />
                   
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
                   </td>
                   <td class="auto-style79" rowspan="7">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style73">Company Name :</td>
                   <td class="auto-style65">
                <asp:TextBox ID="TextBox3" Width="128px" runat="server" AutoPostBack="True" Height="28px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style68">Available Quantity (Packet)</td>
                   <td class="auto-style69">
                <asp:TextBox ID="txtQuantity1" runat="server" Width="128px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" Height="28px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style73">Sell Quantity (Packet) :</td>
                   <td class="auto-style65">
                <asp:TextBox ID="txtQuantity2" runat="server" Width="128px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" Height="28px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style51" colspan="2">
                <asp:Button ID="btnsale" style="border-style: none; border-color: inherit; border-width: medium; background-color:#4caf50; color:white; padding:14px 20px; margin:5px 5px; cursor:pointer" runat="server" Text="Sale" Font-Bold="True" Width="120px" OnClick="btnsell_Click1" Height="42px" />
                <asp:Button ID="btnclear" style="border-style: none; border-color: inherit; border-width: medium; background-color:#1f2021; color:white; padding:14px 20px; margin:5px 0; cursor:pointer" runat="server" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" Width="120px" Height="42px" />
                   </td>
               </tr>
               <tr>
                   <td class="auto-style60" colspan="2" rowspan="2">
                <asp:Label ID="lblsuccessmassage" runat="server" Text="" ForeColor="Green"></asp:Label>
                       <br />
                <asp:Label ID="lblerrormessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                   </td>
                  
               </tr>
              
           </table>
       </div>
    <table class="auto-style42">
        <tr>
            <td class="auto-style44">
                &nbsp;</td>
        </tr>
    </table>
        <h4 class="auto-style51">
            <br />
            <span class="auto-style52"><strong style="font-size: xx-large">List of List</strong></span><br />
        </h4>
       <p class="auto-style51">
            
        <asp:GridView ID="SalesGrid" runat="server" AutoGenerateColumns="False" AutoPostBack="true" HorizontalAlign="Center" OnSelectedIndexChanged="searchGrid_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="220px" Width="461px">
                <AlternatingRowStyle BackColor="White" />
                <columns>
                    <asp:BoundField Datafield="SalesProductName" HeaderText="Product Name" />
                    <asp:BoundField Datafield="SalesCompanyName" HeaderText="Company Name" />
                    <asp:BoundField Datafield="SalesQuantity" HeaderText="Quantity (Packet)" />
                                       
                   <%-- <asp:ButtonField CommandName="Select" Text="select" />--%>
                   
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
           </p>
        <div class="auto-style51">
            <br />
        </div>
</div>
</asp:Content>

