<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="PresentatonLayer.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login Gamer</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: radial-gradient(circle at top right, #0f0c29, #302b63, #24243e);
            color: #c5c6c7;
            font-family: 'Courier New', monospace;
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 15px;
        }

        .card-custom {
            background: rgba(35, 39, 42, 0.85);
            border: 1px solid #45a29e;
            box-shadow: 0 0 20px #66fcf1;
            backdrop-filter: blur(10px);
            border-radius: 10px;
            padding: 2rem;
            width: 100%;
            max-width: 400px;
        }

        .neon-text {
            color: #66fcf1;
            text-shadow: 
                0 0 5px #66fcf1,
                0 0 10px #66fcf1,
                0 0 20px #66fcf1,
                0 0 40px #66fcf1;
        }

        .form-control {
            background: transparent;
            border: 1px solid #45a29e;
            color: #c5c6c7;
        }

        .form-control:focus {
            box-shadow: 0 0 10px #66fcf1;
            border-color: #66fcf1;
        }

        .btn-neon {
            background: linear-gradient(45deg, #66fcf1, #45a29e);
            color: #0b0c10;
            border: none;
            transition: box-shadow 0.3s ease, transform 0.3s ease;
            font-weight: bold;
        }

        .btn-neon:hover {
            box-shadow: 
                0 0 10px #66fcf1, 
                0 0 20px #66fcf1, 
                0 0 30px #66fcf1;
            transform: scale(1.05);
        }

        .footer-text {
            font-size: 0.8rem;
            color: #828282;
        }

        @media (max-width: 576px) {
            .card-custom {
                padding: 1.5rem;
                width: 100%;
            }

            .neon-text {
                font-size: 1.5rem;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card-custom mx-auto">
            <h3 class="text-center neon-text mb-4">Login Gamer</h3>
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Usuario</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="TextBox2" class="form-label">Contraseña</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>
            <div class="mb-3 text-center">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-neon w-100" OnClick="Button1_Click" Text="Ingresar" />
            </div>
            <div class="text-center">
                <asp:Label ID="Label1" runat="server" CssClass="text-danger"></asp:Label>
            </div>
            <div class="text-center mt-3">
                <span class="footer-text">© 2025 Gamer's Hub</span>
            </div>
        </div>
    </form>
</body>
</html>
