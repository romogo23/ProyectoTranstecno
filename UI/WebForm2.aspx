<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="UI.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LOL</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="CSS/Login.css"/>

</head>
<body>
    
    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Inicio</a>
            </div>
            <div class="navbar-right">
                <a class="navbar-brand" href="#">Iniciar Sesión</a>
            </div>
        </div>
    </nav>

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
</body>
</html>
