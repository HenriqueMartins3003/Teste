using System;
using System.Collections.Generic;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Mailing
{
    public partial class ImportacaoLotes : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        Mailings objMailings = new Mailings();

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

        protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampaign.SelectedIndex > 0)
            {
                gridListaLotes();
                modListaLotes.Visible = true;
            }
        }

        protected void gridListaLotes()
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

            BoundField Lot = new BoundField();
            Lot.DataField = "Lot";
            Lot.HeaderText = "Lote";
            Lot.HeaderStyle.CssClass = "gridViewHeader";
            Lot.ItemStyle.CssClass = "gridViewValues";
            Lot.ItemStyle.Width = 100;
            Lot.SortExpression = "Lot";
            gdRegistros.Columns.Add(Lot);

            BoundField LotActivity = new BoundField();
            LotActivity.DataField = "LotActivity";
            LotActivity.HeaderText = "Status do lote";
            LotActivity.HeaderStyle.CssClass = "gridViewHeader";
            LotActivity.ItemStyle.CssClass = "gridViewValues";
            LotActivity.ItemStyle.Width = 150;
            LotActivity.SortExpression = "LotActivity";
            gdRegistros.Columns.Add(LotActivity);

            BoundField Records = new BoundField();
            Records.DataField = "Records";
            Records.HeaderText = "Registros";
            Records.HeaderStyle.CssClass = "gridViewHeader";
            Records.ItemStyle.CssClass = "gridViewValues";
            Records.ItemStyle.Width = 100;
            Records.SortExpression = "Records";
            gdRegistros.Columns.Add(Records);

            BoundField DateTimeMH = new BoundField();
            DateTimeMH.DataField = "DateTimeMH";
            DateTimeMH.HeaderText = "Data/Hora";
            DateTimeMH.HeaderStyle.CssClass = "gridViewHeader";
            DateTimeMH.ItemStyle.CssClass = "gridViewValues";
            DateTimeMH.ItemStyle.Width = 200;
            DateTimeMH.SortExpression = "DateTimeMH";
            gdRegistros.Columns.Add(DateTimeMH);


            // Para exibição do Nome do Arquivo Importado
            BoundField bfArquivo = new BoundField();
            bfArquivo.DataField = "Arquivo";
            bfArquivo.HeaderText = "Arquivo";
            bfArquivo.HeaderStyle.CssClass = "gridViewHeader";
            bfArquivo.ItemStyle.CssClass = "gridViewValues";
            bfArquivo.ItemStyle.Width = 200;
            bfArquivo.SortExpression = "Arquivo";
            gdRegistros.Columns.Add(bfArquivo);






            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";
            gdRegistros.PageSize = 50;

            List<dtoMailing> lista = new List<dtoMailing>();
            lista = objMailings.listLot(ddlCampaign.SelectedValue.ToString());

            if (lista.Count > 0)
            {
                gdRegistros.DataSource = lista;
            }
            else
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='ROK'> Não existem lotes importados !! </div>";
            }

            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencaoLotes.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblTituloDiv.Text = "Gerenciamento de Lote";
                lblIDLote.Text = gdRegistros.DataKeys[index]["Lot"].ToString();
                lblMessageActivate.Text = "Alteração de Estado do Lote : " + gdRegistros.DataKeys[index]["Lot"].ToString();

                String strStatus = gdRegistros.DataKeys[index]["LotActivity"].ToString();
                if (strStatus == "Ativado")
                    rblAtivarDesativar.SelectedValue = "1";
                else
                    rblAtivarDesativar.SelectedValue = "0";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            //UsersProfiles objPerfil = new UsersProfiles();
            //DataSet dsRegistros = objPerfil.BuscaPerfis();

            //DataTable dtRegistros = (DataTable)dsRegistros.Tables[0];
            //String _coluna = e.SortExpression;

            //if (_coluna.Equals(Session["ULTIMOSORT"]))
            //    _coluna = _coluna + " desc";

            //Session.Add("ULTIMOSORT", _coluna);
            //dtRegistros.DefaultView.Sort = _coluna;

            //gdRegistros.DataSource = dtRegistros;
            //gdRegistros.DataBind();
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Gerenciamento de Lote")
            {
                Alteracao();
            }

            Limpar();
        }

        protected void Alteracao()
        {
            try
            {
                String Nome = Dns.GetHostName();
                String IP = null;
                IPAddress[] addresslist = Dns.GetHostAddresses(Dns.GetHostName());

                foreach (IPAddress theaddress in addresslist)
                {
                    IP = theaddress.ToString();
                }

                dtoMailing objDtoMailing = new dtoMailing();
                objDtoMailing.Task = 2;
                objDtoMailing.Campaign = ddlCampaign.SelectedValue.ToString();
                objDtoMailing.Lot = lblIDLote.Text;
                objDtoMailing.LotActivity = rblAtivarDesativar.SelectedValue.ToString();
                objDtoMailing.User = objUsers.User;
                objDtoMailing.Machine = IP;

                Int64 intResultado = objMailings.managerLot(objDtoMailing);
                if (intResultado > 0)
                {
                    lblResponse.Text = "<div class='ROK'> Alteração de Estado do Lote executado com sucesso !! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Estado do Lote !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração de Estado do Lote !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Gerenciar Lote";
                modManutencaoLotes.Visible = false;
                gridListaLotes();
            }
            catch
            {

            }
        }

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gridListaLotes();
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
    }
}
