using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using System.Text;

namespace _webPainelVerisys.AEC
{
    public partial class ControleMailing : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllAEC objAEC = new bllAEC();

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
                PageConfig();
                //AccessSecurity();
                loadCombos();
                loadCampaign();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                Response.Redirect("../Painel/Default.aspx");
            }

            objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
        }

        private void PageConfig()
        {
            dtoPageConfig objdtoPageConfig = null;
            bllPageConfig objPageConfig = new bllPageConfig();

            String strApplication = Session["ObjApplication"].ToString();
            objdtoPageConfig = objPageConfig.listPageConfig(this.Form.ID, strApplication);

            lblTitulo.Text = objdtoPageConfig.Descricao;
        }

        protected void loadCombos()
        {
            DataSet dsQuery = objAEC.ListGetFiltros();
            Combos(dsQuery, rStatusProdutos, "status_produto");
            Combos(dsQuery, rStatusdaDivida, "statusdivida");
            Combos(dsQuery, rFlagCampanha, "campanha");
            Combos(dsQuery, rCobrador, "cobradores");
            Combos(dsQuery, rCredor, "credores");
            Combos(dsQuery, rTipodetelefone, "telefones");
            Combos(dsQuery, rFila, "filas");
            Combos(dsQuery, rGrupodeCobrador, "grupocobrador");
            Combos(dsQuery, rProdutos, "produtos");
        }

        protected void loadCampaign()
        {
            Campaigns objCampaign = new Campaigns();
            ddlCampaign.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlCampaign.DataTextField = "NomeCampanha";
            ddlCampaign.DataValueField = "Campaign";
            ddlCampaign.DataBind();
            ddlCampaign.Items.Insert(0, new ListItem("Selecione a campanha...", "0"));
        }

        protected void Combos(DataSet dsQuery, Repeater rpFiltro, String FiltroNome)
        {
            dsQuery.Tables[0].DefaultView.RowFilter = "Filtro = '" + FiltroNome + "'";
            rpFiltro.DataSource = dsQuery.Tables[0].DefaultView;
            rpFiltro.DataBind();
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            Executar();
            Limpar();
        }

        protected void Executar()
        {
            try
            {
                if (ddlCampaign.SelectedValue == "0")
                {
                    lblResponse.Text = "<div class='RNOK'>É obrigatório selecionar a campanha associada ao Mailing !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                StringBuilder strFiltro = new StringBuilder();
                strFiltro.Remove(0, strFiltro.Length);

                strFiltro.Append(Filtro(rStatusProdutos, "lblIDStatusProdutos", "chkStatusProdutos", "status_produto"));
                strFiltro.Append(Filtro(rStatusdaDivida, "lblIDStatusdaDivida", "chkStatusdaDivida", "statusdivida"));
                strFiltro.Append(Filtro(rFlagCampanha, "lblIDFlagCampanha", "chkFlagCampanha", "campanha"));
                strFiltro.Append(Filtro(rCobrador, "lblIDCobrador", "chkCobrador", "cobradores"));
                strFiltro.Append(Filtro(rCredor, "lblIDCredor", "chkCredor", "credores"));
                strFiltro.Append(Filtro(rTipodetelefone, "lblIDTipodetelefone", "chkTipodetelefone", "telefones"));
                strFiltro.Append(Filtro(rFila, "lblIDFila", "chkFila", "filas"));
                strFiltro.Append(Filtro(rGrupodeCobrador, "lblIDGrupodeCobrador", "chkGrupodeCobrador", "grupocobrador"));
                strFiltro.Append(Filtro(rProdutos, "lblIDProdutos", "chkProdutos", "produtos"));

                dtoAEC objAux = new dtoAEC();
                objAux.Task = 1;
                objAux.FiltroID = 0;
                objAux.Filtro = strFiltro.ToString();
                objAux.IDCampanha = ddlCampaign.SelectedValue.ToString();
                dtoResponse dtoResponse = objAEC.SP_ManagerProcessamento(objAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    lblResponse.Text = "<div class='ROK'> " + dtoResponse.Result + " </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> " + dtoResponse.Result + " </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Execução do Processo !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));

            }
            catch
            {

            }
        }

        protected String Filtro(Repeater rRepeater, String LabelBusca, String ChkBusca, String Busca)
        {
            String strResult = "";

            foreach (RepeaterItem ri in rRepeater.Items)
            {
                Label ID = (Label)ri.FindControl(LabelBusca);
                CheckBox ckBox = (CheckBox)ri.FindControl(ChkBusca);

                if (ckBox.Checked == true)
                {
                    strResult += ID.Text + ",";
                }
            }
            if (!String.IsNullOrEmpty(strResult))
            {
                strResult = "&" + Busca + "=" + strResult.Substring(0, strResult.Length - 1);
            }

            return strResult;
        }
    }
}













