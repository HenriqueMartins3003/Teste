<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportacaoLotes.aspx.cs" Inherits="_webPainelVerisys.Mailing.ImportacaoLotes" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportacaoLotes" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportacaoLotes" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

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

            <div class="ctn" id="modListaLotes" runat="server" visible="false">
                <!-- title[1] -->
                <div class="cttTitle"><b>Lotes</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaLotes" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="Lot, LotActivity, Records, DateTimeMH"
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
            <div class="ctn" id="modManutencaoLotes" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Gerenciamento de Lote"></asp:Label></b>
                        <asp:Label ID="lblIDLote" runat="server" Text="" Visible="false"></asp:Label></b>
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

                    <center>
                    <asp:Label ID="lblMessageActivate" runat="server"></asp:Label>
                    <br /><br />
                    <asp:RadioButtonList ID="rblAtivarDesativar" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Text="&nbsp;Ativar&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="0" Text="&nbsp;Desativar"></asp:ListItem>
                    </asp:RadioButtonList>
                    </center>
                </div>

                <br /><br />
                <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-salvar.gif" OnClick="Manager_Click"/>&nbsp;
                <asp:ImageButton ID="buttonImageLimpar" runat="server" ImageUrl="~/img/btn-limpar.gif" OnClick="buttonImageLimpar_Click"/>
                
            </div>
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>