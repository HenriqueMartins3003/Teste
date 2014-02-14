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
    public partial class RamaisForaRange : System.Web.UI.Page
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

            ButtonField btnDelete = new ButtonField();
            btnDelete.ButtonType = ButtonType.Image;
            btnDelete.ImageUrl = "~/img/delete.gif";
            btnDelete.CommandName = "Del";
            btnDelete.ItemStyle.Width = 50;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnDelete);

            BoundField DSCRamal = new BoundField();
            DSCRamal.DataField = "RM";
            DSCRamal.HeaderText = "Ramal";
            DSCRamal.HeaderStyle.CssClass = "gridViewHeader";
            DSCRamal.ItemStyle.CssClass = "gridViewValues2";
            DSCRamal.ItemStyle.Width = 200;
            DSCRamal.SortExpression = "RM";
            gdRegistros.Columns.Add(DSCRamal);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objTelecom.listRamalForaRange();
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Ramais Fora de Range Cadastrados !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Ramal";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["ID_RM"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["RM"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objTelecom.listRamalForaRange();
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
            if (lblTituloDiv.Text == "Cadastrar novo Ramal")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Exclusão de Ramal")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (txtRamal.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Ramal</b> não pode ficar em Branco !! </div>";
                    return;
                }

                dtoTelecom objAuxTelecom = new dtoTelecom();
                objAuxTelecom.Task = 1;
                objAuxTelecom.Ramal = txtRamal.Text;

                Int64 intResultado = objTelecom.ManagerRamalForaRange(objAuxTelecom, objUsers);

                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Ramal Cadastrado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Ramal !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Ramal !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoTelecom objAuxTelecom = new dtoTelecom();
                objAuxTelecom.Task = 3;
                objAuxTelecom.IDRamal = Convert.ToInt64(lblID.Text);

                Int64 intResultado = objTelecom.ManagerRamalForaRange(objAuxTelecom, objUsers);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Ramal excluido com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Ramal !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Ramal !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo Ramal";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                txtRamal.Text = "";
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
