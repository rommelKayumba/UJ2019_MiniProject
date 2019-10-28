<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <style type="text/css">
        .auto-style41 {
            text-align: center;
        }

        .myTableClass tr th {
    padding: 5px;
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

    <div class="bg-white p-6 mx-auto border bd-default win-shadow cell w-60 position-bottom mt-4 ml-8-xl">

                <h3 class="text-bold text-medium fg-blue">Orders </h3>
                <asp:GridView CssClass="table" ID="productGrid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="5" CellSpacing="5" ForeColor="#333333" GridLines="None" Height="205px" Width="501px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderId" HeaderText="Order Number" />
                        <asp:BoundField DataField="userName" HeaderText="Customer" />
                        <asp:BoundField DataField="isActive" HeaderText="State" />
                        <asp:BoundField DataField="orderDate" HeaderText="Oder Date" />
                        <asp:TemplateField HeaderText="editTemplate" ShowHeader="False" runat="server">
                            <ItemTemplate>
                                   <asp:LinkButton CssClass="button outline primary" ID="lnkEdit" runat="server" CommandArgument='<%# Eval("orderId") %>' OnClick="lnk_edit">Edit/View</asp:LinkButton>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                               <asp:LinkButton CssClass="button outline primary warning" ID="lnkCancel" runat="server" CommandArgument='<%# Eval("orderId") %>' OnClick="lnk_cancel">Cancel</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
</asp:Content>

