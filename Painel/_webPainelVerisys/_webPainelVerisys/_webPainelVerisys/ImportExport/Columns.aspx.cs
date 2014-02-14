using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class Columns : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllImportExport objImportExport = new bllImportExport();
        Validadores objValidadores = new Validadores();

        // Action
        Int64 idRegistro = 0;
        Int64 idProcesso = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            idRegistro = Convert.ToInt64(Request.QueryString["Registro"]);
            idProcesso = Convert.ToInt64(Request.QueryString["Processo"]);

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
                ColumnType();
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

        protected void ColumnType()
        {
            ddlColumnTypeID.DataSource = objImportExport.UINT_LISTCOLUMNTYPE(idProcesso);
            ddlColumnTypeID.DataTextField = "ColumnType";
            ddlColumnTypeID.DataValueField = "ColumnTypeID";
            ddlColumnTypeID.DataBind();
            ddlColumnTypeID.Items.Insert(0, new ListItem("Selecione ...", "0"));
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
            BoundField bfColumnID = new BoundField();
            bfColumnID.DataField = "ColumnID";
            bfColumnID.HeaderText = "ColumnID";
            bfColumnID.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnID.ItemStyle.CssClass = "gridViewValues3";
            bfColumnID.ItemStyle.Width = 50;
            bfColumnID.Visible = false;
            bfColumnID.SortExpression = "ColumnID";
            gdRegistros.Columns.Add(bfColumnID);

            BoundField bfRegistryID = new BoundField();
            bfRegistryID.DataField = "RegistryID";
            bfRegistryID.HeaderText = "RegistryID";
            bfRegistryID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryID.ItemStyle.Width = 50;
            bfRegistryID.Visible = false;
            bfRegistryID.SortExpression = "RegistryID";
            gdRegistros.Columns.Add(bfRegistryID);

            BoundField bfRegistryHeaderID = new BoundField();
            bfRegistryHeaderID.DataField = "RegistryHeaderID";
            bfRegistryHeaderID.HeaderText = "RegistryHeaderID";
            bfRegistryHeaderID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryHeaderID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryHeaderID.ItemStyle.Width = 50;
            bfRegistryHeaderID.Visible = false;
            bfRegistryHeaderID.SortExpression = "RegistryHeaderID";
            gdRegistros.Columns.Add(bfRegistryHeaderID);

            BoundField bfRegistryTrailerID = new BoundField();
            bfRegistryTrailerID.DataField = "RegistryTrailerID";
            bfRegistryTrailerID.HeaderText = "RegistryTrailerID";
            bfRegistryTrailerID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryTrailerID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryTrailerID.ItemStyle.Width = 50;
            bfRegistryTrailerID.Visible = false;
            bfRegistryTrailerID.SortExpression = "RegistryTrailerID";
            gdRegistros.Columns.Add(bfRegistryTrailerID);

            BoundField bfColumnName = new BoundField();
            bfColumnName.DataField = "ColumnName";
            bfColumnName.HeaderText = "Coluna";
            bfColumnName.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnName.ItemStyle.CssClass = "gridViewValues3";
            bfColumnName.ItemStyle.Width = 50;
            bfColumnName.Visible = true;
            bfColumnName.SortExpression = "ColumnName";
            gdRegistros.Columns.Add(bfColumnName);

            BoundField bfInitialPosition = new BoundField();
            bfInitialPosition.DataField = "InitialPosition";
            bfInitialPosition.HeaderText = "Posição";
            bfInitialPosition.HeaderStyle.CssClass = "gridViewHeader1";
            bfInitialPosition.ItemStyle.CssClass = "gridViewValues3";
            bfInitialPosition.ItemStyle.Width = 50;
            bfInitialPosition.Visible = true;
            bfInitialPosition.SortExpression = "InitialPosition";
            gdRegistros.Columns.Add(bfInitialPosition);

            BoundField bfColumnSize = new BoundField();
            bfColumnSize.DataField = "ColumnSize";
            bfColumnSize.HeaderText = "Tamanho";
            bfColumnSize.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnSize.ItemStyle.CssClass = "gridViewValues3";
            bfColumnSize.ItemStyle.Width = 50;
            bfColumnSize.Visible = true;
            bfColumnSize.SortExpression = "ColumnSize";
            gdRegistros.Columns.Add(bfColumnSize);

            BoundField bfColumnNumber = new BoundField();
            bfColumnNumber.DataField = "ColumnNumber";
            bfColumnNumber.HeaderText = "Numero";
            bfColumnNumber.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnNumber.ItemStyle.CssClass = "gridViewValues3";
            bfColumnNumber.ItemStyle.Width = 50;
            bfColumnNumber.Visible = true;
            bfColumnNumber.SortExpression = "ColumnNumber";
            gdRegistros.Columns.Add(bfColumnNumber);

            BoundField bfColumnTypeID = new BoundField();
            bfColumnTypeID.DataField = "ColumnTypeID";
            bfColumnTypeID.HeaderText = "ColumnTypeID";
            bfColumnTypeID.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnTypeID.ItemStyle.CssClass = "gridViewValues3";
            bfColumnTypeID.ItemStyle.Width = 50;
            bfColumnTypeID.Visible = false;
            bfColumnTypeID.SortExpression = "ColumnTypeID";
            gdRegistros.Columns.Add(bfColumnTypeID);

            BoundField bfColumnType = new BoundField();
            bfColumnType.DataField = "ColumnType";
            bfColumnType.HeaderText = "Tipo";
            bfColumnType.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnType.ItemStyle.CssClass = "gridViewValues3";
            bfColumnType.ItemStyle.Width = 50;
            bfColumnType.Visible = true;
            bfColumnType.SortExpression = "ColumnType";
            gdRegistros.Columns.Add(bfColumnType);

 

            BoundField bfColumnValidation = new BoundField();
            bfColumnValidation.DataField = "ColumnValidation";
            bfColumnValidation.HeaderText = "Valida?";
            bfColumnValidation.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnValidation.ItemStyle.CssClass = "gridViewValues3";
            bfColumnValidation.ItemStyle.Width = 50;
            bfColumnValidation.Visible = true;
            bfColumnValidation.SortExpression = "ColumnValidation";
            gdRegistros.Columns.Add(bfColumnValidation);


            BoundField bfDatabaseColumn = new BoundField();
            bfDatabaseColumn.DataField = "DatabaseColumn";
            bfDatabaseColumn.HeaderText = "Coluna";
            bfDatabaseColumn.HeaderStyle.CssClass = "gridViewHeader1";
            bfDatabaseColumn.ItemStyle.CssClass = "gridViewValues3";
            bfDatabaseColumn.ItemStyle.Width = 50;
            bfDatabaseColumn.Visible = true;
            bfDatabaseColumn.SortExpression = "DatabaseColumn";
            gdRegistros.Columns.Add(bfDatabaseColumn);

            BoundField bfColumnJoin = new BoundField();
            bfColumnJoin.DataField = "ColumnJoin";
            bfColumnJoin.HeaderText = "Join";
            bfColumnJoin.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnJoin.ItemStyle.CssClass = "gridViewValues3";
            bfColumnJoin.ItemStyle.Width = 50;
            bfColumnJoin.Visible = false;
            bfColumnJoin.SortExpression = "ColumnJoin";
            gdRegistros.Columns.Add(bfColumnJoin);

            BoundField bfTextAlign = new BoundField();
            bfTextAlign.DataField = "TextAlign";
            bfTextAlign.HeaderText = "PAD";
            bfTextAlign.HeaderStyle.CssClass = "gridViewHeader1";
            bfTextAlign.ItemStyle.CssClass = "gridViewValues3";
            bfTextAlign.ItemStyle.Width = 50;
            bfTextAlign.Visible = false;
            bfTextAlign.SortExpression = "TextAlign";
            gdRegistros.Columns.Add(bfTextAlign);

            BoundField bfTextComplement = new BoundField();
            bfTextComplement.DataField = "TextComplement";
            bfTextComplement.HeaderText = "Preenchimento";
            bfTextComplement.HeaderStyle.CssClass = "gridViewHeader1";
            bfTextComplement.ItemStyle.CssClass = "gridViewValues3";
            bfTextComplement.ItemStyle.Width = 50;
            bfTextComplement.Visible = false;
            bfTextComplement.SortExpression = "TextComplement";
            gdRegistros.Columns.Add(bfTextComplement);

            BoundField bfTableID = new BoundField();
            bfTableID.DataField = "TableID";
            bfTableID.HeaderText = "Tipo Tabela";
            bfTableID.HeaderStyle.CssClass = "gridViewHeader1";
            bfTableID.ItemStyle.CssClass = "gridViewValues3";
            bfTableID.ItemStyle.Width = 50;
            bfTableID.Visible = false;
            bfTableID.SortExpression = "TableID";
            gdRegistros.Columns.Add(bfTableID);

            BoundField bfColumnStatusID = new BoundField();
            bfColumnStatusID.DataField = "ColumnStatusID";
            bfColumnStatusID.HeaderText = "ColumnStatusID";
            bfColumnStatusID.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnStatusID.ItemStyle.CssClass = "gridViewValues3";
            bfColumnStatusID.ItemStyle.Width = 50;
            bfColumnStatusID.Visible = false;
            bfColumnStatusID.SortExpression = "ColumnStatusID";
            gdRegistros.Columns.Add(bfColumnStatusID);

            BoundField bfColumnStatusDescription = new BoundField();
            bfColumnStatusDescription.DataField = "ColumnStatusDescription";
            bfColumnStatusDescription.HeaderText = "Ativo?";
            bfColumnStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfColumnStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfColumnStatusDescription.ItemStyle.Width = 50;
            bfColumnStatusDescription.Visible = true;
            bfColumnStatusDescription.SortExpression = "ColumnStatusDescription";
            gdRegistros.Columns.Add(bfColumnStatusDescription);

            // nao implementado
            BoundField bfDefaultValue = new BoundField();
            bfDefaultValue.DataField = "DefaultValue";
            bfDefaultValue.HeaderText = "DefaultValue";
            bfDefaultValue.HeaderStyle.CssClass = "gridViewHeader1";
            bfDefaultValue.ItemStyle.CssClass = "gridViewValues3";
            bfDefaultValue.ItemStyle.Width = 50;
            bfDefaultValue.Visible = false;
            bfDefaultValue.SortExpression = "DefaultValue";
            gdRegistros.Columns.Add(bfDefaultValue);

            BoundField bfDefaultMandatory = new BoundField();
            bfDefaultMandatory.DataField = "DefaultMandatory";
            bfDefaultMandatory.HeaderText = "DefaultMandatory";
            bfDefaultMandatory.HeaderStyle.CssClass = "gridViewHeader1";
            bfDefaultMandatory.ItemStyle.CssClass = "gridViewValues3";
            bfDefaultMandatory.ItemStyle.Width = 50;
            bfDefaultMandatory.Visible = false;
            bfDefaultMandatory.SortExpression = "DefaultMandatory";
            gdRegistros.Columns.Add(bfDefaultMandatory);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTREGISTRYCOLUMN(objUsers, idRegistro, idProcesso);
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
                lblID.Text = gdRegistros.DataKeys[index]["ColumnID"].ToString();

                

                txtColumnName.Text = gdRegistros.DataKeys[index]["ColumnName"].ToString();
                txtInitialPosition.Text = gdRegistros.DataKeys[index]["InitialPosition"].ToString();
                txtColumnSize.Text = gdRegistros.DataKeys[index]["ColumnSize"].ToString();
                txtColumnNumber.Text = gdRegistros.DataKeys[index]["ColumnNumber"].ToString();
                ddlColumnTypeID.SelectedValue = gdRegistros.DataKeys[index]["ColumnTypeID"].ToString();
                ddlColumnValidation.SelectedValue = gdRegistros.DataKeys[index]["ColumnValidation"].ToString();
                ddlColumnStatus.SelectedValue = gdRegistros.DataKeys[index]["ColumnStatusDescription"].ToString();
                txtDatabaseColumn.Text = gdRegistros.DataKeys[index]["DatabaseColumn"].ToString();
                ddlColumnJoin.SelectedValue = gdRegistros.DataKeys[index]["ColumnJoin"].ToString();
                ddlTextAlign.SelectedValue = gdRegistros.DataKeys[index]["TextAlign"].ToString();
                txtTextComplement.Text = gdRegistros.DataKeys[index]["TextComplement"].ToString();
                txtDefaultValue.Text = gdRegistros.DataKeys[index]["DefaultValue"].ToString();
                ddlDefaultMandatory.SelectedValue = gdRegistros.DataKeys[index]["DefaultMandatory"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["ColumnID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["ColumnName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTREGISTRYCOLUMN(objUsers, idRegistro, idProcesso);
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
                if (txtColumnName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtInitialPosition.Text != String.Empty) 
                {
                    if (!objValidadores.isNumero(txtInitialPosition.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Posição Inicial</b> deve ser numerico !! </div>";
                        return;
                    }
                }

                if (txtColumnSize.Text != String.Empty)
                {
                    if (!objValidadores.isNumero(txtColumnSize.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico !! </div>";
                        return;
                    }
                }

                if (txtColumnNumber.Text != String.Empty)
                {
                    if (!objValidadores.isNumero(txtColumnNumber.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Coluna</b> deve ser numerico !! </div>";
                        return;
                    }
                }

      
              
                if (txtDatabaseColumn.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Coluna</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlColumnTypeID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                dtoImportExport_Column dtoAux = new dtoImportExport_Column();
                dtoAux.Task = 1;

                if (idProcesso == 0)
                    dtoAux.RegistryID = idRegistro;
                else if (idProcesso == 1)
                    dtoAux.RegistryHeaderID = idRegistro;
                else if (idProcesso == 2)
                    dtoAux.RegistryTrailerID = idRegistro;
                
                dtoAux.ColumnName = txtColumnName.Text;
                dtoAux.InitialPosition = Convert.ToInt64(txtInitialPosition.Text == "" ? "0" : txtInitialPosition.Text);
                dtoAux.ColumnSize = Convert.ToInt64(txtColumnSize.Text == "" ? "0" : txtColumnSize.Text);
                dtoAux.ColumnNumber = Convert.ToInt64(txtColumnNumber.Text == "" ? "0" : txtColumnNumber.Text);
                dtoAux.ColumnTypeID = Convert.ToInt64(ddlColumnTypeID.SelectedValue);
                dtoAux.ColumnValidation = Convert.ToBoolean(ddlColumnValidation.SelectedValue);
                dtoAux.ColumnStatus = Convert.ToBoolean(ddlColumnStatus.SelectedValue);
                dtoAux.DatabaseColumn = txtDatabaseColumn.Text;
                dtoAux.ColumnJoin = Convert.ToBoolean(ddlColumnJoin.SelectedValue);
                dtoAux.TextAlign = ddlTextAlign.SelectedValue;
                dtoAux.TextComplement = txtTextComplement.Text;
                dtoAux.DefaultValue = txtDefaultValue.Text;
                dtoAux.DefaultMandatory = Convert.ToBoolean(ddlDefaultMandatory.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYCOLUMN(dtoAux, objUsers);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro do Registro !! </div>" + eCadastro;
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtColumnName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtInitialPosition.Text != String.Empty)
                {
                    if (!objValidadores.isNumero(txtInitialPosition.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Posição Inicial</b> deve ser numerico !! </div>";
                        return;
                    }
                }

                if (txtColumnSize.Text != String.Empty)
                {
                    if (!objValidadores.isNumero(txtColumnSize.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico !! </div>";
                        return;
                    }
                }

                if (txtColumnNumber.Text != String.Empty)
                {
                    if (!objValidadores.isNumero(txtColumnNumber.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Coluna</b> deve ser numerico !! </div>";
                        return;
                    }
                }

          

                if (txtDatabaseColumn.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Coluna</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlColumnTypeID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                dtoImportExport_Column dtoAux = new dtoImportExport_Column();
                dtoAux.Task = 2;

                if (idProcesso == 0)
                    dtoAux.RegistryID = idRegistro;
                else if (idProcesso == 1)
                    dtoAux.RegistryHeaderID = idRegistro;
                else if (idProcesso == 2)
                    dtoAux.RegistryTrailerID = idRegistro;

                dtoAux.ColumnID = Convert.ToInt32(lblID.Text);
                dtoAux.ColumnName = txtColumnName.Text;
                dtoAux.InitialPosition = Convert.ToInt64(txtInitialPosition.Text);
                dtoAux.ColumnSize = Convert.ToInt64(txtColumnSize.Text);
                dtoAux.ColumnNumber = Convert.ToInt64(txtColumnNumber.Text);
                dtoAux.ColumnTypeID = Convert.ToInt64(ddlColumnTypeID.SelectedValue);
                dtoAux.ColumnValidation = Convert.ToBoolean(ddlColumnValidation.SelectedValue);
                dtoAux.ColumnStatus = Convert.ToBoolean(ddlColumnStatus.SelectedValue);
                dtoAux.DatabaseColumn = txtDatabaseColumn.Text;
                dtoAux.ColumnJoin = Convert.ToBoolean(ddlColumnJoin.SelectedValue);
                dtoAux.TextAlign = ddlTextAlign.SelectedValue;
                dtoAux.TextComplement = txtTextComplement.Text;
                dtoAux.DefaultValue = txtDefaultValue.Text;
                dtoAux.DefaultMandatory = Convert.ToBoolean(ddlDefaultMandatory.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYCOLUMN(dtoAux, objUsers);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Registro !! </div>" + eAlteracao;
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoImportExport_Column dtoAux = new dtoImportExport_Column();
                dtoAux.Task = 3;
                dtoAux.ColumnID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRYCOLUMN(dtoAux, objUsers);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão do Registro !! </div>" + eExclusao;
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
                txtColumnName.Text = "";
                txtInitialPosition.Text = "";
                txtColumnSize.Text = "";
                txtColumnNumber.Text = "";
                ddlColumnTypeID.SelectedValue = "";
                ddlColumnValidation.SelectedValue = "False";
                ddlColumnStatus.SelectedValue = "True";
                txtDatabaseColumn.Text = "";
                ddlColumnJoin.SelectedValue = "False";
                ddlTextAlign.SelectedValue = "R";
                txtTextComplement.Text = "";
                txtDefaultValue.Text = "";
                ddlDefaultMandatory.SelectedValue = "False";

            }
            catch
            {

            }
        }


    }
}
