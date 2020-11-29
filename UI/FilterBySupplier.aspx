<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilterBySupplier.aspx.cs" Inherits="UI.FilterBySupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblSupplier" runat="server" Text="Proveedor"></asp:Label>
    <asp:TextBox ID="tbxInsertSupplierName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
    
    <br />
    <br />
    
    <div class="container text-center py-3">
        <div id="contentSuplierName" class="row justify-content-center py-3" runat="server">
        </div>
    </div>

</asp:Content>
