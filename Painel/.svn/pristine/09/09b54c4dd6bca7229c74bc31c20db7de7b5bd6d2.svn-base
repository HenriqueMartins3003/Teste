using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class Files : System.Web.UI.Page
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
                listProcess();
                listFilesType();
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

        protected void listProcess()
        {
            ddlProcessID.DataSource = objImportExport.UINT_LISTPROCESS();
            ddlProcessID.DataTextField = "ProcessName";
            ddlProcessID.DataValueField = "ProcessID";
            ddlProcessID.DataBind();
            ddlProcessID.Items.Insert(0, new ListItem("Processo ...", "0"));
        }

        protected void listFilesType()
        {
            ddlFilesTypeID.DataSource = objImportExport.UINT_LISTFILESTYPE();
            ddlFilesTypeID.DataTextField = "FilesType";
            ddlFilesTypeID.DataValueField = "FilesTypeID";
            ddlFilesTypeID.DataBind();
            ddlFilesTypeID.Items.Insert(0, new ListItem("Tipo ...", "0"));
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
            BoundField bfFileID = new BoundField();
            bfFileID.DataField = "FileID";
            bfFileID.HeaderText = "FileID";
            bfFileID.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileID.ItemStyle.CssClass = "gridViewValues3";
            bfFileID.ItemStyle.Width = 50;
            bfFileID.Visible = false;
            bfFileID.SortExpression = "FileID";
            gdRegistros.Columns.Add(bfFileID);

            BoundField bfProcessID = new BoundField();
            bfProcessID.DataField = "ProcessID";
            bfProcessID.HeaderText = "ProcessID";
            bfProcessID.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessID.ItemStyle.CssClass = "gridViewValues2";
            bfProcessID.ItemStyle.Width = 100;
            bfProcessID.Visible = false;
            bfProcessID.SortExpression = "ProcessID";
            gdRegistros.Columns.Add(bfProcessID);

            BoundField bfProcessName = new BoundField();
            bfProcessName.DataField = "ProcessName";
            bfProcessName.HeaderText = "Processo";
            bfProcessName.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessName.ItemStyle.CssClass = "gridViewValues2";
            bfProcessName.ItemStyle.Width = 100;
            bfProcessName.Visible = true;
            bfProcessName.SortExpression = "ProcessName";
            gdRegistros.Columns.Add(bfProcessName);

            BoundField bfFileName = new BoundField();
            bfFileName.DataField = "FileName";
            bfFileName.HeaderText = "Arquivo";
            bfFileName.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileName.ItemStyle.CssClass = "gridViewValues2";
            bfFileName.ItemStyle.Width = 200;
            bfFileName.Visible = true;
            bfFileName.SortExpression = "FileName";
            gdRegistros.Columns.Add(bfFileName);

            BoundField bfFileExtension = new BoundField();
            bfFileExtension.DataField = "FileExtension";
            bfFileExtension.HeaderText = "FileExtension";
            bfFileExtension.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileExtension.ItemStyle.CssClass = "gridViewValues3";
            bfFileExtension.ItemStyle.Width = 50;
            bfFileExtension.Visible = false;
            bfFileExtension.SortExpression = "FileExtension";
            gdRegistros.Columns.Add(bfFileExtension);

            BoundField bfFileLocation = new BoundField();
            bfFileLocation.DataField = "FileLocation";
            bfFileLocation.HeaderText = "Pasta";
            bfFileLocation.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileLocation.ItemStyle.CssClass = "gridViewValues2";
            bfFileLocation.ItemStyle.Width = 400;
            bfFileLocation.Visible = true;
            bfFileLocation.SortExpression = "FileLocation";
            gdRegistros.Columns.Add(bfFileLocation);

            BoundField bfFileLocationBackup = new BoundField();
            bfFileLocationBackup.DataField = "FileLocationBackup";
            bfFileLocationBackup.HeaderText = "FileLocationBackup";
            bfFileLocationBackup.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileLocationBackup.ItemStyle.CssClass = "gridViewValues3";
            bfFileLocationBackup.ItemStyle.Width = 50;
            bfFileLocationBackup.Visible = false;
            bfFileLocationBackup.SortExpression = "FileLocationBackup";
            gdRegistros.Columns.Add(bfFileLocationBackup);

            BoundField bfFilesTypeID = new BoundField();
            bfFilesTypeID.DataField = "FilesTypeID";
            bfFilesTypeID.HeaderText = "FilesTypeID";
            bfFilesTypeID.HeaderStyle.CssClass = "gridViewHeader1";
            bfFilesTypeID.ItemStyle.CssClass = "gridViewValues3";
            bfFilesTypeID.ItemStyle.Width = 50;
            bfFilesTypeID.Visible = false;
            bfFilesTypeID.SortExpression = "FilesTypeID";
            gdRegistros.Columns.Add(bfFilesTypeID);

            BoundField bfFilesType = new BoundField();
            bfFilesType.DataField = "FilesType";
            bfFilesType.HeaderText = "FilesType";
            bfFilesType.HeaderStyle.CssClass = "gridViewHeader1";
            bfFilesType.ItemStyle.CssClass = "gridViewValues3";
            bfFilesType.ItemStyle.Width = 50;
            bfFilesType.Visible = false;
            bfFilesType.SortExpression = "FilesType";
            gdRegistros.Columns.Add(bfFilesType);

            BoundField bfFileStatus = new BoundField();
            bfFileStatus.DataField = "FileStatus";
            bfFileStatus.HeaderText = "FileStatus";
            bfFileStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileStatus.ItemStyle.CssClass = "gridViewValues3";
            bfFileStatus.ItemStyle.Width = 50;
            bfFileStatus.Visible = false;
            bfFileStatus.SortExpression = "FileStatus";
            gdRegistros.Columns.Add(bfFileStatus);

            BoundField bfFileStatusDescription = new BoundField();
            bfFileStatusDescription.DataField = "FileStatusDescription";
            bfFileStatusDescription.HeaderText = "Ativo?";
            bfFileStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfFileStatusDescription.ItemStyle.Width = 50;
            bfFileStatusDescription.Visible = true;
            bfFileStatusDescription.SortExpression = "FileStatusDescription";
            gdRegistros.Columns.Add(bfFileStatusDescription);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTFILES(objUsers);
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
                lblID.Text = gdRegistros.DataKeys[index]["FileID"].ToString();

                ddlProcessID.SelectedValue = gdRegistros.DataKeys[index]["ProcessID"].ToString();
                txtFileName.Text = gdRegistros.DataKeys[index]["FileName"].ToString();
                txtFileExtension.Text = gdRegistros.DataKeys[index]["FileExtension"].ToString();
                txtFileLocation.Text = gdRegistros.DataKeys[index]["FileLocation"].ToString();
                txtFileLocationBackup.Text = gdRegistros.DataKeys[index]["FileLocationBackup"].ToString();
                ddlFilesTypeID.SelectedValue = gdRegistros.DataKeys[index]["FilesTypeID"].ToString();
                ddlFileStatus.SelectedValue = gdRegistros.DataKeys[index]["FileStatus"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["FileID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["FileName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTFILES(objUsers);
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
                if (ddlProcessID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Processo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (txtFileName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Arquivo</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtFileExtension.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Extensão</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlFilesTypeID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (txtFileLocation.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Pasta</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtFileLocationBackup.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Pasta Backup</b> não pode ficar em Branco !! </div>";
                    return;
                }

                dtoImportExport_Files dtoAux = new dtoImportExport_Files();
                dtoAux.Task = 1;
                dtoAux.ProcessID = Convert.ToInt64(ddlProcessID.SelectedValue);
                dtoAux.FileName = txtFileName.Text;
                dtoAux.FileExtension = txtFileExtension.Text;
                dtoAux.FileLocation = txtFileLocation.Text;
                dtoAux.FileLocationBackup = txtFileLocationBackup.Text;
                dtoAux.FilesTypeID = Convert.ToInt64(ddlFilesTypeID.SelectedValue);
                dtoAux.FileStatus = Convert.ToBoolean(ddlFileStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_FILES(dtoAux, objUsers);
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
                if (ddlProcessID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Processo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (txtFileName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Arquivo</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtFileExtension.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Extensão</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlFilesTypeID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (txtFileLocation.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Pasta</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtFileLocationBackup.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Pasta Backup</b> não pode ficar em Branco !! </div>";
                    return;
                }

                dtoImportExport_Files dtoAux = new dtoImportExport_Files();
                dtoAux.Task = 2;
                dtoAux.FileID = Convert.ToInt64(lblID.Text);
                dtoAux.ProcessID = Convert.ToInt64(ddlProcessID.SelectedValue);
                dtoAux.FileName = txtFileName.Text;
                dtoAux.FileExtension = txtFileExtension.Text;
                dtoAux.FileLocation = txtFileLocation.Text;
                dtoAux.FileLocationBackup = txtFileLocationBackup.Text;
                dtoAux.FilesTypeID = Convert.ToInt64(ddlFilesTypeID.SelectedValue);
                dtoAux.FileStatus = Convert.ToBoolean(ddlFileStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_FILES(dtoAux, objUsers);
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
                dtoImportExport_Files dtoAux = new dtoImportExport_Files();
                dtoAux.Task = 3;
                dtoAux.FileID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_FILES(dtoAux, objUsers);
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
                ddlProcessID.SelectedValue = "0";
                txtFileName.Text = "";
                txtFileExtension.Text = "";
                txtFileLocation.Text = "";
                txtFileLocationBackup.Text = "";
                ddlFilesTypeID.SelectedValue = "0";
                ddlFileStatus.SelectedValue = "0";
            }
            catch
            {

            }
        }
    }
}
