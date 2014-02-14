<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardGrafico.aspx.cs" Inherits="_webPainelVerisys.Painel.DashBoardGrafico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <title>DashBoard Gráficos</title>

    <link rel="SHORTCUT ICON" href="../img/icon_page.png" />
    <link rel="Stylesheet" href="../css/layout.css" />
    
    <script type="text/javascript">

        var winW = 0;

        function ScreenSizeW() {
            if (document.body && document.body.offsetWidth) 
            {
                winW = document.body.offsetWidth;
            }
            
            if (document.compatMode == 'CSS1Compat' &&
                document.documentElement &&
                document.documentElement.offsetWidth) 
            {
                winW = document.documentElement.offsetWidth;
            }
            
            if (window.innerWidth && window.innerHeight) 
            {
                winW = window.innerWidth;
            }
            
            document.getElementById('<%=txtsize.ClientID%>').value = winW;
        }

    </script>

</head>
<body onload="javascript:ScreenSizeW()">
    <form id="frmDashBoardGraficos" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"
            EnableScriptGlobalization="true" 
            EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="titleContentGrafico">DashBoard - Gráficos</div>

            <div class="contentInside">
                <asp:Panel ID="panel1" runat="server">
                    <div class="contentOptions">
                        <b>Opções na tela : &nbsp;</b>&nbsp;
                        <asp:CheckBox ID="cb_Mailing" runat="server" AutoPostBack="true" Checked="true" Text="&nbsp;Mailing&nbsp;&nbsp;&nbsp;&nbsp;" 
                                oncheckedchanged="cb_Mailing_CheckedChanged" />&nbsp;
                        <asp:CheckBox ID="cb_ChamadasTotal" runat="server" 
                                Text="&nbsp;Chamadas (total do dia)&nbsp;&nbsp;&nbsp;&nbsp;" AutoPostBack="true" Checked="true" 
                                oncheckedchanged="cb_ChamadasTotal_CheckedChanged" />&nbsp;
                        <asp:CheckBox ID="cb_ChamadasUltMin" runat="server"  AutoPostBack="true" Checked="true" 
                                Text="&nbsp;Chamadas (últimos 15 min.)&nbsp;&nbsp;&nbsp;&nbsp;" 
                                oncheckedchanged="cb_ChamadasUltMin_CheckedChanged" />&nbsp;
                    
                        <b>Campanhas : &nbsp;</b>
                        <asp:DropDownList ID="ddlCampanhas" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlCampanhas_SelectedIndexChanged" >
                        </asp:DropDownList>
                    
                        <div class="contentView">
                            <b>Exibição</b> 
                            <asp:RadioButtonList ID="rbExibicaoDasInformacoesValores" runat="server" 
                                RepeatDirection="Horizontal" CssClass="form" AutoPostBack="true" 
                                onselectedindexchanged="rbExibicaoDasInformacoesValores_SelectedIndexChanged" >
                                <asp:ListItem Value="1" Text="Absoluto &nbsp;" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Percentual"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <br />                    
                        <small><asp:Label ID="lblDataHora" runat="server"></asp:Label></small>
                    </div>
            
                    <center>
                    <div class="containerBoxGrafico3" id="boxMailingChart" runat="server">
                        <div class="titleBox">Mailing</div>
                        
                        <%--<b>Tipo : &nbsp;</b>--%>
                        <asp:DropDownList ID="ddlMailingChart" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlMailingChart_SelectedIndexChanged" Visible="false">
                        </asp:DropDownList>
                        <br />
                        
                        <div class="contentBoxGrafico">
                            <asp:Label ID="lblMensagemMalingChart" runat="server"></asp:Label>
                    
                            <asp:Chart ID="MailingChart" runat="server" AntiAliasing="All" Height="595px" Width="350px" BackColor="#000">
                                <Series>
                                    <asp:Series Name="SeriesMailingChart">
                                    </asp:Series>
                                </Series>
                                
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartAreaMailingChart" BackColor="#000">
                                        <Area3DStyle Enable3D="True" LightStyle="Simplistic" ></Area3DStyle>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
            
                    <div class="containerBoxGrafico3" id="boxChamadasDiaChart" runat="server">
                        <div class="titleBox">Chamadas Dia</div>
                        
                        <%--<b>Tipo : &nbsp;</b>--%>
                        <asp:DropDownList ID="ddlChamadasDiaChart" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlChamadasDiaChart_SelectedIndexChanged" Visible="false">
                        </asp:DropDownList>
                        <br />
                        
                        <div class="contentBoxGrafico">
                            <asp:Label ID="lblChamadasDiaChart" runat="server"></asp:Label>
                    
                            <asp:Chart ID="ChamadasDiaChart" runat=server AntiAliasing="All" Height="595px" Width="350px" BackColor="#000">
                                <Series>
                                    <asp:Series Name="SeriesChamadasDiaChart">
                                    </asp:Series>
                                </Series>
                                
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartAreaChamadasDiaChart" BackColor="#000">
                                        <Area3DStyle Enable3D="True" LightStyle="Simplistic" ></Area3DStyle>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
            
                    <div class="containerBoxGrafico3" id="boxUltimasChamadasChart" runat="server">
                        <div class="titleBox">Chamadas (15Minutos)</div>
                        
                        <%--<b>Tipo : &nbsp;</b>--%>
                        <asp:DropDownList ID="ddlUltimasChamadasChart" runat="server" 
                            AutoPostBack="true" 
                            onselectedindexchanged="ddlUltimasChamadasChart_SelectedIndexChanged" Visible ="false">
                        </asp:DropDownList>
                        <br />
                        
                        <div class="contentBoxGrafico">
                            <asp:Label ID="lblUltimasChamadasChart" runat="server"></asp:Label>
                    
                            <asp:Chart ID="UltimasChamadasChart" runat=server AntiAliasing="All" Height="595px" Width="350px" BackColor="#000">
                                <Series>
                                    <asp:Series Name="SeriesUltimasChamadasChart">
                                    </asp:Series>
                                </Series>
                                
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartAreaUltimasChamadasChart" BackColor="#000">
                                        <Area3DStyle Enable3D="True" LightStyle="Simplistic" ></Area3DStyle>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
                    </center>
                </asp:Panel>
            </div>
        
            <asp:Timer ID="updater" runat="server" ontick="updater_Tick" Enabled="true" Interval="1000"></asp:Timer>
        
        </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    <p>
    <asp:TextBox ID="txtsize" runat="server" Height="16px" Width="16px" CssClass="Hidden"></asp:TextBox>
    </p>
    </form>
</body>
</html>
