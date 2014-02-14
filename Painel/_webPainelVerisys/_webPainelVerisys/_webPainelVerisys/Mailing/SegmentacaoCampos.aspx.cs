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
    public partial class SegmentacaoCampos : System.Web.UI.Page
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
                dtoMailing objAux = new dtoMailing();
                objAux.Campaign = ddlCampaign.SelectedValue.ToString();

                DataSet dsQuery = objMailing.listSegmentacaoCamposTBDiscador(objAux);

                if (dsQuery.Tables[0].Rows.Count > 0)
                {
                    rModulos.DataSource = dsQuery.Tables[0];
                    rModulos.DataBind();
                }

                modCampanhaModulo.Visible = true;
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            Alteracao();
            Limpar();
        }

        protected void Alteracao()
        {
            try
            {
                dtoMailing objAux = new dtoMailing();
                objAux.Task = 2;
                objAux.User = objUsers.User;
                objAux.Campaign = ddlCampaign.SelectedValue.ToString();

                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    //Label ID = (Label)ri.FindControl("lblID");
                    Label Nome = (Label)ri.FindControl("lblColuna");
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkAcesso");
                    String strColuna = "";

                    if (ckBox.Checked == true)
                    {
                        strColuna = Nome.Text;
                        objAux.SegmentacaoCampo += strColuna + ",";
                    }
                }

                if ((objAux.SegmentacaoCampo != String.Empty) && (objAux.SegmentacaoCampo != null))
                    objAux.SegmentacaoCampo = objAux.SegmentacaoCampo.Substring(0, objAux.SegmentacaoCampo.Length - 1);
                else
                    objAux.SegmentacaoCampo = "NONE";

                Int64 intResultado = objMailing.managerSegmentacaoCamposTBDiscador(objAux, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração realizada com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração !! </div>";
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
            }
            catch
            {

            }
        }

        protected void rModulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
