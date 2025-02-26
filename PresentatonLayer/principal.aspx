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
            margin: 0;
            font-family: 'Arial', sans-serif;
        }
        h1 {
            font-size: 36px;
            margin-bottom: 30px;
            font-weight: bold;
        }
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.3);
            width: 710px;
            height: 324px;
        }
        .button-container {
            display: flex;
            justify-content: space-around;
            width: 100%;
            margin-top: 20px;
        }
        .btn-primary {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #007bff;
            padding: 12px 24px;
            font-size: 18px;
            font-weight: bold;
            color: white;
            cursor: pointer;
            margin: 10px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
            }
        .btn-primary:hover {
            background-color: #0056b3;
        }
        .btn-primary:focus {
            outline: none;
        }
        .btn-primary:active {
            background-color: #004494;
        }
        p {
            color: #cccccc;
            margin-top: 20px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <h1>Bienvenidos </h1>
        <div class="button-container">
            <asp:Button ID="BtnHabitaciones" runat="server" OnClick="Button1_Click" Text="habitaciones" CssClass="btn-primary" Width="167px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnClientes" runat="server" OnClick="Button1_Click1" Text="Clientes" CssClass="btn-primary" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnReserva" runat="server" OnClick="Button2_Click2" Text="Reserva" CssClass="btn-primary" />
        </div>
        <p>Seleciona&nbsp; </p>
    </form>
</body>
</html>
