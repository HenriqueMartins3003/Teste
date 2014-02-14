using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using AjaxControlToolkit;


namespace _webPainelVerisys.Toolbar
{
    public partial class AtualizacaoToolbar : System.Web.UI.Page
    {
        private dtoUsers objUsers = null; 
        UsersProfiles objUsersProfiles = new UsersProfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            ToolkitScriptManager1.RegisterAsyncPostBackControl(TabContainer1);

            if (Session["ObjUsers"] != null)
            {
                objUsers = (dtoUsers)Session["ObjUsers"];
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                AccessSecurity();

                formataGridRamais();
                formataGridLogs();
                formataListBox();
                loadVersaoDefault();
                loadVersoes();
                loadRamais();

            }

            //TabContainer1.OnClientActiveTabChanged

            loadGridRamais();
            loadGridLogs();          

        }

        private void formataListBox()
        {
            try
            {
                int itensListBox = int.Parse(ConfigurationManager.AppSettings["ItemsListBoxRamais"]);
                lbRamais.Rows = itensListBox;
                lbRamaisSelecionador.Rows = itensListBox;
            }

            catch { }
        }


        private void AccessSecurity()
        {
           /* if (Session["ObjUsers"] != null)
            {
                dtoUsers objUser = (dtoUsers)Session["ObjUsers"];
                UserProfiles access = new UserProfiles();

                if (!access.accessOpModule(objUser.IdProfile, Convert.ToInt32(UserProfiles.OpModule.Entries_AAFEControleVersao)))
                {
                    Session["ObjUsers"] = null;
                    Response.Redirect("login.aspx");
                }

                access.setImgButtonINS(this.buttonImageCadastrar, objUser.IdProfile, Convert.ToInt32(UserProfiles.OpModule.Entries_AAFEControleVersao));
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            */

            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Toolbar/AtualizacaoToolbar.aspx");
            }

            bool access = objUsersProfiles.AccessTabPanel(this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            tabAtualizacoes.Visible = access;
            tabVersaoDefault.Visible = access;

            TabContainer1.ActiveTab = tabRamais;
            
           // objUsersProfiles.AcessProfileButton(this.buttonImageCadastrar, "~/img/btn-salvar.gif", this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, Convert.ToInt32(objUsers.IdProfile));
           // objUsersProfiles.AcessProfileButton(this.buttonImageCadastrarDefault, "~/img/btn-salvar.gif", this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, Convert.ToInt32(objUsers.IdProfile));
        }


        protected void formataGridRamais()
        {
            Session["SortAtualRamais"] = " order by Ramal ";
            Session["DecrescenteRamais"] = false;

            gridRamais.AutoGenerateColumns = false;
            gridRamais.Columns.Clear();
            gridRamais.AllowSorting = true;
            try
            {
                int itemsPorPagina = int.Parse(ConfigurationManager.AppSettings["ItemsGridView"]);
                gridRamais.PageSize = itemsPorPagina;
            }

            catch { }

            BoundField Ramal = new BoundField();
            Ramal.DataField = "Ramal";
            Ramal.HeaderText = "Ramal";
            Ramal.HeaderStyle.CssClass = "gridViewHeader1";
            Ramal.ItemStyle.CssClass = "gridViewValues3";
            Ramal.ItemStyle.Width = 40;
            Ramal.SortExpression = "Ramal";
            gridRamais.Columns.Add(Ramal);

            BoundField ModoAtualizacao = new BoundField();
            ModoAtualizacao.DataField = "ModoAtualizacao";
            ModoAtualizacao.HeaderText = "Modo de Atualização";
            ModoAtualizacao.HeaderStyle.CssClass = "gridViewHeader1";
            ModoAtualizacao.ItemStyle.CssClass = "gridViewValues3";
            ModoAtualizacao.ItemStyle.Width = 120;
            ModoAtualizacao.SortExpression = "ModoAtualizacao";
            gridRamais.Columns.Add(ModoAtualizacao);

            BoundField VersaoAtual = new BoundField();
            VersaoAtual.DataField = "VersaoAtual";
            VersaoAtual.HeaderText = "Versao Atual";
            VersaoAtual.HeaderStyle.CssClass = "gridViewHeader1";
            VersaoAtual.ItemStyle.CssClass = "gridViewValues3";
            VersaoAtual.ItemStyle.Width = 80;
            VersaoAtual.SortExpression = "VersaoAtual";
            gridRamais.Columns.Add(VersaoAtual);

            BoundField Versao = new BoundField();
            Versao.DataField = "AtualizarPara";
            Versao.HeaderText = "Atualizar Para";
            Versao.HeaderStyle.CssClass = "gridViewHeader1";
            Versao.ItemStyle.CssClass = "gridViewValues3";
            Versao.ItemStyle.Width = 80;
            Versao.SortExpression = "AtualizarPara";
            gridRamais.Columns.Add(Versao);
                        

            gridRamais.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gridRamais.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gridRamais.FooterStyle.CssClass = "gridViewHeader1";
                     
        }


