using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Campanha
{
    public partial class CampanhaParametros : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        bllTelecom objTelecom = new bllTelecom();

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
                loadCampaign();
                regraDiscagem();
                planoDiscagem();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/DashBoard.aspx");
            }
        }


        protected void loadCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociatedAndMysql(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void loadMascara()
        {
            dtoCampaignMascara objAux = new dtoCampaignMascara();
            lbMascara.DataSource = objCampaign.listCampaignMask(ddlCampaign.SelectedValue.ToString());
            lbMascara.DataValueField = "IDMascara";
            lbMascara.DataTextField = "Mascara";
            lbMascara.DataBind();

            if (lbMascara.Items.Count > 0)
                divMascara.Visible = true;
            else
                divMascara.Visible = false;
        }

        protected void regraDiscagem()
        {
            ddlRegraDiscagem.DataSource = objTelecom.listRules();
            ddlRegraDiscagem.DataTextField = "Name";
            ddlRegraDiscagem.DataValueField = "IdRule";
            ddlRegraDiscagem.DataBind();
            ddlRegraDiscagem.Items.Insert(0, new ListItem("Selecione... ", "0"));

            divPreditivo.Visible = true;
        }

        protected void planoDiscagem()
        {
            ddlPlanoDiscagem.DataSource = objCampaign.listCampaignRules();
            ddlPlanoDiscagem.DataTextField = "NomeRegra";
            ddlPlanoDiscagem.DataValueField = "NumeroRegra";
            ddlPlanoDiscagem.DataBind();
            ddlPlanoDiscagem.Items.Insert(0, new ListItem("Default", "0"));

            divPreditivo.Visible = true;
        }
        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampaign.SelectedIndex > 0)
            {
                dtoCampaign objAuxCampaign = new dtoCampaign();
                objAuxCampaign.Campaign = ddlCampaign.SelectedValue.ToString();

                SqlDataReader iDrCampanha = objCampaign.listCampaignDetails(objAuxCampaign);

                if (iDrCampanha.Read())
                {
                    txtChamAgenteLivre.Text = iDrCampanha["CHAMADASPORAGENTELIVRE"].ToString();
                    txtTempoAtendimento.Text = iDrCampanha["TEMPOPARAATENDIMENTO"].ToString();
                    txtReagendamentoNaoAtendimento.Text = iDrCampanha["REAGENDAMENTONAOATENDIMENTO"].ToString();
                    txtReagendamentoOcupado.Text = iDrCampanha["REAGENDAMENTOOCUPADO"].ToString();
                    txtReagendamentoCongestionamento.Text = iDrCampanha["REAGENDAMENTOCONGESTIONAMENTO"].ToString();
                    txtTentativas.Text = iDrCampanha["NUMEROTENTATIVAS"].ToString();
                    txtTentativasCongestionamento.Text = iDrCampanha["NUMEROTENTATIVAS_CONGESTIONAMENTO"].ToString();
                    txtTentativasNaoAtende.Text = iDrCampanha["NUMEROTENTATIVAS_NAOATENDE"].ToString();
                    txtTentativasOcupado.Text = iDrCampanha["NUMEROTENTATIVAS_OCUPADO"].ToString();
                    txtClausulaWhere.Text = iDrCampanha["PREFIXOCLAUSULAWHERE"].ToString();
                    txtIndiceAgresMax.Text = iDrCampanha["INDICEAGRESSIVIDADEMAXIMO"].ToString();
                    ddlTipovarredura.SelectedValue = iDrCampanha["TIPOVARREDURA"].ToString() == "" ? "0" : iDrCampanha["TIPOVARREDURA"].ToString();

                    if (Convert.ToBoolean(iDrCampanha["INCINDICECAMPOFONECONGESTIONAMENTO"].ToString()) == true)
                        cbIndiceCampoFoneCongestionamento.Checked = true;
                    else
                        cbIndiceCampoFoneCongestionamento.Checked = false;

                    if (Convert.ToBoolean(iDrCampanha["INCINDICECAMPOFONENAOATENDIMENTO"].ToString()) == true)
                        cbIndiceCampoFoneNaoAtendimento.Checked = true;
                    else
                        cbIndiceCampoFoneNaoAtendimento.Checked = false;

                    if (Convert.ToBoolean(iDrCampanha["INCINDICECAMPOFONEOCUPADO"].ToString()) == true)
                        cbIndiceCampoFoneOcupado.Checked = true;
                    else
                        cbIndiceCampoFoneOcupado.Checked = false;

                    //if (iDrCampanha["MODODISCAGEM"].ToString() == "1")
                    //{
                    divPreditivo.Visible = true;

                    //if ((iDrCampanha["IDREGRA"].ToString() != "") && (iDrCampanha["IDREGRA"].ToString() != null))
                    //    ddlRegraDiscagem.SelectedValue = iDrCampanha["IDREGRA"].ToString();
                    //}

                    LoadRecadoCP(ddlCampaign.SelectedValue.ToString());
                }

                //loadMascara();

                modCampanhaParametro.Visible = true;
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void LoadRecadoCP(String strCampanha)
        {
            SqlDataReader iDrCampanha = objCampaign.UINT_RecadoCP(strCampanha);
            if (iDrCampanha.Read())
            {
                ddlRecadoCPAtivo.SelectedValue = iDrCampanha["FLAG_ATIVO"].ToString() == "True" ? "1" : "0";
                txtRecadoCPDescricao.Text = iDrCampanha["DESCRICAO"].ToString();

                divRecadoCP.Visible = true;
            }
            else
            {
                divRecadoCP.Visible = false;
            }

        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            Alteracao();
            Limpar();
        }

        protected void Alteracao()
        {
            try
            {
                dtoCampaign objDtoCampaign = new dtoCampaign();
                objDtoCampaign.Task = 2;
                objDtoCampaign.User = objUsers.User;
                objDtoCampaign.Campaign = ddlCampaign.SelectedValue.ToString();
                objDtoCampaign.ChamadasAgenteLivre = txtChamAgenteLivre.Text;
                objDtoCampaign.TempoAtendimento = Convert.ToInt32(txtTempoAtendimento.Text);
                objDtoCampaign.NumeroTentativas = Convert.ToInt32(txtTentativas.Text);
                objDtoCampaign.ReagendamentoNaoAtendimento = Convert.ToInt32(txtReagendamentoNaoAtendimento.Text);
                objDtoCampaign.ReagendamentoOcupado = Convert.ToInt32(txtReagendamentoOcupado.Text);
                objDtoCampaign.ReagendamentoCongestionamento = Convert.ToInt32(txtReagendamentoCongestionamento.Text);
                objDtoCampaign.NumeroTentativas_Congestionamento = Convert.ToInt32(txtTentativasCongestionamento.Text);
                objDtoCampaign.NumeroTentativas_NaoAtende = Convert.ToInt32(txtTentativasNaoAtende.Text);
                objDtoCampaign.NumeroTentativas_Ocupado = Convert.ToInt32(txtTentativasOcupado.Text);
                objDtoCampaign.IndiceCampoFoneNaoAtendimento = Convert.ToBoolean(cbIndiceCampoFoneNaoAtendimento.Checked);
                objDtoCampaign.IndiceCampoFoneOcupado = Convert.ToBoolean(cbIndiceCampoFoneOcupado.Checked);
                objDtoCampaign.IndiceCampoFoneCongestionamento = Convert.ToBoolean(cbIndiceCampoFoneCongestionamento.Checked);
                objDtoCampaign.PrefixoClausulaWhere = txtClausulaWhere.Text;
                objDtoCampaign.IndiceAgressividadeMaximo = txtIndiceAgresMax.Text;
                //objDtoCampaign.IgnoraReagendamento = Convert.ToBoolean(cbIgnoraReagendamento.Checked);
                objDtoCampaign.TipoVarredura = Convert.ToInt32(ddlTipovarredura.SelectedValue);
                objDtoCampaign.MultiCampo = String.Empty;
                objDtoCampaign.IDRegraRota = Convert.ToInt32(ddlRegraDiscagem.SelectedValue.ToString());
                objDtoCampaign.IDRegra = Convert.ToInt32(ddlPlanoDiscagem.SelectedValue.ToString());


                objDtoCampaign.RecadoCPAtivo = ddlRecadoCPAtivo.SelectedValue == "0" ? false : true;


                Int32 iPosicao = 0;
                if (lbMascaraSelecionada.Items.Count > 0)
                {
                    objCampaign.ManagerCampaignMask_Clear(objDtoCampaign.Campaign);

                    foreach (ListItem li in lbMascaraSelecionada.Items)
                    {
                        Int32 idMascara = int.Parse(li.Value);

                        SqlDataReader drMascara = objCampaign.listCampaignMaskDetails(objDtoCampaign.Campaign, idMascara);
                        if (drMascara.Read())
                        {
                            String strDDD = drMascara["CAMPODDD"].ToString().PadRight(31, ' ') + "+ ";
                            String strFone = drMascara["CAMPO FONE"].ToString().PadRight(31, ' ') + "# ";
                            String strHInicial = drMascara["HORAINICIAL"].ToString() + " # ";
                            String strHFinal = drMascara["HORAFINAL"].ToString() + "\r\n";

                            objDtoCampaign.MultiCampo = objDtoCampaign.MultiCampo + strDDD + strFone + strHInicial + strHFinal;

                            iPosicao++;
                            objCampaign.managerCampaignMask(idMascara, iPosicao);
                        }
                    }
                }

                Int64 intResultado = objCampaign.managerCampaign(objDtoCampaign);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração de Parametros de Campanha realizado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Parametros de Campanha !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Parametros de Campanha !!" + eAlteracao + " </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                modCampanhaParametro.Visible = false;
                lbMascaraSelecionada.Items.Clear();
                loadCampaign();
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
