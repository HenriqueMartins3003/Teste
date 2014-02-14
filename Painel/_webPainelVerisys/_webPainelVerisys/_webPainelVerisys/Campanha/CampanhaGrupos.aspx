<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaGrupos.aspx.cs" Inherits="_webPainelVerisys.Campanha.CampanhaGrupos" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_CampanhasGrupo" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmCampanhasGrupo" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside"  id=divROContent visible="true" runat="server">
            <div class="ctn" id="modLista" runat="server" visible="true">
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
                                DataKeyNames="ID, Grupo, QtdeMaximaCanais, PorcentagemMeta, Ativo"
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

            <!-- RO -->
            <div class="ctn" id="modManutencao" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar"></asp:Label></b>
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

                    <asp:label ID="lblGrupo" CssClass="lb_Inside" Text="Grupo" runat="server" Width="120"></asp:label>
                    <asp:TextBox ID="txtGrupo" runat="server" CssClass="form" Width="500"></asp:TextBox>
                    <br />

                    <asp:label ID="lblMaxCanais" CssClass="lb_Inside" Text="Qtde Max. Canais" runat="server" Width="120"></asp:label>
                    <asp:TextBox ID="txtMaxCanais" runat="server" CssClass="form" Width="100"></asp:TextBox>
                    <br />

                    <asp:label ID="lblAtivo" CssClass="lb_Inside" Text="Ativo ?" runat="server" Width="120"></asp:label>
                    <asp:DropDownList ID="ddlAtivo" runat="server" CssClass="form" Width="105">
                        <asp:ListItem Value="False" Text="NÃO"></asp:ListItem>
                        <asp:ListItem Value="True" Text="SIM"></asp:ListItem>
                    </asp:DropDownList>

                    <br /><br />
                </div>
                
                <div id="div7" class="ctn" runat="server">
                    <asp:Label ID=Label3 Text="Campanha(s) disponíveis" runat="server" /><br />
                    <small><asp:Label ID=Label4 Text="(Para selecionar mais de uma opção faça a seleção com a tecla Crtl de seu teclado pressionada)" runat="server" /></small>
                    <br />
                
                    <asp:ListBox ID="lbCampaign" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="20"></asp:ListBox>
                
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="buttonArrowLeft" runat="server" ImageUrl="~/img/arrow-left.gif" onclick="buttonArrowLeft_Click" />
                    &nbsp;
                    <asp:ImageButton ID="buttonArrowRight" runat="server" ImageUrl="~/img/arrow-right.gif" onclick="buttonArrowRight_Click"  />
                    &nbsp;&nbsp;
                    
                    <asp:ListBox ID="lbCampaignSelected" runat="server" CssClass="formInsideMultiline" Width="340" SelectionMode="Multiple" Rows="20"></asp:ListBox>
                </div>

            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluir" runat="server" Text="Exclusão"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão ?" runat="server"></asp:label>
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