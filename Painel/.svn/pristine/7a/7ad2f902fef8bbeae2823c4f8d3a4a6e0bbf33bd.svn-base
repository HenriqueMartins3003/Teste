using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class ExportQuery : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllImportExport objImportExport = new bllImportExport();
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
                listRules();
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

        protected void listRules()
        {
            ddlRulesID.DataSource = objImportExport.UINT_LISTRULES();
            ddlRulesID.DataTextField = "RulesName";
            ddlRulesID.DataValueField = "RulesID";
            ddlRulesID.DataBind();
            ddlRulesID.Items.Insert(0, new ListItem("Regra ...", "0"));
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
            BoundField bfExportQueryID = new BoundField();
            bfExportQueryID.DataField = "ExportQueryID";
            bfExportQueryID.HeaderText = "ExportQueryID";
            bfExportQueryID.HeaderStyle.CssClass = "gridViewHeader1";
            bfExportQueryID.ItemStyle.CssClass = "gridViewValues3";
            bfExportQueryID.ItemStyle.Width = 50;
            bfExportQueryID.Visible = false;
            bfExportQueryID.SortExpression = "ExportQueryID";
            gdRegistros.Columns.Add(bfExportQueryID);

            BoundField bfRulesID = new BoundField();
            bfRulesID.DataField = "RulesID";
            bfRulesID.HeaderText = "RulesID";
            bfRulesID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesID.ItemStyle.CssClass = "gridViewValues3";
            bfRulesID.ItemStyle.Width = 50;
            bfRulesID.Visible = false;
            bfRulesID.SortExpression = "RulesID";
            gdRegistros.Columns.Add(bfRulesID);

            BoundField bfRulesName = new BoundField();
            bfRulesName.DataField = "RulesName";
            bfRulesName.HeaderText = "Nome";
            bfRulesName.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesName.ItemStyle.CssClass = "gridViewValues2";
            bfRulesName.ItemStyle.Width = 300;
            bfRulesName.Visible = true;
            bfRulesName.SortExpression = "RulesName";
            gdRegistros.Columns.Add(bfRulesName);

            BoundField bfQuery = new BoundField();
            bfQuery.DataField = "Query";
            bfQuery.HeaderText = "Query";
            bfQuery.HeaderStyle.CssClass = "gridViewHeader1";
            bfQuery.ItemStyle.CssClass = "gridViewValues3";
            bfQuery.ItemStyle.Width = 50;
            bfQuery.Visible = false;
            bfQuery.SortExpression = "Query";
            gdRegistros.Columns.Add(bfQuery);

            BoundField bfExportQueryStatus = new BoundField();
            bfExportQueryStatus.DataField = "ExportQueryStatus";
            bfExportQueryStatus.HeaderText = "ExportQueryStatus";
            bfExportQueryStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfExportQueryStatus.ItemStyle.CssClass = "gridViewValues3";
            bfExportQueryStatus.ItemStyle.Width = 50;
            bfExportQueryStatus.Visible = false;
            bfExportQueryStatus.SortExpression = "ExportQueryStatus";
            gdRegistros.Columns.Add(bfExportQueryStatus);

            BoundField bfExportQueryStatusDescription = new BoundField();
            bfExportQueryStatusDescription.DataField = "ExportQueryStatusDescription";
            bfExportQueryStatusDescription.HeaderText = "Ativo?";
            bfExportQueryStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfExportQueryStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfExportQueryStatusDescription.ItemStyle.Width = 100;
            bfExportQueryStatusDescription.Visible = true;
            bfExportQueryStatusDescription.SortExpression = "ExportQueryStatusDescription";
            gdRegistros.Columns.Add(bfExportQueryStatusDescription);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTEXPORTQUERYS(objUsers);
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
                lblID.Text = gdRegistros.DataKeys[index]["ExportQueryID"].ToString();

                ddlRulesID.SelectedValue = gdRegistros.DataKeys[index]["RulesID"].ToString();
                txtQuery.Text = gdRegistros.DataKeys[index]["Query"].ToString();
                ddlExportQueryStatus.SelectedValue = gdRegistros.DataKeys[index]["ExportQueryStatus"].ToString();
                
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["ExportQueryID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["ExportQueryID"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTEXPORTQUERYS(objUsers);
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
                if (ddlRulesID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Regra</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtQuery.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Query</b> não pode ficar em Branco !! </div>";
                    return;
                }

                dtoImportExport_ExportQuery dtoAux = new dtoImportExport_ExportQuery();
                dtoAux.Task = 1;
                dtoAux.RulesID = Convert.ToInt64(ddlRulesID.SelectedValue);
                dtoAux.Query = txtQuery.Text;
                dtoAux.ExportQueryStatus = Convert.ToBoolean(ddlExportQueryStatus.SelectedValue.ToString());

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_EXPORTQUERY(dtoAux, objUsers);
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
                if (ddlRulesID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Regra</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtQuery.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Query</b> não pode ficar em Branco !! </div>";
                    return;
                }

                dtoImportExport_ExportQuery dtoAux = new dtoImportExport_ExportQuery();
                dtoAux.Task = 2;
                dtoAux.ExportQueryID = Convert.ToInt64(lblID.Text);
                dtoAux.RulesID = Convert.ToInt64(ddlRulesID.SelectedValue);
                dtoAux.Query = txtQuery.Text;
                dtoAux.ExportQueryStatus = Convert.ToBoolean(ddlExportQueryStatus.SelectedValue.ToString());

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_EXPORTQUERY(dtoAux, objUsers);
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
                dtoImportExport_ExportQuery dtoAux = new dtoImportExport_ExportQuery();
                dtoAux.Task = 3;
                dtoAux.ExportQueryID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_EXPORTQUERY(dtoAux, objUsers);
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
                lblID.Text = "";
                ddlRulesID.SelectedValue = "0";
                txtQuery.Text = "";
                ddlExportQueryStatus.SelectedValue = "0";
            }
            catch
            {

            }
        }
    }
}
