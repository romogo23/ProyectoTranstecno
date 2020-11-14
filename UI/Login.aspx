<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mx-auto" style="width: 400px;">
        <form class="test" action="/action_page.php">
            <div class="form-group">
                <div class="container-fluid">
                    <h3>Formulario de Inicio de Sesión:</h3>
                    </div>
                </div>
            <div class="form-group">
                <div class="container-fluid">
                    <label for="userName">Nombre de usuario:</label>
                    <input type="text" class="form-control" id="email" />
                </div>
            </div>
            <div class="form-group">
                <div class="container-fluid">
                    <label for="pwd">Contraseña:</label>
                    <input type="password" class="form-control" id="pwd" />
                </div>
            </div>
            <div class="container-fluid">
                <button type="submit" class="btn btn-default">Iniciar Sesión</button>
            </div>
        </form>
    </div>
</asp:Content>
