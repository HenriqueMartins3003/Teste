using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class Process : System.Web.UI.Page
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
                listRegistry();
                ListRegistryHeader();
                listRegistryTrailer();
                listRules();
                listProcessType();
                listExecutionPlan();
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

        protected void listRegistry()
        {
            ddlRegistryID.DataSource = objImportExport.UINT_LISTREGISTRY();
            ddlRegistryID.DataTextField = "RegistryName";
            ddlRegistryID.DataValueField = "RegistryID";
            ddlRegistryID.DataBind();
            ddlRegistryID.Items.Insert(0, new ListItem("Registry ...", "0"));
        }

        protected void ListRegistryHeader()
        {
            ddlRegistryHeaderID.DataSource = objImportExport.UINT_LISTREGISTRYHEADER();
            ddlRegistryHeaderID.DataTextField = "HeaderName";
            ddlRegistryHeaderID.DataValueField = "HeaderID";
            ddlRegistryHeaderID.DataBind();
            ddlRegistryHeaderID.Items.Insert(0, new ListItem("Header ...", "0"));
        }

        protected void listRegistryTrailer()
        {
            ddlRegistryTrailerID.DataSource = objImportExport.UINT_LISTREGISTRYTRAILER();
            ddlRegistryTrailerID.DataTextField = "TrailerName";
            ddlRegistryTrailerID.DataValueField = "TrailerID";
            ddlRegistryTrailerID.DataBind();
            ddlRegistryTrailerID.Items.Insert(0, new ListItem("Trailer ...", "0"));
        }

        protected void listRules()
        {
            ddlRulesID.DataSource = objImportExport.UINT_LISTRULES();
            ddlRulesID.DataTextField = "RulesName";
            ddlRulesID.DataValueField = "RulesID";
            ddlRulesID.DataBind();
            ddlRulesID.Items.Insert(0, new ListItem("Rules ...", "0"));
        }

        protected void listProcessType()
        {
            ddlProcessTypeID.DataSource = objImportExport.UINT_LISTPROCESSTYPE();
            ddlProcessTypeID.DataTextField = "ProcessTypeName";
            ddlProcessTypeID.DataValueField = "ProcessTypeID";
            ddlProcessTypeID.DataBind();
            ddlProcessTypeID.Items.Insert(0, new ListItem("Tipo ...", "0"));
        }

        protected void listExecutionPlan()
        {
            ddlExecutionPlanID.DataSource = objImportExport.UINT_LISTEXECUTIONPLAN();
            ddlExecutionPlanID.DataTextField = "ExecutionPlan";
            ddlExecutionPlanID.DataValueField = "ExecutionPlanID";
            ddlExecutionPlanID.DataBind();
            ddlExecutionPlanID.Items.Insert(0, new ListItem("ExecutionPlan ...", "0"));
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

            ButtonField btnGear = new ButtonField();
            btnGear.ButtonType = ButtonType.Image;
            btnGear.ImageUrl = "../img/gear_16.png";
            btnGear.CommandName = "Gear";
            btnGear.ItemStyle.Width = 25;
            btnGear.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnGear.HeaderText = "";
            btnGear.HeaderStyle.CssClass = "gridViewHeader";
            btnGear.Visible = true;
            gdRegistros.Columns.Add(btnGear);

            
            // Campos
            BoundField bfProcessID = new BoundField();
            bfProcessID.DataField = "ProcessID";
            bfProcessID.HeaderText = "ProcessID";
            bfProcessID.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessID.ItemStyle.CssClass = "gridViewValues3";
            bfProcessID.ItemStyle.Width = 50;
            bfProcessID.Visible = false;
            bfProcessID.SortExpression = "ProcessID";
            gdRegistros.Columns.Add(bfProcessID);

            BoundField bfProcessName = new BoundField();
            bfProcessName.DataField = "ProcessName";
            bfProcessName.HeaderText = "Nome";
            bfProcessName.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessName.ItemStyle.CssClass = "gridViewValues2";
            bfProcessName.ItemStyle.Width = 100;
            bfProcessName.Visible = true;
            bfProcessName.SortExpression = "ProcessName";
            gdRegistros.Columns.Add(bfProcessName);

            BoundField bfProcessDescription = new BoundField();
            bfProcessDescription.DataField = "ProcessDescription";
            bfProcessDescription.HeaderText = "Descrição";
            bfProcessDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessDescription.ItemStyle.CssClass = "gridViewValues3";
            bfProcessDescription.ItemStyle.Width = 50;
            bfProcessDescription.Visible = false;
            bfProcessDescription.SortExpression = "ProcessDescription";
            gdRegistros.Columns.Add(bfProcessDescription);

            BoundField bfProcessTypeID = new BoundField();
            bfProcessTypeID.DataField = "ProcessTypeID";
            bfProcessTypeID.HeaderText = "ProcessTypeID";
            bfProcessTypeID.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessTypeID.ItemStyle.CssClass = "gridViewValues3";
            bfProcessTypeID.ItemStyle.Width = 50;
            bfProcessTypeID.Visible = false;
            bfProcessTypeID.SortExpression = "ProcessTypeID";
            gdRegistros.Columns.Add(bfProcessTypeID);

            BoundField bfProcessTypeName = new BoundField();
            bfProcessTypeName.DataField = "ProcessTypeName";
            bfProcessTypeName.HeaderText = "Tipo";
            bfProcessTypeName.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessTypeName.ItemStyle.CssClass = "gridViewValues3";
            bfProcessTypeName.ItemStyle.Width = 100;
            bfProcessTypeName.Visible = true;
            bfProcessTypeName.SortExpression = "ProcessTypeName";
            gdRegistros.Columns.Add(bfProcessTypeName);

            BoundField bfLotMask = new BoundField();
            bfLotMask.DataField = "LotMask";
            bfLotMask.HeaderText = "Mascara";
            bfLotMask.HeaderStyle.CssClass = "gridViewHeader1";
            bfLotMask.ItemStyle.CssClass = "gridViewValues3";
            bfLotMask.ItemStyle.Width = 50;
            bfLotMask.Visible = true;
            bfLotMask.SortExpression = "LotMask";
            gdRegistros.Columns.Add(bfLotMask);

            BoundField bfLotControlbyCampaign = new BoundField();
            bfLotControlbyCampaign.DataField = "LotControlbyCampaign";
            bfLotControlbyCampaign.HeaderText = "Campanha";
            bfLotControlbyCampaign.HeaderStyle.CssClass = "gridViewHeader1";
            bfLotControlbyCampaign.ItemStyle.CssClass = "gridViewValues3";
            bfLotControlbyCampaign.ItemStyle.Width = 50;
            bfLotControlbyCampaign.Visible = true;
            bfLotControlbyCampaign.SortExpression = "LotControlbyCampaign";
            gdRegistros.Columns.Add(bfLotControlbyCampaign);

            BoundField bfRegistryHeaderID = new BoundField();
            bfRegistryHeaderID.DataField = "RegistryHeaderID";
            bfRegistryHeaderID.HeaderText = "Header";
            bfRegistryHeaderID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryHeaderID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryHeaderID.ItemStyle.Width = 50;
            bfRegistryHeaderID.Visible = true;
            bfRegistryHeaderID.SortExpression = "RegistryHeaderID";
            gdRegistros.Columns.Add(bfRegistryHeaderID);

            BoundField bfRegistryTrailerID = new BoundField();
            bfRegistryTrailerID.DataField = "RegistryTrailerID";
            bfRegistryTrailerID.HeaderText = "Trailer";
            bfRegistryTrailerID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryTrailerID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryTrailerID.ItemStyle.Width = 50;
            bfRegistryTrailerID.Visible = true;
            bfRegistryTrailerID.SortExpression = "RegistryTrailerID";
            gdRegistros.Columns.Add(bfRegistryTrailerID);

            BoundField bfRegistryID = new BoundField();
            bfRegistryID.DataField = "RegistryID";
            bfRegistryID.HeaderText = "Registry";
            bfRegistryID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryID.ItemStyle.Width = 50;
            bfRegistryID.Visible = true;
            bfRegistryID.SortExpression = "RegistryID";
            gdRegistros.Columns.Add(bfRegistryID);

            BoundField bfRulesID = new BoundField();
            bfRulesID.DataField = "RulesID";
            bfRulesID.HeaderText = "Regras";
            bfRulesID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesID.ItemStyle.CssClass = "gridViewValues3";
            bfRulesID.ItemStyle.Width = 50;
            bfRulesID.Visible = true;
            bfRulesID.SortExpression = "RulesID";
            gdRegistros.Columns.Add(bfRulesID);

            BoundField bfExecutionPlanID = new BoundField();
            bfExecutionPlanID.DataField = "ExecutionPlanID";
            bfExecutionPlanID.HeaderText = "ExecutionPlan";
            bfExecutionPlanID.HeaderStyle.CssClass = "gridViewHeader1";
            bfExecutionPlanID.ItemStyle.CssClass = "gridViewValues3";
            bfExecutionPlanID.ItemStyle.Width = 50;
            bfExecutionPlanID.Visible = true;
            bfExecutionPlanID.SortExpression = "ExecutionPlanID";
            gdRegistros.Columns.Add(bfExecutionPlanID);

            BoundField bfProcessStatus = new BoundField();
            bfProcessStatus.DataField = "ProcessStatus";
            bfProcessStatus.HeaderText = "ProcessStatus";
            bfProcessStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessStatus.ItemStyle.CssClass = "gridViewValues3";
            bfProcessStatus.ItemStyle.Width = 50;
            bfProcessStatus.Visible = false;
            bfProcessStatus.SortExpression = "ProcessStatus";
            gdRegistros.Columns.Add(bfProcessStatus);

            BoundField bfProcessStatusDescription = new BoundField();
            bfProcessStatusDescription.DataField = "ProcessStatusDescription";
            bfProcessStatusDescription.HeaderText = "Ativo?";
            bfProcessStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfProcessStatusDescription.ItemStyle.Width = 50;
            bfProcessStatusDescription.Visible = false;
            bfProcessStatusDescription.SortExpression = "ProcessStatusDescription";
            gdRegistros.Columns.Add(bfProcessStatusDescription);
            
            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTPROCESS(objUsers);
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
                modSchedule.Visible = false;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração";
                lblID.Text = gdRegistros.DataKeys[index]["ProcessID"].ToString();

                txtProcessName.Text = gdRegistros.DataKeys[index]["ProcessName"].ToString();
                txtProcessDescription.Text = gdRegistros.DataKeys[index]["ProcessDescription"].ToString();
                ddlProcessTypeID.SelectedValue = gdRegistros.DataKeys[index]["ProcessTypeID"].ToString();
                txtLotMask.Text = gdRegistros.DataKeys[index]["LotMask"].ToString();
                ddlLotControlbyCampaign.SelectedValue = gdRegistros.DataKeys[index]["LotControlbyCampaign"].ToString();
                ddlRegistryHeaderID.SelectedValue = gdRegistros.DataKeys[index]["RegistryHeaderID"].ToString();
                ddlRegistryTrailerID.SelectedValue = gdRegistros.DataKeys[index]["RegistryTrailerID"].ToString();
                ddlRegistryID.SelectedValue = gdRegistros.DataKeys[index]["RegistryID"].ToString();
                ddlRulesID.SelectedValue = gdRegistros.DataKeys[index]["RulesID"].ToString();
                ddlExecutionPlanID.SelectedValue = gdRegistros.DataKeys[index]["ExecutionPlanID"].ToString();
                ddlProcessStatus.SelectedValue = gdRegistros.DataKeys[index]["ProcessStatus"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                modSchedule.Visible = false;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["ProcessID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["ProcessName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Gear")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = false;
                modSchedule.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Execução";
                lblID.Text = gdRegistros.DataKeys[index]["ProcessID"].ToString();
                lblProcessSchedule.Text = gdRegistros.DataKeys[index]["ProcessName"].ToString();
                lblProcessType.Text = gdRegistros.DataKeys[index]["ProcessTypeName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTPROCESS(objUsers);
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
            else if (lblTituloDiv.Text == "Execução")
            {
                Execucao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (txtProcessName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlProcessTypeID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlRegistryID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Registry</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlRulesID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Regras</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlExecutionPlanID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Execution Plan</b> deve ser selecionado !! </div>";
                    return;
                }

                dtoImportExport_Process dtoAux = new dtoImportExport_Process();
                dtoAux.Task = 1;
                dtoAux.ProcessName = txtProcessName.Text;;
                dtoAux.ProcessDescription = txtProcessDescription.Text;
                dtoAux.ProcessTypeID = Convert.ToInt64(ddlProcessTypeID.SelectedValue);
                dtoAux.LotMask = txtLotMask.Text;
                dtoAux.LotControlbyCampaign = Convert.ToBoolean(ddlLotControlbyCampaign.SelectedValue);
                dtoAux.RegistryHeaderID = Convert.ToInt64(ddlRegistryHeaderID.SelectedValue);
                dtoAux.RegistryTrailerID = Convert.ToInt64(ddlRegistryTrailerID.SelectedValue);
                dtoAux.RegistryID = Convert.ToInt64(ddlRegistryID.SelectedValue);
                dtoAux.RulesID = Convert.ToInt64(ddlRulesID.SelectedValue);
                dtoAux.ExecutionPlanID = Convert.ToInt64(ddlExecutionPlanID.SelectedValue);
                dtoAux.ProcessStatus = Convert.ToBoolean(ddlProcessStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_PROCESS(dtoAux, objUsers);
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
                if (txtProcessName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlProcessTypeID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlRegistryID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Registry</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlRulesID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Regras</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlExecutionPlanID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Execution Plan</b> deve ser selecionado !! </div>";
                    return;
                }

                dtoImportExport_Process dtoAux = new dtoImportExport_Process();
                dtoAux.Task = 2;
                dtoAux.ProcessID = Convert.ToInt32(lblID.Text);
                dtoAux.ProcessName = txtProcessName.Text; ;
                dtoAux.ProcessDescription = txtProcessDescription.Text;
                dtoAux.ProcessTypeID = Convert.ToInt64(ddlProcessTypeID.SelectedValue);
                dtoAux.LotMask = txtLotMask.Text;
                dtoAux.LotControlbyCampaign = Convert.ToBoolean(ddlLotControlbyCampaign.SelectedValue);
                dtoAux.RegistryHeaderID = Convert.ToInt64(ddlRegistryHeaderID.SelectedValue);
                dtoAux.RegistryTrailerID = Convert.ToInt64(ddlRegistryTrailerID.SelectedValue);
                dtoAux.RegistryID = Convert.ToInt64(ddlRegistryID.SelectedValue);
                dtoAux.RulesID = Convert.ToInt64(ddlRulesID.SelectedValue);
                dtoAux.ExecutionPlanID = Convert.ToInt64(ddlExecutionPlanID.SelectedValue);
                dtoAux.ProcessStatus = Convert.ToBoolean(ddlProcessStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_PROCESS(dtoAux, objUsers);
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
                dtoImportExport_Process dtoAux = new dtoImportExport_Process();
                dtoAux.Task = 3;
                dtoAux.ProcessID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_PROCESS(dtoAux, objUsers);
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
                modSchedule.Visible = false;
                gdRegistros_Lista();

                // CAMPOS
                txtProcessName.Text = "";
                txtProcessDescription.Text = "";
                ddlProcessTypeID.SelectedValue = "0";
                txtLotMask.Text = "";
                ddlLotControlbyCampaign.SelectedValue = "0";
                ddlRegistryHeaderID.SelectedValue = "0";
                ddlRegistryTrailerID.SelectedValue = "0";
                ddlRegistryID.SelectedValue = "0";
                ddlRulesID.SelectedValue = "0";
                ddlExecutionPlanID.SelectedValue = "0";
                ddlProcessStatus.SelectedValue = "0";

            }
            catch
            {

            }
        }

        protected void Execucao()
        {
            try
            {
                dtoImportExport_Process dtoAux = new dtoImportExport_Process();
                dtoAux.ProcessID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.SP_EXECUTIONPLAN(dtoAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    DateTime dt = Convert.ToDateTime(dtoResponse.Result.Substring(dtoResponse.Result.IndexOf('|') + 1));
                    lblResponse.Text = "<div class='ROK'> Processo Ativado com sucesso !! Primeira execução em <b> " + dt.ToString("dd/MM/yyyy hh:mm:ss") + " </b> </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Ativação do Processo !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Ativação do Processo !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void gdRegistros_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView oGridView = (GridView)sender;
                GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell oTableCell = new TableCell();

                // Coluna 1
                oTableCell.Text = "";
                oTableCell.ColumnSpan = 4;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);

                oTableCell = new TableCell();
                oTableCell.Text = "Lote";
                oTableCell.ColumnSpan = 2;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

                oTableCell = new TableCell();
                oTableCell.Text = "";
                oTableCell.ColumnSpan = 6;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
            }
        }
    }
}
