using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Campanha
{
    public partial class CampanhaHistoricoCalculo : System.Web.UI.Page
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
                loadCampaign();
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

        protected void loadCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void gridLista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            //TEMPOMEDIOATENDIMENTOA
            BoundField bfTMAA = new BoundField();
            bfTMAA.DataField = "LCAM_TMAA";
            bfTMAA.HeaderText = "TMR";
            bfTMAA.HeaderStyle.CssClass = "gridViewHeader1";
            bfTMAA.ItemStyle.CssClass = "gridViewValues3";
            bfTMAA.ItemStyle.Width = 60;
            bfTMAA.SortExpression = "LCAM_TMAA";
            bfTMAA.Visible = true;
            gdRegistros.Columns.Add(bfTMAA);

            //DESVIOPADRAOATENDIMENTOA
            BoundField bfDPAA = new BoundField();
            bfDPAA.DataField = "LCAM_DPAA";
            bfDPAA.HeaderText = "DPAA";
            bfDPAA.HeaderStyle.CssClass = "gridViewHeader1";
            bfDPAA.ItemStyle.CssClass = "gridViewValues3";
            bfDPAA.ItemStyle.Width = 60;
            bfDPAA.Visible = false;
            bfDPAA.SortExpression = "LCAM_DPAA";
            gdRegistros.Columns.Add(bfDPAA);

            //PROBABILIDADEATENDIMENTOA
            BoundField bfPAA = new BoundField();
            bfPAA.DataField = "LCAM_PAA";
            bfPAA.HeaderText = "PAA";
            bfPAA.HeaderStyle.CssClass = "gridViewHeader1";
            bfPAA.ItemStyle.CssClass = "gridViewValues3";
            bfPAA.ItemStyle.Width = 60;
            bfPAA.Visible = false;
            bfPAA.SortExpression = "LCAM_PAA";
            gdRegistros.Columns.Add(bfPAA);

            //PROBABILIDADEATENDIMENTOA %
            BoundField bfPAA_PERC = new BoundField();
            bfPAA_PERC.DataField = "LCAM_PAA_PERC";
            bfPAA_PERC.HeaderText = "PAA";
            bfPAA_PERC.HeaderStyle.CssClass = "gridViewHeader1";
            bfPAA_PERC.ItemStyle.CssClass = "gridViewValues3";
            bfPAA_PERC.ItemStyle.Width = 60;
            bfPAA_PERC.SortExpression = "LCAM_PAA_PERC";
            bfPAA_PERC.Visible = true;
            gdRegistros.Columns.Add(bfPAA_PERC);

            //TEMPOMEDIOCONVERSACAOB
            BoundField bfTMCB = new BoundField();
            bfTMCB.DataField = "LCAM_TMCB";
            bfTMCB.HeaderText = "TMCB";
            bfTMCB.HeaderStyle.CssClass = "gridViewHeader1";
            bfTMCB.ItemStyle.CssClass = "gridViewValues3";
            bfTMCB.ItemStyle.Width = 60;
            bfTMCB.SortExpression = "LCAM_TMCB";
            bfTMCB.Visible = true;
            gdRegistros.Columns.Add(bfTMCB);

            //DESVIOPADRAOCONVERSACAOB
            BoundField bfDPCB = new BoundField();
            bfDPCB.DataField = "LCAM_DPCB";
            bfDPCB.HeaderText = "DPCB";
            bfDPCB.HeaderStyle.CssClass = "gridViewHeader1";
            bfDPCB.ItemStyle.CssClass = "gridViewValues3";
            bfDPCB.ItemStyle.Width = 60;
            bfDPCB.SortExpression = "LCAM_DPCB";
            bfDPCB.Visible = false;
            gdRegistros.Columns.Add(bfDPCB);

            //ATENDIDASAGENTES
            BoundField bfAA = new BoundField();
            bfAA.DataField = "LCAM_AA";
            bfAA.HeaderText = "AA";
            bfAA.HeaderStyle.CssClass = "gridViewHeader1";
            bfAA.ItemStyle.CssClass = "gridViewValues3";
            bfAA.ItemStyle.Width = 60;
            bfAA.SortExpression = "LCAM_AA";
            bfAA.Visible = false;
            gdRegistros.Columns.Add(bfAA);

            //ATENDIDASCLIENTE
            BoundField bfAC = new BoundField();
            bfAC.DataField = "LCAM_AC";
            bfAC.HeaderText = "AC";
            bfAC.HeaderStyle.CssClass = "gridViewHeader1";
            bfAC.ItemStyle.CssClass = "gridViewValues3";
            bfAC.ItemStyle.Width = 60;
            bfAC.SortExpression = "LCAM_AC";
            bfAC.Visible = false;
            gdRegistros.Columns.Add(bfAC);

            //CONGESTIONAMENTOAGENTE
            BoundField bfCA = new BoundField();
            bfCA.DataField = "LCAM_CA";
            bfCA.HeaderText = "CA";
            bfCA.HeaderStyle.CssClass = "gridViewHeader1";
            bfCA.ItemStyle.CssClass = "gridViewValues3";
            bfCA.ItemStyle.Width = 60;
            bfCA.SortExpression = "LCAM_CA";
            bfCA.Visible = false;
            gdRegistros.Columns.Add(bfCA);

            //TOTALLIGACOES
            BoundField bfTL = new BoundField();
            bfTL.DataField = "LCAM_TL";
            bfTL.HeaderText = "TL";
            bfTL.HeaderStyle.CssClass = "gridViewHeader1";
            bfTL.ItemStyle.CssClass = "gridViewValues3";
            bfTL.ItemStyle.Width = 60;
            bfTL.SortExpression = "LCAM_TL";
            bfTL.Visible = true;
            gdRegistros.Columns.Add(bfTL);

            //TEMPOMEDIOCLERICAL
            BoundField bfTMC = new BoundField();
            bfTMC.DataField = "LCEV_TMC";
            bfTMC.HeaderText = "Clerical";
            bfTMC.HeaderStyle.CssClass = "gridViewHeader1";
            bfTMC.ItemStyle.CssClass = "gridViewValues3";
            bfTMC.ItemStyle.Width = 60;
            bfTMC.SortExpression = "LCEV_TMC";
            bfTMC.Visible = true;
            gdRegistros.Columns.Add(bfTMC);

            //TEMPOMEDIOENTRECHAMADAS
            BoundField bfTMEC = new BoundField();
            bfTMEC.DataField = "LCEV_TMEC";
            bfTMEC.HeaderText = "TMEC";
            bfTMEC.HeaderStyle.CssClass = "gridViewHeader1";
            bfTMEC.ItemStyle.CssClass = "gridViewValues3";
            bfTMEC.ItemStyle.Width = 60;
            bfTMEC.SortExpression = "LCEV_TMEC";
            bfTMEC.Visible = true;
            gdRegistros.Columns.Add(bfTMEC);

            //DATAINICIOANALISE
            BoundField bfDIA = new BoundField();
            bfDIA.DataField = "LCAM_DIA";
            bfDIA.HeaderText = "Início Análise";
            bfDIA.HeaderStyle.CssClass = "gridViewHeader";
            bfDIA.ItemStyle.CssClass = "gridViewValues2";
            bfDIA.ItemStyle.Width = 125;
            bfDIA.SortExpression = "LCAM_DIA";
            bfDIA.Visible = true;
            gdRegistros.Columns.Add(bfDIA);

            //DATAFIMANALISE
            BoundField bfDFA = new BoundField();
            bfDFA.DataField = "LCAM_DFA";
            bfDFA.HeaderText = "Fim Análise";
            bfDFA.HeaderStyle.CssClass = "gridViewHeader";
            bfDFA.ItemStyle.CssClass = "gridViewValues2";
            bfDFA.ItemStyle.Width = 125;
            bfDFA.SortExpression = "LCAM_DFA";
            bfDFA.Visible = true;
            gdRegistros.Columns.Add(bfDFA);

            //DATAHORA
            BoundField bfDH = new BoundField();
            bfDH.DataField = "LCAM_DH";
            bfDH.HeaderText = "DH";
            bfDH.HeaderStyle.CssClass = "gridViewHeader";
            bfDH.ItemStyle.CssClass = "gridViewValues2";
            bfDH.ItemStyle.Width = 125;
            bfDH.SortExpression = "LCAM_DH";
            bfDH.Visible = false;
            gdRegistros.Columns.Add(bfDH);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            String DateStart = "";
            String DateFinish = "";


            switch (ddlPeriodo.SelectedValue)
            {
                case "1":
                    DateStart = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd hh:mm:ss");
                    DateFinish = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    break;

                case "2":
                    DateStart = DateTime.Now.AddHours(-2).ToString("yyyy-MM-dd hh:mm:ss");
                    DateFinish = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    break;

                case "3":
                    DateStart = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                    DateFinish = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                    break;
            }

            DataSet dsQuery = objCampaign.listCampaignStatisticsLOG(ddlCampaign.SelectedValue.ToString(), DateStart, DateFinish);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                gdRegistros.DataSource = dsQuery;
                divResponse.Visible = false;
                divROContent.Visible = true;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem dados no Periodo !! </div>";
                divROContent.Visible = false;
            }

            gdRegistros.DataBind();
        }


        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            String DateStart = "";
            String DateFinish = "";


            switch (ddlPeriodo.SelectedValue)
            {
                case "1":
                    DateStart = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd hh:mm:ss");
                    DateFinish = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    break;

                case "2":
                    DateStart = DateTime.Now.AddHours(-2).ToString("yyyy-MM-dd hh:mm:ss");
                    DateFinish = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    break;

                case "3":
                    DateStart = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                    DateFinish = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                    break;
            }

            bllFrontEnd objFrontEnd = new bllFrontEnd();
            DataSet dsRegistros = objCampaign.listCampaignStatisticsLOG(ddlCampaign.SelectedValue.ToString(), DateStart, DateFinish);

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

        protected void buttonImageFilter_Click(object sender, ImageClickEventArgs e)
        {
            gridLista();
        }
    }
}
