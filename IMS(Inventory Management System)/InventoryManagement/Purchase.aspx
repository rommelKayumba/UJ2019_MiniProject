﻿<%@ Page Title="Purchase" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style type="text/css">
    .auto-style41 {
        text-align: center;
    }
    .auto-style42 {
        width: 100%;
    }
    .auto-style43 {
            text-align: right;
            width: 608px;
        }
    .auto-style44 {
        text-align: left;
    }
        .auto-style46 {
        text-align: right;
        width: 571px;
    }
    .auto-style49 {
        text-align: center;
        width: 11px;
    }
    .auto-style50 {
        text-align: center;
        width: 73px;
    }
        .auto-style51 {
            text-align: center;
        }
        .auto-style52 {
            color: #003399;
        }
           .auto-style53 {
               margin-left: 0px;
           }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="auto-style41">
    <h3 class="auto-style52" style="font-size: xx-large">Purchase</h3>
        <asp:HiddenField ID="hfPurchaseId" runat="server" />
    <table class="auto-style42">
        <tr>
            <td class="auto-style43" colspan="2">Product Name:</td>
            <td class="auto-style44" colspan="2">
                <asp:DropDownList ID="DropDownProduct" runat="server" Height="30px" Width="142px" AppendDataBoundItems="True"  OnSelectedIndexChanged="DropDownProduct_SelectedIndexChanged">
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Supplier Name :</td>
            <td class="auto-style44" colspan="2">
                <asp:DropDownList ID="DropDownSupplier" runat="server" Height="30px" Width="142px" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownSupplier_SelectedIndexChanged">
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Quantity (Packet):</td>
            <td class="auto-style44" colspan="2">
                <asp:TextBox ID="txtQuantity" runat="server" Width="142px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" Height="30px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Others :</td>
            <td class="auto-style44" colspan="2">
                <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" MaxLength="99" Width="142px" CssClass="auto-style53"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style46">
                <asp:Button ID="btnsave"  style="border-style: none; border-color: inherit; border-width: medium; background-color:#4caf50; color:white;padding:14px 20px;margin:8px 0;border:none;cursor:pointer" runat="server" Text="Save" Font-Bold="True" OnClick="btnsave_Click" Width="128px" />
            </td>
            <td class="auto-style49">
                <asp:Button ID="btndelete" style="border-style: none; border-color: inherit; border-width: medium; background-color:darkred; color:white;padding:14px 20px;margin:8px 0;border:none;cursor:pointer" runat="server" Text="Delete" Width="128px" Font-Bold="True" OnClick="btndelete_Click" CssClass="auto-style53" />
            </td>
            <td class="auto-style50">
                <asp:Button ID="btnclear" style="border-style: none; border-color: inherit; border-width: medium; background-color:#1f2021; color:white;padding:14px 20px;margin:8px 0;border:none;cursor:pointer" runat="server" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" Width="128px" />
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
        <h4>
            <br />
            <span class="auto-style52" style="font-size: xx-large">Purchase List</span><br />
        <br />
        </h4>
        <div class="auto-style51">
        <asp:GridView ID="purchaseGrid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" OnSelectedIndexChanged="purchaseGrid_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Height="171px" Width="530px">
            <AlternatingRowStyle BackColor="White" />
            <columns>
                <asp:BoundField Datafield="PurchaseId" HeaderText="Purchase Id" />
                <asp:BoundField Datafield="ProductName" HeaderText="Product Name" />
                <asp:BoundField Datafield="CompanyName" HeaderText="Supplier Name" />
                <asp:BoundField Datafield="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Others" HeaderText="Others" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("PurchaseId") %>' OnClick="lnk_onClick">Select</asp:LinkButton>
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

