using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class RessubmissaoMailing : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        Mailings objMailing = new Mailings();

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
                loadCampaign();
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

        protected void loadCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Selecione a Campanha...", "0"));
        }

        protected Boolean loadLote()
        {
            dtoCampaign objAuxCampaign = new dtoCampaign();
            objAuxCampaign.Campaign = ddlCampaign.SelectedValue.ToString();

            //ddlLote.DataSource = objCampaign.listLotAssociated(objAuxCampaign);
            //ddlLote.DataBind();

            List<dtoCampaign> AuxDto = objCampaign.listLotAssociated(objAuxCampaign);
            if (AuxDto != null)
            {
                divResponse.Visible = false;
                ddlLote.DataSource = AuxDto;
                ddlLote.DataTextField = "NomeLote";
                ddlLote.DataValueField = "NumeroLote";
                ddlLote.DataBind();
                ddlLote.Items.Insert(0, new ListItem("Selecione o Lote...", "0"));
                return true;
            }
            else
            {
                lblResponse.Text = "<div class='RNOK'>Essa Campanha não possui modulo de Ressubmissão !! </div>";
                divResponse.Visible = true;
                divLote.Visible = false;
                divRegistro.Visible = false;
                divTelefone.Visible = false;
                return false;
            }
        }

        protected Boolean gridLista()
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

            BoundField IDRegistro = new BoundField();
            IDRegistro.DataField = "RegistroID";
            IDRegistro.HeaderText = "RegistroID";
            IDRegistro.HeaderStyle.CssClass = "gridViewHeader1";
            IDRegistro.ItemStyle.CssClass = "gridViewValues3";
            IDRegistro.ItemStyle.Width = 100;
            IDRegistro.SortExpression = "RegistroID";
            gdRegistros.Columns.Add(IDRegistro);

            BoundField FlagAtivo = new BoundField();
            FlagAtivo.DataField = "StatusRegistro";
            FlagAtivo.HeaderText = "Ativo";
            FlagAtivo.HeaderStyle.CssClass = "gridViewHeader";
            FlagAtivo.ItemStyle.CssClass = "gridViewValues2";
            FlagAtivo.ItemStyle.Width = 100;
            FlagAtivo.SortExpression = "StatusRegistro";
            gdRegistros.Columns.Add(FlagAtivo);

            BoundField LoteAtivo = new BoundField();
            LoteAtivo.DataField = "StatusLot";
            LoteAtivo.HeaderText = "Lote Ativo";
            LoteAtivo.HeaderStyle.CssClass = "gridViewHeader";
            LoteAtivo.ItemStyle.CssClass = "gridViewValues2";
            LoteAtivo.ItemStyle.Width = 100;
            LoteAtivo.SortExpression = "StatusLot";
            gdRegistros.Columns.Add(LoteAtivo);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            //gdRegistros.DataSource = objMailing.listDadosTelefone(ddlCampaign.SelectedValue.ToString(), txtDDD.Text, txtTelefone.Text);
            //gdRegistros.DataBind();

            List<dtoMailing> AuxDto = objMailing.listDadosTelefone(ddlCampaign.SelectedValue.ToString(), txtDDD.Text, txtTelefone.Text);
            if (AuxDto != null)
            {
                divResponse.Visible = false;
                gdRegistros.DataSource = AuxDto;
                gdRegistros.DataBind();
                return true;
            }
            else
            {
                lblResponse.Text = "<div class='RNOK'>Essa Campanha não possui modulo de Ressubmissão !! </div>";
                divResponse.Visible = true;
                return false;
            }
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modDadosRegistro.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                txtRegistroID.Text = gdRegistros.DataKeys[index]["RegistroID"].ToString();
                DadosMailingRegistro();
                modManutencao.Visible = true;
            }
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

        protected void rbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbOpcoes.SelectedValue == "0")
            {
                if (loadLote())
                {
                    divLote.Visible = true;
                    divRegistro.Visible = false;
                    divTelefone.Visible = false;
                }
                else
                {
                    divLote.Visible = false;
                    divRegistro.Visible = false;
                    divTelefone.Visible = false;
                }
            }
            else if (rbOpcoes.SelectedValue == "1")
            {
                divLote.Visible = false;
                divRegistro.Visible = true;
                divTelefone.Visible = false;
            }
            else if (rbOpcoes.SelectedValue == "2")
            {
                divLote.Visible = false;
                divRegistro.Visible = false;
                divTelefone.Visible = true;
            }

            txtDDD.Text = "";
            txtTelefone.Text = "";
            txtRegistroID.Text = "";
            modManutencao.Visible = false;
            modStatusMotivos.Visible = false;
            modDadosRegistro.Visible = false;
            modLista.Visible = false;
            modReagendamento.Visible = false;

            buttonImageFiltrar.Visible = true;
        }

        protected void buttonImageFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            divResponse.Visible = false;

            if (rbOpcoes.SelectedValue == "0")
            {
                if (ddlLote.SelectedIndex == 0)
                {
                    lblResponse.Text = "<div class='RNOK'> É necessário selecionar o Lote !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                divResponse.Visible = false;
                if (DadosMailingLote())
                {
                    modManutencao.Visible = true;
                    modStatusMotivos.Visible = true;
                    modDadosRegistro.Visible = false;
                    modLista.Visible = false;
                }
                else
                {
                    modManutencao.Visible = false;
                    modStatusMotivos.Visible = false;
                    modDadosRegistro.Visible = false;
                    modLista.Visible = false;
                    return;
                }
            }
            else if (rbOpcoes.SelectedValue == "1")
            {
                if (txtRegistroID.Text == String.Empty)
                {
                    lblResponse.Text = "<div class='RNOK'> O campo <b>Registro ID</b> não pode ficar em branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                divResponse.Visible = false;

                if (DadosMailingRegistro())
                {
                    modManutencao.Visible = true;
                    modStatusMotivos.Visible = true;
                    modDadosRegistro.Visible = true;
                    modLista.Visible = false;
                }
                else
                {
                    modManutencao.Visible = false;
                    modStatusMotivos.Visible = false;
                    modDadosRegistro.Visible = false;
                    modLista.Visible = false;
                }
            }
            else if (rbOpcoes.SelectedValue == "2")
            {
                if ((txtDDD.Text == String.Empty) || (txtTelefone.Text == String.Empty))
                {
                    lblResponse.Text = "<div class='RNOK'> Os campos <b>DDD e Telefone</b> não podem ficar em branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                divResponse.Visible = false;

                if (DadosMailingTelefone())
                {
                    modManutencao.Visible = false;
                    modStatusMotivos.Visible = true;
                    modDadosRegistro.Visible = false;
                    modLista.Visible = true;
                }
                else
                {
                    modManutencao.Visible = false;
                    modStatusMotivos.Visible = false;
                    modDadosRegistro.Visible = false;
                    modLista.Visible = false;
                }
            }
        }

        protected Boolean DadosMailingLote()
        {
            List<dtoMailing> AuxDto = objMailing.listStatusMailing(ddlCampaign.SelectedValue.ToString(), ddlLote.SelectedValue.ToString());
            if (AuxDto != null)
            {
                divResponse.Visible = false;
                lbStatusLote.DataSource = AuxDto;
                lbStatusLote.DataValueField = "idStatusMotivo";
                lbStatusLote.DataTextField = "DescricaoStatus";
                lbStatusLote.DataBind();

                lbStatusLoteNovo.DataSource = objMailing.listNovoStatusMailing(ddlCampaign.SelectedValue.ToString());
                lbStatusLoteNovo.DataValueField = "idStatusMotivo";
                lbStatusLoteNovo.DataTextField = "DescricaoStatus";
                lbStatusLoteNovo.DataBind();

                return true;
            }
            else
            {
                lblResponse.Text = "<div class='RNOK'>Essa Campanha não possui modulo de Ressubmissão !! </div>";
                divResponse.Visible = true;
                divLote.Visible = false;
                divRegistro.Visible = false;
                divTelefone.Visible = false;
                return false;
            }

        }

        protected Boolean DadosMailingRegistro()
        {
            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.RegistroID = txtRegistroID.Text;

            SqlDataReader drQuery = objMailing.listDadosRegistro(objAuxMailing);
            if (drQuery == null)
            {
                lblResponse.Text = "<div class='RNOK'>Essa Campanha não possui modulo de Ressubmissão !! </div>";
                divResponse.Visible = true;
                divLote.Visible = false;
                divRegistro.Visible = false;
                divTelefone.Visible = false;
                return false;
            }

            if (drQuery.Read())
            {
                txtIDCampanha.Text = drQuery["ID_CAMPANHA"].ToString();
                txtStatus.Text = drQuery["STATUSCHAMADA"].ToString();
                txtMotivo.Text = drQuery["MOTIVO"].ToString();
                txtTentativas.Text = drQuery["NUMEROTENTATIVAS"].ToString();
                txtReagendamento.Text = drQuery["DATAREAGENDAMENTO"].ToString();
                txtAgente.Text = drQuery["AGENTE"].ToString();

                if (drQuery["FLAG_ATIVO"].ToString().ToUpper() == "TRUE")
                    cbFlagAtivo.Checked = true;

                if (drQuery["LOTE_ATIVO"].ToString().ToUpper() == "TRUE")
                    cbLoteAtivo.Checked = true;

                txtDdd1.Text = drQuery["DDD1"].ToString();
                txtFone1.Text = drQuery["FONE1"].ToString();
                txtDdd2.Text = drQuery["DDD2"].ToString();
                txtFone2.Text = drQuery["FONE2"].ToString();
                txtDdd3.Text = drQuery["DDD3"].ToString();
                txtFone3.Text = drQuery["FONE3"].ToString();
                txtDdd4.Text = drQuery["DDD4"].ToString();
                txtFone4.Text = drQuery["FONE4"].ToString();
                txtDdd5.Text = drQuery["DDD5"].ToString();
                txtFone5.Text = drQuery["FONE5"].ToString();
            }

            lbStatusLote.DataSource = objMailing.listStatusRegistro(ddlCampaign.SelectedValue.ToString(), txtRegistroID.Text);
            lbStatusLote.DataValueField = "idStatusMotivo";
            lbStatusLote.DataTextField = "DescricaoStatus";
            lbStatusLote.DataBind();

            lbStatusLoteNovo.DataSource = objMailing.listNovoStatusMailingReagendamento(ddlCampaign.SelectedValue.ToString());
            lbStatusLoteNovo.DataValueField = "idStatusMotivo";
            lbStatusLoteNovo.DataTextField = "DescricaoStatus";
            lbStatusLoteNovo.DataBind();

            return true;
        }

        protected Boolean DadosMailingTelefone()
        {
            if (gridLista())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void listaHora()
        {
            List<String> listHora = new List<string>();

            for (int i = 1; i <= 24; i++)
                listHora.Add(i.ToString());

            ddlHora.DataSource = listHora;
            ddlHora.DataBind();
        }

        private void listaMinuto()
        {
            List<String> listMinuto = new List<string>();

            for (int i = 0; i <= 60; i++)
                listMinuto.Add(i.ToString());

            ddlMinuto.DataSource = listMinuto;
            ddlMinuto.DataBind();
        }

        protected void lbStatusLoteNovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaHora();
            listaMinuto();

            String strCaracter = ".";
            String[] Split = null;
            Char[] Delimiter = strCaracter.ToCharArray();
            String strStatusNovo = lbStatusLoteNovo.SelectedValue;

            Split = strStatusNovo.Split(Delimiter);
            String strStatusChamadaNovo = Split[0];
            String strMotivoNovo = Split[1];

            if (strStatusChamadaNovo == "99")
                modReagendamento.Visible = true;
            else
                modReagendamento.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if ((lbStatusLote.SelectedValue == "0") || (lbStatusLote.SelectedValue == ""))
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'>Nenhum Status para Ressubmissão foi escolhido, verifique.</div>";
                return;
            }

            if ((lbStatusLoteNovo.SelectedValue == "0") || (lbStatusLoteNovo.SelectedValue == ""))
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'>Nenhum Novo Status para Ressubmissão foi escolhido, verifique.</div>";
                return;
            }

            String strCaracter = ".";
            String[] Split = null;
            Char[] Delimiter = strCaracter.ToCharArray();

            String strStatusAtual = lbStatusLote.SelectedValue;

            Split = strStatusAtual.Split(Delimiter);
            String strStatusChamada = Split[0];
            String strMotivo = Split[1];

            String strStatusNovo = lbStatusLoteNovo.SelectedValue;

            Split = strStatusNovo.Split(Delimiter);
            String strStatusChamadaNovo = Split[0];
            String strMotivoNovo = Split[1];

            String strDataReagendamento = "";
            DateTime dt = new DateTime();
            if (strStatusChamadaNovo == "99")
            {
                if (calReagendamento.SelectedDate.ToString() == String.Empty)
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>Data de reagendamento deve ser selecionada, verifique.</div>";
                    return;
                }

                if ((txtReagDDD.Text == String.Empty) || (txtReagTelefone.Text == String.Empty))
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>Telefone deve ser informado, verifique.</div>";
                    return;
                }

                strDataReagendamento = calReagendamento.SelectedDate.ToShortDateString().ToString() + " " + ddlHora.Text + ":" + ddlMinuto.Text + ":00";
                dt = Convert.ToDateTime(strDataReagendamento);
            }

            dtoMailing objAuxMailing = new dtoMailing();
            objAuxMailing.Campaign = ddlCampaign.SelectedValue.ToString();
            objAuxMailing.Lot = ddlLote.SelectedValue.ToString();
            objAuxMailing.StatusChamada = strStatusChamada;
            objAuxMailing.Motivo = strMotivo;
            objAuxMailing.StatusChamadaNovo = strStatusChamadaNovo;
            objAuxMailing.MotivoNovo = strMotivoNovo;
            objAuxMailing.RegistroID = txtRegistroID.Text;
            objAuxMailing.DateTimeMH = dt.ToString("yyyy-MM-dd HH:mm:ss");
            objAuxMailing.DDD = txtReagDDD.Text;
            objAuxMailing.Telefone = txtReagTelefone.Text;
            objAuxMailing.User = objUsers.User;
            objAuxMailing.Tentativas = chkZeraTentativas.Checked == true ? "1" : "0";
            objAuxMailing.IndiceCampoFone = chkZeraIndiceCampoFone.Checked == true ? "1" : "0";
            objAuxMailing.User = objUsers.User;
            objAuxMailing.StatusAtual = lbStatusLote.SelectedItem.Text;
            objAuxMailing.StatusNovo = lbStatusLoteNovo.SelectedItem.Text;
            Int64 intResultado = objMailing.managerRessubmissao(objAuxMailing);
            if (intResultado > 0)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Ressubmissão Executada com sucesso !! </div>";
                Limpar();
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a execução da Ressubmissão !! </div>";
            }
        }

        protected void Limpar()
        {
            divLote.Visible = false;
            divRegistro.Visible = false;
            divTelefone.Visible = false;
            txtDDD.Text = "";
            txtTelefone.Text = "";
            txtRegistroID.Text = "";
            modManutencao.Visible = false;
            modStatusMotivos.Visible = false;
            modDadosRegistro.Visible = false;
            modLista.Visible = false;
            modReagendamento.Visible = false;
            rbOpcoes.Items[0].Selected = false;
            rbOpcoes.Items[1].Selected = false;
            rbOpcoes.Items[2].Selected = false;

            buttonImageFiltrar.Visible = false;

            buttonImageSalvar.Visible = true;
            divConfirmacao.Visible = false;

        }

        protected void buttonImageSalvar_Click(object sender, ImageClickEventArgs e)
        {
            buttonImageSalvar.Visible = false;
            divConfirmacao.Visible = true;
        }

        protected void buttonImageCancelarConfirmacao_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
        }
    }
}
