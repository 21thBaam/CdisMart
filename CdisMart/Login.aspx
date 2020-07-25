<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CdisMart.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="Content/css/Login/login.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/bootstrap4.5/bootstrap.css"/>
    <script src="Content/bootstrap4.5/jquery-3.5.1.js"></script>
    <script src="Content/js/sweetalert2.js"></script>
</head>
<body>

    <nav class="navbar navbar-dark bg-dark">
    </nav>

    <div class="container">
        <form id="formLogin" runat="server">
            <div id="imgLogin"></div>
            <div class="form-group">
		        <label>Usuario</label>
                <asp:TextBox ID="txtUsuario" class="form-control" placeholder="Nombre de usuario" runat="server"></asp:TextBox>
		    </div>
		    <div class="form-group">
		        <label>Contraseña</label>
                <asp:TextBox ID="txtContraseña" class="form-control" placeholder="Contrasena" TextMode="Password" runat="server"></asp:TextBox>
		    </div>
		    <div class="form-group text-center">
		  	    <asp:Button class="btn btn-primary" ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"/>
		    </div>
            <div class="form-group text-center">
                <a href="AltaUsuario/AltaUsuario.aspx" class="btn btn-outline-success btn-lg">Registrarse</a>
            </div>
            <script type="text/javascript" src="Content/js/incorrecto.js"></script>
        </form>
    </div>
</body>
</html>
