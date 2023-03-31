<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRegistro.aspx.cs" Inherits="Lab08.frmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ----ACTIVIDAD----&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Descripcion<br />
            <asp:TextBox ID="txtDescripcion" runat="server" Height="86px" style="margin-bottom: 6px" Width="182px"></asp:TextBox>
            <br />
            Fecha Actividad<br />
            <asp:Calendar ID="dpFechaActividad" runat="server"></asp:Calendar>
            <br />
            <br />
            Estado<br />
            <asp:TextBox ID="txtEstadoActividad" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            <br />
            <asp:Button ID="btnRegistrarActividad" runat="server" OnClick="btnRegistrarActividad_Click" Text="Registrar" />
            <br />
            ----INSCRITO----<br />
            <br />
            Tipo Documento<br />
            <asp:TextBox ID="txtTipoDocumento" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            <br />
            Documento<br />
            <asp:TextBox ID="txtDocumento" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            <br />
            Nombres<br />
            <asp:TextBox ID="txtNombres" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            <br />
            Apellidos<br />
            <asp:TextBox ID="txtApellidos" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            <br />
            Fecha Nacimiento<br />
            <asp:Calendar ID="dpFechaNacimiento" runat="server"></asp:Calendar>
            <br />
            Sexo<br />
            <asp:TextBox ID="txtSexo" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            Estado<br />
            <asp:TextBox ID="txtEstadoInscrito" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            Tipo<br />
            <asp:TextBox ID="txtTipo" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            Id Actividad<br />
            <asp:TextBox ID="txtActividadInscrito" runat="server" style="margin-bottom: 6px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrar" />
        </div>
    </form>
</body>
</html>
