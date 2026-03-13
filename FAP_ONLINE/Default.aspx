<%@ Page Title="Calculadora Skynetz" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FAP_ONLINE._Default" %>

<!DOCTYPE>
<html lang = "pt-br">
    <head runat = "server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title></title>
    
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />

        <style>
            .bg-style {background-color: #003366;}
            .text-style {color: #003366;}
            .btn-style {background-color: #00509e; color: white; border: none; transition: 0.3s;}
            .btn_style:hover {background-color: #003366; color: white; box-shadow: 0 4px 8px rgba(0,0,0,0.2);}
            .card-header-style {background-color: #f8f9fa; border-bottom: 2px solid #003366;}

            body {background-color: #eaeff5;}
        </style>
    </head>

    <body>
        <form id = "form1" runat = "server">
            <nav class = "navbar navbar-dark bg-style shadow-sm mb-5">
                <div class = "container">
                    <span class = "navbar-brand mb-0 h1 fs-3">
                        <i class = "bi bi-globe-americas me-2"></i> Skynetz Telecom
                    </span>
                    <span class="text-light small d-none d-md-block"><i class="bi bi-shield-lock-fill text-success"></i> Placeholder </span>
                </div>
            </nav>

            <div>
                <asp:DropDownList ID = "IDOrigem" runat = "server" cssClass = "form-select"></asp:DropDownList>
                <asp:DropDownList ID = "IDDestino" runat = "server" CssClass = "form-select"></asp:DropDownList>
                <input type = "number" id = "IDTempo" class = "form-control" />
                <asp:DropDownList ID = "IDPlano" runat = "server" CssClass = "form-select"></asp:DropDownList>
            </div>

        </form>
    </body>
</html>