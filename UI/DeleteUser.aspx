<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="UI.DeleteUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <asp:Button ID="deletebtn" runat="server" Text="Eliminar" OnClick="deletebtn_Click" />
            <asp:Button ID="cancelbtn" runat="server" Text="Cancelar" OnClick="cancelbtn_Click" />
        </div>
    </form>
</body>
</html>
