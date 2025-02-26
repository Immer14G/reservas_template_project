<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservaForm.aspx.cs" Inherits="PresentatonLayer.ReservaForm" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reservación</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
            color: #333;
        }
        .container {
            margin-top: 30px;
        }
        .form-control, .form-select {
            border-radius: 8px;
        }
        .btn {
            border-radius: 5px;
        }
        .table {
            margin-top: 30px;
        }
        .label-custom {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Selección de Cliente -->
            <div class="mb-3">
                <label for="ddlClientes" class="label-custom">Seleccione Cliente:</label>
                <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-select">
                    <asp:ListItem Value="1">Admin</asp:ListItem>                   
                </asp:DropDownList>
            </div>

            <!-- Selección de Habitaciones -->
            <div class="mb-3">
                <label for="ddlHabitaciones" class="label-custom">Seleccione Tipo de Habitación:</label>
                <asp:DropDownList ID="ddlHabitaciones" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CalcularTotal" CssClass="form-select">
                    <asp:ListItem Value="80">2 Huéspedes - $80 por noche</asp:ListItem>
                    <asp:ListItem Value="125">4 Huéspedes - $125 por noche</asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Descuento -->
            <div class="mb-3">
                <label class="label-custom">Seleccione Descuento:</label>
                <asp:RadioButtonList ID="rblDescuento" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CalcularTotal" CssClass="form-check-inline">
                    <asp:ListItem Value="0" Selected="True">Sin Descuento</asp:ListItem>
                    <asp:ListItem Value="10">10% Descuento</asp:ListItem>
                    <asp:ListItem Value="20">20% Descuento</asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <!-- Fechas -->
            <div class="mb-3">
                <label for="txtFechaInicio" class="label-custom">Fecha de Inicio:</label>
                <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtFechaFin" class="label-custom">Fecha de Fin:</label>
                <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Calcular Total -->
            <div class="text-center mb-3">
                <asp:Button ID="btnCalcular" runat="server" Text="Calcular Total" OnClick="CalcularTotal" CssClass="btn btn-primary w-100" />
            </div>

            <!-- Guardar Reserva -->
            <div class="text-center mb-3">
                <asp:Button ID="btnGuardarReserva" runat="server" Text="Guardar Reserva" OnClick="guardar" CssClass="btn btn-success w-100" />
            </div>

            <!-- Total -->
            <div class="text-center">
                <asp:Label ID="lblTotal" runat="server" Text="Total: " Font-Bold="True" CssClass="fw-bold"></asp:Label>
            </div>

            <!-- Tabla de Reservas -->
            <div class="table-responsive">
                <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="false" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" CssClass="table table-striped table-hover mt-4">
                    <Columns>
                        <asp:BoundField DataField="id_reserva" HeaderText="ID Reserva" SortExpression="id_reserva" />
                        <asp:BoundField DataField="id_cliente" HeaderText="Cliente" SortExpression="id_cliente" />
                        <asp:BoundField DataField="id_habitacion" HeaderText="Habitación" SortExpression="id_habitacion" />
                        <asp:BoundField DataField="checkin" HeaderText="Check-in" SortExpression="checkin" />
                        <asp:BoundField DataField="checkout" HeaderText="Check-out" SortExpression="checkout" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
                        <asp:BoundField DataField="descuento" HeaderText="Descuento" SortExpression="descuento" />
                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha Registro" SortExpression="fecha_registro" />
                        <asp:BoundField DataField="id_usuario" HeaderText="Usuario" SortExpression="id_usuario" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
