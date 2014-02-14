using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.BLL.Tribanco;
using _webPainelVerisys.DTO;
using _webPainelVerisys.DTO.Tribanco;

namespace _webPainelVerisys.Tribanco
{
    public partial class PriorizacaoMailing : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        _webPainelVerisys.BLL.Tribanco.Mailing objMailingsTribanco = new _webPainelVerisys.BLL.Tribanco.Mailing();

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
                AccessSecurity();
                loadCampaign();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/DashBoard.aspx");
            }
        }

        protected void loadCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampaign.SelectedIndex > 0)
            {
                gridLista();
                modLista.Visible = true;
                modExecucao.Visible = true;
            }
        }

        protected void gridLista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            ButtonField btnUpdate = new ButtonField();
            btnUpdate.ButtonType = ButtonType.Image;
            btnUpdate.ImageUrl = "../img/edit.gif";
            btnUpdate.CommandName = "Upd";
            btnUpdate.ItemStyle.Width = 25;
            btnUpdate.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnUpdate.HeaderText = "";
            btnUpdate.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnUpdate);

            BoundField DSCRegra = new BoundField();
            DSCRegra.DataField = "REGRADISTRIBUICAO";
            DSCRegra.HeaderText = "Regra de Distribuição";
            DSCRegra.HeaderStyle.CssClass = "gridViewHeader";
            DSCRegra.ItemStyle.CssClass = "gridViewValues3";
            DSCRegra.ItemStyle.Width = 100;
            DSCRegra.SortExpression = "REGRADISTRIBUICAO";
            gdRegistros.Columns.Add(DSCRegra);

            BoundField DSCCampanha = new BoundField();
            DSCCampanha.DataField = "CAMPANHA";
            DSCCampanha.HeaderText = "Campanha";
            DSCCampanha.HeaderStyle.CssClass = "gridViewHeader";
            DSCCampanha.ItemStyle.CssClass = "gridViewValues3";
            DSCCampanha.ItemStyle.Width = 100;
            DSCCampanha.SortExpression = "CAMPANHA";
            gdRegistros.Columns.Add(DSCCampanha);

            BoundField DSCPrioridade = new BoundField();
            DSCPrioridade.DataField = "PRIORIDADE";
            DSCPrioridade.HeaderText = "Prioridade";
            DSCPrioridade.HeaderStyle.CssClass = "gridViewHeader";
            DSCPrioridade.ItemStyle.CssClass = "gridViewValues3";
            DSCPrioridade.ItemStyle.Width = 100;
            DSCPrioridade.SortExpression = "PRIORIDADE";
            gdRegistros.Columns.Add(DSCPrioridade);

            BoundField DateTimeMH = new BoundField();
            DateTimeMH.DataField = "DATAHORA";
            DateTimeMH.HeaderText = "Data/Hora";
            DateTimeMH.HeaderStyle.CssClass = "gridViewHeader";
            DateTimeMH.ItemStyle.CssClass = "gridViewValues3";
            DateTimeMH.ItemStyle.Width = 100;
            DateTimeMH.SortExpression = "DATAHORA";
            gdRegistros.Columns.Add(DateTimeMH);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            _webPainelVerisys.DTO.Tribanco.dtoMailing objAuxMailing = new _webPainelVerisys.DTO.Tribanco.dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.User = objUsers.User;

            DataSet dsQuery = objMailingsTribanco.listDadosPrioridade(objAuxMailing);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Dados de Prioridade Cadastrados !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencao.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblTituloDiv.Text = "Alteração de Priorizacao de Mailing";
                lblID.Text = gdRegistros.DataKeys[index]["REGRADISTRIBUICAO"].ToString();

                txtIDCampanha.Text = gdRegistros.DataKeys[index]["CAMPANHA"].ToString();
                txtRegra.Text = gdRegistros.DataKeys[index]["REGRADISTRIBUICAO"].ToString();
                txtPrioridade.Text = gdRegistros.DataKeys[index]["PRIORIDADE"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            _webPainelVerisys.DTO.Tribanco.dtoMailing objAuxMailing = new _webPainelVerisys.DTO.Tribanco.dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.User = objUsers.User;

            DataSet dsRegistros = objMailingsTribanco.listDadosPrioridade(objAuxMailing);
            if (dsRegistros.Tables[0].Rows.Count > 0)
            {
                DataTable dtRegistros = (DataTable)dsRegistros.Tables[0];
                String _coluna = e.SortExpression;

                if (_coluna.Equals(Session["ULTIMOSORT"]))
                    _coluna = _coluna + " desc";

                Session.Add("ULTIMOSORT", _coluna);
                dtRegistros.DefaultView.Sort = _coluna;

                gdRegistros.DataSource = dtRegistros;
                gdRegistros.DataBind();
            }
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Alteração de Priorizacao de Mailing")
            {
                Alteracao();
            }

            Limpar();
        }

        protected void ManagerFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            Filtrar();
            Limpar();
        }

        protected void Alteracao()
        {
            try
            {
                _webPainelVerisys.DTO.Tribanco.dtoMailing objDtoMailing = new _webPainelVerisys.DTO.Tribanco.dtoMailing();
                objDtoMailing.Task = 2;
                objDtoMailing.Campaign = ddlCampaign.SelectedValue.ToString();
                objDtoMailing.Prioridade = txtPrioridade.Text;
                objDtoMailing.RegraDistribuicao = lblID.Text;
                objDtoMailing.User = objUsers.User;

                Int64 intResultado = objMailingsTribanco.ManagerPriorizacao(objDtoMailing);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração de Prioridade executado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Prioridade !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Prioridade !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Filtrar()
        {
            try
            {
                _webPainelVerisys.DTO.Tribanco.dtoMailing objDtoMailing = new _webPainelVerisys.DTO.Tribanco.dtoMailing();
                objDtoMailing.Task = 4;
                objDtoMailing.Campaign = ddlCampaign.SelectedValue.ToString();
                objDtoMailing.User = objUsers.User;

                Int64 intResultado = objMailingsTribanco.ManagerPriorizacao(objDtoMailing);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Priorização executado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Execução de Priorização !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Execução de Priorização !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Alteração de Priorizacao de Mailing";
                modManutencao.Visible = false;
                modLista.Visible = false;
                modExecucao.Visible = false;
                txtPrioridade.Text = "";
                txtRegra.Text = "";
                txtIDCampanha.Text = "";
                loadCampaign();
            }
            catch
            {

            }
        }

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gridLista();
        }

        protected void gdRegistros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Color = "#E8F3FF";

                if (((e.Row.RowIndex + 1) % 2) == 0)
                {
                    e.Row.CssClass = "gridViewValues1";
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml(Color);
                }
            }
        }
    }
}
