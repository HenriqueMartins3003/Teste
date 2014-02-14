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
    public partial class Plano_Affinity : System.Web.UI.Page
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
                loadProduto(ddlCampaign.SelectedValue.ToString());
                loadTipoPlano(ddlCampaign.SelectedValue.ToString());
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

        protected void loadProduto(String IDCampanha)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            ddlProduto.DataSource = objFrontEnd.listProdutoAffinity(IDCampanha);
            ddlProduto.DataTextField = "DescricaoProduto";
            ddlProduto.DataValueField = "IDProduto";
            ddlProduto.DataBind();
        }

        protected void loadTipoPlano(String IDCampanha)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            ddlTipoPlano.DataSource = objFrontEnd.listTipoPlanoAffinity(IDCampanha);
            ddlTipoPlano.DataTextField = "TipoPlano";
            ddlTipoPlano.DataValueField = "IDTipoPlano";
            ddlTipoPlano.DataBind();
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            divContent.Visible = true;
            gridLista(ddlCampaign.SelectedValue.ToString());
            loadProduto(ddlCampaign.SelectedValue.ToString());
            loadTipoPlano(ddlCampaign.SelectedValue.ToString());
        }

        protected void gridLista(String IDCampanha)
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            ButtonField btnUpdate = new ButtonField();
            btnUpdate.ButtonType = ButtonType.Image;
            btnUpdate.ImageUrl = "../img/edit.gif";
            btnUpdate.CommandName = "Upd";
            btnUpdate.ItemStyle.Width = 20;
            btnUpdate.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnUpdate.HeaderText = "";
            btnUpdate.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnUpdate);

            ButtonField btnDelete = new ButtonField();
            btnDelete.ButtonType = ButtonType.Image;
            btnDelete.ImageUrl = "../img/delete.gif";
            btnDelete.CommandName = "Del";
            btnDelete.ItemStyle.Width = 20;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnDelete);

            BoundField bfID = new BoundField();
            bfID.DataField = "IDPLANO";
            bfID.HeaderText = "ID";
            bfID.HeaderStyle.CssClass = "gridViewHeader1";
            bfID.ItemStyle.CssClass = "gridViewValues3";
            bfID.ItemStyle.Width = 25;
            bfID.SortExpression = "IDPLANO";
            bfID.Visible = false;
            gdRegistros.Columns.Add(bfID);

            BoundField bfIDPRODUTO = new BoundField();
            bfIDPRODUTO.DataField = "IDPRODUTO";
            bfIDPRODUTO.HeaderText = "IDProduto";
            bfIDPRODUTO.HeaderStyle.CssClass = "gridViewHeader1";
            bfIDPRODUTO.ItemStyle.CssClass = "gridViewValues3";
            bfIDPRODUTO.ItemStyle.Width = 25;
            bfIDPRODUTO.SortExpression = "IDPRODUTO";
            bfIDPRODUTO.Visible = false;
            gdRegistros.Columns.Add(bfIDPRODUTO);

            BoundField bfDESCRICAOPRODUTO = new BoundField();
            bfDESCRICAOPRODUTO.DataField = "DESCRICAOPRODUTO";
            bfDESCRICAOPRODUTO.HeaderText = "Produto";
            bfDESCRICAOPRODUTO.HeaderStyle.CssClass = "gridViewHeader1";
            bfDESCRICAOPRODUTO.ItemStyle.CssClass = "gridViewValues3";
            bfDESCRICAOPRODUTO.ItemStyle.Width = 120;
            bfDESCRICAOPRODUTO.SortExpression = "DESCRICAOPRODUTO";
            bfDESCRICAOPRODUTO.Visible = true;
            gdRegistros.Columns.Add(bfDESCRICAOPRODUTO);

            BoundField bfCODIGOPLANO = new BoundField();
            bfCODIGOPLANO.DataField = "CODIGOPLANO";
            bfCODIGOPLANO.HeaderText = "Codigo Plano";
            bfCODIGOPLANO.HeaderStyle.CssClass = "gridViewHeader1";
            bfCODIGOPLANO.ItemStyle.CssClass = "gridViewValues3";
            bfCODIGOPLANO.ItemStyle.Width = 25;
            bfCODIGOPLANO.SortExpression = "CODIGOPLANO";
            bfCODIGOPLANO.Visible = true;
            gdRegistros.Columns.Add(bfCODIGOPLANO);

            BoundField bfXIMPORTANCIASEGURADA = new BoundField();
            bfXIMPORTANCIASEGURADA.DataField = "XIMPORTANCIASEGURADA";
            bfXIMPORTANCIASEGURADA.HeaderText = "XSegurado";
            bfXIMPORTANCIASEGURADA.HeaderStyle.CssClass = "gridViewHeader1";
            bfXIMPORTANCIASEGURADA.ItemStyle.CssClass = "gridViewValues3";
            bfXIMPORTANCIASEGURADA.ItemStyle.Width = 30;
            bfXIMPORTANCIASEGURADA.SortExpression = "XIMPORTANCIASEGURADA";
            bfXIMPORTANCIASEGURADA.Visible = false;
            gdRegistros.Columns.Add(bfXIMPORTANCIASEGURADA);

            BoundField bfIMPORTANCIASEGURADA = new BoundField();
            bfIMPORTANCIASEGURADA.DataField = "IMPORTANCIASEGURADA";
            bfIMPORTANCIASEGURADA.HeaderText = "Segurado";
            bfIMPORTANCIASEGURADA.HeaderStyle.CssClass = "gridViewHeader1";
            bfIMPORTANCIASEGURADA.ItemStyle.CssClass = "gridViewValues3";
            bfIMPORTANCIASEGURADA.ItemStyle.Width = 50;
            bfIMPORTANCIASEGURADA.SortExpression = "IMPORTANCIASEGURADA";
            bfIMPORTANCIASEGURADA.Visible = true;
            gdRegistros.Columns.Add(bfIMPORTANCIASEGURADA);

            BoundField bfXTITULAR = new BoundField();
            bfXTITULAR.DataField = "XTITULAR";
            bfXTITULAR.HeaderText = "XTitular";
            bfXTITULAR.HeaderStyle.CssClass = "gridViewHeader1";
            bfXTITULAR.ItemStyle.CssClass = "gridViewValues3";
            bfXTITULAR.ItemStyle.Width = 30;
            bfXTITULAR.SortExpression = "XTITULAR";
            bfXTITULAR.Visible = false;
            gdRegistros.Columns.Add(bfXTITULAR);

            BoundField bfTITULAR = new BoundField();
            bfTITULAR.DataField = "TITULAR";
            bfTITULAR.HeaderText = "Titular";
            bfTITULAR.HeaderStyle.CssClass = "gridViewHeader1";
            bfTITULAR.ItemStyle.CssClass = "gridViewValues3";
            bfTITULAR.ItemStyle.Width = 50;
            bfTITULAR.SortExpression = "TITULAR";
            bfTITULAR.Visible = true;
            gdRegistros.Columns.Add(bfTITULAR);

            BoundField bfXCONJUGE = new BoundField();
            bfXCONJUGE.DataField = "XCONJUGE";
            bfXCONJUGE.HeaderText = "XConjuge";
            bfXCONJUGE.HeaderStyle.CssClass = "gridViewHeader1";
            bfXCONJUGE.ItemStyle.CssClass = "gridViewValues3";
            bfXCONJUGE.ItemStyle.Width = 30;
            bfXCONJUGE.SortExpression = "XCONJUGE";
            bfXCONJUGE.Visible = false;
            gdRegistros.Columns.Add(bfXCONJUGE);

            BoundField bfCONJUGE = new BoundField();
            bfCONJUGE.DataField = "CONJUGE";
            bfCONJUGE.HeaderText = "Conjuge";
            bfCONJUGE.HeaderStyle.CssClass = "gridViewHeader1";
            bfCONJUGE.ItemStyle.CssClass = "gridViewValues3";
            bfCONJUGE.ItemStyle.Width = 50;
            bfCONJUGE.SortExpression = "CONJUGE";
            bfCONJUGE.Visible = true;
            gdRegistros.Columns.Add(bfCONJUGE);

            BoundField bfXFILHO = new BoundField();
            bfXFILHO.DataField = "XFILHO";
            bfXFILHO.HeaderText = "XFilho";
            bfXFILHO.HeaderStyle.CssClass = "gridViewHeader1";
            bfXFILHO.ItemStyle.CssClass = "gridViewValues3";
            bfXFILHO.ItemStyle.Width = 30;
            bfXFILHO.SortExpression = "XFILHO";
            bfXFILHO.Visible = false;
            gdRegistros.Columns.Add(bfXFILHO);

            BoundField bfFILHO = new BoundField();
            bfFILHO.DataField = "FILHO";
            bfFILHO.HeaderText = "Filho";
            bfFILHO.HeaderStyle.CssClass = "gridViewHeader1";
            bfFILHO.ItemStyle.CssClass = "gridViewValues3";
            bfFILHO.ItemStyle.Width = 50;
            bfFILHO.SortExpression = "FILHO";
            bfFILHO.Visible = true;
            gdRegistros.Columns.Add(bfFILHO);

            BoundField bfIDADEMIN = new BoundField();
            bfIDADEMIN.DataField = "IDADEMIN";
            bfIDADEMIN.HeaderText = "Idade Min";
            bfIDADEMIN.HeaderStyle.CssClass = "gridViewHeader1";
            bfIDADEMIN.ItemStyle.CssClass = "gridViewValues3";
            bfIDADEMIN.ItemStyle.Width = 30;
            bfIDADEMIN.SortExpression = "IDADEMIN";
            bfIDADEMIN.Visible = true;
            gdRegistros.Columns.Add(bfIDADEMIN);

            BoundField bfIDADEMAX = new BoundField();
            bfIDADEMAX.DataField = "IDADEMAX";
            bfIDADEMAX.HeaderText = "Idade Max";
            bfIDADEMAX.HeaderStyle.CssClass = "gridViewHeader1";
            bfIDADEMAX.ItemStyle.CssClass = "gridViewValues3";
            bfIDADEMAX.ItemStyle.Width = 30;
            bfIDADEMAX.SortExpression = "IDADEMAX";
            bfIDADEMAX.Visible = true;
            gdRegistros.Columns.Add(bfIDADEMAX);

            BoundField bfIDTIPOPLANO = new BoundField();
            bfIDTIPOPLANO.DataField = "IDTIPOPLANO";
            bfIDTIPOPLANO.HeaderText = "IDTipoPlano";
            bfIDTIPOPLANO.HeaderStyle.CssClass = "gridViewHeader1";
            bfIDTIPOPLANO.ItemStyle.CssClass = "gridViewValues3";
            bfIDTIPOPLANO.ItemStyle.Width = 50;
            bfIDTIPOPLANO.SortExpression = "IDTIPOPLANO";
            bfIDTIPOPLANO.Visible = false;
            gdRegistros.Columns.Add(bfIDTIPOPLANO);

            BoundField bfTIPOPLANO = new BoundField();
            bfTIPOPLANO.DataField = "TIPOPLANO";
            bfTIPOPLANO.HeaderText = "Tipo Plano";
            bfTIPOPLANO.HeaderStyle.CssClass = "gridViewHeader1";
            bfTIPOPLANO.ItemStyle.CssClass = "gridViewValues3";
            bfTIPOPLANO.ItemStyle.Width = 50;
            bfTIPOPLANO.SortExpression = "TIPOPLANO";
            bfTIPOPLANO.Visible = true;
            gdRegistros.Columns.Add(bfTIPOPLANO);

            BoundField bfFLAG_ATIVO = new BoundField();
            bfFLAG_ATIVO.DataField = "FLAG_ATIVO";
            bfFLAG_ATIVO.HeaderText = "Ativo?";
            bfFLAG_ATIVO.HeaderStyle.CssClass = "gridViewHeader1";
            bfFLAG_ATIVO.ItemStyle.CssClass = "gridViewValues3";
            bfFLAG_ATIVO.ItemStyle.Width = 30;
            bfFLAG_ATIVO.SortExpression = "FLAG_ATIVO";
            bfFLAG_ATIVO.Visible = true;
            gdRegistros.Columns.Add(bfFLAG_ATIVO);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsQuery = objFrontEnd.dslistPlanosAffinity(IDCampanha);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Planos Cadastrados !! </div>";
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
                lblTituloDiv.Text = "Alteração de Plano";

                lblID.Text = gdRegistros.DataKeys[index]["IDPLANO"].ToString();

                ddlProduto.SelectedValue = gdRegistros.DataKeys[index]["IDPRODUTO"].ToString();
                ddlTipoPlano.SelectedValue = gdRegistros.DataKeys[index]["IDTIPOPLANO"].ToString();
                txtCodigoPlano.Text = gdRegistros.DataKeys[index]["CODIGOPLANO"].ToString();
                txtImportanciaSegurada.Text = gdRegistros.DataKeys[index]["XIMPORTANCIASEGURADA"].ToString();
                txtTitular.Text = gdRegistros.DataKeys[index]["XTITULAR"].ToString();
                txtConjuge.Text = gdRegistros.DataKeys[index]["XCONJUGE"].ToString();
                txtFilho.Text = gdRegistros.DataKeys[index]["XFILHO"].ToString();
                txtIdadeMin.Text = gdRegistros.DataKeys[index]["IDADEMIN"].ToString();
                txtIdadeMax.Text = gdRegistros.DataKeys[index]["IDADEMAX"].ToString();
                
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["FLAG_ATIVO"].ToString() == "Sim" ? "True" : "False";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Plano";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["IDPLANO"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["CODIGOPLANO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsRegistros = objFrontEnd.dslistPlanosAffinity(ddlCampaign.SelectedValue.ToString());

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
            if (lblTituloDiv.Text == "Cadastrar novo Plano")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Plano")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Plano")
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
                if (ddlProduto.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Produto</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtCodigoPlano.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Codigo do Plano</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtImportanciaSegurada.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Imp.Segurada</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtTitular.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Titular</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtConjuge.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Conjuge</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtFilho.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Filho</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtIdadeMin.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Idade Min</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtIdadeMax.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Idade Max</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlTipoPlano.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo de Plano</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoPlano objDto = new dtoPlano();
                objDto.Task = 1;
                objDto.IDProduto = Convert.ToInt64(ddlProduto.SelectedValue.ToString());
                objDto.CodigoPlano = Convert.ToInt64(txtCodigoPlano.Text);
                objDto.ImportanciaSegurada = Convert.ToInt64(txtImportanciaSegurada.Text);
                objDto.Titular = Convert.ToInt64(txtTitular.Text);
                objDto.Conjuge = Convert.ToInt64(txtConjuge.Text);
                objDto.Filho = Convert.ToInt64(txtFilho.Text);
                objDto.IdadeMin = Convert.ToInt64(txtIdadeMin.Text);
                objDto.IdadeMax = Convert.ToInt64(txtIdadeMax.Text);
                objDto.TipoPlano = Convert.ToInt64(ddlTipoPlano.SelectedValue.ToString());
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerPlanoAffinity(objDto, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Plano Cadastrado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Plano !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Plano !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                if (ddlProduto.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Produto</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtCodigoPlano.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Codigo do Plano</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtImportanciaSegurada.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Imp.Segurada</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtTitular.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Titular</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtConjuge.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Conjuge</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtFilho.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Filho</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtIdadeMin.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Idade Min</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtIdadeMax.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Idade Max</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlTipoPlano.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo de Plano</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoPlano objDto = new dtoPlano();
                objDto.Task = 2;
                objDto.IDPlano = Convert.ToInt64(lblID.Text);
                objDto.IDProduto = Convert.ToInt64(ddlProduto.SelectedValue.ToString());
                objDto.CodigoPlano = Convert.ToInt64(txtCodigoPlano.Text);
                objDto.ImportanciaSegurada = Convert.ToInt64(txtImportanciaSegurada.Text);
                objDto.Titular = Convert.ToInt64(txtTitular.Text);
                objDto.Conjuge = Convert.ToInt64(txtConjuge.Text);
                objDto.Filho = Convert.ToInt64(txtFilho.Text);
                objDto.IdadeMin = Convert.ToInt64(txtIdadeMin.Text);
                objDto.IdadeMax = Convert.ToInt64(txtIdadeMax.Text);
                objDto.TipoPlano = Convert.ToInt64(ddlTipoPlano.SelectedValue.ToString());
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerPlanoAffinity(objDto, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'>Plano Alterado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Plano !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Plano !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoPlano objDto = new dtoPlano();
                objDto.Task = 3;
                objDto.IDPlano = Convert.ToInt64(lblID.Text);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 idExclusaoOperacao = objFrontEnd.ManagerPlanoAffinity(objDto, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Plano Excluido com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Plano !! Plano já utilizados pela operação não podem ser excluidos ! </div>";
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
                lblTituloDiv.Text = "Cadastrar novo Plano";
                modManutencao.Visible = true;
                modExcluir.Visible = false;

                ddlProduto.SelectedValue = "0";
                ddlTipoPlano.SelectedValue = "0";
                txtCodigoPlano.Text = "";
                txtImportanciaSegurada.Text = "";
                txtTitular.Text = "";
                txtConjuge.Text = "";
                txtFilho.Text = "";
                txtIdadeMin.Text = "";
                txtIdadeMax.Text = "";
                
                ddlAtivo.SelectedValue = "False";
                gridLista(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}
