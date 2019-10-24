<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Compatibility.aspx.cs" Inherits="Compatibility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class ="row p-8">
       
    <div   class="bg-white p-15 mx-auto border bd-default win-shadow cell mt-4 ml-8-xl">

         <div>
               <h3 class="text-cap text-bold">Compatibility Rule</h3>
        </div>
        <div class="row border bd-default cell mt-2 p-4">
            <asp:DropDownList ID="DdList" onselectedindexchanged="btnSubmit_Click" AutoPostBack="True" runat="server"></asp:DropDownList>

        </div>
     
        <div class="row bd-default cell">
        <div class="row border bd-default cell mt-2 p-4 float-left">
            <asp:CheckBoxList ID="CheckBoxList1"   runat="server" Width="450px"></asp:CheckBoxList>


        </div>

   <div class="float-right bd-default cell mt-2 p4">
       <asp:Label ID="lblRules" runat="server" Text=""></asp:Label>
       <asp:BulletedList ID="LtRules" runat="server"></asp:BulletedList>
 </div>
            
</div>

        <div class=" float-left order-1 bd-default cell mt-2 p-4">
            <asp:button runat="server" class="button success" OnClick="btnSubmit_Event" id="btnSubmit" text="submit" />
            <asp:label runat="server" id="txtResult" text="Label"></asp:label>

        </div>       

    </div>
   </div>
</asp:Content>

