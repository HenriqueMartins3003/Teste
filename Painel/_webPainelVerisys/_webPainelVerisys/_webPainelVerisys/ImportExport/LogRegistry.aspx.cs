﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.ImportExport
{
    public partial class LogRegistry : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllImportExport objImportExport = new bllImportExport();
        dtoImportExport_Logs objAux = new dtoImportExport_Logs();

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

            BoundField bfFileName = new BoundField();
            bfFileName.DataField = "FileName";
            bfFileName.HeaderText = "Arquivo";
            bfFileName.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileName.ItemStyle.CssClass = "gridViewValues3";
            bfFileName.ItemStyle.Width = 200;
            bfFileName.SortExpression = "FileName";
            bfFileName.Visible = true;
            gdRegistros.Columns.Add(bfFileName);

            BoundField bfFileHash = new BoundField();
            bfFileHash.DataField = "FileHash";
            bfFileHash.HeaderText = "Hash";
            bfFileHash.HeaderStyle.CssClass = "gridViewHeader1";
            bfFileHash.ItemStyle.CssClass = "gridViewValues3";
            bfFileHash.ItemStyle.Width = 400;
            bfFileHash.Visible = false;
            bfFileHash.SortExpression = "FileHash";
            gdRegistros.Columns.Add(bfFileHash);

            BoundField bfProcessDatetime = new BoundField();
            bfProcessDatetime.DataField = "ProcessDatetime";
            bfProcessDatetime.HeaderText = "Data";
            bfProcessDatetime.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessDatetime.ItemStyle.CssClass = "gridViewValues3";
            bfProcessDatetime.ItemStyle.Width = 400;
            bfProcessDatetime.SortExpression = "ProcessDatetime";
            bfProcessDatetime.Visible = true;
            gdRegistros.Columns.Add(bfProcessDatetime);

            BoundField bfRegistryLine = new BoundField();
            bfRegistryLine.DataField = "RegistryLine";
            bfRegistryLine.HeaderText = "Linha";
            bfRegistryLine.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryLine.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryLine.ItemStyle.Width = 400;
            bfRegistryLine.SortExpression = "RegistryLine";
            bfRegistryLine.Visible = true;
            gdRegistros.Columns.Add(bfRegistryLine);

            BoundField bfRegistryStatus = new BoundField();
            bfRegistryStatus.DataField = "RegistryStatus";
            bfRegistryStatus.HeaderText = "Problema";
            bfRegistryStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryStatus.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryStatus.ItemStyle.Width = 400;
            bfRegistryStatus.SortExpression = "RegistryStatus";
            bfRegistryStatus.Visible = true;
            gdRegistros.Columns.Add(bfRegistryStatus);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

           
            objAux.StartDatetime = Convert.ToDateTime(txtStartDate.Text + " " + txtStartTime.Text).ToString("dd/MM/yyyy HH:mm:ss");
            objAux.EndDatetime = Convert.ToDateTime(txtEndDate.Text + " " + txtEndTime.Text).ToString("dd/MM/yyyy HH:mm:ss");
            objAux.ProcessID = Convert.ToInt64(ddlProcessID.SelectedValue);

            DataSet dsQuery = objImportExport.UINT_LOGREGISTRY(objAux, objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
                divResponse.Visible = false;
                ctnLista.Visible = true;
                divGridContent.Visible = true;
                gdRegistros.DataSource = dsQuery;
            }
            else
            {
                divResponse.Visible = true;
                ctnLista.Visible = false;
                divGridContent.Visible = false;
                lblResponse.Text = "<div class='ROK'> Não existem dados Cadastrados !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            objAux.StartDatetime = Convert.ToDateTime(txtStartDate.Text + " " + txtStartTime.Text).ToString("dd/MM/yyyy HH:mm:ss");
            objAux.EndDatetime = Convert.ToDateTime(txtEndDate.Text + " " + txtEndTime.Text).ToString("dd/MM/yyyy HH:mm:ss");
            objAux.ProcessID = Convert.ToInt64(ddlProcessID.SelectedValue);

            DataSet dsRegistros = objImportExport.UINT_LOGREGISTRY(objAux, objUsers);
            if (dsRegistros.Tables[0].Rows.Count > 0)
            {
                DataTable dtRegistros = (DataTable)dsRegistros.Tables[0];
                String _coluna = e.SortExpression;

                if (_coluna.Equals(Session["ULTIMOSORT"]))
                    _coluna = _coluna + " desc";

                Session.Add("ULTIMOSORT", _coluna);
                dtRegistros.DefaultView.Sort = _coluna;

                gdRegistros.DataSource = dtRegistros;
                gdRegistros.DataBind();
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
      
        protected void buttonImageFilter_Click(object sender, ImageClickEventArgs e)
        {
            gdRegistros_Lista();
        }
    }
}
