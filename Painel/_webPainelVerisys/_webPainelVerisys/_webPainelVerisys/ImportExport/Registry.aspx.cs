﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.ImportExport
{
    public partial class Registry : System.Web.UI.Page
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
            BoundField bfRegistryID = new BoundField();
            bfRegistryID.DataField = "RegistryID";
            bfRegistryID.HeaderText = "ID";
            bfRegistryID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryID.ItemStyle.Width = 50;
            bfRegistryID.Visible = false;
            gdRegistros.Columns.Add(bfRegistryID);

            BoundField bfRegistryName = new BoundField();
            bfRegistryName.DataField = "RegistryName";
            bfRegistryName.HeaderText = "Nome";
            bfRegistryName.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryName.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryName.ItemStyle.Width = 200;
            bfRegistryName.Visible = true;
            bfRegistryName.SortExpression = "RegistryName";
            gdRegistros.Columns.Add(bfRegistryName);

            BoundField bfRegistrySeparator = new BoundField();
            bfRegistrySeparator.DataField = "RegistrySeparator";
            bfRegistrySeparator.HeaderText = "Separador";
            bfRegistrySeparator.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistrySeparator.ItemStyle.CssClass = "gridViewValues3";
            bfRegistrySeparator.ItemStyle.Width = 100;
            bfRegistrySeparator.Visible = true;
            bfRegistrySeparator.SortExpression = "RegistrySeparator";
            gdRegistros.Columns.Add(bfRegistrySeparator);

            BoundField bfRegistryLineSize = new BoundField();
            bfRegistryLineSize.DataField = "RegistryLineSize";
            bfRegistryLineSize.HeaderText = "Tamanho";
            bfRegistryLineSize.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryLineSize.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryLineSize.ItemStyle.Width = 100;
            bfRegistryLineSize.Visible = true;
            bfRegistryLineSize.SortExpression = "RegistryLineSize";
            gdRegistros.Columns.Add(bfRegistryLineSize);

            BoundField bfRegistryInitialLine = new BoundField();
            bfRegistryInitialLine.DataField = "RegistryInitialLine";
            bfRegistryInitialLine.HeaderText = "Linha";
            bfRegistryInitialLine.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryInitialLine.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryInitialLine.ItemStyle.Width = 100;
            bfRegistryInitialLine.Visible = true;
            bfRegistryInitialLine.SortExpression = "RegistryInitialLine";
            gdRegistros.Columns.Add(bfRegistryInitialLine);

            BoundField bfRegistryStatusID = new BoundField();
            bfRegistryStatusID.DataField = "RegistryStatusID";
            bfRegistryStatusID.HeaderText = "RegistryStatusID";
            bfRegistryStatusID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryStatusID.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryStatusID.ItemStyle.Width = 50;
            bfRegistryStatusID.Visible = false;
            bfRegistryStatusID.SortExpression = "RegistryStatusID";
            gdRegistros.Columns.Add(bfRegistryStatusID);

            BoundField bfRegistryStatus = new BoundField();
            bfRegistryStatus.DataField = "RegistryStatus";
            bfRegistryStatus.HeaderText = "Ativo ?";
            bfRegistryStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryStatus.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryStatus.ItemStyle.Width = 100;
            bfRegistryStatus.Visible = true;
            bfRegistryStatus.SortExpression = "RegistryStatus";
            gdRegistros.Columns.Add(bfRegistryStatus);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTREGISTRY(objUsers);
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
        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTREGISTRY(objUsers);
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
        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencao.Visible = true;
                modExcluir.Visible = false;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração";
                lblID.Text = gdRegistros.DataKeys[index]["RegistryID"].ToString();

                txtRegistryName.Text = gdRegistros.DataKeys[index]["RegistryName"].ToString();
                txtRegistrySeparator.Text = gdRegistros.DataKeys[index]["RegistrySeparator"].ToString();
                txtRegistryLineSize.Text = gdRegistros.DataKeys[index]["RegistryLineSize"].ToString();
                txtRegistryInitialLine.Text = gdRegistros.DataKeys[index]["RegistryInitialLine"].ToString();
                ddlRegistryStatus.SelectedValue = gdRegistros.DataKeys[index]["RegistryStatusID"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["RegistryID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["RegistryName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Col")
            {
                int index = int.Parse((string)e.CommandArgument);
                Response.Redirect("Columns.aspx?Processo=0&Registro=" + gdRegistros.DataKeys[index]["RegistryID"].ToString());
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
                if (txtRegistryName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if ((txtRegistryInitialLine.Text == String.Empty) || (!objValidadores.isNumero(txtRegistryInitialLine.Text)))
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Linha</b> deve ser numerico e não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtRegistrySeparator.Text == String.Empty)
                {
                    if ((txtRegistryLineSize.Text == String.Empty) && (!objValidadores.isNumero(txtRegistryInitialLine.Text)))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                        return;
                    }
                }

                dtoImportExport_Registry dtoAuxIERegistry = new dtoImportExport_Registry();
                dtoAuxIERegistry.Task = 1;
                dtoAuxIERegistry.RegistryName = txtRegistryName.Text;
                dtoAuxIERegistry.RegistrySeparator = txtRegistrySeparator.Text;
                dtoAuxIERegistry.RegistryLineSize = Convert.ToInt32(txtRegistryLineSize.Text == "" ? "0" : txtRegistryLineSize.Text);
                dtoAuxIERegistry.RegistryInitialLine = Convert.ToInt32(txtRegistryInitialLine.Text);
                dtoAuxIERegistry.RegistryStatus = Convert.ToBoolean(ddlRegistryStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRY(dtoAuxIERegistry, objUsers);
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
                if (txtRegistryName.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if ((txtRegistryInitialLine.Text == String.Empty) || (!objValidadores.isNumero(txtRegistryInitialLine.Text)))
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Linha</b> deve ser numerico e não pode ficar em Branco !! </div>";
                    return;
                }

                if (txtRegistrySeparator.Text == String.Empty)
                {
                    if ((txtRegistryLineSize.Text == String.Empty) && (!objValidadores.isNumero(txtRegistryInitialLine.Text)))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                        return;
                    }
                }

                dtoImportExport_Registry dtoAuxIERegistry = new dtoImportExport_Registry();
                dtoAuxIERegistry.Task = 2;
                dtoAuxIERegistry.RegistryID = Convert.ToInt32(lblID.Text);
                dtoAuxIERegistry.RegistryName = txtRegistryName.Text;
                dtoAuxIERegistry.RegistrySeparator = txtRegistrySeparator.Text;
                dtoAuxIERegistry.RegistryLineSize = Convert.ToInt32(txtRegistryLineSize.Text == "" ? "0" : txtRegistryLineSize.Text);
                dtoAuxIERegistry.RegistryInitialLine = Convert.ToInt32(txtRegistryInitialLine.Text);
                dtoAuxIERegistry.RegistryStatus = Convert.ToBoolean(ddlRegistryStatus.SelectedValue);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRY(dtoAuxIERegistry, objUsers);
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
                dtoImportExport_Registry dtoAuxIERegistry = new dtoImportExport_Registry();
                dtoAuxIERegistry.Task = 3;
                dtoAuxIERegistry.RegistryID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_REGISTRY(dtoAuxIERegistry, objUsers);
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
                txtRegistryName.Text = "";
                txtRegistrySeparator.Text = "";
                txtRegistryLineSize.Text = "";
                txtRegistryInitialLine.Text = "";
                ddlRegistryStatus.SelectedValue = "True";
            }
            catch
            {

            }
        }
    }
}
