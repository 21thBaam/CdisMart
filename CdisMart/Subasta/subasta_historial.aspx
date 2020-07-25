<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="subasta_historial.aspx.cs" Inherits="CdisMart.Subasta.subasta_historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/css/Subasta/subastaHistorial.css" rel="stylesheet">
    <div class="contai">
        <div class="card">
            <div class="card-header text-center">
                <h2 class="title">Subasta Historial</h2>
            </div>
            <div class="card-body">
                <div class="row">
                    <label class="col-md-3">Nombre del producto:</label>
                    <asp:Label runat="server" ID="lProductName"></asp:Label>
                </div>
                <div class="row">
                    <label class="col-md-3">Descripción del producto:</label>
                    <asp:Label runat="server" ID="lDescription"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:DropDownList ID="ddl_Usuarios" CssClass="lista" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:GridView ID="grd_historial" AutoGenerateColumns="false" runat="server" CssClass="table">
                        <Columns>
                            <asp:BoundField HeaderText="Usuario que realizo la oferta" DataField="UserId" />
                            <asp:BoundField HeaderText="Monto de la oferta" DataField="Amount" />
                            <asp:BoundField HeaderText="Fecha de realizacion de la oferta" DataField="BidDate" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="form-group">
                    <label>Total de todas las pujas realizadas</label>
                    <label id="total" class="badge badge-secondary"></label>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {

            function total() {
                var total = 0;
                var index = <%=grd_historial.Rows.Count %>;

                for (var i = 1; i <= index; i++) {
                    if (document.getElementById('<%=grd_historial.ClientID%>').rows[i].style.display == "none") {

                    } else {
                        total += parseFloat(document.getElementById('<%=grd_historial.ClientID%>').rows[i].cells[1].innerText);
                        document.getElementById('<%=grd_historial.ClientID%>').rows[i].id = "foo";
                    }
                }
                document.getElementById("total").innerHTML = total;
            }

            total();

            $(".lista").chosen();

            $("#MainContent_grd_historial tbody").addClass('myTable');

            $("#MainContent_ddl_Usuarios").change(function () {
                var value = $(this).val().toLowerCase();
                $(".myTable #foo").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
                total();
            });
        });
    </script>

</asp:Content>
