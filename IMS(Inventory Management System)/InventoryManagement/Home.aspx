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
    
    <div class="=row mt-5 mb-2">
        <div class="cell" style="text-align:center">
            <label class="text-bold" id="lblWelcome" runat="server"></label>

        </div>

    </div>


    <div class="row ml-3 pos-center pos-fixed">

        <div class="tiles-grid tiles-group">

            <div runat="server"  class="bg-blue" data-role="tile" data-size="medium" data-effect="hover-slide-left" id="btnProduct">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class="icon mif-apps"></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your Components
                    </p>
                </div>
                <span class="branding-bar">Components</span>
            </div>

            <div runat="server"  class="bg-amazon" data-role="tile" data-size="medium" data-effect="hover-slide-left" id="btnSupplier">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class="icon mif-truck"></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your Suppliers
                    </p>
                </div>
                <span class="branding-bar">Supplier</span>
            </div>
            </div>

            <div class="bg-amber" data-role="tile" data-size="medium" data-effect="hover-slide-left" runat="server" id="btnPurchase">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class="icon mif-cart"></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your purchases
                    </p>
                </div>
                <span class="branding-bar">Order</span>
            </div>

            <div  class="bg-green" data-role="tile" data-size="medium" data-effect="hover-slide-left" runat="server" id ="btnSales">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class="icon mif-money"></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your Sales
                    </p>
                </div>
                <span class="branding-bar">Sales</span>
            </div>


             


             <div runat="server" class="bg-pink" data-role="tile" data-size="medium" data-effect="hover-slide-left" id ="btncliens">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class="icon mif-money"></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your All your clients and Orders
                    </p>
                </div>
                <span class="branding-bar">Clients</span>
            </div>


             <div class="bg-yellow" data-role="tile" data-size="medium" data-effect="hover-slide-left" runat="server" id ="btnEntries">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class="icon mif-money"></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your all your entries
                    </p>
                </div>
                <span class="branding-bar">Report</span>
            </div>


             <div class="bg-red" data-role="tile" data-size="medium" data-effect="hover-slide-left" runat="server" id="btnStocks">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class="icon mif-money"></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your all your stocks and update them
                    </p>
                </div>
                <span class="branding-bar">Stocks</span>
            </div>


             <div class="bg-grey" data-role="tile" data-size="medium" data-effect="hover-slide-left"  runat="server" id="btnMatching">
                <div class="slide-front d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <span class=""></span>
                </div>
                <div class="slide-back d-flex flex-justify-center flex-align-center p-4 op-mauve">
                    <p class="text-center">
                        View your all matching components
                    </p>
                </div>
                <span class="branding-bar">Matching Components</span>
            </div>
        </div>

</asp:Content>

