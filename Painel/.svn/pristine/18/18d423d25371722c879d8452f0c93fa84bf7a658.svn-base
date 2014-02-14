<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportacaoIdentificadoresLotes.aspx.cs" Inherits="_webPainelVerisys.Mailing.ImportacaoIdentificadoresLotes" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportacaoIdentificadoresLotes" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportacaoIdentificadoresLotes" runat="server">
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
                        <asp:label ID="lblLote" CssClass="lb_Inside" Text="Lote :" runat="server"></asp:label>
                        <br /><br />
                        <asp:DropDownList ID="ddlLote" runat="server" CssClass="form"></asp:DropDownList>
                    </div>
                    
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblCampo" CssClass="lb_Inside" Text="Campo :" runat="server"></asp:label>
                        <br /><br />
                        <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form"></asp:DropDownList>
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
                                DataKeyNames="ITEM, QTDE"
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