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
    public partial class TipoCartao_Affinity : System.Web.UI.Page
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

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            divContent.Visible = true;
            gridLista(ddlCampaign.SelectedValue.ToString());
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
            bfID.DataField = "CODIGO";
            bfID.HeaderText = "Codigo";
            bfID.HeaderStyle.CssClass = "gridViewHeader1";
            bfID.ItemStyle.CssClass = "gridViewValues3";
            bfID.ItemStyle.Width = 50;
            bfID.SortExpression = "CODIGO";
            gdRegistros.Columns.Add(bfID);

            BoundField bfTipoPlano = new BoundField();
            bfTipoPlano.DataField = "TIPOCARTAO";
            bfTipoPlano.HeaderText = "Tipo Cartão";
            bfTipoPlano.HeaderStyle.CssClass = "gridViewHeader";
            bfTipoPlano.ItemStyle.CssClass = "gridViewValues2";
            bfTipoPlano.ItemStyle.Width = 200;
            bfTipoPlano.SortExpression = "TIPOCARTAO";
            gdRegistros.Columns.Add(bfTipoPlano);

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
            DataSet dsQuery = objFrontEnd.dslistTipoCartaoAffinity(IDCampanha);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Tipos de Cartao Cadastrados !! </div>";
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
                lblTituloDiv.Text = "Alteração de Tipo de Cartao";

                lblID.Text = gdRegistros.DataKeys[index]["CODIGO"].ToString();

                txtCodigo.Text = gdRegistros.DataKeys[index]["CODIGO"].ToString();
                txtTipoCartao.Text = gdRegistros.DataKeys[index]["TIPOCARTAO"].ToString();
                
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["FLAG_ATIVO"].ToString() == "Sim" ? "True" : "False";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Tipo de Cartao";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["CODIGO"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["TIPOCARTAO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsRegistros = objFrontEnd.dslistTipoCartaoAffinity(ddlCampaign.SelectedValue.ToString());

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
            if (lblTituloDiv.Text == "Cadastrar novo Tipo de Cartao")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Tipo de Cartao")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Tipo de Cartao")
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
                if (txtCodigo.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Codigo</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtTipoCartao.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo Cartão</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoTipoCartao objDto = new dtoTipoCartao();
                objDto.Task = 1;
                objDto.Codigo = txtCodigo.Text;
                objDto.TipoCartao = txtTipoCartao.Text;
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerTipoCartaoAffinity(objDto, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Tipo de Cartao Cadastrado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Tipo de Cartao !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Tipo de Cartao !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtCodigo.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Codigo</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtTipoCartao.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo Cartão</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoTipoCartao objDto = new dtoTipoCartao();
                objDto.Task = 2;
                objDto.Codigo = txtCodigo.Text;
                objDto.TipoCartao = txtTipoCartao.Text;
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerTipoCartaoAffinity(objDto, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Tipo de Cartao Alterado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Tipo de Cartao !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Tipo de Cartao !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoTipoCartao objDto = new dtoTipoCartao();
                objDto.Task = 3;
                objDto.Codigo = lblID.Text;
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 idExclusaoOperacao = objFrontEnd.ManagerTipoCartaoAffinity(objDto, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Tipo de Cartao Excluido com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Tipo de Cartao !! Tipo de Cartao já utilizados pela operação não podem ser excluidos ! </div>";
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
                lblTituloDiv.Text = "Cadastrar novo Tipo de Cartao";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                
                txtCodigo.Text = "";
                txtTipoCartao.Text = "";
                
                ddlAtivo.SelectedValue = "False";
                gridLista(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}
