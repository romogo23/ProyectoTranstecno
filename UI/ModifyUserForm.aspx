﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyUserForm.aspx.cs" Inherits="UI.ModifyUserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modificar Usuario</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/RegisterUser.css" />

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

    <form id="form1" runat="server" class="formImage">
        <div class="container fluid">
            <div class="resgisterForm">
                <h1 class="titleRegister">Modificar usuario:</h1>
                <div class="formlabels">
                    <label class="lblName">Correo:</label>
                    <%--<asp:TextBox type="email" class="form-control" id="email" runat="server" placeholder="Correo de usuario..." required="" OnTextChanged="email_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
                    <input type="email" class="form-control" id="email" runat="server" placeholder="Correo de usuario..." required=""/>
                    <label class="lblName">Contraseña:</label>
                    <input type="text" class="form-control" id="password" runat="server" placeholder="Contraseña..." required=""/>
                    <label class="lblName">Rol:</label>
                    <asp:DropDownList ID="rols" runat="server" CssClass="form-control">
                        <asp:ListItem Value="1">Administrador Secundario</asp:ListItem>
                        <asp:ListItem Value="2">Usuario Común</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnRegister" runat="server" Text="Modificar" OnClick="btnModify_Click" CssClass="btnR" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btnR" OnClick="btnCancel_Click" />
            </div>
        </div>

        <%--<script>
            function checkInput(obj) {
                //location.reload();
                //document.email.value = "Hola";
                //alert(obj.value);
                //WebForm_DoPostBackWithOptions(obj.value);
            }
        </script>--%>

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
