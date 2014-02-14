using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class CampanhaMetralhadora : System.Web.UI.Page
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
                loadGroups();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/DashBoard.aspx");
            }
        }

        protected void loadGroups()
        {
            ddlGrupos.DataSource = objCampaign.listCampaignAssociatedGroupUser(objUsers);
            ddlGrupos.DataTextField = "Grupo";
            ddlGrupos.DataValueField = "GrupoID";
            ddlGrupos.DataBind();
            ddlGrupos.Items.Insert(0, new ListItem("Selecione o Grupo...", "0"));
        }



        public void loadCampanha()
        {
            rModulos.DataSource = objCampaign.listCampaignMetralhadora(ddlGrupos.SelectedValue);
            rModulos.DataBind();

            DataSet dsQuery = objCampaign.listGroups();
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                txtCanaisMaximo.Text = dsQuery.Tables[0].Rows[0]["QtdeMaximaCanais"].ToString();
            }
            else
            {
                txtCanaisMaximo.Text = "0";
            }

            Int32 SomaMeta = 0;
            foreach (RepeaterItem ri in this.rModulos.Items)
            {
                TextBox Meta = (TextBox)ri.FindControl("txtMeta");
                if (String.IsNullOrEmpty(Meta.Text))
                    Meta.Text = "0";

                SomaMeta += Convert.ToInt32(Meta.Text);
            }

            txtCanaisUtilizados.Text = SomaMeta.ToString();
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
                Int32 SomaMeta = 0;
                String listaCampanha = "'";

                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    TextBox Meta = (TextBox)ri.FindControl("txtMeta");
                    if (String.IsNullOrEmpty(Meta.Text))
                        Meta.Text = "0";

                    SomaMeta += Convert.ToInt32(Meta.Text);
                }
                txtCanaisUtilizados.Text = SomaMeta.ToString();

                if (SomaMeta > Convert.ToInt32(txtCanaisMaximo.Text))
                {
                    lblResponse.Text = "<div class='RNOK'> Quantidade de Canais não pode ser superior a quantidade Maxima Permitida !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                Int64 intResultado = 0;
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    Label ID = (Label)ri.FindControl("lblID");
                    TextBox Meta = (TextBox)ri.FindControl("txtMeta");
                    if (String.IsNullOrEmpty(Meta.Text))
                        Meta.Text = "0";

                    intResultado = objCampaign.managerCampaignCanais(ID.Text, Convert.ToInt32(Meta.Text), Convert.ToInt32(ddlGrupos.SelectedValue));
                }

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração realizada com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração dos Canais !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração dos Canais !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                loadCampanha();
            }
            catch
            {

            }
        }

        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGrupos.SelectedValue != "0")
            {
                loadCampanha();
            }
        }
    }
}
