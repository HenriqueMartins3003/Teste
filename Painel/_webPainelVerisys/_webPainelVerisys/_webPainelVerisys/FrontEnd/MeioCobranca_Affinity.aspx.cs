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
    public partial class MeioCobranca_Affinity : System.Web.UI.Page
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
                loadTipoMeioCobranca(ddlCampaign.SelectedValue.ToString());
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

        protected void loadTipoMeioCobranca(String IDCampanha)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            ddlTipoMeioCobranca.DataSource = objFrontEnd.listTipoMeioCobrancaAffinity(IDCampanha);
            ddlTipoMeioCobranca.DataTextField = "TipoMeioCobranca";
            ddlTipoMeioCobranca.DataValueField = "IDTipoMeioCobranca";
            ddlTipoMeioCobranca.DataBind();
        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            divContent.Visible = true;
            gridLista(ddlCampaign.SelectedValue.ToString());
            loadProduto(ddlCampaign.SelectedValue.ToString());
            loadTipoMeioCobranca(ddlCampaign.SelectedValue.ToString());
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
            bfID.DataField = "IDMEIOCOBRANCA";
            bfID.HeaderText = "IDMEIOCOBRANCA";
            bfID.HeaderStyle.CssClass = "gridViewHeader1";
            bfID.ItemStyle.CssClass = "gridViewValues3";
            bfID.ItemStyle.Width = 50;
            bfID.SortExpression = "IDMEIOCOBRANCA";
            bfID.Visible = false;
            gdRegistros.Columns.Add(bfID);

            BoundField bfCLIENTE = new BoundField();
            bfCLIENTE.DataField = "CLIENTE";
            bfCLIENTE.HeaderText = "Cliente";
            bfCLIENTE.HeaderStyle.CssClass = "gridViewHeader1";
            bfCLIENTE.ItemStyle.CssClass = "gridViewValues3";
            bfCLIENTE.ItemStyle.Width = 50;
            bfCLIENTE.SortExpression = "CLIENTE";
            gdRegistros.Columns.Add(bfCLIENTE);

            BoundField bfNMEIOCOBRANCA = new BoundField();
            bfNMEIOCOBRANCA.DataField = "NMEIOCOBRANCA";
            bfNMEIOCOBRANCA.HeaderText = "Meio Cobranca";
            bfNMEIOCOBRANCA.HeaderStyle.CssClass = "gridViewHeader";
            bfNMEIOCOBRANCA.ItemStyle.CssClass = "gridViewValues2";
            bfNMEIOCOBRANCA.ItemStyle.Width = 50;
            bfNMEIOCOBRANCA.SortExpression = "NMEIOCOBRANCA";
            gdRegistros.Columns.Add(bfNMEIOCOBRANCA);

            BoundField bfNADMCOBRANCA = new BoundField();
            bfNADMCOBRANCA.DataField = "NADMCOBRANCA";
            bfNADMCOBRANCA.HeaderText = "Adm Cobranca";
            bfNADMCOBRANCA.HeaderStyle.CssClass = "gridViewHeader";
            bfNADMCOBRANCA.ItemStyle.CssClass = "gridViewValues2";
            bfNADMCOBRANCA.ItemStyle.Width = 50;
            bfNADMCOBRANCA.SortExpression = "NADMCOBRANCA";
            gdRegistros.Columns.Add(bfNADMCOBRANCA);

            BoundField bfNCICLOADMCOBRANCA = new BoundField();
            bfNCICLOADMCOBRANCA.DataField = "NCICLOADMCOBRANCA";
            bfNCICLOADMCOBRANCA.HeaderText = "Ciclo Adm Cobranca";
            bfNCICLOADMCOBRANCA.HeaderStyle.CssClass = "gridViewHeader";
            bfNCICLOADMCOBRANCA.ItemStyle.CssClass = "gridViewValues2";
            bfNCICLOADMCOBRANCA.ItemStyle.Width = 50;
            bfNCICLOADMCOBRANCA.SortExpression = "NCICLOADMCOBRANCA";
            gdRegistros.Columns.Add(bfNCICLOADMCOBRANCA);

            BoundField bfIDTIPOMEIOCOBRANCA = new BoundField();
            bfIDTIPOMEIOCOBRANCA.DataField = "IDTIPOMEIOCOBRANCA";
            bfIDTIPOMEIOCOBRANCA.HeaderText = "IDTIPOMEIOCOBRANCA";
            bfIDTIPOMEIOCOBRANCA.HeaderStyle.CssClass = "gridViewHeader";
            bfIDTIPOMEIOCOBRANCA.ItemStyle.CssClass = "gridViewValues2";
            bfIDTIPOMEIOCOBRANCA.ItemStyle.Width = 50;
            bfIDTIPOMEIOCOBRANCA.SortExpression = "IDTIPOMEIOCOBRANCA";
            bfIDTIPOMEIOCOBRANCA.Visible = false;
            gdRegistros.Columns.Add(bfIDTIPOMEIOCOBRANCA);

            BoundField bfDESCRICAOTIPOMEIOCOBRANCA = new BoundField();
            bfDESCRICAOTIPOMEIOCOBRANCA.DataField = "DESCRICAOTIPOMEIOCOBRANCA";
            bfDESCRICAOTIPOMEIOCOBRANCA.HeaderText = "Tipo Meio Cobranca";
            bfDESCRICAOTIPOMEIOCOBRANCA.HeaderStyle.CssClass = "gridViewHeader";
            bfDESCRICAOTIPOMEIOCOBRANCA.ItemStyle.CssClass = "gridViewValues2";
            bfDESCRICAOTIPOMEIOCOBRANCA.ItemStyle.Width = 50;
            bfDESCRICAOTIPOMEIOCOBRANCA.SortExpression = "DESCRICAOTIPOMEIOCOBRANCA";
            gdRegistros.Columns.Add(bfDESCRICAOTIPOMEIOCOBRANCA);

            BoundField bfIDPRODUTO = new BoundField();
            bfIDPRODUTO.DataField = "IDPRODUTO";
            bfIDPRODUTO.HeaderText = "IDPRODUTO";
            bfIDPRODUTO.HeaderStyle.CssClass = "gridViewHeader";
            bfIDPRODUTO.ItemStyle.CssClass = "gridViewValues2";
            bfIDPRODUTO.ItemStyle.Width = 50;
            bfIDPRODUTO.SortExpression = "IDPRODUTO";
            bfIDPRODUTO.Visible = false;
            gdRegistros.Columns.Add(bfIDPRODUTO);

            BoundField bfDESCRICAOPRODUTO = new BoundField();
            bfDESCRICAOPRODUTO.DataField = "DESCRICAOPRODUTO";
            bfDESCRICAOPRODUTO.HeaderText = "Produto";
            bfDESCRICAOPRODUTO.HeaderStyle.CssClass = "gridViewHeader";
            bfDESCRICAOPRODUTO.ItemStyle.CssClass = "gridViewValues2";
            bfDESCRICAOPRODUTO.ItemStyle.Width = 50;
            bfDESCRICAOPRODUTO.SortExpression = "DESCRICAOPRODUTO";
            bfDESCRICAOPRODUTO.Visible = false;
            gdRegistros.Columns.Add(bfDESCRICAOPRODUTO); 

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
            DataSet dsQuery = objFrontEnd.dslistMeioCobrancaAffinity(IDCampanha);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Meios de Cobrança Cadastrados !! </div>";
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
                lblTituloDiv.Text = "Alteração de Meio de Cobranca";

                lblID.Text = gdRegistros.DataKeys[index]["IDMEIOCOBRANCA"].ToString();

                txtCliente.Text = gdRegistros.DataKeys[index]["CLIENTE"].ToString();
                txtMeioCobranca.Text = gdRegistros.DataKeys[index]["NMEIOCOBRANCA"].ToString();
                txtAdmCobranca.Text = gdRegistros.DataKeys[index]["NADMCOBRANCA"].ToString();
                txtCicloAdmCobranca.Text = gdRegistros.DataKeys[index]["NCICLOADMCOBRANCA"].ToString();
                ddlTipoMeioCobranca.SelectedValue = gdRegistros.DataKeys[index]["IDTIPOMEIOCOBRANCA"].ToString();
                ddlProduto.SelectedValue = gdRegistros.DataKeys[index]["IDPRODUTO"].ToString();
                
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["FLAG_ATIVO"].ToString() == "Sim" ? "True" : "False";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Meio de Cobranca";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["IDMEIOCOBRANCA"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["CLIENTE"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsRegistros = objFrontEnd.dslistMeioCobrancaAffinity(ddlCampaign.SelectedValue.ToString());

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
            if (lblTituloDiv.Text == "Cadastrar novo Meio de Cobranca")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Meio de Cobranca")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Meio de Cobranca")
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
                if (txtCliente.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Cliente</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtAdmCobranca.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Adm Cobranca</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtMeioCobranca.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Meio Cobranca</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtCicloAdmCobranca.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Ciclo Adm Cobranca</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlTipoMeioCobranca.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Meio Cobranca</b> deve ser Selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlProduto.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Produto</b> deve ser Selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoMeioCobranca objDto = new dtoMeioCobranca();
                objDto.Task = 1;

                objDto.Cliente = txtCliente.Text;
                objDto.NMeioCobranca = txtMeioCobranca.Text;
                objDto.NAdmCobranca = txtAdmCobranca.Text;
                objDto.NCicloAdmCobranca = txtCicloAdmCobranca.Text;
                objDto.IDTipoMeioCobranca = Convert.ToInt64(ddlTipoMeioCobranca.SelectedValue);
                objDto.IDProduto = Convert.ToInt64(ddlProduto.SelectedValue);
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerMeioCobrancaAffinity(objDto, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Meio de Cobranca Cadastrado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Meio de Cobranca !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Meio de Cobranca !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                if (txtCliente.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Cliente</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtAdmCobranca.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Adm Cobranca</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtMeioCobranca.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Meio Cobranca</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtCicloAdmCobranca.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Ciclo Adm Cobranca</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlTipoMeioCobranca.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Meio Cobranca</b> deve ser Selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlProduto.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Produto</b> deve ser Selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoMeioCobranca objDto = new dtoMeioCobranca();
                objDto.Task = 2;
                objDto.IDMeioCobranca = Convert.ToInt64(lblID.Text);
                objDto.Cliente = txtCliente.Text;
                objDto.NMeioCobranca = txtMeioCobranca.Text;
                objDto.NAdmCobranca = txtAdmCobranca.Text;
                objDto.NCicloAdmCobranca = txtCicloAdmCobranca.Text;
                objDto.IDTipoMeioCobranca = Convert.ToInt64(ddlTipoMeioCobranca.SelectedValue);
                objDto.IDProduto = Convert.ToInt64(ddlProduto.SelectedValue);
                objDto.Flag_Ativo = Convert.ToInt16(ddlAtivo.SelectedValue == "False" ? 0 : 1);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 intResultado = objFrontEnd.ManagerMeioCobrancaAffinity(objDto, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Meio de Cobranca Alterado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Meio de Cobranca !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Meio de Cobranca !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoMeioCobranca objDto = new dtoMeioCobranca();
                objDto.Task = 3;
                objDto.IDMeioCobranca = Convert.ToInt64(lblID.Text);
                objDto.IDCampanha = ddlCampaign.SelectedValue.ToString();

                bllFrontEnd objFrontEnd = new bllFrontEnd();
                Int64 idExclusaoOperacao = objFrontEnd.ManagerMeioCobrancaAffinity(objDto, objUsers);
                if (idExclusaoOperacao > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Meio de Cobranca Excluido com Sucesso </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Meio de Cobranca !! Meio de Cobranca já utilizados pela operação não podem ser excluidos ! </div>";
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
                lblTituloDiv.Text = "Cadastrar novo Meio de Cobranca";
                modManutencao.Visible = true;
                modExcluir.Visible = false;

                txtCliente.Text = "";
                txtMeioCobranca.Text = "";
                txtAdmCobranca.Text = "";
                txtCicloAdmCobranca.Text = "";
                ddlTipoMeioCobranca.SelectedValue = "";
                ddlProduto.SelectedValue = "";

                ddlAtivo.SelectedValue = "False";
                gridLista(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }
    }
}
