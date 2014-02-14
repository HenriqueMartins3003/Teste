using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
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
    public partial class DashBoardEstatisticas : System.Web.UI.Page
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
            if (objUsersProfiles.AccessProfile("boxEstatisticaAssertividade", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxEstatisticaAssertividade.Visible = false;
            }
            else
            {
                boxEstatisticaAssertividade.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxEstatisticaAssertividadeTotal", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxEstatisticaAssertividadeTotal.Visible = false;
            }
            else
            {
                boxEstatisticaAssertividadeTotal.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxIntervaloMedia", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxIntervaloMedia.Visible = false;
            }
            else
            {
                boxIntervaloMedia.Visible = true;
            }

            if (objUsersProfiles.AccessProfile("boxAtendimento", dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                boxAtendimento.Visible = false;
            }
            else
            {
                boxAtendimento.Visible = true;
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

        private void listCampaign()
        {
            Campaigns objCampaign = new Campaigns();

            ddlCampanhas.DataSource = objCampaign.listCampaignAssociatedModule(objUsers, this.Form.ID);
            ddlCampanhas.DataTextField = "NomeCampanha";
            ddlCampanhas.DataValueField = "Campaign";
            ddlCampanhas.DataBind();
            ddlCampanhas.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        private void listRO()
        {
            RO objRO = new RO();
            lbRO.DataSource = objRO.listRO(ddlCampanhas.SelectedValue.ToString());
            lbRO.DataValueField = "IdRO";
            lbRO.DataTextField = "DescricaoRO";
            lbRO.DataBind();
        }

        private void Construtor()
        {
            EstatisticaAssertividade();
            EstatisticaAssertividadeTotal();
            EstatisticaIntervaloMedia();
            EstatisticaAtendimento();
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


        private void EstatisticaAssertividade()
        {
            try
            {
                String ListROs = "";
                foreach (ListItem _listRO in lbROSelected.Items)
                {
                    ListROs += _listRO.Value + ",";
                }

                Estatisticas objEstatisticas = new Estatisticas();
                DataSet dsAssertividade = objEstatisticas.listaAssetividade(ddlCampanhas.SelectedValue.ToString(), ListROs);

                if (dsAssertividade.Tables[0].Rows.Count > 0)
                {
                    dsAssertividade.Tables[0].Columns.Add("PORCENTAGEM", typeof(String));
                    for (int i = 0; i < dsAssertividade.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            Int32 TotalLigacoes = Convert.ToInt32(dsAssertividade.Tables[0].Compute("SUM(QTDE)", "HORA = " + dsAssertividade.Tables[0].Rows[i]["HORA"]));
                            Int32 iQtde = Convert.ToInt32(dsAssertividade.Tables[0].Rows[i]["QTDE"].ToString());
                            String iPorcentagem = calcularPorcentagem(TotalLigacoes, iQtde);

                            dsAssertividade.Tables[0].Rows[i]["PORCENTAGEM"] = iPorcentagem.Replace(",", ".");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    ChartAssertividade.ChartAreas.Add("chtArea");

                    ChartAssertividade.ChartAreas[0].AxisX.Title = "Hora";
                    ChartAssertividade.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    ChartAssertividade.ChartAreas[0].AxisY.Title = "Volume";
                    ChartAssertividade.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    ChartAssertividade.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                    ChartAssertividade.ChartAreas[0].BorderWidth = 2;
                    ChartAssertividade.Legends.Add("Telefones");


                    // TELEFONE 1
                    if (cbAssertividadeFone1.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone1'";
                        ChartAssertividade.Series.Add("Fone1");
                        ChartAssertividade.Series["Fone1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividade.Series["Fone1"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividade.Series["Fone1"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividade.Series["Fone1"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividade.Series["Fone1"].Label = "#VALY%";
                        }

                        ChartAssertividade.Series["Fone1"].IsVisibleInLegend = true;
                        ChartAssertividade.Series["Fone1"].IsValueShownAsLabel = true;
                        ChartAssertividade.Series["Fone1"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividade.Series["Fone1"].BorderWidth = 3;
                        ChartAssertividade.Series["Fone1"].Color = Color.Red;
                    }

                    // TELEFONE 2
                    if (cbAssertividadeFone2.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone2'";
                        ChartAssertividade.Series.Add("Fone2");
                        ChartAssertividade.Series["Fone2"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividade.Series["Fone2"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividade.Series["Fone2"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividade.Series["Fone2"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividade.Series["Fone2"].Label = "#VALY%";
                        }

                        ChartAssertividade.Series["Fone2"].IsVisibleInLegend = true;
                        ChartAssertividade.Series["Fone2"].IsValueShownAsLabel = true;
                        ChartAssertividade.Series["Fone2"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividade.Series["Fone2"].BorderWidth = 3;
                        ChartAssertividade.Series["Fone2"].Color = Color.Green;
                    }

                    // TELEFONE 3
                    if (cbAssertividadeFone3.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone3'";
                        ChartAssertividade.Series.Add("Fone3");
                        ChartAssertividade.Series["Fone3"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividade.Series["Fone3"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividade.Series["Fone3"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividade.Series["Fone3"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividade.Series["Fone3"].Label = "#VALY%";
                        }

                        ChartAssertividade.Series["Fone3"].IsVisibleInLegend = true;
                        ChartAssertividade.Series["Fone3"].IsValueShownAsLabel = true;
                        ChartAssertividade.Series["Fone3"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividade.Series["Fone3"].BorderWidth = 3;
                        ChartAssertividade.Series["Fone3"].Color = Color.Blue;
                    }


                    // TELEFONE 4
                    if (cbAssertividadeFone4.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone4'";
                        ChartAssertividade.Series.Add("Fone4");
                        ChartAssertividade.Series["Fone4"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividade.Series["Fone4"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividade.Series["Fone4"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividade.Series["Fone4"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividade.Series["Fone4"].Label = "#VALY%";
                        }

                        ChartAssertividade.Series["Fone4"].IsVisibleInLegend = true;
                        ChartAssertividade.Series["Fone4"].IsValueShownAsLabel = true;
                        ChartAssertividade.Series["Fone4"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividade.Series["Fone4"].BorderWidth = 3;
                        ChartAssertividade.Series["Fone4"].Color = Color.Brown;
                    }


                    // TELEFONE 5
                    if (cbAssertividadeFone5.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone5'";
                        ChartAssertividade.Series.Add("Fone5");
                        ChartAssertividade.Series["Fone5"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividade.Series["Fone5"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividade.Series["Fone5"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividade.Series["Fone5"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividade.Series["Fone5"].Label = "#VALY%";
                        }

                        ChartAssertividade.Series["Fone5"].IsVisibleInLegend = true;
                        ChartAssertividade.Series["Fone5"].IsValueShownAsLabel = true;
                        ChartAssertividade.Series["Fone5"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividade.Series["Fone5"].BorderWidth = 3;
                        ChartAssertividade.Series["Fone5"].Color = Color.Yellow;
                    }



                    // Legenda
                    ChartAssertividade.Legends[0].LegendStyle = LegendStyle.Table;
                    ChartAssertividade.Legends[0].TableStyle = LegendTableStyle.Wide;
                    ChartAssertividade.Legends[0].Docking = Docking.Bottom;
                    ChartAssertividade.Legends[0].Title = "Legenda";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void EstatisticaAssertividadeTotal()
        {
            try
            {
                Estatisticas objEstatisticas = new Estatisticas();
                DataSet dsAssertividade = objEstatisticas.listaAssetividade(ddlCampanhas.SelectedValue.ToString(), "");

                if (dsAssertividade.Tables[0].Rows.Count > 0)
                {
                    dsAssertividade.Tables[0].Columns.Add("PORCENTAGEM", typeof(String));
                    for (int i = 0; i < dsAssertividade.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            Int32 TotalLigacoes = Convert.ToInt32(dsAssertividade.Tables[0].Compute("SUM(QTDE)", "HORA = " + dsAssertividade.Tables[0].Rows[i]["HORA"]));
                            Int32 iQtde = Convert.ToInt32(dsAssertividade.Tables[0].Rows[i]["QTDE"].ToString());
                            String iPorcentagem = calcularPorcentagem(TotalLigacoes, iQtde);

                            dsAssertividade.Tables[0].Rows[i]["PORCENTAGEM"] = iPorcentagem.Replace(",", ".");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    ChartAssertividadeTotal.ChartAreas.Add("chtArea");

                    ChartAssertividadeTotal.ChartAreas[0].AxisX.Title = "Hora";
                    ChartAssertividadeTotal.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    ChartAssertividadeTotal.ChartAreas[0].AxisY.Title = "Volume";
                    ChartAssertividadeTotal.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    ChartAssertividadeTotal.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                    ChartAssertividadeTotal.ChartAreas[0].BorderWidth = 2;
                    ChartAssertividadeTotal.Legends.Add("Telefones");


                    // TELEFONE 1
                    if (cbAssertividadeTotalFone1.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone1'";
                        ChartAssertividadeTotal.Series.Add("Fone1");
                        ChartAssertividadeTotal.Series["Fone1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividadeTotal.Series["Fone1"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividadeTotal.Series["Fone1"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividadeTotal.Series["Fone1"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividadeTotal.Series["Fone1"].Label = "#VALY%";
                        }

                        ChartAssertividadeTotal.Series["Fone1"].IsVisibleInLegend = true;
                        ChartAssertividadeTotal.Series["Fone1"].IsValueShownAsLabel = true;
                        ChartAssertividadeTotal.Series["Fone1"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividadeTotal.Series["Fone1"].BorderWidth = 3;
                        ChartAssertividadeTotal.Series["Fone1"].Color = Color.Red;
                    }

                    // TELEFONE 2
                    if (cbAssertividadeTotalFone2.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone2'";
                        ChartAssertividadeTotal.Series.Add("Fone2");
                        ChartAssertividadeTotal.Series["Fone2"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividadeTotal.Series["Fone2"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividadeTotal.Series["Fone2"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividadeTotal.Series["Fone2"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividadeTotal.Series["Fone2"].Label = "#VALY%";
                        }

                        ChartAssertividadeTotal.Series["Fone2"].IsVisibleInLegend = true;
                        ChartAssertividadeTotal.Series["Fone2"].IsValueShownAsLabel = true;
                        ChartAssertividadeTotal.Series["Fone2"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividadeTotal.Series["Fone2"].BorderWidth = 3;
                        ChartAssertividadeTotal.Series["Fone2"].Color = Color.Green;
                    }


                    // TELEFONE 3
                    if (cbAssertividadeTotalFone3.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone3'";
                        ChartAssertividadeTotal.Series.Add("Fone3");
                        ChartAssertividadeTotal.Series["Fone3"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividadeTotal.Series["Fone3"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividadeTotal.Series["Fone3"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividadeTotal.Series["Fone3"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividadeTotal.Series["Fone3"].Label = "#VALY%";
                        }

                        ChartAssertividadeTotal.Series["Fone3"].IsVisibleInLegend = true;
                        ChartAssertividadeTotal.Series["Fone3"].IsValueShownAsLabel = true;
                        ChartAssertividadeTotal.Series["Fone3"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividadeTotal.Series["Fone3"].BorderWidth = 3;
                        ChartAssertividadeTotal.Series["Fone3"].Color = Color.Blue;
                    }


                    // TELEFONE 4
                    if (cbAssertividadeTotalFone4.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone4'";
                        ChartAssertividadeTotal.Series.Add("Fone4");
                        ChartAssertividadeTotal.Series["Fone4"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividadeTotal.Series["Fone4"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividadeTotal.Series["Fone4"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividadeTotal.Series["Fone4"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividadeTotal.Series["Fone4"].Label = "#VALY%";
                        }

                        ChartAssertividadeTotal.Series["Fone4"].IsVisibleInLegend = true;
                        ChartAssertividadeTotal.Series["Fone4"].IsValueShownAsLabel = true;
                        ChartAssertividadeTotal.Series["Fone4"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividadeTotal.Series["Fone4"].BorderWidth = 3;
                        ChartAssertividadeTotal.Series["Fone4"].Color = Color.Brown;
                    }


                    // TELEFONE 5
                    if (cbAssertividadeTotalFone5.Checked == true)
                    {
                        dsAssertividade.Tables[0].DefaultView.RowFilter = "NOMECAMPOFONE = 'Fone5'";
                        ChartAssertividadeTotal.Series.Add("Fone5");
                        ChartAssertividadeTotal.Series["Fone5"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;

                        if (rbExibicaoDasInformacoesValores.SelectedValue == "1")
                        {
                            ChartAssertividadeTotal.Series["Fone5"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "QTDE");
                            ChartAssertividadeTotal.Series["Fone5"].Label = "#VALY";
                        }
                        else if (rbExibicaoDasInformacoesValores.SelectedValue == "2")
                        {
                            ChartAssertividadeTotal.Series["Fone5"].Points.DataBindXY(dsAssertividade.Tables[0].DefaultView, "HORA", dsAssertividade.Tables[0].DefaultView, "PORCENTAGEM");
                            ChartAssertividadeTotal.Series["Fone5"].Label = "#VALY%";
                        }

                        ChartAssertividadeTotal.Series["Fone5"].IsVisibleInLegend = true;
                        ChartAssertividadeTotal.Series["Fone5"].IsValueShownAsLabel = true;
                        ChartAssertividadeTotal.Series["Fone5"].ToolTip = "Data Point Y Value: #VALY{G}";
                        ChartAssertividadeTotal.Series["Fone5"].BorderWidth = 3;
                        ChartAssertividadeTotal.Series["Fone5"].Color = Color.Yellow;
                    }


                    // Legenda
                    ChartAssertividadeTotal.Legends[0].LegendStyle = LegendStyle.Table;
                    ChartAssertividadeTotal.Legends[0].TableStyle = LegendTableStyle.Wide;
                    ChartAssertividadeTotal.Legends[0].Docking = Docking.Bottom;
                    ChartAssertividadeTotal.Legends[0].Title = "Legenda";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void EstatisticaIntervaloMedia()
        {
            try
            {
                Estatisticas objEstatisticas = new Estatisticas();
                DataSet dsQuery = objEstatisticas.listaCalculoCampanhas(ddlCampanhas.SelectedValue.ToString());

                if (dsQuery.Tables[0].Rows.Count > 0)
                {
                    ChartIntervaloMedia.ChartAreas.Add("chtAreaIntervaloMedia");

                    ChartIntervaloMedia.ChartAreas[0].AxisX.Title = "Hora";
                    ChartIntervaloMedia.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    ChartIntervaloMedia.ChartAreas[0].AxisY.Title = "Volume";
                    ChartIntervaloMedia.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    ChartIntervaloMedia.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                    ChartIntervaloMedia.ChartAreas[0].AxisX.Interval = 15;
                    ChartIntervaloMedia.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                    ChartIntervaloMedia.ChartAreas[0].BorderWidth = 2;
                    ChartIntervaloMedia.Legends.Add("IntervaloMedia");

                    if (cbMediaIntervaloRing.Checked == true)
                    {
                        ChartIntervaloMedia.Series.Add("Tempo Médio de Ring");
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].Points.DataBindXY(dsQuery.Tables[0].DefaultView, "LCAM_DFA", dsQuery.Tables[0].DefaultView, "LCAM_TMAA");
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].Label = "#VALY";
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].XValueType = ChartValueType.Time;
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].IsVisibleInLegend = true;
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].IsValueShownAsLabel = true;
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].ToolTip = "Ring: #VALY{G} segundos";
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].BorderWidth = 3;
                        ChartIntervaloMedia.Series["Tempo Médio de Ring"].Color = Color.Red;
                    }

                    if (cbMediaIntervaloChamadas.Checked == true)
                    {
                        ChartIntervaloMedia.Series.Add("Intervalo Entre Chamadas");
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].Points.DataBindXY(dsQuery.Tables[0].DefaultView, "LCAM_DFA", dsQuery.Tables[0].DefaultView, "LCEV_TMEC");
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].Label = "#VALY";
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].XValueType = ChartValueType.Time;
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].IsVisibleInLegend = true;
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].IsValueShownAsLabel = true;
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].ToolTip = "Intervalo: #VALY{G} segundos";
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].BorderWidth = 3;
                        ChartIntervaloMedia.Series["Intervalo Entre Chamadas"].Color = Color.Green;
                    }




                    // Legenda
                    ChartIntervaloMedia.Legends[0].LegendStyle = LegendStyle.Table;
                    ChartIntervaloMedia.Legends[0].TableStyle = LegendTableStyle.Tall;
                    ChartIntervaloMedia.Legends[0].Docking = Docking.Bottom;
                    ChartIntervaloMedia.Legends[0].Title = "Legenda";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void EstatisticaAtendimento()
        {
            try
            {
                Estatisticas objEstatisticas = new Estatisticas();
                DataSet dsQuery = objEstatisticas.listaCalculoCampanhas(ddlCampanhas.SelectedValue.ToString());

                if (dsQuery.Tables[0].Rows.Count > 0)
                {
                    ChartAtendimento.ChartAreas.Add("chtArea");

                    ChartAtendimento.ChartAreas[0].AxisX.Title = "Hora";
                    ChartAtendimento.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 10, System.Drawing.FontStyle.Bold);
                    ChartAtendimento.ChartAreas[0].AxisY.Title = "Volume";
                    ChartAtendimento.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 10, System.Drawing.FontStyle.Bold);
                    ChartAtendimento.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                    ChartAtendimento.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                    ChartAtendimento.ChartAreas[0].AxisX.Interval = 15;
                    ChartAtendimento.ChartAreas[0].BorderWidth = 2;
                    ChartAtendimento.Legends.Add("Atendimento");

                    if (cbChamadasEfetuadas.Checked == true)
                    {
                        ChartAtendimento.Series.Add("Chamadas Efetuadas");
                        ChartAtendimento.Series["Chamadas Efetuadas"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        ChartAtendimento.Series["Chamadas Efetuadas"].Points.DataBindXY(dsQuery.Tables[0].DefaultView, "LCAM_DFA", dsQuery.Tables[0].DefaultView, "LCAM_TL");
                        ChartAtendimento.Series["Chamadas Efetuadas"].Label = "#VALY";
                        ChartAtendimento.Series["Chamadas Efetuadas"].XValueType = ChartValueType.Time;
                        ChartAtendimento.Series["Chamadas Efetuadas"].IsVisibleInLegend = true;
                        ChartAtendimento.Series["Chamadas Efetuadas"].IsValueShownAsLabel = true;
                        ChartAtendimento.Series["Chamadas Efetuadas"].ToolTip = "Chamadas: #VALY{G}";
                        ChartAtendimento.Series["Chamadas Efetuadas"].BorderWidth = 3;
                        ChartAtendimento.Series["Chamadas Efetuadas"].Color = Color.Red;
                    }

                    if (cbChamadasCliente.Checked == true)
                    {
                        ChartAtendimento.Series.Add("Chamadas Atendidas pelo Cliente");
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].Points.DataBindXY(dsQuery.Tables[0].DefaultView, "LCAM_DFA", dsQuery.Tables[0].DefaultView, "LCAM_AC");
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].Label = "#VALY";
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].XValueType = ChartValueType.Time;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].IsVisibleInLegend = true;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].IsValueShownAsLabel = true;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].ToolTip = "Atd Cliente: #VALY{G}";
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].BorderWidth = 3;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Cliente"].Color = Color.Green;
                    }

                    if (cbChamadasAgente.Checked == true)
                    {
                        ChartAtendimento.Series.Add("Chamadas Atendidas pelo Agente");
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].Points.DataBindXY(dsQuery.Tables[0].DefaultView, "LCAM_DFA", dsQuery.Tables[0].DefaultView, "LCAM_AA");
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].Label = "#VALY";
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].XValueType = ChartValueType.Time;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].IsVisibleInLegend = true;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].IsValueShownAsLabel = true;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].ToolTip = "Atd Agente: #VALY{G}";
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].BorderWidth = 3;
                        ChartAtendimento.Series["Chamadas Atendidas pelo Agente"].Color = Color.Blue;
                    }



                    // Legenda
                    ChartAtendimento.Legends[0].LegendStyle = LegendStyle.Table;
                    ChartAtendimento.Legends[0].TableStyle = LegendTableStyle.Tall;
                    ChartAtendimento.Legends[0].Docking = Docking.Bottom;
                    ChartAtendimento.Legends[0].Title = "Legenda";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        protected void rbExibicaoDasInformacoesValores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampanhas.SelectedValue.ToString() != "0")
                Construtor();
        }

        protected void ddlCampanhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRO.Items.Clear();
            lbROSelected.Items.Clear();

            if (ddlCampanhas.SelectedValue.ToString() != "0")
            {
                listRO();
                Construtor();
            }
        }

        protected void buttonArrowLeft_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li1 in lbROSelected.Items)
            {
                if (li1.Selected)
                {
                    lbRO.Items.Add(li1);
                }
            }

            foreach (ListItem li1 in lbRO.Items)
            {
                foreach (ListItem li2 in lbROSelected.Items)
                {
                    if (li1.Value == li2.Value)
                    {
                        lbROSelected.Items.Remove(li2);
                        break;
                    }
                }
            }

            if (ddlCampanhas.SelectedValue.ToString() != "0")
                Construtor();
        }

        protected void buttonArrowRight_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li1 in lbRO.Items)
            {
                if (li1.Selected)
                {
                    lbROSelected.Items.Add(li1);
                }
            }

            foreach (ListItem li1 in lbROSelected.Items)
            {
                foreach (ListItem li2 in lbRO.Items)
                {
                    if (li1.Value == li2.Value)
                    {
                        lbRO.Items.Remove(li2);
                        break;
                    }
                }
            }

            if (ddlCampanhas.SelectedValue.ToString() != "0")
                Construtor();
        }

        protected void updater_Tick(object sender, EventArgs e)
        {
            updater.Interval = int.Parse(ConfigurationManager.AppSettings["TimeUpdate"].ToString());
            dataHora();

            if (ddlCampanhas.SelectedValue.ToString() != "0")
                Construtor();
        }

        public void dataHora()
        {
            lblDataHora.Text = "&nbsp; Atualizado em <b>" + DateTime.Now.ToString("dd/MM/yyyy") + "</b> às <b>" + DateTime.Now.ToString("HH:mm:ss") + "</b>";
        }

        protected void cbAssertividadeFone_CheckedChanged(object sender, EventArgs e)
        {
            Construtor();
        }

        protected void cbAssertividadeTotalFone_CheckedChanged(object sender, EventArgs e)
        {
            Construtor();
        }

        protected void cbChamadasRing_CheckedChanged(object sender, EventArgs e)
        {
            Construtor();
        }

        protected void cbChamadasAtendimento_CheckedChanged(object sender, EventArgs e)
        {
            Construtor();
        }
    }
}
