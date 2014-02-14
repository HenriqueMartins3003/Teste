<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PriorizacaoMailing.aspx.cs" Inherits="_webPainelVerisys.Tribanco.PriorizacaoMailing" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportacaoLotes" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmPriorizacaoMailing" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Priorizacao de Mailings</div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Campanhas</b></div>
            
            <div class="ctn" id="divCampanha" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlCampaign_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                
                </div>
            </div>
            
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div class="ctn" id="modLista" runat="server" visible="false">
                <!-- title[1] -->
                <div class="cttTitle"><b>Opções de Priorização</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="CAMPANHA, REGRADISTRIBUICAO, PRIORIDADE, DATAHORA"
                                onrowcommand="gdRegistros_RowCommand"
                                onsorting="gdRegistros_Sorting"
                                onpageindexchanging="gdRegistros_PageIndexChanging" 
                            onrowdatabound="gdRegistros_RowDataBound" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>

            <!-- RO -->
            <div class="ctn" id="modManutencao" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Alteração de Priorizacao de Mailing"></asp:Label></b>
                        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label></b>
                    </div>

                    <div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>

                    <div class="clear"></div>

                </div>

                <!-- content -->
                <div id="Div2" class="ctt" runat="server">

                    <asp:Label ID="lblIDCampanha" runat="server" class="lb_TB" Text="Campanha" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtIDCampanha" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                    <br />

                    <asp:Label ID="lblRegra" runat="server" class="lb_TB" Text="Regra" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtRegra" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                    <br />

                    <asp:Label ID="lblPrioridade" runat="server" class="lb_TB" Text="Prioridade" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtPrioridade" runat="server" CssClass="form" ></asp:TextBox>
                    
                </div>

                <br /><br />
                <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-salvar.gif" OnClick="Manager_Click"/>&nbsp;
                <asp:ImageButton ID="buttonImageLimpar" runat="server" ImageUrl="~/img/btn-limpar.gif" OnClick="buttonImageLimpar_Click"/>
                
            </div>
            
            <div class="ctn" id="modExecucao" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="Label1" runat="server" Text="Execução de Priorizacao de Mailing"></asp:Label></b>
                    </div>

                    <div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>

                    <div class="clear"></div>

                </div>

                <br /><br />
                <asp:ImageButton ID="buttonImageFiltrar" runat="server" ImageUrl="~/img/btn-filtrar.gif" OnClick="ManagerFiltrar_Click"/>&nbsp;
                
            </div>
            
            
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>