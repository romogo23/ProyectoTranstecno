<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostponeInvoice.aspx.cs" Inherits="UI.PostponeInvoice" %>

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
               <h3>Aplazar Factura</h3>
                <asp:Label ID="labelIdInvoice" runat="server" Text="Identificador de factura" CssClass="tittle"></asp:Label>
                <br />
                <asp:Label ID="lblIdInvoice" runat="server" Text="" CssClass="tittle"></asp:Label>
                <br /><br />
                <asp:Label ID="labelPaymentDate" runat="server" Text="Fecha de pago" CssClass="tittle"></asp:Label>
                <br />
                <asp:TextBox ID="txtPaymentDate" runat="server" TextMode="Date" CssClass="findtxt"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</body>
</html>
