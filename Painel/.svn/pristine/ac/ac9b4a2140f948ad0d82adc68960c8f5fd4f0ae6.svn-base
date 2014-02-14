using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class BuscaMailing : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        Mailings objMailings = new Mailings();

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
                PageConfig();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/Default.aspx");
            }

            objUsersProfiles.AcessProfileButton(buttonImageFilter, "~/img/btn-filtrar.gif", this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, Convert.ToInt32(objUsers.IdProfile));
        }

        private void PageConfig()
        {
            dtoPageConfig objdtoPageConfig = null;
            bllPageConfig objPageConfig = new bllPageConfig();

            String strApplication = Session["ObjApplication"].ToString();
            objdtoPageConfig = objPageConfig.listPageConfig(this.Form.ID, strApplication);

            lblTitulo.Text = objdtoPageConfig.Descricao;
        }

        protected void loadCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void loadLote(String strIDCampanha)
        {
            dtoCampaign objAuxCampaign = new dtoCampaign();
            objAuxCampaign.Campaign = ddlCampaign.SelectedValue.ToString();
            ddlLote.DataSource = objCampaign.listLotAssociated(objAuxCampaign);
            ddlLote.DataTextField = "NomeLote";
            ddlLote.DataValueField = "NumeroLote";
            ddlLote.DataBind();
            ddlLote.Items.Insert(0, new ListItem("Selecione o Lote ...", "0"));
        }

        public void loadSegmentacaoCampo()
        {
            String StrTabelaDiscador = objCampaign.BuscaTabelaDiscador(ddlCampaign.SelectedValue);

            ddlCampo.DataSource = objMailings.listSegmentacaoCampo(ddlCampaign.SelectedValue.ToString(), StrTabelaDiscador);
            ddlCampo.DataTextField = "SegmentacaoCampo";
            ddlCampo.DataValueField = "SegmentacaoCampo";
            ddlCampo.DataBind();
            ddlCampo.Items.Insert(0, new ListItem("Selecione o Campo...", "0"));
        }

        protected void gridLista()
        {
            gdRegistros.AutoGenerateColumns = true;
            gdRegistros.Columns.Clear();

            gdRegistros.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.RowStyle.CssClass = "gridViewValues2";
            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objMailings.ListaRegistroMailing(ddlCampaign.SelectedValue.ToString(), Convert.ToInt32(ddlLote.SelectedValue), ddlCampo.SelectedValue, txtValor.Text, objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                divContent.Visible = true;
                gdRegistros.DataSource = dsQuery.Tables[0];
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem registros para o Filtro Solicitado !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "white-space:nowrap; padding:5px 5px 5px 5px;");
            }

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

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlCampaign.SelectedValue != "0") && (ddlCampaign.SelectedValue != null))
            {
                loadLote(ddlCampaign.SelectedValue.ToString());
                loadSegmentacaoCampo();
            }
        }

        protected void buttonImageFilter_Click(object sender, ImageClickEventArgs e)
        {
            gridLista();
        }
    }
}
