<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillByDate.aspx.cs" Inherits="UI.BillByDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Filtrar Fecha</title>

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

    <form id="form1" runat="server" class="formImage">
        <div class="container">
            <div class="dateForm">
                <asp:Label ID="lblStartDate" runat="server" Text="Fecha de Inicio" CssClass="tittle"></asp:Label>
                <br />
                <asp:TextBox ID="TxtStartDate" runat="server" TextMode="Date" CssClass="findtxt"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fecha Requerida" ControlToValidate="TxtStartDate"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblendDate" runat="server" Text="Fecha de Final" CssClass="tittle"></asp:Label>
                <br />
                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" CssClass="findtxt"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fecha Requerida" ControlToValidate="txtEndDate"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" CssClass="btnR" />

                <asp:Label ID="lblBillClient" runat="server" Text="" CssClass="tittle"></asp:Label>
                <br />
                <asp:GridView ID="gdInvoiceClient" runat="server" CssClass="table table-borderless"></asp:GridView>
                <br />
                <asp:Label ID="lblBillSupplier" runat="server" Text="" CssClass="tittle"></asp:Label>
                <br />
                <asp:GridView ID="gdInvoiceSupplier" runat="server" CssClass="table table-borderless"></asp:GridView>
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