        private void loadGridRamais()
        {       
            Versao objVersao = new Versao();

            gridRamais.DataSource = objVersao.listRamaisGrid(Session["SortAtualRamais"].ToString(), (bool)Session["DecrescenteRamais"]);
            gridRamais.DataBind();
        }


        protected void GridviewRamais_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridRamais.PageIndex = e.NewPageIndex;
            loadGridRamais();
           // string script = @"RemoveReproducao();";
           // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "teste", script, true);

        }

        protected void GridviewRamais_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["DecrescenteRamais"] = !(bool)Session["DecrescenteRamais"];
            if (e.SortExpression.Equals("Ramal"))
            {
                Session["SortAtualRamais"] = " order by Ramal ";
            }
            if (e.SortExpression.Equals("ModoAtualizacao"))
            {
                Session["SortAtualRamais"] = " order by ModoAtualizacao ";
            }

            if (e.SortExpression.Equals("VersaoAtual"))
            {
                Session["SortAtualRamais"] = " order by VersaoAtual ";
            }

            if (e.SortExpression.Equals("AtualizarPara"))
            {
                Session["SortAtualRamais"] = " order by AtualizarPara ";
            }      

            //  Gridview1.DataSource = Intelig.RetornaRowsLigacoes(NumerodeA, NumerodeB, DataInicial, DataFinal, RetornaStringSort());
            //  Gridview1.DataBind();

            loadGridRamais();
        }

        protected void GridviewRamais_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void formataGridLogs()
        {
            Session["SortAtualLogs"] = " order by DataHora";
            Session["DecrescenteLogs"] = false;

            gridLogs.AutoGenerateColumns = false;
            gridLogs.Columns.Clear();
            gridLogs.AllowSorting = true;

            try
            {
                int itemsPorPagina = int.Parse(ConfigurationManager.AppSettings["ItemsGridView"]);
                gridLogs.PageSize = itemsPorPagina;
            }

            catch { }

            BoundField Ramal = new BoundField();
            Ramal.DataField = "Ramal";
            Ramal.HeaderText = "Ramal";
            Ramal.HeaderStyle.CssClass = "gridViewHeader1";
            Ramal.ItemStyle.CssClass = "gridViewValues3";
            Ramal.ItemStyle.Width = 40;
            Ramal.SortExpression = "Ramal";
            gridLogs.Columns.Add(Ramal);

            BoundField ModoAtualizacao = new BoundField();
            ModoAtualizacao.DataField = "Ip";
            ModoAtualizacao.HeaderText = "Ip";
            ModoAtualizacao.HeaderStyle.CssClass = "gridViewHeader1";
            ModoAtualizacao.ItemStyle.CssClass = "gridViewValues3";
            ModoAtualizacao.ItemStyle.Width = 120;
            ModoAtualizacao.SortExpression = "Ip";
            gridLogs.Columns.Add(ModoAtualizacao);

            BoundField VersaoAtual = new BoundField();
            VersaoAtual.DataField = "VersaoAnterior";
            VersaoAtual.HeaderText = "Versão Anterior";
            VersaoAtual.HeaderStyle.CssClass = "gridViewHeader1";
            VersaoAtual.ItemStyle.CssClass = "gridViewValues3";
            VersaoAtual.ItemStyle.Width = 120;
            VersaoAtual.SortExpression = "VersaoAnterior";
            gridLogs.Columns.Add(VersaoAtual);

            BoundField VersaoAtualizacao = new BoundField();
            VersaoAtualizacao.DataField = "VersaoAtualizacao";
            VersaoAtualizacao.HeaderText = "Versão Atualização";
            VersaoAtualizacao.HeaderStyle.CssClass = "gridViewHeader1";
            VersaoAtualizacao.ItemStyle.CssClass = "gridViewValues3";
            VersaoAtualizacao.ItemStyle.Width = 120;
            VersaoAtualizacao.SortExpression = "VersaoAtualizacao";
            gridLogs.Columns.Add(VersaoAtualizacao);

            BoundField Resultado = new BoundField();
            Resultado.DataField = "Resultado";
            Resultado.HeaderText = "Resultado";
            Resultado.HeaderStyle.CssClass = "gridViewHeader1";
            Resultado.ItemStyle.CssClass = "gridViewValues3";
            Resultado.ItemStyle.Width = 120;
            Resultado.SortExpression = "Resultado";
            gridLogs.Columns.Add(Resultado);

            BoundField DataHora = new BoundField();
            DataHora.DataField = "DataHora";
            DataHora.HeaderText = "Horário Atualização";
            DataHora.HeaderStyle.CssClass = "gridViewHeader1";
            DataHora.ItemStyle.CssClass = "gridViewValues3";
            DataHora.ItemStyle.Width = 120;
            DataHora.SortExpression = "DataHora";
            gridLogs.Columns.Add(DataHora);

            gridLogs.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gridLogs.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gridLogs.FooterStyle.CssClass = "gridViewHeader";

        }


        private void loadGridLogs()
        {
            Versao objVersao = new Versao();
            gridLogs.DataSource = objVersao.ListLogsAA(Session["SortAtualLogs"].ToString(), (bool)Session["DecrescenteLogs"]);
            gridLogs.DataBind();
        }



        protected void GridviewLogs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLogs.PageIndex = e.NewPageIndex;
            loadGridLogs();
            //   gridLogs.DataBind();
            //  string script = @"RemoveReproducao();";
            //   ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "teste", script, true);

        }

        protected void GridviewLogs_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["DecrescenteLogs"] = !(bool)Session["DecrescenteLogs"];
            if (e.SortExpression.Equals("Ramal"))
            {
                Session["SortAtualLogs"] = " order by Ramal ";
            }
            if (e.SortExpression.Equals("Ip"))
            {
                Session["SortAtualLogs"] = " order by Ip ";
            }

            if (e.SortExpression.Equals("VersaoAnterior"))
            {
                Session["SortAtualLogs"] = " order by VersaoAnterior ";
            }

            if (e.SortExpression.Equals("VersaoAtualizacao"))
            {
                Session["SortAtualLogs"] = " order by VersaoAtualizacao ";
            }

            if (e.SortExpression.Equals("Resultado"))
            {
                Session["SortAtualLogs"] = " order by Resultado ";
            }

            if (e.SortExpression.Equals("DataHora"))
            {
                Session["SortAtualLogs"] = " order by DataHora ";
            }

            //  Gridview1.DataSource = Intelig.RetornaRowsLigacoes(NumerodeA, NumerodeB, DataInicial, DataFinal, RetornaStringSort());
            //  Gridview1.DataBind();

            loadGridLogs();
        }

        protected void GridviewLogs_RowDataBound(object sender, GridViewRowEventArgs e)
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

        private void loadVersoes()
        {
            Versao objVersao = new Versao();
            ddlVersao.DataSource = objVersao.listVersao();
            ddlVersao.DataTextField = "DescricaoVersao";
            ddlVersao.DataValueField = "IdPacoteVersao";
            ddlVersao.DataBind();
            ddlVersao.Items.Insert(0, new ListItem("Selecione a Versão ...", "0"));
        }

        private void loadRamais()
        {
            Versao objVersao = new Versao();
            List<dtoRamaisVersao> listRamais = objVersao.listRamais();

            if (listRamais.Count > 0)
            {
                lbRamais.DataSource = listRamais;
                lbRamais.DataValueField = "Ramal";
                lbRamais.DataTextField = "Ramal";
                lbRamais.DataBind();
            }
        }

        private void loadVersaoDefault()
        {
            Versao objVersao = new Versao();
            ddlVersaoDefault.DataSource = objVersao.listVersao();
            ddlVersaoDefault.DataTextField = "DescricaoVersao";
            ddlVersaoDefault.DataValueField = "IdPacoteVersao";
            ddlVersaoDefault.DataBind();
            ddlVersaoDefault.Items.Insert(0, new ListItem("Selecione a Versão ...", "0"));

           string versaoDefault = objVersao.ObtemVersaoDefault();
           if (!string.IsNullOrEmpty(versaoDefault))
           {               
               this.lblDadoVersaoDefault.Text = versaoDefault;                              
           }

           else
           {
               this.lblDadoVersaoDefault.Text = "-";
           }
            
          
        }

        protected void  ActiveTabChangedServer(object sender, EventArgs e)     
        {
            
            
        }



        protected void buttonImageCadastrarDefault_Click(object sender, ImageClickEventArgs e)
        {
            Versao objVersao = new Versao();
            int idVersaoDefault = Convert.ToInt32(ddlVersaoDefault.SelectedValue.ToString());

            if (ddlVersaoDefault.SelectedIndex == 0)
            {
                lblResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'>A versão a ser configurada deve ser selecionada</div>";
                return;
            }

            bool result = objVersao.SalvaVersaoDefault(idVersaoDefault);

            if (result)
            {
                lblResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'>Versão Default alterada com sucesso</div>";
                this.lblDadoVersaoDefault.Text = ddlVersaoDefault.Items[ddlVersaoDefault.SelectedIndex].Text;
            }

            else
            {
                lblResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'>Erro na alteração da Versão Default.</div>";
            }
        }

        protected void buttonImageCadastrar_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlVersao.SelectedIndex == 0)
            {                
                lblResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'>A versão a ser configurada deve ser selecionada</div>";
                return;
            }

            if (lbRamaisSelecionador.Items.Count < 1)
            {
                lblResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'>Pelo menos um ramal deve ser selecionado</div>";
                return;
            }

            Versao objVersao = new Versao();
            Boolean result = false;

            foreach (ListItem _ramais in lbRamaisSelecionador.Items)
            {              
                string ramal = _ramais.Value;
                int idVersao = Convert.ToInt32(ddlVersao.SelectedValue.ToString());
                int modo  = Convert.ToInt32(ddlModo.SelectedValue.ToString());

                result = objVersao.managerVersao(ramal, idVersao, modo, objUsers.User);
            }

            if (result)
            {
                lblResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'>Versão configurada com sucesso</div>";
                loadRamais();
                lbRamaisSelecionador.Items.Clear();
                ddlVersao.SelectedValue = "0";
                loadGridRamais();
            }
            else
            {
                lblResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'>Versão na Aplicação.</div>";
            }
        }

        protected void btnLeft_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li in lbRamaisSelecionador.Items)
            {
                if (li.Selected)
                {
                    lbRamais.Items.Add(li);
                }
            }

            foreach (ListItem li in lbRamais.Items)
            {
                foreach (ListItem li2 in lbRamaisSelecionador.Items)
                {
                    if (li.Value == li2.Value)
                    {
                        lbRamaisSelecionador.Items.Remove(li2);
                        break;
                    }
                }
            }
        }

        protected void btnRight_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li in lbRamais.Items)
            {
                if (li.Selected)
                {
                    lbRamaisSelecionador.Items.Add(li);
                }
            }

            foreach (ListItem li in lbRamaisSelecionador.Items)
            {
                foreach (ListItem li2 in lbRamais.Items)
                {
                    if (li.Value == li2.Value)
                    {
                        lbRamais.Items.Remove(li2);
                        break;
                    }
                }
            }
        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            lblResponse.Visible = false;
        }
    }
}
