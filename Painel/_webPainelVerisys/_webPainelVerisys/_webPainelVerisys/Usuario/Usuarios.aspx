<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="_webPainelVerisys.Usuario.Usuario" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_Usuarios" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmUsuarios" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Usuarios</div>
        
        <div class="contentInside" id=div3 runat="server">
        
            <div class="cttTitle"><b>Pesquisar: Usuários com permissão de acesso</b></div>
            <div class="ctnInside" id="div4" runat="server">
                
                <div class="ctt">
                    
                    <asp:TextBox ID="txtUsuarioCadastrado" runat="server" CssClass="form" Width="600px" />
                    &nbsp;&nbsp;
                
                    <asp:DropDownList ID="ddlUsuarioCadastrado" runat="server" CssClass="formInside">
                        <asp:ListItem Value="1" Text="Código"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Nome"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                
                    <asp:ImageButton ID="btnFiltroCadastrado" CssClass="btnDefaultInsideInline" runat="server" ImageUrl="~/img/btn-filtrar.gif" onclick="btnFiltroCadastrado_Click" />
                
                </div>
                
            </div>
            
        </div>
        
        <div class="contentInside"  id=divLista visible="true" runat="server">
            
            <div class="cttTitle"><b>Usuarios</b></div>
            <div class="ctnInside" id="modLista" runat="server">

                <div class="ctt">

                    <asp:GridView ID="gdRegistros" runat="server" 
                            AllowSorting="True"
                            GridLines="None"
                            CellPadding="4"
                            AllowPaging="True"
                            PageSize="20"
                            AlternatingRowStyle-HorizontalAlign="Left"
                            DataKeyNames="CODIGO, NOME, DESCRICAO, IDPERFILUSUARIO"
                            onrowcommand="gdRegistros_RowCommand"
                            onsorting="gdRegistros_Sorting"
                            onpageindexchanging="gdRegistros_PageIndexChanging" 
                            onrowdatabound="gdRegistros_RowDataBound" HorizontalAlign="Center" >
                        <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                        <AlternatingRowStyle></AlternatingRowStyle>
                    </asp:GridView>
                
                </div>
            
            </div>
            
        </div>
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
            <asp:Label ID="lblResponse" runat="server"></asp:Label>
            <br />
        </div>

        <div class="contentInside" id=div5 runat="server">
        
            <div class="cttTitle"><b>Pesquisar: Usuários sem permissão de acesso</b></div>
            <div class="ctnInside" id="div6" runat="server">
            
                <div class="ctt">
                
                    <asp:TextBox ID="txtUsuarioNaoCadastrado" runat="server" CssClass="form" Width="600px" />
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlUsuarioNaoCadastrado" runat="server" CssClass="formInside">
                        <asp:ListItem Value="1" Text="Código"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Nome"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnFiltroNaoCadastrado" runat="server" CssClass="btnDefaultInsideInline" ImageUrl="~/img/btn-filtrar.gif" onclick="btnFiltroNaoCadastrado_Click" />
                
                </div>
                
            </div>
            
        </div>

        <div class="contentInside"  id=divContent visible="false" runat="server">
            <br /><br />
            <div class="ctn" id="modManutencao" visible="true" runat="server">
                
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo Usuário"></asp:Label></b>
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
                <div id="divUsuarioNaoCadastrado" class="ctt" runat="server">
                    
                    <div id="divUsuario" class="ctn" runat="server">
                        
                        <asp:Label ID=lbl1 Text="Usuário(s) disponíveis" runat="server" />
                        <small><asp:Label ID=Label1 Text="(Para selecionar mais de uma opção faça a seleção com a tecla Crtl de seu teclado pressionada)" runat="server" /></small>
                        <br />

                        <asp:ListBox ID="lbUsersNotAssociated" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="5"></asp:ListBox>
                        
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="buttonArrowLeftUserNotAssociated" runat="server" ImageUrl="~/img/arrow-left.gif" onclick="buttonArrowLeftUserNotAssociated_Click" />
                        &nbsp;
                        <asp:ImageButton ID="buttonArrowRightUserNotAssociated" runat="server" ImageUrl="~/img/arrow-right.gif" onclick="buttonArrowRightUserNotAssociated_Click"  />
                        &nbsp;&nbsp;    
                    
                        <asp:ListBox ID="lbUsersNotAssociatedSelected" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="5"></asp:ListBox>
                    
                    </div>
                    <br /><br />
                    
                    <div id="div1" class="ctn" runat="server">
                    
                        <asp:Label ID=Label2 Text="Perfil de Acesso" runat="server" />
                        <br />
                        <asp:DropDownList ID="ddlProfile" runat="server" CssClass="form" Width="200px"></asp:DropDownList>
                    
                    </div>
                    <br /><br />
                    
                    <div id="div7" class="ctn" runat="server">
                        <asp:Label ID=Label3 Text="Campanha(s) disponíveis" runat="server" />
                        <small><asp:Label ID=Label4 Text="(Para selecionar mais de uma opção faça a seleção com a tecla Crtl de seu teclado pressionada)" runat="server" /></small>
                        <br />
                    
                        <asp:ListBox ID="lbCampaigns" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="20"></asp:ListBox>
                    
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="buttonArrowLeftCampaign" runat="server" ImageUrl="~/img/arrow-left.gif" onclick="buttonArrowLeftCampaign_Click" />
                        &nbsp;
                        <asp:ImageButton ID="buttonArrowRightCampaign" runat="server" ImageUrl="~/img/arrow-right.gif" onclick="buttonArrowRightCampaign_Click"  />
                        &nbsp;&nbsp;
                        
                        <asp:ListBox ID="lbCampaignsSelected" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="20"></asp:ListBox>
                    </div>
                    
                    <br /><br />
                    <div id="div8" class="ctn" runat="server">
                        <asp:Label ID="Label3Groups" Text="Grupos de Campanhas" runat="server" />
                        <br />
                        <small><asp:Label ID="Label4Groups" Text="(Para selecionar mais de uma opção faça a seleção com a tecla Crtl de seu teclado pressionada)" runat="server" /></small>
                        <br />
                        <small><asp:Label ID="Label4Groupsq" Text="(Exclusivo para Metralhadoras)" runat="server" /></small>
                        <br />
                    
                        <asp:ListBox ID="lbCampaignsGroups" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="20"></asp:ListBox>
                    
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="buttonArrowLeftCampaignGroups" runat="server" ImageUrl="~/img/arrow-left.gif" onclick="buttonArrowLeftCampaignGroups_Click" />
                        &nbsp;
                        <asp:ImageButton ID="buttonArrowRightCampaignGroups" runat="server" ImageUrl="~/img/arrow-right.gif" onclick="buttonArrowRightCampaignGroups_Click"  />
                        &nbsp;&nbsp;
                        
                        <asp:ListBox ID="lbCampaignsSelectedGroups" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="20"></asp:ListBox>
                    </div>
                    
                </div>

            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluir" runat="server" Text="Exclusão de Usuário"></asp:Label></b></div><div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate></asp:UpdateProgress></div><div class="clear"></div>

                </div>
                
                <div id="Div2" class="ctt" runat="server">

                    <center>
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Usuário :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label></center>
                
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