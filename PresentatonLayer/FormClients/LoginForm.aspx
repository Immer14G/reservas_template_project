<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="PresentatonLayer.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login Básico</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: #f5f5f5;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            padding: 15px;
        }

        .card-custom {
            padding: 2rem;
            width: 100%;
            max-width: 400px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card card-custom">
            <h3 class="text-center mb-4">Login</h3>
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Usuario</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="TextBox2" class="form-label">Contraseña</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>
            <div class="d-grid mb-3">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Ingresar" />
            </div>
            <div class="text-center">
                <asp:Label ID="Label1" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
