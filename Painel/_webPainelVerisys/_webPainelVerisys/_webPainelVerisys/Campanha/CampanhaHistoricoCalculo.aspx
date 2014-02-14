<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaHistoricoCalculo.aspx.cs" Inherits="_webPainelVerisys.Campanha.CampanhaHistoricoCalculo" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_CampanhaHistoricoCalculo" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmCampanhaHistoricoCalculo" runat="server">
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
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" ></asp:DropDownList>
                    </div>
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblPeriodo" CssClass="lb_Inside" Text="Período :" runat="server"></asp:label>
                        <br /><br />
                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form">
                            <asp:ListItem Value="1" Text="última 01 hora"></asp:ListItem>
                            <asp:ListItem Value="2" Text="últimas 02 horas"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Dia Corrente"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <br /><br />
                    <div class="ctnFormHorizontal" style="margin:0px;">
                        <asp:ImageButton ID="buttonImageFilter" runat="server" 
                            ImageUrl="~/img/btn-filtrar.gif" onclick="buttonImageFilter_Click" />
                    </div>
                    
                </div>
            </div>
            
        </div>
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divROContent visible="false" runat="server">



            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modListaRO" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Histórico</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <asp:GridView ID="gdRegistros" runat="server" 
                            AllowSorting="True"
                            GridLines="None"
                            CellPadding="4"
                            AllowPaging="True"
                            PageSize="60"
                            AlternatingRowStyle-HorizontalAlign="Left"
                            DataKeyNames="LCAM_TMAA, LCAM_DPAA, LCAM_PAA, LCAM_TMCB, LCAM_DPCB, LCAM_AA, LCAM_AC, LCAM_CA, LCAM_TL, LCAM_DH, LCAM_DIA, LCAM_DFA, LCEV_TMC, LCEV_TMEC"
                            onsorting="gdRegistros_Sorting"
                            onpageindexchanging="gdRegistros_PageIndexChanging" 
                        onrowdatabound="gdRegistros_RowDataBound" >
                        <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                        <AlternatingRowStyle></AlternatingRowStyle>
                    </asp:GridView>
                    
                </div>

            </div>
            
            <div class="ctn" id="modLegenda" runat="server" visible="true">
            
                <p><b>Legendas : </b></p>
                <small>
                    <asp:Label runat="server" text="TMAA" width="60px"><b>TMR</b></asp:Label>: Tempo Médio de Ring (em Segundos)<br />
                    <asp:Label runat="server" text="TMAA" width="60px"><b>PAA</b></asp:Label>: Percentual de Atendimento Cliente (em Porcentagem)<br />
                    <asp:Label runat="server" text="TMAA" width="60px"><b>TMCB</b></asp:Label>: Tempo Médio de Conversação (em Segundos)<br />
                    <asp:Label runat="server" text="TMAA" width="60px"><b>TL</b></asp:Label>: Total de Ligações no periodo de Análise (10 minutos)(em Volume de dados)<br />
                    <asp:Label runat="server" text="TMAA" width="60px"><b>CLERICAL</b></asp:Label>: Tempo Médio de Clerical (em Segundos)<br />
                    <asp:Label runat="server" text="TMAA" width="60px"><b>TMEC</b></asp:Label>: Tempo Médio entre Chamadas (em Segundos)<br />
                </small>
            
            </div>
            
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
</form>
</asp:Content>