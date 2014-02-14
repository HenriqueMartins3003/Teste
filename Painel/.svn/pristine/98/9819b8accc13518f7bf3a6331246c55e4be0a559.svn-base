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
    public partial class ScreenCaptureACDList : System.Web.UI.Page
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
                gridLista();
                CarregaGrupoDAC();
                CarregaPorcentagem();
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
            btnDelete.ItemStyle.Width = 50;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnDelete);

            BoundField DSCACDGROUP = new BoundField();
            DSCACDGROUP.DataField = "ACDGROUP";
            DSCACDGROUP.HeaderText = "Grupo DAC";
            DSCACDGROUP.HeaderStyle.CssClass = "gridViewHeader";
            DSCACDGROUP.ItemStyle.CssClass = "gridViewValues2";
            DSCACDGROUP.ItemStyle.Width = 100;
            DSCACDGROUP.SortExpression = "ACDGROUP";
            gdRegistros.Columns.Add(DSCACDGROUP);

            BoundField DSCACTIVATED = new BoundField();
            DSCACTIVATED.DataField = "ACTIVATED";
            DSCACTIVATED.HeaderText = "Status";
            DSCACTIVATED.HeaderStyle.CssClass = "gridViewHeader";
            DSCACTIVATED.ItemStyle.CssClass = "gridViewValues2";
            DSCACTIVATED.ItemStyle.Width = 100;
            DSCACTIVATED.SortExpression = "ACTIVATED";
            gdRegistros.Columns.Add(DSCACTIVATED);

            BoundField PERCENTAGERATE = new BoundField();
            PERCENTAGERATE.DataField = "PERCENTAGERATE";
            PERCENTAGERATE.HeaderText = "Porcentagem";
            PERCENTAGERATE.HeaderStyle.CssClass = "gridViewHeader";
            PERCENTAGERATE.ItemStyle.CssClass = "gridViewValues2";
            PERCENTAGERATE.ItemStyle.Width = 100;
            PERCENTAGERATE.SortExpression = "PERCENTAGERATE";
            gdRegistros.Columns.Add(PERCENTAGERATE);

            BoundField datLASTCHANGE = new BoundField();
            datLASTCHANGE.DataField = "LASTCHANGE";
            datLASTCHANGE.HeaderText = "Ultima Alteração";
            datLASTCHANGE.HeaderStyle.CssClass = "gridViewHeader";
            datLASTCHANGE.ItemStyle.CssClass = "gridViewValues2";
            datLASTCHANGE.ItemStyle.Width = 150;
            datLASTCHANGE.SortExpression = "LASTCHANGE";
            gdRegistros.Columns.Add(datLASTCHANGE);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objTelecom.listScreenCaptureACDList();
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Screen Capture ACDLists Cadastrados !! </div>";
            }

            gdRegistros.DataBind();
        }

        private void CarregaPorcentagem()
        {
            int count = 100;
            while (count > -5)
            {
                ddlPorcentagem.Items.Insert(0, new ListItem(count.ToString(), count.ToString()));
                count = count - 5;
            }

            ddlPorcentagem.Items.Insert(0, new ListItem("Porcentagem ...", "0"));
        }

        protected void CarregaGrupoDAC()
        {
            ddlGrupoDac.DataSource = objTelecom.listGrupoDAC();
            ddlGrupoDac.DataTextField = "NomeGrupoDAC";
            ddlGrupoDac.DataValueField = "GrupoDAC";
            ddlGrupoDac.DataBind();
            ddlGrupoDac.Items.Insert(0, new ListItem("Selecione o Grupo DAC...", "0"));
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencao.Visible = true;
                modExcluir.Visible = false;

                int index = int.Parse((string)e.CommandArgument);

                lblTituloDiv.Text = "Alteração de Grupo DAC";
                lblID.Text = gdRegistros.DataKeys[index]["ACDGROUP"].ToString();
                ddlGrupoDac.SelectedValue = gdRegistros.DataKeys[index]["ACDGROUP"].ToString();

                try
                {
                    ddlPorcentagem.SelectedValue = gdRegistros.DataKeys[index]["PERCENTAGERATE"].ToString();
                }
                catch
                {
                    ddlPorcentagem.SelectedValue = "0";
                }

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Grupo DAC";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["ACDGROUP"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["ACDGROUP"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objTelecom.listScreenCaptureACDList();
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
            if (lblTituloDiv.Text == "Cadastrar novo Grupo DAC")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Grupo DAC")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Grupo DAC")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (ddlGrupoDac.SelectedIndex == 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O <b>Grupo DAC</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlGrupoDac.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>A porcentagem deve ser selecionado</div>";
                    return;
                }

                dtoTelecom objAuxTelecom = new dtoTelecom();
                objAuxTelecom.Task = 1;
                objAuxTelecom.GrupoDAC = ddlGrupoDac.SelectedValue;
                objAuxTelecom.Status = Convert.ToInt16(rbStatus.SelectedValue);
                objAuxTelecom.PercentageRate = ddlPorcentagem.SelectedValue;

                Int64 intResultado = objTelecom.ManagerScreenCaptureACDList(objAuxTelecom, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Grupo DAC Cadastrado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Grupo DAC !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Grupo DAC !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (ddlGrupoDac.SelectedIndex == 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O <b>Grupo DAC</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlGrupoDac.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>A porcentagem deve ser selecionado</div>";
                    return;
                }

                dtoTelecom objAuxTelecom = new dtoTelecom();
                objAuxTelecom.Task = 2;
                objAuxTelecom.GrupoDAC = ddlGrupoDac.SelectedValue;
                objAuxTelecom.Status = Convert.ToInt16(rbStatus.SelectedValue);
                objAuxTelecom.GrupoDAC = lblID.Text;
                objAuxTelecom.PercentageRate = ddlPorcentagem.SelectedValue;

                Int64 intResultado = objTelecom.ManagerScreenCaptureACDList(objAuxTelecom, objUsers);
                if (intResultado > 0)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='ROK'> Grupo DAC Alterado com sucesso !! </div>";
                }
                else
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Grupo DAC !! </div>";
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Grupo DAC !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoTelecom objAuxTelecom = new dtoTelecom();
                objAuxTelecom.Task = 3;
                objAuxTelecom.GrupoDAC = lblID.Text;

                Int64 intResultado = objTelecom.ManagerScreenCaptureACDList(objAuxTelecom, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Grupo DAC excluido com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Grupo DAC !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Grupo DAC !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo Grupo DAC";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                CarregaGrupoDAC();
                gridLista();
            }
            catch
            {

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
    }
}
