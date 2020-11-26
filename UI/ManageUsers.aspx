<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="UI.ManageUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False">
                    <Columns>
                       <asp:BoundField DataField="UserName"/>
                        <asp:BoundField DataField="UserName" HtmlEncode="False" DataFormatString="<a href='UpdateCategory.aspx?userName={0}'>Modificar</a>" />
                        <asp:BoundField DataField="UserName" HtmlEncode="False" DataFormatString="<a href='DeleteUser.aspx?userName={0}'>Eliminar</a>" />
                    </Columns>
                </asp:GridView>
        </div>
    </form>
</body>
</html>
