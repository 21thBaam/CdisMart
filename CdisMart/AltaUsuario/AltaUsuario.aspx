<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="CdisMart.AltaUsuario.AltaUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alta Usuario</title>
    <link href="../Content/css/AltaUsuario/altaUsuario.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Content/bootstrap4.5/bootstrap.css"/>
    <script src="../Content/bootstrap4.5/jquery-3.5.1.js"></script>
    <script src="../Content/js/sweetalert2.js"></script>
</head>
<body>

    <nav class="navbar navbar-dark bg-dark">
    </nav>

    <div class="container">
		<form id="form1" runat="server">
			<div class="card">
			<div class="card-header">
				<h3>Alta de Usuario</h3>
			</div>
			<div class="card-body">
                <div class="form-group">
					<label>Nombre Completo</label>
                    <asp:TextBox ID="txtNombreCompleto" class="form-control" placeholder="Ingrese Nombre Completo" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_NombreCompleto" runat="server" ControlToValidate="txtNombreCompleto" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="El nombre es requerido" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev_NombreCompleto" runat="server" ValidationExpression="^[a-zA-Z0-9 ]*$" ControlToValidate="txtNombreCompleto" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="Nombre Invalido debe ser Alfanumérica" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
				</div>
                <div class="form-group">
					<label>Correo Electronico</label>
                    <asp:TextBox ID="txtCorreoElectronico" class="form-control" placeholder="Ingrese Correo Electronico" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_CorreoElectronico" runat="server" ControlToValidate="txtCorreoElectronico" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="El correo electronico es requerido" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev_CorreoElectronico" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtCorreoElectronico" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="Invalido Formato de Correo Electronico" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
				</div>
				<div class="form-group">
					<label>Usuario</label>
                    <asp:TextBox ID="txtUsuario" class="form-control" placeholder="Nombre de usuario" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Usuario" runat="server" ControlToValidate="txtUsuario" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="El Nombre de usuario es requerido" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev_Usuario" runat="server" ValidationExpression="^[a-zA-Z0-9]*$" ControlToValidate="txtUsuario" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="Nombre de Usuario Invalido debe ser Alfanumérica" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="cv_Usuario" runat="server" ControlToValidate="txtUsuario" ClientValidationFunction="ajaxCall" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="El nombre de usuario no esta disponible" ForeColor="Red"></asp:CustomValidator>
                    
				</div>
				<div class="form-group">
					<label>Contraseña</label>
                    <asp:TextBox ID="txtContraseña" class="form-control" placeholder="Contraseña" TextMode="Password" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Contraseña" runat="server" ControlToValidate="txtContraseña" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La contraseña es requerida" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev_Contraseña" runat="server" ValidationExpression="^[a-zA-Z0-9]*$" ControlToValidate="txtContraseña" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="Contraseña Invalida debe ser Alfanumérica" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
				</div>
                <div class="form-group">
					<label>Confirmación Contraseña</label>
                    <asp:TextBox ID="txtConfirmacionContraseña" class="form-control" placeholder="Confirmación Contraseña" TextMode="Password" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_ConfirmacionContraseña" runat="server" ControlToValidate="txtConfirmacionContraseña" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La confirmación de la contraseña es requerida" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev_ConfirmacionContraseña" runat="server" ValidationExpression="^[a-zA-Z0-9]*$" ControlToValidate="txtConfirmacionContraseña" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="Confirmación Contraseña Invalida debe ser Alfanumérica" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
				</div>
                <asp:CompareValidator ID="cv_Contraseña" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtConfirmacionContraseña" ValidationGroup="vlg1" ErrorMessage="Las contraseñas no coinciden" Display="Dynamic" Font-Names="Verdana" ForeColor="Red"></asp:CompareValidator>
			</div>
			<div class="card-footer"></div>
                <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="vlg1"/>
			</div>
            <script type="text/javascript" src="../Content/js/hechoAltaUsuario.js"></script>
		</form>
	</div>
    <script type="text/javascript">
        function ajaxCall(sender, args) {
            var valid;
            var name = args.Value;
            $.ajax({
                dataType: "json",
                type: "post",
                url: '<%=ResolveUrl("~/Services/UsuarioServices.svc/consultaNombreUsuario")%>',
                data: JSON.stringify({ name: name }),
                contentType: 'application/json;charset=utf-8',
                async: false,
                success: function (data) {
                    if (data.d != "null") {
                        valid = false;
                        console.log("False");
                    } else {
                        valid = true;
                        console.log("True");
                    }
                },
                error: function (e) {
                    alert(e);
                    valid = false;
                }
            });
            args.IsValid = valid;
        }
    </script>
</body>
</html>
