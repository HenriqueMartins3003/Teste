<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultadoOperacao_Fidelity.aspx.cs" Inherits="_webPainelVerisys.ResultadoOperacao.ResultadoOperacao_Fidelity" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ResultadoOperacao" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmResultadoOperacao_Fidelity" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Resultado da Operação (R.O.)</div>


        <div class="contentInside" id=divCampanhaContent visible="false" runat="server">
            <div class="ctn" id="divCampanha" runat="server">
                <div class="cttTitle"><b>Seleção de Base de Mailing</b></div>
                <div class="ctt">
                    <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" onselectedindexchanged="ddlCampaign_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divROContent visible="false" runat="server">

            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modListaRO" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>R.O. Cadastrados</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaRO" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="IDRO, DESCRICAORO, IDTIPO, DESCRICACAOTIPO, ATIVO, CC, CE, VE, RE, FE, RA, LN, RESSUBMISSAO"
                                onrowcommand="gdRegistros_RowCommand"
                                onsorting="gdRegistros_Sorting"
                                onpageindexchanging="gdRegistros_PageIndexChanging" 
                            onrowdatabound="gdRegistros_RowDataBound" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </div>
            
                <asp:label ID="lblLegenda" class="lb_Inside" runat="server" >Legenda</asp:label><br />
                <div class="ctnInsideModules">
                    <asp:label ID="Label1" runat="server" >CC - Contato Certo</asp:label><br />
                    <asp:label ID="Label2" runat="server" >CE - Contato Efetivo</asp:label><br />
                    <asp:label ID="Label3" runat="server" >VE - Venda</asp:label><br />
                    <asp:label ID="Label4" runat="server" >RE - Reemitida</asp:label>
                </div>
                <div class="ctnInsideModules">
                    <asp:label ID="Label5" runat="server" >FE - Finalização Efetiva</asp:label><br />
                    <asp:label ID="Label6" runat="server" >RA - Reagendamento</asp:label><br />
                    <asp:label ID="Label7" runat="server" >LN - Ligações Não Atendidas</asp:label>
                </div>
            
            </div>

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>

            <!-- RO -->
            <div class="ctn" id="modManutencaoRO" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo Resultado da Operação"></asp:Label></b>
                        <asp:Label ID="lblIDRO" runat="server" Text="" Visible="false"></asp:Label></b>
                    </div>

                    <div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>

                    <div class="clear"></div>

                </div>

                <!-- content -->
                <div id="Div1" class="ctt" runat="server">

                    <asp:label ID="lblDescricao" CssClass="lb_Inside" Text="Descrição" runat="server" Width="150px"></asp:label>
                    <asp:TextBox ID="txtDescricao" runat="server" CssClass="form" Width="500"></asp:TextBox>

                    <br />

                    <asp:label ID="lblTipo" CssClass="lb_Inside" Text="Tipo" runat="server" Width="150px"></asp:label>
                    <asp:DropDownList ID="ddlTypeRO" runat="server" CssClass="form" Width="500"></asp:DropDownList>
                    
                    <br />

                    <asp:label ID="lblAtivo" CssClass="lb_Inside" Text="Ativo ?" runat="server" Width="150px"></asp:label>
                    <asp:DropDownList ID="ddlAtivo" runat="server" CssClass="form" Width="100">
                        <asp:ListItem Value="False" Text="NÃO"></asp:ListItem>
                        <asp:ListItem Value="True" Text="SIM"></asp:ListItem>
                    </asp:DropDownList>

                    <br />
                    
                    <asp:label ID="lblContatoCerto" class="lb_Inside" runat="server" Width="150px">Contato Certo</asp:label>
                    <asp:RadioButtonList ID="rbContatoCerto" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:label ID="lblContatoEfetivo" class="lb_Inside" runat="server" Width="150px">Contato Efetivo</asp:label>
                    <asp:RadioButtonList ID="rbContatoEfetivo" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:label ID="lblVenda" class="lb_Inside" runat="server" Width="150px">Venda</asp:label>
                    <asp:RadioButtonList ID="rbVenda" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:label ID="lblReemitida" class="lb_Inside" runat="server" Width="150px">Reemitida</asp:label>
                    <asp:RadioButtonList ID="rbReemitida" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:label ID="lblFinalizacaoEfetiva" class="lb_Inside" runat="server" Width="150px">Finalização Efetiva</asp:label>
                    <asp:RadioButtonList ID="rbFinalizacaoEfetiva" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:label ID="lblReagendamento" class="lb_Inside" runat="server" Width="150px">Reagendamento</asp:label>
                    <asp:RadioButtonList ID="rbReagendamento" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:label ID="lblLigacoesNaoAtendidas" class="lb_Inside" runat="server" Width="150px">Ligações Não Atendidas</asp:label>
                    <asp:RadioButtonList ID="rbLigacoesNaoAtendidas" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:label ID="lblRessubmissao" class="lb_Inside" runat="server" Width="150px">Permite Ressubmissão</asp:label>
                    <asp:RadioButtonList ID="rbRessubmissao" runat="server" RepeatDirection="Horizontal" CssClass="form" Width="150px">
                        <asp:ListItem Value="NÃO" Text="&nbsp;Não&nbsp;&nbsp;" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="SIM" Text="&nbsp;Sim&nbsp;&nbsp;" ></asp:ListItem>
                    </asp:RadioButtonList>

                    <br /><br />
                </div>
            </div>
            
            <div class="ctn" id="modExcluirRO" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluirRO" runat="server" Text="Excluir Resultado da Operação"></asp:Label></b>
                    </div>

                    <div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>

                    <div class="clear"></div>

                </div>
                
                <!-- content -->
                <div id="Div2" class="ctt" runat="server">

                    <center>
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Resultado da Operação :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblROExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
                    </center>
                
                </div>
            </div>

            <br />
            <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-salvar.gif" OnClick="Manager_Click"/>&nbsp;
            <asp:ImageButton ID="buttonImageLimpar" runat="server" ImageUrl="~/img/btn-limpar.gif" OnClick="buttonImageLimpar_Click"/>

        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>