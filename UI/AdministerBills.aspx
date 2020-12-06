<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministerBills.aspx.cs" Inherits="UI.AdministerBills" %>

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
                <div class="formlabels">
                    <asp:GridView ID="grdInvoices" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="idInvoice" />
                            <asp:BoundField DataField="ClientName" />
                            <asp:BoundField DataField="TotalBill" />
                            <asp:BoundField DataField="PaymentDate" />
                            <asp:BoundField DataField="State" />
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='ModifyInvoice.aspx?idInvoice={0}'>Modificar</a>" />
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='CloseInvoice.aspx?idInvoice={0}'>Cerrar</a>" />
                            <asp:BoundField DataField="idInvoice" HtmlEncode="False" DataFormatString="<a class='btn btn-default' href='PostponeInvoice.aspx?idInvoice={0}'>Aplazar</a>" />
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
