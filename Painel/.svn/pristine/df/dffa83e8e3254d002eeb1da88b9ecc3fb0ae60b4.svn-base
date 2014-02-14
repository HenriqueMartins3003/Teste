using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.FrontEnd
{
    public partial class Produto_Affinity : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();

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
                divContent.Visible = false;
            }
            else
            {
                loadCampaign(false);
                divCampanhaContent.Visible = false;
                divContent.Visible = true;
                gridLista(ddlCampaign.SelectedValue.ToString());
                loadCampaignCadastro();
            }
        }

        protected void loadCampaign(Boolean bolVisible)
        {
            Campaigns objCampaign = new Campaigns();
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();

            if (bolVisible)
                ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void loadCampaignCadastro()
        {
            Campaigns objCampaign = new Campaigns();
            ddlCampanhaCadastro.DataSource = objCampaign.listCampaign();
            ddlCampanhaCadastro.DataTextField = "NomeCampanha";
            ddlCampanhaCadastro.DataValueField = "Campaign";
            ddlCampanhaCadastro.DataBind();
            ddlCampanhaCadastro.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            divContent.Visible = true;
            gridLista(ddlCampaign.SelectedValue.ToString());
            loadCampaignCadastro();
        }

        protected void gridLista(String IDCampanha)
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

            BoundField bfID = new BoundField();
            bfID.DataField = "IDPRODUTO";
            bfID.HeaderText = "ID";
            bfID.HeaderStyle.CssClass = "gridViewHeader1";
            bfID.ItemStyle.CssClass = "gridViewValues3";
            bfID.ItemStyle.Width = 50;
            bfID.SortExpression = "IDPRODUTO";
            gdRegistros.Columns.Add(bfID);

            BoundField bfDESCRICAOPRODUTO = new BoundField();
            bfDESCRICAOPRODUTO.DataField = "DESCRICAOPRODUTO";
            bfDESCRICAOPRODUTO.HeaderText = "Produto";
            bfDESCRICAOPRODUTO.HeaderStyle.CssClass = "gridViewHeader";
            bfDESCRICAOPRODUTO.ItemStyle.CssClass = "gridViewValues2";
            bfDESCRICAOPRODUTO.ItemStyle.Width = 200;
            bfDESCRICAOPRODUTO.SortExpression = "DESCRICAOPRODUTO";
            gdRegistros.Columns.Add(bfDESCRICAOPRODUTO);

            BoundField bfCAMPANHAMAILING = new BoundField();
            bfCAMPANHAMAILING.DataField = "CAMPANHAMAILING";
            bfCAMPANHAMAILING.HeaderText = "Campanha Mailing";
            bfCAMPANHAMAILING.HeaderStyle.CssClass = "gridViewHeader";
            bfCAMPANHAMAILING.ItemStyle.CssClass = "gridViewValues2";
            bfCAMPANHAMAILING.ItemStyle.Width = 100;
            bfCAMPANHAMAILING.SortExpression = "CAMPANHAMAILING";
            gdRegistros.Columns.Add(bfCAMPANHAMAILING);

            BoundField bfIDCAMPANHA = new BoundField();
            bfIDCAMPANHA.DataField = "IDCAMPANHA";
            bfIDCAMPANHA.HeaderText = "Campanha";
            bfIDCAMPANHA.HeaderStyle.CssClass = "gridViewHeader";
            bfIDCAMPANHA.ItemStyle.CssClass = "gridViewValues2";
            bfIDCAMPANHA.ItemStyle.Width = 100;
            bfIDCAMPANHA.SortExpression = "IDCAMPANHA";
            gdRegistros.Columns.Add(bfIDCAMPANHA);

            BoundField bfFlagAtivo = new BoundField();
            bfFlagAtivo.DataField = "FLAG_ATIVO";
            bfFlagAtivo.HeaderText = "Ativo";
            bfFlagAtivo.HeaderStyle.CssClass = "gridViewHeader";
            bfFlagAtivo.ItemStyle.CssClass = "gridViewValues2";
            bfFlagAtivo.ItemStyle.Width = 100;
            bfFlagAtivo.SortExpression = "FLAG_ATIVO";
            gdRegistros.Columns.Add(bfFlagAtivo);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsQuery = objFrontEnd.dslistProdutoAffinity(IDCampanha);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Tipos de Planos Cadastrados !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração de Tipo de Plano";

                lblID.Text = gdRegistros.DataKeys[index]["IDPRODUTO"].ToString();

                txtProduto.Text = gdRegistros.DataKeys[index]["DESCRICAOPRODUTO"].ToString();
                txtCampanhaMailing.Text = gdRegistros.DataKeys[index]["CAMPANHAMAILING"].ToString();
                ddlCampanhaCadastro.SelectedValue = gdRegistros.DataKeys[index]["IDCAMPANHA"].ToString();
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["FLAG_ATIVO"].ToString() == "Sim" ? "True" : "False";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Tipo de Plano";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["IDPRODUTO"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["DESCRICAOPRODUTO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsRegistros = objFrontEnd.dslistProdutoAffinity(ddlCampaign.SelectedValue.ToString());

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
            gridLista(ddlCampaign.SelectedValue.ToString());
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
            if (lblTituloDiv.Text == "Cadastrar novo Produto")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Produto")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Produto")
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
                if (txtProduto.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Produto</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlCampanhaCadastro.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Campanha</b> deve ser Selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoProduto objDto = new dtoProduto();
                objDto.Task = 1;
                objDto.DescricaoProduto = txtProduto.Text;
                objDto.CampanhaMailing = txtCampanhaMailing.Text;
                objDto.IDCampanha = ddlCampanhaCadastro.SelectedValue.ToString();
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerProdutoAffinity(objDto, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Produto Cadastrado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Produto !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Produto !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtProduto.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Produto</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlCampanhaCadastro.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Campanha</b> deve ser Selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoProduto objDto = new dtoProduto();
                objDto.Task = 2;
                objDto.IDProduto = Convert.ToInt64(lblID.Text);
                objDto.DescricaoProduto = txtProduto.Text;
                objDto.CampanhaMailing = txtCampanhaMailing.Text;
                objDto.IDCampanha = ddlCampanhaCadastro.SelectedValue.ToString();
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerProdutoAffinity(objDto, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Produto Alterado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Produto !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Produto !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoProduto objDto = new dtoProduto();
                objDto.Task = 3;
                objDto.IDProduto = Convert.ToInt64(lblID.Text);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 idExclusaoOperacao = objFrontEnd.ManagerProdutoAffinity(objDto, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Produto Excluido com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Produto !! Produto já utilizados pela operação não podem ser excluidos ! </div>";
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
                lblTituloDiv.Text = "Cadastrar novo Produto";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                
                txtProduto.Text = "";
                txtCampanhaMailing.Text = "";
                ddlCampanhaCadastro.SelectedValue = "0";
                
                ddlAtivo.SelectedValue = "False";
                gridLista(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}
