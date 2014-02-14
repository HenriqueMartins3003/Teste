<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardEstatisticas.aspx.cs" Inherits="_webPainelVerisys.Painel.DashBoardEstatisticas" MasterPageFile="~/MP.Master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="cph_DashBoardEstatisticas" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmDashBoardEstatisticas" runat="server">
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
                        <asp:DropDownList ID="ddlCampanhas" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlCampanhas_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </div>
                    
                    <div class="contentView">
                        <b>Exibição</b> 
                        <asp:RadioButtonList ID="rbExibicaoDasInformacoesValores" runat="server" 
                            RepeatDirection="Horizontal" CssClass="form" AutoPostBack="true" 
                            onselectedindexchanged="rbExibicaoDasInformacoesValores_SelectedIndexChanged">
                            <asp:ListItem Value="1" Text="Absoluto &nbsp;" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Percentual"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                
                    <br /><br />
                    

                
                
                
                    <div class="clear"></div>
                    
                </div>
                
                <div style="text-align:center;"><small><asp:Label ID="lblDataHora" runat="server"></asp:Label></small></div>
            
                <!-- combos options -->
                <div class="containerBoxBig" id="boxEstatisticaAssertividade" runat="server" visible = "true">
                    <div class="titleBox">Assertividade no Atendimento por Tipo de Resultado Operacional</div>
                    <div class="contentBoxBig">
                        <asp:Label ID="lblMensagemAssertividade" runat="server"></asp:Label>
                        
                        <div id="divRO" class="contentBoxListsContentL" runat="server" style="width:720px; border:solid 0px">
                        
                            <small><asp:Label ID=Label1 Text="(Para selecionar mais de uma opção faça a seleção com a tecla Crtl de seu teclado pressionada)" runat="server" /></small>
                            <br /><br />
                            
                            <div id="Div1" class="contentBoxLists" runat="server" style="width:320px;">
                                <div class="titleBox">ROs Cadastrados</div>
                                <asp:ListBox ID="lbRO" runat="server" CssClass="formInsideMultiline" Width="100%" SelectionMode="Multiple" Rows="5"></asp:ListBox>
                            </div>
                        
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="buttonArrowLeft" runat="server" ImageUrl="~/img/arrow-left.gif" onclick="buttonArrowLeft_Click" />
                            &nbsp;&nbsp;
                            <asp:ImageButton ID="buttonArrowRight" runat="server" ImageUrl="~/img/arrow-right.gif" onclick="buttonArrowRight_Click" />
                            &nbsp;&nbsp;
                        
                            <div id="Div2" class="contentBoxLists2" runat="server" style="width:320px;">
                                <div class="titleBox">ROs Selecionados</div>
                                <asp:ListBox ID="lbROSelected" runat="server" CssClass="formInsideMultiline" Width="100%" SelectionMode="Multiple" Rows="5"></asp:ListBox>
                            </div>
                    
                        </div>
                        
                        <br />
                        <center>
                            <asp:Label ID=Label2 Text="Itens" runat="server"></asp:Label>
                            <br />
                            <asp:CheckBox id="cbAssertividadeFone1" runat="server" checked="true" text="Fone1&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeFone2" runat="server" checked="true" text="Fone2&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeFone3" runat="server" checked="true" text="Fone3&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeFone4" runat="server" checked="true" text="Fone4&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeFone5" runat="server" checked="true" text="Fone5&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeFone_CheckedChanged"></asp:CheckBox>
                        </center>
                        <br />
                        
                        <asp:Chart id="ChartAssertividade" runat="server" Width="700px" Height="370px"></asp:Chart>
                       
                    </div>
                </div>
                
                <div class="containerBoxBig" id="boxEstatisticaAssertividadeTotal" runat="server" visible = "true">
                    <div class="titleBox">Distribuição do Atendimento por Tipo de Telefone</div>
                    <div class="contentBoxBigM">
                        <asp:Label ID="lblMensagemAssertividadeTotal" runat="server"></asp:Label>
                        
                        <br />
                        <center>
                            <asp:Label ID="lblAsserttotalmesn" Text="Itens" runat="server"></asp:Label>
                            <br />
                            <asp:CheckBox id="cbAssertividadeTotalFone1" runat="server" checked="true" text="Fone1&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeTotalFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeTotalFone2" runat="server" checked="true" text="Fone2&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeTotalFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeTotalFone3" runat="server" checked="true" text="Fone3&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeTotalFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeTotalFone4" runat="server" checked="true" text="Fone4&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeTotalFone_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbAssertividadeTotalFone5" runat="server" checked="true" text="Fone5&nbsp;" autopostback="true" oncheckedchanged="cbAssertividadeTotalFone_CheckedChanged"></asp:CheckBox>
                        </center>
                        <br />
                        
                        <asp:Chart id="ChartAssertividadeTotal" runat="server" Width="700px" Height="370px"></asp:Chart>
                        
                       
                    </div>
                </div>

                <div class="containerBoxBig" id="boxAtendimento" runat="server" visible = "true">
                    <div class="titleBox">Histórico de Chamadas Efetuadas e Atendidas</div>
                    <div class="contentBoxBigM">
                        <asp:Label ID="lblMensagemAtendimento" runat="server"></asp:Label>
                        
                        <br />
                        <center>
                            <asp:Label ID="lblAtendimentoItens" Text="Itens" runat="server"></asp:Label>
                            <br />
                            <asp:CheckBox id="cbChamadasEfetuadas" runat="server" checked="true" text="Chamadas Efetuadas&nbsp;" autopostback="true" oncheckedchanged="cbChamadasAtendimento_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbChamadasCliente" runat="server" checked="true" text="Chamadas Cliente&nbsp;" autopostback="true" oncheckedchanged="cbChamadasAtendimento_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbChamadasAgente" runat="server" checked="true" text="Chamadas Agente&nbsp;" autopostback="true" oncheckedchanged="cbChamadasAtendimento_CheckedChanged"></asp:CheckBox>
                        </center>
                        <br />
                        
                        <asp:Chart id="ChartAtendimento" runat="server" Width="700px" Height="370px"></asp:Chart>
                       
                    </div>
                </div>
                
                <div class="containerBoxBig" id="boxIntervaloMedia" runat="server" visible = "true">
                    <div class="titleBox">Histórico do Tempo de Ring e Intervalo Entre Chamadas</div>
                    <div class="contentBoxBigM">
                        <asp:Label ID="lblMensagemIntervaloMedia" runat="server"></asp:Label>
                        
                        <br />
                        <center>
                            <asp:Label ID="lblMediaItens" Text="Itens" runat="server"></asp:Label>
                            <br />
                            <asp:CheckBox id="cbMediaIntervaloChamadas" runat="server" checked="true" text="Chamadas&nbsp;" autopostback="true" oncheckedchanged="cbChamadasRing_CheckedChanged"></asp:CheckBox>
                            <asp:CheckBox id="cbMediaIntervaloRing" runat="server" checked="true" text="Ring&nbsp;" autopostback="true" oncheckedchanged="cbChamadasRing_CheckedChanged"></asp:CheckBox>
                        </center>
                        <br />
                        
                        <asp:Chart id="ChartIntervaloMedia" runat="server" Width="700px" Height="370px"></asp:Chart>
                       
                    </div>
                </div>
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
            
            
                <div class="clear"></div>
            
            </asp:Panel>
        </div>
    
    <asp:Timer ID="updater" runat="server" Enabled="true" Interval="1000" 
            ontick="updater_Tick"></asp:Timer>
    
    </ContentTemplate>
    </asp:UpdatePanel>

</div>
</body>
</form>

</asp:Content>