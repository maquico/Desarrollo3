<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="Teo8.frmMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
        </div>
        Nombres:
        <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
        <p>
            Apellidos:
            <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:FileUpload ID="fuImagen" runat="server" />
        </p>
        <p>
            <asp:Image ID="imgImagen" runat="server" Height="158px" Width="250px" />
        </p>
        <p>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
        </p>
    </form>
</body>
</html>
