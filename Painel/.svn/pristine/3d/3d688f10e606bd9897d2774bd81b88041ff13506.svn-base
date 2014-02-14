using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.ResultadoOperacao
{
    public partial class ResultadoOperacaoTipo : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        RO objTipoRO = new RO();

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
                AccessMailing();
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

        private void AccessMailing()
        {
            List<dtoUsersProfiles> listProfile = objUsersProfiles.AccessMailing(objUsers);
            if (listProfile.Count > 1)
            {
                loadCampaign(true);
                divCampanhaContent.Visible = true;
                divROContent.Visible = false;
            }
            else
            {
                loadCampaign(false);
                divCampanhaContent.Visible = false;
                divROContent.Visible = true;
                gridListaTipoRO(ddlCampaign.SelectedValue.ToString());
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

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            divROContent.Visible = true;
            gridListaTipoRO(ddlCampaign.SelectedValue.ToString());
        }

        protected void gridListaTipoRO(String IDCampanha)
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
            btnDelete.ItemStyle.Width = 25;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnDelete);

            BoundField IDRO = new BoundField();
            IDRO.DataField = "ID_TIPO_RO";
            IDRO.HeaderText = "Codigo";
            IDRO.HeaderStyle.CssClass = "gridViewHeader1";
            IDRO.ItemStyle.CssClass = "gridViewValues3";
            IDRO.ItemStyle.Width = 50;
            IDRO.SortExpression = "ID_TIPO_RO";
            gdRegistros.Columns.Add(IDRO);

            BoundField DSCDescricao = new BoundField();
            DSCDescricao.DataField = "DESCRICAO";
            DSCDescricao.HeaderText = "Descrição";
            DSCDescricao.HeaderStyle.CssClass = "gridViewHeader";
            DSCDescricao.ItemStyle.CssClass = "gridViewValues2";
            DSCDescricao.ItemStyle.Width = 400;
            DSCDescricao.SortExpression = "DESCRICAO";
            gdRegistros.Columns.Add(DSCDescricao);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            RO objTipoRO = new RO();
            gdRegistros.DataSource = objTipoRO.DatasetROType(IDCampanha, objUsers);
            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencaoTipoRO.Visible = true;
                modExcluirTipoRO.Visible = false;
                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração de Tipo de Resultado da Operação";

                lblIDTipoRO.Text = gdRegistros.DataKeys[index]["ID_TIPO_RO"].ToString();
                txtDescricao.Text = gdRegistros.DataKeys[index]["DESCRICAO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Tipo de Resultado da Operação";
                modManutencaoTipoRO.Visible = false;
                modExcluirTipoRO.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblIDTipoRO.Text = gdRegistros.DataKeys[index]["ID_TIPO_RO"].ToString();
                lblTipoROExclusao.Text = gdRegistros.DataKeys[index]["DESCRICAO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            RO objRO = new RO();
            DataSet dsRegistros = objRO.DatasetROType(ddlCampaign.SelectedValue.ToString(), objUsers);

            DataTable dtRegistros = (DataTable)dsRegistros.Tables[0];
            String _coluna = e.SortExpression;

            if (_coluna.Equals(Session["ULTIMOSORT"]))
                _coluna = _coluna + " desc";

            Session.Add("ULTIMOSORT", _coluna);
            dtRegistros.DefaultView.Sort = _coluna;

            gdRegistros.DataSource = dtRegistros;
            gdRegistros.DataBind();
        }

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gridListaTipoRO(ddlCampaign.SelectedValue.ToString());
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
            if (lblTituloDiv.Text == "Cadastrar novo Tipo de Resultado da Operação")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Tipo de Resultado da Operação")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Tipo de Resultado da Operação")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Cadastro()
        {
            try
            {
                if (txtDescricao.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Descrição</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 1;
                objDtoRO.TipoRO = txtDescricao.Text;
                objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();

                Int64 intResultado = objTipoRO.ManagerROType(objDtoRO, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Tipo de R.O. Cadastrado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Tipo de R.O. !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Tipo de R.O. !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                if (txtDescricao.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Descrição</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 2;
                objDtoRO.IDTipoRO = Convert.ToInt64(lblIDTipoRO.Text);
                objDtoRO.TipoRO = txtDescricao.Text;
                objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();

                Int64 intResultado = objTipoRO.ManagerROType(objDtoRO, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Tipo de R.O. Alterado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Tipo de R.O. !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Tipo de R.O. !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 3;
                objDtoRO.IDTipoRO = Convert.ToInt64(lblIDTipoRO.Text);
                objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();

                Int64 idExclusaoOperacao = objTipoRO.ManagerROType(objDtoRO, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Tipo de R.O. Excluido com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Tipo de R.O. !! Tipo de R.O. em uso não podem ser excluidos ! </div>";
                    divResponse.Visible = true;
                }
            }
            catch
            {

            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo Tipo de Resultado da Operação";
                modManutencaoTipoRO.Visible = true;
                modExcluirTipoRO.Visible = false;
                txtDescricao.Text = "";
                gridListaTipoRO(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}
