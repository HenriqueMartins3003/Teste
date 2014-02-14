using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.Campanha
{
    public partial class RotasDialingRules : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllTelecom objTelecom = new bllTelecom();
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
                listPhoneClassification();
                listPhoneType();
                listPriority();
                listTrunkGroup();
                listRulesName();
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

        //lista todas as regras cadastradas
        protected void listRulesName()
        {
            ddlRuleName.DataSource = objTelecom.listRules();
            ddlRuleName.DataTextField = "Name";
            ddlRuleName.DataValueField = "IdRule";
            ddlRuleName.DataBind();
            ddlRuleName.Items.Insert(0, new ListItem("Rule ...", "0"));
        }

        protected void listTrunkGroup()
        {
            ddlTrunkGroup.DataSource = objTelecom.PAN_LISTTRUNKGROUP(objUsers);
            ddlTrunkGroup.DataTextField = "Numero";
            ddlTrunkGroup.DataValueField = "Numero";
            ddlTrunkGroup.DataBind();
            ddlTrunkGroup.Items.Insert(0, new ListItem("Rota ...", "0"));
        }

        protected void listPhoneType()
        {
            ddlPhoneType.DataSource = objTelecom.PAN_LISTPHONETYPE(objUsers);
            ddlPhoneType.DataTextField = "DescriptionType";
            ddlPhoneType.DataValueField = "IDType";
            ddlPhoneType.DataBind();
            ddlPhoneType.Items.Insert(0, new ListItem("Tipo ...", "-1"));
        }

        protected void listPhoneClassification()
        {
            ddlPhoneClassification.DataSource = objTelecom.PAN_LISTPHONECLASSIFICATION(objUsers);
            ddlPhoneClassification.DataTextField = "DescriptionClassification";
            ddlPhoneClassification.DataValueField = "IDClassification";
            ddlPhoneClassification.DataBind();
            ddlPhoneClassification.Items.Insert(0, new ListItem("Classificação ...", "-1"));
        }

        protected void listPriority()
        {
            int count = 9;
            while (count > -1)
            {
                ddlPriority.Items.Insert(0, new ListItem(count.ToString(), count.ToString()));
                count = count - 1;
            }
            //ddlPriority.Items.Insert(0, new ListItem("Prioridade ...", "0"));
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
            BoundField bfId = new BoundField();
            bfId.DataField = "Id";
            bfId.HeaderText = "Id";
            bfId.HeaderStyle.CssClass = "gridViewHeader1";
            bfId.ItemStyle.CssClass = "gridViewValues3";
            bfId.ItemStyle.Width = 50;
            bfId.Visible = false;
            bfId.SortExpression = "Id";
            gdRegistros.Columns.Add(bfId);

            BoundField bfIdRule = new BoundField();
            bfIdRule.DataField = "Name";
            bfIdRule.HeaderText = "Rule";
            bfIdRule.HeaderStyle.CssClass = "gridViewHeader1";
            bfIdRule.ItemStyle.CssClass = "gridViewValues3";
            bfIdRule.ItemStyle.Width = 50;
            bfIdRule.Visible = true;
            bfIdRule.SortExpression = "Name";
            gdRegistros.Columns.Add(bfIdRule);

            BoundField bfTrunkGroup = new BoundField();
            bfTrunkGroup.DataField = "TrunkGroup";
            bfTrunkGroup.HeaderText = "Rota";
            bfTrunkGroup.HeaderStyle.CssClass = "gridViewHeader1";
            bfTrunkGroup.ItemStyle.CssClass = "gridViewValues3";
            bfTrunkGroup.ItemStyle.Width = 50;
            bfTrunkGroup.Visible = true;
            bfTrunkGroup.SortExpression = "TrunkGroup";
            gdRegistros.Columns.Add(bfTrunkGroup);

            BoundField bfPhoneType = new BoundField();
            bfPhoneType.DataField = "PhoneType";
            bfPhoneType.HeaderText = "PhoneType";
            bfPhoneType.HeaderStyle.CssClass = "gridViewHeader1";
            bfPhoneType.ItemStyle.CssClass = "gridViewValues3";
            bfPhoneType.ItemStyle.Width = 50;
            bfPhoneType.Visible = false;
            bfPhoneType.SortExpression = "PhoneType";
            gdRegistros.Columns.Add(bfPhoneType);

            BoundField bfPhoneTypeDescription = new BoundField();
            bfPhoneTypeDescription.DataField = "PhoneTypeDescription";
            bfPhoneTypeDescription.HeaderText = "Tipo";
            bfPhoneTypeDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfPhoneTypeDescription.ItemStyle.CssClass = "gridViewValues3";
            bfPhoneTypeDescription.ItemStyle.Width = 100;
            bfPhoneTypeDescription.Visible = true;
            bfPhoneTypeDescription.SortExpression = "PhoneTypeDescription";
            gdRegistros.Columns.Add(bfPhoneTypeDescription);

            BoundField bfPhoneClassification = new BoundField();
            bfPhoneClassification.DataField = "PhoneClassification";
            bfPhoneClassification.HeaderText = "PhoneClassification";
            bfPhoneClassification.HeaderStyle.CssClass = "gridViewHeader1";
            bfPhoneClassification.ItemStyle.CssClass = "gridViewValues3";
            bfPhoneClassification.ItemStyle.Width = 50;
            bfPhoneClassification.Visible = false;
            bfPhoneClassification.SortExpression = "PhoneClassification";
            gdRegistros.Columns.Add(bfPhoneClassification);

            BoundField bfPhoneClassificationDescription = new BoundField();
            bfPhoneClassificationDescription.DataField = "PhoneClassificationDescription";
            bfPhoneClassificationDescription.HeaderText = "Classificação";
            bfPhoneClassificationDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfPhoneClassificationDescription.ItemStyle.CssClass = "gridViewValues3";
            bfPhoneClassificationDescription.ItemStyle.Width = 100;
            bfPhoneClassificationDescription.Visible = true;
            bfPhoneClassificationDescription.SortExpression = "PhoneClassificationDescription";
            gdRegistros.Columns.Add(bfPhoneClassificationDescription);

            BoundField bfPriority = new BoundField();
            bfPriority.DataField = "Priority";
            bfPriority.HeaderText = "Prioridade";
            bfPriority.HeaderStyle.CssClass = "gridViewHeader1";
            bfPriority.ItemStyle.CssClass = "gridViewValues3";
            bfPriority.ItemStyle.Width = 50;
            bfPriority.Visible = true;
            bfPriority.SortExpression = "Priority";
            gdRegistros.Columns.Add(bfPriority);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objTelecom.PAN_LISTDIALINGRULES(objUsers);
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
                lblID.Text = gdRegistros.DataKeys[index]["Id"].ToString();

                ddlRuleName.SelectedValue = gdRegistros.DataKeys[index]["idRule"].ToString();
                ddlTrunkGroup.SelectedValue = gdRegistros.DataKeys[index]["TrunkGroup"].ToString();
                ddlPhoneType.SelectedValue = gdRegistros.DataKeys[index]["PhoneType"].ToString();
                ddlPhoneClassification.SelectedValue = gdRegistros.DataKeys[index]["PhoneClassification"].ToString();
                ddlPriority.SelectedValue = gdRegistros.DataKeys[index]["Priority"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["Id"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["TrunkGroup"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objTelecom.PAN_LISTDIALINGRULES(objUsers);
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
                if (ddlTrunkGroup.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Rota</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlPhoneType.SelectedValue == "-1")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlPhoneClassification.SelectedValue == "-1")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Classificação</b> deve ser selecionado !! </div>";
                    return;
                }

                dtoTelecomDialingRules dtoAux = new dtoTelecomDialingRules();
                dtoAux.Task = 1;
                dtoAux.IdRule = Convert.ToInt64(ddlRuleName.SelectedValue);
                dtoAux.TrunkGroup = Convert.ToInt64(ddlTrunkGroup.SelectedValue);
                dtoAux.PhoneType = Convert.ToInt64(ddlPhoneType.SelectedValue);
                dtoAux.PhoneClassification = Convert.ToInt64(ddlPhoneClassification.SelectedValue);
                dtoAux.Priority = Convert.ToInt64(ddlPriority.SelectedValue);

                dtoResponse dtoResponse = objTelecom.PAN_MANAGERDIALINGRULES(dtoAux, objUsers);
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
                if (ddlTrunkGroup.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Rota</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlPhoneType.SelectedValue == "-1")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Tipo</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlPhoneClassification.SelectedValue == "-1")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Classificação</b> deve ser selecionado !! </div>";
                    return;
                }

                dtoTelecomDialingRules dtoAux = new dtoTelecomDialingRules();
                dtoAux.Task = 2;
                dtoAux.Id = Convert.ToInt32(lblID.Text);
                dtoAux.IdRule = Convert.ToInt64(ddlRuleName.SelectedValue);
                dtoAux.TrunkGroup = Convert.ToInt64(ddlTrunkGroup.SelectedValue);
                dtoAux.PhoneType = Convert.ToInt64(ddlPhoneType.SelectedValue);
                dtoAux.PhoneClassification = Convert.ToInt64(ddlPhoneClassification.SelectedValue);
                dtoAux.Priority = Convert.ToInt64(ddlPriority.SelectedValue);

                dtoResponse dtoResponse = objTelecom.PAN_MANAGERDIALINGRULES(dtoAux, objUsers);
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
                dtoTelecomDialingRules dtoAux = new dtoTelecomDialingRules();
                dtoAux.Task = 3;
                dtoAux.Id = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objTelecom.PAN_MANAGERDIALINGRULES(dtoAux, objUsers);
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
                ddlRuleName.SelectedValue = "0";
                ddlPhoneClassification.SelectedValue = "0";
                ddlPhoneType.SelectedValue = "-1";
                ddlPriority.SelectedValue = "-1";
                ddlTrunkGroup.SelectedValue = "0";
            }
            catch
            {

            }

        }

        protected void ddlPhoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPhoneType.SelectedValue == "3")
            {
                ddlPhoneClassification.SelectedValue = "0";
                ddlPhoneClassification.Enabled = false;
            }
            else
            {
                ddlPhoneClassification.Enabled = true;
            }
        }

        protected void ddlPhoneClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPhoneClassification.SelectedValue == "3")
            {
                ddlPhoneType.SelectedValue = "0";
                ddlPhoneType.Enabled = false;
            }
            else
            {
                ddlPhoneType.Enabled = true;
            }
        }
    }
}
