<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadTemplate.aspx.cs" Inherits="UI.LoadTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <link rel="stylesheet" type="text/css" href="CSS/LoadTemplate.css" />

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
                <div class="col-5">
                    <div class="containerBlack">
                        <h1 class="titleBills">Ingresar Facturas:</h1>
                        <div class="contFile">
                            <div class="contFile1">
                                <h5 class="titleLoad">Cargar Plantilla:</h5>
                            </div>
                            <div class="contFile2">
                                <asp:FileUpload ID="FP" runat="server" CssClass="btnFile"/>
                            </div>
                        </div>
                        <asp:Button ID="btnLoadInvoice" runat="server" Text="Validar plantilla" OnClick="btnLoadInvoice_Click" CssClass="btnFileVal"/> 
                                <asp:Button ID="btnUploadInvoice" runat="server" Text="Cargar plantilla" Visible="False" OnClick="btnUploadInvoice_Click" CssClass="btnFileLoad"/>
                        <asp:Label ID="lblInformationInvoice" runat="server" Text="" CssClass="lblError"></asp:Label>
                    </div>
                </div>
                <div class="col-7">
                    <div class="containerCal">
                        <asp:Calendar ID="Calendar1" runat="server" CssClass="cal" OnDayRender="Calendar1_DayRender"></asp:Calendar>
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
