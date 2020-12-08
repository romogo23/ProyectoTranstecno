<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostponeBill.aspx.cs" Inherits="UI.PostponeBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Aplazar Factura</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/ModifyBills.css" />

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
            <div class="AdminFormBill">
                <h1 class="titleAdmin">Aplazar Factura:</h1>
                <div class="formlabels">
                    <br />
                    <asp:Label ID="labelPaymentDate" runat="server" Text="Nueva fecha de recordatorio:" CssClass="tittle"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPaymentDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" CssClass="btnR" />
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btnCancel_Click" CssClass="btnR" />
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
