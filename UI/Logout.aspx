<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="UI.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cerrar Sesión</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="CSS/Logout.css" />

</head>
<body>

    <!--Navigation bar-->
    <div id="nav-placehold">
    </div>

    <script>
        $(function () {
            $("#nav-placehold").load("navbarAdmin.html");
        });
    </script>
    <!--end of Navigation bar-->

    <div class="container mx-auto">
        <form class="test" runat="server">
            <div class="container-fluid">
                <div class="form-group">
                    <div class="containerT">
                        <h3 class="tittle">¿Desea cerrar sesión?</h3>
                    </div>
                </div>
                <div class="containerT text-center">
                    <img src="Images/8.png" class="img-circle" alt="clock" width="200px" height="200px">
                    <h3 id="userName" runat="server" class="tittle"></h3>
                </div>

                <div class="containerT text-center">
                    <input type="submit" value="Cerrar Sesión" runat="server" id="cmdSignOut" class="btn">
                </div>
        </form>
    </div>
    </div>
    

    <%--<form id="form1" runat="server" class="formImage">
        <div class="jumbotron fluid" style="background-image: url(Images/def.jpg); background-repeat: no-repeat; background-position: center; background-size: cover; background-position-y: unset;">
            <div class="container text-center">
                <asp:Label ID="lblLogOutText" runat="server" Text="">
                    <h1 id="h1LogOut" runat="server"><span class="glyphicon glyphicon-user"></span></h1>
                </asp:Label>
            </div>
        </div>


    </form>--%>

    <!--Footer-->
    <footer id="foot-placehold">
    </footer>

    <script>
        $(function () {
            $("#foot-placehold").load("generalFooter.html");
        });
    </script>
    <!--end of Footer-->

</body>
</html>
