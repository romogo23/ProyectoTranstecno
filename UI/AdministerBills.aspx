<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministerBills.aspx.cs" Inherits="UI.AdministerBills" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestionar Facturas</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/ManageBills.css" />

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
                <h1 class="titleAdmin">Gestionar Facturas:</h1>
                <br />
                <div class="formlabels">
                    <h3 class="titleAdmin">Facturas de Clientes:</h3>
                    <br />
                    <asp:GridView ID="grdInvoices" runat="server" AutoGenerateColumns="False" CssClass="table table-borderless" OnRowCreated="grdInvoices_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="idInvoice" HeaderText ="Id de Factura"/>
                            <asp:BoundField DataField="ClientName" HeaderText ="Nombre de Cliente"/>
                            <asp:BoundField DataField="TotalBill" HeaderText ="Monto"/>
                            <asp:BoundField DataField="PaymentDate" HeaderText ="Fecha de Recordatorio"/>
                            <asp:BoundField DataField="State" HeaderText ="Estado"/>
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='ModifyBill.aspx?idInvoice={0}'>Modificar</a>" />
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='CloseBill.aspx?idInvoice={0}'>Cerrar</a>" />
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='PostponeBill.aspx?idInvoice={0}'>Aplazar</a>" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <h3 class="titleAdmin">Facturas de Proveedores:</h3>
                    <br />
                    <asp:GridView ID="grdSuppliers" runat="server" AutoGenerateColumns="False" CssClass="table table-borderless" OnRowCreated="grdInvoices_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="idInvoice" HeaderText ="Id de Factura"/>
                            <asp:BoundField DataField="SupplierName" HeaderText ="Nombre de Porveedor"/>
                            <asp:BoundField DataField="TotalBillSupplier" HeaderText ="Monto"/>
                            <asp:BoundField DataField="PaymentDateSupplier" HeaderText ="Fecha de Recordatorio"/>
                            <asp:BoundField DataField="StateSupplier" HeaderText ="Estado"/>
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='ModifyBill.aspx?idInvoice={0}'>Modificar</a>" />
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='CloseBill.aspx?idInvoice={0}'>Cerrar</a>" />
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='PostponeBill.aspx?idInvoice={0}'>Aplazar</a>" />
                        </Columns>
                    </asp:GridView>
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
