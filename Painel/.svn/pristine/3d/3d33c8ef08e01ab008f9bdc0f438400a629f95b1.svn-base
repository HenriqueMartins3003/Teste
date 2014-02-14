using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.ResultadoOperacao
{
    public partial class ResultadoOperacaoCampanha : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        RO objROCampanha = new RO();

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
                AccessMailing();
                
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

        private void PageConfig()
        {
            dtoPageConfig objdtoPageConfig = null;
            bllPageConfig objPageConfig = new bllPageConfig();

            String strApplication = Session["ObjApplication"].ToString();
            objdtoPageConfig = objPageConfig.listPageConfig(this.Form.ID, strApplication);

            lblTitulo.Text = objdtoPageConfig.Descricao;
        }

        private void AccessMailing()
        {
            List<dtoUsersProfiles> listProfile = objUsersProfiles.AccessMailing(objUsers);
            if (listProfile.Count > 1)
            {
                loadCampaign(true);
                divCampanhaContent.Visible = true;
                divROContent.Visible = false;
            }
            else
            {
                loadCampaign(false);
                divCampanhaContent.Visible = false;
                divROContent.Visible = true;
                gridListaROCampanha(ddlCampaign.SelectedValue.ToString());
                loadRO(ddlCampaign.SelectedValue.ToString());
                loadCampaignAssoc(ddlCampaign.SelectedValue.ToString());
            }
        }

        protected void loadCampaign(Boolean bolVisible)
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();

            if (bolVisible)
                ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void loadCampaignAssoc(String IDCampanha)
        {
            ddlCampaignAssoc.DataSource = objROCampanha.listCampaignNotAssociated(IDCampanha, objUsers);
            ddlCampaignAssoc.DataTextField = "NomeCampanha";
            ddlCampaignAssoc.DataValueField = "Campaign";
            ddlCampaignAssoc.DataBind();
            ddlCampaignAssoc.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        public void loadRO(String IDCampanha)
        {
            RO objRO = new RO();
            lbRO.DataSource = objRO.DatasetRO(IDCampanha, objUsers);
            lbRO.DataValueField = "IDRO";
            lbRO.DataTextField = "DESCRICAORO";
            lbRO.DataBind();
        }

        public void loadROConfiguration(String IDCampanha)
        {
            rModulos.DataSource = objROCampanha.listROConfiguration(IDCampanha, objUsers);
            rModulos.DataBind();


        }

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            divROContent.Visible = true;
            gridListaROCampanha(ddlCampaign.SelectedValue.ToString());
            loadRO(ddlCampaign.SelectedValue.ToString());
            loadCampaignAssoc(ddlCampaign.SelectedValue.ToString());
        }

        protected void gridListaROCampanha(String IDCampanha)
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

            ButtonField btnAssociar = new ButtonField();
            btnAssociar.ButtonType = ButtonType.Image;
            btnAssociar.ImageUrl = "~/img/calendar.gif";
            btnAssociar.CommandName = "Ass";
            btnAssociar.ItemStyle.Width = 25;
            btnAssociar.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnAssociar.HeaderText = "";
            btnAssociar.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnAssociar);

            BoundField BFIDCampanha = new BoundField();
            BFIDCampanha.DataField = "NUMEROCAMPANHA";
            BFIDCampanha.HeaderText = "Codigo";
            BFIDCampanha.HeaderStyle.CssClass = "gridViewHeader1";
            BFIDCampanha.ItemStyle.CssClass = "gridViewValues3";
            BFIDCampanha.ItemStyle.Width = 100;
            BFIDCampanha.SortExpression = "NUMEROCAMPANHA";
            BFIDCampanha.Visible = false;
            gdRegistros.Columns.Add(BFIDCampanha);

            BoundField DSCNome = new BoundField();
            DSCNome.DataField = "NOME";
            DSCNome.HeaderText = "Nome";
            DSCNome.HeaderStyle.CssClass = "gridViewHeader";
            DSCNome.ItemStyle.CssClass = "gridViewValues2";
            DSCNome.ItemStyle.Width = 400;
            DSCNome.SortExpression = "NOME";
            gdRegistros.Columns.Add(DSCNome);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            RO objROCampanha = new RO();
            gdRegistros.DataSource = objROCampanha.DatasetCampaignAssoc(IDCampanha, objUsers);
            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Alteração de Associação de R.O. X Campanha";
                modManutencaoCampanhaRO.Visible = true;
                modExcluirCampanhaRO.Visible = false;
                modConfigurarReagendamento.Visible = false;
                int index = int.Parse((string)e.CommandArgument);
                lblIDCampanhaRO.Text = gdRegistros.DataKeys[index]["NUMEROCAMPANHA"].ToString();

                ddlCampaignAssoc.DataSource = objCampaign.listCampaignAssociated(objUsers);
                ddlCampaignAssoc.DataBind();
                ddlCampaignAssoc.SelectedValue = gdRegistros.DataKeys[index]["NUMEROCAMPANHA"].ToString();
                ddlCampaignAssoc.Enabled = false;

                // Alimenta a LabelBox com os ROs já cadastrados
                lbROSelecionados.DataSource = objROCampanha.listROAssociated(gdRegistros.DataKeys[index]["NUMEROCAMPANHA"].ToString(), objUsers);
                lbROSelecionados.DataValueField = "IdRO";
                lbROSelecionados.DataTextField = "DescricaoRO";
                lbROSelecionados.DataBind();

                // Remove os ROs já Cadastrados do LabelBox de ROs.
                foreach (ListItem li1 in lbROSelecionados.Items)
                {
                    lbRO.Items.Remove(li1);
                }

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão de Associação de R.O. X Campanha";
                modManutencaoCampanhaRO.Visible = false;
                modConfigurarReagendamento.Visible = false;
                modExcluirCampanhaRO.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblIDCampanhaRO.Text = gdRegistros.DataKeys[index]["NUMEROCAMPANHA"].ToString();
                lblCampanhaROExclusao.Text = gdRegistros.DataKeys[index]["NOME"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Ass")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Configuração de Associação de R.O. X Campanha";
                modManutencaoCampanhaRO.Visible = false;
                modExcluirCampanhaRO.Visible = false;
                modConfigurarReagendamento.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblIDCampanhaRO.Text = gdRegistros.DataKeys[index]["NUMEROCAMPANHA"].ToString();
                loadROConfiguration(gdRegistros.DataKeys[index]["NUMEROCAMPANHA"].ToString());

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            RO objRO = new RO();
            DataSet dsRegistros = objRO.DatasetCampaignAssoc(ddlCampaign.SelectedValue.ToString(), objUsers);

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
            gridListaROCampanha(ddlCampaign.SelectedValue.ToString());
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
            if (lblTituloDiv.Text == "Cadastrar nova Associação de R.O. X Campanha")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração de Associação de R.O. X Campanha")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão de Associação de R.O. X Campanha")
            {
                Exclusao();
            }
            else if (lblTituloDiv.Text == "Configuração de Associação de R.O. X Campanha")
            {
                AlteracaoReagendamento();
            }

            Limpar();
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        //protected void Cadastro()
        //{
        //    try
        //    {
        //        if (ddlCampaignAssoc.SelectedIndex == 0)
        //        {
        //            lblResponse.Text = "<div class='RNOK'>Selecione a <b>Campanha</b> a ser associada !! </div>";
        //            divResponse.Visible = true;
        //            return;
        //        }

        //        if (lbROSelecionados.Items.Count <= 0)
        //        {
        //            lblResponse.Text = "<div class='RNOK'>Selecione no Minimo 1 (Um) <b>R.O.</b> a Associação !! </div>";
        //            divResponse.Visible = true;
        //            return;
        //        }

        //        Int64 intResultado = 0;
        //        for (int i = 0; i < lbROSelecionados.Items.Count; i++)
        //        {
        //            dtoRO objDtoRO = new dtoRO();
        //            objDtoRO.Task = 1;
        //            objDtoRO.Campanha = ddlCampaignAssoc.SelectedValue.ToString();
        //            objDtoRO.IdRO = int.Parse(lbROSelecionados.Items[i].Value);

        //            //intResultado = objROCampanha.ManagerROCampanha(objDtoRO, objUsers);
        //        }

        //        if (intResultado > 0)
        //        {
        //            lblResponse.Text = "<div class='ROK'>A associação <b>foi realizada</b> com sucesso</div>";
        //            divResponse.Visible = true;
        //        }
        //    }
        //    catch (Exception eCadastro)
        //    {
        //        lblResponse.Text = "<div class='RNOK'> Erro durante a Associção do R.O. X Campanha !! </div>";
        //        divResponse.Visible = true;
        //    }
        //}

        //protected void Alteracao()
        //{
        //    UsersProfiles objProfiles = new UsersProfiles();

        //    try
        //    {
        //        if (ddlCampaignAssoc.SelectedIndex == 0)
        //        {
        //            lblResponse.Text = "<div class='RNOK'>Selecione a <b>Campanha</b> a ser associada !! </div>";
        //            divResponse.Visible = true;
        //            return;
        //        }

        //        if (lbROSelecionados.Items.Count <= 0)
        //        {
        //            lblResponse.Text = "<div class='RNOK'>Selecione no Minimo 1 (Um) <b>R.O.</b> a Associação !! </div>";
        //            divResponse.Visible = true;
        //            return;
        //        }

        //        Exclusao();
        //        Cadastro();

                
        //        //dtoRO objDtoRO = new dtoRO();
        //        //objDtoRO.Task = 2;
        //        //objDtoRO.IDTipoRO = Convert.ToInt64(lblIDCampanhaRO.Text);
        //        //objDtoRO.TipoRO = txtDescricao.Text;
        //        //objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();

        //        //Int64 intResultado = objTipoRO.ManagerROType(objDtoRO);

        //        //if (intResultado > 0)
        //        //{
        //        //    lblResponse.Text = "<div class='ROK'> Tipo de R.O. Alterado com sucesso !! </div>";
        //        //    divResponse.Visible = true;
        //        //}
        //        //else
        //        //{
        //        //    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Tipo de R.O. !! </div>";
        //        //    divResponse.Visible = true;
        //        //}
        //    }
        //    catch (Exception eAlteracao)
        //    {
        //        divResponse.Visible = true;
        //        lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Tipo de R.O. !! </div>";
        //    }
        //}

        //protected void Exclusao()
        //{
        //    try
        //    {
        //        dtoRO objDtoRO = new dtoRO();
        //        objDtoRO.Task = 3;
        //        objDtoRO.Campanha = lblIDCampanhaRO.Text;

        //        //Int64 idExclusaoOperacao = objROCampanha.ManagerROCampanha(objDtoRO, objUsers);
        //        //if (idExclusaoOperacao > 0)
        //        //{
        //        //    lblResponse.Text = "<div class='ROK'> Associação de R.O. X Campanha, Excluido com Sucesso !! </div>";
        //        //    divResponse.Visible = true;
        //        //}
        //        //else
        //        //{
        //        //    lblResponse.Text = "<div class='RNOK'> Erro ao excluir Associação de R.O. X Campanha !! </div>";
        //        //    divResponse.Visible = true;
        //        //}
        //    }
        //    catch
        //    {

        //    }
        //}

        //protected void AlteracaoReagendamento()
        //{
        //    UsersProfiles objProfiles = new UsersProfiles();

        //    try
        //    {
        //        foreach (RepeaterItem ri in this.rModulos.Items)
        //        {
        //            Label ID = (Label)ri.FindControl("lblID");
        //            CheckBox ckBoxReagendamento = (CheckBox)ri.FindControl("chkReagendamento");
        //            CheckBox ckBoxReagEspecifico = (CheckBox)ri.FindControl("chkReagEspecifico");
        //            TextBox TempoRetorno = (TextBox)ri.FindControl("txtTempoRetorno");

        //            dtoRO objDtoRO = new dtoRO();
        //            objDtoRO.Task = 4;
        //            objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();
        //            objDtoRO.IDROCampanha = Convert.ToInt64(ID.Text);
        //            objDtoRO.ReagendamentoRO = ckBoxReagendamento.Checked == true ? true : false;
        //            objDtoRO.ReagendamentoEspecificoRO = ckBoxReagEspecifico.Checked == true ? true : false;
        //            objDtoRO.TempoReagendamentoRO = Convert.ToInt16(TempoRetorno.Text);

        //            //Int64 intROCampanha = objROCampanha.ManagerROCampanha(objDtoRO, objUsers);
        //            //if (intROCampanha > 0)
        //            //{
        //            //    divResponse.Visible = true;
        //            //    lblResponse.Text = "<div class='ROK'> Alteração de Configuração R.O. X Campanha realizada com sucesso !! </div>";
        //            //}
        //            //else
        //            //{
        //            //    divResponse.Visible = true;
        //            //    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Configuração R.O. X Campanha !! </div>";
        //            //}
        //        }
        //    }
        //    catch (Exception eAlteracao)
        //    {
        //        divResponse.Visible = true;
        //        lblResponse.Text = "<div class='RNOK'> Erro Alteração de Configuração R.O. X Campanha !! </div>";
        //    }
        //}



        protected void Cadastro()
        {
            try
            {
                if (ddlCampaignAssoc.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione a <b>Campanha</b> a ser associada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (lbROSelecionados.Items.Count <= 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione no Minimo 1 (Um) <b>R.O.</b> a Associação !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 1;
                objDtoRO.Campanha = ddlCampaignAssoc.SelectedValue.ToString();

                foreach (ListItem li in lbROSelecionados.Items)
                {
                    objDtoRO.ListaRO += li.Value.ToString() + ",";
                }

                objDtoRO.ListaRO = objDtoRO.ListaRO.Substring(0, objDtoRO.ListaRO.Length - 1);

                String Result = objROCampanha.PAN_ManagerROCampanha(objDtoRO, objUsers);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante a Associção do R.O. X Campanha !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                if (ddlCampaignAssoc.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione a <b>Campanha</b> a ser associada !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (lbROSelecionados.Items.Count <= 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Selecione no Minimo 1 (Um) <b>R.O.</b> a Associação !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 2;
                objDtoRO.Campanha = ddlCampaignAssoc.SelectedValue.ToString();

                foreach (ListItem li in lbROSelecionados.Items)
                {
                    objDtoRO.ListaRO += li.Value.ToString() + ",";
                }

                objDtoRO.ListaRO = objDtoRO.ListaRO.Substring(0, objDtoRO.ListaRO.Length - 1);

                String Result = objROCampanha.PAN_ManagerROCampanha(objDtoRO, objUsers);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Tipo de R.O. !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoRO objDtoRO = new dtoRO();
                objDtoRO.Task = 3;
                objDtoRO.Campanha = ddlCampaignAssoc.SelectedValue.ToString();

                String Result = objROCampanha.PAN_ManagerROCampanha(objDtoRO, objUsers);
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

            }
        }

        protected void AlteracaoReagendamento()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    Label ID = (Label)ri.FindControl("lblID");
                    CheckBox ckBoxReagendamento = (CheckBox)ri.FindControl("chkReagendamento");
                    CheckBox ckBoxReagEspecifico = (CheckBox)ri.FindControl("chkReagEspecifico");
                    TextBox TempoRetorno = (TextBox)ri.FindControl("txtTempoRetorno");

                    dtoRO objDtoRO = new dtoRO();
                    objDtoRO.Task = 4;
                    objDtoRO.Campanha = ddlCampaign.SelectedValue.ToString();
                    objDtoRO.IDROCampanha = Convert.ToInt64(ID.Text);
                    objDtoRO.ReagendamentoRO = ckBoxReagendamento.Checked == true ? true : false;
                    objDtoRO.ReagendamentoEspecificoRO = ckBoxReagEspecifico != null ? (ckBoxReagEspecifico.Checked == true ? true : false) : false;
                    objDtoRO.TempoReagendamentoRO = TempoRetorno != null ? Convert.ToInt16(TempoRetorno.Text) : 0;

                    String Result = objROCampanha.PAN_ManagerROCampanha(objDtoRO, objUsers);
                    if (Result.Substring(0, 4).ToString().ToUpper() == "ERROR")
                    {
                        lblResponse.Text = "<div class='RNOK'>" + Result + "</div>";
                        divResponse.Visible = true;
                        break;
                    }
                    else
                    {
                        lblResponse.Text = "<div class='ROK'>" + Result + "</div>";
                        divResponse.Visible = true;
                    }
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro Alteração de Configuração R.O. X Campanha !! </div>";
            }
        }







        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar nova Associação de R.O. X Campanha";
                modManutencaoCampanhaRO.Visible = true;
                modExcluirCampanhaRO.Visible = false;
                modConfigurarReagendamento.Visible = false;
                ddlCampaignAssoc.Enabled = true;
                lbROSelecionados.Items.Clear();
                loadRO(ddlCampaign.SelectedValue.ToString());
                gridListaROCampanha(ddlCampaign.SelectedValue.ToString());
                loadCampaignAssoc(ddlCampaign.SelectedValue.ToString());
            }
            catch
            {

            }
        }

        protected void buttonArrowLeft_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li1 in lbROSelecionados.Items)
            {
                if (li1.Selected)
                {
                    lbRO.Items.Add(li1);
                }
            }

            foreach (ListItem li1 in lbRO.Items)
            {
                if (li1.Selected)
                {
                    lbROSelecionados.Items.Remove(li1);
                }
            }
        }

        protected void buttonArrowRight_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li1 in lbRO.Items)
            {
                if (li1.Selected)
                {
                    lbROSelecionados.Items.Add(li1);
                }
            }

            foreach (ListItem li1 in lbROSelecionados.Items)
            {
                if (li1.Selected)
                {
                    lbRO.Items.Remove(li1);
                }
            }
        }

        protected void chkReagendarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReagendarTodos.Checked == true)
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkReagendamento");
                    ckBox.Checked = true;
                }
            }
            else
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkReagendamento");
                    ckBox.Checked = false;
                }
            }
        }

        protected void chkReagEspecificoTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReagEspecificoTodos.Checked == true)
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkReagEspecifico");
                    ckBox.Checked = true;
                }
            }
            else
            {
                foreach (RepeaterItem ri in this.rModulos.Items)
                {
                    CheckBox ckBox = (CheckBox)ri.FindControl("chkReagEspecifico");
                    ckBox.Checked = false;
                }
            }
        }
    }
}
