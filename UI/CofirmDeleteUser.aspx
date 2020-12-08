<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CofirmDeleteUser.aspx.cs" Inherits="UI.CofirmDeleteUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Confirmar Eliminar Usuario</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/ConfirmD.css" />

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

    <form id="form1" runat="server" class="formConf">
        <div class="formLabels">
            <img src="Images/3.png" class="image"/>
            <div class="textBlock">
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button CssClass="btnStyle" ID="deletebtn" runat="server" Text="Eliminar" OnClick="deletebtn_Click" />
            <asp:Button CssClass="btnStyle" ID="cancelbtn" runat="server" Text="Cancelar" OnClick="cancelbtn_Click" />
        </div>
    </form>

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
