<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegmentacaoRegra.aspx.cs" Inherits="_webPainelVerisys.Mailing.SegmentacaoRegra" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_SegmentacaoRegra" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmSegmentacaoRegra" runat="server">
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
        
        <div class="contentInside" id=divSegmentacaoContent visible="true" runat="server">
            <div class="ctn" id="divSegmentacao" runat="server">
                <div class="cttTitle"><b>Segmentações</b></div>
                <div class="ctt">
                    <asp:label ID="Label4" CssClass="lb_Inside" Text="Segmentação" runat="server" Width="150px"></asp:label>
                    <asp:DropDownList ID="ddlSegmentacao" runat="server" CssClass="form" 
                        AutoPostBack="true" Width="300px" onselectedindexchanged="ddlSegmentacao_SelectedIndexChanged"></asp:DropDownList>
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
                <div class="cttTitle"><b>Regras Cadastradas</b></div>

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
                                DataKeyNames="ID_SEGMENTACAOREGRA, CAMPO_SEGMENTACAO, REGRA_SEGMENTACAO, VALOR_SEGMENTACAO, TABELA_SEGMENTACAO, ABRE_PARENTESES, FECHA_PARENTESES, CONJUNCAO"
                                onrowcommand="gdRegistros_RowCommand"
                                onpageindexchanging="gdRegistros_PageIndexChanging" 
                            onrowdatabound="gdRegistros_RowDataBound" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <!-- RO -->
            <div class="ctn" id="modManutencao" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar nova Regra Segmentação"></asp:Label></b>
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


                    <asp:label ID="lblConjuncao" CssClass="lb_Inside" Text="Conjunção" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlConjuncao" runat="server" Width="60px" CssClass="form" >
                        <asp:ListItem Value="AND" Text="E"></asp:ListItem>
                        <asp:ListItem Value="OR" Text="OU"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlParentesesAbre" runat="server" Width="40px" CssClass="form" >
                        <asp:ListItem Value="Sem" Text="&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="Com" Text="("></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    
                    <asp:label ID="Label5" CssClass="lb_Inside" Text="Tabela" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlTabela" runat="server" Width="200px" CssClass="form" 
                        AutoPostBack="true" onselectedindexchanged="ddlTabela_SelectedIndexChanged" ></asp:DropDownList>
                    <br />
                    
                    <asp:label ID="Label6" CssClass="lb_Inside" Text="Campo" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlCampo" runat="server" Width="200px" CssClass="form"></asp:DropDownList>
                    <br />
                    
                    <asp:label ID="Label7" CssClass="lb_Inside" Text="Operador" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlOperador" runat="server" Width="200px" CssClass="form" >
                        <asp:ListItem Value="0" Text="Selecione o Operador..."></asp:ListItem>
                        <asp:ListItem Value="=" Text="Igual a"></asp:ListItem>
                        <asp:ListItem Value="<>" Text="Diferente de"></asp:ListItem>
                        <asp:ListItem Value="<" Text="Menor que"></asp:ListItem>
                        <asp:ListItem Value=">" Text="Maior que"></asp:ListItem>
                        <asp:ListItem Value="<=" Text="Menor ou Igual a"></asp:ListItem>
                        <asp:ListItem Value=">=" Text="Maior ou Igual a"></asp:ListItem>
                        <asp:ListItem Value="INICIA" Text="Inicia em"></asp:ListItem>
                        <asp:ListItem Value="CONTEM" Text="Contem"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    
                    <asp:label ID="Label8" CssClass="lb_Inside" Text="Valor" runat="server"></asp:label>
                    <asp:TextBox ID="txtValor" runat="server" CssClass="form" Width="200px" MaxLength="100"></asp:TextBox>
                    <asp:DropDownList ID="ddlParentesesFecha" runat="server" Width="40px" CssClass="form" >
                        <asp:ListItem Value="Sem" Text="&nbsp;"></asp:ListItem>
                        <asp:ListItem Value="Com" Text=")"></asp:ListItem>
                    </asp:DropDownList>
                   
                    <br /><br />
                    <asp:label style="font-size: xx-small" ID="Label1" Text="Pode-se inserir mais de um valor quando o Operador for &quot;Igual a&quot; ou &quot;Diferente de&quot;, os valores devem ser separados por virgula (,)" runat="server"></asp:label>

                </div>
            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluir" runat="server" Text="Excluir Regra Segmentação"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão da Regra Segmentação :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
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