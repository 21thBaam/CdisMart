<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="subasta_detallada.aspx.cs" Inherits="CdisMart.Subasta.subasta_detallada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/css/Subasta/subastaDetallada.css" rel="stylesheet">
    <script src="../Content/js/sweetalert2.js"></script>
    <div class="contai">
        <div class="card">
            <div class="card-header text-center">
                <h2 class="title">Subasta</h2>
            </div>
            <hr class="separador">
            <div class="card-body">
                <div class="row">
                    <label class="col-md-4"># de la subasta:</label>
                    <asp:Label ID="lNumeroSubasta" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <label class="col-md-4">Nombre Producto:</label>
                    <asp:Label ID="lNombreProducto" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <label class="col-md-4">Descripción:</label>
                    <asp:Label ID="lDescripcion" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <label class="col-md-4">Fecha de inicio de la subasta:</label>
                    <asp:Label ID="lFechaInicio" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <label class="col-md-4">Fecha de fin de la subasta:</label>
                    <asp:Label ID="lFechaFin" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <label class="col-md-4">Oferta actual más alta:</label>
                    <asp:Label ID="lHighestBid" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <label class="col-md-4">Usuario que realizo la oferta actual más alta:</label>
                    <asp:Label ID="lWinner" runat="server"></asp:Label>
                </div>
                <hr class="separador">
                <div class="form-group">
                    <label>Cantidad deseada a ofertar</label>
                    <asp:TextBox ID="txtBid" class="form-control" placeholder="Ingrese su puja" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Bid" ControlToValidate="txtBid" runat="server" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La puja es requerida" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rev_Bid" runat="server" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" ControlToValidate="txtBid" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="No cumple con el formato Numeros decimales y solo 2 decimales" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    <asp:RangeValidator ID="rv_Bid" runat="server" ControlToValidate="txtBid" Type="Double" MinimumValue="1" MaximumValue="999999" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La cantidad ingresada debe ser un numero decimal mayor a 0 y menor que 1,000,000." ForeColor="Red" SetFocusOnError="True"></asp:RangeValidator>
                </div>
                <asp:CustomValidator style="display: block;" ID="cv_FechaFin" runat="server" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La Subasta ha finalizado" ForeColor="Red"></asp:CustomValidator>
                <asp:CustomValidator  style="display: block;" ID="cv_UserID" runat="server" ValidationGroup="vlg1" Display="Dynamic" ForeColor="Red" ErrorMessage="No se le permite ofertar en esta subasta"></asp:CustomValidator>
            </div>
            <div class="card-footer"></div>
            <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" ValidationGroup="vlg1" Text="Enviar Puja" OnClick="btnGuardar_Click" />
        </div>
    </div>

    <script type="text/javascript" src="../Content/js/hecho.js"></script>
    <script type="text/javascript" src="../Content/js/incorrectoFlex.js"></script>
</asp:Content>
