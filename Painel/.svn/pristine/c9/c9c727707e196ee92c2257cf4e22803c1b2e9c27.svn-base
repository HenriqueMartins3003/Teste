<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegmentacaoMailing.aspx.cs" Inherits="_webPainelVerisys.Mailing.SegmentacaoMailing" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_SegmentacaoMailing" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmSegmentacaoMailing" runat="server">
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
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
            <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
            
        <!-- content -->
        <div class="contentInside"  id=divContent visible="false" runat="server">

            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modLista" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Segmentações Cadastradas</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="ID_SEGMENTACAO, NOME_SEGMENTACAO, NUMERO_CAMPANHA, NUMERO_LOTE, PRIORIDADE, IDFLAG, FLAG_ATIVO"
                                onrowcommand="gdRegistros_RowCommand"
                                onsorting="gdRegistros_Sorting"
                                onpageindexchanging="gdRegistros_PageIndexChanging" 
                            onrowdatabound="gdRegistros_RowDataBound" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="ctn" id="modManutencao" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar nova Segmentação"></asp:Label></b>
                        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label></b>
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

                    <asp:label ID="lblDescricao" CssClass="lb_Inside" Text="Descrição" runat="server"></asp:label>
                    <asp:TextBox ID="txtDescricao" runat="server" CssClass="form" Width="500"></asp:TextBox>
                    <br />
                    
                    <asp:label ID="Label1" CssClass="lb_Inside" Text="Campanha" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlCampanhaCadastro" runat="server" Width="200px" CssClass="form" 
                                      AutoPostBack="true" >
                    </asp:DropDownList>
                    <br />
                    
                    <asp:label ID="Label2" CssClass="lb_Inside" Text="Lote" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlLoteCadastro" runat="server" Width="200px" CssClass="form">
                    </asp:DropDownList>            
                    <br />
                    
                    <asp:label ID="Label3" CssClass="lb_Inside" Text="Prioridade" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlPrioridade" runat="server" Width="200px" CssClass="form" AutoPostBack="true">
                        <asp:ListItem Value="0" Text="&nbsp;0&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="1" Text="&nbsp;1&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="2" Text="&nbsp;2&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="3" Text="&nbsp;3&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="4" Text="&nbsp;4&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="5" Text="&nbsp;5&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="6" Text="&nbsp;6&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="7" Text="&nbsp;7&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="8" Text="&nbsp;8&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="9" Text="&nbsp;9&nbsp;&nbsp;" Selected=True></asp:ListItem>
                        <asp:ListItem Value="10" Text="&nbsp;Habilitar&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="11" Text="&nbsp;Desabilitar&nbsp;&nbsp;"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    
                    <asp:label ID="lblAtivo" CssClass="lb_Inside" Text="Ativo ?" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlAtivo" runat="server" CssClass="form" Width="200">
                        <asp:ListItem Value="False" Text="NÃO"></asp:ListItem>
                        <asp:ListItem Value="True" Text="SIM"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluir" runat="server" Text="Excluir Segmentação"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão da Segmentação :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
                    </center>
                
                </div>
            </div>
            
            <div class="ctn" id="modLimpar" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblLimpar" runat="server" Text="Remover Segmentação"></asp:Label></b>
                    </div>

                    <div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>

                    <div class="clear"></div>

                </div>
                
                <!-- content -->
                <div id="Div4" class="ctt" runat="server">

                    <center>
                    <asp:label ID="lblMensagemLimpar" Text="Confirma a remoção da Segmentação :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblRemoverCampanhaInfo" CssClass="lb_InsideConfirm" Text="Campanha : " runat="server"></asp:label>
                    <asp:label ID="lblRemoverCampanha" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
                    <br />
                    <asp:label ID="lblRemoverLoteInfo" CssClass="lb_InsideConfirm" Text="Lote : " runat="server"></asp:label>
                    <asp:label ID="lblRemoverLote" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
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