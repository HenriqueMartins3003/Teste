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
    public partial class GruposDacParametros : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        GruposDac objGruposDac = new GruposDac();

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
                loadGruposDac();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/DashBoard.aspx");
            }
        }

        protected void loadGruposDac()
        {
            ddlGruposDac.DataSource = objGruposDac.listGruposDac(objUsers);
            ddlGruposDac.DataTextField = "NomeGrupoDac";
            ddlGruposDac.DataValueField = "GrupoDac";
            ddlGruposDac.DataBind();
            ddlGruposDac.Items.Insert(0, new ListItem("Selecione o Grupo Dac...", "0"));
        }

        protected void ddlGruposDac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGruposDac.SelectedIndex > 0)
            {
                dtoGruposDac objAuxGrupoDac = new dtoGruposDac();
                objAuxGrupoDac.GrupoDac = ddlGruposDac.SelectedValue.ToString();

                SqlDataReader iDrGruposDac = objGruposDac.listGruposDacDetails(objAuxGrupoDac);

                if (iDrGruposDac.Read())
                {
                    txtTempoClerical.Text = iDrGruposDac["TEMPOCLERICAL"].ToString();
                }

                modGruposDacParametro.Visible = true;
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));

                divResponse.Visible = false;
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
                if (txtTempoClerical.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='NOK'> Campo Tempo de Clerical deve ser definido !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoGruposDac objDtoGruposDac = new dtoGruposDac();
                objDtoGruposDac.Task = 2;
                objDtoGruposDac.User = objUsers.User;
                objDtoGruposDac.GrupoDac = ddlGruposDac.SelectedValue.ToString();
                objDtoGruposDac.TempoClerical = txtTempoClerical.Text;

                Int64 intResultado = objGruposDac.managerGruposDac(objDtoGruposDac);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração de Parametros de Grupo Dac realizado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Parametros de Grupo Dac !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Parametros de Grupo Dac !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                modGruposDacParametro.Visible = false;
                loadGruposDac();
            }
            catch
            {

            }
        }
    }
}
