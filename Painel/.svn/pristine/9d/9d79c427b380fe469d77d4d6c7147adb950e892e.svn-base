using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class SegmentacaoProcesso : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        Mailings objMailing = new Mailings();

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
                PageConfig();
                AccessMailing();
                
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/Default.aspx");
            }

            objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-filtrar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
        }

        private void PageConfig()
        {
            dtoPageConfig objdtoPageConfig = null;
            bllPageConfig objPageConfig = new bllPageConfig();

            String strApplication = Session["ObjApplication"].ToString();
            objdtoPageConfig = objPageConfig.listPageConfig(this.Form.ID, strApplication);

            lblTitulo.Text = objdtoPageConfig.Descricao;
        }

        private void AccessMailing()
        {
            List<dtoUsersProfiles> listProfile = objUsersProfiles.AccessMailing(objUsers);
            if (listProfile.Count > 1)
            {
                loadCampaign(true);
                divCampanhaContent.Visible = true;
                divContent.Visible = false;
                divSegmentacaoContent.Visible = false;
            }
            else
            {
                loadCampaign(false);
                divCampanhaContent.Visible = false;
                divContent.Visible = false;
                loadSegmentacoes();
                divSegmentacaoContent.Visible = true;
            }
        }

        protected void loadCampaign(Boolean bolVisible)
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();

            if (bolVisible)
                ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected Boolean loadSegmentacoes()
        {
            // comentario
            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.IDSegmentacao = "";

            DataSet dsQuery = objMailing.listSegmentacaoProcesso(objAuxMailing, objUsers);
            if (dsQuery != null)
            {
                ddlSegmentacao.DataSource = dsQuery.Tables[0];
                ddlSegmentacao.DataTextField = "NOME_SEGMENTACAO";
                ddlSegmentacao.DataValueField = "ID_SEGMENTACAO";
                ddlSegmentacao.DataBind();
                ddlSegmentacao.Items.Insert(0, new ListItem("Selecione a Segmentação...", "0"));

                return true;
            }
            else
            {
                return false;
            }
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadSegmentacoes())
            {
                divSegmentacaoContent.Visible = true;
                divResponse.Visible = false;
            }
            else
            {
                divContent.Visible = false;
                divSegmentacaoContent.Visible = false;
                lblResponse.Text = "<div class='RNOK'>Essa Base de Mailing não possui modulo de Segmentação !! </div>";
                divResponse.Visible = true;
                return;
            }
        }

        protected void ddlSegmentacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            divContent.Visible = true;
            //gridListaSegmentacao(ddlCampaign.SelectedValue.ToString(), ddlSegmentacao.SelectedValue.ToString());
            gridListaRegra(ddlCampaign.SelectedValue.ToString(), ddlSegmentacao.SelectedValue.ToString());
        }

        protected void gridListaSegmentacao(String IDCampanha, String IDSegmentacao)
        {
            gdSegmentacao.AutoGenerateColumns = false;
            gdSegmentacao.Columns.Clear();

            BoundField ID = new BoundField();
            ID.DataField = "ID_SEGMENTACAO";
            ID.HeaderText = "ID";
            ID.HeaderStyle.CssClass = "gridViewHeader1";
            ID.ItemStyle.CssClass = "gridViewValues3";
            ID.ItemStyle.Width = 50;
            ID.SortExpression = "ID_SEGMENTACAO";
            gdSegmentacao.Columns.Add(ID);

            BoundField DSCDescricao = new BoundField();
            DSCDescricao.DataField = "NOME_SEGMENTACAO";
            DSCDescricao.HeaderText = "Descrição";
            DSCDescricao.HeaderStyle.CssClass = "gridViewHeader";
            DSCDescricao.ItemStyle.CssClass = "gridViewValues2";
            DSCDescricao.ItemStyle.Width = 400;
            DSCDescricao.SortExpression = "NOME_SEGMENTACAO";
            gdSegmentacao.Columns.Add(DSCDescricao);

            BoundField bfCampanha = new BoundField();
            bfCampanha.DataField = "NUMERO_CAMPANHA";
            bfCampanha.HeaderText = "Campanha";
            bfCampanha.HeaderStyle.CssClass = "gridViewHeader";
            bfCampanha.ItemStyle.CssClass = "gridViewValues3";
            bfCampanha.ItemStyle.Width = 50;
            bfCampanha.SortExpression = "NUMERO_CAMPANHA";
            gdSegmentacao.Columns.Add(bfCampanha);

            BoundField bfLote = new BoundField();
            bfLote.DataField = "NUMERO_LOTE";
            bfLote.HeaderText = "Lote";
            bfLote.HeaderStyle.CssClass = "gridViewHeader";
            bfLote.ItemStyle.CssClass = "gridViewValues3";
            bfLote.ItemStyle.Width = 50;
            bfLote.SortExpression = "NUMERO_LOTE";
            gdSegmentacao.Columns.Add(bfLote);

            BoundField bfPriority = new BoundField();
            bfPriority.DataField = "PRIORIDADE";
            bfPriority.HeaderText = "Prioridade";
            bfPriority.HeaderStyle.CssClass = "gridViewHeader";
            bfPriority.ItemStyle.CssClass = "gridViewValues3";
            bfPriority.ItemStyle.Width = 50;
            bfPriority.SortExpression = "PRIORIDADE";
            gdSegmentacao.Columns.Add(bfPriority);

            BoundField bfStatus = new BoundField();
            bfStatus.DataField = "FLAG_ATIVO";
            bfStatus.HeaderText = "Ativo ?";
            bfStatus.HeaderStyle.CssClass = "gridViewHeader";
            bfStatus.ItemStyle.CssClass = "gridViewValues3";
            bfStatus.ItemStyle.Width = 50;
            bfStatus.SortExpression = "FLAG_ATIVO";
            gdSegmentacao.Columns.Add(bfStatus);

            gdSegmentacao.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdSegmentacao.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdSegmentacao.FooterStyle.CssClass = "gridViewHeader";

            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.IDSegmentacao = "";

            DataSet dsQuery = objMailing.listSegmentacao(objAuxMailing, objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdSegmentacao.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Não existem Segmentações Cadastradas !! </div>";
            }

            gdSegmentacao.DataBind();
        }

        protected void gridListaRegra(String IDCampanha, String IDSegmentacao)
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            BoundField ID = new BoundField();
            ID.DataField = "ID_SEGMENTACAOREGRA";
            ID.HeaderText = "ID";
            ID.HeaderStyle.CssClass = "gridViewHeader1";
            ID.ItemStyle.CssClass = "gridViewValues3";
            ID.ItemStyle.Width = 50;
            ID.SortExpression = "ID_SEGMENTACAOREGRA";
            gdRegistros.Columns.Add(ID);

            BoundField bfCampo = new BoundField();
            bfCampo.DataField = "CAMPO_SEGMENTACAO";
            bfCampo.HeaderText = "Campo";
            bfCampo.HeaderStyle.CssClass = "gridViewHeader";
            bfCampo.ItemStyle.CssClass = "gridViewValues2";
            bfCampo.ItemStyle.Width = 100;
            bfCampo.SortExpression = "CAMPO_SEGMENTACAO";
            gdRegistros.Columns.Add(bfCampo);

            BoundField bfRegra = new BoundField();
            bfRegra.DataField = "REGRA_SEGMENTACAO";
            bfRegra.HeaderText = "Operador";
            bfRegra.HeaderStyle.CssClass = "gridViewHeader";
            bfRegra.ItemStyle.CssClass = "gridViewValues3";
            bfRegra.ItemStyle.Width = 100;
            bfRegra.SortExpression = "REGRA_SEGMENTACAO";
            gdRegistros.Columns.Add(bfRegra);

            BoundField bfValor = new BoundField();
            bfValor.DataField = "VALOR_SEGMENTACAO";
            bfValor.HeaderText = "Valor";
            bfValor.HeaderStyle.CssClass = "gridViewHeader";
            bfValor.ItemStyle.CssClass = "gridViewValues2";
            bfValor.ItemStyle.Width = 300;
            bfValor.SortExpression = "VALOR_SEGMENTACAO";
            gdRegistros.Columns.Add(bfValor);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = IDCampanha;
            objAuxMailing.IDSegmentacao = IDSegmentacao;

            DataSet dsQuery = objMailing.listSegmentacaoRegras(objAuxMailing, objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                divResponse.Visible = false;
                gdRegistros.DataSource = dsQuery;
                gdRegistros.DataBind();
            }
            else
            {
                divContent.Visible = false;
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Não existem Segmentações Cadastradas !! </div>";
            }
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

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.User = objUsers.User;
                objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
                objAuxMailing.IDSegmentacao = ddlSegmentacao.SelectedValue.ToString();

                Int64 intResultado = objMailing.managerSegmentacaoProcesso(objAuxMailing, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Segmentação Executada com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante o Processo de Segmentação !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eManager)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante o Processo de Segmentação !! </div>";
                divResponse.Visible = true;
            }

            Limpar();
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                divContent.Visible = false;
                ddlSegmentacao.SelectedIndex = 0;
            }
            catch
            {

            }
        }

    }
}
