<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceSupplierTest.aspx.cs" Inherits="UI.InvoiceSupplierTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
    <asp:Button ID="Modify" runat="server" OnClick="Modify_Click" Text="Modify" />
    <asp:Button ID="Close" runat="server" OnClick="Close_Click" Text="Close" />
    <asp:Button ID="LoadSupplier" runat="server" OnClick="LoadSupplier_Click" Text="Load Supplier" />
    <asp:Button ID="LoadByDate" runat="server" OnClick="LoadByDate_Click" Text="Load By Date" />
    <asp:GridView ID="grdSupplier" runat="server">
    </asp:GridView>
    <asp:GridView ID="grdInvoice" runat="server">
    </asp:GridView>
</asp:Content>
