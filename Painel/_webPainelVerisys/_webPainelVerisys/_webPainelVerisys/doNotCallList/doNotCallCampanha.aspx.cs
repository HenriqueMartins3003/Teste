using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.doNotCallList
{
    public partial class doNotCallCampanha : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        blldoNotCallList objDoNotCallList = new blldoNotCallList();

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
                AccessSecurity();
                gdRegistros_Lista();
                loadProcesso();
                listCampaign();
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

        protected void loadProcesso()
        {
            ddlProcesso.DataSource = objDoNotCallList.listProcesso();
            ddlProcesso.DataTextField = "Processo";
            ddlProcesso.DataValueField = "ProcessoID";
            ddlProcesso.DataBind();
            ddlProcesso.Items.Insert(0, new ListItem("Processo ...", "0"));
        }

        protected void listCampaign()
        {
            Campaigns objCampaign = new Campaigns();
            ddlNotCallCampanha.DataSource = objCampaign.listCampaignAssociated(objUsers);
            ddlNotCallCampanha.DataTextField = "NomeCampanha";
            ddlNotCallCampanha.DataValueField = "Campaign";
            ddlNotCallCampanha.DataBind();
            ddlNotCallCampanha.Items.Insert(0, new ListItem("Campanha ...", "0"));
        }

        protected void gdRegistros_Lista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            // Botoes
            ButtonField btnDelete = new ButtonField();
            btnDelete.ButtonType = ButtonType.Image;
            btnDelete.ImageUrl = "../img/delete.gif";
            btnDelete.CommandName = "Del";
            btnDelete.ItemStyle.Width = 25;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            btnDelete.Visible = true;
            gdRegistros.Columns.Add(btnDelete);


            
            // Campos
            BoundField bfidCampanha = new BoundField();
            bfidCampanha.DataField = "idCampanha";
            bfidCampanha.HeaderText = "idCampanha";
            bfidCampanha.HeaderStyle.CssClass = "gridViewHeader1";
            bfidCampanha.ItemStyle.CssClass = "gridViewValues3";
            bfidCampanha.ItemStyle.Width = 50;
            bfidCampanha.Visible = false;
            gdRegistros.Columns.Add(bfidCampanha);

            BoundField bfCampanha = new BoundField();
            bfCampanha.DataField = "Campanha";
            bfCampanha.HeaderText = "Campanha";
            bfCampanha.HeaderStyle.CssClass = "gridViewHeader1";
            bfCampanha.ItemStyle.CssClass = "gridViewValues3";
            bfCampanha.ItemStyle.Width = 100;
            bfCampanha.Visible = true;
            gdRegistros.Columns.Add(bfCampanha);

            BoundField bfNome = new BoundField();
            bfNome.DataField = "Nome";
            bfNome.HeaderText = "Nome";
            bfNome.HeaderStyle.CssClass = "gridViewHeader1";
            bfNome.ItemStyle.CssClass = "gridViewValues3";
            bfNome.ItemStyle.Width = 200;
            bfNome.Visible = true;
            gdRegistros.Columns.Add(bfNome);

            BoundField bfProcessoID = new BoundField();
            bfProcessoID.DataField = "ProcessoID";
            bfProcessoID.HeaderText = "ProcessoID";
            bfProcessoID.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcessoID.ItemStyle.CssClass = "gridViewValues3";
            bfProcessoID.ItemStyle.Width = 50;
            bfProcessoID.Visible = false;
            gdRegistros.Columns.Add(bfProcessoID);

            BoundField bfProcesso = new BoundField();
            bfProcesso.DataField = "Processo";
            bfProcesso.HeaderText = "Processo";
            bfProcesso.HeaderStyle.CssClass = "gridViewHeader1";
            bfProcesso.ItemStyle.CssClass = "gridViewValues3";
            bfProcesso.ItemStyle.Width = 200;
            bfProcesso.Visible = true;
            gdRegistros.Columns.Add(bfProcesso);

            BoundField bfFlag_Ativo = new BoundField();
            bfFlag_Ativo.DataField = "Flag_Ativo";
            bfFlag_Ativo.HeaderText = "Flag_Ativo";
            bfFlag_Ativo.HeaderStyle.CssClass = "gridViewHeader1";
            bfFlag_Ativo.ItemStyle.CssClass = "gridViewValues3";
            bfFlag_Ativo.ItemStyle.Width = 50;
            bfFlag_Ativo.Visible = false;
            gdRegistros.Columns.Add(bfFlag_Ativo);

            BoundField bfFlagAtivoDescription = new BoundField();
            bfFlagAtivoDescription.DataField = "FlagAtivoDescription";
            bfFlagAtivoDescription.HeaderText = "Ativo?";
            bfFlagAtivoDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfFlagAtivoDescription.ItemStyle.CssClass = "gridViewValues3";
            bfFlagAtivoDescription.ItemStyle.Width = 100;
            bfFlagAtivoDescription.Visible = true;
            gdRegistros.Columns.Add(bfFlagAtivoDescription);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objDoNotCallList.listdoNotCallListCampaign(objUsers);
            if (dsQuery.Tables[0].Rows.Count > 0)
            {
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

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["idCampanha"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["Campanha"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdRegistros.PageIndex = e.NewPageIndex;
            gdRegistros_Lista();
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

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }




        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Cadastro")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Exclusão")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void Cadastro()
        {
            try
            {
                if (ddlNotCallCampanha.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Campanha</b> deve ser selecionado !! </div>";
                    return;
                }

                if (ddlProcesso.SelectedValue == "0")
                {
                    divResponse.Visible = true;
                    lblResponse.Text = "<div class='RNOK'>O Campo <b>Processo</b> deve ser selecionado !! </div>";
                    return;
                }

                dtoNotCallCampanha dtoAux = new dtoNotCallCampanha();
                dtoAux.Task = 1;
                dtoAux.Campanha = ddlNotCallCampanha.SelectedValue;
                dtoAux.ProcessoID = Convert.ToInt64(ddlProcesso.SelectedValue);

                dtoResponse dtoResponse = objDoNotCallList.PAN_ManagerCampaign(dtoAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    lblResponse.Text = "<div class='ROK'> Registro Cadastrado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro do Registro !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro do Registro !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoNotCallCampanha dtoAux = new dtoNotCallCampanha();
                dtoAux.Task = 3;
                dtoAux.IDCampanha = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objDoNotCallList.PAN_ManagerCampaign(dtoAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    lblResponse.Text = "<div class='ROK'> Registro Excluido com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão do Registro !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eExclusao)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão do Registro !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastro";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                ctnLista.Visible = true;
                gdRegistros_Lista();

                // CAMPOS
                ddlNotCallCampanha.SelectedValue = "0";
                ddlProcesso.SelectedValue = "0";
            }
            catch
            {

            }
        }
    }
}
