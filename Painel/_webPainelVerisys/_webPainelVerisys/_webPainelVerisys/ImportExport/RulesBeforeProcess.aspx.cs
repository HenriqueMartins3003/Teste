using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class RulesBeforeProcess : System.Web.UI.Page
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
                listProcess();
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

        protected void listProcess()
        {
            ddlProcessID.DataSource = objImportExport.UINT_LISTPROCESS();
            ddlProcessID.DataTextField = "ProcessName";
            ddlProcessID.DataValueField = "ProcessID";
            ddlProcessID.DataBind();
            ddlProcessID.Items.Insert(0, new ListItem("Processo ...", "0"));
        }

        protected void listCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Campanha ...", "0"));

            // Campanhas relacionadas.
            rCampanhasAssociadas.DataSource = objCampaign.listCampaignAssociated(objUsers);
            rCampanhasAssociadas.DataBind();
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
            bfRulesName.ItemStyle.Width = 200;
            bfRulesName.Visible = true;
            bfRulesName.SortExpression = "RulesName";
            gdRegistros.Columns.Add(bfRulesName);

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
            bfProcessName.HeaderText = "Processo";
            bfProcessName.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessName.ItemStyle.CssClass = "gridViewValues2";
            bfProcessName.ItemStyle.Width = 200;
            bfProcessName.Visible = true;
            bfProcessName.SortExpression = "ProcessName";
            gdRegistros.Columns.Add(bfProcessName);

            BoundField bfCampaign = new BoundField();
            bfCampaign.DataField = "Campaign";
            bfCampaign.HeaderText = "Campanha";
            bfCampaign.HeaderStyle.CssClass = "gridViewHeader1";
            bfCampaign.ItemStyle.CssClass = "gridViewValues3";
            bfCampaign.ItemStyle.Width = 100;
            bfCampaign.Visible = true;
            bfCampaign.SortExpression = "Campaign";
            gdRegistros.Columns.Add(bfCampaign);

            BoundField bfDisableAncientID = new BoundField();
            bfDisableAncientID.DataField = "DisableAncientID";
            bfDisableAncientID.HeaderText = "DisableAncientID";
            bfDisableAncientID.HeaderStyle.CssClass = "gridViewHeader1";
            bfDisableAncientID.ItemStyle.CssClass = "gridViewValues3";
            bfDisableAncientID.ItemStyle.Width = 50;
            bfDisableAncientID.Visible = false;
            bfDisableAncientID.SortExpression = "DisableAncientID";
            gdRegistros.Columns.Add(bfDisableAncientID);

            BoundField bfDisableAncientIDDescription = new BoundField();
            bfDisableAncientIDDescription.DataField = "DisableAncientIDDescription";
            bfDisableAncientIDDescription.HeaderText = "Desabilita";
            bfDisableAncientIDDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfDisableAncientIDDescription.ItemStyle.CssClass = "gridViewValues3";
            bfDisableAncientIDDescription.ItemStyle.Width = 100;
            bfDisableAncientIDDescription.Visible = true;
            bfDisableAncientIDDescription.SortExpression = "DisableAncientIDDescription";
            gdRegistros.Columns.Add(bfDisableAncientIDDescription);

            BoundField bfRulesStatus = new BoundField();
            bfRulesStatus.DataField = "RulesStatus";
            bfRulesStatus.HeaderText = "RulesStatus";
            bfRulesStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesStatus.ItemStyle.CssClass = "gridViewValues3";
            bfRulesStatus.ItemStyle.Width = 50;
            bfRulesStatus.Visible = false;
            bfRulesStatus.SortExpression = "RulesStatus";
            gdRegistros.Columns.Add(bfRulesStatus);

            BoundField bfRulesStatusDescription = new BoundField();
            bfRulesStatusDescription.DataField = "RulesStatusDescription";
            bfRulesStatusDescription.HeaderText = "Ativo?";
            bfRulesStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfRulesStatusDescription.ItemStyle.Width = 100;
            bfRulesStatusDescription.Visible = true;
            bfRulesStatusDescription.SortExpression = "RulesStatusDescription";
            gdRegistros.Columns.Add(bfRulesStatusDescription);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTRULESBEFOREPROCESS(objUsers);
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
                lblID.Text = gdRegistros.DataKeys[index]["RulesID"].ToString();

                txtRulesName.Text = gdRegistros.DataKeys[index]["RulesName"].ToString();
                ddlCampaign.SelectedValue = gdRegistros.DataKeys[index]["Campaign"].ToString();
                ddlDisableAncientID.SelectedValue = gdRegistros.DataKeys[index]["DisableAncientID"].ToString();
                ddlRulesStatus.SelectedValue = gdRegistros.DataKeys[index]["RulesStatus"].ToString();
                ddlProcessID.SelectedValue = gdRegistros.DataKeys[index]["ProcessID"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["RulesID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["RulesName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTRULESBEFOREPROCESS(objUsers);
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
                if (txtRulesName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlProcessID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Processo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlCampaign.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Campanha</b> deve ser selecionado !! </div>";
                    return;
                }

                String strAssociadas = "";
                foreach (RepeaterItem ri in rCampanhasAssociadas.Items)
                {
                    Label ID = (Label)ri.FindControl("lblIDCampanhaAssociada");
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkCampanha");

                    if (ckBox.Checked == true)
                    {
                        strAssociadas += ID.Text + ",";
                    }
                }
                if (!String.IsNullOrEmpty(strAssociadas))
                {
                    strAssociadas = strAssociadas.Substring(0, strAssociadas.Length - 1);
                }

                dtoImportExport_RulesBeforeProcess dtoAux = new dtoImportExport_RulesBeforeProcess();
                dtoAux.Task = 1;
                dtoAux.RulesName = txtRulesName.Text;
                dtoAux.ProcessID = Convert.ToInt64(ddlProcessID.SelectedValue);
                dtoAux.Campaign = ddlCampaign.SelectedValue;
                dtoAux.DisableAncientID = Convert.ToBoolean(ddlDisableAncientID.SelectedValue);
                dtoAux.RulesStatus = Convert.ToBoolean(ddlRulesStatus.SelectedValue.ToString());
                dtoAux.CampanhasAssociadas = strAssociadas;

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULESBEFOREPROCESS(dtoAux, objUsers);
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
                if (txtRulesName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlProcessID.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Processo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlCampaign.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Campanha</b> deve ser selecionado !! </div>";
                    return;
                }

                String strAssociadas = "";
                foreach (RepeaterItem ri in rCampanhasAssociadas.Items)
                {
                    Label ID = (Label)ri.FindControl("lblIDCampanhaAssociada");
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkCampanha");

                    if (ckBox.Checked == true)
                    {
                        strAssociadas += ID.Text + ",";
                    }
                }
                if (!String.IsNullOrEmpty(strAssociadas))
                {
                    strAssociadas = strAssociadas.Substring(0, strAssociadas.Length - 1);
                }

                dtoImportExport_RulesBeforeProcess dtoAux = new dtoImportExport_RulesBeforeProcess();
                dtoAux.Task = 2;
                dtoAux.RulesID = Convert.ToInt64(lblID.Text);
                dtoAux.RulesName = txtRulesName.Text;
                dtoAux.ProcessID = Convert.ToInt64(ddlProcessID.SelectedValue);
                dtoAux.Campaign = ddlCampaign.SelectedValue;
                dtoAux.DisableAncientID = Convert.ToBoolean(ddlDisableAncientID.SelectedValue);
                dtoAux.RulesStatus = Convert.ToBoolean(ddlRulesStatus.SelectedValue.ToString());
                dtoAux.CampanhasAssociadas = strAssociadas;

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULESBEFOREPROCESS(dtoAux, objUsers);
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
                dtoImportExport_RulesBeforeProcess dtoAux = new dtoImportExport_RulesBeforeProcess();
                dtoAux.Task = 3;
                dtoAux.RulesID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULESBEFOREPROCESS(dtoAux, objUsers);
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
                txtRulesName.Text = "";
                ddlProcessID.SelectedValue = "0";
                ddlCampaign.SelectedValue = "0";
                ddlDisableAncientID.SelectedValue = "0";
                ddlRulesStatus.SelectedValue = "";
            }
            catch
            {

            }
        }


    }
}
