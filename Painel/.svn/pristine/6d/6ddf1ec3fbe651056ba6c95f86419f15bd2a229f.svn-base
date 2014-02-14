using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.ImportExport
{
    public partial class LogImportExport : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        bllImportExport objImportExport = new bllImportExport();

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
                listProcess();
                listCampaign();

                calStartDate.SelectedDate = DateTime.Now;
                calEndDate.SelectedDate = DateTime.Now;
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/Default.aspx");
            }

            objUsersProfiles.AcessProfileButton(buttonImageFilter, "~/img/btn-filtrar.gif", this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, Convert.ToInt32(objUsers.IdProfile));
        }

        private void PageConfig()
        {
            dtoPageConfig objdtoPageConfig = null;
            bllPageConfig objPageConfig = new bllPageConfig();

            String strApplication = Session["ObjApplication"].ToString();
            objdtoPageConfig = objPageConfig.listPageConfig(this.Form.ID, strApplication);

            lblTitulo.Text = objdtoPageConfig.Descricao;
        }

        protected void listCampaign()
        {
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Campanha ...", "0"));
        }

        protected void listProcess()
        {
            ddlProcessID.DataSource = objImportExport.UINT_LISTPROCESS();
            ddlProcessID.DataTextField = "ProcessName";
            ddlProcessID.DataValueField = "ProcessID";
            ddlProcessID.DataBind();
            ddlProcessID.Items.Insert(0, new ListItem("Todos Processos ...", "0"));
        }

        protected void gdRegistros_Lista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            BoundField bfProcessID = new BoundField();
            bfProcessID.DataField = "ProcessID";
            bfProcessID.HeaderText = "Processo";
            bfProcessID.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessID.ItemStyle.CssClass = "gridViewValues3";
            bfProcessID.ItemStyle.Width = 50;
            bfProcessID.SortExpression = "ProcessID";
            bfProcessID.Visible = true;
            gdRegistros.Columns.Add(bfProcessID);

            BoundField bfFileName = new BoundField();
            bfFileName.DataField = "FileName";
            bfFileName.HeaderText = "Arquivo";
            bfFileName.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileName.ItemStyle.CssClass = "gridViewValues2";
            bfFileName.ItemStyle.Width = 200;
            bfFileName.SortExpression = "FileName";
            bfFileName.Visible = true;
            gdRegistros.Columns.Add(bfFileName);

            BoundField bfCampaign = new BoundField();
            bfCampaign.DataField = "Campaign";
            bfCampaign.HeaderText = "Campanha";
            bfCampaign.HeaderStyle.CssClass = "gridViewHeader1";
            bfCampaign.ItemStyle.CssClass = "gridViewValues3";
            bfCampaign.ItemStyle.Width = 200;
            bfCampaign.SortExpression = "Campaign";
            bfCampaign.Visible = true;
            gdRegistros.Columns.Add(bfCampaign);

            BoundField bfLot = new BoundField();
            bfLot.DataField = "Lot";
            bfLot.HeaderText = "Lote";
            bfLot.HeaderStyle.CssClass = "gridViewHeader1";
            bfLot.ItemStyle.CssClass = "gridViewValues3";
            bfLot.ItemStyle.Width = 200;
            bfLot.SortExpression = "Lot";
            bfLot.Visible = true;
            gdRegistros.Columns.Add(bfLot);

            BoundField bfLotStatus = new BoundField();
            bfLotStatus.DataField = "LotStatus";
            bfLotStatus.HeaderText = "Lote";
            bfLotStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfLotStatus.ItemStyle.CssClass = "gridViewValues3";
            bfLotStatus.ItemStyle.Width = 200;
            bfLotStatus.SortExpression = "LotStatus";
            bfLotStatus.Visible = true;
            gdRegistros.Columns.Add(bfLotStatus);

            BoundField bfRegistryStatus = new BoundField();
            bfRegistryStatus.DataField = "RegistryStatus";
            bfRegistryStatus.HeaderText = "Registro";
            bfRegistryStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryStatus.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryStatus.ItemStyle.Width = 200;
            bfRegistryStatus.SortExpression = "RegistryStatus";
            bfRegistryStatus.Visible = true;
            gdRegistros.Columns.Add(bfRegistryStatus);

            BoundField bfTotalImported = new BoundField();
            bfTotalImported.DataField = "TotalImported";
            bfTotalImported.HeaderText = "IMP";
            bfTotalImported.HeaderStyle.CssClass = "gridViewHeader1";
            bfTotalImported.ItemStyle.CssClass = "gridViewValues3";
            bfTotalImported.ItemStyle.Width = 200;
            bfTotalImported.SortExpression = "TotalImported";
            bfTotalImported.Visible = true;
            gdRegistros.Columns.Add(bfTotalImported);

            BoundField bfTotalRejected = new BoundField();
            bfTotalRejected.DataField = "TotalRejected";
            bfTotalRejected.HeaderText = "REJ";
            bfTotalRejected.HeaderStyle.CssClass = "gridViewHeader1";
            bfTotalRejected.ItemStyle.CssClass = "gridViewValues3";
            bfTotalRejected.ItemStyle.Width = 200;
            bfTotalRejected.SortExpression = "TotalRejected";
            bfTotalRejected.Visible = true;
            gdRegistros.Columns.Add(bfTotalRejected);

            BoundField bfTotalFile = new BoundField();
            bfTotalFile.DataField = "TotalFile";
            bfTotalFile.HeaderText = "Total";
            bfTotalFile.HeaderStyle.CssClass = "gridViewHeader1";
            bfTotalFile.ItemStyle.CssClass = "gridViewValues3";
            bfTotalFile.ItemStyle.Width = 200;
            bfTotalFile.SortExpression = "TotalFile";
            bfTotalFile.Visible = true;
            gdRegistros.Columns.Add(bfTotalFile);

            BoundField bfImportDateTimeStart = new BoundField();
            bfImportDateTimeStart.DataField = "ImportDateTimeStart";
            bfImportDateTimeStart.HeaderText = "Inicio";
            bfImportDateTimeStart.HeaderStyle.CssClass = "gridViewHeader1";
            bfImportDateTimeStart.ItemStyle.CssClass = "gridViewValues3";
            bfImportDateTimeStart.ItemStyle.Width = 200;
            bfImportDateTimeStart.SortExpression = "ImportDateTimeStart";
            bfImportDateTimeStart.Visible = true;
            gdRegistros.Columns.Add(bfImportDateTimeStart);

            BoundField bfImportDateTimeEnd = new BoundField();
            bfImportDateTimeEnd.DataField = "ImportDateTimeEnd";
            bfImportDateTimeEnd.HeaderText = "Fim";
            bfImportDateTimeEnd.HeaderStyle.CssClass = "gridViewHeader1";
            bfImportDateTimeEnd.ItemStyle.CssClass = "gridViewValues3";
            bfImportDateTimeEnd.ItemStyle.Width = 200;
            bfImportDateTimeEnd.SortExpression = "ImportDateTimeEnd";
            bfImportDateTimeEnd.Visible = false;
            gdRegistros.Columns.Add(bfImportDateTimeEnd);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            dtoImportExport_Logs objAux = new dtoImportExport_Logs();
            objAux.StartDatetime = Convert.ToDateTime(txtStartDate.Text + " " + txtStartTime.Text).ToString("dd/MM/yyyy HH:mm:ss");
            objAux.EndDatetime = Convert.ToDateTime(txtEndDate.Text + " " + txtEndTime.Text).ToString("dd/MM/yyyy HH:mm:ss");
            objAux.ProcessID = Convert.ToInt64(ddlProcessID.SelectedValue);
            objAux.CampaignID = ddlCampaign.SelectedValue;

            DataSet dsQuery = objImportExport.UINT_LOGIMPORTEXPORT(objAux, objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                divResponse.Visible = false;
                ctnLista.Visible = true;
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

        protected void gdRegistros_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView oGridView = (GridView)sender;
                GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell oTableCell = new TableCell();

                // Coluna 1
                oTableCell.Text = "";
                oTableCell.ColumnSpan = 4;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);

                //Ativos
                oTableCell = new TableCell();
                oTableCell.Text = "Ativos?";
                oTableCell.ColumnSpan = 2;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

                //Registros
                oTableCell = new TableCell();
                oTableCell.Text = "Registros";
                oTableCell.ColumnSpan = 3;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

                //Database
                oTableCell = new TableCell();
                oTableCell.Text = "";
                oTableCell.ColumnSpan = 1;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
            }
        }

        protected void buttonImageFilter_Click(object sender, ImageClickEventArgs e)
        {
            gdRegistros_Lista();
        }
    }
}
