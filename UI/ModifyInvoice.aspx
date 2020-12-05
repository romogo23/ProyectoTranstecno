<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyInvoice.aspx.cs" Inherits="UI.ModifyInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <div>
                <h3>Modificar Factura</h3>
                <asp:Label ID="labelPaymentMethod" runat="server" Text="Metodo de pago" CssClass="tittle"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlPaymentsMethods" runat="server">
                    <asp:ListItem Value="0">Efectivo</asp:ListItem>
                    <asp:ListItem Value="1">Cheque</asp:ListItem>
                    <asp:ListItem Value="2">Transferencia</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="labelIdPaymentMethod" runat="server" Text="Identificador de metodo de pago" CssClass="tittle"></asp:Label>
                <br />
                <asp:TextBox type="text" class="form-control" ID="txtIdPaymentMethod" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdPaymentMethod" ErrorMessage="Debe ingresar un identificador de metodo de pago"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="labelPaymentDate" runat="server" Text="Fecha de pago" CssClass="tittle"></asp:Label>
                <br />
                <asp:TextBox ID="txtPaymentDate" runat="server" TextMode="Date" CssClass="findtxt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaymentDate" ErrorMessage="Debe ingresar una fecha de pago"></asp:RequiredFieldValidator>
                <br /><br />

                <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</body>
</html>
