<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministerUsers.aspx.cs" Inherits="UI.AdministerUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/ManageUser.css" />

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

    <form id="form1" runat="server">
        <div class="container fluid">
            <div class="AdminForm">
                <h1 class="titleAdmin">Gestionar usuario:</h1>
                <div class="formlabels">
                    <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" class="table table-borderless">
                        <Columns>
                            <%--<asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btnStyle"/ Text="Modificar">--%> <%--CAMBIAR LO DE ABAJO POR BOTONES--%>
                            <asp:BoundField DataField="UserName" />
                            <asp:BoundField DataField="UserName" HtmlEncode="False" DataFormatString="<a class='btn btn-default btn-w' href='ModifyUser.aspx?userName={0}'>Modificar</a>"/>
                            <asp:BoundField DataField="UserName" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='DeleteUser.aspx?userName={0}'>Eliminar</a>"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
