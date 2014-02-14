<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegmentacaoProcesso.aspx.cs" Inherits="_webPainelVerisys.Mailing.SegmentacaoProcesso" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_SegmentacaoProcesso" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmSegmentacaoProcesso" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside" id=divCampanhaContent visible="false" runat="server">
            <div class="ctn" id="divCampanha" runat="server">
                <div class="cttTitle"><b>Seleção de Base de Mailing</b></div>
                <div class="ctt">
                    <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" onselectedindexchanged="ddlCampaign_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
        </div>
        
        <br />
        <div class="contentInside" id=divSegmentacaoContent visible="true" runat="server">
            <div class="ctn" id="divSegmentacao" runat="server">
                <div class="cttTitle"><b>Segmentações</b></div>
                <div class="ctt">
                    <asp:label ID="Label4" CssClass="lb_Inside" Text="Segmentação" runat="server" Width="150px"></asp:label>
                    <asp:DropDownList ID="ddlSegmentacao" runat="server" CssClass="form" 
                        AutoPostBack="true" Width="300px" onselectedindexchanged="ddlSegmentacao_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
            <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="false" runat="server">

            <div class="ctn" id="modLista" runat="server" visible="false">
                <!-- title[1] -->
                <div class="cttTitle"><b>Segmentação</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="Div2" runat="server">
                        <asp:GridView ID="gdSegmentacao" runat="server" 
                                AllowSorting="false"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="false"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="ID_SEGMENTACAO, NOME_SEGMENTACAO, NUMERO_CAMPANHA, NUMERO_LOTE, PRIORIDADE, IDFLAG, FLAG_ATIVO" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>

                </div>
            </div>
            
            <div class="ctn" id="modRegra" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Regras Cadastradas</b></div>
                <div class="ctt">
                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="false"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="false"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="ID_SEGMENTACAOREGRA, CAMPO_SEGMENTACAO, REGRA_SEGMENTACAO, VALOR_SEGMENTACAO, TABELA_SEGMENTACAO"
                                onrowdatabound="gdRegistros_RowDataBound" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            

            <br />
            <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-filtrar.gif" OnClick="Manager_Click"/>&nbsp;
            <asp:ImageButton ID="buttonImageLimpar" runat="server" ImageUrl="~/img/btn-limpar.gif" OnClick="buttonImageLimpar_Click"/>
                        
        </div>

    </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</div>
</form>
</asp:Content>