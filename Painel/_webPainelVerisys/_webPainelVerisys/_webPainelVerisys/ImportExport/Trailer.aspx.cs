using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class Trailer : System.Web.UI.Page
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
        
        protected void gdRegistros_Lista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();
            
            // BOTOES
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

            ButtonField btnColumns = new ButtonField();
            btnColumns.ButtonType = ButtonType.Image;
            btnColumns.ImageUrl = "../img/calendar.gif";
            btnColumns.CommandName = "Col";
            btnColumns.ItemStyle.Width = 25;
            btnColumns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnColumns.HeaderText = "";
            btnColumns.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnColumns);

            // CAMPOS
            BoundField bfTrailerID = new BoundField();
            bfTrailerID.DataField = "TrailerID";
            bfTrailerID.HeaderText = "ID";
            bfTrailerID.HeaderStyle.CssClass = "gridViewHeader1";
            bfTrailerID.ItemStyle.CssClass = "gridViewValues3";
            bfTrailerID.ItemStyle.Width = 50;
            bfTrailerID.Visible = false;
            gdRegistros.Columns.Add(bfTrailerID);

            BoundField bfTrailerName = new BoundField();
            bfTrailerName.DataField = "TrailerName";
            bfTrailerName.HeaderText = "Nome";
            bfTrailerName.HeaderStyle.CssClass = "gridViewHeader1";
            bfTrailerName.ItemStyle.CssClass = "gridViewValues3";
            bfTrailerName.ItemStyle.Width = 200;
            bfTrailerName.Visible = true;
            bfTrailerName.SortExpression = "TrailerName";
            gdRegistros.Columns.Add(bfTrailerName);

            BoundField bfTrailerSeparator = new BoundField();
            bfTrailerSeparator.DataField = "TrailerSeparator";
            bfTrailerSeparator.HeaderText = "Separador";
            bfTrailerSeparator.HeaderStyle.CssClass = "gridViewHeader1";
            bfTrailerSeparator.ItemStyle.CssClass = "gridViewValues3";
            bfTrailerSeparator.ItemStyle.Width = 100;
            bfTrailerSeparator.Visible = true;
            bfTrailerSeparator.SortExpression = "TrailerSeparator";
            gdRegistros.Columns.Add(bfTrailerSeparator);

            BoundField bfTrailerLineSize = new BoundField();
            bfTrailerLineSize.DataField = "TrailerLineSize";
            bfTrailerLineSize.HeaderText = "Tamanho";
            bfTrailerLineSize.HeaderStyle.CssClass = "gridViewHeader1";
            bfTrailerLineSize.ItemStyle.CssClass = "gridViewValues3";
            bfTrailerLineSize.ItemStyle.Width = 100;
            bfTrailerLineSize.Visible = true;
            bfTrailerLineSize.SortExpression = "TrailerLineSize";
            gdRegistros.Columns.Add(bfTrailerLineSize);

            BoundField bfTrailerStatusID = new BoundField();
            bfTrailerStatusID.DataField = "TrailerStatusID";
            bfTrailerStatusID.HeaderText = "TrailerStatusID";
            bfTrailerStatusID.HeaderStyle.CssClass = "gridViewHeader1";
            bfTrailerStatusID.ItemStyle.CssClass = "gridViewValues3";
            bfTrailerStatusID.ItemStyle.Width = 50;
            bfTrailerStatusID.Visible = false;
            bfTrailerStatusID.SortExpression = "TrailerStatusID";
            gdRegistros.Columns.Add(bfTrailerStatusID);

            BoundField bfTrailerStatus = new BoundField();
            bfTrailerStatus.DataField = "TrailerStatus";
            bfTrailerStatus.HeaderText = "Ativo ?";
            bfTrailerStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfTrailerStatus.ItemStyle.CssClass = "gridViewValues3";
            bfTrailerStatus.ItemStyle.Width = 100;
            bfTrailerStatus.Visible = true;
            bfTrailerStatus.SortExpression = "TrailerStatus";
            gdRegistros.Columns.Add(bfTrailerStatus);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTREGISTRYTRAILER(objUsers);
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
                lblID.Text = gdRegistros.DataKeys[index]["TrailerID"].ToString();

                txtTrailerName.Text = gdRegistros.DataKeys[index]["TrailerName"].ToString();
                txtTrailerSeparator.Text = gdRegistros.DataKeys[index]["TrailerSeparator"].ToString();
                txtTrailerLineSize.Text = gdRegistros.DataKeys[index]["TrailerLineSize"].ToString();
                ddlTrailerStatus.SelectedValue = gdRegistros.DataKeys[index]["TrailerStatusID"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["TrailerID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["TrailerName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Col")
            {
                int index = int.Parse((string)e.CommandArgument);
                Response.Redirect("Columns.aspx?Processo=2&Registro=" + gdRegistros.DataKeys[index]["TrailerID"].ToString());
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTREGISTRYTRAILER(objUsers);
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
                if (txtTrailerName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtTrailerSeparator.Text == String.Empty)
                {
                    if (txtTrailerLineSize.Text == String.Empty)
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                        return;
                    }
                }

                dtoImportExport_Trailer dtoAuxIETrailer = new dtoImportExport_Trailer();
                dtoAuxIETrailer.Task = 1;
                dtoAuxIETrailer.TrailerName = txtTrailerName.Text;
                dtoAuxIETrailer.TrailerSeparator = txtTrailerSeparator.Text;
                dtoAuxIETrailer.TrailerLineSize = Convert.ToInt32(txtTrailerLineSize.Text == "" ? "0" : txtTrailerLineSize.Text);
                dtoAuxIETrailer.TrailerStatus = Convert.ToBoolean(ddlTrailerStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYTRAILER(dtoAuxIETrailer, objUsers);
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
                if (txtTrailerName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtTrailerSeparator.Text == String.Empty)
                {
                    if (txtTrailerLineSize.Text == String.Empty)
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                        return;
                    }
                }

                dtoImportExport_Trailer dtoAuxIETrailer = new dtoImportExport_Trailer();
                dtoAuxIETrailer.Task = 2;
                dtoAuxIETrailer.TrailerID = Convert.ToInt32(lblID.Text);
                dtoAuxIETrailer.TrailerName = txtTrailerName.Text;
                dtoAuxIETrailer.TrailerSeparator = txtTrailerSeparator.Text;
                dtoAuxIETrailer.TrailerLineSize = Convert.ToInt32(txtTrailerLineSize.Text == "" ? "0" : txtTrailerLineSize.Text);
                dtoAuxIETrailer.TrailerStatus = Convert.ToBoolean(ddlTrailerStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYTRAILER(dtoAuxIETrailer, objUsers);
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
                dtoImportExport_Trailer dtoAuxIETrailer = new dtoImportExport_Trailer();
                dtoAuxIETrailer.Task = 3;
                dtoAuxIETrailer.TrailerID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYTRAILER(dtoAuxIETrailer, objUsers);
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
                ctnLista.Visible = true;
                modExcluir.Visible = false;
                gdRegistros_Lista();

                // CAMPOS
                txtTrailerName.Text = "";
                txtTrailerSeparator.Text = "";
                txtTrailerLineSize.Text = "";
                ddlTrailerStatus.SelectedValue = "True";
            }
            catch
            {

            }
        }
    }
}
