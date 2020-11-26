<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="UI.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <h3>Registrar usuario:</h3>
              <label>Nombre de usuario:</label>
            <input type="text" class="form-control" id="userNameRegister" runat="server"/>
            <label>Correo:</label>
            <input type="email" class="form-control" id="email" runat="server"/>
            <label>Contraseña:</label>
            <input type="password" class="form-control" id="password" runat="server"/>
           <label>Rol:</label>
            <asp:DropDownList ID="rols" runat="server">
                <asp:ListItem Value="1" Selected="True">Administrador Secundario</asp:ListItem>
                <asp:ListItem Value="2">Usuario Común</asp:ListItem>
              </asp:DropDownList>
            <asp:Button ID="btnRegister" runat="server" Text="Registrar" OnClick="btnRegister_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
            </div>
    </form>
</body>
</html>
