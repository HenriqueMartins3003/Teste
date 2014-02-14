<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard_Affinity.aspx.cs" Inherits="_webPainelVerisys.Painel.DashBoard_Affinity" MasterPageFile="~/MP.Master" %>

<asp:Content ID="cph_INDEX" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmDashBoard_Affinity" runat="server">
<div class="containerInside">

    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="true" 
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <!-- title -->
    <div class="titleContentInside">Painel Vendas de Seguro - Affinity</div>
    
    <!-- content -->
    <div class="contentInside">
    
        <asp:Panel ID="panelPanel" runat="server">
        
            <!-- filter -->
            <div class="titleFilter">Filtros</div>
            
            <div class="containerFilter">
                <div class="contentFilter">
                    Campanhas
                    <br />
                    <asp:DropDownList ID="ddlCampanhas" runat="server" CssClass="form" 
                        AutoPostBack="true" onselectedindexchanged="ddlCampanhas_SelectedIndexChanged" >
                    </asp:DropDownList>
                </div>
                
                <div class="clear"></div>
            </div>
            
            <!-- content option -->
            <div class="contentOptions">
            
                <b>Opções na tela:</b>&nbsp;
                <asp:CheckBox ID="cbVendas" runat="server" AutoPostBack="true" Checked="true" 
                    Text="&nbsp;Vendas&nbsp;&nbsp;&nbsp;&nbsp;" 
                    oncheckedchanged="cbVendas_CheckedChanged" />&nbsp;
                <asp:CheckBox ID="cbVendasOperador" runat="server" 
                    Text="&nbsp;Vendas por Operador&nbsp;&nbsp;&nbsp;&nbsp;" AutoPostBack="true" 
                    Checked="true" oncheckedchanged="cbVendasOperador_CheckedChanged" />&nbsp;
                <asp:CheckBox ID="cbVendasOperador_15minutos" runat="server" 
                    Text="&nbsp;Vendas por Operador (15minutos)&nbsp;&nbsp;&nbsp;&nbsp;" 
                    AutoPostBack="true" Checked="true" 
                    oncheckedchanged="cbVendasOperador_15minutos_CheckedChanged" />&nbsp;

            </div>
            
            <div style="text-align:center;"><small><asp:Label ID="lblDataHora" runat="server"></asp:Label></small></div>
            
            <!-- combos options -->
            <div class="containerBoxBig" id="boxVendasAffinity" runat="server">
                <div class="titleBox">Vendas</div>
                <div class="contentBoxScroll">
                    <asp:Label ID="lblMensagemVendas" runat="server" visible="false"></asp:Label>

                    <div id="ctnListaVendas" runat="server">
                        <asp:GridView ID="gdVendas" runat="server" 
                                AllowSorting="False"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="False"
                                PageSize="1"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="DATA, LOGIN, NOMEAGENTE, PROPOSTA, CPF, VALOR, CAMPANHA" 
                            onrowdatabound="gdVendas_RowDataBound"  >
                        </asp:GridView>
                    </div>

                </div>
            </div>
            
            <div class="containerBox" id="boxVendasAffinityOperador" runat="server">
                <div class="titleBox">Vendas por Operador</div>
                <div class="contentBoxScroll">
                    <asp:Label ID="lblMensagemVendasOperador" runat="server" visible="false"></asp:Label>
                    
                    <div id="ctnListaVendasOperador" runat="server">
                        <asp:GridView ID="gdVendasOperador" runat="server" 
                                AllowSorting="False"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="False"
                                PageSize="1"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="QTDE, LOGIN, NOMEAGENTE, CAMPANHA" 
                            onrowdatabound="gdVendasOperador_RowDataBound"  >
                        </asp:GridView>
                    </div>
                    
                </div>
            </div>
            
            <div class="containerBox" id="boxVendasAffinityOperador_15minutos" runat="server">
                <div class="titleBox">Vendas por Operador (15minutos)</div>
                <div class="contentBoxScroll">
                    <asp:Label ID="lblMensagemVendasOperador15minutos" runat="server" visible="false"></asp:Label>
                    
                    <div id="ctnListaVendasOperador_15minutos" runat="server">
                        <asp:GridView ID="gdVendasOperador_15minutos" runat="server" 
                                AllowSorting="False"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="False"
                                PageSize="1"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="QTDE, LOGIN, NOMEAGENTE, CAMPANHA" 
                            onrowdatabound="gdVendasOperador_15minutos_RowDataBound" >
                        </asp:GridView>
                    </div>

                </div>
            </div>
            
            <div class="clear"></div>
    
        </asp:Panel>
    
    </div>
    
    <asp:Timer ID="updater" runat="server" ontick="updater_Tick" Enabled="true" Interval="1000"></asp:Timer>
    
    </ContentTemplate>
    </asp:UpdatePanel>

</div>
</form>

</asp:Content>