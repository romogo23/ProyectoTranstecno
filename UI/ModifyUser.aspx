<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyUser.aspx.cs" Inherits="UI.ModifyUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Correo"></asp:Label>
             <input type="email" id="email" runat="server"/>
            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
         <input type="password" id="password" runat="server"/>
           <label>Rol:</label>
            <asp:DropDownList ID="rols" runat="server">
                <asp:ListItem Value="1" Selected="True">Administrador Secundario</asp:ListItem>
                <asp:ListItem Value="2">Usuario Común</asp:ListItem>
              </asp:DropDownList>
            <asp:Button ID="btnmodify" runat="server" Text="Modificar" OnClick="btnmodify_Click" />
            <asp:Button ID="btndelete" runat="server" Text="Cancelar" OnClick="btndelete_Click" />
        </div>
    </form>
</body>
</html>
