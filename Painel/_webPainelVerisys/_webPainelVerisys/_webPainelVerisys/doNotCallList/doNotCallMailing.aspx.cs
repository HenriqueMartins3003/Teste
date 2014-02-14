using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class doNotCallMailing : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        blldoNotCallList objdoNotCallList = new blldoNotCallList();

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
                AccessSecurity();
                PageConfig();
                gridLista();
                loadProcesso();
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

        protected void loadProcesso()
        {
            ddlProcesso.DataSource = objdoNotCallList.listProcesso();
            ddlProcesso.DataTextField = "Processo";
            ddlProcesso.DataValueField = "ProcessoID";
            ddlProcesso.DataBind();
            ddlProcesso.Items.Insert(0, new ListItem("Processo ...", "0"));
        }

        protected void gridLista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

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

            BoundField ID = new BoundField();
            ID.DataField = "IDMAILING";
            ID.HeaderText = "ID";
            ID.HeaderStyle.CssClass = "gridViewHeader1";
            ID.ItemStyle.CssClass = "gridViewValues3";
            ID.ItemStyle.Width = 50;
            ID.Visible = false;
            ID.SortExpression = "IDMAILING";
            gdRegistros.Columns.Add(ID);

            BoundField bfTABELADISCADOR = new BoundField();
            bfTABELADISCADOR.DataField = "TABELADISCADOR";
            bfTABELADISCADOR.HeaderText = "Tabela Discador";
            bfTABELADISCADOR.HeaderStyle.CssClass = "gridViewHeader";
            bfTABELADISCADOR.ItemStyle.CssClass = "gridViewValues2";
            bfTABELADISCADOR.ItemStyle.Width = 100;
            bfTABELADISCADOR.SortExpression = "TABELADISCADOR";
            gdRegistros.Columns.Add(bfTABELADISCADOR);

            BoundField bfKYFONEBLOQUEIO = new BoundField();
            bfKYFONEBLOQUEIO.DataField = "KYFONEBLOQUEIO";
            bfKYFONEBLOQUEIO.HeaderText = "KyFone Bloqueio";
            bfKYFONEBLOQUEIO.HeaderStyle.CssClass = "gridViewHeader";
            bfKYFONEBLOQUEIO.ItemStyle.CssClass = "gridViewValues3";
            bfKYFONEBLOQUEIO.ItemStyle.Width = 50;
            bfKYFONEBLOQUEIO.SortExpression = "KYFONEBLOQUEIO";
            gdRegistros.Columns.Add(bfKYFONEBLOQUEIO);

            BoundField bfLINKEDSERVERMAILING = new BoundField();
            bfLINKEDSERVERMAILING.DataField = "LINKEDSERVERMAILING";
            bfLINKEDSERVERMAILING.HeaderText = "LinkedServer";
            bfLINKEDSERVERMAILING.HeaderStyle.CssClass = "gridViewHeader";
            bfLINKEDSERVERMAILING.ItemStyle.CssClass = "gridViewValues2";
            bfLINKEDSERVERMAILING.ItemStyle.Width = 100;
            bfLINKEDSERVERMAILING.SortExpression = "LINKEDSERVERMAILING";
            gdRegistros.Columns.Add(bfLINKEDSERVERMAILING);

            BoundField bfPROCESSO = new BoundField();
            bfPROCESSO.DataField = "PROCESSO";
            bfPROCESSO.HeaderText = "Processo";
            bfPROCESSO.HeaderStyle.CssClass = "gridViewHeader";
            bfPROCESSO.ItemStyle.CssClass = "gridViewValues2";
            bfPROCESSO.ItemStyle.Width = 100;
            bfPROCESSO.SortExpression = "PROCESSO";
            gdRegistros.Columns.Add(bfPROCESSO);

            BoundField bfPROCESSOID = new BoundField();
            bfPROCESSOID.DataField = "PROCESSOID";
            bfPROCESSOID.HeaderText = "ProcessoID";
            bfPROCESSOID.HeaderStyle.CssClass = "gridViewHeader";
            bfPROCESSOID.ItemStyle.CssClass = "gridViewValues2";
            bfPROCESSOID.ItemStyle.Width = 50;
            bfPROCESSOID.Visible = false;
            bfPROCESSOID.SortExpression = "PROCESSOID";
            gdRegistros.Columns.Add(bfPROCESSOID);

            BoundField bfFLAG_ATIVO = new BoundField();
            bfFLAG_ATIVO.DataField = "FLAG_ATIVO";
            bfFLAG_ATIVO.HeaderText = "Ativo ?";
            bfFLAG_ATIVO.HeaderStyle.CssClass = "gridViewHeader";
            bfFLAG_ATIVO.ItemStyle.CssClass = "gridViewValues2";
            bfFLAG_ATIVO.ItemStyle.Width = 50;
            bfFLAG_ATIVO.SortExpression = "FLAG_ATIVO";
            gdRegistros.Columns.Add(bfFLAG_ATIVO);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objdoNotCallList.listdoNotCallListMailing(objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Mailings Cadastrados !! </div>";
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
                lblTituloDiv.Text = "Alteração de base de Mailings";

                lblID.Text = gdRegistros.DataKeys[index]["IDMAILING"].ToString();

                txtTabelaDiscador.Text = gdRegistros.DataKeys[index]["TABELADISCADOR"].ToString();
                txtKyFone.Text = gdRegistros.DataKeys[index]["KYFONEBLOQUEIO"].ToString();
                txtLinkedServer.Text = gdRegistros.DataKeys[index]["LINKEDSERVERMAILING"].ToString();
                ddlProcesso.SelectedValue = gdRegistros.DataKeys[index]["PROCESSOID"].ToString();
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["FLAG_ATIVO"].ToString() == "SIM" ? "True" : "False";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de base de Mailings";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["IDMAILING"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["TABELADISCADOR"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objdoNotCallList.listdoNotCallListMailing(objUsers);
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
            gridLista();
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

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Cadastrar nova base de Mailings")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de base de Mailings")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de base de Mailings")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Cadastro()
        {
            try
            {
                if (txtTabelaDiscador.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>A <b>Tabela Discador</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlProcesso.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Processo</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtKyFone.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>KyFone Bloqueio</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }
                else
                {
                    Boolean bolTesteNumerico = Regex.IsMatch(txtKyFone.Text, @"^\d+$");
                    if (!bolTesteNumerico)
                    {
                        lblResponse.Text = "<div class='RNOK'>O <b>KyFone Bloqueio</b> deve ser numérico !! </div>";
                        divResponse.Visible = true;
                        return;
                    }
                }

                //if (txtLinkedServer.Text == String.Empty)
                //{
                //    lblResponse.Text = "<div class='RNOK'>O <b>LinkedServer</b> não pode ficar em Branco !! </div>";
                //    divResponse.Visible = true;
                //    return;
                //}

                dtodoNotCallList objAux = new dtodoNotCallList();
                objAux.Task = 1;
                objAux.IDMailing = 0;
                objAux.TabelaDiscador = txtTabelaDiscador.Text;
                objAux.KYFoneBloqueio = Convert.ToInt32(txtKyFone.Text);
                objAux.LinkedServerMailing = txtLinkedServer.Text;
                objAux.Flag_Ativo = Convert.ToBoolean(ddlAtivo.SelectedValue == "False" ? false : true);
                objAux.ProcessoID = Convert.ToInt64(ddlProcesso.SelectedValue.ToString());

                String Result = objdoNotCallList.PAN_ManagerMailing(objAux, objUsers);
                if (Result.Substring(0, 4).ToString().ToUpper() == "ERROR")
                {
                    lblResponse.Text = "<div class='RNOK'>" + Result + "</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='ROK'>" + Result + "</div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Regra Segmentação !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtTabelaDiscador.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>A <b>Tabela Discador</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (ddlProcesso.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>Processo</b> deve ser selecionado !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (txtKyFone.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'>O <b>KyFone Bloqueio</b> não pode ficar em Branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }
                else
                {
                    Boolean bolTesteNumerico = Regex.IsMatch(txtKyFone.Text, @"^\d+$");
                    if (!bolTesteNumerico)
                    {
                        lblResponse.Text = "<div class='RNOK'>O <b>KyFone Bloqueio</b> deve ser numérico !! </div>";
                        divResponse.Visible = true;
                        return;
                    }
                }

                //if (txtLinkedServer.Text == String.Empty)
                //{
                //    lblResponse.Text = "<div class='RNOK'>O <b>LinkedServer</b> não pode ficar em Branco !! </div>";
                //    divResponse.Visible = true;
                //    return;
                //}

                dtodoNotCallList objAux = new dtodoNotCallList();
                objAux.Task = 2;
                objAux.IDMailing = Convert.ToInt32(lblID.Text);
                objAux.TabelaDiscador = txtTabelaDiscador.Text;
                objAux.KYFoneBloqueio = Convert.ToInt32(txtKyFone.Text);
                objAux.LinkedServerMailing = txtLinkedServer.Text;
                objAux.Flag_Ativo = Convert.ToBoolean(ddlAtivo.SelectedValue == "False" ? false : true);
                objAux.ProcessoID = Convert.ToInt64(ddlProcesso.SelectedValue.ToString());

                String Result = objdoNotCallList.PAN_ManagerMailing(objAux, objUsers);
                if (Result.Substring(0, 4).ToString().ToUpper() == "ERROR")
                {
                    lblResponse.Text = "<div class='RNOK'>" + Result + "</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='ROK'>" + Result + "</div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração da Regra Segmentação !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtodoNotCallList objAux = new dtodoNotCallList();
                objAux.Task = 3;
                objAux.IDMailing = Convert.ToInt32(lblID.Text);
                objAux.TabelaDiscador = "";
                objAux.KYFoneBloqueio = 0;
                objAux.LinkedServerMailing = "";
                objAux.Flag_Ativo = true;

                String Result = objdoNotCallList.PAN_ManagerMailing(objAux, objUsers);
                if (Result.Substring(0, 4).ToString().ToUpper() == "ERROR")
                {
                    lblResponse.Text = "<div class='RNOK'>" + Result + "</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='ROK'>" + Result + "</div>";
                    divResponse.Visible = true;
                }
            }
            catch
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Regra Segmentação !! </div>";
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar nova base de Mailings";
                divContent.Visible = true;
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                gridLista();

                txtTabelaDiscador.Text = String.Empty;
                txtKyFone.Text = String.Empty;
                txtLinkedServer.Text = String.Empty;
                ddlAtivo.SelectedValue = "0";
                ddlProcesso.SelectedValue = "0";
            }
            catch
            {

            }
        }
    }
}
