<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageInvoices.aspx.cs" Inherits="UI.ManageInvoices" %>

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
                <h3>Gestionar facturas</h3>
            </div>
            <asp:GridView ID="grdInvoices" runat="server" AutoGenerateColumns="False">
                    <Columns>
                       <asp:BoundField DataField="idInvoice"/>
                        <asp:BoundField DataField="idInvoice"/>
                        <asp:BoundField DataField="idInvoice"/>
                        <asp:BoundField DataField="idInvoice"/>
                        <asp:BoundField DataField="idInvoice"/>
                        <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a href='ModifyInvoice.aspx?'>Modificar</a>" />
                        <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a href='CloseInvoice.aspx?'>Cerrar</a>" />
                        <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a href='PostponeInvoice.aspx?el atributoquevoyapasar={0}'>Aplazar</a>" />
                    </Columns>
                </asp:GridView>
        </div>
    </form>
</body>
</html>
