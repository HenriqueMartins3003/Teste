<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doNotCallMailing.aspx.cs" Inherits="_webPainelVerisys.Mailing.doNotCallMailing" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_doNotCallMailing" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmdoNotCallMailing" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div id="divResponse" runat="server" visible="false" class="ctt">
            <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
        
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div class="ctn" id="modLista" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Cadastrados</b></div>

                <div class="ctt">

                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="IDMAILING, TABELADISCADOR, KYFONEBLOQUEIO, LINKEDSERVERMAILING, PROCESSO, PROCESSOID, FLAG_ATIVO"
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
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar nova base de Mailings"></asp:Label></b>
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

                    <asp:label ID="lblTabelaDiscador" CssClass="lb_Inside" Text="Tabela Discador" Width="120px" runat="server"></asp:label>
                    <asp:TextBox ID="txtTabelaDiscador" runat="server" CssClass="form" Width="200px" MaxLength="100"></asp:TextBox>
                    <br />
                    
                    <asp:label ID="lblKyFone" CssClass="lb_Inside" Text="KYFone Bloqueio" Width="120px" runat="server"></asp:label>
                    <asp:TextBox ID="txtKyFone" runat="server" CssClass="form" Width="200px" MaxLength="100"></asp:TextBox>
                    <br />
                    
                    <asp:label ID="lblLinkedServer" CssClass="lb_Inside" Text="Linked Server" Width="120px" runat="server"></asp:label>
                    <asp:TextBox ID="txtLinkedServer" runat="server" CssClass="form" Width="200px" MaxLength="100"></asp:TextBox>
                    <br />
                    
                    <asp:label ID="lblProcesso" CssClass="lb_Inside" Text="Processo" Width="120px" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlProcesso" runat="server" CssClass="form" Width="200"></asp:DropDownList>
                    <br />
                    
                    <asp:label ID="lblAtivo" CssClass="lb_Inside" Text="Ativo ?" Width="120px" runat="server"></asp:label>
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
                        <asp:Label ID="lblExluir" runat="server" Text="Excluir base de Mailings"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão da base de Mailings :" runat="server"></asp:label>
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