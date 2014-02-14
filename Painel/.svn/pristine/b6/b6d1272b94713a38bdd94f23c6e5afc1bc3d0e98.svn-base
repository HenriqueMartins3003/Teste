<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportacaoHistorico.aspx.cs" Inherits="_webPainelVerisys.Mailing.ImportacaoHistorico" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportacaoHistorico" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportacaoHistorico" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Filtro de Pesquisa</b></div>
            
            <div class="ctn" id="divCampanha" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                        <br /><br />
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlCampaign_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblOperacao" CssClass="lb_Inside" Text="Operação :" runat="server"></asp:label>
                        <br /><br />
                        <asp:DropDownList ID="ddlTipoOperacao" runat="server" CssClass="form"></asp:DropDownList>
                    </div>
                    
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblPeriodo" CssClass="lb_Inside" Text="Período :" runat="server"></asp:label>
                        <br /><br />
                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form">
                            <asp:ListItem Value="1" Text="03 dias"></asp:ListItem>
                            <asp:ListItem Value="2" Text="07 dias"></asp:ListItem>
                            <asp:ListItem Value="3" Text="15 dias"></asp:ListItem>
                            <asp:ListItem Value="4" Text="30 dias"></asp:ListItem>
                            <asp:ListItem Value="5" Text="60 dias"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <br /><br />
                    <div class="ctnFormHorizontal" style="margin:0px;">
                        <asp:ImageButton ID="buttonImageFilter" runat="server" ImageUrl="~/img/btn-filtrar.gif" onclick="buttonImageFilter_Click" />
                    </div>
                    
                </div>
            </div>
            
        </div>
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divROContent visible="true" runat="server">

            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modListaRO" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Histórico</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaTipoRO" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="false"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="false"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="Campaign, Lot, Records, Description, DateTimeMH, User"
                                onrowdatabound="gdRegistros_RowDataBound" >
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                    
                </div>
            </div>
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>