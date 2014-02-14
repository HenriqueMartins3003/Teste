using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Campanha
{
    public partial class CampanhaRegraSequenciamento : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();

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
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/Default.aspx");
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

            BoundField bfID = new BoundField();
            bfID.DataField = "IDREGRA";
            bfID.HeaderText = "ID";
            bfID.HeaderStyle.CssClass = "gridViewHeader1";
            bfID.ItemStyle.CssClass = "gridViewValues3";
            bfID.ItemStyle.Width = 25;
            bfID.SortExpression = "IDREGRA";
            bfID.Visible = false;
            gdRegistros.Columns.Add(bfID);

            BoundField bfNOMEREGRA = new BoundField();
            bfNOMEREGRA.DataField = "NOMEREGRA";
            bfNOMEREGRA.HeaderText = "Plano";
            bfNOMEREGRA.HeaderStyle.CssClass = "gridViewHeader";
            bfNOMEREGRA.ItemStyle.CssClass = "gridViewValues2";
            bfNOMEREGRA.ItemStyle.Width = 250;
            bfNOMEREGRA.Visible = true;
            bfNOMEREGRA.SortExpression = "NOMEREGRA";
            gdRegistros.Columns.Add(bfNOMEREGRA);

            BoundField bfDATACRIACAO = new BoundField();
            bfDATACRIACAO.DataField = "DATACRIACAO";
            bfDATACRIACAO.HeaderText = "Data de Criação";
            bfDATACRIACAO.HeaderStyle.CssClass = "gridViewHeader";
            bfDATACRIACAO.ItemStyle.CssClass = "gridViewValues2";
            bfDATACRIACAO.ItemStyle.Width = 130;
            bfDATACRIACAO.SortExpression = "DATACRIACAO";
            gdRegistros.Columns.Add(bfDATACRIACAO);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objCampaign.listCampaignRulesSequence();
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Planos de Discagem Cadastrados !! </div>";
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
                lblTituloDiv.Text = "Alteração de Plano de Discagem";

                lblID.Text = gdRegistros.DataKeys[index]["IDREGRA"].ToString();
                txtRegra.Text = gdRegistros.DataKeys[index]["NOMEREGRA"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão do Plano de Discagem";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["IDREGRA"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["NOMEREGRA"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsRegistros = objCampaign.listCampaignRulesSequence();

            DataTable dtRegistros = (DataTable)dsRegistros.Tables[0];
            String _coluna = e.SortExpression;

            if (_coluna.Equals(Session["ULTIMOSORT"]))
                _coluna = _coluna + " desc";

            Session.Add("ULTIMOSORT", _coluna);
            dtRegistros.DefaultView.Sort = _coluna;

            gdRegistros.DataSource = dtRegistros;
            gdRegistros.DataBind();
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

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }


        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Cadastrar novo Plano de Discagem")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Plano de Discagem")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão do Plano de Discagem")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (txtRegra.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O <b>Plano de Discagem</b> deve ser definido !! </div>";
                    return;
                }

                dtoCampaignRule objAux = new dtoCampaignRule();
                objAux.Task = 1;
                objAux.User = objUsers.User;
                objAux.NomeRegra = txtRegra.Text;

                Int64 intResultado = objCampaign.managerCampaignRulesNameSequence(objAux);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Novo Plano de Discagem Cadastrado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Novo Plano de Discagem !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação do Novo Plano de Discagem !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (txtRegra.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O <b>Plano de Discagem</b> deve ser definido !! </div>";
                    return;
                }

                dtoCampaignRule objAux = new dtoCampaignRule();
                objAux.Task = 2;
                objAux.User = objUsers.User;
                objAux.NumeroRegra = lblID.Text;
                objAux.NomeRegra = txtRegra.Text;

                Int64 intResultado = objCampaign.managerCampaignRulesNameSequence(objAux);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração de Plano de Discagem realizado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Plano de Discagem !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Plano de Discagem !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoCampaignRule objAux = new dtoCampaignRule();
                objAux.Task = 3;
                objAux.User = objUsers.User;
                objAux.NumeroRegra = lblID.Text;

                Int64 intResultado = objCampaign.managerCampaignRulesNameSequence(objAux);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Plano de Discagem excluido com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Plano de Discagem !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Plano de Discagem !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo Plano de Discagem";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                txtRegra.Text = "";
                gridLista();
            }
            catch
            {

            }
        }
    }
}
