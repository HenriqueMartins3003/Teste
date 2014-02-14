<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaParametros.aspx.cs" Inherits="_webPainelVerisys.Campanha.CampanhaParametros" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_CampanhaParametros" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmCampanhaParametros" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Parâmetros da Campanha</div>

        <div class="contentInside" id="divCampanhaContent" runat="server">
        
            <div class="cttTitle"><b>Campanhas</b></div>
            
            <div class="ctn" id="divCampanha" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha:" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlCampaign_SelectedIndexChanged"></asp:DropDownList>
                            
                     
                    </div>
                
                </div>
            </div>
            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            

            <div class="ctn" id="modCampanhaParametro" runat="server" visible="false">
                <!-- title[1] -->
                <div class="cttTitle"><b>Parametros</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div class="ctt">
                        <asp:Label ID="lblChamAgenteLivre" runat="server" Text="Índice de Agressividade" CssClass="lb_Inside" Width="300px" ></asp:Label>
                        <asp:TextBox ID="txtChamAgenteLivre" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblIndiceAgresMax" runat="server" Text="Índice de Agressividade (Máximo)" CssClass="lb_Inside" Width="300px" visible="false"></asp:Label>
                        <asp:TextBox ID="txtIndiceAgresMax" runat="server" Width="60px" CssClass="form" visible="false"></asp:TextBox>
                    </div>
                
                    <br />
                
                    <div class="ctt">
                        <asp:Label ID="lblTempoAtendimento" runat="server" Text="Tempo para Atendimento (segundos)" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtTempoAtendimento" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblReagendamentoNaoAtendimento" runat="server" Text="Reagendamento por Não Atendimento(minutos)" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtReagendamentoNaoAtendimento" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblReagendamentoOcupado" runat="server" Text="Reagendamento por Ocupado (minutos)" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtReagendamentoOcupado" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblReagendamentoCongestionamento" runat="server" Text="Reagendamento por Congestionamento (minutos)" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtReagendamentoCongestionamento" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblTentativas" runat="server" Text="Número de Tentativas" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtTentativas" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblTentativasCongestionamento" runat="server" Text="Tentativas por Congestionamento" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtTentativasCongestionamento" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblTentativasNaoAtende" runat="server" Text="Tentativas por Não Atende" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtTentativasNaoAtende" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblTentativasOcupado" runat="server" Text="Tentativas por Ocupado" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtTentativasOcupado" runat="server" Width="60px" CssClass="form"></asp:TextBox>
                        <br />
                    </div>
                
                    <br />
                    
                    <div class="ctt">
                        
                        <asp:Label ID="Label1" runat="server" Text="Índice Campo Fone não Atendimento" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:CheckBox ID="cbIndiceCampoFoneNaoAtendimento" runat="server"/>
                        <br /><br />
                        
                        <asp:Label ID="Label2" runat="server" Text="Índice Campo Fone Ocupado" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:CheckBox ID="cbIndiceCampoFoneOcupado" runat="server"/>
                        <br /><br />
                        
                        <asp:Label ID="Label3" runat="server" Text="Índice Campo Fone Congestionamento" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:CheckBox ID="cbIndiceCampoFoneCongestionamento" runat="server"/>
                        <br /><br />
                        
                        <small>
                            <p>Vai para próximo campo de telefone, de acordo com o evento marcado</p>
                        </small>
                    </div>
                    
                    <br />
                    
                    <div class="ctt" id="divPreditivo" runat="server" visible="false">
                    
                        <%--<asp:Label ID="lblVirgens" runat="server" Text="Ignora Reagendamentos" CssClass="lb_Inside" Width="300px"></asp:Label>
                            <asp:CheckBox ID="cbIgnoraReagendamento" runat="server"/>
                        <br /><br />--%>
                        
                        <asp:Label ID="lblTipoVarredura" runat="server" Text="Tipo de Varredura" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:DropDownList ID="ddlTipovarredura" runat="server" CssClass="form" >
                            <asp:ListItem Value="0" Text="Vertical"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Horizontal"></asp:ListItem>
                        </asp:DropDownList>
                        
                        <br /><br />
                        <asp:Label ID="lblPlanoDiscagem" runat="server" Text="Plano de Discagem" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:DropDownList ID="ddlPlanoDiscagem" runat="server" CssClass="form" AutoPostBack="true"></asp:DropDownList>
                        
                        <br /><br />
                        <asp:label ID="lblRegraDiscagem" CssClass="lb_Inside" Text="Regra de Discagem" runat="server" Width="300px"></asp:label>
                        <asp:DropDownList ID="ddlRegraDiscagem" runat="server" CssClass="form" AutoPostBack="true" ></asp:DropDownList>
                    
                    </div>
                    
                    <br />
                    
                    <div class="ctt" runat="server" visible="false">
                        
                        <asp:Label ID="lblClausulaWhere" runat="server" Text="Prefixo Cláusula Where (Filtro Discador)" CssClass="lb_Inside" Width="300px" visible="false"></asp:Label>
                        <asp:TextBox ID="txtClausulaWhere" runat="server" Width="400px" CssClass="form" MaxLength="250" visible="false"></asp:TextBox>
                        <br />
                    </div>
                    
                    <br />
                    
                    <div class="ctt" id="divMascara" visible="false" runat="server">
                        
                        <asp:Label ID="lblMultiCampo" Text="Ordem de Discagem Default" runat="server" />
                        <br />
                        
                        <asp:ListBox ID="lbMascara" runat="server" CssClass="formInsideMultiline" SelectionMode="Multiple" Rows="5" Width="250"></asp:ListBox>
                    
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="btnALeft" runat="server" ImageUrl="~/img/arrow-left.gif" onclick="btnALeft_Click" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="btnARight" runat="server" ImageUrl="~/img/arrow-right.gif" onclick="btnARight_Click" />
                        &nbsp;&nbsp;
                        
                        <asp:ListBox ID="lbMascaraSelecionada" runat="server" CssClass="formInsideMultiline" SelectionMode="Multiple" Rows="5" Width="250"></asp:ListBox>
                        
                        <br />
                        <small>
                            <p>O Sinal de + indica que o campo esta em uso e a ordem apresentada é a atual configuração realizada !</p>
                        </small>
                        <br />
                    </div>
                    
                    <br />
                    
                    <div id="divRecadoCP" class="ctt" runat="server" visible="false">
                        
                        <br />
                        <asp:Label ID="lblRecadoCPAtivo" runat="server" Text="Ativo?" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:DropDownList ID="ddlRecadoCPAtivo" runat="server" CssClass="form" >
                            <asp:ListItem Value="0" Text="Não"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Sim"></asp:ListItem>
                        </asp:DropDownList>
                        
                        <br />
                        <asp:Label ID="lblRecadoCPDescricao" runat="server" Text="Descrição" CssClass="lb_Inside" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtRecadoCPDescricao" runat="server" Width="400px" CssClass="form" MaxLength="250" visible="true" ReadOnly="True" ></asp:TextBox>
                        
                    </div>
                    
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