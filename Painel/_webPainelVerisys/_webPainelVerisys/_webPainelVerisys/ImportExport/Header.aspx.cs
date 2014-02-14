using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class Header : System.Web.UI.Page
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

            ButtonField btnColumns = new ButtonField();
            btnColumns.ButtonType = ButtonType.Image;
            btnColumns.ImageUrl = "../img/calendar.gif";
            btnColumns.CommandName = "Col";
            btnColumns.ItemStyle.Width = 25;
            btnColumns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnColumns.HeaderText = "";
            btnColumns.HeaderStyle.CssClass = "gridViewHeader";
            btnUpdate.Visible = true;
            gdRegistros.Columns.Add(btnColumns);

            // Campos
            BoundField bfHeaderID = new BoundField();
            bfHeaderID.DataField = "HeaderID";
            bfHeaderID.HeaderText = "ID";
            bfHeaderID.HeaderStyle.CssClass = "gridViewHeader1";
            bfHeaderID.ItemStyle.CssClass = "gridViewValues3";
            bfHeaderID.ItemStyle.Width = 50;
            bfHeaderID.Visible = false;
            gdRegistros.Columns.Add(bfHeaderID);

            BoundField bfHeaderName = new BoundField();
            bfHeaderName.DataField = "HeaderName";
            bfHeaderName.HeaderText = "Nome";
            bfHeaderName.HeaderStyle.CssClass = "gridViewHeader1";
            bfHeaderName.ItemStyle.CssClass = "gridViewValues3";
            bfHeaderName.ItemStyle.Width = 200;
            bfHeaderName.Visible = true;
            bfHeaderName.SortExpression = "HeaderName";
            gdRegistros.Columns.Add(bfHeaderName);

            BoundField bfHeaderSeparator = new BoundField();
            bfHeaderSeparator.DataField = "HeaderSeparator";
            bfHeaderSeparator.HeaderText = "Separador";
            bfHeaderSeparator.HeaderStyle.CssClass = "gridViewHeader1";
            bfHeaderSeparator.ItemStyle.CssClass = "gridViewValues3";
            bfHeaderSeparator.ItemStyle.Width = 100;
            bfHeaderSeparator.Visible = true;
            bfHeaderSeparator.SortExpression = "HeaderSeparator";
            gdRegistros.Columns.Add(bfHeaderSeparator);

            BoundField bfHeaderLineSize = new BoundField();
            bfHeaderLineSize.DataField = "HeaderLineSize";
            bfHeaderLineSize.HeaderText = "Tamanho";
            bfHeaderLineSize.HeaderStyle.CssClass = "gridViewHeader1";
            bfHeaderLineSize.ItemStyle.CssClass = "gridViewValues3";
            bfHeaderLineSize.ItemStyle.Width = 100;
            bfHeaderLineSize.Visible = true;
            bfHeaderLineSize.SortExpression = "HeaderLineSize";
            gdRegistros.Columns.Add(bfHeaderLineSize);

            BoundField bfHeaderInitialLine = new BoundField();
            bfHeaderInitialLine.DataField = "HeaderInitialLine";
            bfHeaderInitialLine.HeaderText = "Linha";
            bfHeaderInitialLine.HeaderStyle.CssClass = "gridViewHeader1";
            bfHeaderInitialLine.ItemStyle.CssClass = "gridViewValues3";
            bfHeaderInitialLine.ItemStyle.Width = 100;
            bfHeaderInitialLine.Visible = true;
            bfHeaderInitialLine.SortExpression = "HeaderInitialLine";
            gdRegistros.Columns.Add(bfHeaderInitialLine);

            BoundField bfHeaderStatusID = new BoundField();
            bfHeaderStatusID.DataField = "HeaderStatusID";
            bfHeaderStatusID.HeaderText = "HeaderStatusID";
            bfHeaderStatusID.HeaderStyle.CssClass = "gridViewHeader1";
            bfHeaderStatusID.ItemStyle.CssClass = "gridViewValues3";
            bfHeaderStatusID.ItemStyle.Width = 50;
            bfHeaderStatusID.Visible = false;
            bfHeaderStatusID.SortExpression = "HeaderStatusID";
            gdRegistros.Columns.Add(bfHeaderStatusID);

            BoundField bfHeaderStatus = new BoundField();
            bfHeaderStatus.DataField = "HeaderStatus";
            bfHeaderStatus.HeaderText = "Ativo ?";
            bfHeaderStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfHeaderStatus.ItemStyle.CssClass = "gridViewValues3";
            bfHeaderStatus.ItemStyle.Width = 100;
            bfHeaderStatus.Visible = true;
            bfHeaderStatus.SortExpression = "HeaderStatus";
            gdRegistros.Columns.Add(bfHeaderStatus);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTREGISTRYHEADER(objUsers);
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
                lblID.Text = gdRegistros.DataKeys[index]["HeaderID"].ToString();

                txtHeaderName.Text = gdRegistros.DataKeys[index]["HeaderName"].ToString();
                txtHeaderSeparator.Text = gdRegistros.DataKeys[index]["HeaderSeparator"].ToString();
                txtHeaderLineSize.Text = gdRegistros.DataKeys[index]["HeaderLineSize"].ToString();
                txtHeaderInitialLine.Text = gdRegistros.DataKeys[index]["HeaderInitialLine"].ToString();
                ddlHeaderStatus.SelectedValue = gdRegistros.DataKeys[index]["HeaderStatusID"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["HeaderID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["HeaderName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Col")
            {
                int index = int.Parse((string)e.CommandArgument);
                Response.Redirect("Columns.aspx?Processo=1&Registro=" + gdRegistros.DataKeys[index]["HeaderID"].ToString());
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTREGISTRYHEADER(objUsers);
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
                if (txtHeaderName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if ((txtHeaderInitialLine.Text == String.Empty) || (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Linha</b> deve ser numerico e não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtHeaderSeparator.Text == String.Empty)
                {
                    if ((txtHeaderLineSize.Text == String.Empty) && (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                        return;
                    }
                }

                dtoImportExport_Header dtoAuxIEHeader = new dtoImportExport_Header();
                dtoAuxIEHeader.Task = 1;
                dtoAuxIEHeader.HeaderName = txtHeaderName.Text;
                dtoAuxIEHeader.HeaderSeparator = txtHeaderSeparator.Text;
                dtoAuxIEHeader.HeaderLineSize = Convert.ToInt32(txtHeaderLineSize.Text == "" ? "0" : txtHeaderLineSize.Text);
                dtoAuxIEHeader.HeaderInitialLine = Convert.ToInt32(txtHeaderInitialLine.Text);
                dtoAuxIEHeader.HeaderStatus = Convert.ToBoolean(ddlHeaderStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYHEADER(dtoAuxIEHeader, objUsers);
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
                if (txtHeaderName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if ((txtHeaderInitialLine.Text == String.Empty) || (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Linha</b> deve ser numerico e não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtHeaderSeparator.Text == String.Empty)
                {
                    if ((txtHeaderLineSize.Text == String.Empty) && (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                        return;
                    }
                }

                dtoImportExport_Header dtoAuxIEHeader = new dtoImportExport_Header();
                dtoAuxIEHeader.Task = 2;
                dtoAuxIEHeader.HeaderID = Convert.ToInt32(lblID.Text);
                dtoAuxIEHeader.HeaderName = txtHeaderName.Text;
                dtoAuxIEHeader.HeaderSeparator = txtHeaderSeparator.Text;
                dtoAuxIEHeader.HeaderLineSize = Convert.ToInt32(txtHeaderLineSize.Text == "" ? "0" : txtHeaderLineSize.Text);
                dtoAuxIEHeader.HeaderInitialLine = Convert.ToInt32(txtHeaderInitialLine.Text);
                dtoAuxIEHeader.HeaderStatus = Convert.ToBoolean(ddlHeaderStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYHEADER(dtoAuxIEHeader, objUsers);
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
                dtoImportExport_Header dtoAuxIEHeader = new dtoImportExport_Header();
                dtoAuxIEHeader.Task = 3;
                dtoAuxIEHeader.HeaderID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYHEADER(dtoAuxIEHeader, objUsers);
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
                txtHeaderName.Text = "";
                txtHeaderSeparator.Text = "";
                txtHeaderLineSize.Text = "";
                txtHeaderInitialLine.Text = "";
                ddlHeaderStatus.SelectedValue = "True";
            }
            catch
            {

            }
        }
    }
}
