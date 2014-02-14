﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;
using clsTools;


namespace _webPainelVerisys.ImportExport
{
    public partial class Rules : System.Web.UI.Page
    {
        dtoUsers objUsers = null;
        UsersProfiles objUsersProfiles = new UsersProfiles();
        bllImportExport objImportExport = new bllImportExport();
        Validadores objValidadores = new Validadores();
        Campaigns objCampaing = new Campaigns();
        string campanhas = "";

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
                listaCampanhas();
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


        protected void gdRegistros_Lista()
        {
            gdRegistros.AutoGenerateColumns = false;
            gdRegistros.Columns.Clear();

            // Botoes
            ButtonField btnUpdate = new ButtonField();
            btnUpdate.ButtonType = ButtonType.Image;
            btnUpdate.ImageUrl = "../img/edit.gif";
            btnUpdate.CommandName = "Upd";
            btnUpdate.ItemStyle.Width = 25;
            btnUpdate.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            btnUpdate.HeaderText = "";
            btnUpdate.HeaderStyle.CssClass = "gridViewHeader";
            btnUpdate.Visible = true;
            gdRegistros.Columns.Add(btnUpdate);

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
            BoundField bfRulesID = new BoundField();
            bfRulesID.DataField = "RulesID";
            bfRulesID.HeaderText = "RulesID";
            bfRulesID.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesID.ItemStyle.CssClass = "gridViewValues3";
            bfRulesID.ItemStyle.Width = 50;
            bfRulesID.Visible = false;
            bfRulesID.SortExpression = "RulesID";
            gdRegistros.Columns.Add(bfRulesID);

            BoundField bfRulesName = new BoundField();
            bfRulesName.DataField = "RulesName";
            bfRulesName.HeaderText = "Nome";
            bfRulesName.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesName.ItemStyle.CssClass = "gridViewValues3";
            bfRulesName.ItemStyle.Width = 50;
            bfRulesName.Visible = true;
            bfRulesName.SortExpression = "RulesName";
            gdRegistros.Columns.Add(bfRulesName);

            BoundField bfCampaign = new BoundField();
            bfCampaign.DataField = "Campaign";
            bfCampaign.HeaderText = "Campanha";
            bfCampaign.HeaderStyle.CssClass = "gridViewHeader1";
            bfCampaign.ItemStyle.CssClass = "gridViewValues3";
            bfCampaign.ItemStyle.Width = 50;
            bfCampaign.Visible = true;
            bfCampaign.SortExpression = "Campaign";
            gdRegistros.Columns.Add(bfCampaign);

            BoundField bfLotStatus = new BoundField();
            bfLotStatus.DataField = "LotStatus";
            bfLotStatus.HeaderText = "LotStatus";
            bfLotStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfLotStatus.ItemStyle.CssClass = "gridViewValues3";
            bfLotStatus.ItemStyle.Width = 50;
            bfLotStatus.Visible = false;
            bfLotStatus.SortExpression = "LotStatus";
            gdRegistros.Columns.Add(bfLotStatus);

            BoundField bfLotStatusDescription = new BoundField();
            bfLotStatusDescription.DataField = "LotStatusDescription";
            bfLotStatusDescription.HeaderText = "Lote";
            bfLotStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfLotStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfLotStatusDescription.ItemStyle.Width = 50;
            bfLotStatusDescription.Visible = true;
            bfLotStatusDescription.SortExpression = "LotStatusDescription";
            gdRegistros.Columns.Add(bfLotStatusDescription);

            BoundField bfRegistryStatus = new BoundField();
            bfRegistryStatus.DataField = "RegistryStatus";
            bfRegistryStatus.HeaderText = "RegistryStatus";
            bfRegistryStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryStatus.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryStatus.ItemStyle.Width = 50;
            bfRegistryStatus.Visible = false;
            bfRegistryStatus.SortExpression = "RegistryStatus";
            gdRegistros.Columns.Add(bfRegistryStatus);

            BoundField bfRegistryStatusDescription = new BoundField();
            bfRegistryStatusDescription.DataField = "RegistryStatusDescription";
            bfRegistryStatusDescription.HeaderText = "Registro";
            bfRegistryStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfRegistryStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfRegistryStatusDescription.ItemStyle.Width = 50;
            bfRegistryStatusDescription.Visible = true;
            bfRegistryStatusDescription.SortExpression = "RegistryStatusDescription";
            gdRegistros.Columns.Add(bfRegistryStatusDescription);

            BoundField bfCheckRaw = new BoundField();
            bfCheckRaw.DataField = "CheckRaw";
            bfCheckRaw.HeaderText = "CheckRaw";
            bfCheckRaw.HeaderStyle.CssClass = "gridViewHeader1";
            bfCheckRaw.ItemStyle.CssClass = "gridViewValues3";
            bfCheckRaw.ItemStyle.Width = 50;
            bfCheckRaw.Visible = false;
            bfCheckRaw.SortExpression = "CheckRaw";
            gdRegistros.Columns.Add(bfCheckRaw);

            BoundField bfCheckRawDescription = new BoundField();
            bfCheckRawDescription.DataField = "CheckRawDescription";
            bfCheckRawDescription.HeaderText = "Arquivo?";
            bfCheckRawDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfCheckRawDescription.ItemStyle.CssClass = "gridViewValues3";
            bfCheckRawDescription.ItemStyle.Width = 50;
            bfCheckRawDescription.Visible = true;
            bfCheckRawDescription.SortExpression = "CheckRawDescription";
            gdRegistros.Columns.Add(bfCheckRawDescription);


          
            BoundField bfRulesStatus = new BoundField();
            bfRulesStatus.DataField = "RulesStatus";
            bfRulesStatus.HeaderText = "RulesStatus";
            bfRulesStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesStatus.ItemStyle.CssClass = "gridViewValues3";
            bfRulesStatus.ItemStyle.Width = 50;
            bfRulesStatus.Visible = false;
            bfRulesStatus.SortExpression = "RulesStatus";
            gdRegistros.Columns.Add(bfRulesStatus);

            BoundField bfRulesStatusDescription = new BoundField();
            bfRulesStatusDescription.DataField = "RulesStatusDescription";
            bfRulesStatusDescription.HeaderText = "Ativo?";
            bfRulesStatusDescription.HeaderStyle.CssClass = "gridViewHeader1";
            bfRulesStatusDescription.ItemStyle.CssClass = "gridViewValues3";
            bfRulesStatusDescription.ItemStyle.Width = 50;
            bfRulesStatusDescription.Visible = true;
            bfRulesStatusDescription.SortExpression = "RulesStatusDescription";
            gdRegistros.Columns.Add(bfRulesStatusDescription);

            BoundField bfOldLotStatus = new BoundField();
            bfOldLotStatus.DataField = "OldLotStatusDecription";
            bfOldLotStatus.HeaderText = "Desabilitar lote";
            bfOldLotStatus.HeaderStyle.CssClass = "gridViewHeader1";
            bfOldLotStatus.ItemStyle.CssClass = "gridViewValues3";
            bfOldLotStatus.ItemStyle.Width = 50;
            bfOldLotStatus.Visible = true;
            bfOldLotStatus.SortExpression = "OldLotStatusDecription";
            gdRegistros.Columns.Add(bfOldLotStatus);
           
            gdRegistros.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gdRegistros.PagerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            gdRegistros.FooterStyle.CssClass = "gridViewHeader";

            DataSet dsQuery = objImportExport.UINT_LISTRULES(objUsers);
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

        //lista campanhas
        private void listaCampanhas()
        {
            lstCampaign.DataSource = objCampaing.listCampaignAssociated(objUsers);
            lstCampaign.DataTextField = "NomeCampanha";
            lstCampaign.DataValueField = "campaign";
            lstCampaign.DataBind();
        }

       

        protected void gdRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                divResponse.Visible = false;
                modManutencao.Visible = true;
                modExcluir.Visible = false;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Alteração";
                lblID.Text = gdRegistros.DataKeys[index]["RulesID"].ToString();

                txtRulesName.Text = gdRegistros.DataKeys[index]["RulesName"].ToString();
                lstCampaign.SelectedValue = gdRegistros.DataKeys[index]["Campaign"].ToString();
                ddlLotStatus.SelectedValue = gdRegistros.DataKeys[index]["LotStatus"].ToString();
                ddlRegistryStatus.SelectedValue = gdRegistros.DataKeys[index]["RegistryStatus"].ToString();
                ddlCheckRaw.SelectedValue = gdRegistros.DataKeys[index]["CheckRaw"].ToString();
                ddlRulesStatus.SelectedValue = gdRegistros.DataKeys[index]["RulesStatus"].ToString();
                ddlOldLotStatus.SelectedValue = gdRegistros.DataKeys[index]["OldLotStatus"].ToString();


                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.ALTERACAO, Convert.ToInt32(objUsers.IdProfile));
            }

