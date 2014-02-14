using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys.Campanha
{
    public partial class CampanhaGrupos : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        Campaigns objCampaign = new Campaigns();
        RO objROCampanha = new RO();

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
                gridLista();
                loadCampaignNotAssociatedGroups();
            }
        }

        private void AccessSecurity()
        {
            if (objUsersProfiles.AccessProfile(this.Form.ID, dtoUsersProfiles.AccessType.CONSULTA, objUsers.IdProfile) == 0)
            {
                //Response.Redirect("../Painel/DashBoard.aspx");
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

        protected void loadCampaignNotAssociatedGroups()
        {
            lbCampaign.DataSource = objCampaign.listCampaignNotAssociatedGroup();
            lbCampaign.DataValueField = "Campaign";
            lbCampaign.DataTextField = "NomeCampanha";
            lbCampaign.DataBind();
        }

        protected void gridLista()
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

            ButtonField btnDelete = new ButtonField();
            btnDelete.ButtonType = ButtonType.Image;
            btnDelete.ImageUrl = "../img/delete.gif";
            btnDelete.CommandName = "Del";
            btnDelete.ItemStyle.Width = 25;
            btnDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnDelete.HeaderText = "";
            btnDelete.HeaderStyle.CssClass = "gridViewHeader";
            gdRegistros.Columns.Add(btnDelete);

            BoundField bfID = new BoundField();
            bfID.DataField = "ID";
            bfID.HeaderText = "ID";
            bfID.HeaderStyle.CssClass = "gridViewHeader1";
            bfID.ItemStyle.CssClass = "gridViewValues3";
            bfID.ItemStyle.Width = 100;
            bfID.SortExpression = "ID";
            bfID.Visible = false;
            gdRegistros.Columns.Add(bfID);

            BoundField bfGrupo = new BoundField();
            bfGrupo.DataField = "Grupo";
            bfGrupo.HeaderText = "Grupo";
            bfGrupo.HeaderStyle.CssClass = "gridViewHeader";
            bfGrupo.ItemStyle.CssClass = "gridViewValues2";
            bfGrupo.ItemStyle.Width = 200;
            bfGrupo.SortExpression = "Grupo";
            gdRegistros.Columns.Add(bfGrupo);

            BoundField bfQtdeMaximaCanais = new BoundField();
            bfQtdeMaximaCanais.DataField = "QtdeMaximaCanais";
            bfQtdeMaximaCanais.HeaderText = "Qtde Max. Canais";
            bfQtdeMaximaCanais.HeaderStyle.CssClass = "gridViewHeader";
            bfQtdeMaximaCanais.ItemStyle.CssClass = "gridViewValues2";
            bfQtdeMaximaCanais.ItemStyle.Width = 100;
            bfQtdeMaximaCanais.SortExpression = "QtdeMaximaCanais";
            gdRegistros.Columns.Add(bfQtdeMaximaCanais);

            BoundField bfAtivo = new BoundField();
            bfAtivo.DataField = "Ativo";
            bfAtivo.HeaderText = "Ativo?";
            bfAtivo.HeaderStyle.CssClass = "gridViewHeader";
            bfAtivo.ItemStyle.CssClass = "gridViewValues2";
            bfAtivo.ItemStyle.Width = 50;
            bfAtivo.SortExpression = "Ativo";
            gdRegistros.Columns.Add(bfAtivo);

            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            gdRegistros.DataSource = objCampaign.listGroups();
            gdRegistros.DataBind();
        }

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Alteração";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                int index = int.Parse((string)e.CommandArgument);
                lblID.Text = gdRegistros.DataKeys[index]["ID"].ToString();

                // Alimenta a LabelBox com os ROs já cadastrados
                lbCampaignSelected.DataSource = objCampaign.listCampaignAssociatedGroup(Convert.ToInt32(gdRegistros.DataKeys[index]["ID"].ToString()));
                lbCampaignSelected.DataValueField = "Campaign";
                lbCampaignSelected.DataTextField = "NomeCampanha";
                lbCampaignSelected.DataBind();

                txtGrupo.Text = gdRegistros.DataKeys[index]["Grupo"].ToString();
                txtMaxCanais.Text = gdRegistros.DataKeys[index]["QtdeMaximaCanais"].ToString();
                ddlAtivo.SelectedValue = gdRegistros.DataKeys[index]["Ativo"].ToString() == "SIM" ? "True" : "False";

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                lblTituloDiv.Text = "Exclusão";
                modManutencao.Visible = false;
                modExcluir.Visible = true;
                int index = int.Parse((string)e.CommandArgument);

                lblID.Text = gdRegistros.DataKeys[index]["ID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["Grupo"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            RO objRO = new RO();
            DataSet dsRegistros = objCampaign.listGroups();

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

        protected void Manager_Click(object sender, ImageClickEventArgs e)
        {
            if (lblTituloDiv.Text == "Cadastrar")
            {
                Cadastro();
            }
            else if (lblTituloDiv.Text == "Alteração")
            {
                Alteracao();
            }
            else if (lblTituloDiv.Text == "Exclusão")
            {
                Exclusao();
            }

            Limpar();
        }

        protected void buttonImageLimpar_Click(object sender, ImageClickEventArgs e)
        {
            Limpar();
            divResponse.Visible = false;
        }

        protected void Cadastro()
        {
            try
            {
                if (String.IsNullOrEmpty(txtGrupo.Text))
                {
                    lblResponse.Text = "<div class='RNOK'>Nome do Grupo não pode ficar em branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (String.IsNullOrEmpty(txtMaxCanais.Text))
                {
                    lblResponse.Text = "<div class='RNOK'>Qtde de canais não pode ficar em branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }


                dtoCampaignGroup objDto = new dtoCampaignGroup();
                objDto.Task = 1;
                objDto.Grupo = txtGrupo.Text;
                objDto.QtdeMaximaCanais = Convert.ToInt32(txtMaxCanais.Text);
                objDto.Ativo = Convert.ToInt32(ddlAtivo.SelectedValue == "False" ? 0 : 1);

                foreach (ListItem li in lbCampaignSelected.Items)
                {
                    objDto.Campaigns += li.Value.ToString() + ",";
                }
                objDto.Campaigns = objDto.Campaigns.Substring(0, objDto.Campaigns.Length - 1);

                Int64 Result = objCampaign.managerGroups(objDto);
                if (Result == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Erro no cadastro !!! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='ROK'>Cadastro realizado com sucesso !!! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eCadastro)
            {
                lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro !! </div>";
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            UsersProfiles objProfiles = new UsersProfiles();

            try
            {
                if (String.IsNullOrEmpty(txtGrupo.Text))
                {
                    lblResponse.Text = "<div class='RNOK'>Nome do Grupo não pode ficar em branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }

                if (String.IsNullOrEmpty(txtMaxCanais.Text))
                {
                    lblResponse.Text = "<div class='RNOK'>Qtde de canais não pode ficar em branco !! </div>";
                    divResponse.Visible = true;
                    return;
                }


                dtoCampaignGroup objDto = new dtoCampaignGroup();
                objDto.Task = 2;
                objDto.GrupoID = Convert.ToInt32(lblID.Text);
                objDto.Grupo = txtGrupo.Text;
                objDto.QtdeMaximaCanais = Convert.ToInt32(txtMaxCanais.Text);
                objDto.Ativo = Convert.ToInt32(ddlAtivo.SelectedValue == "False" ? 0 : 1);

                foreach (ListItem li in lbCampaignSelected.Items)
                {
                    objDto.Campaigns += li.Value.ToString() + ",";
                }
                objDto.Campaigns = objDto.Campaigns.Substring(0, objDto.Campaigns.Length - 1);

                Int64 Result = objCampaign.managerGroups(objDto);
                if (Result == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Erro na Alteração !!! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='ROK'>Alteração realizado com sucesso !!! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração !! </div>";
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoCampaignGroup objDto = new dtoCampaignGroup();
                objDto.Task = 3;
                objDto.GrupoID = Convert.ToInt32(lblID.Text);

                Int64 Result = objCampaign.managerGroups(objDto);
                if (Result == 0)
                {
                    lblResponse.Text = "<div class='RNOK'>Erro na Exclusão !!! </div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='ROK'>Exclusão realizado com sucesso !!! </div>";
                    divResponse.Visible = true;
                }
            }
            catch
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão !! </div>";
            }
        }

        protected void Limpar()
        {
            try
            {
                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.INCLUSAO, Convert.ToInt32(objUsers.IdProfile));
                lblTituloDiv.Text = "Cadastrar";
                modManutencao.Visible = true;
                modExcluir.Visible = false;
                loadCampaignNotAssociatedGroups();
                lbCampaignSelected.Items.Clear();
                txtGrupo.Text = "";
                txtMaxCanais.Text = "";
                gridLista();
            }
            catch
            {

            }
        }

        protected void buttonArrowLeft_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li1 in lbCampaignSelected.Items)
            {
                if (li1.Selected)
                {
                    lbCampaign.Items.Add(li1);
                }
            }

            foreach (ListItem li1 in lbCampaign.Items)
            {
                if (li1.Selected)
                {
                    lbCampaignSelected.Items.Remove(li1);
                }
            }
        }

        protected void buttonArrowRight_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li1 in lbCampaign.Items)
            {
                if (li1.Selected)
                {
                    lbCampaignSelected.Items.Add(li1);
                }
            }

            foreach (ListItem li1 in lbCampaignSelected.Items)
            {
                if (li1.Selected)
                {
                    lbCampaign.Items.Remove(li1);
                }
            }
        }
    }
}
