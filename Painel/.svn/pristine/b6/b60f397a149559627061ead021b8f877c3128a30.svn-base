using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.BLL.Fidelity;
using _webPainelVerisys.DTO;
//using _webPainelVerisys.DTO.Fidelity;

namespace _webPainelVerisys.Exclusive.Fidelity
{
    public partial class AuthorizationCode : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Telecom objTelecom = new Telecom();

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
                gridListaAuthorizationCode();
                CarregaCore();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/DashBoard.aspx");
            }

            objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
        }

        private void PageConfig()
        {

        }

        protected void gridListaAuthorizationCode()
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

            ButtonField btnDelete = new ButtonField();
            btnDelete.ButtonType = ButtonType.Image;
            btnDelete.ImageUrl = "../img/delete.gif";
            btnDelete.CommandName = "Del";
            btnDelete.ItemStyle.Width = 50;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnDelete);

            BoundField IDAuthorizationCode = new BoundField();
            IDAuthorizationCode.DataField = "ID_AUTHORIZATIONCODE";
            IDAuthorizationCode.HeaderText = "ID";
            IDAuthorizationCode.HeaderStyle.CssClass = "gridViewHeader1";
            IDAuthorizationCode.ItemStyle.CssClass = "gridViewValues3";
            IDAuthorizationCode.ItemStyle.Width = 50;
            gdRegistros.Columns.Add(IDAuthorizationCode);

            BoundField DSCAuthCode = new BoundField();
            DSCAuthCode.DataField = "AUTHCODE";
            DSCAuthCode.HeaderText = "AUTHORIZATION CODE";
            DSCAuthCode.HeaderStyle.CssClass = "gridViewHeader";
            DSCAuthCode.ItemStyle.CssClass = "gridViewValues2";
            DSCAuthCode.ItemStyle.Width = 300;
            DSCAuthCode.SortExpression = "AUTHCODE";
            gdRegistros.Columns.Add(DSCAuthCode);

            BoundField DSCPermissoesRamais = new BoundField();
            DSCPermissoesRamais.DataField = "DESCRITIVO";
            DSCPermissoesRamais.HeaderText = "Core Acessso";
            DSCPermissoesRamais.HeaderStyle.CssClass = "gridViewHeader";
            DSCPermissoesRamais.ItemStyle.CssClass = "gridViewValues2";
            DSCPermissoesRamais.ItemStyle.Width = 200;
            DSCPermissoesRamais.SortExpression = "DESCRITIVO";
            gdRegistros.Columns.Add(DSCPermissoesRamais);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objTelecom.listAuthCode();
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Authorization Codes Cadastrados !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void CarregaCore()
        {
            ddlCore.DataSource = objTelecom.listCore();
            ddlCore.DataTextField = "DescritivoCore";
            ddlCore.DataValueField = "NumeroCore";
            ddlCore.DataBind();
            ddlCore.Items.Insert(0, new ListItem("Selecione o Core...", "0"));
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencaoAuthorizationCode.Visible = true;
                modExcluirAuthorizationCode.Visible = false;
                
                int index = int.Parse((string)e.CommandArgument);

                lblTituloDiv.Text = "Alteração de Authorization Code";
                lblIDAuthorizationCode.Text = gdRegistros.DataKeys[index]["ID_AUTHORIZATIONCODE"].ToString();
                txtAuthorizationCode.Text = gdRegistros.DataKeys[index]["AUTHCODE"].ToString();
                txtAuthorizationCode.Enabled = false;
                ddlCore.SelectedValue = gdRegistros.DataKeys[index]["CORE"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Authorization Code";
                modManutencaoAuthorizationCode.Visible = false;
                modExcluirAuthorizationCode.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblIDAuthorizationCode.Text = gdRegistros.DataKeys[index]["ID_AUTHORIZATIONCODE"].ToString();
                lblAuthorizationCodeExclusao.Text = gdRegistros.DataKeys[index]["AUTHCODE"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objTelecom.listAuthCode();
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
            if (lblTituloDiv.Text == "Cadastrar novo Authorization Code")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Authorization Code")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Authorization Code")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (txtAuthorizationCode.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Authorization Code</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlCore.SelectedIndex == 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>Selecione o <b>Core</b> !! </div>";
                    return;
                }

                dtoTelecom objAuxAuthorizationCode = new dtoTelecom();
                objAuxAuthorizationCode.Task = 1;
                objAuxAuthorizationCode.AuthCode = txtAuthorizationCode.Text;
                objAuxAuthorizationCode.NumeroCore = ddlCore.SelectedValue.ToString();

                Int64 intResultado = objTelecom.ManagerAuthorizationCode(objAuxAuthorizationCode, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Authorization Code Cadastrado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Authorization Code !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Authorization Code !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtAuthorizationCode.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Authorization Code</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlCore.SelectedIndex == 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>Selecione o <b>Core</b> !! </div>";
                    return;
                }

                dtoTelecom objAuxAuthorizationCode = new dtoTelecom();
                objAuxAuthorizationCode.Task = 2;
                objAuxAuthorizationCode.IDAuthCode = Convert.ToInt64(lblIDAuthorizationCode.Text);
                objAuxAuthorizationCode.NumeroCore = ddlCore.SelectedValue.ToString();

                Int64 intResultado = objTelecom.ManagerAuthorizationCode(objAuxAuthorizationCode, objUsers);
                if (intResultado > 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='ROK'> Authorization Code Alterado com sucesso !! </div>";
                }
                else
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Authorization Code !! </div>";
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Authorization Code !! </div>";
            }
        }

        protected void Exclusao()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                dtoTelecom objAuxAuthorizationCode = new dtoTelecom();
                objAuxAuthorizationCode.Task = 3;
                objAuxAuthorizationCode.IDAuthCode = Convert.ToInt64(lblIDAuthorizationCode.Text);

                Int64 intResultado = objTelecom.ManagerAuthorizationCode(objAuxAuthorizationCode, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Authorization Code excluido com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Authorization Code !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Authorization Code !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo Authorization Code";
                modManutencaoAuthorizationCode.Visible = true;
                modExcluirAuthorizationCode.Visible = false;
                txtAuthorizationCode.Text = "";
                txtAuthorizationCode.Enabled = true;
                ddlCore.SelectedIndex = 0;
                gridListaAuthorizationCode();
            }
            catch
            {

            }
        }

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gridListaAuthorizationCode();
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
