<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="PresentatonLayer.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administración de Habitaciones</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #0d1b2a;
            color: white;
        }
    </style>
</head>
<body class="container mt-4">
    <form id="form1" runat="server">
        <div class="card p-4">
            <h2 class="text-center">Lista de Habitaciones</h2>
            <asp:GridView ID="gvHabitaciones" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id_habitaciones" 
                OnRowEditing="gvHabitaciones_RowEditing"
                OnRowUpdating="gvHabitaciones_RowUpdating"
                OnRowCancelingEdit="gvHabitaciones_RowCancelingEdit"
                OnRowDeleting="gvHabitaciones_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="id_habitaciones" HeaderText="id_habitaciones" />
                    <asp:BoundField DataField="numero" HeaderText="numero" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" />
                    <asp:BoundField DataField="huespedes" HeaderText="huespedes"  />
                    <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            </div>

        <div class="card p-4 mt-4">
            <h2 class="text-center">Agregar Nueva Habitación</h2>
            <div class="mb-3">
                <label class="form-label">Número:</label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Huéspedes:</label>
                <asp:TextBox ID="txtHuespedes" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">ID Usuario:</label>
                <asp:DropDownList ID="DdlUsuario" runat="server" CssClass="form-select">
                    <asp:ListItem>Admin</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Habitación" OnClick="btnAgregar_click" CssClass="btn btn-primary" />
        </div>
    </form>
    
   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
