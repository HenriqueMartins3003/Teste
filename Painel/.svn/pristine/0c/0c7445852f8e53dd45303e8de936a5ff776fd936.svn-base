<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaDefinicaoSequenciamento.aspx.cs" Inherits="_webPainelVerisys.Campanha.Campanha_DefinicaoSequenciamento" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_CampanhaDefinicaoSequenciamento" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmCampanhaDefinicaoSequenciamento" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Plano de Discagem</b></div>
            
            <div class="ctn" id="divRegra" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Plano de Discagem :" runat="server" width="150px"></asp:label>
                        <asp:DropDownList ID="ddlRegra" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlRegra_SelectedIndexChanged" width="250px"></asp:DropDownList>
                    </div>
                
                </div>
            </div>
            
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div class="ctn" id="modLista" runat="server" visible="true">
                <div class="cttTitle"><b>Sequenciamentos Cadastrados</b></div>

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
                                DataKeyNames="IDDEFINICAO, MODOAGRUPAMENTO, MODOAGRUPAMENTO_DESC, HORAINICIAL, HORAINICIAL_DESC, HORAFINAL, HORAFINAL_DESC, DEFINICAOSEQUENCIAMENTO"
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
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo Sequenciamento"></asp:Label></b>
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
                    
                    <div id="Div3" class="contentBoxListsContentL" runat="server">
                        <center>
                            <asp:Label ID="lblDataHora" Text="Segmentação de Periodos" runat="server" />
                        </center>
                        <br />
                        
                        <asp:label ID="lblSemana" CssClass="lb_Inside" Text="Grupo de Dias" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlSemana" runat="server" CssClass="form" Width="200"></asp:DropDownList>

                        <br />

                        <asp:label ID="lblHoraInicial" CssClass="lb_Inside" Text="Hora Inicial" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtHoraInicial"  runat="server" CssClass="form" Width="50" 
                            onkeypress="startTabCheck();return MM_formatoDigitos(event,this,'##:##:##');" 
                            onkeyup="exibeValor(this, 8, 0)" onfocus="stopTabCheck(this)" MaxLength="8"></asp:TextBox>
                        
                        <br />

                        <asp:label ID="lblHoraFinal" CssClass="lb_Inside" Text="Hora Final" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtHoraFinal" runat="server" CssClass="form" Width="50" 
                            onkeypress="startTabCheck();return MM_formatoDigitos(event,this,'##:##:##');" 
                            onkeyup="exibeValor(this, 8, 0)" onfocus="stopTabCheck(this)" MaxLength="8"></asp:TextBox>
                    </div>
                        
                    <div class="contentBoxListsContentR" runat="server">
                        <center>
                            <asp:Label ID="lblMultiCampo" Text="Ordem de Discagem" runat="server" />
                        </center>
                        <br />
                        <div class="contentBoxLists" runat="server">
                            <div class="titleBox">Telefones Disponiveis</div>
                            <asp:ListBox ID="lbMascara" runat="server" CssClass="formInsideMultiline" SelectionMode="Multiple" Rows="5" Width="100%"></asp:ListBox>
                        </div>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="btnALeft" runat="server" ImageUrl="~/img/arrow-left.gif" onclick="btnALeft_Click" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="btnARight" runat="server" ImageUrl="~/img/arrow-right.gif" onclick="btnARight_Click" />
                        &nbsp;&nbsp;
                        
                        <div class="contentBoxLists2" runat="server">
                            <div class="titleBox">Telefones Configurados</div>
                            <asp:ListBox ID="lbMascaraSelecionada" runat="server" CssClass="formInsideMultiline" SelectionMode="Multiple" Rows="5" Width="100%"></asp:ListBox>
                        </div>
                        <br />
                    </div>
                
                </div>
            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluir" runat="server" Text="Excluir Sequenciamento"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Sequenciamento :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
                    </center>
                
                </div>
            </div>

            <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-salvar.gif" OnClick="Manager_Click"/>&nbsp;
            <asp:ImageButton ID="buttonImageLimpar" runat="server" ImageUrl="~/img/btn-limpar.gif" OnClick="buttonImageLimpar_Click"/>    
                
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>