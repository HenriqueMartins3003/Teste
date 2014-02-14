using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Usuario
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();

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
                gridListaPerfis();
                CarregaTipoPerfil();
                CarregaModulos();
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

        protected void gridListaPerfis()
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
            btnDelete.ItemStyle.Width = 50;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnDelete);

            BoundField IDPerfil = new BoundField();
            IDPerfil.DataField = "ID";
            IDPerfil.HeaderText = "ID";
            IDPerfil.HeaderStyle.CssClass = "gridViewHeader1";
            IDPerfil.ItemStyle.CssClass = "gridViewValues3";
            IDPerfil.ItemStyle.Width = 50;
            IDPerfil.Visible = false;
            gdRegistros.Columns.Add(IDPerfil);

            BoundField DSCDescricao = new BoundField();
            DSCDescricao.DataField = "DESCRICAO";
            DSCDescricao.HeaderText = "Descrição";
            DSCDescricao.HeaderStyle.CssClass = "gridViewHeader";
            DSCDescricao.ItemStyle.CssClass = "gridViewValues2";
            DSCDescricao.ItemStyle.Width = 300;
            DSCDescricao.SortExpression = "DESCRICAO";
            gdRegistros.Columns.Add(DSCDescricao);

            BoundField DSCTipoPerfil = new BoundField();
            DSCTipoPerfil.DataField = "TIPOPERFIL";
            DSCTipoPerfil.HeaderText = "Tipo de Perfil";
            DSCTipoPerfil.HeaderStyle.CssClass = "gridViewHeader";
            DSCTipoPerfil.ItemStyle.CssClass = "gridViewValues2";
            DSCTipoPerfil.ItemStyle.Width = 200;
            DSCTipoPerfil.SortExpression = "TIPOPERFIL";
            gdRegistros.Columns.Add(DSCTipoPerfil);

            BoundField DSCAtivo = new BoundField();
            DSCAtivo.DataField = "ATIVO";
            DSCAtivo.HeaderText = "Ativo ?";
            DSCAtivo.HeaderStyle.CssClass = "gridViewHeader1";
            DSCAtivo.ItemStyle.CssClass = "gridViewValues3";
            DSCAtivo.ItemStyle.Width = 50;
            DSCAtivo.SortExpression = "ATIVO";
            gdRegistros.Columns.Add(DSCAtivo);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            UsersProfiles objPerfil = new UsersProfiles();
            gdRegistros.DataSource = objPerfil.BuscaPerfis(objUsers);
            gdRegistros.DataBind();
        }

        protected void CarregaTipoPerfil()
        {
            UsersProfiles objPerfil = new UsersProfiles();
            ddlTypeProfile.DataSource = objPerfil.BuscaTipoPerfis(objUsers);
            ddlTypeProfile.DataTextField = "DESCRICAO";
            ddlTypeProfile.DataValueField = "ID_TIPOPERFIL";
            ddlTypeProfile.DataBind();
            ddlTypeProfile.Items.Insert(0, new ListItem("Selecione o Tipo de Perfil...", "0"));
        }

        protected void CarregaModulos()
        {
            Modulos objModulos = new Modulos();
            String strApplication = Session["ObjApplication"].ToString();
            rModulos.DataSource = objModulos.RetornaModulosPerfil("", strApplication);
            rModulos.DataBind();
        }

        protected void CarregaModulos(String idPerfil)
        {
            Modulos objModulos = new Modulos();
            String strApplication = Session["ObjApplication"].ToString();
            rModulos.DataSource = objModulos.RetornaModulosPerfil(idPerfil, strApplication);
            rModulos.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencaoPerfil.Visible = true;
                modExcluirPerfil.Visible = false;
                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração de Perfil";
                lblIDPerfil.Text = gdRegistros.DataKeys[index]["ID"].ToString();
                txtDescricao.Text = gdRegistros.DataKeys[index]["DESCRICAO"].ToString();
                ddlTypeProfile.SelectedValue = gdRegistros.DataKeys[index]["IDTIPOPERFIL"].ToString();
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["ATIVO"].ToString().ToUpper() == "SIM" ? "True" : "False";
                CarregaModulos(gdRegistros.DataKeys[index]["ID"].ToString());

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
            
            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Perfil";
                modManutencaoPerfil.Visible = false;
                modExcluirPerfil.Visible = true;
                int index = int.Parse((string)e.CommandArgument);
                lblIDPerfil.Text = gdRegistros.DataKeys[index]["ID"].ToString();
                lblPerfilExclusao.Text = gdRegistros.DataKeys[index]["DESCRICAO"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            UsersProfiles objPerfil = new UsersProfiles();
            DataSet dsRegistros = objPerfil.BuscaPerfis(objUsers);

            DataTable dtRegistros = (DataTable)dsRegistros.Tables[0];
            String _coluna = e.SortExpression;

            if (_coluna.Equals(Session["ULTIMOSORT"]))
                _coluna = _coluna + " desc";

            Session.Add("ULTIMOSORT", _coluna);
            dtRegistros.DefaultView.Sort = _coluna;

            gdRegistros.DataSource = dtRegistros;
            gdRegistros.DataBind();
        }

        protected void chkInsereTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInsereTodos.Checked == true)
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkInsere");
                    ckBox.Checked = true;
                }
            }
            else
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkInsere");
                    ckBox.Checked = false;
                }
            }
        }

        protected void chkDeletaTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletaTodos.Checked == true)
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkDelete");
                    ckBox.Checked = true;
                }
            }
            else
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkDelete");
                    ckBox.Checked = false;
                }
            }
        }

        protected void chkAlteraTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlteraTodos.Checked == true)
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkAltera");
                    ckBox.Checked = true;
                }
            }
            else
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkAltera");
                    ckBox.Checked = false;
                }
            }
        }

        protected void chkConsultaTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConsultaTodos.Checked == true)
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkConsulta");
                    ckBox.Checked = true;
                }
            }
            else
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkConsulta");
                    ckBox.Checked = false;
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
            dtoUsersProfiles dtoProfiles = new dtoUsersProfiles();

            if (lblTituloDiv.Text == "Cadastrar novo perfil")
            {
                try
                {
                    if (txtDescricao.Text == String.Empty)
                    {
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Descrição</b> não pode ficar em Branco !! </div>";
                        divResponse.Visible = true;
                        return;
                    }

                    if (ddlTypeProfile.SelectedIndex == 0)
                    {
                        lblResponse.Text = "<div class='RNOK'>Selecione o <b>Tipo Perfil</b> !! </div>";
                        divResponse.Visible = true;
                        return;
                    }

                    dtoProfiles.Task = 1;
                    dtoProfiles.IdUserProfile = 0;
                    dtoProfiles.DescriptProfile = txtDescricao.Text;
                    dtoProfiles.TypeProfile = Convert.ToInt16(ddlTypeProfile.SelectedValue);
                    dtoProfiles.Status = ddlAtivo.SelectedValue == "False" ? 0 : 1;

                    foreach (RepeaterItem ri in this.rModulos.Items)
                    {
                        Label ID = (Label)ri.FindControl("lblID");
                        CheckBox ckBoxInsere = (CheckBox)ri.FindControl("chkInsere");
                        CheckBox ckBoxDelete = (CheckBox)ri.FindControl("chkDelete");
                        CheckBox ckBoxAltera = (CheckBox)ri.FindControl("chkAltera");
                        CheckBox ckBoxConsulta = (CheckBox)ri.FindControl("chkConsulta");

                        String strModulo = "";
                        String ModuloInclusao = "";
                        String ModuloAlteracao = "";
                        String ModuloExclusao = "";
                        String ModuloConsulta = "";

                        if ((ckBoxInsere.Checked == true) || (ckBoxDelete.Checked == true) || (ckBoxAltera.Checked == true) || (ckBoxConsulta.Checked == true))
                        {
                            strModulo = ID.Text;
                            ModuloInclusao = ckBoxInsere.Checked == true ? "1" : "0";
                            ModuloAlteracao = ckBoxAltera.Checked == true ? "1" : "0";
                            ModuloExclusao = ckBoxDelete.Checked == true ? "1" : "0";
                            ModuloConsulta = ckBoxConsulta.Checked == true ? "1" : "0";

                            dtoProfiles.ModuleList = dtoProfiles.ModuleList + ";" + strModulo + "," + ModuloInclusao + "," + ModuloAlteracao + "," + ModuloExclusao + "," + ModuloConsulta;
                        }
                    }

                    dtoProfiles.ModuleList = dtoProfiles.ModuleList.Substring(1, dtoProfiles.ModuleList.Length - 1);

                    String Result = objUsersProfiles.ManagerProfiles(dtoProfiles, objUsers);
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
                catch (Exception ex)
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante o processo de Cadastramento de Perfil !! </div>";
                    divResponse.Visible = true;
                }
            }
            else if (lblTituloDiv.Text == "Alteração de Perfil")
            {
                try
                {
                    if (txtDescricao.Text == String.Empty)
                    {
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Descrição</b> não pode ficar em Branco !! </div>";
                        divResponse.Visible = true;
                        return;
                    }

                    if (ddlTypeProfile.SelectedIndex == 0)
                    {
                        lblResponse.Text = "<div class='RNOK'>Selecione o <b>Tipo Perfil</b> !! </div>";
                        divResponse.Visible = true;
                        return;
                    }

                    dtoProfiles.Task = 2;
                    dtoProfiles.IdUserProfile = Convert.ToInt64(lblIDPerfil.Text);
                    dtoProfiles.DescriptProfile = txtDescricao.Text;
                    dtoProfiles.TypeProfile = Convert.ToInt16(ddlTypeProfile.SelectedValue);
                    dtoProfiles.Status = ddlAtivo.SelectedValue == "False" ? 0 : 1;

                    foreach (RepeaterItem ri in this.rModulos.Items)
                    {
                        Label ID = (Label)ri.FindControl("lblID");
                        CheckBox ckBoxInsere = (CheckBox)ri.FindControl("chkInsere");
                        CheckBox ckBoxDelete = (CheckBox)ri.FindControl("chkDelete");
                        CheckBox ckBoxAltera = (CheckBox)ri.FindControl("chkAltera");
                        CheckBox ckBoxConsulta = (CheckBox)ri.FindControl("chkConsulta");

                        String strModulo = "";
                        String ModuloInclusao = "";
                        String ModuloAlteracao = "";
                        String ModuloExclusao = "";
                        String ModuloConsulta = "";

                        if ((ckBoxInsere.Checked == true) || (ckBoxDelete.Checked == true) || (ckBoxAltera.Checked == true) || (ckBoxConsulta.Checked == true))
                        {
                            strModulo = ID.Text;
                            ModuloInclusao = ckBoxInsere.Checked == true ? "1" : "0";
                            ModuloAlteracao = ckBoxAltera.Checked == true ? "1" : "0";
                            ModuloExclusao = ckBoxDelete.Checked == true ? "1" : "0";
                            ModuloConsulta = ckBoxConsulta.Checked == true ? "1" : "0";

                            dtoProfiles.ModuleList = dtoProfiles.ModuleList + ";" + strModulo + "," + ModuloInclusao + "," + ModuloAlteracao + "," + ModuloExclusao + "," + ModuloConsulta;
                        }
                    }

                    dtoProfiles.ModuleList = dtoProfiles.ModuleList.Substring(1, dtoProfiles.ModuleList.Length - 1);

                    String Result = objUsersProfiles.ManagerProfiles(dtoProfiles, objUsers);
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
                catch (Exception ex)
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante o processo de Alteração de Perfil !! </div>";
                    divResponse.Visible = true;
                }
            }
            else if (lblTituloDiv.Text == "Exclusão de Perfil")
            {
                try
                {
                    dtoProfiles.Task = 3;
                    dtoProfiles.IdUserProfile = Convert.ToInt64(lblIDPerfil.Text);
                    dtoProfiles.DescriptProfile = "";
                    dtoProfiles.TypeProfile = 0;
                    dtoProfiles.Status = 0;
                    dtoProfiles.ModuleList = "";

                    String Result = objUsersProfiles.ManagerProfiles(dtoProfiles, objUsers);
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
                catch (Exception ex)
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante o processo de Exclusão de Perfil !! </div>";
                    divResponse.Visible = true;
                }
            }

            Limpar();
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo perfil";
                modManutencaoPerfil.Visible = true;
                modExcluirPerfil.Visible = false;
                txtDescricao.Text = "";
                ddlTypeProfile.SelectedIndex = 0;
                ddlAtivo.SelectedValue = "False";
                gridListaPerfis();
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkInsere");
                    ckBox.Checked = false;
                    CheckBox ckBox1 = (CheckBox)ri.FindControl("chkDelete");
                    ckBox1.Checked = false;
                    CheckBox ckBox2 = (CheckBox)ri.FindControl("chkAltera");
                    ckBox2.Checked = false;
                    CheckBox ckBox3 = (CheckBox)ri.FindControl("chkConsulta");
                    ckBox3.Checked = false;
                }
            }
            catch
            {

            }
        }

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gridListaPerfis();
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
    }
}
