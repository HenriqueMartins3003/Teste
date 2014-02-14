using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class SegmentacaoRegra : System.Web.UI.Page
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
                divSegmentacaoContent.Visible = false;
            }
            else
            {
                loadCampaign(false);
                divCampanhaContent.Visible = false;
                divContent.Visible = false;
                loadSegmentacoes();
                loadSegmentacaoTabela();
                divSegmentacaoContent.Visible = true;
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

        protected Boolean loadSegmentacoes()
        {
            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.IDSegmentacao = "";

            DataSet dsQuery = objMailing.listSegmentacao(objAuxMailing, objUsers);
            if (dsQuery != null)
            {
                ddlSegmentacao.DataSource = dsQuery.Tables[0];
                ddlSegmentacao.DataTextField = "NOME_SEGMENTACAO";
                ddlSegmentacao.DataValueField = "ID_SEGMENTACAO";
                ddlSegmentacao.DataBind();
                ddlSegmentacao.Items.Insert(0, new ListItem("Selecione a Segmentação...", "0"));

                return true;
            }
            else
            {
                return false;
            }
        }

        public void loadSegmentacaoCampo(String strTabela)
        {
            if (strTabela != String.Empty)
                ddlCampo.DataSource = objMailing.listSegmentacaoCampo(ddlCampaign.SelectedValue.ToString(), ddlTabela.SelectedValue.ToString());
            else
                ddlCampo.DataSource = objMailing.listSegmentacaoCampo(ddlCampaign.SelectedValue.ToString(), "");

            ddlCampo.DataTextField = "SegmentacaoCampo";
            ddlCampo.DataValueField = "SegmentacaoCampo";
            ddlCampo.DataBind();
            ddlCampo.Items.Insert(0, new ListItem("Selecione o Campo...", "0"));

        }

        public void loadSegmentacaoTabela()
        {
            ddlTabela.DataSource = objMailing.listSegmentacaoTabela(ddlCampaign.SelectedValue.ToString());
            ddlTabela.DataTextField = "SegmentacaoTabela";
            ddlTabela.DataValueField = "SegmentacaoTabela";
            ddlTabela.DataBind();
            ddlTabela.Items.Insert(0, new ListItem("Selecione a Tabela...", "0"));
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            //divContent.Visible = true;

            if (loadSegmentacoes())
            {
                divSegmentacaoContent.Visible = true;
                divResponse.Visible = false;
                loadSegmentacaoTabela();
                gridLista(ddlCampaign.SelectedValue.ToString(), ddlSegmentacao.SelectedValue.ToString());
            }
            else
            {
                divContent.Visible = false;
                divSegmentacaoContent.Visible = false;
                lblResponse.Text = "<div class='RNOK'>Essa Base de Mailing não possui modulo de Segmentação !! </div>";
                divResponse.Visible = true;
                return;
            }
        }

        protected void ddlSegmentacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            modManutencao.Visible = true;
            modExcluir.Visible = false;
            divContent.Visible = true;
            gridLista(ddlCampaign.SelectedValue.ToString(), ddlSegmentacao.SelectedValue.ToString());
        }

        protected void ddlTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSegmentacaoCampo(ddlTabela.SelectedValue.ToString());
        }

        protected void gridLista(String IDCampanha, String IDSegmentacao)
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

            BoundField ID = new BoundField();
            ID.DataField = "ID_SEGMENTACAOREGRA";
            ID.HeaderText = "ID";
            ID.HeaderStyle.CssClass = "gridViewHeader1";
            ID.ItemStyle.CssClass = "gridViewValues3";
            ID.ItemStyle.Width = 50;
            ID.Visible = false;
            ID.SortExpression = "ID_SEGMENTACAOREGRA";
            gdRegistros.Columns.Add(ID);

            BoundField bfConjuncao = new BoundField();
            bfConjuncao.DataField = "CONJUNCAO";
            bfConjuncao.HeaderText = "Conjunção";
            bfConjuncao.HeaderStyle.CssClass = "gridViewHeader";
            bfConjuncao.ItemStyle.CssClass = "gridViewValues3";
            bfConjuncao.ItemStyle.Width = 50;
            bfConjuncao.SortExpression = "CONJUNCAO";
            gdRegistros.Columns.Add(bfConjuncao);

            BoundField bfAbreParenteses = new BoundField();
            bfAbreParenteses.DataField = "ABRE_PARENTESES";
            bfAbreParenteses.HeaderText = "";
            bfAbreParenteses.HeaderStyle.CssClass = "gridViewHeader";
            bfAbreParenteses.ItemStyle.CssClass = "gridViewValues3";
            bfAbreParenteses.ItemStyle.Width = 50;
            bfAbreParenteses.SortExpression = "ABRE_PARENTESES";
            gdRegistros.Columns.Add(bfAbreParenteses);

            BoundField bfCampo = new BoundField();
            bfCampo.DataField = "CAMPO_SEGMENTACAO";
            bfCampo.HeaderText = "Campo";
            bfCampo.HeaderStyle.CssClass = "gridViewHeader";
            bfCampo.ItemStyle.CssClass = "gridViewValues2";
            bfCampo.ItemStyle.Width = 100;
            bfCampo.SortExpression = "CAMPO_SEGMENTACAO";
            gdRegistros.Columns.Add(bfCampo);

            BoundField bfRegra = new BoundField();
            bfRegra.DataField = "REGRA_SEGMENTACAO";
            bfRegra.HeaderText = "Operador";
            bfRegra.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegra.ItemStyle.CssClass = "gridViewValues3";
            bfRegra.ItemStyle.Width = 100;
            bfRegra.SortExpression = "REGRA_SEGMENTACAO";
            gdRegistros.Columns.Add(bfRegra);

            BoundField bfValor = new BoundField();
            bfValor.DataField = "VALOR_SEGMENTACAO";
            bfValor.HeaderText = "Valor";
            bfValor.HeaderStyle.CssClass = "gridViewHeader";
            bfValor.ItemStyle.CssClass = "gridViewValues2";
            bfValor.ItemStyle.Width = 300;
            bfValor.SortExpression = "VALOR_SEGMENTACAO";
            gdRegistros.Columns.Add(bfValor);

            BoundField bfFechaParenteses = new BoundField();
            bfFechaParenteses.DataField = "FECHA_PARENTESES";
            bfFechaParenteses.HeaderText = "";
            bfFechaParenteses.HeaderStyle.CssClass = "gridViewHeader";
            bfFechaParenteses.ItemStyle.CssClass = "gridViewValues3";
            bfFechaParenteses.ItemStyle.Width = 50;
            bfFechaParenteses.SortExpression = "FECHA_PARENTESES";
            gdRegistros.Columns.Add(bfFechaParenteses);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = IDCampanha;
            objAuxMailing.IDSegmentacao = IDSegmentacao;

            DataSet dsQuery = objMailing.listSegmentacaoRegras(objAuxMailing, objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Regras Cadastradas para essa Segmentação !! </div>";
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
                loadSegmentacaoCampo("");

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração de Regra Segmentação";

                lblID.Text = gdRegistros.DataKeys[index]["ID_SEGMENTACAOREGRA"].ToString();

                ddlTabela.SelectedValue = gdRegistros.DataKeys[index]["TABELA_SEGMENTACAO"].ToString();
                ddlCampo.SelectedValue = gdRegistros.DataKeys[index]["CAMPO_SEGMENTACAO"].ToString(); ;
                ddlOperador.Text = gdRegistros.DataKeys[index]["REGRA_SEGMENTACAO"].ToString();
                txtValor.Text = gdRegistros.DataKeys[index]["VALOR_SEGMENTACAO"].ToString();

                ddlParentesesAbre.SelectedValue = gdRegistros.DataKeys[index]["ABRE_PARENTESES"].ToString() == "" ? "Sem" : "Com";
                ddlParentesesFecha.SelectedValue = gdRegistros.DataKeys[index]["FECHA_PARENTESES"].ToString() == "" ? "Sem" : "Com";
                ddlConjuncao.Text = gdRegistros.DataKeys[index]["CONJUNCAO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Regra Segmentação";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["ID_SEGMENTACAOREGRA"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["CAMPO_SEGMENTACAO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        //protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    dtoMailing objAuxMailing = new dtoMailing();
        //    objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
        //    objAuxMailing.IDSegmentacao = ddlSegmentacao.SelectedValue.ToString();

        //    DataSet dsRegistros = objMailing.listSegmentacaoRegras(objAuxMailing, objUsers);
        //    if (dsRegistros.Tables[0].Rows.Count > 0)
        //    {
        //        DataTable dtRegistros = (DataTable)dsRegistros.Tables[0];
        //        String _coluna = e.SortExpression;

        //        if (_coluna.Equals(Session["ULTIMOSORT"]))
        //            _coluna = _coluna + " desc";

        //        Session.Add("ULTIMOSORT", _coluna);
        //        dtRegistros.DefaultView.Sort = _coluna;

        //        gdRegistros.DataSource = dtRegistros;
        //        gdRegistros.DataBind();
        //    }
        //}

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gridLista(ddlCampaign.SelectedValue.ToString(), ddlSegmentacao.SelectedValue.ToString());
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
            if (lblTituloDiv.Text == "Cadastrar nova Regra Segmentação")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Regra Segmentação")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Regra Segmentação")
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
                if (ddlTabela.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>A <b>Tabela</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlCampo.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Campo</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlOperador.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Operador</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtValor.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Valor</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.Task = 1;
                objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
                objAuxMailing.IDSegmentacao = ddlSegmentacao.SelectedValue.ToString();
                objAuxMailing.SegmentacaoTabela = ddlTabela.SelectedValue.ToString();
                objAuxMailing.SegmentacaoCampo = ddlCampo.SelectedValue.ToString();
                objAuxMailing.SegmentacaoRegra = ddlOperador.SelectedValue.ToString();
                objAuxMailing.SegmentacaoValor = txtValor.Text;
                objAuxMailing.SegmentacaoAbreParenteses = ddlParentesesAbre.SelectedValue.ToString() == "Com" ? "(" : "";
                objAuxMailing.SegmentacaoFechaParenteses = ddlParentesesFecha.SelectedValue.ToString() == "Com" ? ")" : ""; ;
                objAuxMailing.Conjuncao = ddlConjuncao.SelectedValue.ToString();

                Int64 intResultado = objMailing.managerSegmentacaoRegra(objAuxMailing, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Regra Segmentação Cadastrada com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Regra Segmentação !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Regra Segmentação !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (ddlTabela.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>A <b>Tabela</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlCampo.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Campo</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlOperador.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Operador</b> deve ser selecionada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtValor.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Valor</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.Task = 2;
                objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
                objAuxMailing.IDSegmentacaoRegra = Convert.ToInt64(lblID.Text);
                objAuxMailing.SegmentacaoTabela = ddlTabela.SelectedValue.ToString();
                objAuxMailing.SegmentacaoCampo = ddlCampo.SelectedValue.ToString();
                objAuxMailing.SegmentacaoRegra = ddlOperador.SelectedValue.ToString();
                objAuxMailing.SegmentacaoValor = txtValor.Text;
                objAuxMailing.SegmentacaoAbreParenteses = ddlParentesesAbre.SelectedValue.ToString() == "Com" ? "(" : "";
                objAuxMailing.SegmentacaoFechaParenteses = ddlParentesesFecha.SelectedValue.ToString() == "Com" ? ")" : ""; ;
                objAuxMailing.Conjuncao = ddlConjuncao.SelectedValue.ToString();

                Int64 intResultado = objMailing.managerSegmentacaoRegra(objAuxMailing, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Regra Segmentação Alterada com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração da Regra Segmentação !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração da Regra Segmentação !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoMailing objAuxMailing = new dtoMailing();
                objAuxMailing.Task = 3;
                objAuxMailing.IDSegmentacaoRegra = Convert.ToInt64(lblID.Text);
                objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();

                Int64 idExclusaoOperacao = objMailing.managerSegmentacaoRegra(objAuxMailing, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Regra Segmentação Excluida com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Regra Segmentação !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Regra Segmentação !! </div>";
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar nova Regra Segmentação";
                divContent.Visible = true;
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                gridLista(ddlCampaign.SelectedValue.ToString(), ddlSegmentacao.SelectedValue.ToString());

                //ddlSegmentacao.SelectedIndex = 0;
                ddlTabela.SelectedIndex = 0;
                ddlCampo.SelectedIndex = 0;
                ddlOperador.SelectedIndex = 0;
                txtValor.Text = "";
            }
            catch
            {

            }
        }
    }
}
