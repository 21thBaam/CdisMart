<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="subasta_alta.aspx.cs" Inherits="CdisMart.Subasta.subasta_alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/css/Subasta/subastaAlta.css" rel="stylesheet">
    <script src="../Content/js/sweetalert2.js"></script>
    <div class="contai">
        <div class="card">
            <div class="card-header text-center">
                <h2 class="title">Creación de Subasta</h2>
            </div>
            <hr class="separador">
            <div class="row">
                <div class="col-lg-4 col-lg-offset-4">
                    <div class="form-group">
                        <label>Nombre de producto</label>
                        <asp:TextBox ID="txtNombreProducto" class="form-control" placeholder="Ingrese Nombre de producto" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_NombreProducto" ControlToValidate="txtNombreProducto" runat="server" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="El nombre del prodcuto es requerido" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_NombreProducto" runat="server" ValidationExpression="^[a-zA-Z0-9 ]*$" ControlToValidate="txtNombreProducto" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="Nombre del producto es Invalido debe ser Alfanumérica" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label>Descripción del producto</label>
                        <asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Ingrese Descripción del producto" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Descripcion" ControlToValidate="txtDescripcion" runat="server" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La descripción del prodcuto es requerido" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_Descripcion" runat="server" ValidationExpression="^[a-zA-Z0-9 ]*$" ControlToValidate="txtDescripcion" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La descripción del producto es Invalido debe ser Alfanumérica" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label>Fecha de inicio</label>
                        <asp:TextBox ID="txtFechaInicio" class="form-control" placeholder="Ingrese Fecha de inicio" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_FechaInicio" runat="server" ControlToValidate="txtFechaInicio" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La Fecha de Inicio es requerida" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_FechaInicio" runat="server" ControlToValidate="txtFechaInicio" Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="El formato es incorrecto(dd/mm/yyy)" ForeColor="Red" SetFocusOnError="true"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvv_FechaInicio" ControlToValidate="txtFechaInicio" Type="Date" Operator="GreaterThanEqual" Display="Dynamic" ValidationGroup="vlg1" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Fecha Inicio tiene que ser igual o mayor a la fecha actual" runat="server"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <label>Fecha de fin</label>
                        <asp:TextBox ID="txtFechaFin" class="form-control" placeholder="Ingrese Fecha de fin" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_FechaFin" runat="server" ControlToValidate="txtFechaFin" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="La Fecha de Fin es requerida" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_FechaFin" runat="server" ControlToValidate="txtFechaFin" Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg1" Display="Dynamic" ErrorMessage="El formato es incorrecto(dd/mm/yyy)" ForeColor="Red" SetFocusOnError="true"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvv_Fechafin" ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFin" Type="Date" Operator="GreaterThanEqual" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="vlg1" ErrorMessage="Fecha fin tiene que ser igual o mayor a la fecha inicio" runat="server"></asp:CompareValidator>
                    </div>
                    <div class="card-footer"></div>
                    <asp:Button ID="btnGuardar" class="btn btn-success btn-lg btn-block" runat="server" Text="Guardar" ValidationGroup="vlg1" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="../Content/js/hechoCreacionSubasta.js"></script>
    <script type="text/javascript" src="../Content/js/incorrectoFlex.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtFechaInicio").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy"
            });
            $("#MainContent_txtFechaFin").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy"
            });
            //$(".lista").chosen();
        });
    </script>

</asp:Content>