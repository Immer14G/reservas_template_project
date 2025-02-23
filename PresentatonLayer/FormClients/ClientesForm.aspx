﻿<<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientesForm.aspx.cs" Inherits="PresentatonLayer.ClientesForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"Gestión de Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <!-- Encabezado -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Gestión de Clientestión de Clientes</a>
            </div>
        </nav>

        <div class="container mt-4">
            <!-- Lista de clientes -->
            <div class="card shadow-sm mb-4">
                <div class="card-header bg-secondary text-white text-center">
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

            <!-- Formulario para agregar cliente -->
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
                        <label class="form-label">
                        <asp:TextBox ID="txtusuario" runat="server" CssClass="form-control" placeholder="Ingrese el usuario"></asp:TextBox>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_click" CssClass="btn btn-primary" />
                    </div>
                </div>
                   <div class="text-center">
                   <asp:Button ID="btnSalir" runat="server" Text="Volver" OnClick="btnVolver_click" CssClass="btn btn-primary" />
               </div>
            </div>
        </div>

        <!-- Pie de página -->
        <footer class="bg-dark text-white text-center py-3 mt-4">
            <p class="mb-0">© 2025 Gestión de Clientes. Todos los derechos reservados.chos reservados.</p>
        </footer>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
