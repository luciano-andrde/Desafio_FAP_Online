<%@ Page Title="Calculadora Skynetz" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FAP_ONLINE._Default" %>

<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />

    <style>
        .bg-style {
            background-color: #003366;
        }

        .text-style {
            color: #003366;
        }

        .btn-style {
            background-color: #00509e;
            color: white;
            border: none;
            transition: 0.3s;
        }

            .btn-style:hover {
                background-color: #003366;
                color: white;
                box-shadow: 0 4px 8px rgba(0,0,0,0.2);
            }

        .card-header-style {
            background-color: #f8f9fa;
            border-bottom: 2px solid #003366;
        }

        body {
            background-color: #eaeff5;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <!-- Navbar -->
        <nav class="navbar navbar-dark bg-style shadow-sm mb-5">
            <div class="container">
                <span class="navbar-brand mb-0 h1 fs-3">
                    <i class="bi bi-globe-americas me-2"></i>Skynetz Telecom
                </span>
                <span class="text-light small d-none d-md-block"><i class="bi bi-shield-lock-fill text-success"></i>Placeholder </span>
            </div>
        </nav>

        <!-- Container principal -->
        <div class="container pb-5">
            <div class="row justify-content-center">
                <div class="col-lg-10">

                    <div class="card shadow-lg border-0 rounded-3">

                        <!-- Cabeçalho do card -->
                        <div class="card-header card-header-corporate p-4">
                            <h4 class="mb-0 text-corporate fw-bold">
                                <i class="bi bi-calculator me-2"></i>Simulador de Tarifas FaleMais
                            </h4>
                            <p class="text-muted mb-0 mt-1 small">Calcule os custos da sua chamada interurbana com os nossos planos exclusivos.</p>
                        </div>

                        <!-- Corpo do body -->
                        <div class="card-body p-5">

                            <!-- Linha onde ficam alinhados os 4 inputs (DDD origem, DDD destino, tempo e plano) -->
                            <div class="row g-4 mb-4">

                                <!-- DropDownList do DDD de origem populados pelo page load -->
                                <div class="col-md-3">
                                    <label class="form-label text-secondary fw-semibold"><i class="bi bi-geo-alt-fill me-1"></i>Origem (DDD)</label>
                                    <asp:DropDownList ID="ddlOrigem" runat="server" CssClass="form-select border-secondary-subtle" ClientIDMode="Static"></asp:DropDownList>
                                </div>

                                <!-- DropDownList do DDD de destino populados pelo page load -->
                                <div class="col-md-3">
                                    <label class="form-label text-secondary fw-semibold"><i class="bi bi-pin-map-fill me-1"></i>Destino (DDD)</label>
                                    <asp:DropDownList ID="ddlDestino" runat="server" CssClass="form-select border-secondary-subtle" ClientIDMode="Static"></asp:DropDownList>
                                </div>

                                <!-- Input do tempo em minutos -->
                                <div class="col-md-3">
                                    <label class="form-label text-secondary fw-semibold"><i class="bi bi-clock-history me-1"></i>Tempo (Minutos)</label>
                                    <div class="input-group">
                                        <input type="number" id="txtTempo" class="form-control border-secondary-subtle" min="1" value="10" />
                                        <span class="input-group-text bg-light text-muted">min</span>
                                    </div>
                                </div>

                                <!-- DropDownList dos planos disponíveis populados pelo page load -->
                                <div class="col-md-3">
                                    <label class="form-label text-secondary fw-semibold"><i class="bi bi-telephone-outbound-fill me-1"></i>Plano FaleMais</label>
                                    <asp:DropDownList ID="ddlPlano" runat="server" CssClass="form-select border-secondary-subtle" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                            </div>

                            <!-- Linha com o botão que faz a simulação dos valores -->
                            <div class="row mb-5 mt-2">
                                <div class="col-12 text-center">
                                    <hr class="text-muted mb-4">
                                    <button type="button" id="btnCalcular" class="btn btn-corporate btn-lg px-5 py-3 fw-bold rounded-pill btn-style">
                                        <i class="bi bi-check-circle me-2"></i>Simular Valores
                                    </button>
                                </div>
                            </div>

                            <!-- Região onde irão aparecer os resultados do calculo de valor -->
                            <div id="areaResultados" style="display: none;">
                                <div class="row justify-content-center">
                                    <div class="col-12">
                                        <h5 class="text-center text-corporate fw-bold mb-4">Resumo Financeiro</h5>
                                    </div>

                                    <!-- Card onde aparece o valor com o plano -->
                                    <div class="col-md-5">
                                        <div class="card bg-success bg-opacity-10 border-success border-opacity-50 h-100">
                                            <div class="card-body text-center p-4">
                                                <h6 class="text-success text-uppercase fw-bold"><i class="bi bi-star-fill me-1"></i>Com FaleMais</h6>
                                                <h2 id="lblComPlano" class="display-5 fw-bold text-success mt-3 mb-0">R$ 0,00</h2>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Card onde aparece o valor sem o plano -->
                                    <div class="col-md-5 mt-3 mt-md-0">
                                        <div class="card bg-light border-secondary border-opacity-25 h-100">
                                            <div class="card-body text-center p-4">
                                                <h6 class="text-muted text-uppercase fw-bold">Tarifa Padrão (Sem Plano)</h6>
                                                <h3 id="lblSemPlano" class="text-secondary mt-3 mb-0">R$ 0,00</h3>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
