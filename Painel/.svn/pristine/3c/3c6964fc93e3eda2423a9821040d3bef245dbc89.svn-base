using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Painel
{
    public partial class DashBoardGrafico : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();

        DataSet dsMailingChart = new DataSet();
        DataSet dsChamadasDiaChart = new DataSet();
        DataSet dsUltimasChamadasChart = new DataSet();

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
                CarregaCombos();
                AccessSecurity();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile("boxMailing", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                cb_Mailing.Visible = false;
                cb_Mailing.Checked = false;
                boxMailingChart.Visible = false;
            }
            else
            {
                cb_Mailing.Visible = true;
                cb_Mailing.Checked = true;
                boxMailingChart.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxChamadasDia", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                cb_ChamadasTotal.Visible = false;
                cb_ChamadasTotal.Checked = false;
                boxChamadasDiaChart.Visible = false;
            }
            else
            {
                cb_ChamadasTotal.Visible = true;
                cb_ChamadasTotal.Checked = true;
                boxChamadasDiaChart.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxUltimasChamadas", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                cb_ChamadasUltMin.Visible = false;
                cb_ChamadasUltMin.Checked = false;
                boxUltimasChamadasChart.Visible = false;
            }
            else
            {
                cb_ChamadasUltMin.Visible = true;
                cb_ChamadasUltMin.Checked = true;
                boxUltimasChamadasChart.Visible = true;
            }
        }


        public void dataHora()
        {
            lblDataHora.Text = "&nbsp; Atualizado em <b>" + DateTime.Now.ToString("dd/MM/yyyy") + "</b> às <b>" + DateTime.Now.ToString("HH:mm:ss") + "</b>";
        }

        public void listCampaign()
        {
            Campaigns objCampaign = new Campaigns();

            ddlCampanhas.DataSource = objCampaign.listCampaignAssociatedModule(objUsers, "frmDashBoard");
            ddlCampanhas.DataTextField = "NomeCampanha";
            ddlCampanhas.DataValueField = "Campaign";
            ddlCampanhas.DataBind();
            ddlCampanhas.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        void CarregaCombos()
        {
            DataSet ds = listChartType();

            ddlChamadasDiaChart.DataSource = ds.Tables[0];
            ddlChamadasDiaChart.DataTextField = "A";
            ddlChamadasDiaChart.DataValueField = "B";
            ddlChamadasDiaChart.DataBind();
            ddlChamadasDiaChart.Text = "Pie";

            ddlMailingChart.DataSource = ds.Tables[0];
            ddlMailingChart.DataTextField = "A";
            ddlMailingChart.DataValueField = "B";
            ddlMailingChart.DataBind();
            ddlMailingChart.Text = "Pie";

            ddlUltimasChamadasChart.DataSource = ds.Tables[0];
            ddlUltimasChamadasChart.DataTextField = "A";
            ddlUltimasChamadasChart.DataValueField = "B";
            ddlUltimasChamadasChart.DataBind();
            ddlUltimasChamadasChart.Text = "Pie";
        }

        DataSet listChartType()
        {
            DataSet objDs = new DataSet();
            objDs.Tables.Add("TABLE");

            objDs.Tables[0].Columns.Add("A", Type.GetType("System.String"));
            objDs.Tables[0].Columns.Add("B", Type.GetType("System.String"));

            objDs.Tables["TABLE"].Rows.Add(new object[] { "<Selecione>", "0" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Point", "Point" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "FastPoint", "FastPoint" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Bubble", "Bubble" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Line", "Line" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Spline", "Spline" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "StepLine", "StepLine" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "FastLine", "FastLine" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Bar", "Bar" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "StackedBar", "StackedBar" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "StackedBar100", "StackedBar100" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Column", "Column" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "StackedColumn", "StackedColumn" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "StackedColumn100", "StackedColumn100" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Area", "Area" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "SplineArea", "SplineArea" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "StackedArea", "StackedArea" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "StackedArea100", "StackedArea100" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Pie", "Pie" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Doughnut", "Doughnut" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Stock", "Stock" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Candlestick", "Candlestick" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Range", "Range" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "SplineRange", "SplineRange" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "RangeBar", "RangeBar" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "RangeColumn", "RangeColumn" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Radar", "Radar" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Polar", "Polar" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "ErrorBar", "ErrorBar" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "BoxPlot", "BoxPlot" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Renko", "Renko" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "ThreeLineBreak", "ThreeLineBreak" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "Kagi", "Kagi" });
            //objDs.Tables["TABLE"].Rows.Add(new object[] { "PointAndFigure", "PointAndFigure" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Funnel", "Funnel" });
            objDs.Tables["TABLE"].Rows.Add(new object[] { "Pyramid", "Pyramid" });

            DataView view = objDs.Tables[0].DefaultView;
            view.Sort = "A";

            return objDs;

        }

        protected void ddlMailingChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampanhas.SelectedValue != "0")
                listarMailing();
        }

        protected void ddlChamadasDiaChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampanhas.SelectedValue != "0")
                listarChamadasDia();
        }

        protected void ddlUltimasChamadasChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampanhas.SelectedValue != "0")
                listarChamadasUltimos15Minutos();
        }






        void Chart(SeriesChartType ChartType, Chart ChartName, DataSet dsDados)
        {
            try
            {
                Int16 countDiv = 0;
                Int16 Percent = 30;

                if (cb_ChamadasTotal.Checked == true)
                    countDiv++;

                if (cb_ChamadasUltMin.Checked == true)
                    countDiv++;

                if (cb_Mailing.Checked == true)
                    countDiv++;

                if (countDiv == 1)
                {
                    Percent = 85;
                }
                else if (countDiv == 2)
                {
                    Percent = 43;
                }
                else if (countDiv == 3)
                {
                    Percent = 30;
                }

                Int32 i = (Convert.ToInt32(txtsize.Text) * Percent) / 100;
                ChartName.Width = i;

                DataTable dt = dsDados.Tables[0];
                ChartName.DataSource = dt;
                ChartName.Series[0]["PieLabelStyle"] = "Disabled";
                ChartName.Series[0].XValueMember = "Status";
                ChartName.Series[0].YValueMembers = "Total";

                if ((ChartType == SeriesChartType.Pie) ||
                    (ChartType == SeriesChartType.Doughnut) ||
                    (ChartType == SeriesChartType.Funnel) ||
                    (ChartType == SeriesChartType.Pyramid))
                {
                    ChartName.Legends.Add("Legend1");
                    ChartName.Legends[0].Enabled = true;
                    ChartName.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
                    ChartName.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                    if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                    {
                        ChartName.Series[0].LegendText = "#VALX (#VALY)";
                        ChartName.Series[0].Label = "#VALY";
                    }
                    else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                    {
                        ChartName.Series[0].LegendText = "#VALX (#VALY%)";
                        ChartName.Series[0].Label = "#VALY";
                    }

                    ChartName.Series[0].ChartType = ChartType;
                    ChartName.DataManipulator.Sort(PointSortOrder.Descending, ChartName.Series[0]);
                }

                ChartName.DataBind();
                ChartName.Visible = true;
            }
            catch (Exception ex)
            { }
        }

        public String calcularPorcentagem(int valorTotal, int valorParcial)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }







        //public void listarMailing()
        //{
        //    try
        //    {
        //        DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_MAILING"].ToString());
        //        ds.Tables[0].DefaultView.Sort = "Campanha, Status";
        //        ds.Tables[0].DefaultView.RowFilter = "Campanha = '" + ddlCampanhas.SelectedValue + "'";

        //        // variáveis auxiliares
        //        int iLivres = 0;
        //        int iDiscando = 0;
        //        int iAtendidas = 0;
        //        int iFinalizadosAplicacao = 0;
        //        int iFinalizadosExcessoTentativas = 0;
        //        int iFinalizadosNumerosInvalidos = 0;
        //        int iReagendadoDiscador = 0;
        //        int iReagendadoFrontEnd = 0;
        //        int iNumerosProibidos = 0;
        //        int iNumerosProcom = 0;

        //        // loop para tratamento das informações do XML
        //        for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
        //        {
        //            // valores encontrados na pesquisa
        //            string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
        //            string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

        //            // tratamento dos valores por switch
        //            switch (int.Parse(status))
        //            {
        //                // registro livres
        //                case 0:
        //                    iLivres = iLivres + int.Parse(valor);
        //                    break;

        //                // finalizados pela aplicação
        //                case 1:
        //                    iFinalizadosAplicacao = iFinalizadosAplicacao + int.Parse(valor);
        //                    break;

        //                // Finalizados pela aplicação
        //                case 2:
        //                    iReagendadoDiscador = iReagendadoDiscador + int.Parse(valor);
        //                    break;

        //                // Números proibidos
        //                case 7:
        //                    iNumerosProibidos = iNumerosProibidos + int.Parse(valor);
        //                    break;

        //                // Finalizados por excesso de tentativas
        //                case 8:
        //                    iFinalizadosExcessoTentativas = iFinalizadosExcessoTentativas + int.Parse(valor);
        //                    break;

        //                // Finalizados por números inválidos
        //                case 9:
        //                    iFinalizadosNumerosInvalidos = iFinalizadosNumerosInvalidos + int.Parse(valor);
        //                    break;

        //                // Finalizados por números Restrição do Procon
        //                case 10:
        //                    iNumerosProcom = iNumerosProcom + int.Parse(valor);
        //                    break;

        //                // Reagendado pelo FrontEnd
        //                case 99:
        //                    iReagendadoFrontEnd = iReagendadoFrontEnd + int.Parse(valor);
        //                    break;

        //                case 100:
        //                    iDiscando = iDiscando + int.Parse(valor);
        //                    break;

        //                case 150:
        //                    iAtendidas = iAtendidas + int.Parse(valor);
        //                    break;

        //                default:
        //                    break;
        //            }
        //        }

        //        DataSet objDs1 = new DataSet();
        //        objDs1.Tables.Add("TABLE");

        //        objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
        //        objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

        //        if (iLivres != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Livres", iLivres });

        //        if (iDiscando != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Discando", iDiscando });

        //        if (iAtendidas != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendida", iAtendidas });

        //        if (iFinalizadosAplicacao != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.Aplicação", iFinalizadosAplicacao });

        //        if (iFinalizadosExcessoTentativas != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.ExcessoTent", iFinalizadosExcessoTentativas });

        //        if (iFinalizadosNumerosInvalidos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.NumInvalidos", iFinalizadosNumerosInvalidos });

        //        if (iReagendadoDiscador != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.Discador", iReagendadoDiscador });

        //        if (iReagendadoFrontEnd != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.FrontEnd", iReagendadoFrontEnd });

        //        if (iNumerosProibidos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProibidos", iNumerosProibidos });

        //        if (iNumerosProcom != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProcon", iNumerosProcom });

        //        if (ddlMailingChart.SelectedValue == "0")
        //            Chart(SeriesChartType.Pie, MailingChart, objDs1);
        //        else
        //            Chart((SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlMailingChart.SelectedValue.ToString()), MailingChart, objDs1);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public void listarMailing()
        {
            try
            {
                String iLivres = "0";
                String iDiscando = "0";
                String iAtendidas = "0";
                String iFinalizadosAplicacao = "0";
                String iFinalizadosExcessoTentativas = "0";
                String iFinalizadosNumerosInvalidos = "0";
                String iReagendadoDiscador = "0";
                String iReagendadoFrontEnd = "0";
                String iNumerosProibidos = "0";
                String iNumerosProcom = "0";
                Int32 iTotalMail = 0;

                DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_MAILING"].ToString());
                //ds.Tables[0].DefaultView.Sort = "Campanha, Status";
                

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("PORCENTAGEM", typeof(String));
                    ds.Tables[0].Columns.Add("QTDE", typeof(Int32));

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["QTDE"] = Convert.ToInt32(ds.Tables[0].Rows[i]["Total"]);
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            iTotalMail = Convert.ToInt32(ds.Tables[0].Compute("SUM(QTDE)", "CAMPANHA = " + ds.Tables[0].Rows[i]["CAMPANHA"]));
                            Int32 iQtde = Convert.ToInt32(ds.Tables[0].Rows[i]["QTDE"].ToString());
                            String iPorcentagem = calcularPorcentagem(iTotalMail, iQtde);

                            ds.Tables[0].Rows[i]["PORCENTAGEM"] = iPorcentagem.Replace(",", ".");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    ds.Tables[0].DefaultView.RowFilter = "CAMPANHA = '" + ddlCampanhas.SelectedValue.ToString().Trim() + "'";
                    for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                    {
                        string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                        string valor = "0";
                        String strCampanha = ds.Tables[0].DefaultView.ToTable().Rows[i]["CAMPANHA"].ToString();

                        if (strCampanha == ddlCampanhas.SelectedValue)
                        {
                            if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                                valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();
                            else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                                valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["PORCENTAGEM"].ToString();


                            switch (int.Parse(status))
                            {
                                case 0:
                                    iLivres = valor;
                                    break;
                                case 1:
                                    iFinalizadosAplicacao = valor;
                                    break;
                                case 2:
                                    iReagendadoDiscador = valor;
                                    break;
                                case 7:
                                    iNumerosProibidos = valor;
                                    break;
                                case 8:
                                    iFinalizadosExcessoTentativas = valor;
                                    break;
                                case 9:
                                    iFinalizadosNumerosInvalidos = valor;
                                    break;
                                case 10:
                                    iNumerosProcom = valor;
                                    break;
                                case 99:
                                    iReagendadoFrontEnd = valor;
                                    break;
                                case 100:
                                    iDiscando = valor;
                                    break;
                                case 150:
                                    iAtendidas = valor;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    DataSet objDs1 = new DataSet();
                    objDs1.Tables.Add("TABLE");

                    objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                    objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                    if (iLivres != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Livres", iLivres });

                    if (iDiscando != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Discando", iDiscando });

                    if (iAtendidas != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendida", iAtendidas });

                    if (iFinalizadosAplicacao != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.Aplicação", iFinalizadosAplicacao });

                    if (iFinalizadosExcessoTentativas != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.ExcessoTent", iFinalizadosExcessoTentativas });

                    if (iFinalizadosNumerosInvalidos != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fin.NumInvalidos", iFinalizadosNumerosInvalidos });

                    if (iReagendadoDiscador != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.Discador", iReagendadoDiscador });

                    if (iReagendadoFrontEnd != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Reag.FrontEnd", iReagendadoFrontEnd });

                    if (iNumerosProibidos != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProibidos", iNumerosProibidos });

                    if (iNumerosProcom != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "NumerosProcon", iNumerosProcom });


                    if (ddlMailingChart.SelectedValue == "0")
                        Chart(SeriesChartType.Pie, MailingChart, objDs1);
                    else
                        Chart((SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlMailingChart.SelectedValue.ToString()), MailingChart, objDs1);
                }
            }
            catch (Exception ex)
            {

            }
        }


        //public void listarChamadasDia()
        //{
        //    try
        //    {
        //        // instanciar as variaveis auxiliares
        //        string servico = null;
        //        int iAtendidas_TotalDia = 0;
        //        int iNaoAtendidas_TotalDia = 0;
        //        int iTimeOut_TotalDia = 0;
        //        int iFalha_TotalDia = 0;
        //        int iCongetionamentoAgente_TotalDia = 0;
        //        int iCongestionamentoA4_TotalDia = 0;
        //        int iCongestionamentoCentralPublica_TotalDia = 0;
        //        int iOcupado_TotalDia = 0;
        //        int iFax_TotalDia = 0;
        //        int iNumeroInvalido_TotalDia = 0;

        //        int iCancelada_TotalDia = 0;
        //        int iCanceladaCaixaPostal_TotalDia = 0;
        //        int iCanceladaMensagemOperadora_TotalDia = 0;

        //        int iFalhaSinalizacao_TotalDia = 0;

        //        // busca o número do serviço de acordo com a campanha escolhida
        //        DataSet dsCampanhas = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CAMPANHAS"].ToString());
        //        dsCampanhas.Tables[0].DefaultView.Sort = "Numero";
        //        dsCampanhas.Tables[0].DefaultView.RowFilter = "Numero = '" + ddlCampanhas.SelectedValue + "'";

        //        // captura o número do serviço de acordo com a campanha escolhida
        //        for (int j = 0; j < dsCampanhas.Tables[0].DefaultView.Count; j++)
        //        {
        //            servico = dsCampanhas.Tables[0].DefaultView.ToTable().Rows[j]["Servico"].ToString();
        //        }

        //        // cria um DataSet com o número do serviço
        //        DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CHAMADAS_TOTALDIA"].ToString());
        //        ds.Tables[0].DefaultView.Sort = "Grupo, Status";
        //        ds.Tables[0].DefaultView.RowFilter = "Grupo = '" + servico + "'";

        //        // loop para tratamento das informações do XML
        //        for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
        //        {
        //            string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
        //            string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

        //            switch (int.Parse(status))
        //            {
        //                case 4:
        //                case 5:
        //                case 2002:
        //                    iAtendidas_TotalDia = iAtendidas_TotalDia + int.Parse(valor);
        //                    break;

        //                case 2:
        //                    iTimeOut_TotalDia = iTimeOut_TotalDia + int.Parse(valor);
        //                    break;

        //                case 3:
        //                    iNaoAtendidas_TotalDia = iNaoAtendidas_TotalDia + int.Parse(valor);
        //                    break;

        //                case 6:
        //                    iFalha_TotalDia = iFalha_TotalDia + int.Parse(valor);
        //                    break;

        //                case 7:
        //                    iCongetionamentoAgente_TotalDia = iCongetionamentoAgente_TotalDia + int.Parse(valor);
        //                    break;

        //                case 10:
        //                    iOcupado_TotalDia = iOcupado_TotalDia + int.Parse(valor);
        //                    break;

        //                case 11:
        //                    iFax_TotalDia = iFax_TotalDia + int.Parse(valor);
        //                    break;

        //                case 12:
        //                    iNumeroInvalido_TotalDia = iNumeroInvalido_TotalDia + int.Parse(valor);
        //                    break;

        //                case 16:
        //                    iCanceladaCaixaPostal_TotalDia = iCanceladaCaixaPostal_TotalDia + int.Parse(valor);
        //                    break;

        //                case 18:
        //                    iCongestionamentoA4_TotalDia = iCongestionamentoA4_TotalDia + int.Parse(valor);
        //                    break;

        //                case 19:
        //                    iFalhaSinalizacao_TotalDia = iFalhaSinalizacao_TotalDia + int.Parse(valor);
        //                    break;

        //                case 20:
        //                    iCanceladaMensagemOperadora_TotalDia = iCanceladaMensagemOperadora_TotalDia + int.Parse(valor);
        //                    break;

        //                case 37:
        //                    iCongestionamentoCentralPublica_TotalDia = iCongestionamentoCentralPublica_TotalDia + int.Parse(valor);
        //                    break;
        //            }
        //        }

        //        DataSet objDs1 = new DataSet();
        //        objDs1.Tables.Add("TABLE");

        //        objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
        //        objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

        //        if (iAtendidas_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_TotalDia });

        //        if (iCanceladaCaixaPostal_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", iCanceladaCaixaPostal_TotalDia });

        //        if (iCanceladaMensagemOperadora_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", iCanceladaMensagemOperadora_TotalDia });

        //        if (iCongestionamentoA4_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", iCongestionamentoA4_TotalDia });

        //        if (iCongestionamentoCentralPublica_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", iCongestionamentoCentralPublica_TotalDia });

        //        if (iCongetionamentoAgente_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", iCongetionamentoAgente_TotalDia });

        //        if (iFalha_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", iFalha_TotalDia });

        //        if (iFalhaSinalizacao_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", iFalhaSinalizacao_TotalDia });

        //        if (iFax_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", iFax_TotalDia });

        //        if (iNaoAtendidas_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", iNaoAtendidas_TotalDia });

        //        if (iNumeroInvalido_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", iNumeroInvalido_TotalDia });

        //        if (iOcupado_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", iOcupado_TotalDia });

        //        if (iTimeOut_TotalDia != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", iTimeOut_TotalDia });

        //        if (ddlChamadasDiaChart.SelectedValue == "0")
        //            Chart(SeriesChartType.Pie, ChamadasDiaChart, objDs1);
        //        else
        //            Chart((SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChamadasDiaChart.SelectedValue.ToString()), ChamadasDiaChart, objDs1);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public void listarChamadasDia()
        {
            try
            {
                // instanciar as variaveis auxiliares
                string servico = null;
                String iAtendidas_TotalDia = "0";
                String iNaoAtendidas_TotalDia = "0";
                String iTimeOut_TotalDia = "0";
                String iFalha_TotalDia = "0";
                String iCongetionamentoAgente_TotalDia = "0";
                String iCongestionamentoA4_TotalDia = "0";
                String iCongestionamentoCentralPublica_TotalDia = "0";
                String iOcupado_TotalDia = "0";
                String iFax_TotalDia = "0";
                String iNumeroInvalido_TotalDia = "0";
                String iCanceladaCaixaPostal_TotalDia = "0";
                String iCanceladaMensagemOperadora_TotalDia = "0";
                String iFalhaSinalizacao_TotalDia = "0";

                Int32 iTotal = 0;

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
                ds.Tables[0].DefaultView.Sort = "GRUPO, STATUS";
                ds.Tables[0].DefaultView.RowFilter = "GRUPO = '" + servico + "'";

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("PORCENTAGEM", typeof(String));
                    ds.Tables[0].Columns.Add("QTDE", typeof(Int32));

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["QTDE"] = Convert.ToInt32(ds.Tables[0].Rows[i]["TOTAL"]);
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            iTotal = Convert.ToInt32(ds.Tables[0].Compute("SUM(QTDE)", "GRUPO = '" + ds.Tables[0].Rows[i]["GRUPO"] + "'"));
                            Int32 iQtde = Convert.ToInt32(ds.Tables[0].Rows[i]["QTDE"].ToString());
                            String iPorcentagem = calcularPorcentagem(iTotal, iQtde);

                            ds.Tables[0].Rows[i]["PORCENTAGEM"] = iPorcentagem.Replace(",", ".");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    // loop para tratamento das informações do XML
                    for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                    {
                        string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                        string valor = "0";
                        String strGrupo = ds.Tables[0].DefaultView.ToTable().Rows[i]["GRUPO"].ToString();

                        if (strGrupo == servico)
                        {
                            if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                                valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();
                            else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                                valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["PORCENTAGEM"].ToString();


                            switch (int.Parse(status))
                            {
                                case 4:
                                    break;
                                case 5:
                                    break;
                                case 2002:
                                    //iAtendidas_TotalDia = (Convert.ToInt32(iAtendidas_TotalDia) + Convert.ToInt32(valor)).ToString();
                                    iAtendidas_TotalDia = valor;
                                    break;
                                case 2:
                                    iTimeOut_TotalDia = valor;
                                    break;
                                case 3:
                                    iNaoAtendidas_TotalDia = valor;
                                    break;
                                case 6:
                                    iFalha_TotalDia = valor;
                                    break;
                                case 7:
                                    iCongetionamentoAgente_TotalDia = valor;
                                    break;
                                case 10:
                                    iOcupado_TotalDia = valor;
                                    break;
                                case 11:
                                    iFax_TotalDia = valor;
                                    break;
                                case 12:
                                    iNumeroInvalido_TotalDia = valor;
                                    break;
                                case 16:
                                    iCanceladaCaixaPostal_TotalDia = valor;
                                    break;
                                case 18:
                                    iCongestionamentoA4_TotalDia = valor;
                                    break;
                                case 19:
                                    iFalhaSinalizacao_TotalDia = valor;
                                    break;
                                case 20:
                                    iCanceladaMensagemOperadora_TotalDia = valor;
                                    break;
                                case 37:
                                    iCongestionamentoCentralPublica_TotalDia = valor;
                                    break;
                            }
                        }
                    }

                    DataSet objDs1 = new DataSet();
                    objDs1.Tables.Add("TABLE");

                    objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                    objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                    if (iAtendidas_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_TotalDia });

                    if (iCanceladaCaixaPostal_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", iCanceladaCaixaPostal_TotalDia });

                    if (iCanceladaMensagemOperadora_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", iCanceladaMensagemOperadora_TotalDia });

                    if (iCongestionamentoA4_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", iCongestionamentoA4_TotalDia });

                    if (iCongestionamentoCentralPublica_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", iCongestionamentoCentralPublica_TotalDia });

                    if (iCongetionamentoAgente_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", iCongetionamentoAgente_TotalDia });

                    if (iFalha_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", iFalha_TotalDia });

                    if (iFalhaSinalizacao_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", iFalhaSinalizacao_TotalDia });

                    if (iFax_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", iFax_TotalDia });

                    if (iNaoAtendidas_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", iNaoAtendidas_TotalDia });

                    if (iNumeroInvalido_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", iNumeroInvalido_TotalDia });

                    if (iOcupado_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", iOcupado_TotalDia });

                    if (iTimeOut_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", iTimeOut_TotalDia });

                    if (ddlChamadasDiaChart.SelectedValue == "0")
                        Chart(SeriesChartType.Pie, ChamadasDiaChart, objDs1);
                    else
                        Chart((SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChamadasDiaChart.SelectedValue.ToString()), ChamadasDiaChart, objDs1);
                }
            }
            catch (Exception ex)
            {

            }
        }


        //public void listarChamadasUltimos15Minutos()
        //{
        //    try
        //    {
        //        // instanciar as variaveis auxiliares
        //        string servico = null;
        //        int iAtendidas_Ultimos15Minutos = 0;
        //        int iNaoAtendidas_Ultimos15Minutos = 0;
        //        int iTimeOut_Ultimos15Minutos = 0;
        //        int iFalha_Ultimos15Minutos = 0;
        //        int iCongetionamentoAgente_Ultimos15Minutos = 0;
        //        int iOcupado_Ultimos15Minutos = 0;
        //        int iFax_Ultimos15Minutos = 0;
        //        int iNumeroInvalido_Ultimos15Minutos = 0;
        //        int iCancelada_Ultimos15Minutos = 0;
        //        int iCanceladaCaixaPostal_Ultimos15Minutos = 0;
        //        int iCanceladaMensagemOperadora_Ultimos15Minutos = 0;
        //        int iCongestionamentoA4_Ultimos15Minutos = 0;
        //        int iFalhaSinalizacao_Ultimos15Minutos = 0;
        //        int iCongestionamentoCentralPublica_Ultimos15Minutos = 0;

        //        // busca o número do serviço de acordo com a campanha escolhida
        //        DataSet dsCampanhas = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CAMPANHAS"].ToString());
        //        dsCampanhas.Tables[0].DefaultView.Sort = "Numero";
        //        dsCampanhas.Tables[0].DefaultView.RowFilter = "Numero = '" + ddlCampanhas.SelectedValue + "'";

        //        // captura o número do serviço de acordo com a campanha escolhida
        //        for (int j = 0; j < dsCampanhas.Tables[0].DefaultView.Count; j++)
        //        {
        //            servico = dsCampanhas.Tables[0].DefaultView.ToTable().Rows[j]["Servico"].ToString();
        //        }

        //        // cria um DataSet com o número do serviço
        //        DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CHAMADAS_15MINUTOS"].ToString());
        //        ds.Tables[0].DefaultView.Sort = "Grupo, Status";
        //        ds.Tables[0].DefaultView.RowFilter = "Grupo = '" + servico + "'";

        //        // loop para tratamento das informações do XML
        //        for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
        //        {
        //            string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
        //            string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

        //            switch (int.Parse(status))
        //            {
        //                case 4:
        //                case 5:
        //                case 2002:
        //                    iAtendidas_Ultimos15Minutos = iAtendidas_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 2:
        //                    iTimeOut_Ultimos15Minutos = iTimeOut_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 3:
        //                    iNaoAtendidas_Ultimos15Minutos = iNaoAtendidas_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 6:
        //                    iFalha_Ultimos15Minutos = iFalha_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 7:
        //                    iCongetionamentoAgente_Ultimos15Minutos = iCongetionamentoAgente_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 10:
        //                    iOcupado_Ultimos15Minutos = iOcupado_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 11:
        //                    iFax_Ultimos15Minutos = iFax_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 12:
        //                    iNumeroInvalido_Ultimos15Minutos = iNumeroInvalido_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 16:
        //                    iCanceladaCaixaPostal_Ultimos15Minutos = iCanceladaCaixaPostal_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 18:
        //                    iCongestionamentoA4_Ultimos15Minutos = iCongestionamentoA4_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 19:
        //                    iFalhaSinalizacao_Ultimos15Minutos = iFalhaSinalizacao_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 20:
        //                    iCanceladaMensagemOperadora_Ultimos15Minutos = iCanceladaMensagemOperadora_Ultimos15Minutos + int.Parse(valor);
        //                    break;

        //                case 37:
        //                    iCongestionamentoCentralPublica_Ultimos15Minutos = iCongestionamentoCentralPublica_Ultimos15Minutos + int.Parse(valor);
        //                    break;
        //            }
        //        }

        //        DataSet objDs1 = new DataSet();
        //        objDs1.Tables.Add("TABLE");

        //        objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
        //        objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

        //        if (iAtendidas_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_Ultimos15Minutos });

        //        if (iCanceladaCaixaPostal_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", iCanceladaCaixaPostal_Ultimos15Minutos });

        //        if (iCanceladaMensagemOperadora_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", iCanceladaMensagemOperadora_Ultimos15Minutos });

        //        if (iCongestionamentoA4_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", iCongestionamentoA4_Ultimos15Minutos });

        //        if (iCongestionamentoCentralPublica_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", iCongestionamentoCentralPublica_Ultimos15Minutos });

        //        if (iCongetionamentoAgente_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", iCongetionamentoAgente_Ultimos15Minutos });

        //        if (iFalha_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", iFalha_Ultimos15Minutos });

        //        if (iFalhaSinalizacao_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", iFalhaSinalizacao_Ultimos15Minutos });

        //        if (iFax_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", iFax_Ultimos15Minutos });

        //        if (iNaoAtendidas_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", iNaoAtendidas_Ultimos15Minutos });

        //        if (iNumeroInvalido_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", iNumeroInvalido_Ultimos15Minutos });

        //        if (iOcupado_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", iOcupado_Ultimos15Minutos });

        //        if (iTimeOut_Ultimos15Minutos != 0)
        //            objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", iTimeOut_Ultimos15Minutos });

        //        if (ddlUltimasChamadasChart.SelectedValue == "0")
        //            Chart(SeriesChartType.Pie, UltimasChamadasChart, objDs1);
        //        else
        //            Chart((SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlUltimasChamadasChart.SelectedValue.ToString()), UltimasChamadasChart, objDs1);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public void listarChamadasUltimos15Minutos()
        {
            try
            {
                // instanciar as variaveis auxiliares
                string servico = null;
                String iAtendidas_TotalDia = "0";
                String iNaoAtendidas_TotalDia = "0";
                String iTimeOut_TotalDia = "0";
                String iFalha_TotalDia = "0";
                String iCongetionamentoAgente_TotalDia = "0";
                String iCongestionamentoA4_TotalDia = "0";
                String iCongestionamentoCentralPublica_TotalDia = "0";
                String iOcupado_TotalDia = "0";
                String iFax_TotalDia = "0";
                String iNumeroInvalido_TotalDia = "0";
                String iCanceladaCaixaPostal_TotalDia = "0";
                String iCanceladaMensagemOperadora_TotalDia = "0";
                String iFalhaSinalizacao_TotalDia = "0";

                Int32 iTotal = 0;

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
                ds.Tables[0].DefaultView.Sort = "GRUPO, STATUS";
                ds.Tables[0].DefaultView.RowFilter = "GRUPO = '" + servico + "'";

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("PORCENTAGEM", typeof(String));
                    ds.Tables[0].Columns.Add("QTDE", typeof(Int32));

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["QTDE"] = Convert.ToInt32(ds.Tables[0].Rows[i]["TOTAL"]);
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            iTotal = Convert.ToInt32(ds.Tables[0].Compute("SUM(QTDE)", "GRUPO = '" + ds.Tables[0].Rows[i]["GRUPO"] + "'"));
                            Int32 iQtde = Convert.ToInt32(ds.Tables[0].Rows[i]["QTDE"].ToString());
                            String iPorcentagem = calcularPorcentagem(iTotal, iQtde);

                            ds.Tables[0].Rows[i]["PORCENTAGEM"] = iPorcentagem.Replace(",", ".");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    // loop para tratamento das informações do XML
                    for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                    {
                        string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                        string valor = "0";
                        String strGrupo = ds.Tables[0].DefaultView.ToTable().Rows[i]["GRUPO"].ToString();

                        if (strGrupo == servico)
                        {
                            if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                                valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();
                            else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                                valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["PORCENTAGEM"].ToString();


                            switch (int.Parse(status))
                            {
                                case 4:
                                    break;
                                case 5:
                                    break;
                                case 2002:
                                    //iAtendidas_TotalDia = (Convert.ToInt32(iAtendidas_TotalDia) + Convert.ToInt32(valor)).ToString();
                                    iAtendidas_TotalDia = valor;
                                    break;
                                case 2:
                                    iTimeOut_TotalDia = valor;
                                    break;
                                case 3:
                                    iNaoAtendidas_TotalDia = valor;
                                    break;
                                case 6:
                                    iFalha_TotalDia = valor;
                                    break;
                                case 7:
                                    iCongetionamentoAgente_TotalDia = valor;
                                    break;
                                case 10:
                                    iOcupado_TotalDia = valor;
                                    break;
                                case 11:
                                    iFax_TotalDia = valor;
                                    break;
                                case 12:
                                    iNumeroInvalido_TotalDia = valor;
                                    break;
                                case 16:
                                    iCanceladaCaixaPostal_TotalDia = valor;
                                    break;
                                case 18:
                                    iCongestionamentoA4_TotalDia = valor;
                                    break;
                                case 19:
                                    iFalhaSinalizacao_TotalDia = valor;
                                    break;
                                case 20:
                                    iCanceladaMensagemOperadora_TotalDia = valor;
                                    break;
                                case 37:
                                    iCongestionamentoCentralPublica_TotalDia = valor;
                                    break;
                            }
                        }
                    }

                    DataSet objDs1 = new DataSet();
                    objDs1.Tables.Add("TABLE");

                    objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                    objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                    if (iAtendidas_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_TotalDia });

                    if (iCanceladaCaixaPostal_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", iCanceladaCaixaPostal_TotalDia });

                    if (iCanceladaMensagemOperadora_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas Operadora", iCanceladaMensagemOperadora_TotalDia });

                    if (iCongestionamentoA4_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Destino", iCongestionamentoA4_TotalDia });

                    if (iCongestionamentoCentralPublica_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Public", iCongestionamentoCentralPublica_TotalDia });

                    if (iCongetionamentoAgente_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Congest.Agente", iCongetionamentoAgente_TotalDia });

                    if (iFalha_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas", iFalha_TotalDia });

                    if (iFalhaSinalizacao_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Falhas Sinaliz.", iFalhaSinalizacao_TotalDia });

                    if (iFax_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Fax", iFax_TotalDia });

                    if (iNaoAtendidas_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Não Atendidas", iNaoAtendidas_TotalDia });

                    if (iNumeroInvalido_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Num.Invalidos", iNumeroInvalido_TotalDia });

                    if (iOcupado_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Ocupados", iOcupado_TotalDia });

                    if (iTimeOut_TotalDia != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Outros", iTimeOut_TotalDia });

                    if (ddlChamadasDiaChart.SelectedValue == "0")
                        Chart(SeriesChartType.Pie, UltimasChamadasChart, objDs1);
                    else
                        Chart((SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChamadasDiaChart.SelectedValue.ToString()), UltimasChamadasChart, objDs1);
                }
            }
            catch (Exception ex)
            {

            }
        }










        protected void cb_Mailing_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Mailing.Checked == false)
            {
                boxMailingChart.Visible = false;
            }
            else
            {
                boxMailingChart.Visible = true;
            }

            Redimencionamento();
        }

        protected void cb_ChamadasTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ChamadasTotal.Checked == false)
            {
                boxChamadasDiaChart.Visible = false;
            }
            else
            {
                boxChamadasDiaChart.Visible = true;
            }

            Redimencionamento();

        }

        protected void cb_ChamadasUltMin_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ChamadasUltMin.Checked == false)
            {
                boxUltimasChamadasChart.Visible = false;
            }
            else
            {
                boxUltimasChamadasChart.Visible = true;
            }
            Redimencionamento();

        }

        void Redimencionamento()
        {
            Int16 I = 0;

            if (cb_ChamadasTotal.Checked == true)
                I++;

            if (cb_ChamadasUltMin.Checked == true)
                I++;

            if (cb_Mailing.Checked == true)
                I++;

            if (I == 1)
            {
                boxMailingChart.Attributes["class"] = "containerBoxGrafico1";
                boxChamadasDiaChart.Attributes["class"] = "containerBoxGrafico1";
                boxUltimasChamadasChart.Attributes["class"] = "containerBoxGrafico1";
            }
            else if (I == 2)
            {
                boxMailingChart.Attributes["class"] = "containerBoxGrafico2";
                boxChamadasDiaChart.Attributes["class"] = "containerBoxGrafico2";
                boxUltimasChamadasChart.Attributes["class"] = "containerBoxGrafico2";
            }
            else if (I == 3)
            {
                boxMailingChart.Attributes["class"] = "containerBoxGrafico3";
                boxChamadasDiaChart.Attributes["class"] = "containerBoxGrafico3";
                boxUltimasChamadasChart.Attributes["class"] = "containerBoxGrafico3";
            }

            if (ddlCampanhas.SelectedValue != "0")
                Construtor();
        }

        protected void ddlCampanhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampanhas.SelectedValue != "0")
                Construtor();
        }

        protected void updater_Tick(object sender, EventArgs e)
        {
            updater.Interval = int.Parse(ConfigurationManager.AppSettings["TimeUpdate"].ToString());

            if (ddlCampanhas.SelectedValue != "0")
                Construtor();
        }

        protected void rbExibicaoDasInformacoesValores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampanhas.SelectedValue.ToString() != "0")
                Construtor();
        }

        private void Construtor()
        {
            if (ddlCampanhas.SelectedValue != "0")
            {
                listarMailing();
                listarChamadasDia();
                listarChamadasUltimos15Minutos();
            }
            dataHora();
        }
    }
}
