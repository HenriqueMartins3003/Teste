<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultadoOperacaoClassificacao.aspx.cs" Inherits="_webPainelVerisys.ResultadoOperacao.ResultadoOperacaoClassificacao" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ResultadoOperacaoClassificacao" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmResultadoOperacaoClassificacao" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Classificação de Resultado da Operação</div>


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
        <div class="contentInside"  id=divROContent visible="false" runat="server">

            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modListaClassificacaoRO" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Classificações Cadastradas</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaClassificacaoRO" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="ID_CLASSIFICACAO, NOM_CLASSIFICACAO, DESC_CLASSIFICACAO, ATIVO"
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



            <!-- RO -->
            <div class="ctn" id="modManutencaoClassificacaoRO" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar nova Classificação de Resultado da Operação"></asp:Label></b>
                        <asp:Label ID="lblIDClassificacaoRO" runat="server" Text="" Visible="false"></asp:Label></b>
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

                    <asp:label ID="lblNome" CssClass="lb_Inside" Text="Nome" runat="server"></asp:label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form" Width="500"></asp:TextBox>

                    <br />
                    
                    <asp:label ID="lblDescricao" CssClass="lb_Inside" Text="Descrição" runat="server"></asp:label>
                    <asp:TextBox ID="txtDescricao" runat="server" CssClass="form" Width="500"></asp:TextBox>

                    <br />

                    <asp:label ID="lblAtivo" CssClass="lb_Inside" Text="Ativo ?" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlAtivo" runat="server" CssClass="form" Width="100">
                        <asp:ListItem Value="False" Text="NÃO"></asp:ListItem>
                        <asp:ListItem Value="True" Text="SIM"></asp:ListItem>
                    </asp:DropDownList>
                    
                    <br /><br />

                </div>
            </div>
            
            <div class="ctn" id="modExcluirClassificacaoRO" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluirClassificacaoRO" runat="server" Text="Excluir Classificação de Resultado da Operação"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão da Classificação de Resultado da Operação :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblClassificacaoROExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
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