<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceTest.aspx.cs" Inherits="UI.InvoiceTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="insert" runat="server" Text="Insert" OnClick="insert_Click" />
    <br />
    <br />
    <asp:Button ID="modify" runat="server" Text="modify" OnClick="modify_Click" />
    <br />
    <br />
    <asp:Button ID="close" runat="server" Text="Close" OnClick="close_Click" />
    <br />
    <br />
    <asp:Button ID="loadC" runat="server" Text="loadClient" OnClick="loadC_Click" />
    <br />
    <br />
    <asp:Button ID="loadDate" runat="server" Text="Load by date" OnClick="loadDate_Click" />
    <br />
    <br />
    <asp:GridView ID="grdClient" runat="server">
    </asp:GridView>
    <br />
    <asp:GridView ID="GridInvoice" runat="server">
    </asp:GridView>
</asp:Content>
