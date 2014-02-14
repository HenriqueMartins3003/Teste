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
    public partial class ResultadoOperacao : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        RO objRO = new RO();

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
                gridListaRO(ddlCampaign.SelectedValue.ToString());
                loadType();
                loadClassificacao();
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

        protected void loadType()
        {
            ddlTypeRO.DataSource = objRO.listTypeRO(ddlCampaign.SelectedValue.ToString(), objUsers);
            ddlTypeRO.DataTextField = "TipoRO";
            ddlTypeRO.DataValueField = "IDTipoRO";
            ddlTypeRO.DataBind();
            ddlTypeRO.Items.Insert(0, new ListItem("Selecione o Tipo...", "0"));
        }

        protected void loadClassificacao()
        {
            ddlClassificacao.DataSource = objRO.listClassificacaoRO(ddlCampaign.SelectedValue.ToString(), objUsers);
            ddlClassificacao.DataTextField = "DescClassificacaoRO";
            ddlClassificacao.DataValueField = "IDClassificacaoRO";
            ddlClassificacao.DataBind();
            ddlClassificacao.Items.Insert(0, new ListItem("Selecione a Classificação...", "0"));
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            divROContent.Visible = true;
            gridListaRO(ddlCampaign.SelectedValue.ToString());
            loadType();
            loadClassificacao();
        }

        protected void gridListaRO(String IDCampanha)
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
            IDRO.DataField = "IDRO";
            IDRO.HeaderText = "Codigo";
            IDRO.HeaderStyle.CssClass = "gridViewHeader1";
            IDRO.ItemStyle.CssClass = "gridViewValues3";
            IDRO.ItemStyle.Width = 50;
            IDRO.SortExpression = "IDRO";
            gdRegistros.Columns.Add(IDRO);

            BoundField DSCDescricao = new BoundField();
            DSCDescricao.DataField = "DESCRICAORO";
            DSCDescricao.HeaderText = "Descrição";
            DSCDescricao.HeaderStyle.CssClass = "gridViewHeader";
            DSCDescricao.ItemStyle.CssClass = "gridViewValues2";
            DSCDescricao.ItemStyle.Width = 400;
            DSCDescricao.SortExpression = "DESCRICAORO";
            gdRegistros.Columns.Add(DSCDescricao);

            BoundField DSCTipoRO = new BoundField();
            DSCTipoRO.DataField = "DESCRICACAOTIPO";
            DSCTipoRO.HeaderText = "Tipo";
            DSCTipoRO.HeaderStyle.CssClass = "gridViewHeader";
            DSCTipoRO.ItemStyle.CssClass = "gridViewValues2";
            DSCTipoRO.ItemStyle.Width = 100;
            DSCTipoRO.SortExpression = "DESCRICACAOTIPO";
            gdRegistros.Columns.Add(DSCTipoRO);

            BoundField DSCClassificacao = new BoundField();
            DSCClassificacao.DataField = "NOMECLASSIFICACAO";
            DSCClassificacao.HeaderText = "Classificação";
            DSCClassificacao.HeaderStyle.CssClass = "gridViewHeader";
            DSCClassificacao.ItemStyle.CssClass = "gridViewValues2";
            DSCClassificacao.ItemStyle.Width = 100;
            DSCClassificacao.SortExpression = "NOMECLASSIFICACAO";
            gdRegistros.Columns.Add(DSCClassificacao);

            BoundField DSCAtivo = new BoundField();
            DSCAtivo.DataField = "ATIVO";
            DSCAtivo.HeaderText = "Ativo";
            DSCAtivo.HeaderStyle.CssClass = "gridViewHeader1";
            DSCAtivo.ItemStyle.CssClass = "gridViewValues3";
            DSCAtivo.ItemStyle.Width = 50;
            DSCAtivo.SortExpression = "ATIVO";
            gdRegistros.Columns.Add(DSCAtivo);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            RO objRO = new RO();
            gdRegistros.DataSource = objRO.DatasetRO(IDCampanha, objUsers);
            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencaoRO.Visible = true;
                modExcluirRO.Visible = false;
                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração de Resultado da Operação";
                
                lblIDRO.Text = gdRegistros.DataKeys[index]["IDRO"].ToString();
                txtDescricao.Text = gdRegistros.DataKeys[index]["DESCRICAORO"].ToString();
                ddlTypeRO.SelectedValue = gdRegistros.DataKeys[index]["IDTIPO"].ToString();
                ddlClassificacao.SelectedValue = gdRegistros.DataKeys[index]["IDCLASSIFICACAO"].ToString();
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["ATIVO"].ToString() == "SIM" ? "True" : "False";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Resultado da Operação";
                modManutencaoRO.Visible = false;
                modExcluirRO.Visible = true;
                int index = int.Parse((string)e.CommandArgument);
                
                lblIDRO.Text = gdRegistros.DataKeys[index]["IDRO"].ToString();
                lblROExclusao.Text = gdRegistros.DataKeys[index]["DESCRICAORO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            RO objRO = new RO();
            DataSet dsRegistros = objRO.DatasetRO(ddlCampaign.SelectedValue.ToString(), objUsers);

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
            gridListaRO(ddlCampaign.SelectedValue.ToString());
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
            if (lblTituloDiv.Text == "Cadastrar novo Resultado da Operação")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Resultado da Operação")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Resultado da Operação")
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

                if (ddlTypeRO.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione o <b>Tipo de R.O.</b> !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlClassificacao.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione a <b>Classificação do R.O.</b> !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 1;
                objDtoRO.DescricaoRO = txtDescricao.Text;
                objDtoRO.IDTipoRO = Convert.ToInt16(ddlTypeRO.SelectedValue);
                objDtoRO.IDClassificacaoRO = Convert.ToInt16(ddlClassificacao.SelectedValue);
                objDtoRO.Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();

                Int64 intResultado = objRO.ManagerRO(objDtoRO, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo RO Cadastrado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo R.O. !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo R.O. !! </div>";
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

                if (ddlTypeRO.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione o <b>Tipo de R.O.</b> !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlClassificacao.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione a <b>Classificação do R.O.</b> !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 2;
                objDtoRO.IdRO = Convert.ToInt64(lblIDRO.Text);
                objDtoRO.DescricaoRO = txtDescricao.Text;
                objDtoRO.IDTipoRO = Convert.ToInt16(ddlTypeRO.SelectedValue);
                objDtoRO.IDClassificacaoRO = Convert.ToInt16(ddlClassificacao.SelectedValue);
                objDtoRO.Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();

                Int64 intResultado = objRO.ManagerRO(objDtoRO, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> R.O. Alterado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do R.O. !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do R.O. !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 3;
                objDtoRO.IdRO = Convert.ToInt64(lblIDRO.Text);
                objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();

                Int64 idExclusaoOperacao = objRO.ManagerRO(objDtoRO, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> R.O. Excluido com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir R.O. !! R.O. já utilizados pela operação não podem ser excluidos ! </div>";
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
                lblTituloDiv.Text = "Cadastrar novo Resultado da Operação";
                modManutencaoRO.Visible = true;
                modExcluirRO.Visible = false;
                txtDescricao.Text = "";
                ddlTypeRO.SelectedIndex = 0;
                ddlClassificacao.SelectedIndex = 0;
                ddlAtivo.SelectedValue = "False";
                gridListaRO(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}
