using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.BLL.Fidelity;
using _webPainelVerisys.DTO;
//using _webPainelVerisys.DTO.Fidelity;

namespace _webPainelVerisys.Fidelity
{
    public partial class GrupoXCore : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Telecom objTelecom = new Telecom();

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
                gridListaGrupoXCore();
                CarregaCore();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/DashBoard.aspx");
            }

            objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
        }

        protected void gridListaGrupoXCore()
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

            BoundField IDGrupoXCode = new BoundField();
            IDGrupoXCode.DataField = "ID";
            IDGrupoXCode.HeaderText = "ID";
            IDGrupoXCode.HeaderStyle.CssClass = "gridViewHeader1";
            IDGrupoXCode.ItemStyle.CssClass = "gridViewValues3";
            IDGrupoXCode.ItemStyle.Width = 50;
            IDGrupoXCode.SortExpression = "ID";
            gdRegistros.Columns.Add(IDGrupoXCode);

            BoundField DSCGrupoDac = new BoundField();
            DSCGrupoDac.DataField = "GRUPODAC";
            DSCGrupoDac.HeaderText = "Grupo DAC";
            DSCGrupoDac.HeaderStyle.CssClass = "gridViewHeader";
            DSCGrupoDac.ItemStyle.CssClass = "gridViewValues2";
            DSCGrupoDac.ItemStyle.Width = 300;
            DSCGrupoDac.SortExpression = "GRUPODAC";
            gdRegistros.Columns.Add(DSCGrupoDac);


            BoundField DSCCore = new BoundField();
            DSCCore.DataField = "DESCRITIVO";
            DSCCore.HeaderText = "Core Acessso";
            DSCCore.HeaderStyle.CssClass = "gridViewHeader";
            DSCCore.ItemStyle.CssClass = "gridViewValues2";
            DSCCore.ItemStyle.Width = 200;
            DSCCore.SortExpression = "DESCRITIVO";
            gdRegistros.Columns.Add(DSCCore);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";
            gdRegistros.PageSize = 20;

            DataSet dsQuery = objTelecom.listGrupoxCore();
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Grupos x Cores Cadastrados !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            if (txtSearchText.Text != "")
            {
                DataSet dsQuery = objTelecom.listGrupoxCore();
                //...
                dsQuery.Tables[0].DefaultView.RowFilter = "GRUPODAC like '%" + txtSearchText.Text + "%'";
                gdRegistros.DataSource = dsQuery.Tables[0].DefaultView;
                gdRegistros.DataBind();
            }
            else
            {
                gridListaGrupoXCore();
            }
        }

        protected void CarregaCore()
        {
            ddlCore.DataSource = objTelecom.listCore();
            ddlCore.DataTextField = "DescritivoCore";
            ddlCore.DataValueField = "NumeroCore";
            ddlCore.DataBind();
            ddlCore.Items.Insert(0, new ListItem("Selecione o Core...", "0"));
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencaoGrupoXCore.Visible = true;
                modExcluirGrupoXCore.Visible = false;

                int index = int.Parse((string)e.CommandArgument);

                lblTituloDiv.Text = "Alteração de Grupo X Core";
                lblIDGrupoXCore.Text = gdRegistros.DataKeys[index]["ID"].ToString();
                txtGrupoXCore.Text = gdRegistros.DataKeys[index]["GRUPODAC"].ToString();
                txtGrupoXCore.Enabled = false;
                ddlCore.SelectedValue = gdRegistros.DataKeys[index]["CORE"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Grupo X Core";
                modManutencaoGrupoXCore.Visible = false;
                modExcluirGrupoXCore.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblIDGrupoXCore.Text = gdRegistros.DataKeys[index]["ID"].ToString();
                lblGrupoXCoreExclusao.Text = gdRegistros.DataKeys[index]["GRUPODAC"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objTelecom.listGrupoxCore();
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

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Cadastrar novo Grupo X Core")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Grupo X Core")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Grupo X Core")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (txtGrupoXCore.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Grupo DAC</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlCore.SelectedIndex == 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>Selecione o <b>Core</b> !! </div>";
                    return;
                }

                dtoTelecom objAuxGrupoXCore = new dtoTelecom();
                objAuxGrupoXCore.Task = 1;
                objAuxGrupoXCore.GrupoDAC = txtGrupoXCore.Text;
                objAuxGrupoXCore.NumeroCore = ddlCore.SelectedValue.ToString();

                Int64 intResultado = objTelecom.ManagerGrupoXCore(objAuxGrupoXCore, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Grupo X Core Cadastrado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Grupo X Core !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Grupo X Core !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtGrupoXCore.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Grupo DAC</b> não pode ficar em Branco !! </div>";
                    return;
                }

                if (ddlCore.SelectedIndex == 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>Selecione o <b>Core</b> !! </div>";
                    return;
                }

                dtoTelecom objAuxGrupoXCore = new dtoTelecom();
                objAuxGrupoXCore.Task = 2;
                objAuxGrupoXCore.IDGrupoxCore = Convert.ToInt64(lblIDGrupoXCore.Text);
                objAuxGrupoXCore.NumeroCore = ddlCore.SelectedValue.ToString();

                Int64 intResultado = objTelecom.ManagerGrupoXCore(objAuxGrupoXCore, objUsers);
                if (intResultado > 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='ROK'> Grupo X Core Alterado com sucesso !! </div>";
                }
                else
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Grupo X Core !! </div>";
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Grupo X Core !! </div>";
            }
        }

        protected void Exclusao()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                dtoTelecom objAuxGrupoXCore = new dtoTelecom();
                objAuxGrupoXCore.Task = 3;
                objAuxGrupoXCore.IDGrupoxCore = Convert.ToInt64(lblIDGrupoXCore.Text);

                Int64 intResultado = objTelecom.ManagerGrupoXCore(objAuxGrupoXCore, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Grupo X Core excluido com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Grupo X Core !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Grupo X Core !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo Grupo X Core";
                modManutencaoGrupoXCore.Visible = true;
                modExcluirGrupoXCore.Visible = false;
                txtGrupoXCore.Text = "";
                txtGrupoXCore.Enabled = true;
                ddlCore.SelectedIndex = 0;
                gridListaGrupoXCore();
                txtSearchText.Text = "";
            }
            catch
            {

            }
        }

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gridListaGrupoXCore();
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
