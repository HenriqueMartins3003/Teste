using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class RulesCampaign : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllImportExport objImportExport = new bllImportExport();
        Campaigns objCampaign = new Campaigns();
        Validadores objValidadores = new Validadores();

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
                PageConfig();
                AccessSecurity();
                gdRegistros_Lista();
                listCampaign();
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

        protected void listCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Campanha ...", "0"));
        }

        protected void gdRegistros_Lista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            // Botoes
            ButtonField btnUpdate = new ButtonField();
            btnUpdate.ButtonType = ButtonType.Image;
            btnUpdate.ImageUrl = "../img/edit.gif";
            btnUpdate.CommandName = "Upd";
            btnUpdate.ItemStyle.Width = 25;
            btnUpdate.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnUpdate.HeaderText = "";
            btnUpdate.HeaderStyle.CssClass = "gridViewHeader";
            btnUpdate.Visible = true;
            gdRegistros.Columns.Add(btnUpdate);

            ButtonField btnDelete = new ButtonField();
            btnDelete.ButtonType = ButtonType.Image;
            btnDelete.ImageUrl = "../img/delete.gif";
            btnDelete.CommandName = "Del";
            btnDelete.ItemStyle.Width = 25;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            btnDelete.Visible = true;
            gdRegistros.Columns.Add(btnDelete);





            // Campos
            BoundField bfIDRulesCampaign = new BoundField();
            bfIDRulesCampaign.DataField = "IDRulesCampaign";
            bfIDRulesCampaign.HeaderText = "IDRulesCampaign";
            bfIDRulesCampaign.HeaderStyle.CssClass = "gridViewHeader1";
            bfIDRulesCampaign.ItemStyle.CssClass = "gridViewValues3";
            bfIDRulesCampaign.ItemStyle.Width = 50;
            bfIDRulesCampaign.Visible = false;
            bfIDRulesCampaign.SortExpression = "IDRulesCampaign";
            gdRegistros.Columns.Add(bfIDRulesCampaign);

            BoundField bfCampaign = new BoundField();
            bfCampaign.DataField = "Campaign";
            bfCampaign.HeaderText = "Campanha";
            bfCampaign.HeaderStyle.CssClass = "gridViewHeader1";
            bfCampaign.ItemStyle.CssClass = "gridViewValues3";
            bfCampaign.ItemStyle.Width = 100;
            bfCampaign.Visible = true;
            bfCampaign.SortExpression = "Campaign";
            gdRegistros.Columns.Add(bfCampaign);

            BoundField bfTableColumn = new BoundField();
            bfTableColumn.DataField = "TableColumn";
            bfTableColumn.HeaderText = "Coluna";
            bfTableColumn.HeaderStyle.CssClass = "gridViewHeader1";
            bfTableColumn.ItemStyle.CssClass = "gridViewValues2";
            bfTableColumn.ItemStyle.Width = 200;
            bfTableColumn.Visible = true;
            bfTableColumn.SortExpression = "TableColumn";
            gdRegistros.Columns.Add(bfTableColumn);

            BoundField bfData = new BoundField();
            bfData.DataField = "Data";
            bfData.HeaderText = "Conteudo";
            bfData.HeaderStyle.CssClass = "gridViewHeader1";
            bfData.ItemStyle.CssClass = "gridViewValues2";
            bfData.ItemStyle.Width = 300;
            bfData.Visible = true;
            bfData.SortExpression = "Data";
            gdRegistros.Columns.Add(bfData);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTRULESCAMPAIGN(objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                ctnLista.Visible = false;
                lblResponse.Text = "<div class='ROK'> Não existem dados Cadastrados !! </div>";
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
                lblTituloDiv.Text = "Alteração";
                lblID.Text = gdRegistros.DataKeys[index]["IDRulesCampaign"].ToString();

                ddlCampaign.SelectedValue = gdRegistros.DataKeys[index]["Campaign"].ToString();
                txtTableColumn.Text = gdRegistros.DataKeys[index]["TableColumn"].ToString();
                txtData.Text = gdRegistros.DataKeys[index]["Data"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["IDRulesCampaign"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["IDRulesCampaign"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTRULESCAMPAIGN(objUsers);
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
            gdRegistros_Lista();
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

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Cadastro")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (ddlCampaign.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Campanha</b> deve ser selecionado !! </div>";
                    return;
                }

                if (txtTableColumn.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Coluna</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtData.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Conteúdo</b> não pode ficar em Branco !! </div>";
                    return;
                }

                dtoImportExport_RulesCampaign dtoAux = new dtoImportExport_RulesCampaign();
                dtoAux.Task = 1;
                dtoAux.Campaign = ddlCampaign.SelectedValue ;
                dtoAux.TableColumn = txtTableColumn.Text;
                dtoAux.Data = txtData.Text;

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULESCAMPAIGN(dtoAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    lblResponse.Text = "<div class='ROK'> Registro Cadastrado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro do Registro !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro do Registro !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (ddlCampaign.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Campanha</b> deve ser selecionado !! </div>";
                    return;
                }

                if (txtTableColumn.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Coluna</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtData.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Conteúdo</b> não pode ficar em Branco !! </div>";
                    return;
                }

                dtoImportExport_RulesCampaign dtoAux = new dtoImportExport_RulesCampaign();
                dtoAux.Task = 2;
                dtoAux.IDRulesCampaign = Convert.ToInt64(lblID.Text);
                dtoAux.Campaign = ddlCampaign.SelectedValue;
                dtoAux.TableColumn = txtTableColumn.Text;
                dtoAux.Data = txtData.Text;

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULESCAMPAIGN(dtoAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    lblResponse.Text = "<div class='ROK'> Registro Alterado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Registro !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Registro !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoImportExport_RulesCampaign dtoAux = new dtoImportExport_RulesCampaign();
                dtoAux.Task = 3;
                dtoAux.IDRulesCampaign = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULESCAMPAIGN(dtoAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    lblResponse.Text = "<div class='ROK'> Registro Excluido com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão do Registro !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão do Registro !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastro";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                ctnLista.Visible = true;
                gdRegistros_Lista();

                // CAMPOS
                ddlCampaign.SelectedValue = "0";
                txtTableColumn.Text = "";
                txtData.Text = "";
            }
            catch
            {

            }
        }
    }
}
