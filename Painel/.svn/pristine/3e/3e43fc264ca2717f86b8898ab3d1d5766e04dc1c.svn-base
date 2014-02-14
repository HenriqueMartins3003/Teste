using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;

namespace _webPainelVerisys.doNotCallList
{
    public partial class doNotCallReceptivo : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        blldoNotCallList objdoNotCallList = new blldoNotCallList();
        Validadores objValidador = new Validadores();

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
            BoundField bfidReceptivo = new BoundField();
            bfidReceptivo.DataField = "idReceptivo";
            bfidReceptivo.HeaderText = "idReceptivo";
            bfidReceptivo.HeaderStyle.CssClass = "gridViewHeader1";
            bfidReceptivo.ItemStyle.CssClass = "gridViewValues3";
            bfidReceptivo.ItemStyle.Width = 50;
            bfidReceptivo.Visible = false;
            bfidReceptivo.SortExpression = "idReceptivo";
            gdRegistros.Columns.Add(bfidReceptivo);

            BoundField bfDDD = new BoundField();
            bfDDD.DataField = "DDD";
            bfDDD.HeaderText = "DDD";
            bfDDD.HeaderStyle.CssClass = "gridViewHeader1";
            bfDDD.ItemStyle.CssClass = "gridViewValues3";
            bfDDD.ItemStyle.Width = 50;
            bfDDD.Visible = false;
            bfDDD.SortExpression = "DDD";
            gdRegistros.Columns.Add(bfDDD);

            BoundField bfNumeroTelefone = new BoundField();
            bfNumeroTelefone.DataField = "NumeroTelefone";
            bfNumeroTelefone.HeaderText = "Telefone";
            bfNumeroTelefone.HeaderStyle.CssClass = "gridViewHeader1";
            bfNumeroTelefone.ItemStyle.CssClass = "gridViewValues3";
            bfNumeroTelefone.ItemStyle.Width = 100;
            bfNumeroTelefone.Visible = false;
            bfNumeroTelefone.SortExpression = "NumeroTelefone";
            gdRegistros.Columns.Add(bfNumeroTelefone);

            BoundField bfCPF = new BoundField();
            bfCPF.DataField = "CPF";
            bfCPF.HeaderText = "CPF";
            bfCPF.HeaderStyle.CssClass = "gridViewHeader1";
            bfCPF.ItemStyle.CssClass = "gridViewValues3";
            bfCPF.ItemStyle.Width = 100;
            bfCPF.Visible = true;
            bfCPF.SortExpression = "CPF";
            gdRegistros.Columns.Add(bfCPF);

            BoundField bfDataSolicitacao = new BoundField();
            bfDataSolicitacao.DataField = "DataSolicitacao";
            bfDataSolicitacao.HeaderText = "DataSolicitacao";
            bfDataSolicitacao.HeaderStyle.CssClass = "gridViewHeader1";
            bfDataSolicitacao.ItemStyle.CssClass = "gridViewValues3";
            bfDataSolicitacao.ItemStyle.Width = 150;
            bfDataSolicitacao.Visible = true;
            bfDataSolicitacao.SortExpression = "DataSolicitacao";
            gdRegistros.Columns.Add(bfDataSolicitacao);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objdoNotCallList.UINT_LISTRECEPTIVO(objUsers);
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
            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["idReceptivo"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["CPF"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objdoNotCallList.UINT_LISTRECEPTIVO(objUsers);
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
                if (txtDDD.Text != String.Empty)
                {
                    if (!objValidador.isDDD(txtDDD.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>DDD</b> não é valido !! </div>";
                        return;
                    }
                }

                if (txtTelefone.Text != String.Empty)
                {
                    if (!objValidador.isTelefone(txtTelefone.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>Telefone</b> não é valido !! </div>";
                        return;
                    }
                }

                if (txtCPF.Text != String.Empty)
                {
                    if (!objValidador.isCPF(txtCPF.Text))
                    {
                        divResponse.Visible = true;
                        lblResponse.Text = "<div class='RNOK'>O Campo <b>CPF</b> não é valido !! </div>";
                        return;
                    }
                }

                dtoNotCallReceptivo dtoAux = new dtoNotCallReceptivo();
                dtoAux.Task = 1;
                dtoAux.DDD = txtDDD.Text;
                dtoAux.Telefone = txtTelefone.Text;
                dtoAux.CPF = txtCPF.Text;

                dtoResponse dtoResponse = objdoNotCallList.UINT_MANAGER_RECEPTIVO(dtoAux, objUsers);
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

        protected void Exclusao()
        {
            try
            {
                dtoNotCallReceptivo dtoAux = new dtoNotCallReceptivo();
                dtoAux.Task = 3;
                dtoAux.IdReceptivo = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objdoNotCallList.UINT_MANAGER_RECEPTIVO(dtoAux, objUsers);
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
                txtDDD.Text = "";
                txtTelefone.Text = "";
                txtCPF.Text = "";
            }
            catch
            {

            }
        }
    }
}
