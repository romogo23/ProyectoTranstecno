<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillByClient.aspx.cs" Inherits="UI.BillByClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Filtrar Cliente</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/Filter.css" />

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
            <div class="row align-items-start">
                <div class="col-4">
                    <div class="containerBlack">
                        <asp:Label ID="lblClient" runat="server" Text="Cliente" CssClass="tittle"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbxInsertClientName" runat="server" CssClass="findtxt"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" CssClass="btnR"/>

                        <asp:RequiredFieldValidator ID="RFClientName" runat="server" ControlToValidate="tbxInsertClientName" ErrorMessage="Debe introducir un nombre"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-8">
                    <div class="containerCal">
                        <asp:Label ID="lblClientList" runat="server" Text="Lista De Clientes" CssClass="tittle"></asp:Label>
                        <div id="contentClientsName" class="container-fluid" runat="server">
                        </div>
                    </div>
                </div>
            </div>
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
