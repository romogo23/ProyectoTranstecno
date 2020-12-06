<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceClient.aspx.cs" Inherits="UI.InvoiceClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gdInvoiceClient" runat="server"></asp:GridView>
</asp:Content>
