<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcelTest.aspx.cs" Inherits="WebApplication1.ExcelTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:FileUpload ID="FP" runat="server" />  
     <asp:Button ID="Button1" runat="server" Text="Load Excel"  
             OnClick="Button1_Click" />  
     <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>


</asp:Content>
