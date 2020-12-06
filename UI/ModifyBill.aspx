<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyBill.aspx.cs" Inherits="UI.ModifyBill" %>

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
                <h1 class="titleAdmin">Modificar Factura:</h1>
                <div class="formlabels">
                    <asp:Label ID="labelPaymentMethod" runat="server" Text="Metodo de pago" CssClass="tittle"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlPaymentsMethods" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Efectivo</asp:ListItem>
                        <asp:ListItem Value="1">Cheque</asp:ListItem>
                        <asp:ListItem Value="2">Transferencia</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="labelIdPaymentMethod" runat="server" Text="Identificador de metodo de pago" CssClass="tittle"></asp:Label>
                    <br />
                    <asp:TextBox type="text" ID="txtIdPaymentMethod" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdPaymentMethod" ErrorMessage="Debe ingresar un identificador de metodo de pago"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="labelPaymentDate" runat="server" Text="Fecha de pago" CssClass="tittle"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPaymentDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaymentDate" ErrorMessage="Debe ingresar una fecha de pago"></asp:RequiredFieldValidator>
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
