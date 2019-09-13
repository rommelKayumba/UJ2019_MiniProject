<%@ Page Title="Product" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

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
        width: 8px;
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
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="auto-style41">
    <h3 class="auto-style52" style="font-size: xx-large">Product Registration</h3>
        <asp:HiddenField ID="hfProductId" runat="server" />
    <table class="auto-style42">
        <tr>
            <td class="auto-style43" colspan="2">Product Name:</td>
            <td class="auto-style44" colspan="2">
                <asp:TextBox ID="txtproname" runat="server" Width="145px" Height="34px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Product Description:</td>
            <td class="auto-style44" colspan="2">
                <asp:TextBox ID="txtprodes" runat="server" TextMode="MultiLine" MaxLength="99" Width="145px" Height="34px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style46">
                <asp:Button ID="btnsave" style="border-style: none; border-color: inherit; border-width: medium; background-color:#4caf50; color:white; padding:14px 20px; margin:8px 0;" runat="server" Text="Save" Font-Bold="True" OnClick="btnsave_Click" Width="110px" CssClass="auto-style53" />
            </td>
            <td class="auto-style49">
                <asp:Button ID="btndelete" style="background-color:red;color:white;padding:14px 20px;margin:8px 0;border:none;cursor:pointer" runat="server" Text="Delete" Width="110px" Font-Bold="True" />
            </td>
            <td class="auto-style50">
                <asp:Button ID="btnclear" style="background-color:#1f2021;color:white;padding:14px 20px;margin:8px 0;border:none;cursor:pointer" runat="server" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" />
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
            <span class="auto-style52" style="font-size: xx-large">List of Products</span><br />
        <br />
        </h4>
        <div class="auto-style51">
        <asp:GridView ID="productGrid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" Height="205px" Width="501px">
            <AlternatingRowStyle BackColor="White" />
            <columns>
                <asp:BoundField Datafield="ProductId" HeaderText="Product Id" />
                <asp:BoundField Datafield="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="ProductDescription" HeaderText="Product Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ProductId") %>' OnClick="lnk_onClick">Select</asp:LinkButton>
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

