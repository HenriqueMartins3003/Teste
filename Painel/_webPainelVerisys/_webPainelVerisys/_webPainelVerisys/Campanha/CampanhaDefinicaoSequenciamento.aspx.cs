using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Campanha
{
    public partial class Campanha_DefinicaoSequenciamento : System.Web.UI.Page
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
                loadRegra();
                loadDiaSemana();
                loadMascara();
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

        protected void loadRegra()
        {
            ddlRegra.DataSource = objCampaign.listCampaignRules();
            ddlRegra.DataTextField = "NomeRegra";
            ddlRegra.DataValueField = "NumeroRegra";
            ddlRegra.DataBind();
            ddlRegra.Items.Insert(0, new ListItem("Selecione o Plano de Discagem ...", "0"));
        }

        protected void loadDiaSemana()
        {
            ddlSemana.DataSource = objCampaign.listModoAgrupamentoDia();
            ddlSemana.DataTextField = "Descricao";
            ddlSemana.DataValueField = "ID";
            ddlSemana.DataBind();
        }

        protected void loadMascara(String strSequenciamento)
        {
            lbMascara.Items.Clear();
            lbMascaraSelecionada.Items.Clear();

            dtoCampaignMascara objAux = new dtoCampaignMascara();
            lbMascara.DataSource = objCampaign.listCampaignMaskSequence(strSequenciamento, ddlRegra.SelectedValue.ToString(), false);
            lbMascara.DataValueField = "DDD";
            lbMascara.DataTextField = "FONE";
            lbMascara.DataBind();

            lbMascaraSelecionada.DataSource = objCampaign.listCampaignMaskSequence(strSequenciamento, ddlRegra.SelectedValue.ToString(), true);
            lbMascaraSelecionada.DataValueField = "DDD";
            lbMascaraSelecionada.DataTextField = "FONE";
            lbMascaraSelecionada.DataBind();
        }

        protected void loadMascara()
        {
            lbMascara.Items.Clear();
            lbMascaraSelecionada.Items.Clear();

            dtoCampaignMascara objAux = new dtoCampaignMascara();
            lbMascara.DataSource = objCampaign.listCampaignMaskSequence("", "");
            lbMascara.DataValueField = "DDD";
            lbMascara.DataTextField = "FONE";
            lbMascara.DataBind();
        }

        protected void ddlRegra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegra.SelectedIndex > 0)
            {
                gridLista(ddlRegra.SelectedValue.ToString());
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
            else
            {
                Limpar();
            }
        }

        protected void gridLista(String IDRegra)
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
            bfID.DataField = "IDDEFINICAO";
            bfID.HeaderText = "ID";
            bfID.HeaderStyle.CssClass = "gridViewHeader1";
            bfID.ItemStyle.CssClass = "gridViewValues3";
            bfID.ItemStyle.Width = 25;
            bfID.SortExpression = "IDDEFINICAO";
            bfID.Visible = false;
            gdRegistros.Columns.Add(bfID);

            BoundField bfDIASEMANA = new BoundField();
            bfDIASEMANA.DataField = "MODOAGRUPAMENTO";
            bfDIASEMANA.HeaderText = "Dia Semana";
            bfDIASEMANA.HeaderStyle.CssClass = "gridViewHeader";
            bfDIASEMANA.ItemStyle.CssClass = "gridViewValues2";
            bfDIASEMANA.ItemStyle.Width = 100;
            bfDIASEMANA.Visible = false;
            bfDIASEMANA.SortExpression = "MODOAGRUPAMENTO";
            gdRegistros.Columns.Add(bfDIASEMANA);

            BoundField bfDIASEMANA_DESC = new BoundField();
            bfDIASEMANA_DESC.DataField = "MODOAGRUPAMENTO_DESC";
            bfDIASEMANA_DESC.HeaderText = "Dia Semana";
            bfDIASEMANA_DESC.HeaderStyle.CssClass = "gridViewHeader";
            bfDIASEMANA_DESC.ItemStyle.CssClass = "gridViewValues2";
            bfDIASEMANA_DESC.ItemStyle.Width = 100;
            bfDIASEMANA_DESC.SortExpression = "MODOAGRUPAMENTO_DESC";
            gdRegistros.Columns.Add(bfDIASEMANA_DESC);


            BoundField bfHORAINICIAL = new BoundField();
            bfHORAINICIAL.DataField = "HORAINICIAL";
            bfHORAINICIAL.HeaderText = "Hora Inicial";
            bfHORAINICIAL.HeaderStyle.CssClass = "gridViewHeader";
            bfHORAINICIAL.ItemStyle.CssClass = "gridViewValues2";
            bfHORAINICIAL.ItemStyle.Width = 100;
            bfHORAINICIAL.SortExpression = "HORAINICIAL";
            bfHORAINICIAL.Visible = false;
            gdRegistros.Columns.Add(bfHORAINICIAL);

            BoundField bfHORAINICIAL_DESC = new BoundField();
            bfHORAINICIAL_DESC.DataField = "HORAINICIAL_DESC";
            bfHORAINICIAL_DESC.HeaderText = "Hora Inicial";
            bfHORAINICIAL_DESC.HeaderStyle.CssClass = "gridViewHeader";
            bfHORAINICIAL_DESC.ItemStyle.CssClass = "gridViewValues2";
            bfHORAINICIAL_DESC.ItemStyle.Width = 100;
            bfHORAINICIAL_DESC.SortExpression = "HORAINICIAL_DESC";
            gdRegistros.Columns.Add(bfHORAINICIAL_DESC);



            BoundField bfHORAFINAL = new BoundField();
            bfHORAFINAL.DataField = "HORAFINAL";
            bfHORAFINAL.HeaderText = "Hora Final";
            bfHORAFINAL.HeaderStyle.CssClass = "gridViewHeader";
            bfHORAFINAL.ItemStyle.CssClass = "gridViewValues2";
            bfHORAFINAL.ItemStyle.Width = 100;
            bfHORAFINAL.SortExpression = "HORAFINAL";
            bfHORAFINAL.Visible = false;
            gdRegistros.Columns.Add(bfHORAFINAL);

            BoundField bfHORAFINAL_DESC = new BoundField();
            bfHORAFINAL_DESC.DataField = "HORAFINAL_DESC";
            bfHORAFINAL_DESC.HeaderText = "Hora Final";
            bfHORAFINAL_DESC.HeaderStyle.CssClass = "gridViewHeader";
            bfHORAFINAL_DESC.ItemStyle.CssClass = "gridViewValues2";
            bfHORAFINAL_DESC.ItemStyle.Width = 100;
            bfHORAFINAL_DESC.SortExpression = "HORAFINAL_DESC";
            gdRegistros.Columns.Add(bfHORAFINAL_DESC);

            BoundField bfDEFINICAOSEQUENCIAMENTO = new BoundField();
            bfDEFINICAOSEQUENCIAMENTO.DataField = "DEFINICAOSEQUENCIAMENTO";
            bfDEFINICAOSEQUENCIAMENTO.HeaderText = "Sequenciamento";
            bfDEFINICAOSEQUENCIAMENTO.HeaderStyle.CssClass = "gridViewHeader";
            bfDEFINICAOSEQUENCIAMENTO.ItemStyle.CssClass = "gridViewValues2";
            bfDEFINICAOSEQUENCIAMENTO.ItemStyle.Width = 100;
            bfDEFINICAOSEQUENCIAMENTO.SortExpression = "DEFINICAOSEQUENCIAMENTO";
            bfDEFINICAOSEQUENCIAMENTO.Visible = false;
            gdRegistros.Columns.Add(bfDEFINICAOSEQUENCIAMENTO);

            BoundField bfDEFINICAOSEQUENCIAMENTOUSERVIEW = new BoundField();
            bfDEFINICAOSEQUENCIAMENTOUSERVIEW.DataField = "DEFINICAOSEQUENCIAMENTOUSERVIEW";
            bfDEFINICAOSEQUENCIAMENTOUSERVIEW.HeaderText = "Sequenciamento";
            bfDEFINICAOSEQUENCIAMENTOUSERVIEW.HeaderStyle.CssClass = "gridViewHeader";
            bfDEFINICAOSEQUENCIAMENTOUSERVIEW.ItemStyle.CssClass = "gridViewValues2";
            bfDEFINICAOSEQUENCIAMENTOUSERVIEW.ItemStyle.Width = 400;
            bfDEFINICAOSEQUENCIAMENTOUSERVIEW.SortExpression = "DEFINICAOSEQUENCIAMENTOUSERVIEW";
            bfDEFINICAOSEQUENCIAMENTOUSERVIEW.Visible = true;
            gdRegistros.Columns.Add(bfDEFINICAOSEQUENCIAMENTOUSERVIEW);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objCampaign.listCampaignDialSequence(IDRegra);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem Sequenciamentos Cadastrados !! </div>";
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
                lblTituloDiv.Text = "Alteração de Sequenciamento";

                lblID.Text = gdRegistros.DataKeys[index]["IDDEFINICAO"].ToString();
                ddlSemana.SelectedValue = gdRegistros.DataKeys[index]["MODOAGRUPAMENTO"].ToString();

                txtHoraInicial.Text = gdRegistros.DataKeys[index]["HORAINICIAL_DESC"].ToString();
                txtHoraFinal.Text = gdRegistros.DataKeys[index]["HORAFINAL_DESC"].ToString();

                loadMascara(gdRegistros.DataKeys[index]["DEFINICAOSEQUENCIAMENTO"].ToString());

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Sequenciamento";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["IDDEFINICAO"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["HORAINICIAL_DESC"].ToString() + " à " + gdRegistros.DataKeys[index]["HORAFINAL_DESC"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsRegistros = objCampaign.listCampaignDialSequence(ddlRegra.SelectedValue.ToString());

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
            gridLista(ddlRegra.SelectedValue.ToString());
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
            if (lblTituloDiv.Text == "Cadastrar novo Sequenciamento")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Sequenciamento")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Sequenciamento")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (ddlRegra.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Regra</b> deve ser selecionada !! </div>";
                    return;
                }

                if (txtHoraInicial.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Hora Inicial</b> deve ser definida !! </div>";
                    return;
                }

                if (txtHoraFinal.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Hora Final</b> deve ser definida !! </div>";
                    return;
                }

                if (lbMascaraSelecionada.Items.Count < 1)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Orderm de Discagem</b> deve ser definida !! </div>";
                    return;
                }

                dtoCampaignRule objAux = new dtoCampaignRule();
                objAux.Task = 1;
                objAux.User = objUsers.User;
                objAux.NumeroRegra = ddlRegra.SelectedValue.ToString();
                objAux.IDModoAgrupamento = ddlSemana.SelectedValue.ToString();

                try
                {
                    objAux.HoraInicial = Convert.ToDateTime("1900-01-01 " + txtHoraInicial.Text);
                    objAux.HoraFinal = Convert.ToDateTime("1900-01-01 " + txtHoraFinal.Text);
                }
                catch
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O valor de <b>Hora Inicial e/ou Hora Final </b>estão invalidos !! </div>";
                    return;
                }
                
                objAux.DefinicaoSequenciamento = String.Empty;
                objAux.DefinicaoSequenciamentoUserView = String.Empty;

                Int32 iPosicao = 0;
                if (lbMascaraSelecionada.Items.Count > 0)
                {
                    foreach (ListItem li in lbMascaraSelecionada.Items)
                    {
                        String strDDD = li.Value.ToString().PadRight(31, ' ') + "+ ";
                        String strDDDUserView = li.Value.ToString();
                        String strFone = li.Text.ToString().PadRight(31, ' ') + "# ";
                        String strFoneUserView = li.Text.ToString();
                        String strHInicial = "00:00:00".ToString() + " # ";
                        String strHFinal = "23:59:59".ToString() + "\r\n";

                        objAux.DefinicaoSequenciamento = objAux.DefinicaoSequenciamento + strDDD + strFone + strHInicial + strHFinal;
                        objAux.DefinicaoSequenciamentoUserView = objAux.DefinicaoSequenciamentoUserView + strFone;// +":";

                        iPosicao++;
                    }
                }

                Int64 intResultado = objCampaign.managerCampaignRulesSequence(objAux);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Nova Ordem de Sequenciamento Cadastrada com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Nova Ordem de Sequenciamento !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a gravação da Nova Ordem de Sequenciamento !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                if (ddlRegra.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Regra</b> deve ser selecionada !! </div>";
                    return;
                }

                if (txtHoraInicial.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Hora Inicial</b> deve ser definida !! </div>";
                    return;
                }

                if (txtHoraFinal.Text == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Hora Final</b> deve ser definida !! </div>";
                    return;
                }

                if (lbMascaraSelecionada.Items.Count < 1)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>A <b>Ordem de Discagem</b> deve ser definida !! </div>";
                    return;
                }

                dtoCampaignRule objAux = new dtoCampaignRule();
                objAux.Task = 2;
                objAux.User = objUsers.User;
                objAux.IdSequenciamento = Convert.ToInt32(lblID.Text);
                objAux.NumeroRegra = ddlRegra.SelectedValue.ToString();
                objAux.IDModoAgrupamento = ddlSemana.SelectedValue.ToString();

                try
                {
                    objAux.HoraInicial = Convert.ToDateTime("1900-01-01 " + txtHoraInicial.Text);
                    objAux.HoraFinal = Convert.ToDateTime("1900-01-01 " + txtHoraFinal.Text);
                }
                catch
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O valor de <b>Hora Inicial e/ou Hora Final </b>estão invalidos !! </div>";
                    return;
                }

                objAux.DefinicaoSequenciamento = String.Empty;
                objAux.DefinicaoSequenciamentoUserView = String.Empty;

                Int32 iPosicao = 0;
                if (lbMascaraSelecionada.Items.Count > 0)
                {
                    foreach (ListItem li in lbMascaraSelecionada.Items)
                    {
                        String strDDD = li.Value.ToString().PadRight(31, ' ') + "+ ";
                        String strDDDUserView = li.Value.ToString();
                        String strFone = li.Text.ToString().PadRight(31, ' ') + "# ";
                        String strFoneUserView = li.Text.ToString();
                        String strHInicial = "00:00:00".ToString() + " # ";
                        String strHFinal = "23:59:59".ToString() + "\r\n";

                        objAux.DefinicaoSequenciamento = objAux.DefinicaoSequenciamento + strDDD + strFone + strHInicial + strHFinal;
                        objAux.DefinicaoSequenciamentoUserView = objAux.DefinicaoSequenciamentoUserView + strFone;// +":";

                        iPosicao++;
                    }
                }

                Int64 intResultado = objCampaign.managerCampaignRulesSequence(objAux);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração de Ordem de Sequenciamento realizado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Ordem de Sequenciamento !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Ordem de Sequenciamento !! </div>";
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
                objAux.IdSequenciamento = Convert.ToInt32(lblID.Text);

                Int64 intResultado = objCampaign.managerCampaignRulesSequence(objAux);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Ordem de Sequenciamento excluido com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Ordem de Sequenciamento !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro ao excluir Ordem de Sequenciamento !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar novo Sequenciamento";
                modManutencao.Visible = true;
                modExcluir.Visible = false;

                
                loadDiaSemana();
                loadMascara();

                txtHoraFinal.Text = "";
                txtHoraInicial.Text = "";
                ddlSemana.SelectedValue = "0";
                gridLista(ddlRegra.SelectedValue.ToString());
            }
            catch
            {

            }
        }

        protected void btnALeft_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li in lbMascaraSelecionada.Items)
            {
                if (li.Selected)
                {
                    lbMascara.Items.Add(li);
                }
            }

            foreach (ListItem li in lbMascara.Items)
            {
                foreach (ListItem li2 in lbMascaraSelecionada.Items)
                {
                    if (li.Value == li2.Value)
                    {
                        lbMascaraSelecionada.Items.Remove(li2);
                        break;
                    }
                }
            }
        }

        protected void btnARight_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li in lbMascara.Items)
            {
                if (li.Selected)
                {
                    if (li.Text.Substring(0, 1) == "+")
                        li.Text = li.Text.Substring(2, li.Text.Length - 2);

                    lbMascaraSelecionada.Items.Add(li);
                }
            }

            foreach (ListItem li in lbMascaraSelecionada.Items)
            {
                foreach (ListItem li2 in lbMascara.Items)
                {
                    if (li.Value == li2.Value)
                    {
                        lbMascara.Items.Remove(li2);
                        break;
                    }
                }
            }
        }
    }
}
