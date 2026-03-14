using FAP_ONLINE.Data;
using System;
using System.Linq;
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
    }
}