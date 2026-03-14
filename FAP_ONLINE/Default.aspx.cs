using FAP_ONLINE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FAP_ONLINE
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDadosNaTela();
            }
        }

        private void CarregarDadosNaTela()
        {
            using (var contexto = new Context())
            {
                var listaDePlanos = contexto.Planos.ToList();

                ddlPlano.DataSource = listaDePlanos;
                ddlPlano.DataTextField = "PlanoNome";
                ddlPlano.DataValueField = "PlanoID";
                ddlPlano.DataBind();

                var origens = contexto.Tarifa.Select(t => t.Origem).Distinct().ToList();
                ddlOrigem.DataSource = origens;
                ddlOrigem.DataBind();

                var destinos = contexto.Tarifa.Select(t => t.Destino).Distinct().ToList();
                ddlDestino.DataSource = destinos;
                ddlDestino.DataBind();
            }
        }
    }
}