<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plano_Affinity.aspx.cs" Inherits="_webPainelVerisys.FrontEnd.Plano_Affinity" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_PlanoAffinity" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmPlanoAffinity" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Planos - Affinity</div>


        <div class="contentInside" id=divCampanhaContent visible="false" runat="server">
            <div class="ctn" id="divCampanha" runat="server">
                <div class="cttTitle"><b>Campanha</b></div>
                <div class="ctt">
                    <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" onselectedindexchanged="ddlCampaign_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="false" runat="server">

            <div class="ctn" id="modLista" runat="server" visible="true">
                <div class="cttTitle"><b>Planos Cadastrados</b></div>

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
                                DataKeyNames="IDPLANO, IDPRODUTO, DESCRICAOPRODUTO, CODIGOPLANO, XIMPORTANCIASEGURADA, IMPORTANCIASEGURADA, XTITULAR, TITULAR, XCONJUGE, CONJUGE, XFILHO, FILHO, IDADEMIN, IDADEMAX, IDTIPOPLANO, TIPOPLANO, FLAG_ATIVO"
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

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>

            <div class="ctn" id="modManutencao" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo Plano"></asp:Label></b>
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

                    <asp:label ID="lblProduto" CssClass="lb_Inside" Text="Produto" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlProduto" runat="server" CssClass="form" Width="500"></asp:DropDownList>
                    
                    <br />
                    <asp:label ID="lblCodigoPlano" CssClass="lb_Inside" Text="Cod.Plano" runat="server"></asp:label>
                    <asp:TextBox ID="txtCodigoPlano" runat="server" CssClass="form" Width="100"></asp:TextBox>
                    
                    <br /><br />
                    
                    <small>
                    Os valores devem ser incluidos sem nenhuma pontuação, somente valores inteiros.<br />
                    Ex: R$ 100,00 deve ser cadastrado como 10000.<br />
                    Ex: R$ 14,90 deve ser cadastrado como 1490.<br /></small>
                    
                    <br />
                    <asp:label ID="lblImportanciaSegurada" CssClass="lb_Inside" Text="Imp.Segurada" runat="server"></asp:label>
                    <asp:TextBox ID="txtImportanciaSegurada" runat="server" CssClass="form" Width="100"></asp:TextBox>
                    
                    <br />
                    <asp:label ID="lblTitular" CssClass="lb_Inside" Text="Titular" runat="server"></asp:label>
                    <asp:TextBox ID="txtTitular" runat="server" CssClass="form" Width="100"></asp:TextBox>
                                        
                    <br />
                    <asp:label ID="lblConjuge" CssClass="lb_Inside" Text="Conjuge" runat="server"></asp:label>
                    <asp:TextBox ID="txtConjuge" runat="server" CssClass="form" Width="100"></asp:TextBox>

                    <br />
                    <asp:label ID="lblFilho" CssClass="lb_Inside" Text="Filho" runat="server"></asp:label>
                    <asp:TextBox ID="txtFilho" runat="server" CssClass="form" Width="100"></asp:TextBox>
                    
                    <br />
                    <asp:label ID="lblIdadeMin" CssClass="lb_Inside" Text="Idade Min" runat="server"></asp:label>
                    <asp:TextBox ID="txtIdadeMin" runat="server" CssClass="form" Width="100"></asp:TextBox>
                    
                    <br />
                    <asp:label ID="lblIdadeMax" CssClass="lb_Inside" Text="Idade Max" runat="server"></asp:label>
                    <asp:TextBox ID="txtIdadeMax" runat="server" CssClass="form" Width="100"></asp:TextBox>
                    
                    <br /><br />
                    <asp:label ID="lblTipoPlano" CssClass="lb_Inside" Text="Tipo Plano" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlTipoPlano" runat="server" CssClass="form" Width="500"></asp:DropDownList>
                    
                    <br />

                    <asp:label ID="lblAtivo" CssClass="lb_Inside" Text="Ativo ?" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlAtivo" runat="server" CssClass="form" Width="100">
                        <asp:ListItem Value="False" Text="NÃO"></asp:ListItem>
                        <asp:ListItem Value="True" Text="SIM"></asp:ListItem>
                    </asp:DropDownList>

                    <br /><br />
                </div>
            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluir" runat="server" Text="Excluir Plano"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Plano :" runat="server"></asp:label>
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