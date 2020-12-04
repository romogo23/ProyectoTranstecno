<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Transtecno S.A</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="CSS/Login.css"/>

</head>
<body>

    <!--Navigation bar-->
    <div id="nav-placeholder">
    </div>

    <script>
        $(function () {
            $("#nav-placeholder").load("navbarLogin.html");
        });
    </script>
    <!--end of Navigation bar-->

    <div class="container mx-auto" style="width: 400px;">
        <form class="test" runat="server">
            <div class="form-group">
                <div class="container-fluid">
                    <h3>Formulario de Inicio de Sesión:</h3>
                    </div>
                </div>
            <div class="form-group">
                <div class="container-fluid">
                    <label for="userName">Nombre de usuario:</label>
                    <input type="text" class="form-control" id="userName" runat="server"/>
                </div>
            </div>
            <div class="form-group">
                <div class="container-fluid">
                    <label id="lblPassword" for="pwd" runat="server">Contraseña:</label>
                    <input type="password" class="form-control" id="pwd" runat="server"/>
                </div>
            </div>
            <div class="container-fluid">
                <asp:Button ID="btnLogin" class="btn btn-default" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click"/>
            </div>
        </form>
    </div>
</body>
</html>