            if (e.CommandName == "Del")
            {
                divResponse.Visible = false;
                modManutencao.Visible = false;
                modExcluir.Visible = true;

                int index = int.Parse((string)e.CommandArgument);
                lblTituloDiv.Text = "Exclusão";
                lblID.Text = gdRegistros.DataKeys[index]["RulesID"].ToString();
                lblExclusao.Text = gdRegistros.DataKeys[index]["RulesName"].ToString();

                objUsersProfiles.AcessProfileButton(buttonImageSalvar, "~/img/btn-salvar-disable.gif", this.Form.ID, dtoUsersProfiles.AccessType.EXCLUSAO, Convert.ToInt32(objUsers.IdProfile));
            }
        }

        protected void gdRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet dsRegistros = objImportExport.UINT_LISTRULES(objUsers);
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

        protected void Cadastro()
        {
            try
            {
                //if (txtHeaderName.Text == String.Empty)
                //{
                //    divResponse.Visible = true;
                //    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                //    return;
                //}

                //if ((txtHeaderInitialLine.Text == String.Empty) || (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                //{
                //    divResponse.Visible = true;
                //    lblResponse.Text = "<div class='RNOK'>O Campo <b>Linha</b> deve ser numerico e não pode ficar em Branco !! </div>";
                //    return;
                //}

                //if (txtHeaderSeparator.Text == String.Empty)
                //{
                //    if ((txtHeaderLineSize.Text == String.Empty) && (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                //    {
                //        divResponse.Visible = true;
                //        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                //        return;
                //    }
                //}

                dtoImportExport_Rules dtoAux = new dtoImportExport_Rules();
                dtoAux.Task = 1;
                dtoAux.RulesName = txtRulesName.Text;

                foreach (ListItem _listCampaign in lstCampaign.Items)
                {
                    dtoAux.Campaign = dtoAux.Campaign + ";" + _listCampaign.Value;
                }
                dtoAux.Campaign = dtoAux.Campaign.Substring(1, dtoAux.Campaign.Length - 1);
                dtoAux.LotStatus = Convert.ToBoolean(ddlLotStatus.SelectedValue.ToString());
                dtoAux.RegistryStatus = Convert.ToBoolean(ddlRegistryStatus.SelectedValue.ToString());
                dtoAux.CheckRaw = Convert.ToBoolean(ddlCheckRaw.SelectedValue.ToString());
                dtoAux.RulesStatus = Convert.ToBoolean(ddlRulesStatus.SelectedValue.ToString());
                dtoAux.OldLotStatus = Convert.ToBoolean(ddlOldLotStatus.SelectedValue.ToString());

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULES(dtoAux, objUsers);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante o Cadastro do Registro !! </div>" + eCadastro;
                divResponse.Visible = true;
            }
        }

        protected void Alteracao()
        {
            try
            {
                //if (txtHeaderName.Text == String.Empty)
                //{
                //    divResponse.Visible = true;
                //    lblResponse.Text = "<div class='RNOK'>O Campo <b>Nome</b> não pode ficar em Branco !! </div>";
                //    return;
                //}

                //if ((txtHeaderInitialLine.Text == String.Empty) || (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                //{
                //    divResponse.Visible = true;
                //    lblResponse.Text = "<div class='RNOK'>O Campo <b>Linha</b> deve ser numerico e não pode ficar em Branco !! </div>";
                //    return;
                //}

                //if (txtHeaderSeparator.Text == String.Empty)
                //{
                //    if ((txtHeaderLineSize.Text == String.Empty) && (!objValidadores.isNumero(txtHeaderInitialLine.Text)))
                //    {
                //        divResponse.Visible = true;
                //        lblResponse.Text = "<div class='RNOK'>O Campo <b>Tamanho</b> deve ser numerico e não pode ficar em Branco !! </div>";
                //        return;
                //    }
                //}

                dtoImportExport_Rules dtoAux = new dtoImportExport_Rules();
                dtoAux.Task = 2;
                dtoAux.RulesID = Convert.ToInt64(lblID.Text);
                dtoAux.RulesName = txtRulesName.Text;
                foreach (ListItem _listCampaign in lstCampaign.Items)
                {
                    dtoAux.Campaign = dtoAux.Campaign + ";" + _listCampaign.Value;
                }
                dtoAux.Campaign = dtoAux.Campaign.Substring(1, dtoAux.Campaign.Length - 1);
                dtoAux.LotStatus = Convert.ToBoolean(ddlLotStatus.SelectedValue.ToString());
                dtoAux.RegistryStatus = Convert.ToBoolean(ddlRegistryStatus.SelectedValue.ToString());
                dtoAux.CheckRaw = Convert.ToBoolean(ddlCheckRaw.SelectedValue.ToString());
                dtoAux.RulesStatus = Convert.ToBoolean(ddlRulesStatus.SelectedValue.ToString());
                dtoAux.OldLotStatus = Convert.ToBoolean(ddlOldLotStatus.SelectedValue.ToString());

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULES(dtoAux, objUsers);
                if (dtoResponse.ResultCode == 0)
                {
                    lblResponse.Text = "<div class='ROK'> Registro Alterado com sucesso !!</div>";
                    divResponse.Visible = true;
                }
                else
                {
                    lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Registro !! </div>";
                    divResponse.Visible = true;
                }
            }
            catch (Exception eAlteracao)
            {
                divResponse.Visible = true;
                lblResponse.Text = "<div class='RNOK'> Erro durante a Alteração do Registro !! </div>" + eAlteracao;
            }
        }

        protected void Exclusao()
        {
            try
            {
                dtoImportExport_Rules dtoAux = new dtoImportExport_Rules();
                dtoAux.Task = 3;
                dtoAux.RulesID = Convert.ToInt32(lblID.Text);

                dtoResponse dtoResponse = objImportExport.UINT_MANAGER_RULES(dtoAux, objUsers);
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
                lblResponse.Text = "<div class='RNOK'> Erro durante a Exclusão do Registro !! </div>" + eExclusao;
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
                lblID.Text = "";
                txtRulesName.Text = "";
                lstCampaign.SelectedValue = "";
                ddlLotStatus.SelectedValue = "0";
                ddlRegistryStatus.SelectedValue = "0";
                ddlCheckRaw.SelectedValue = "0";
                ddlRulesStatus.SelectedValue = "";
                ddlOldLotStatus.SelectedValue = "";

            }
            catch
            {

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

                //Coluna 3
                oTableCell = new TableCell();
                oTableCell.Text = "Valida";
                oTableCell.ColumnSpan = 1;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);


                //Coluna 5
                oTableCell = new TableCell();
                oTableCell.Text = "";
                oTableCell.ColumnSpan = 2;
                oTableCell.CssClass = "gridViewHeader1";
                oGridViewRow.Cells.Add(oTableCell);
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
            }
        }
    }
}
