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
    public partial class DashBoardReceptivo : System.Web.UI.Page
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
            if (objUsersProfiles.AccessProfile("boxChamadasReceptivasDia", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxChamadasReceptivasDia.Visible = false;
                cb_ChamadasTotal.Visible = false;
                boxChamadasReceptivasDiaChart.Visible = false;
            }
            else
            {
                boxChamadasReceptivasDia.Visible = true;
                cb_ChamadasTotal.Visible = true;
                boxChamadasReceptivasDiaChart.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxUltimasChamadasReceptivas", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxUltimasChamadasReceptivas.Visible = false;
                cb_ChamadasUltMin.Visible = false;
                boxUltimasChamadasReceptivasChart.Visible = false;
            }
            else
            {
                boxUltimasChamadasReceptivas.Visible = true;
                cb_ChamadasUltMin.Visible = true;
                boxUltimasChamadasReceptivasChart.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxRO", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxROReceptivo.Visible = false;
                cb_RO.Visible = false;
            }
            else
            {
                boxROReceptivo.Visible = true;
                cb_RO.Visible = true;
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
                int iRecebidas_TotalDia = 0;

                // cria um DataSet com o número do serviço
                DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CHAMADASRECEBIDAS_TOTALDIA"].ToString());
                ds.Tables[0].DefaultView.Sort = "Campanha, Status";
                ds.Tables[0].DefaultView.RowFilter = "Campanha = '" + ddlCampanhas.SelectedValue + "'";

                // loop para tratamento das informações do XML
                for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                {
                    string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                    string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

                    switch (int.Parse(status))
                    {
                        case 1:
                            iAtendidas_TotalDia = iAtendidas_TotalDia + int.Parse(valor);
                            break;

                        case 0:
                            iRecebidas_TotalDia = iRecebidas_TotalDia + int.Parse(valor);
                            break;
                    }
                }

                // soma do total de chamadas do dia
                iTotalDia = iAtendidas_TotalDia + iRecebidas_TotalDia;

                DataSet objDs1 = new DataSet();
                objDs1.Tables.Add("TABLE");

                objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_TotalDia.Text = iTotalDia.ToString();
                    lblAtendidas_TotalDia.Text = iAtendidas_TotalDia.ToString();
                    lblRecebidas_TotalDia.Text = lblRecebidas_TotalDia.ToString();

                    if (lblAtendidas_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", lblAtendidas_TotalDia.Text });

                    if (lblRecebidas_TotalDia.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Recebidas", lblRecebidas_TotalDia.Text });
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_TotalDia.Text = calcularPorcentagem(iTotalDia, iTotalDia).ToString() + "%";
                    lblAtendidas_TotalDia.Text = calcularPorcentagem(iTotalDia, iAtendidas_TotalDia).ToString() + "%";
                    lblRecebidas_TotalDia.Text = calcularPorcentagem(iTotalDia, iRecebidas_TotalDia).ToString() + "%";

                    if (iAtendidas_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_TotalDia });

                    if (iRecebidas_TotalDia != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Recebidas", iRecebidas_TotalDia });
                }

                // Grafico
                DataTable dt = objDs1.Tables[0];
                ChamadasReceptivasDiaChart.DataSource = dt;
                ChamadasReceptivasDiaChart.Series["SeriesChamadasReceptivasDiaChart"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                ChamadasReceptivasDiaChart.Series["SeriesChamadasReceptivasDiaChart"]["PieLabelStyle"] = "Disabled"; // para desabilitar a legenda da pizza (não interfere na legenda do quadro)
                ChamadasReceptivasDiaChart.Series["SeriesChamadasReceptivasDiaChart"].XValueMember = "Status";
                ChamadasReceptivasDiaChart.Series["SeriesChamadasReceptivasDiaChart"].YValueMembers = "Total";

                ChamadasReceptivasDiaChart.Legends.Add("Legend1");
                ChamadasReceptivasDiaChart.Legends[0].Enabled = true;
                ChamadasReceptivasDiaChart.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
                ChamadasReceptivasDiaChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    ChamadasReceptivasDiaChart.Series[0].LegendText = "#VALX (#VALY)";
                    ChamadasReceptivasDiaChart.Series["SeriesChamadasReceptivasDiaChart"].Label = "#VALY";
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    ChamadasReceptivasDiaChart.Series[0].LegendText = "#VALX (#PERCENT)";
                    ChamadasReceptivasDiaChart.Series["SeriesChamadasReceptivasDiaChart"].Label = "#PERCENT{P2}";
                }

                ChamadasReceptivasDiaChart.DataManipulator.Sort(PointSortOrder.Descending, ChamadasReceptivasDiaChart.Series[0]);

                ChamadasReceptivasDiaChart.DataBind();
                ChamadasReceptivasDiaChart.Visible = true;

                // exibe a tabela
                tblChamadasTotalDia.Visible = true;
            }
            catch (Exception ex)
            {
                // var com a mensagem (para posterior utilização)
                string excessao = ex.Message;

                // exibe mensagem de erro durante caso ocorra
                lblMensagemChamadasReceptivasTotalDia.Text = "<center>...</center>";
                lblMensagemChamadasReceptivasTotalDia.Visible = true;

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
                int iRecebidas_Ultimos15Minutos = 0;

                // cria um DataSet com o número do serviço
                DataSet ds = Geral.RetornaDadosXML_Historico(ConfigurationManager.AppSettings["XML_CHAMADASRECEBIDAS_15MINUTOS"].ToString());
                ds.Tables[0].DefaultView.Sort = "Campanha, Status";
                ds.Tables[0].DefaultView.RowFilter = "Campanha = '" + ddlCampanhas.SelectedValue + "'";

                // loop para tratamento das informações do XML
                for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                {
                    string status = ds.Tables[0].DefaultView.ToTable().Rows[i]["Status"].ToString();
                    string valor = ds.Tables[0].DefaultView.ToTable().Rows[i]["Total"].ToString();

                    switch (int.Parse(status))
                    {
                        case 1:
                            iAtendidas_Ultimos15Minutos = iAtendidas_Ultimos15Minutos + int.Parse(valor);
                            break;

                        case 0:
                            iRecebidas_Ultimos15Minutos = iRecebidas_Ultimos15Minutos + int.Parse(valor);
                            break;
                    }
                }

                // soma do total de chamadas
                iTotalUltimos15Minutos = iAtendidas_Ultimos15Minutos + iRecebidas_Ultimos15Minutos;

                DataSet objDs1 = new DataSet();
                objDs1.Tables.Add("TABLE");

                objDs1.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
                objDs1.Tables[0].Columns.Add("Total", Type.GetType("System.String"));

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_UltimosMinutos.Text = iTotalUltimos15Minutos.ToString();
                    lblAtendidas_UltimosMinutos.Text = iAtendidas_Ultimos15Minutos.ToString();
                    lblRecebidas_UltimosMinutos.Text = iRecebidas_Ultimos15Minutos.ToString();

                    if (lblAtendidas_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", lblAtendidas_UltimosMinutos.Text });

                    if (lblRecebidas_UltimosMinutos.Text != "0")
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Canceladas CP", lblRecebidas_UltimosMinutos.Text });
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    // preenche as informações resgatadas para a exibição nos label's
                    lblTotal_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iTotalUltimos15Minutos).ToString() + "%";
                    lblAtendidas_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iAtendidas_Ultimos15Minutos).ToString() + "%";
                    lblRecebidas_UltimosMinutos.Text = calcularPorcentagem(iTotalUltimos15Minutos, iRecebidas_Ultimos15Minutos).ToString() + "%";

                    if (iAtendidas_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Atendidas", iAtendidas_Ultimos15Minutos });

                    if (iRecebidas_Ultimos15Minutos != 0)
                        objDs1.Tables["TABLE"].Rows.Add(new object[] { "Recebidas", iRecebidas_Ultimos15Minutos });
                }

                // Grafico
                DataTable dt = objDs1.Tables[0];
                UltimasChamadasReceptivasChart.DataSource = dt;
                UltimasChamadasReceptivasChart.Series["SeriesUltimasChamadasReceptivasChart"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                UltimasChamadasReceptivasChart.Series["SeriesUltimasChamadasReceptivasChart"]["PieLabelStyle"] = "Disabled"; // para desabilitar a legenda da pizza (não interfere na legenda do quadro)
                UltimasChamadasReceptivasChart.Series["SeriesUltimasChamadasReceptivasChart"].XValueMember = "Status";
                UltimasChamadasReceptivasChart.Series["SeriesUltimasChamadasReceptivasChart"].YValueMembers = "Total";

                UltimasChamadasReceptivasChart.Legends.Add("Legend1");
                UltimasChamadasReceptivasChart.Legends[0].Enabled = true;
                UltimasChamadasReceptivasChart.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
                UltimasChamadasReceptivasChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                if (int.Parse(Session["tipoExibicao"].ToString()) == 1)
                {
                    UltimasChamadasReceptivasChart.Series[0].LegendText = "#VALX (#VALY)";
                    UltimasChamadasReceptivasChart.Series["SeriesUltimasChamadasReceptivasChart"].Label = "#VALY";
                }
                else if (int.Parse(Session["tipoExibicao"].ToString()) == 2)
                {
                    UltimasChamadasReceptivasChart.Series[0].LegendText = "#VALX (#PERCENT)";
                    UltimasChamadasReceptivasChart.Series["SeriesUltimasChamadasReceptivasChart"].Label = "#PERCENT{P2}";
                }

                UltimasChamadasReceptivasChart.DataManipulator.Sort(PointSortOrder.Descending, UltimasChamadasReceptivasChart.Series[0]);

                UltimasChamadasReceptivasChart.DataBind();
                UltimasChamadasReceptivasChart.Visible = true;

                // exibe a tabela
                tblChamadasUltimos15Minutos.Visible = true;
            }
            catch (Exception ex)
            {
                // var com a mensagem (para posterior utilização)
                string excessao = ex.Message;

                // exibe mensagem de erro durante caso ocorra
                lblMensagemChamadasReceptivas15Minutos.Text = "<center>...</center>";
                lblMensagemChamadasReceptivas15Minutos.Visible = true;

                // esconde a tabela caso ocorra alguma excessão
                tblChamadasUltimos15Minutos.Visible = false;
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
                    lblMensagemChamadasReceptivasTotalDia.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadasReceptivas15Minutos.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemResultadoOperacao.Text = "<center>Nenhuma campanha selecionada!</center>";

                    // exibe as label's de mensagens
                    lblMensagemChamadasReceptivasTotalDia.Visible = true;
                    lblMensagemChamadasReceptivas15Minutos.Visible = true;
                    lblMensagemResultadoOperacao.Visible = true;

                    //lblCampanhaSelecionada.Text = "Selecione uma campanha...";
                }
                else
                {
                    // esconde as label's de mensagens
                    lblMensagemChamadasReceptivasTotalDia.Visible = false;
                    lblMensagemChamadasReceptivas15Minutos.Visible = false;
                    lblMensagemResultadoOperacao.Visible = false;

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
                    lblMensagemChamadasReceptivasTotalDia.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadasReceptivas15Minutos.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemResultadoOperacao.Text = "<center>Nenhuma campanha selecionada!</center>";

                    // exibe as label's de mensagens
                    lblMensagemChamadasReceptivasTotalDia.Visible = true;
                    lblMensagemChamadasReceptivas15Minutos.Visible = true;
                    lblMensagemResultadoOperacao.Visible = true;

                    //lblCampanhaSelecionada.Text = "Selecione uma campanha...";
                }
                else
                {
                    // esconde as label's de mensagens
                    lblMensagemChamadasReceptivasTotalDia.Visible = false;
                    lblMensagemChamadasReceptivas15Minutos.Visible = false;
                    lblMensagemResultadoOperacao.Visible = false;

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
                    lblMensagemChamadasReceptivasTotalDia.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemChamadasReceptivas15Minutos.Text = "<center>Nenhuma campanha selecionada!</center>";
                    lblMensagemResultadoOperacao.Text = "<center>Nenhuma campanha selecionada!</center>";

                    // exibe as label's de mensagens
                    lblMensagemChamadasReceptivasTotalDia.Visible = true;
                    lblMensagemChamadasReceptivas15Minutos.Visible = true;
                    lblMensagemResultadoOperacao.Visible = true;

                    //lblCampanhaSelecionada.Text = "Selecione uma campanha...";
                }
                else
                {
                    // esconde as label's de mensagens
                    lblMensagemChamadasReceptivasTotalDia.Visible = false;
                    lblMensagemChamadasReceptivas15Minutos.Visible = false;
                    lblMensagemResultadoOperacao.Visible = false;

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

        protected void cb_ChamadasTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ChamadasTotal.Checked == false)
            {
                boxChamadasReceptivasDia.Visible = false;
                boxChamadasReceptivasDiaChart.Visible = false;
            }
            else
            {
                boxChamadasReceptivasDia.Visible = true;
                boxChamadasReceptivasDiaChart.Visible = true;
            }

            ConstrutordeTela();
        }

        protected void cb_ChamadasUltMin_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ChamadasUltMin.Checked == false)
            {
                boxUltimasChamadasReceptivas.Visible = false;
                boxUltimasChamadasReceptivasChart.Visible = false;
            }
            else
            {
                boxUltimasChamadasReceptivas.Visible = true;
                boxUltimasChamadasReceptivasChart.Visible = true;
            }

            ConstrutordeTela();
        }

        protected void cb_RO_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_RO.Checked == false)
            {
                boxROReceptivo.Visible = false;
            }
            else
            {
                boxROReceptivo.Visible = true;
            }

            ConstrutordeTela();
        }

        protected void cbGrafico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbGrafico.Checked == true)
                {
                    boxChamadasReceptivasDiaChart.Visible = true;
                    boxUltimasChamadasReceptivasChart.Visible = true;
                }
                else
                {
                    boxChamadasReceptivasDiaChart.Visible = false;
                    boxUltimasChamadasReceptivasChart.Visible = false;
                }

                ConstrutordeTela();
            }
            catch (Exception ex)
            {
                ////////
            }
        }

        protected void cbTexto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTexto.Checked == true)
            {
                boxChamadasReceptivasDia.Visible = true;
                boxUltimasChamadasReceptivas.Visible = true;
                boxROReceptivo.Visible = true;
            }
            else
            {
                boxChamadasReceptivasDia.Visible = false;
                boxUltimasChamadasReceptivas.Visible = false;
                boxROReceptivo.Visible = false;
            }

            ConstrutordeTela();
        }
    }
}
