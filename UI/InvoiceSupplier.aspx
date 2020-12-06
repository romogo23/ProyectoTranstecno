<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceSupplier.aspx.cs" Inherits="UI.InvoiceSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gdInvoiceSupplier" runat="server"></asp:GridView>
</asp:Content>
