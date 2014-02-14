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

namespace _webPainelVerisys.Campanha
{
    public partial class CampanhaModulo : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();

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
                dtoCampaign objAuxCampaign = new dtoCampaign();
                objAuxCampaign.Campaign = ddlCampaign.SelectedValue.ToString();

                DataSet dsCampanha = objCampaign.listCampaignModule(objAuxCampaign);

                if (dsCampanha.Tables[0].Rows.Count > 0)
                {
                    rModulos.DataSource = dsCampanha.Tables[0];
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
                dtoCampaign objDtoCampaign = new dtoCampaign();
                objDtoCampaign.Task = 2;
                objDtoCampaign.User = objUsers.User;
                objDtoCampaign.Campaign = ddlCampaign.SelectedValue.ToString();

                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    Label ID = (Label)ri.FindControl("lblID");
                    Label Nome = (Label)ri.FindControl("lblNomeModulo");
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkAcesso");
                    String strModulo = "";

                    if (ckBox.Checked == true)
                    {
                        strModulo = Nome.Text;
                        objDtoCampaign.Modulo += strModulo + ","; // +"," + ModuloInclusao;
                    }
                }

                if ((objDtoCampaign.Modulo != String.Empty) && (objDtoCampaign.Modulo != null))
                    objDtoCampaign.Modulo = objDtoCampaign.Modulo.Substring(0, objDtoCampaign.Modulo.Length - 1);
                else
                    objDtoCampaign.Modulo = "NONE";

                Int64 intResultado = objCampaign.managerCampaignModule(objDtoCampaign);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração de Campanha X Modulo realizado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Campanha X Modulo  !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Campanha X Modulo !! </div>";
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
    }
}
