<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifySuccess.aspx.cs" Inherits="UI.ModifySuccess" %>

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

    <link rel="stylesheet" type="text/css" href="CSS/ConfirmD.css" />

</head>
<body>
    <form id="form1" runat="server" class="formConf">
        <div class="formLabels">
            <img src="Images/3.png" class="image"/>
            <div class="textBlock">
                <asp:Label ID="Label1" runat="server" Text="Modificación exitosa"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
