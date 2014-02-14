using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Painel
{
    public partial class Painel : System.Web.UI.Page
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
                listCampaign();
                AccessSecurity();
                PageConfig();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile("boxMailing", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxMailing.Visible = false;
                cb_Mailing.Visible = false;
                boxMailingChart.Visible = false;
            }
            else
            {
                boxMailing.Visible = true;
                cb_Mailing.Visible = true;
                boxMailingChart.Visible = true;
            }
                
            if (objUsersProfiles.AccessProfile("boxChamadasDia", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxChamadasDia.Visible = false;
                cb_ChamadasTotal.Visible = false;
                boxChamadasDiaChart.Visible = false;
            }
            else
            {
                boxChamadasDia.Visible = true;
                cb_ChamadasTotal.Visible = true;
                boxChamadasDiaChart.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxUltimasChamadas", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxUltimasChamadas.Visible = false;
                cb_ChamadasUltMin.Visible = false;
                boxUltimasChamadasChart.Visible = false;
            }
            else
            {
                boxUltimasChamadas.Visible = true;
                cb_ChamadasUltMin.Visible = true;
                boxUltimasChamadasChart.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxRO", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxRO.Visible = false;
                cb_RO.Visible = false;
            }
            else
            {
                boxRO.Visible = true;
                cb_RO.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxEstatistica", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxEstatisticas.Visible = false;
                cb_Estatistica.Visible = false;
            }
            else
            {
                boxRO.Visible = true;
                cb_Estatistica.Visible = true;
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

        /// <summary>
        /// data e hora atual
        /// captura a data e hora e atualiza a label
        /// modificado em 25/10/2010 às 10:30
        /// </summary>
        public void dataHora()
        {
            lblDataHora.Text = "&nbsp; Atualizado em <b>" + DateTime.Now.ToString("dd/MM/yyyy") + "</b> às <b>" + DateTime.Now.ToString("HH:mm:ss") + "</b>";
        }

        /// <summary>
        /// Listar as campanhas cadastradas no campo de DropDownList
        /// </summary>
        public void listCampaign()
        {
            Campaigns objCampaign = new Campaigns();

            ddlCampanhas.DataSource = objCampaign.listCampaignAssociatedModule(objUsers, this.Form.ID);
            ddlCampanhas.DataTextField = "NomeCampanha";
            ddlCampanhas.DataValueField = "Campaign";
            ddlCampanhas.DataBind();
            ddlCampanhas.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        /// <summary>
        /// calcular a porcentagem referente a quantidade por status
        /// modificado em 25/10/2010 às 10:45
        /// </summary>
        /// <param name="valorTotal"></param>
        /// <param name="valorStatus"></param>
        /// <returns></returns>
        public String calcularPorcentagem(int valorTotal, int valorParcial)
        {
            string resultado = String.Empty;
            double parcial = 0;

            if (valorParcial != 0 || valorTotal != 0)
            {
                parcial = (double)valorParcial / (double)valorTotal * 100;

                return Math.Round(parcial, 2).ToString();
            }
            else
            {
                parcial = 0;

                return Math.Round(parcial, 2).ToString();
            }
        }

        /// <summary>
        /// listar as informações do campanha escolhida 
        /// modificado em 25/10/2010 às 10:20
        /// </summary>
        public void listarMailing(int tipoDeExibicao)
        {
            try
            {
                // carrega os dados
                DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_MAILING"].ToString());

                ds.Tables[0].DefaultView.Sort = "Campanha, Status";
                ds.Tables[0].DefaultView.RowFilter = "Campanha = '" + ddlCampanhas.SelectedValue + "'";



                // variáveis auxiliares
                int iTotalMail = 0;
                int iLivres = 0;
                int iDiscando = 0;
                int iAtendidas = 0;
                int iFinalizadosTotal = 0;
                int iFinalizadosAplicacao = 0;
                int iFinalizadosExcessoTentativas = 0;
                int iFinalizadosNumerosInvalidos = 0;
                int iReagendadosTotal = 0;
                int iReagendadoDiscador = 0;
                int iReagendadoFrontEnd = 0;
                int iNumerosProibidos = 0;
                int iNumerosProcom = 0;

                // loop para tratamento das informações do XML
                for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                {
                    // valores encontrados na pesquisa
                    string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                    string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

                    // tratamento dos valores por switch
                    switch (int.Parse(status))
                    {
                        // registro livres
                        case 0:
                            iLivres = iLivres + int.Parse(valor);
                            break;

                        // finalizados pela aplicação
                        case 1:
                            iFinalizadosAplicacao = iFinalizadosAplicacao + int.Parse(valor);
                            break;

                        // Finalizados pela aplicação
                        case 2:
                            iReagendadoDiscador = iReagendadoDiscador + int.Parse(valor);
                            break;

                        // Números proibidos
                        case 7:
                            iNumerosProibidos = iNumerosProibidos + int.Parse(valor);
                            break;

                        // Finalizados por excesso de tentativas
                        case 8:
                            iFinalizadosExcessoTentativas = iFinalizadosExcessoTentativas + int.Parse(valor);
                            break;

                        // Finalizados por números inválidos
                        case 9:
                            iFinalizadosNumerosInvalidos = iFinalizadosNumerosInvalidos + int.Parse(valor);
                            break;

                        // Finalizados por números Restrição do Procon
                        case 10:
                            iNumerosProcom = iNumerosProcom + int.Parse(valor);
                            break;

                        // Reagendado pelo FrontEnd
                        case 99:
                            iReagendadoFrontEnd = iReagendadoFrontEnd + int.Parse(valor);
                            break;

                        case 100:
                            iDiscando = iDiscando + int.Parse(valor);
                            break;

                        case 150:
                            iAtendidas = iAtendidas + int.Parse(valor);
                            break;

                        default:
                            //iTotalMail = iTotalMail + int.Parse(valor);
                            break;
                    }
                }

                // registro total do mailing
                iTotalMail = iTotalMail + iFinalizadosAplicacao + iFinalizadosExcessoTentativas + iFinalizadosNumerosInvalidos + iLivres + iDiscando + iAtendidas + iReagendadoDiscador + iReagendadoFrontEnd + iNumerosProibidos + iNumerosProcom;

                // total de finalizados
                iFinalizadosTotal = iFinalizadosAplicacao + iFinalizadosExcessoTentativas + iFinalizadosNumerosInvalidos + iNumerosProibidos + iNumerosProcom;

                // total reagendados
                iReagendadosTotal = iReagendadoDiscador + iReagendadoFrontEnd;


                DataSet objDs1 = new DataSet();
                objDs1.Tables.Add("TABLE");

                objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_Mailing.Text = iTotalMail.ToString();
                    lblLivres_Mailing.Text = iLivres.ToString();
                    lblDiscando_Mailing.Text = iDiscando.ToString();
                    lblAtendida_Mailing.Text = iAtendidas.ToString();
                    lblFinalizadosTotal_Mailing.Text = iFinalizadosTotal.ToString();
                    lblFinalizadosAplicacao_Mailing.Text = iFinalizadosAplicacao.ToString();
                    lblFinalizadosExcessoTentativas_Mailing.Text = iFinalizadosExcessoTentativas.ToString();
                    lblFinalizadosNumerosInvalidos_Mailing.Text = iFinalizadosNumerosInvalidos.ToString();
                    lblReagendados_Mailing.Text = iReagendadosTotal.ToString();
                    lblReagendadoDiscador_Mailing.Text = iReagendadoDiscador.ToString();
                    lblReagendadoFrontEnd_Mailing.Text = iReagendadoFrontEnd.ToString();
                    lblNumerosProibidos_Mailing.Text = iNumerosProibidos.ToString();
                    lblNumerosProcon_Mailing.Text = iNumerosProcom.ToString();

                    if (lblLivres_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Livres", lblLivres_Mailing.Text });

                    if (lblDiscando_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Discando", lblDiscando_Mailing.Text });

                    if (lblAtendida_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendida", lblAtendida_Mailing.Text });

                    if (lblFinalizadosAplicacao_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.Aplicação", lblFinalizadosAplicacao_Mailing.Text });

                    if (lblFinalizadosExcessoTentativas_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.ExcessoTent", lblFinalizadosExcessoTentativas_Mailing.Text });

                    if (lblFinalizadosNumerosInvalidos_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.NumInvalidos", lblFinalizadosNumerosInvalidos_Mailing.Text });

                    if (lblReagendadoDiscador_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.Discador", lblReagendadoDiscador_Mailing.Text });

                    if (lblReagendadoFrontEnd_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.FrontEnd", lblReagendadoFrontEnd_Mailing.Text });

                    if (lblNumerosProibidos_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProibidos", lblNumerosProibidos_Mailing.Text });

                    if (lblNumerosProcon_Mailing.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProcon", lblNumerosProcon_Mailing.Text });
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    lblTotal_Mailing.Text = calcularPorcentagem(iTotalMail, iTotalMail).ToString() + "%";
                    lblLivres_Mailing.Text = calcularPorcentagem(iTotalMail, iLivres).ToString() + "%";
                    lblDiscando_Mailing.Text = calcularPorcentagem(iTotalMail, iDiscando).ToString() + "%";
                    lblAtendida_Mailing.Text = calcularPorcentagem(iTotalMail, iAtendidas).ToString() + "%";
                    lblFinalizadosTotal_Mailing.Text = calcularPorcentagem(iTotalMail, iFinalizadosTotal).ToString() + "%";
                    lblFinalizadosAplicacao_Mailing.Text = calcularPorcentagem(iTotalMail, iFinalizadosAplicacao).ToString() + "%";
                    lblFinalizadosExcessoTentativas_Mailing.Text = calcularPorcentagem(iTotalMail, iFinalizadosExcessoTentativas).ToString() + "%";
                    lblFinalizadosNumerosInvalidos_Mailing.Text = calcularPorcentagem(iTotalMail, iFinalizadosNumerosInvalidos).ToString() + "%";
                    lblReagendados_Mailing.Text = calcularPorcentagem(iTotalMail, iReagendadosTotal).ToString() + "%";
                    lblReagendadoDiscador_Mailing.Text = calcularPorcentagem(iTotalMail, iReagendadoDiscador).ToString() + "%";
                    lblReagendadoFrontEnd_Mailing.Text = calcularPorcentagem(iTotalMail, iReagendadoFrontEnd).ToString() + "%";
                    lblNumerosProibidos_Mailing.Text = calcularPorcentagem(iTotalMail, iNumerosProibidos).ToString() + "%";
                    lblNumerosProcon_Mailing.Text = calcularPorcentagem(iTotalMail, iNumerosProcom).ToString() + "%";

                    if (iLivres != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Livres", iLivres });

                    if (iDiscando != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Discando", iDiscando });

                    if (iAtendidas != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendida", iAtendidas });

                    if (iFinalizadosAplicacao != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.Aplicação", iFinalizadosAplicacao });

                    if (iFinalizadosExcessoTentativas != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.ExcessoTent", iFinalizadosExcessoTentativas });

                    if (iFinalizadosNumerosInvalidos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.NumInvalidos", iFinalizadosNumerosInvalidos });

                    if (iReagendadoDiscador != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.Discador", iReagendadoDiscador });

                    if (iReagendadoFrontEnd != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.FrontEnd", iReagendadoFrontEnd });

                    if (iNumerosProibidos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProibidos", iNumerosProibidos });

                    if (iNumerosProcom != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProcon", iNumerosProcom });
                }

                // Grafico
                DataTable dt = objDs1.Tables[0];
                MailingChart.DataSource = dt;
                MailingChart.Series["SeriesMailingChart"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                //MailingChart.Series["SeriesMailingChart"]["PieLabelStyle"] = "Outside"; // Para colocar a legenda fora da pizza (não interfere na legenda do quadro) 
                MailingChart.Series["SeriesMailingChart"]["PieLabelStyle"] = "Disabled"; // para desabilitar a legenda da pizza (não interfere na legenda do quadro)
                MailingChart.Series["SeriesMailingChart"].XValueMember = "Status";
                MailingChart.Series["SeriesMailingChart"].YValueMembers = "Total";

                MailingChart.Legends.Add("Legend1");
                MailingChart.Legends[0].Enabled = true;
                MailingChart.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
                MailingChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    MailingChart.Series[0].LegendText = "#VALX (#VALY)";
                    MailingChart.Series["SeriesMailingChart"].Label = "#VALY";
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    MailingChart.Series[0].LegendText = "#VALX (#PERCENT)";
                    MailingChart.Series["SeriesMailingChart"].Label = "#PERCENT{P2}";
                }

                MailingChart.DataManipulator.Sort(PointSortOrder.Descending, MailingChart.Series[0]);

                MailingChart.DataBind();
                MailingChart.Visible = true;

                // habilita a exibição da da tabela dos mailing's
                tblMailing.Visible = true;
            }
            catch (Exception ex)
            {
                // var com a mensagem (para posterior utilização)
                string excessao = ex.Message;

                // exibe mensagem de erro durante caso ocorra
                lblMensagemMaling.Text = "<center>" + excessao + "</center>";
                lblMensagemMaling.Visible = true;

                // esconde a tabela caso ocorra alguma excessão
                tblMailing.Visible = false;
            }
        }

        /// <summary>
        /// listar todas as chamadas do dia 
        /// modificado em 25/10/2010 às 13:40
        /// </summary>
        public void listarChamadasDia(int tipoDeExibicao)
        {
            try
            {
                // instanciar as variaveis auxiliares
                string servico = null;
                int iTotalDia = 0;
                int iAtendidas_TotalDia = 0;
                int iNaoAtendidas_TotalDia = 0;
                int iTimeOut_TotalDia = 0;
                int iFalha_TotalDia = 0;
                int iCongestionamentoTotal_TotalDia = 0;
                int iCongetionamentoAgente_TotalDia = 0;
                int iCongestionamentoA4_TotalDia = 0;
                int iCongestionamentoCentralPublica_TotalDia = 0;
                int iOcupado_TotalDia = 0;
                int iFax_TotalDia = 0;
                int iNumeroInvalido_TotalDia = 0;
                int iCancelada_TotalDia = 0;
                int iCanceladaCaixaPostal_TotalDia = 0;
                int iCanceladaMensagemOperadora_TotalDia = 0;
                int iFalhaSinalizacao_TotalDia = 0;
                int iFalhaTotal_TotalDia = 0;

                // busca o número do serviço de acordo com a campanha escolhida
                DataSet dsCampanhas = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CAMPANHAS"].ToString());
                dsCampanhas.Tables[0].DefaultView.Sort = "Numero";
                dsCampanhas.Tables[0].DefaultView.RowFilter = "Numero = '" + ddlCampanhas.SelectedValue + "'";

                // captura o número do serviço de acordo com a campanha escolhida
                for (int j = 0; j < dsCampanhas.Tables[0].DefaultView.Count; j++)
                {
                    servico = dsCampanhas.Tables[0].DefaultView.ToTable().Rows[j]["Servico"].ToString();
                }

                // cria um DataSet com o número do serviço
                DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CHAMADAS_TOTALDIA"].ToString());
                ds.Tables[0].DefaultView.Sort = "Grupo, Status";
                ds.Tables[0].DefaultView.RowFilter = "Grupo = '" + servico + "'";

                // loop para tratamento das informações do XML
                for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                {
                    string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                    string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

                    switch (int.Parse(status))
                    {
                        case 4:
                        case 5:
                        case 2002:
                            iAtendidas_TotalDia = iAtendidas_TotalDia + int.Parse(valor);
                            break;

                        case 2:
                            iTimeOut_TotalDia = iTimeOut_TotalDia + int.Parse(valor);
                            break;

                        case 3:
                            iNaoAtendidas_TotalDia = iNaoAtendidas_TotalDia + int.Parse(valor);
                            break;

                        case 6:
                            iFalha_TotalDia = iFalha_TotalDia + int.Parse(valor);
                            break;

                        case 7:
                            iCongetionamentoAgente_TotalDia = iCongetionamentoAgente_TotalDia + int.Parse(valor);
                            break;

                        case 10:
                            iOcupado_TotalDia = iOcupado_TotalDia + int.Parse(valor);
                            break;

                        case 11:
                            iFax_TotalDia = iFax_TotalDia + int.Parse(valor);
                            break;

                        case 12:
                            iNumeroInvalido_TotalDia = iNumeroInvalido_TotalDia + int.Parse(valor);
                            break;

                        case 16:
                            iCanceladaCaixaPostal_TotalDia = iCanceladaCaixaPostal_TotalDia + int.Parse(valor);
                            break;

                        case 18:
                            iCongestionamentoA4_TotalDia = iCongestionamentoA4_TotalDia + int.Parse(valor);
                            break;

                        case 19:
                            iFalhaSinalizacao_TotalDia = iFalhaSinalizacao_TotalDia + int.Parse(valor);
                            break;

                        case 20:
                            iCanceladaMensagemOperadora_TotalDia = iCanceladaMensagemOperadora_TotalDia + int.Parse(valor);
                            break;

                        case 37:
                            iCongestionamentoCentralPublica_TotalDia = iCongestionamentoCentralPublica_TotalDia + int.Parse(valor);
                            break;
                    }
                }

                // soma do total de chamadas do dia
                iTotalDia = iAtendidas_TotalDia + iNaoAtendidas_TotalDia + iTimeOut_TotalDia +
                iFalha_TotalDia + iCongetionamentoAgente_TotalDia + iOcupado_TotalDia + iFax_TotalDia +
                iNumeroInvalido_TotalDia + iCanceladaCaixaPostal_TotalDia + iCongestionamentoA4_TotalDia +
                iFalhaSinalizacao_TotalDia + iCongestionamentoCentralPublica_TotalDia + iCanceladaMensagemOperadora_TotalDia;

                // Total Canceladas
                iCancelada_TotalDia = iCanceladaCaixaPostal_TotalDia + iCanceladaMensagemOperadora_TotalDia;

                // total congestionados
                iCongestionamentoTotal_TotalDia = iCongestionamentoA4_TotalDia + iCongestionamentoCentralPublica_TotalDia + iCongetionamentoAgente_TotalDia;

                // total falhas
                iFalhaTotal_TotalDia = iFalha_TotalDia + iFalhaSinalizacao_TotalDia;

                DataSet objDs1 = new DataSet();
                objDs1.Tables.Add("TABLE");

                objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_TotalDia.Text = iTotalDia.ToString();
                    lblAtendidas_TotalDia.Text = iAtendidas_TotalDia.ToString();
                    lblCanceladas_TotalDia.Text = iCancelada_TotalDia.ToString();
                    lblCanceladasCaixaPostal_TotalDia.Text = iCanceladaCaixaPostal_TotalDia.ToString();
                    lblCanceladasOperadora_TotalDia.Text = iCanceladaMensagemOperadora_TotalDia.ToString();
                    lblCongestionamento_TotalDia.Text = iCongestionamentoTotal_TotalDia.ToString();
                    lblCongestionamento_A4_TotalDia.Text = iCongestionamentoA4_TotalDia.ToString();
                    lblCongestionamento_CP_TotalDia.Text = iCongestionamentoCentralPublica_TotalDia.ToString();
                    lblCongestionamento_Agente_TotalDia.Text = iCongetionamentoAgente_TotalDia.ToString();
                    lblFalhaTotal_TotalDia.Text = iFalhaTotal_TotalDia.ToString();
                    lblFalha_TotalDia.Text = iFalha_TotalDia.ToString();
                    lblFalhaPorSinalizacao_TotalDia.Text = iFalhaSinalizacao_TotalDia.ToString();
                    lblFax_TotalDia.Text = iFax_TotalDia.ToString();
                    lblNaoAtendidas_TotalDia.Text = iNaoAtendidas_TotalDia.ToString();
                    lblNumerosInvalidos_TotalDia.Text = iNumeroInvalido_TotalDia.ToString();
                    lblOcupados_TotalDia.Text = iOcupado_TotalDia.ToString();
                    lblTimeOut_TotalDia.Text = iTimeOut_TotalDia.ToString();
                    //lblSemAgentes_TotalDia.Text = "";

                    if (lblAtendidas_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", lblAtendidas_TotalDia.Text });

                    if (lblCanceladasCaixaPostal_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", lblCanceladasCaixaPostal_TotalDia.Text });

                    if (lblCanceladasOperadora_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", lblCanceladasOperadora_TotalDia.Text });

                    if (lblCongestionamento_A4_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", lblCongestionamento_A4_TotalDia.Text });

                    if (lblCongestionamento_CP_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", lblCongestionamento_CP_TotalDia.Text });

                    if (lblCongestionamento_Agente_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", lblCongestionamento_Agente_TotalDia.Text });

                    if (lblFalha_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", lblFalha_TotalDia.Text });

                    if (lblFalhaPorSinalizacao_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", lblFalhaPorSinalizacao_TotalDia.Text });

                    if (lblFax_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", lblFax_TotalDia.Text });

                    if (lblNaoAtendidas_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", lblNaoAtendidas_TotalDia.Text });

                    if (lblNumerosInvalidos_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", lblNumerosInvalidos_TotalDia.Text });

                    if (lblOcupados_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", lblOcupados_TotalDia.Text });

                    if (lblTimeOut_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", lblTimeOut_TotalDia.Text });
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_TotalDia.Text = calcularPorcentagem(iTotalDia, iTotalDia).ToString() + "%";
                    lblAtendidas_TotalDia.Text = calcularPorcentagem(iTotalDia, iAtendidas_TotalDia).ToString() + "%";
                    lblCanceladas_TotalDia.Text = calcularPorcentagem(iTotalDia, iCancelada_TotalDia).ToString() + "%";
                    lblCanceladasCaixaPostal_TotalDia.Text = calcularPorcentagem(iTotalDia, iCanceladaCaixaPostal_TotalDia).ToString() + "%";
                    lblCanceladasOperadora_TotalDia.Text = calcularPorcentagem(iTotalDia, iCanceladaMensagemOperadora_TotalDia).ToString() + "%";
                    lblCongestionamento_TotalDia.Text = calcularPorcentagem(iTotalDia, iCongestionamentoTotal_TotalDia).ToString() + "%";
                    lblCongestionamento_A4_TotalDia.Text = calcularPorcentagem(iTotalDia, iCongestionamentoA4_TotalDia).ToString() + "%";
                    lblCongestionamento_CP_TotalDia.Text = calcularPorcentagem(iTotalDia, iCongestionamentoCentralPublica_TotalDia).ToString() + "%";
                    lblCongestionamento_Agente_TotalDia.Text = calcularPorcentagem(iTotalDia, iCongetionamentoAgente_TotalDia).ToString() + "%";
                    lblFalhaTotal_TotalDia.Text = calcularPorcentagem(iTotalDia, iFalhaTotal_TotalDia).ToString() + "%";
                    lblFalha_TotalDia.Text = calcularPorcentagem(iTotalDia, iFalha_TotalDia).ToString() + "%";
                    lblFalhaPorSinalizacao_TotalDia.Text = calcularPorcentagem(iTotalDia, iFalhaSinalizacao_TotalDia).ToString() + "%";
                    lblFax_TotalDia.Text = calcularPorcentagem(iTotalDia, iFax_TotalDia).ToString() + "%";
                    lblNaoAtendidas_TotalDia.Text = calcularPorcentagem(iTotalDia, iNaoAtendidas_TotalDia).ToString() + "%";
                    lblNumerosInvalidos_TotalDia.Text = calcularPorcentagem(iTotalDia, iNumeroInvalido_TotalDia).ToString() + "%";
                    lblOcupados_TotalDia.Text = calcularPorcentagem(iTotalDia, iOcupado_TotalDia).ToString() + "%";
                    lblTimeOut_TotalDia.Text = calcularPorcentagem(iTotalDia, iTimeOut_TotalDia).ToString() + "%";
                    //lblSemAgentes_TotalDia.Text = "";

                    if (iAtendidas_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_TotalDia });

                    if (iCanceladaCaixaPostal_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", iCanceladaCaixaPostal_TotalDia });

                    if (iCanceladaMensagemOperadora_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", iCanceladaMensagemOperadora_TotalDia });

                    if (iCongestionamentoA4_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", iCongestionamentoA4_TotalDia });

                    if (iCongestionamentoCentralPublica_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", iCongestionamentoCentralPublica_TotalDia });

                    if (iCongetionamentoAgente_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", iCongetionamentoAgente_TotalDia });

                    if (iFalha_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", iFalha_TotalDia });

                    if (iFalhaSinalizacao_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", iFalhaSinalizacao_TotalDia });

                    if (iFax_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", iFax_TotalDia });

                    if (iNaoAtendidas_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", iNaoAtendidas_TotalDia });

                    if (iNumeroInvalido_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", iNumeroInvalido_TotalDia });

                    if (iOcupado_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", iOcupado_TotalDia });

                    if (iTimeOut_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", iTimeOut_TotalDia });
                }

                // Grafico
                DataTable dt = objDs1.Tables[0];
                ChamadasDiaChart.DataSource = dt;
                ChamadasDiaChart.Series["SeriesChamadasDiaChart"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                ChamadasDiaChart.Series["SeriesChamadasDiaChart"]["PieLabelStyle"] = "Disabled"; // para desabilitar a legenda da pizza (não interfere na legenda do quadro)
                ChamadasDiaChart.Series["SeriesChamadasDiaChart"].XValueMember = "Status";
                ChamadasDiaChart.Series["SeriesChamadasDiaChart"].YValueMembers = "Total";

                ChamadasDiaChart.Legends.Add("Legend1");
                ChamadasDiaChart.Legends[0].Enabled = true;
                ChamadasDiaChart.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
                ChamadasDiaChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    ChamadasDiaChart.Series[0].LegendText = "#VALX (#VALY)";
                    ChamadasDiaChart.Series["SeriesChamadasDiaChart"].Label = "#VALY";
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    ChamadasDiaChart.Series[0].LegendText = "#VALX (#PERCENT)";
                    ChamadasDiaChart.Series["SeriesChamadasDiaChart"].Label = "#PERCENT{P2}";
                }

                ChamadasDiaChart.DataManipulator.Sort(PointSortOrder.Descending, ChamadasDiaChart.Series[0]);

                ChamadasDiaChart.DataBind();
                ChamadasDiaChart.Visible = true;

                // exibe a tabela
                tblChamadasTotalDia.Visible = true;
            }
            catch (Exception ex)
            {
                // var com a mensagem (para posterior utilização)
                string excessao = ex.Message;

                // exibe mensagem de erro durante caso ocorra
                lblMensagemChamadasTotalDia.Text = "<center>...</center>";
                lblMensagemChamadasTotalDia.Visible = true;

                // esconde a tabela caso ocorra alguma excessão
                tblChamadasTotalDia.Visible = false;
            }
        }

        /// <summary>
        /// listar as chamadas dos últimos 15 minutos 
        /// modificado em 25/10/2010 às 14:02
        /// </summary>
        public void listarChamadasUltimos15Minutos(int tipoDeExibicao)
        {
            try
            {
                // instanciar as variaveis auxiliares
                string servico = null;
                int iTotalUltimos15Minutos = 0;
                int iAtendidas_Ultimos15Minutos = 0;
                int iNaoAtendidas_Ultimos15Minutos = 0;
                int iTimeOut_Ultimos15Minutos = 0;
                int iFalha_Ultimos15Minutos = 0;
                int iCongetionamentoAgente_Ultimos15Minutos = 0;
                int iOcupado_Ultimos15Minutos = 0;
                int iFax_Ultimos15Minutos = 0;
                int iNumeroInvalido_Ultimos15Minutos = 0;
                int iCancelada_Ultimos15Minutos = 0;
                int iCanceladaCaixaPostal_Ultimos15Minutos = 0;
                int iCanceladaMensagemOperadora_Ultimos15Minutos = 0;
                int iCongestionamentoA4_Ultimos15Minutos = 0;
                int iFalhaSinalizacao_Ultimos15Minutos = 0;
                int iFalhaTotal_Ultimos15Minutos = 0;
                int iCongestionamentoTotal_Ultimos15Minutos = 0;
                int iCongestionamentoCentralPublica_Ultimos15Minutos = 0;

                // busca o número do serviço de acordo com a campanha escolhida
                DataSet dsCampanhas = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CAMPANHAS"].ToString());
                dsCampanhas.Tables[0].DefaultView.Sort = "Numero";
                dsCampanhas.Tables[0].DefaultView.RowFilter = "Numero = '" + ddlCampanhas.SelectedValue + "'";

                // captura o número do serviço de acordo com a campanha escolhida
                for (int j = 0; j < dsCampanhas.Tables[0].DefaultView.Count; j++)
                {
                    servico = dsCampanhas.Tables[0].DefaultView.ToTable().Rows[j]["Servico"].ToString();
                }

                // cria um DataSet com o número do serviço
                DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CHAMADAS_15MINUTOS"].ToString());
                ds.Tables[0].DefaultView.Sort = "Grupo, Status";
                ds.Tables[0].DefaultView.RowFilter = "Grupo = '" + servico + "'";

                // loop para tratamento das informações do XML
                for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                {
                    string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                    string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

                    switch (int.Parse(status))
                    {
                        case 4:
                        case 5:
                        case 2002:
                            iAtendidas_Ultimos15Minutos = iAtendidas_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 2:
                            iTimeOut_Ultimos15Minutos = iTimeOut_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 3:
                            iNaoAtendidas_Ultimos15Minutos = iNaoAtendidas_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 6:
                            iFalha_Ultimos15Minutos = iFalha_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 7:
                            iCongetionamentoAgente_Ultimos15Minutos = iCongetionamentoAgente_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 10:
                            iOcupado_Ultimos15Minutos = iOcupado_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 11:
                            iFax_Ultimos15Minutos = iFax_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 12:
                            iNumeroInvalido_Ultimos15Minutos = iNumeroInvalido_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 16:
                            iCanceladaCaixaPostal_Ultimos15Minutos = iCanceladaCaixaPostal_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 18:
                            iCongestionamentoA4_Ultimos15Minutos = iCongestionamentoA4_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 19:
                            iFalhaSinalizacao_Ultimos15Minutos = iFalhaSinalizacao_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 20:
                            iCanceladaMensagemOperadora_Ultimos15Minutos = iCanceladaMensagemOperadora_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 37:
                            iCongestionamentoCentralPublica_Ultimos15Minutos = iCongestionamentoCentralPublica_Ultimos15Minutos + int.Parse(valor);
                            break;
                    }
                }

                // soma do total de chamadas
                iTotalUltimos15Minutos = iAtendidas_Ultimos15Minutos + iNaoAtendidas_Ultimos15Minutos + iTimeOut_Ultimos15Minutos +
                iFalha_Ultimos15Minutos + iCongetionamentoAgente_Ultimos15Minutos + iOcupado_Ultimos15Minutos + iFax_Ultimos15Minutos +
                iNumeroInvalido_Ultimos15Minutos + iCanceladaCaixaPostal_Ultimos15Minutos + iCongestionamentoA4_Ultimos15Minutos +
                iFalhaSinalizacao_Ultimos15Minutos + iCongestionamentoCentralPublica_Ultimos15Minutos + iCanceladaMensagemOperadora_Ultimos15Minutos;

                // Total Canceladas
                iCancelada_Ultimos15Minutos = iCanceladaCaixaPostal_Ultimos15Minutos + iCanceladaMensagemOperadora_Ultimos15Minutos;

                // total congestionados
                iCongestionamentoTotal_Ultimos15Minutos = iCongestionamentoA4_Ultimos15Minutos + iCongestionamentoCentralPublica_Ultimos15Minutos + iCongetionamentoAgente_Ultimos15Minutos;

                // total falhas
                iFalhaTotal_Ultimos15Minutos = iFalha_Ultimos15Minutos + iFalhaSinalizacao_Ultimos15Minutos;

                DataSet objDs1 = new DataSet();
                objDs1.Tables.Add("TABLE");

                objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_UltimosMinutos.Text = iTotalUltimos15Minutos.ToString();
                    lblAtendidas_UltimosMinutos.Text = iAtendidas_Ultimos15Minutos.ToString();
                    lblCanceladas_UltimosMinutos.Text = iCancelada_Ultimos15Minutos.ToString();
                    lblCanceladasCaixaPostal_UltimosMinutos.Text = iCanceladaCaixaPostal_Ultimos15Minutos.ToString();
                    lblCanceladasMensagem_UltimosMinutos.Text = iCanceladaMensagemOperadora_Ultimos15Minutos.ToString();
                    lblCongestionamento_UltimosMinutos.Text = iCongestionamentoTotal_Ultimos15Minutos.ToString();
                    lblCongestionamento_A4_UltimosMinutos.Text = iCongestionamentoA4_Ultimos15Minutos.ToString();
                    lblCongestionamento_CP_UltimosMinutos.Text = iCongestionamentoCentralPublica_Ultimos15Minutos.ToString();
                    lblCongestionamento_Agente_UltimosMinutos.Text = iCongetionamentoAgente_Ultimos15Minutos.ToString();
                    lblFalhaTotal_UltimosMinutos.Text = iFalhaTotal_Ultimos15Minutos.ToString();
                    lblFalha_UltimosMinutos.Text = iFalha_Ultimos15Minutos.ToString();
                    lblFalhaPorSinalizacao_UltimosMinutos.Text = iFalhaSinalizacao_Ultimos15Minutos.ToString();
                    lblFax_UltimosMinutos.Text = iFax_Ultimos15Minutos.ToString();
                    lblNaoAtendidas_UltimosMinutos.Text = iNaoAtendidas_Ultimos15Minutos.ToString();
                    lblNumerosInvalidos_UltimosMinutos.Text = iNumeroInvalido_Ultimos15Minutos.ToString();
                    lblOcupados_UltimosMinutos.Text = iOcupado_Ultimos15Minutos.ToString();
                    lblTimeOut_UltimosMinutos.Text = iTimeOut_Ultimos15Minutos.ToString();
                    //lblSemAgentes_TotalDia.Text = "";

                    if (lblAtendidas_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", lblAtendidas_UltimosMinutos.Text });

                    if (lblCanceladasCaixaPostal_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", lblCanceladasCaixaPostal_UltimosMinutos.Text });

                    if (lblCanceladasMensagem_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", lblCanceladasMensagem_UltimosMinutos.Text });

                    if (lblCongestionamento_A4_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", lblCongestionamento_A4_UltimosMinutos.Text });

                    if (lblCongestionamento_CP_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", lblCongestionamento_CP_UltimosMinutos.Text });

                    if (lblCongestionamento_Agente_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", lblCongestionamento_Agente_UltimosMinutos.Text });

                    if (lblFalha_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", lblFalha_UltimosMinutos.Text });

                    if (lblFalhaPorSinalizacao_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", lblFalhaPorSinalizacao_UltimosMinutos.Text });

                    if (lblFax_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", lblFax_UltimosMinutos.Text });

                    if (lblNaoAtendidas_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", lblNaoAtendidas_UltimosMinutos.Text });

                    if (lblNumerosInvalidos_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", lblNumerosInvalidos_UltimosMinutos.Text });

                    if (lblOcupados_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", lblOcupados_UltimosMinutos.Text });

                    if (lblTimeOut_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", lblTimeOut_UltimosMinutos.Text });
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iTotalUltimos15Minutos).ToString() + "%";
                    lblAtendidas_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iAtendidas_Ultimos15Minutos).ToString() + "%";
                    lblCanceladas_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iCancelada_Ultimos15Minutos).ToString() + "%";
                    lblCanceladasCaixaPostal_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iCanceladaCaixaPostal_Ultimos15Minutos).ToString() + "%";
                    lblCanceladasMensagem_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iCanceladaMensagemOperadora_Ultimos15Minutos).ToString() + "%";
                    lblCongestionamento_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iCongestionamentoTotal_Ultimos15Minutos).ToString() + "%";
                    lblCongestionamento_A4_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iCongestionamentoA4_Ultimos15Minutos).ToString() + "%";
                    lblCongestionamento_CP_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iCongestionamentoCentralPublica_Ultimos15Minutos).ToString() + "%";
                    lblCongestionamento_Agente_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iCongetionamentoAgente_Ultimos15Minutos).ToString() + "%";
                    lblFalhaTotal_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iFalhaTotal_Ultimos15Minutos).ToString() + "%";
                    lblFalha_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iFalha_Ultimos15Minutos).ToString() + "%";
                    lblFalhaPorSinalizacao_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iFalhaSinalizacao_Ultimos15Minutos).ToString() + "%";
                    lblFax_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iFax_Ultimos15Minutos).ToString() + "%";
                    lblNaoAtendidas_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iNaoAtendidas_Ultimos15Minutos).ToString() + "%";
                    lblNumerosInvalidos_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iNumeroInvalido_Ultimos15Minutos).ToString() + "%";
                    lblOcupados_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iOcupado_Ultimos15Minutos).ToString() + "%";
                    lblTimeOut_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iTimeOut_Ultimos15Minutos).ToString() + "%";
                    //lblSemAgentes_TotalDia.Text = "";

                    if (iAtendidas_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_Ultimos15Minutos });

                    if (iCanceladaCaixaPostal_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", iCanceladaCaixaPostal_Ultimos15Minutos });

                    if (iCanceladaMensagemOperadora_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", iCanceladaMensagemOperadora_Ultimos15Minutos });

                    if (iCongestionamentoA4_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", iCongestionamentoA4_Ultimos15Minutos });

                    if (iCongestionamentoCentralPublica_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", iCongestionamentoCentralPublica_Ultimos15Minutos });

                    if (iCongetionamentoAgente_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", iCongetionamentoAgente_Ultimos15Minutos });

                    if (iFalha_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", iFalha_Ultimos15Minutos });

                    if (iFalhaSinalizacao_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", iFalhaSinalizacao_Ultimos15Minutos });

                    if (iFax_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", iFax_Ultimos15Minutos });

                    if (iNaoAtendidas_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", iNaoAtendidas_Ultimos15Minutos });

                    if (iNumeroInvalido_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", iNumeroInvalido_Ultimos15Minutos });

                    if (iOcupado_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", iOcupado_Ultimos15Minutos });

                    if (iTimeOut_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", iTimeOut_Ultimos15Minutos });

                }

                // Grafico
                DataTable dt = objDs1.Tables[0];
                UltimasChamadasChart.DataSource = dt;
                UltimasChamadasChart.Series["SeriesUltimasChamadasChart"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                UltimasChamadasChart.Series["SeriesUltimasChamadasChart"]["PieLabelStyle"] = "Disabled"; // para desabilitar a legenda da pizza (não interfere na legenda do quadro)
                UltimasChamadasChart.Series["SeriesUltimasChamadasChart"].XValueMember = "Status";
                UltimasChamadasChart.Series["SeriesUltimasChamadasChart"].YValueMembers = "Total";

                UltimasChamadasChart.Legends.Add("Legend1");
                UltimasChamadasChart.Legends[0].Enabled = true;
                UltimasChamadasChart.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
                UltimasChamadasChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    UltimasChamadasChart.Series[0].LegendText = "#VALX (#VALY)";
                    UltimasChamadasChart.Series["SeriesUltimasChamadasChart"].Label = "#VALY";
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    UltimasChamadasChart.Series[0].LegendText = "#VALX (#PERCENT)";
                    UltimasChamadasChart.Series["SeriesUltimasChamadasChart"].Label = "#PERCENT{P2}";
                }

                UltimasChamadasChart.DataManipulator.Sort(PointSortOrder.Descending, UltimasChamadasChart.Series[0]);

                UltimasChamadasChart.DataBind();
                UltimasChamadasChart.Visible = true;

                // exibe a tabela
                tblChamadasUltimos15Minutos.Visible = true;
            }
            catch (Exception ex)
            {
                // var com a mensagem (para posterior utilização)
                string excessao = ex.Message;

                // exibe mensagem de erro durante caso ocorra
                lblMensagemChamadas15Minutos.Text = "<center>...</center>";
                lblMensagemChamadas15Minutos.Visible = true;

                // esconde a tabela caso ocorra alguma excessão
                tblChamadasUltimos15Minutos.Visible = false;
            }
        }

        public void listarEstatistica()
        {
            try
            {
                DateTime iDataHoraAnalise;
                Int32 iTempoMedioChamadas = 0;
                String iProbabilidadeAtendimento;
                Int32 iTempoMedioConversacao = 0;
                Int32 iTempoMedioClerical = 0;

                Campaigns objCampanha = new Campaigns();
                DataSet ds = objCampanha.listCampaignStatistics(ddlCampanhas.SelectedValue.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    iDataHoraAnalise = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATAFIMANALISE"].ToString());
                    iTempoMedioChamadas = Convert.ToInt32(ds.Tables[0].Rows[0]["TempoMedioEntreChamadas"].ToString());
                    iProbabilidadeAtendimento = ds.Tables[0].Rows[0]["PROBABILIDADEATENDIMENTOA"].ToString();
                    iTempoMedioConversacao = Convert.ToInt32(ds.Tables[0].Rows[0]["TEMPOMEDIOCONVERSACAOB"].ToString());
                    iTempoMedioClerical = Convert.ToInt32(ds.Tables[0].Rows[0]["TEMPOMEDIOCLERICAL"].ToString());

                    lblDataHoraAnalise.Text = iDataHoraAnalise.ToString("dd/MM/yyyy hh:mm:ss");
                    lblIntervaloChamadas.Text = iTempoMedioChamadas.ToString();
                    lblProbabilidadeAtendimento.Text = iProbabilidadeAtendimento;
                    lblTempoMedioConversacao.Text = iTempoMedioConversacao.ToString();
                    lblTEMPOMEDIOCLERICAL.Text = iTempoMedioClerical.ToString();
                }
            }
            catch (Exception ex)
            {
                // exibe mensagem de erro durante caso ocorra
                lblMensagemEstatisticas.Text = "<center> Erro !!! </center>";
                lblMensagemEstatisticas.Visible = true;
            }
        }

        /// <summary>
        /// listar os resultados da operações da data atual
        /// </summary>
        /// <param name="tipoDeExibicao"></param>
        public void listarRO(Int16 tipoDeExibicao)
        {
            try
            {
                RO bll = new RO();
                rptRO.DataSource = bll.historyRO(ddlCampanhas.SelectedValue, tipoDeExibicao, objUsers);
                rptRO.DataBind();

                dtoRO objAux = new dtoRO();
                objAux = bll.totalRO(ddlCampanhas.SelectedValue, tipoDeExibicao, objUsers);
                lblTotalRO.Text = objAux.Total.ToString();
            }
            catch (Exception ex)
            {
                // var com a mensagem (para posterior utilização)
                string excessao = ex.Message;
            }
        }

        protected void ConstrutordeTela()
        {
            try
            {
                if (Session["tipoExibicao"] == null)
                {
                    // variáveis auxiliares
                    Session["tipoExibicao"] = 1;
                }

                if (ddlCampanhas.SelectedValue == "0")
                {
                    // apresenta quando o usuário não selecionar um grupo na lista
                    lblMensagemMaling.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadasTotalDia.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadas15Minutos.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemResultadoOperacao.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemEstatisticas.Text = "<center>Nenhuma campanha selecionada!</center>";

                    // exibe as label's de mensagens
                    lblMensagemMaling.Visible = true;
                    lblMensagemChamadasTotalDia.Visible = true;
                    lblMensagemChamadas15Minutos.Visible = true;
                    lblMensagemResultadoOperacao.Visible = true;
                    lblMensagemEstatisticas.Visible = true;

                    //lblCampanhaSelecionada.Text = "Selecione uma campanha...";
                }
                else
                {
                    // esconde as label's de mensagens
                    lblMensagemMaling.Visible = false;
                    lblMensagemChamadasTotalDia.Visible = false;
                    lblMensagemChamadas15Minutos.Visible = false;
                    lblMensagemResultadoOperacao.Visible = false;
                    lblMensagemEstatisticas.Visible = false;

                    // listar o mailing
                    listarMailing(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar chamadas do dia
                    listarChamadasDia(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar chamadas dos últimos 15 minutos
                    listarChamadasUltimos15Minutos(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar os RO's
                    listarRO(Convert.ToInt16(Session["tipoExibicao"].ToString()));

                    // Listar Estatisticas
                    listarEstatistica();

                    updater.Enabled = true;
                }

                dataHora();
            }
            catch (Exception ex)
            {
                // var com a mensagem (para posterior utilização)
                string excessao = ex.Message;

                //lblCampanhaSelecionada.Text = "Selecione uma campanha...";

                // esconde a tabela caso ocorra alguma excessão
                //tblChamadasUltimos15Minutos.Visible = false;
            }
        }

        /// <summary>
        /// Ao selecionar a campanha exibir os dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCampanhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConstrutordeTela();
        }

        /// <summary>
        /// Exibição dos dados de acordo com a seleção das informações
        /// absoluto e porcentagem
        /// modificado em 28/10/2010 às 11:33
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rbExibicaoDasInformacoesValores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
            {
                // variável auxiliar
                Session["tipoExibicao"] = 1;

                if (ddlCampanhas.SelectedValue == "0")
                {
                    // apresenta quando o usuário não selecionar um grupo na lista
                    lblMensagemMaling.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadasTotalDia.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadas15Minutos.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemResultadoOperacao.Text = "<center>Nenhuma campanha selecionada!</center>";

                    // exibe as label's de mensagens
                    lblMensagemMaling.Visible = true;
                    lblMensagemChamadasTotalDia.Visible = true;
                    lblMensagemChamadas15Minutos.Visible = true;
                    lblMensagemResultadoOperacao.Visible = true;

                    //lblCampanhaSelecionada.Text = "Selecione uma campanha...";
                }
                else
                {
                    // esconde as label's de mensagens
                    lblMensagemMaling.Visible = false;
                    lblMensagemChamadasTotalDia.Visible = false;
                    lblMensagemChamadas15Minutos.Visible = false;
                    lblMensagemResultadoOperacao.Visible = false;

                    // Exibe o nome da campanha escolhida
                    //lblCampanhaSelecionada.Text = "Campanha: <b>" + ddlCampanhas.SelectedItem.ToString() + "</b>";

                    // listar o mailing
                    listarMailing(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar chamadas do dia
                    listarChamadasDia(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar chamadas dos últimos 15 minutos
                    listarChamadasUltimos15Minutos(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar os RO's
                    listarRO(Convert.ToInt16(Session["tipoExibicao"].ToString()));

                    updater.Enabled = true;
                }
            }
            else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
            {
                // variável auxiliar
                Session["tipoExibicao"] = 2;

                if (ddlCampanhas.SelectedValue == "0")
                {
                    // apresenta quando o usuário não selecionar um grupo na lista
                    lblMensagemMaling.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadasTotalDia.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadas15Minutos.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemResultadoOperacao.Text = "<center>Nenhuma campanha selecionada!</center>";

                    // exibe as label's de mensagens
                    lblMensagemMaling.Visible = true;
                    lblMensagemChamadasTotalDia.Visible = true;
                    lblMensagemChamadas15Minutos.Visible = true;
                    lblMensagemResultadoOperacao.Visible = true;

                    //lblCampanhaSelecionada.Text = "Selecione uma campanha...";
                }
                else
                {
                    // esconde as label's de mensagens
                    lblMensagemMaling.Visible = false;
                    lblMensagemChamadasTotalDia.Visible = false;
                    lblMensagemChamadas15Minutos.Visible = false;
                    lblMensagemResultadoOperacao.Visible = false;

                    // Exibe o nome da campanha escolhida
                    //lblCampanhaSelecionada.Text = "Campanha: <b>" + ddlCampanha.SelectedItem.ToString() + "</b>";

                    // listar o mailing
                    listarMailing(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar chamadas do dia
                    listarChamadasDia(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar chamadas dos últimos 15 minutos
                    listarChamadasUltimos15Minutos(int.Parse(Session["tipoExibicao"].ToString()));

                    // listar os RO's
                    listarRO(Convert.ToInt16(Session["tipoExibicao"].ToString()));

                    updater.Enabled = true;
                }

                dataHora();
            }
        }

        protected void updater_Tick(object sender, EventArgs e)
        {
            updater.Interval = int.Parse(ConfigurationManager.AppSettings["TimeUpdate"].ToString());
            dataHora();
            ConstrutordeTela();
        }

        protected void cb_Mailing_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Mailing.Checked == false)
            {
                boxMailing.Visible = false;
                boxMailingChart.Visible = false;
            }
            else
            {
                boxMailing.Visible = true;
                boxMailingChart.Visible = true;
            }

            ConstrutordeTela();
        }

        protected void cb_ChamadasTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ChamadasTotal.Checked == false)
            {
                boxChamadasDia.Visible = false;
                boxChamadasDiaChart.Visible = false;
            }
            else
            {
                boxChamadasDia.Visible = true;
                boxChamadasDiaChart.Visible = true;
            }

            ConstrutordeTela();
        }

        protected void cb_ChamadasUltMin_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ChamadasUltMin.Checked == false)
            {
                boxUltimasChamadas.Visible = false;
                boxUltimasChamadasChart.Visible = false;
            }
            else
            {
                boxUltimasChamadas.Visible = true;
                boxUltimasChamadasChart.Visible = true;
            }

            ConstrutordeTela();
        }

        protected void cb_RO_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_RO.Checked == false)
            {
                boxRO.Visible = false;
                //boxROChart.Visible = false;
            }
            else
            {
                boxRO.Visible = true;
                //boxROChart.Visible = true;
            }

            ConstrutordeTela();
        }

        protected void cbGrafico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbGrafico.Checked == true)
                {
                    boxMailingChart.Visible = true;
                    boxChamadasDiaChart.Visible = true;
                    boxUltimasChamadasChart.Visible = true;
                }
                else
                {
                    boxMailingChart.Visible = false;
                    boxChamadasDiaChart.Visible = false;
                    boxUltimasChamadasChart.Visible = false;
                }

                ConstrutordeTela();
            }
            catch (Exception ex)
            {
                lblMensagemMaling.Text = ex.Message;

            }
        }

        protected void cbTexto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTexto.Checked == true)
            {
                boxMailing.Visible = true;
                boxChamadasDia.Visible = true;
                boxUltimasChamadas.Visible = true;
                boxRO.Visible = true;
                boxEstatisticas.Visible = true;
            }
            else
            {
                boxMailing.Visible = false;
                boxChamadasDia.Visible = false;
                boxUltimasChamadas.Visible = false;
                boxRO.Visible = false;
                boxEstatisticas.Visible = false;
            }

            ConstrutordeTela();
        }

        protected void cb_Estatistica_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Estatistica.Checked == false)
            {
                boxEstatisticas.Visible = false;
            }
            else
            {
                boxEstatisticas.Visible = true;
            }

            ConstrutordeTela();
        }
    }
}
