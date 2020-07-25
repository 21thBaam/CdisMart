<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="subasta_s.aspx.cs" Inherits="CdisMart.Subasta.subasta_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/css/Subasta/subasta_s.css" rel="stylesheet">

    <div class="contai">
        <div class="tabla">
            <div class="form-group">
                <input id="busqueda" type="text" class="form-control" placeholder="Busqueda..."/>
            </div>
            <asp:GridView ID="grd_subastas" AutoGenerateColumns="false" runat="server" CssClass="table table-hover">
            <Columns>
                <asp:BoundField HeaderText="# de la subasta" DataField="AuctionId" />
                <asp:HyperLinkField DataNavigateUrlFields="AuctionId" HeaderText="Nombre del producto" DataNavigateUrlFormatString="subasta_detallada.aspx?AuctionId={0}" DataTextField="ProductName" />
                <asp:BoundField HeaderText="Descripción del producto" DataField="Description" />
                <asp:BoundField HeaderText="Fecha de inicio de la subasta" DataField="StartDate" />
                <asp:BoundField HeaderText="Fecha de fin de la subasta" DataField="EndDate" />
                <asp:HyperLinkField DataNavigateUrlFields="AuctionId" HeaderText="Historial" DataNavigateUrlFormatString="subasta_historial.aspx?AuctionId={0}" Text="Historial" />
            </Columns>
        </asp:GridView>
        </div>
    </div>

    <script>
        $(document).ready(function () {

            var index = <%=grd_subastas.Rows.Count %>;

            for (var i = 1; i <= index; i++) {
                document.getElementById('<%=grd_subastas.ClientID%>').rows[i].id = "foo";
                }

            $("#MainContent_grd_subastas tbody").addClass('myTable');

            $("#busqueda").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $(".myTable #foo").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>

</asp:Content>
