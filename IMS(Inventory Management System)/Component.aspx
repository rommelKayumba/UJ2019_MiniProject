<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Component.aspx.cs" Inherits="Component" %>

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

     <div class="row">

        <div class="float-left">

            <div class="bg-white p-6 mx-auto border bd-default win-shadow cell mt-4 ml-8-xl">

                <h3 class="text-bold text-cap fg-blue"> Manage Components</h3>

                <asp:HiddenField ID="hfProductId" runat="server" />

                <div class="container">

                    <div>
                        <label for="uname"><b>Component Name</b></label>

                        <asp:TextBox ID="txtComponentname" runat="server"></asp:TextBox>

                    </div>


                    <div>
                        <label for="uname"><b>Component Description</b></label>

                        <asp:TextBox ID="txtComponentDescription" runat="server" TextMode="MultiLine"></asp:TextBox>

                    </div>

                    <div> 
                        <label for="uname"><b> Unit Price</b> </label>
                        <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>
                    </div>

                    <div>
                          <label for="uname"><b> Qunatity</b> </label>
                        <asp:TextBox ID="TxtQuantity" runat="server"></asp:TextBox>

                    </div>

                    <div>
                          <label for="uname"><b> Availability</b> </label>
                        <asp:TextBox ID="TxtAvailability" runat="server"></asp:TextBox>
                    </div>

                    <div>

                        <asp:Button ID="btnsave" CssClass="button success mt-2 w-30 " runat="server" Text="Save" Font-Bold="True" OnClick="btnsave_Click" style="left: 0px; top: 0px" />
                        <asp:Button ID="btnUpdate" CssClass="button alert mt-2 w-30 l-1" runat="server" Text="Update" Font-Bold="True" OnClick="btndelete_Click" />
                        <asp:Button ID="btnclear" CssClass="button secondary mt-2 w-30 ml-1" runat="server" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" />

                    </div>
                    <asp:Label ID="lblsuccessmassage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    <asp:Label ID="lblerrormessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
     </div>



    <div class="float-right">


            <div class="bg-white p-6 mx-auto border bd-default win-shadow cell w-60 position-bottom mt-4 ml-8-xl">

                <h3 class="text-bold text-medium fg-blue">List of Products </h3>
                <asp:GridView CssClass="table" ID="ComponentGrid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="5" CellSpacing="5" ForeColor="#333333" GridLines="None" Height="205px" Width="501px" OnSelectedIndexChanged="productGrid_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ComponetId" HeaderText="Component ID" />
                        <asp:BoundField DataField="ComponentName" HeaderText="Component Name" />
                        <asp:BoundField DataField="ComponentDescription" HeaderText="Component Description" />
                        <asp:BoundField DataField="ComponentPrice" HeaderText="Unit Price" />
                        <asp:TemplateField>
                            <ItemTemplate>
<%--                                <asp:LinkButton CssClass="button outline primary" ID="lnkView" runat="server" CommandArgument='<%# Eval("ProductId") %>' OnClick="lnk_onClick">Select</asp:LinkButton>--%>
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
        </div>


   


</asp:Content>

