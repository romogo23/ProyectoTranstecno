<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilterByDate.aspx.cs" Inherits="UI.FilterByDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblStartDate" runat="server" Text="Fecha de Inicio"></asp:Label>
     <br />
    <asp:TextBox ID="TxtStartDate" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblendDate" runat="server" Text="Fecha de Final"></asp:Label>
     <br />
    <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    
    <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
    <br />

    <div class="container text-center py-3">
        <div id="contentInvoiceByDate" class="row justify-content-center py-3" runat="server">
        </div>
    </div>

    <div class="container text-center py-3">
        <div id="contentInvoiceSupplier" class="row justify-content-center py-3" runat="server">
        </div>
    </div>

</asp:Content>
