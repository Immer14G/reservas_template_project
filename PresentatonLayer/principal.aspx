<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="PresentatonLayer.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administración de Habitaciones</title>
    <style>
        body {
            background-color: #0d1b2a;
            color: white;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            flex-direction: column;
            text-align: center;
        }
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .btn-primary {
            background-color: #007bff;
            border: none;
            padding: 10px 20px;
            font-size: 18px;
            cursor: pointer;
            margin-top: 20px;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <h1>Bienvenidos a Administración de Habitaciones</h1>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Administración ir" CssClass="btn-primary" Width="300px" />
    </form>
</body>
</html>
