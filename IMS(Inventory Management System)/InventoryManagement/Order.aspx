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

    <div class="container mt-3 ">
    <h1 class="text-center fg-black">Clients Orders</h1>
    <h3 class="text-center">With sorting and filtering</h3>

    <div class="d-flex flex-justify-center" id="activity">
        <div data-role="activity" data-type="cycle" data-style="color"></div>
    </div>

        <table class="table striped table-border mt-4"
           data-role="table"
           data-cls-component="mt-10"
           data-rows="10"
           data-source="table-100k.json"
           data-pagination="true"
           data-show-all-pages="false"
           data-on-data-loaded="$('#activity').remove()"
    ></table>
  </div>
</asp:Content>

