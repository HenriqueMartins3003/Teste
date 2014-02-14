<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardReceptivo.aspx.cs" Inherits="_webPainelVerisys.Painel.DashBoardReceptivo" MasterPageFile="~/MP.Master" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="cph_INDEX" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmDashBoardReceptivo" runat="server">
<body>
<div class="containerInside">

    <asp:ScriptManager ID="ScriptManager1" runat="server"
        EnableScriptGlobalization="true" 
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
    <ContentTemplate>
    
    <!-- title -->
    <div class="titleContentInside">
        <asp:Label ID="lblTitulo" runat="server" text="Titulo"></asp:Label>
    </div>
    
    <!-- content -->
    <div class="contentInside">
    
        <asp:Panel ID="panelPanel" runat="server">
        
            <!-- filter -->
            <div class="titleFilter">Filtros</div>
            <div class="containerFilter">
                <div class="contentFilter">
                    <b>Campanhas</b>
                    <br />
                    <asp:DropDownList ID="ddlCampanhas" runat="server" CssClass="form" AutoPostBack="true" 
                            onselectedindexchanged="ddlCampanhas_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                
                <div class="contentFilter">
                    <b>Quadros</b>
                    <br />
                    <asp:CheckBox ID="cbTexto" runat="server" AutoPostBack="true" Checked="true" 
                        Text="&nbsp;Texto&nbsp;&nbsp;&nbsp;&nbsp;" 
                        oncheckedchanged="cbTexto_CheckedChanged" />&nbsp;
                    <br />
                    <asp:CheckBox ID="cbGrafico" runat="server" AutoPostBack="true" Checked="true" 
                        Text="&nbsp;Gráficos&nbsp;&nbsp;&nbsp;&nbsp;" 
                        oncheckedchanged="cbGrafico_CheckedChanged" />&nbsp;
                </div>
                
                <div class="contentView">
                    <b>Exibição</b> 
                    <asp:RadioButtonList ID="rbExibicaoDasInformacoesValores" runat="server" RepeatDirection="Horizontal" 
                        CssClass="form" AutoPostBack="true" 
                        onselectedindexchanged="rbExibicaoDasInformacoesValores_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="Absoluto &nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Percentual"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                
                <div class="clear"></div>
            </div>
            
            <!-- content option -->
            <div class="contentOptions">
                <b>Opções na tela:</b>&nbsp;<br />
                <asp:CheckBox ID="cb_ChamadasTotal" runat="server" 
                        Text="&nbsp;Chamadas (total do dia)&nbsp;&nbsp;&nbsp;&nbsp;" AutoPostBack="true" Checked="true" 
                        oncheckedchanged="cb_ChamadasTotal_CheckedChanged" />&nbsp;
                <asp:CheckBox ID="cb_ChamadasUltMin" runat="server"  AutoPostBack="true" Checked="true" 
                        Text="&nbsp;Chamadas (últimos 15 min.)&nbsp;&nbsp;&nbsp;&nbsp;" 
                        oncheckedchanged="cb_ChamadasUltMin_CheckedChanged" />&nbsp;
                <asp:CheckBox ID="cb_RO" runat="server" AutoPostBack="true" Checked="true" 
                        Text="&nbsp;Resultado da Operação" 
                        oncheckedchanged="cb_RO_CheckedChanged" />
            </div>
            
            <div style="text-align:center;"><small><asp:Label ID="lblDataHora" runat="server"></asp:Label></small></div>
            
            <!-- combos options -->
            <div class="containerBox" id="boxChamadasReceptivasDia" runat="server" visible="true">
                <div class="titleBox">Chamadas Receptivas (total do dia)</div>
            
                <div class="contentBox">
                    <asp:Label ID="lblMensagemChamadasReceptivasTotalDia" runat="server"></asp:Label>
            
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" runat="server" id="tblChamadasTotalDia" class="odd">
                        <thead>
                            <tr>
                                <td align="left" valign="middle" style="padding:3px 5px; width:80%; background:#CCC;"><b>Total</b></td>
                                <td align="right" valign="middle" style="padding:3px 5px; width:20%; background:#CCC;"><b><asp:Label ID="lblTotal_TotalDia" runat="server"></asp:Label></b></td>
                            </tr>
                        </thead>
                
                        <tbody>
                            <tr>
                                <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Atendidas</b></td>
                                <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblAtendidas_TotalDia" runat="server"></asp:Label></b></td>
                            </tr>
                            <tr>
                                <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Recebidas</b> <small></small></td>
                                <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblRecebidas_TotalDia" runat="server"></asp:Label></b></td>
                            </tr>
                        </tbody>
                    </table>
            
                </div>
            </div>
            
            <div class="containerBox" id="boxChamadasReceptivasDiaChart" runat="server">
                <div class="titleBox">Chamadas Receptivas (total do dia) - Gráfico</div>
                
                <div class="contentBox">
                    <asp:Label ID="lblMensagemChamadasReceptivasDiaChart" runat="server"></asp:Label>
            
                    <asp:Chart ID="ChamadasReceptivasDiaChart" runat=server>
                        <Series>
                            <asp:Series Name="SeriesChamadasReceptivasDiaChart" ChartType="Pie"></asp:Series>
                        </Series>
                        
                        <ChartAreas>
                            <asp:ChartArea Name="ChartAreaChamadasReceptivasDiaChart" Area3DStyle-Enable3D="True" />
                        </ChartAreas>
                    </asp:Chart>
            
                </div>
            </div>

















            
            <div class="containerBox" id="boxUltimasChamadasReceptivas" runat="server" visible = "true">
                <div class="titleBox">Chamadas Receptivas (últimos 15 min.)</div>
                    
                <div class="contentBox">
                    <asp:Label ID="lblMensagemChamadasReceptivas15Minutos" runat="server"></asp:Label>
                
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" runat="server" id="tblChamadasUltimos15Minutos" class="odd">
                        <thead>
                            <tr>
                                <td align="left" valign="middle" style="padding:3px 5px; width:80%; background:#CCC;"><b>Total</b></td>
                                <td align="right" valign="middle" style="padding:3px 5px; width:20%; background:#CCC;"><b><asp:Label ID="lblTotal_UltimosMinutos" runat="server"></asp:Label></b></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Atendidas</b></td>
                                <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblAtendidas_UltimosMinutos" runat="server"></asp:Label></b></td>
                            </tr>
                            <tr>
                                <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Recebidas</b> <small></small></td>
                                <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblRecebidas_UltimosMinutos" runat="server"></asp:Label></b></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            
            <div class="containerBox" id="boxUltimasChamadasReceptivasChart" runat="server">
                <div class="titleBox">Chamadas Receptivas (últimos 15 min.) - Gráfico</div>
                
                <div class="contentBox">
                    <asp:Label ID="lblMensagemUltimasChamadasReceptivasChart" runat="server"></asp:Label>
            
                    <asp:Chart ID="UltimasChamadasReceptivasChart" runat=server>
                        <Series>
                            <asp:Series Name="SeriesUltimasChamadasReceptivasChart" ChartType="Pie"></asp:Series>
                        </Series>
                        
                        <ChartAreas>
                            <asp:ChartArea Name="ChartAreaUltimasChamadasReceptivasChart" Area3DStyle-Enable3D="True" />
                        </ChartAreas>
                    </asp:Chart>
            
                </div>
            </div>
            
            <div class="containerBoxScroll" id="boxROReceptivo" runat="server" visible = "true">
                <div class="titleBox">Resultado da Operação</div>
                <div class="contentBoxScroll">
                    <asp:Label ID="lblMensagemResultadoOperacao" runat="server"></asp:Label>
                    
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="odd">
                        <thead>
                            <tr>
                                <td style="padding:3px 5px; width:80%; background:#CCC;" align="left" valign="middle">Total</td>
                                <td style="padding:3px 5px; width:20%; background:#CCC;" align="right" valign="middle"><asp:Label ID="lblTotalRO" runat="server"></asp:Label></td>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptRO" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><%# Eval("DescricaoRO") %></td>
                                    <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><%# Eval("TotalRO")%></td>
                                </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            
            <div class="clear"></div>
    
        </asp:Panel>
    
    </div>
    
    <asp:Timer ID="updater" runat="server" ontick="updater_Tick" Enabled="true" Interval="1000"></asp:Timer>
    
    </ContentTemplate>
    </asp:UpdatePanel>

</div>
</body>
            
</form>

</asp:Content>