using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class ImportacaoIdentificadoresLotes : System.Web.UI.Page
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

        protected void loadIdentificadores(String strIDCampanha)
        {
            dtoCampaign objAuxCampaign = new dtoCampaign();
            objAuxCampaign.Campaign = ddlCampaign.SelectedValue.ToString();
            ddlCampo.DataSource = objCampaign.listIdentificadoresAssociados(objAuxCampaign);
            ddlCampo.DataTextField = "Identificador";
            ddlCampo.DataValueField = "Identificador";
            ddlCampo.DataBind();
            ddlCampo.Items.Insert(0, new ListItem("Selecione o Identificador ...", "0"));
        }

        public void loadMailingHandler()
        {
            divROContent.Visible = false;

            if (ddlCampaign.SelectedValue == "0")
            {
                return;
            }

            if (ddlLote.SelectedValue == "0")
            {
                return;
            }

            gridListaHistorico();
        }

        protected void gridListaHistorico()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            BoundField bfCampaign = new BoundField();
            bfCampaign.DataField = "ITEM";
            bfCampaign.HeaderText = "Descrição";
            bfCampaign.HeaderStyle.CssClass = "gridViewHeader";
            bfCampaign.ItemStyle.CssClass = "gridViewValues1";
            bfCampaign.ItemStyle.Width = 400;
            bfCampaign.SortExpression = "ITEM";
            gdRegistros.Columns.Add(bfCampaign);

            BoundField bfLot = new BoundField();
            bfLot.DataField = "QTDE";
            bfLot.HeaderText = "Qtde";
            bfLot.HeaderStyle.CssClass = "gridViewHeader1";
            bfLot.ItemStyle.CssClass = "gridViewValues3";
            bfLot.ItemStyle.Width = 100;
            bfLot.SortExpression = "QTDE";
            gdRegistros.Columns.Add(bfLot);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objMailings.PAN_ListaIdentificadoresLote(ddlCampaign.SelectedValue.ToString(), Convert.ToInt32(ddlLote.SelectedValue), ddlCampo.SelectedValue.ToString(), objUsers);

            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                divROContent.Visible = true;
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
                loadIdentificadores(ddlCampaign.SelectedValue.ToString());
            }
        }

        protected void buttonImageFilter_Click(object sender, ImageClickEventArgs e)
        {
            loadMailingHandler();
        }
    }
}
