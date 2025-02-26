<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="PresentatonLayer.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administración de Habitaciones</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
            color: #333;
        }
        .card {
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }
        .card-header {
            background-color: #007bff;
            color: white;
            border-radius: 10px 10px 0 0;
            font-weight: bold;
        }
        .card-body {
            background-color: #ffffff;
            padding: 20px;
        }
        .container {
            margin-top: 30px;
        }
    </style>
</head>
<body class="container">
    <form id="form1" runat="server">
        <div class="row">
            
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header text-center">
                        Agregar Nueva Habitación
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label class="form-label">Número:</label>
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" placeholder="Número de habitación"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Descripción:</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción de la habitación"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Huéspedes:</label>
                            <asp:TextBox ID="txtHuespedes" runat="server" CssClass="form-control" placeholder="Cantidad de huéspedes"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">ID Usuario:</label>
                            <asp:DropDownList ID="DdlUsuario" runat="server" CssClass="form-select">
                                <asp:ListItem>Seleccione un Usuario</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Habitación" OnClick="btnAgregar_click" CssClass="btn btn-primary w-100" />
                    </div>
                </div>
            </div>

         
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header text-center">
                        Lista de Habitaciones
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="gvHabitaciones" runat="server" AutoGenerateColumns="False" 
                            OnRowEditing="gvHabitaciones_RowEditing"
                            OnRowUpdating="gvHabitaciones_RowUpdating"
                            OnRowCancelingEdit="gvHabitaciones_RowCancelingEdit"
                            OnRowDeleting="gvHabitaciones_RowDeleting" class="table table-striped" DataKeyNames="id_habitaciones"  >
                            <Columns>
                                <asp:BoundField DataField="id_habitaciones" HeaderText="id_habitaciones" InsertVisible="False" ReadOnly="True" SortExpression="id_habitaciones" />
                                <asp:BoundField DataField="numero" HeaderText="numero" SortExpression="numero" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="huespedes" HeaderText="huespedes" SortExpression="huespedes" />
                                <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" SortExpression="id_usuario" />
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbreservas1ConnectionString %>" SelectCommand="SELECT [id_habitaciones], [numero], [descripcion], [huespedes], [id_usuario] FROM [habitaciones]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
