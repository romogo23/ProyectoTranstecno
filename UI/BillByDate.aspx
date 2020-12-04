<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillByDate.aspx.cs" Inherits="UI.BillByDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/FilterDate.css" />

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
        <<div class="container fluid">
            <div class="dateForm">
                <asp:Label ID="lblStartDate" runat="server" Text="Fecha de Inicio" CssClass="tittle"></asp:Label>
                <br />
                <asp:TextBox ID="TxtStartDate" runat="server" TextMode="Date" CssClass="findtxt"></asp:TextBox>
                <br />
                <asp:Label ID="lblendDate" runat="server" Text="Fecha de Final" CssClass="tittle"></asp:Label>
                <br />
                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" CssClass="findtxt"></asp:TextBox>
                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" CssClass="btnR" />

                <div id="contentInvoiceByDate" class="row text-center" runat="server">
                </div>

                <div id="contentInvoiceSupplier" class="row text-center" runat="server">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
