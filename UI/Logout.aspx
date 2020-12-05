<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="UI.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Tra</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="CSS/Login.css" />

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

    <div class="container mx-auto" style="width: 400px;">
        <form class="test" runat="server">
            <div class="form-group">
                <div class="container-fluid">
                    <h3>Cerrar Sesión:</h3>
                </div>
            </div>
            <div class="container-fluid bg-1 text-center">
                <img src="Images/8.png" class="img-circle" alt="clock" width="auto" height="auto">
                <h3 id="userName" runat="server" class="txt"></h3>
            </div>

            <div class="container-fluid bg-2 text-center">
                <br />
                <br />
                <input type="submit" value="LogOut" runat="server" id="cmdSignOut" class="btn" style="background-color: #f5f0bf" onmouseover="this.style.color='#808080'; this.style.textDecoration='none'" onmouseout="this.style.color='#000000'; this.style.textDecoration='none'">
            </div>
        </form>
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
