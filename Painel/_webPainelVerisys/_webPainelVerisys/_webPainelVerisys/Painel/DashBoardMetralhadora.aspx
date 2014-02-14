<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardMetralhadora.aspx.cs" Inherits="_webPainelVerisys.Painel.DashBoardMetralhadora" MasterPageFile="~/MP.Master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="cph_DashBoardMetralhadora" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmDashBoardMetralhadora" runat="server">
<body>
<div class="containerInside">

    <asp:ScriptManager ID="ScriptManager1" runat="server"
        EnableScriptGlobalization="true" 
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
    <ContentTemplate>
    
    <script type="text/javascript">

        var popupWindow;

        function openw(url) 
        {
            popupWindow = window.open(url, '' , 'status=no,menubar=no,scrollbars=yes,resizable=no,toolbar=no');
            popupWindow.focus();
            popupWindow.moveTo(0, 0); 
            popupWindow.resizeTo(screen.availWidth, screen.availHeight);
        }

        function closew() {
            if (popupWindow) {
                popupWindow.close();
            }
        }    
    </script>
    
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
            <asp:CheckBox ID="cb_Mailing" runat="server" AutoPostBack="true" Checked="true" 
                    Text="&nbsp;Mailing&nbsp;&nbsp;&nbsp;&nbsp;" 
                    oncheckedchanged="cb_Mailing_CheckedChanged" />&nbsp;
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
            <div class="containerBox" id="boxMailingMetralhadora" runat="server" visible = "true">
            <div class="titleBox">Maling</div>
            <div class="contentBox">
            <asp:Label ID="lblMensagemMaling" runat="server"></asp:Label>
                
            <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblMailing" runat="server" class="odd">
            <thead>
            <tr>
              <td style="padding:3px 5px; width:80%; background:#CCC;" align="left" valign="middle"><b>Total</b></td>
              <td style="padding:3px 5px; width:20%; background:#CCC;" align="right" valign="middle"><b><asp:Label ID="lblTotal_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            </thead>
            <tbody>
            <tr>
              <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Livres</b></td>
              <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblLivres_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
              <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Discando</b> <small>(Inform. temporária)</small></td>
              <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblDiscando_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
              <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Atendida</b> <small>(Aguardando finalização)</small></td>
              <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblAtendida_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
              <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b><a id="actFinalizadosTotal" style="cursor:pointer;">Total finalizados</a></b></td>
              <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblFinalizadosTotal_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            <tr id="finalizados_Mailing">
              <td colspan="2">
                  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tbody>
                    <tr>
                      <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Aplicação</td>
                      <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblFinalizadosAplicacao_Mailing" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Excesso de tentativas</td>
                      <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblFinalizadosExcessoTentativas_Mailing" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Números inválidos</td>
                      <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblFinalizadosNumerosInvalidos_Mailing" runat="server"></asp:Label></td>
                    </tr>
                    </tbody>
                  </table>
              </td>
            </tr>
            <tr>
              <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Reagendados</b></td>
              <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblReagendados_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            <tr id="tr_Reagendados_Mailing">
              <td colspan="2">
                  <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tinterno">
                    <tbody style="background:#E8F3FF;">
                    <tr>
                      <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Discador</td>
                      <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblReagendadoDiscador_Mailing" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Front-End</td>
                      <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblReagendadoFrontEnd_Mailing" runat="server"></asp:Label></td>
                    </tr>
                    </tbody>
                  </table>
              </td>
            </tr>
            <tr>
              <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Números Proibidos</b></td>
              <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblNumerosProibidos_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
              <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Restrição Procon</b></td>
              <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblNumerosProcon_Mailing" runat="server"></asp:Label></b></td>
            </tr>
            </tbody>
            </table>
                
            </div>
            </div>
            
            <div class="containerBox" id="boxMailingChartMetralhadora" runat="server">
                <div class="titleBox">Maling - Gráfico</div>
                
                <div class="contentBox">
                    <asp:Label ID="lblMensagemMalingChart" runat="server"></asp:Label>
            
                    <asp:Chart ID="MailingChart" runat=server>
                        <Series>
                            <asp:Series Name="SeriesMailingChart" ChartType="Pie"></asp:Series>
                        </Series>
                        
                        <ChartAreas>
                            <asp:ChartArea Name="ChartAreaMailingChart" Area3DStyle-Enable3D="True" />
                        </ChartAreas>
                    </asp:Chart>
            
                </div>
            </div>
            
            <div class="containerBox" id="boxChamadasDiaMetralhadora" runat="server" visible="true">
            <div class="titleBox">Chamadas (total do dia)</div>
            <div class="contentBox">
            <asp:Label ID="lblMensagemChamadasTotalDia" runat="server"></asp:Label>
            
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
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Total de Canceladas</b> <small></small></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblCanceladas_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                <tr id="tr_Canceladas_TotalDia">
                  <td colspan="2">
                      <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Caixa Postal</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCanceladasCaixaPostal_TotalDia" runat="server"></asp:Label></td>
                        </tr>
                        
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Mensagem Operadora</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCanceladasOperadora_TotalDia" runat="server"></asp:Label></td>
                        </tr>
                      </table>
                  </td>
                </tr>
            
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Total de Congestionamentos</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblCongestionamento_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                <tr id="tr_Congestionamento_TotalDia">
                  <td colspan="2">
                      <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Central de destino</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCongestionamento_A4_TotalDia" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Central pública</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCongestionamento_CP_TotalDia" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Outros</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCongestionamento_Agente_TotalDia" runat="server"></asp:Label></td>
                        </tr>
                      </table>
                  </td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Total de Falhas</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblFalhaTotal_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                <tr id="tr_Falhas_TotalDia">
                  <td colspan="2">
                      <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Falha</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblFalha_TotalDia" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Por sinalização</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblFalhaPorSinalizacao_TotalDia" runat="server"></asp:Label></td>
                        </tr>
                      </table>
                  </td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>FAX</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblFax_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Não atendidas</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblNaoAtendidas_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Números inválidos</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblNumerosInvalidos_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Ocupados</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblOcupados_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Outros</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblTimeOut_TotalDia" runat="server"></asp:Label></b></td>
                </tr>
                </tbody>
            </table>
            
            </div>
            </div>
            
            <div class="containerBox" id="boxChamadasDiaChartMetralhadora" runat="server">
                <div class="titleBox">Chamadas (total do dia) - Gráfico</div>
                
                <div class="contentBox">
                    <asp:Label ID="lblMensagemChamadasDiaChart" runat="server"></asp:Label>
            
                    <asp:Chart ID="ChamadasDiaChart" runat=server>
                        <Series>
                            <asp:Series Name="SeriesChamadasDiaChart" ChartType="Pie"></asp:Series>
                        </Series>
                        
                        <ChartAreas>
                            <asp:ChartArea Name="ChartAreaChamadasDiaChart" Area3DStyle-Enable3D="True" />
                        </ChartAreas>
                    </asp:Chart>
            
                </div>
            </div>
            
            <div class="containerBox" id="boxUltimasChamadasMetralhadora" runat="server" visible = "true">
            <div class="titleBox">Chamadas (últimos 15 min.)</div>
            <div class="contentBox">
            
            <asp:Label ID="lblMensagemChamadas15Minutos" runat="server"></asp:Label>
                
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
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Total de Canceladas</b> <small></small></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblCanceladas_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                <tr id="tr1">
                  <td colspan="2">
                      <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Caixa Postal</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCanceladasCaixaPostal_UltimosMinutos" runat="server"></asp:Label></td>
                        </tr>
                        
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Mensagem Operadora</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCanceladasMensagem_UltimosMinutos" runat="server"></asp:Label></td>
                        </tr>
                      </table>
                  </td>
                </tr>
                
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Total de Congestionamentos</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblCongestionamento_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                <tr id="tr_Congest_UltimosMinutos">
                  <td colspan="2">
                      <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Central de destino</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCongestionamento_A4_UltimosMinutos" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Central pública</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCongestionamento_CP_UltimosMinutos" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Outros</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblCongestionamento_Agente_UltimosMinutos" runat="server"></asp:Label></td>
                        </tr>
                      </table>
                  </td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Total de Falhas</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblFalhaTotal_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                <tr id="tr_Falhas_UltimosMinutos">
                  <td colspan="2">
                      <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Falha</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblFalha_UltimosMinutos" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td style="padding:3px 5px; width:80%;" align="left" valign="middle">&nbsp;<img src="../img/tree.gif" alt="" style="margin-bottom:3px;" />&nbsp;Por sinalização</td>
                          <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><asp:Label ID="lblFalhaPorSinalizacao_UltimosMinutos" runat="server"></asp:Label></td>
                        </tr>
                      </table>
                  </td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>FAX</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblFax_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Não atendidas</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblNaoAtendidas_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Números inválidos</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblNumerosInvalidos_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Ocupados</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblOcupados_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                  <td style="padding:3px 5px; width:80%;" align="left" valign="middle"><b>Outros</b></td>
                  <td style="padding:3px 5px; width:20%;" align="right" valign="middle"><b><asp:Label ID="lblTimeOut_UltimosMinutos" runat="server"></asp:Label></b></td>
                </tr>
                </tbody>
            </table>
            
            </div>
            </div>
            
            <div class="containerBox" id="boxUltimasChamadasChartMetralhadora" runat="server">
                <div class="titleBox">Chamadas (últimos 15 min.) - Gráfico</div>
                
                <div class="contentBox">
                    <asp:Label ID="lblMensagemUltimasChamadasChart" runat="server"></asp:Label>
            
                    <asp:Chart ID="UltimasChamadasChart" runat=server>
                        <Series>
                            <asp:Series Name="SeriesUltimasChamadasChart" ChartType="Pie"></asp:Series>
                        </Series>
                        
                        <ChartAreas>
                            <asp:ChartArea Name="ChartAreaUltimasChamadasChart" Area3DStyle-Enable3D="True" />
                        </ChartAreas>
                    </asp:Chart>
            
                </div>
            </div>
            
            <div class="containerBoxScroll" id="boxROMetralhadora" runat="server" visible = "true">
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