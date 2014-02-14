using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Painel
{
    public partial class DashBoard_FAV : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ObjUsers"] != null)
            {
                objUsers = (dtoUsers)Session["ObjUsers"];
            }
            else
            {
                Response.Redirect("../login.aspx");
            }

            if (!IsPostBack)
            {
                listCampaign();
                AccessSecurity();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile("boxVendas", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxVendas.Visible = false;
                cbVendas.Visible = false;
            }
            else
            {
                boxVendas.Visible = true;
                cbVendas.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxVendas_15minutos", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxVendas_15minutos.Visible = false;
                cbVendas_15minutos.Visible = false;
            }
            else
            {
                boxVendas_15minutos.Visible = true;
                cbVendas_15minutos.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxVendasOperador", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxVendasOperador.Visible = false;
                cbVendasOperador.Visible = false;
            }
            else
            {
                boxVendasOperador.Visible = true;
                cbVendasOperador.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxVendasOperador_15minutos", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxVendasOperador_15minutos.Visible = false;
                cbVendasOperador_15minutos.Visible = false;
            }
            else
            {
                boxVendasOperador_15minutos.Visible = true;
                cbVendasOperador_15minutos.Visible = true;
            }
        }

        public void dataHora()
        {
            lblDataHora.Text = "Atualizado em <b>" + DateTime.Now.ToString("dd/MM/yyyy") + "</b> às <b>" + DateTime.Now.ToString("HH:mm:ss") + "</b>";
        }

        public void listCampaign()
        {
            Campaigns objCampaign = new Campaigns();

            ddlCampanhas.DataSource = objCampaign.listCampaignAssociatedModule(objUsers, this.Form.ID);
            ddlCampanhas.DataTextField = "NomeCampanha";
            ddlCampanhas.DataValueField = "Campaign";
            ddlCampanhas.DataBind();
            ddlCampanhas.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));


            //DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CAMPANHAS"].ToString());

            //if (ds.Tables.Count > 0)
            //{
            //    ddlCampanhas.DataSource = ds;
            //    ddlCampanhas.DataTextField = "Coluna";
            //    ddlCampanhas.DataValueField = "Numero";
            //    ddlCampanhas.DataBind();

            //    ddlCampanhas.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
            //}
        }

        protected void updater_Tick(object sender, EventArgs e)
        {
            updater.Interval = int.Parse(ConfigurationManager.AppSettings["TimeUpdate"].ToString());
            dataHora();

            gridVendas();
            gridVendas15minutos();
            gridVendasOperador();
            gridVendasOperador15minutos();
        }

        private void gridVendas()
        {
            gdVendas.AutoGenerateColumns = false;
            gdVendas.Columns.Clear();

            BoundField bfData = new BoundField();
            bfData.DataField = "DATA";
            bfData.HeaderText = "Data";
            bfData.HeaderStyle.CssClass = "gridViewHeader1";
            bfData.ItemStyle.CssClass = "gridViewValues3";
            bfData.ItemStyle.Width = 100;
            gdVendas.Columns.Add(bfData);

            BoundField bfLogin = new BoundField();
            bfLogin.DataField = "LOGIN";
            bfLogin.HeaderText = "Login";
            bfLogin.HeaderStyle.CssClass = "gridViewHeader1";
            bfLogin.ItemStyle.CssClass = "gridViewValues3";
            bfLogin.ItemStyle.Width = 100;
            gdVendas.Columns.Add(bfLogin);

            BoundField bfNome = new BoundField();
            bfNome.DataField = "NOMEAGENTE";
            bfNome.HeaderText = "Nome";
            bfNome.HeaderStyle.CssClass = "gridViewHeader1";
            bfNome.ItemStyle.CssClass = "gridViewValues2";
            bfNome.ItemStyle.Width = 150;
            gdVendas.Columns.Add(bfNome);

            BoundField bfProposta = new BoundField();
            bfProposta.DataField = "PROPOSTA";
            bfProposta.HeaderText = "Proposta";
            bfProposta.HeaderStyle.CssClass = "gridViewHeader1";
            bfProposta.ItemStyle.CssClass = "gridViewValues3";
            bfProposta.ItemStyle.Width = 100;
            gdVendas.Columns.Add(bfProposta);

            BoundField bfCpfCnpj = new BoundField();
            bfCpfCnpj.DataField = "CPF";
            bfCpfCnpj.HeaderText = "CPF/CNPJ";
            bfCpfCnpj.HeaderStyle.CssClass = "gridViewHeader1";
            bfCpfCnpj.ItemStyle.CssClass = "gridViewValues3";
            bfCpfCnpj.ItemStyle.Width = 80;
            gdVendas.Columns.Add(bfCpfCnpj);

            BoundField bfValor = new BoundField();
            bfValor.DataField = "VALOR";
            bfValor.HeaderText = "Valor";
            bfValor.HeaderStyle.CssClass = "gridViewHeader1";
            bfValor.ItemStyle.CssClass = "gridViewValues2";
            bfValor.ItemStyle.Width = 100;
            gdVendas.Columns.Add(bfValor);

            gdVendas.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdVendas.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdVendas.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_VENDAS"].ToString());
            if (dsQuery.Tables.Count > 0)
            {
                DataTable dtQuery = dsQuery.Tables[0];
                string expression = "CAMPANHA = " + ddlCampanhas.SelectedValue.ToString();
                DataRow[] foundRows;
                foundRows = dtQuery.Select(expression);

                try
                {
                    DataTable dtResultado = foundRows.CopyToDataTable();
                    gdVendas.DataSource = dtResultado;
                    lblMensagemVendas.Visible = false;
                }
                catch
                {
                    lblMensagemVendas.Visible = true;
                    lblMensagemVendas.Text = "<div class='ROK'> Não existem Vendas registradas !! </div>";
                }
            }
            else
            {
                lblMensagemVendas.Visible = true;
                lblMensagemVendas.Text = "<div class='ROK'> Não existem Vendas registradas !! </div>";
            }
            gdVendas.DataBind();
        }

        private void gridVendas15minutos()
        {
            gdVendas_15minutos.AutoGenerateColumns = false;
            gdVendas_15minutos.Columns.Clear();

            BoundField bfData = new BoundField();
            bfData.DataField = "DATA";
            bfData.HeaderText = "Data";
            bfData.HeaderStyle.CssClass = "gridViewHeader1";
            bfData.ItemStyle.CssClass = "gridViewValues3";
            bfData.ItemStyle.Width = 100;
            gdVendas_15minutos.Columns.Add(bfData);

            BoundField bfLogin = new BoundField();
            bfLogin.DataField = "LOGIN";
            bfLogin.HeaderText = "Login";
            bfLogin.HeaderStyle.CssClass = "gridViewHeader1";
            bfLogin.ItemStyle.CssClass = "gridViewValues3";
            bfLogin.ItemStyle.Width = 100;
            gdVendas_15minutos.Columns.Add(bfLogin);

            BoundField bfNome = new BoundField();
            bfNome.DataField = "NOMEAGENTE";
            bfNome.HeaderText = "Nome";
            bfNome.HeaderStyle.CssClass = "gridViewHeader1";
            bfNome.ItemStyle.CssClass = "gridViewValues2";
            bfNome.ItemStyle.Width = 150;
            gdVendas_15minutos.Columns.Add(bfNome);

            BoundField bfProposta = new BoundField();
            bfProposta.DataField = "PROPOSTA";
            bfProposta.HeaderText = "Proposta";
            bfProposta.HeaderStyle.CssClass = "gridViewHeader1";
            bfProposta.ItemStyle.CssClass = "gridViewValues3";
            bfProposta.ItemStyle.Width = 100;
            gdVendas_15minutos.Columns.Add(bfProposta);

            BoundField bfCpfCnpj = new BoundField();
            bfCpfCnpj.DataField = "CPF";
            bfCpfCnpj.HeaderText = "CPF/CNPJ";
            bfCpfCnpj.HeaderStyle.CssClass = "gridViewHeader1";
            bfCpfCnpj.ItemStyle.CssClass = "gridViewValues3";
            bfCpfCnpj.ItemStyle.Width = 80;
            gdVendas_15minutos.Columns.Add(bfCpfCnpj);

            BoundField bfValor = new BoundField();
            bfValor.DataField = "VALOR";
            bfValor.HeaderText = "Valor";
            bfValor.HeaderStyle.CssClass = "gridViewHeader1";
            bfValor.ItemStyle.CssClass = "gridViewValues2";
            bfValor.ItemStyle.Width = 100;
            gdVendas_15minutos.Columns.Add(bfValor);

            gdVendas_15minutos.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdVendas_15minutos.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdVendas_15minutos.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_VENDAS15MINUTOS"].ToString());
            if (dsQuery.Tables.Count > 0)
            {
                DataTable dtQuery = dsQuery.Tables[0];
                string expression = "CAMPANHA = " + ddlCampanhas.SelectedValue.ToString();
                DataRow[] foundRows;
                foundRows = dtQuery.Select(expression);

                try
                {
                    DataTable dtResultado = foundRows.CopyToDataTable();
                    gdVendas_15minutos.DataSource = dtResultado;
                    lblMensagemVendas15minutos.Visible = false;
                }
                catch
                {
                    lblMensagemVendas15minutos.Visible = true;
                    lblMensagemVendas15minutos.Text = "<div class='ROK'> Não existem Vendas registradas nos ultimos 15 minutos !! </div>";
                }
            }
            else
            {
                lblMensagemVendas15minutos.Visible = true;
                lblMensagemVendas15minutos.Text = "<div class='ROK'> Não existem Vendas registradas nos ultimos 15 minutos !! </div>";
            }
            gdVendas_15minutos.DataBind();
        }

        private void gridVendasOperador()
        {
            gdVendasOperador.AutoGenerateColumns = false;
            gdVendasOperador.Columns.Clear();

            BoundField bfLogin = new BoundField();
            bfLogin.DataField = "LOGIN";
            bfLogin.HeaderText = "Login";
            bfLogin.HeaderStyle.CssClass = "gridViewHeader1";
            bfLogin.ItemStyle.CssClass = "gridViewValues3";
            bfLogin.ItemStyle.Width = 100;
            gdVendasOperador.Columns.Add(bfLogin);

            BoundField bfNome = new BoundField();
            bfNome.DataField = "NOMEAGENTE";
            bfNome.HeaderText = "Nome";
            bfNome.HeaderStyle.CssClass = "gridViewHeader1";
            bfNome.ItemStyle.CssClass = "gridViewValues3";
            bfNome.ItemStyle.Width = 150;
            gdVendasOperador.Columns.Add(bfNome);

            BoundField bfQtde = new BoundField();
            bfQtde.DataField = "QTDE";
            bfQtde.HeaderText = "Qtde";
            bfQtde.HeaderStyle.CssClass = "gridViewHeader1";
            bfQtde.ItemStyle.CssClass = "gridViewValues3";
            bfQtde.ItemStyle.Width = 100;
            gdVendasOperador.Columns.Add(bfQtde);

            gdVendasOperador.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdVendasOperador.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdVendasOperador.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_VENDASOPERADOR"].ToString());
            if (dsQuery.Tables.Count > 0)
            {
                DataTable dtQuery = dsQuery.Tables[0];
                string expression = "CAMPANHA = " + ddlCampanhas.SelectedValue.ToString();
                DataRow[] foundRows;
                foundRows = dtQuery.Select(expression);

                try
                {
                    DataTable dtResultado = foundRows.CopyToDataTable();
                    gdVendasOperador.DataSource = dtResultado;
                    lblMensagemVendasOperador.Visible = false;
                }
                catch
                {
                    lblMensagemVendasOperador.Visible = true;
                    lblMensagemVendasOperador.Text = "<div class='ROK'> Não existem Vendas registradas !! </div>";
                }
            }
            else
            {
                lblMensagemVendasOperador.Visible = true;
                lblMensagemVendasOperador.Text = "<div class='ROK'> Não existem Vendas registradas !! </div>";
            }
            gdVendasOperador.DataBind();
        }

        private void gridVendasOperador15minutos()
        {
            gdVendasOperador_15minutos.AutoGenerateColumns = false;
            gdVendasOperador_15minutos.Columns.Clear();

            BoundField bfLogin = new BoundField();
            bfLogin.DataField = "LOGIN";
            bfLogin.HeaderText = "Login";
            bfLogin.HeaderStyle.CssClass = "gridViewHeader1";
            bfLogin.ItemStyle.CssClass = "gridViewValues3";
            bfLogin.ItemStyle.Width = 100;
            gdVendasOperador_15minutos.Columns.Add(bfLogin);

            BoundField bfNome = new BoundField();
            bfNome.DataField = "NOMEAGENTE";
            bfNome.HeaderText = "Nome";
            bfNome.HeaderStyle.CssClass = "gridViewHeader1";
            bfNome.ItemStyle.CssClass = "gridViewValues2";
            bfNome.ItemStyle.Width = 150;
            gdVendasOperador_15minutos.Columns.Add(bfNome);

            BoundField bfQtde = new BoundField();
            bfQtde.DataField = "QTDE";
            bfQtde.HeaderText = "Qtde";
            bfQtde.HeaderStyle.CssClass = "gridViewHeader1";
            bfQtde.ItemStyle.CssClass = "gridViewValues3";
            bfQtde.ItemStyle.Width = 100;
            gdVendasOperador_15minutos.Columns.Add(bfQtde);

            gdVendasOperador_15minutos.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdVendasOperador_15minutos.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdVendasOperador_15minutos.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_VENDASOPERADOR15MINUTOS"].ToString());
            if (dsQuery.Tables.Count > 0)
            {
                DataTable dtQuery = dsQuery.Tables[0];
                string expression = "CAMPANHA = " + ddlCampanhas.SelectedValue.ToString();
                DataRow[] foundRows;
                foundRows = dtQuery.Select(expression);

                try
                {
                    DataTable dtResultado = foundRows.CopyToDataTable();
                    gdVendasOperador_15minutos.DataSource = dtResultado;
                    lblMensagemVendasOperador15minutos.Visible = false;
                }
                catch
                {
                    lblMensagemVendasOperador15minutos.Visible = true;
                    lblMensagemVendasOperador15minutos.Text = "<div class='ROK'> Não existem Vendas registradas nos ultimos 15 minutos !! </div>";
                }
            }
            else
            {
                lblMensagemVendasOperador15minutos.Visible = true;
                lblMensagemVendasOperador15minutos.Text = "<div class='ROK'> Não existem Vendas registradas nos ultimos 15 minutos !! </div>";
            }
            gdVendasOperador_15minutos.DataBind();
        }

        protected void cbVendas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVendas.Checked == true)
            {
                boxVendas.Visible = true;
            }
            else
            {
                boxVendas.Visible = false;
            }
        }

        protected void cbVendas_15minutos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVendas_15minutos.Checked == true)
            {
                boxVendas_15minutos.Visible = true;
            }
            else
            {
                boxVendas_15minutos.Visible = false;
            }
        }

        protected void cbVendasOperador_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVendasOperador.Checked == true)
            {
                boxVendasOperador.Visible = true;
            }
            else
            {
                boxVendasOperador.Visible = false;
            }
        }

        protected void cbVendasOperador_15minutos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVendasOperador_15minutos.Checked == true)
            {
                boxVendasOperador_15minutos.Visible = true;
            }
            else
            {
                boxVendasOperador_15minutos.Visible = false;
            }
        }
    }
}
