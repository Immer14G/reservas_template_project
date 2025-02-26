<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientesForm.aspx.cs" Inherits="PresentatonLayer.ClientesForm" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f1f3f5;
            color: #4b4f54;
            font-family: 'Roboto', sans-serif;
        }
        .navbar {
            border-radius: 0 0 15px 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }
        .navbar-brand {
            font-weight: 600;
            font-size: 1.5rem;
        }
        .card {
            border-radius: 12px;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
            margin-bottom: 30px;
        }
        .card-header {
            background-color: #007bff;
            color: white;
            font-weight: 600;
            border-radius: 12px 12px 0 0;
            text-align: center;
        }
        .card-body {
            background-color: #ffffff;
            padding: 30px;
        }
        .form-label {
            font-weight: 500;
        }
        .form-control, .form-select {
            border-radius: 8px;
            padding: 12px 15px;
            margin-bottom: 20px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }
        .btn {
            border-radius: 8px;
            padding: 12px 30px;
            font-weight: 600;
        }
        .btn-primary {
            background-color: #007bff;
            border: none;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
        .btn-secondary {
            background-color: #6c757d;
            border: none;
        }
        .btn-secondary:hover {
            background-color: #495057;
        }
        .container {
            margin-top: 50px;
        }
        .text-center {
            margin-top: 20px;
        }
        .grid-container {
            display: grid;
            gap: 20px;
            grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
        }
        .card-header h2 {
            font-size: 1.5rem;
            margin: 0;
        }
        .card-body .form-control {
            transition: all 0.3s ease;
        }
        .form-control:focus {
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
            border-color: #007bff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Gestión de Clientes</a>
            </div>
        </nav>

        <div class="container mt-4">
            <!-- Sección para la lista de clientes (arriba) -->
            <div class="row">
                <div class="col-12">
                    <div class="card shadow-sm mb-4">
                        <div class="card-header">
                            <h2>Lista de Clientes</h2>
                        </div>
                        <div class="card-body">
                            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="id_cliente" 
                                CssClass="table table-striped table-hover" 
                                OnRowUpdating="gvClientes_RowUpdating" 
                                OnRowDeleting="gvClientes_RowDeleting" 
                                OnRowCancelingEdit="gvClientes_RowCancelingEdit"
                                OnRowEditing="gvClientes_RowEditing">
                                <Columns>
                                    <asp:BoundField DataField="id_cliente" HeaderText="ID" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="dui" HeaderText="DUI" />
                                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                                    <asp:BoundField DataField="correo" HeaderText="Correo" />
                                    <asp:BoundField DataField="departamento" HeaderText="Departamento" />
                                    <asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" />
                                    <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario" />
                                    <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
                                    <asp:CommandField ShowEditButton="True" EditText="Editar" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Sección para agregar un nuevo cliente (abajo) -->
            <div class="row">
                <div class="col-12">
                    <div class="card shadow-sm">
                        <div class="card-header bg-success text-white text-center">
                            <h2>Agregar Nuevo Cliente</h2>
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <label class="form-label">Nombre:</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">DUI:</label>
                                <asp:TextBox ID="txtDui" runat="server" CssClass="form-control" placeholder="Ingrese el DUI"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Teléfono:</label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese el teléfono"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Correo:</label>
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingrese el correo"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Departamento:</label>
                                <asp:TextBox ID="txtDepartamento" runat="server" CssClass="form-control" placeholder="Ingrese el departamento"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Fecha de Registro:</label>
                                <asp:TextBox ID="txtf" runat="server" CssClass="form-control" placeholder="Ingrese la fecha"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Usuario:</label>
                                <asp:DropDownList ID="DdlUsuario" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="Seleccione un usuario" Value="" />
                                </asp:DropDownList>
                            </div>

                            <div class="text-center">
                                <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_click" CssClass="btn btn-primary w-100" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Botón de salida -->
            <div class="text-center mt-4">
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_click" CssClass="btn btn-secondary w-100" />
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
