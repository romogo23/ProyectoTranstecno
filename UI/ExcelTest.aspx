<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcelTest.aspx.cs" Inherits="WebApplication1.ExcelTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:FileUpload ID="FP" runat="server" />  
    <br />
     <asp:Button ID="btnLoadInvoice" runat="server" Text="Subir plantilla" OnClick="btnLoadInvoice_Click" /> 
    <br />
     <br />
     <asp:GridView ID="grdInvoice" runat="server"></asp:GridView>
     <br />
    <asp:Label ID="lblInformationInvoice" runat="server" Text=""></asp:Label>
    <br />
     <br />
    <asp:Button ID="btnUploadInvoice" runat="server" Text="Cargar plantilla" Visible="False" OnClick="btnUploadInvoice_Click" />
</asp:Content>
