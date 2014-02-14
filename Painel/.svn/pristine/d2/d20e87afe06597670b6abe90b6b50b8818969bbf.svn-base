using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class SegmentacaoMailing : System.Web.UI.Page
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
                PageConfig();
                AccessMailing();
                
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/Default.aspx");
            }

            objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
        }

        private void PageConfig()
        {
            dtoPageConfig objdtoPageConfig = null;
            bllPageConfig objPageConfig = new bllPageConfig();

            String strApplication = Session["ObjApplication"].ToString();
            objdtoPageConfig = objPageConfig.listPageConfig(this.Form.ID, strApplication);

            lblTitulo.Text = objdtoPageConfig.Descricao;
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
                loadCampanhaCadastro();
                loadLoteCadastro();
                gridLista(ddlCampaign.SelectedValue.ToString());
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

        protected void loadCampanhaCadastro()
        {
            ddlCampanhaCadastro.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampanhaCadastro.DataTextField = "NomeCampanha";
            ddlCampanhaCadastro.DataValueField = "Campaign";
            ddlCampanhaCadastro.DataBind();
            ddlCampanhaCadastro.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void loadLoteCadastro()
        {
            dtoCampaign objAuxCampaign = new dtoCampaign();
            objAuxCampaign.Campaign = ddlCampaign.SelectedValue.ToString();

            ddlLoteCadastro.DataSource = objCampaign.listLot(objAuxCampaign);
            ddlLoteCadastro.DataTextField = "NomeLote";
            ddlLoteCadastro.DataValueField = "NumeroLote";
            ddlLoteCadastro.DataBind();
            ddlLoteCadastro.Items.Insert(0, new ListItem("Novo Lote (Importação)...", "99999"));
            ddlLoteCadastro.Items.Insert(0, new ListItem("Selecione o Lote...", "0"));
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCampanhaCadastro();
            loadLoteCadastro();

            if (gridLista(ddlCampaign.SelectedValue.ToString()))
            {
                divContent.Visible = true;
                divResponse.Visible = false;
            }
            else
            {
                divContent.Visible = false;
                lblResponse.Text = "<div class='RNOK'>Essa Base de Mailing não possui modulo de Segmentação !! </div>";
                divResponse.Visible = true;
                return;
            }
        }

        protected Boolean gridLista(String IDCampanha)
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

            ButtonField btnClear = new ButtonField();
            btnClear.ButtonType = ButtonType.Image;
            btnClear.ImageUrl = "../img/listar.gif";
            btnClear.CommandName = "Clr";
            btnClear.ItemStyle.Width = 25;
            btnClear.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnClear.HeaderText = "";
            btnClear.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnClear);

            BoundField ID = new BoundField();
            ID.DataField = "ID_SEGMENTACAO";
            ID.HeaderText = "ID";
            ID.HeaderStyle.CssClass = "gridViewHeader1";
            ID.ItemStyle.CssClass = "gridViewValues3";
            ID.ItemStyle.Width = 50;
            ID.SortExpression = "ID_SEGMENTACAO";
            gdRegistros.Columns.Add(ID);

            BoundField DSCDescricao = new BoundField();
            DSCDescricao.DataField = "NOME_SEGMENTACAO";
            DSCDescricao.HeaderText = "Descrição";
            DSCDescricao.HeaderStyle.CssClass = "gridViewHeader";
            DSCDescricao.ItemStyle.CssClass = "gridViewValues2";
            DSCDescricao.ItemStyle.Width = 400;
            DSCDescricao.SortExpression = "NOME_SEGMENTACAO";
            gdRegistros.Columns.Add(DSCDescricao);

            BoundField bfCampanha = new BoundField();
            bfCampanha.DataField = "NUMERO_CAMPANHA";
            bfCampanha.HeaderText = "Campanha";
            bfCampanha.HeaderStyle.CssClass = "gridViewHeader";
            bfCampanha.ItemStyle.CssClass = "gridViewValues3";
            bfCampanha.ItemStyle.Width = 50;
            bfCampanha.SortExpression = "NUMERO_CAMPANHA";
            gdRegistros.Columns.Add(bfCampanha);

            BoundField bfLote = new BoundField();
            bfLote.DataField = "NUMERO_LOTE";
            bfLote.HeaderText = "Lote";
            bfLote.HeaderStyle.CssClass = "gridViewHeader";
            bfLote.ItemStyle.CssClass = "gridViewValues3";
            bfLote.ItemStyle.Width = 50;
            bfLote.SortExpression = "NUMERO_LOTE";
            gdRegistros.Columns.Add(bfLote);

            BoundField bfPriority = new BoundField();
            bfPriority.DataField = "PRIORIDADE";
            bfPriority.HeaderText = "Prioridade";
            bfPriority.HeaderStyle.CssClass = "gridViewHeader";
            bfPriority.ItemStyle.CssClass = "gridViewValues3";
            bfPriority.ItemStyle.Width = 50;
            bfPriority.SortExpression = "PRIORIDADE";
            gdRegistros.Columns.Add(bfPriority);

            BoundField bfStatus = new BoundField();
            bfStatus.DataField = "FLAG_ATIVO";
            bfStatus.HeaderText = "Ativo ?";
            bfStatus.HeaderStyle.CssClass = "gridViewHeader";
            bfStatus.ItemStyle.CssClass = "gridViewValues3";
            bfStatus.ItemStyle.Width = 50;
            bfStatus.SortExpression = "FLAG_ATIVO";
            gdRegistros.Columns.Add(bfStatus);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.IDSegmentacao = "";

            DataSet dsQuery = objMailing.listSegmentacao(objAuxMailing, objUsers);
            if (dsQuery != null)
            {
                if (dsQuery.Tables[0].Rows.Count > 0)
                {
                    gdRegistros.DataSource = dsQuery;
                    gdRegistros.DataBind();
                }
                else
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'> Não existem Segmentações Cadastradas !! </div>";
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                modLimpar.Visible = false;
                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração de Segmentação";

                lblID.Text = gdRegistros.DataKeys[index]["ID_SEGMENTACAO"].ToString();
                txtDescricao.Text = gdRegistros.DataKeys[index]["NOME_SEGMENTACAO"].ToString();
                ddlCampanhaCadastro.SelectedValue = gdRegistros.DataKeys[index]["NUMERO_CAMPANHA"].ToString();
                ddlLoteCadastro.SelectedValue = gdRegistros.DataKeys[index]["NUMERO_LOTE"].ToString();
                ddlPrioridade.SelectedValue = gdRegistros.DataKeys[index]["PRIORIDADE"].ToString();
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["FLAG_ATIVO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Segmentação";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                modLimpar.Visible = false;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["ID_SEGMENTACAO"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["NOME_SEGMENTACAO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Clr")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Remover Segmentação";
                modManutencao.Visible = false;
                modExcluir.Visible = false;
                modLimpar.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["ID_SEGMENTACAO"].ToString();
                lblRemoverCampanha.Text = gdRegistros.DataKeys[index]["NUMERO_CAMPANHA"].ToString();
                lblRemoverLote.Text = gdRegistros.DataKeys[index]["NUMERO_LOTE"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.IDSegmentacao = "";

            DataSet dsRegistros = objMailing.listSegmentacao(objAuxMailing, objUsers);
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
            if (lblTituloDiv.Text == "Cadastrar nova Segmentação")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Segmentação")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Segmentação")
            {
                Exclusao();
            }
            else if (lblTituloDiv.Text == "Remover Segmentação")
            {
                Limpeza();
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

                if (ddlCampanhaCadastro.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>A <b>Campanha</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlLoteCadastro.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Lote</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.Task = 1;
                objAuxMailing.NomeSegmentacao = txtDescricao.Text;
                objAuxMailing.Campaign = ddlCampanhaCadastro.SelectedValue.ToString();
                objAuxMailing.Lot = ddlLoteCadastro.SelectedValue.ToString();
                objAuxMailing.Priority = Convert.ToInt64(ddlPrioridade.SelectedValue.ToString());
                objAuxMailing.Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                
                Int64 intResultado = objMailing.managerSegmentacao(objAuxMailing, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Segmentação Cadastrada com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Segmentação !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Segmentação !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtDescricao.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Descrição</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlCampanhaCadastro.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>A <b>Campanha</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlLoteCadastro.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Lote</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.Task = 2;
                objAuxMailing.IDSegmentacao = lblID.Text;
                objAuxMailing.NomeSegmentacao = txtDescricao.Text;
                objAuxMailing.Campaign = ddlCampanhaCadastro.SelectedValue.ToString();
                objAuxMailing.Lot = ddlLoteCadastro.SelectedValue.ToString();
                objAuxMailing.Priority = Convert.ToInt64(ddlPrioridade.SelectedValue.ToString());
                objAuxMailing.Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);

                Int64 intResultado = objMailing.managerSegmentacao(objAuxMailing, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Segmentação Alterada com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração da Segmentação !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração da Segmentação !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.Task = 3;
                objAuxMailing.IDSegmentacao = lblID.Text;
                objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();

                Int64 idExclusaoOperacao = objMailing.managerSegmentacao(objAuxMailing, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Segmentação Excluida com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Segmentação !! Segmentações em uso não podem ser excluidas ! </div>";
                    divResponse.Visible = true;
                }
            }
            catch
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Segmentação !! Segmentações em uso não podem ser excluidas ! </div>";
            }
        }

        protected void Limpeza()
        {
            try
            {
                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.Task = 4;
                objAuxMailing.IDSegmentacao = lblID.Text;
                objAuxMailing.Campaign = lblRemoverCampanha.Text;
                objAuxMailing.Lot = lblRemoverLote.Text;

                Int64 idExclusaoOperacao = objMailing.managerSegmentacao(objAuxMailing, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Segmentação Removida com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao Remover Segmentação !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro ao Remover Segmentação !! </div>";
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar nova Segmentação";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                modLimpar.Visible = false;
                txtDescricao.Text = "";
                ddlCampanhaCadastro.SelectedIndex = 0;
                ddlLoteCadastro.SelectedIndex = 0;
                ddlPrioridade.SelectedValue = "9";
                ddlAtivo.SelectedValue = "False";

                gridLista(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}
