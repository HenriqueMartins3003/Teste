using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class ExportacaoMailingMetralhadora : System.Web.UI.Page
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
                loadCampaign();
                PageConfig();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/DashBoard.aspx");
            }
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

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampaign.SelectedIndex > 0)
            {
                divResponse.Visible = false;

                loadLote(ddlCampaign.SelectedValue);

                Mailings objMailing = new Mailings();
                DataSet dsStatus = objMailing.listStatusChamada();
                if (dsStatus.Tables[0].Rows.Count > 0)
                {
                    rStatus.DataSource = dsStatus.Tables[0];
                    rStatus.DataBind();
                }

                RO objRO = new RO();
                DataSet dsQuery = objRO.DatasetRO_Fidelity(ddlCampaign.SelectedValue, objUsers);
                if (dsQuery.Tables[0].Rows.Count > 0)
                {
                    rMotivo.DataSource = dsQuery.Tables[0];
                    rMotivo.DataBind();
                }

                modCampanhaModulo.Visible = true;
                
                
                
                
                
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
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

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            Executar();
            Limpar();
        }

        protected void Executar()
        {
            try
            {
                if (ddlLote.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'> Seleção de Lote Obrigatória !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoMailingMetralhadora objAux = new dtoMailingMetralhadora();
                objAux.Campanha = ddlCampaign.SelectedValue.ToString();
                objAux.Lote = Convert.ToInt64(ddlLote.SelectedValue);

                foreach (RepeaterItem ri in this.rStatus.Items)
                {
                    Label Nome = (Label)ri.FindControl("lblColunaID");
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkAcesso");
                    String strColuna = "";

                    if (ckBox.Checked == true)
                    {
                        strColuna = Nome.Text;
                        objAux.ListStatus += strColuna + ",";
                    }
                }

                foreach (RepeaterItem ri in this.rMotivo.Items)
                {
                    Label Nome = (Label)ri.FindControl("lblColunaIDMotivo");
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkAcessoMotivo");
                    String strColunaMotivo = "";

                    if (ckBox.Checked == true)
                    {
                        strColunaMotivo = Nome.Text;
                        objAux.ListRO += strColunaMotivo + ",";
                    }
                }

                if (!String.IsNullOrEmpty(objAux.ListStatus))
                    objAux.ListStatus = objAux.ListStatus.Substring(0, objAux.ListStatus.Length - 1);
                else
                    objAux.ListStatus = "NONE";

                if (!String.IsNullOrEmpty(objAux.ListRO))
                    objAux.ListRO = objAux.ListRO.Substring(0, objAux.ListRO.Length - 1);
                else
                    objAux.ListRO = "NONE";

                Int64 intResultado = objMailing.UINT_ExportacaoMetralhadora(objAux, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Arquivo Gerado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Geração do Arquivo !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Geração do Arquivo !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                modCampanhaModulo.Visible = false;
                loadCampaign();
                ddlLote.ClearSelection();
            }
            catch
            {

            }
        }

        protected void rStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item)
            //{
            //    string Color = "#E8F3FF";

            //    if (((e.Item.ItemIndex + 1) % 2) == 0)
            //    {
            //        e.Item.CssClass = "gridViewValues1";
            //        e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml(Color);
            //    }
            //}
        }

        protected void rMotivo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item)
            //{
            //    string Color = "#E8F3FF";

            //    if (((e.Item.ItemIndex + 1) % 2) == 0)
            //    {
            //        e.Item.CssClass = "gridViewValues1";
            //        e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml(Color);
            //    }
            //}
        }
    }
}
