using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _webPainelVerisys.DTO;
using _webPainelVerisys.BLL;
using clsTools;
using System.Data;

namespace _webPainelVerisys.Campanha
{
    public partial class GruposDacPermissao : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllTelecom objTelecom = new bllTelecom();
        GruposDac objGrupoDAC = new GruposDac();
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
                gdRegistros_List();
                listGrupoDAC();
                listPhoneClassification();
                listPhoneType();

            }
        }

        private void PageConfig()
        {
            dtoPageConfig objdtoPageConfig = null;
            bllPageConfig objPageConfig = new bllPageConfig();

            String strApplication = Session["ObjApplication"].ToString();
            objdtoPageConfig = objPageConfig.listPageConfig(this.Form.ID, strApplication);

            lblTitulo.Text = objdtoPageConfig.Descricao;

        }


        protected void listGrupoDAC()
        {
            ddlGrupoDac.DataSource = objGrupoDAC.listGruposDacFull(objUsers);
            ddlGrupoDac.DataTextField = "NomeGrupoDac";
            ddlGrupoDac.DataValueField = "GrupoDAC";
            ddlGrupoDac.DataBind();
            ddlGrupoDac.Items.Insert(0, new ListItem("Grupo DAC ...", "0"));
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


        protected void gdRegistros_List()
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
            bfId.DataField = "IDGrupoDACRestricao";
            bfId.HeaderText = "Grupo DAC";
            bfId.HeaderStyle.CssClass = "gridViewHeader1";
            bfId.ItemStyle.CssClass = "gridViewValues3";
            bfId.ItemStyle.Width = 50;
            bfId.Visible = false;
            bfId.SortExpression = "IDGrupoDACRestricao";
            gdRegistros.Columns.Add(bfId);


            BoundField bfIdGrupo = new BoundField();
            bfIdGrupo.DataField = "GrupoDAC";
            bfIdGrupo.HeaderText = "Grupo DAC";
            bfIdGrupo.HeaderStyle.CssClass = "gridViewHeader1";
            bfIdGrupo.ItemStyle.CssClass = "gridViewValues3";
            bfIdGrupo.ItemStyle.Width = 50;
            bfIdGrupo.Visible = true;
            bfIdGrupo.SortExpression = "GrupoDAC";
            gdRegistros.Columns.Add(bfIdGrupo);

            BoundField bfTipo = new BoundField();
            bfTipo.DataField = "DescriptionType";
            bfTipo.HeaderText = "Tipo";
            bfTipo.HeaderStyle.CssClass = "gridViewHeader1";
            bfTipo.ItemStyle.CssClass = "gridViewValues3";
            bfTipo.ItemStyle.Width = 50;
            bfTipo.Visible = true;
            bfTipo.SortExpression = "DescriptionType";
            gdRegistros.Columns.Add(bfTipo);

            BoundField bfClassificacao = new BoundField();
            bfClassificacao.DataField = "DescriptionClassification";
            bfClassificacao.HeaderText = "Classificação";
            bfClassificacao.HeaderStyle.CssClass = "gridViewHeader1";
            bfClassificacao.ItemStyle.CssClass = "gridViewValues3";
            bfClassificacao.ItemStyle.Width = 50;
            bfClassificacao.Visible = true;
            bfClassificacao.SortExpression = "DescriptionClassification";
            gdRegistros.Columns.Add(bfClassificacao);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objGrupoDAC.listGrupoDacPermission(objUsers);
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
                lblID.Text = gdRegistros.DataKeys[index]["IDGrupoDACRestricao"].ToString();

                ddlGrupoDac.SelectedValue = gdRegistros.DataKeys[index]["GrupoDAC"].ToString();
                ddlPhoneType.SelectedValue = gdRegistros.DataKeys[index]["IDType"].ToString();
                ddlPhoneClassification.SelectedValue = gdRegistros.DataKeys[index]["Classificacao"].ToString();



                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["IDGrupoDACRestricao"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["IDGrupoDACRestricao"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objGrupoDAC.listGrupoDacPermission(objUsers);
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
            gdRegistros_List();
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

                dtoGrupoDacPermission dtoAux = new dtoGrupoDacPermission();
                dtoAux.Task = 1;
                dtoAux.GrupoDAC = Convert.ToInt32(ddlGrupoDac.SelectedValue);
                dtoAux.Tipo = Convert.ToInt32(ddlPhoneType.SelectedValue);
                dtoAux.Classificacao = Convert.ToInt32(ddlPhoneClassification.SelectedValue);

                dtoResponse dtoResponse = objGrupoDAC.MANAGERGRUPODACPERMISSION(dtoAux);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro do Registro !! " + eCadastro + "</div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {


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

                dtoGrupoDacPermission dtoAux = new dtoGrupoDacPermission();
                dtoAux.Task = 2;
                dtoAux.IdGrupoDACRestricao = Convert.ToInt32(lblID.Text);
                dtoAux.GrupoDAC = Convert.ToInt32(ddlGrupoDac.SelectedValue);
                dtoAux.Tipo = Convert.ToInt32(ddlPhoneType.SelectedValue);
                dtoAux.Classificacao = Convert.ToInt32(ddlPhoneClassification.SelectedValue);

                dtoResponse dtoResponse = objGrupoDAC.MANAGERGRUPODACPERMISSION(dtoAux);

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
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Registro !! " + eAlteracao + "</div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoGrupoDacPermission dtoAux = new dtoGrupoDacPermission();
                dtoAux.Task = 3;
                dtoAux.IdGrupoDACRestricao = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objGrupoDAC.MANAGERGRUPODACPERMISSION(dtoAux);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão do Registro !!" + eExclusao + " </div>";
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
                gdRegistros_List();

                // CAMPOS
                ddlPhoneClassification.SelectedValue = "0";
                ddlPhoneType.SelectedValue = "-1";
            }
            catch
            {

            }

        }



    }
}
