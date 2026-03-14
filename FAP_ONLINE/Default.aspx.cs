using FAP_ONLINE.Data;
using FAP_ONLINE.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FAP_ONLINE
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Carrega os dados apenas uma vez, evitando recarregamentos desnecessários
            if (!IsPostBack)
            {
                CarregarDadosNaTela();
            }
        }


        //Popula os DropDownLists com os dados que estão no banco de dados
        private void CarregarDadosNaTela()
        {
            //Garante que a conexão com o banco de dados será fechada após o uso
            using (var contexto = new Context())
            {
                //Ordena os planos por minutos gratuitos disponíveis (crescente)
                var listaDePlanos = contexto.Planos.OrderBy(p => p.MinutosGratuitos).ToList();

                ddlPlano.DataSource = listaDePlanos;
                ddlPlano.DataTextField = "PlanoNome";
                ddlPlano.DataValueField = "PlanoID";
                ddlPlano.DataBind();

                //Distinct evita duplicatas e OrderBy ordena na ordem alfabética
                var origens = contexto.Tarifas.Select(t => t.Origem).Distinct().OrderBy(o => o).ToList();
                ddlOrigem.DataSource = origens;
                ddlOrigem.DataBind();

                //Distinct evita duplicatas e OrderBy ordena na ordem alfabética
                var destinos = contexto.Tarifas.Select(t => t.Destino).Distinct().OrderBy(d => d).ToList();
                ddlDestino.DataSource = destinos;
                ddlDestino.DataBind();
            }
        }

        //Método chamado pelo Ajax para calcular os valores da ligação
        [WebMethod]
        public static object Calcular(string origem, string destino, int tempo, int planoID)
        {
            try
            {
                //Garante que a conexão com o banco de dados será fechada após o uso
                using (var contexto = new Context())
                {
                    //Busca a tarifa pela combinação de origem e destino 
                    var tarifa = contexto.Tarifas.FirstOrDefault(t => t.Origem == origem && t.Destino == destino);

                    //Rota de tarifa não cadastrada 
                    if (tarifa == null)
                    {
                        return new { sucesso = false, mensagem = "Esta rota de origem e destino não está disponível." };
                    }

                    //Busca pelo plano usando o ID
                    var plano = contexto.Planos.FirstOrDefault(p => p.PlanoID == planoID);

                    //Plano não cadastrado
                    if (plano == null)
                    {
                        return new { sucesso = false, mensagem = "Plano selecionado inválido." };
                    }

                    //Objeto derivado da classe que calcula os valores da ligação
                    var calculadora = new CalculadoraDeValorDaLigacao();

                    decimal valorSemPlano = calculadora.CalculoSemPlano(tempo, tarifa.ValorPorMinuto);
                    decimal valorComPlano = calculadora.CalculoComPlano(tempo, tarifa.ValorPorMinuto, plano.MinutosGratuitos);

                    //Cultura br para garantir que o valor ficará no formato monetário em R$
                    var culturaBR = new CultureInfo("pt-BR");

                    //Retorno com os valores da ligação, com e sem o plano
                    return new
                    {
                        sucesso = true,
                        valorSemPlano = valorSemPlano.ToString("C", culturaBR), //formata os valores como moeda (em reais)
                        valorComPlano = valorComPlano.ToString("C", culturaBR)  //formata os valores como moeda (em reais)
                    };
                }
            }
            catch (Exception ex)
            {
                return new { sucesso = false, mensagem = "Ocorreu um erro ao calcular: " + ex.Message };
            }
        }
    }
}