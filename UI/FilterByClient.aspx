<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilterByClient.aspx.cs" Inherits="UI.FilterByClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblClient" runat="server" Text="Cliente"></asp:Label>
    <asp:TextBox ID="tbxInsertClientName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Button" OnClick="btnSearch_Click" />
    
    <br />
    <br />
    
    <div class="container text-center py-3">
        <div id="contentClientsName" class="row justify-content-center py-3" runat="server">
        </div>
    </div>
</asp:Content>
