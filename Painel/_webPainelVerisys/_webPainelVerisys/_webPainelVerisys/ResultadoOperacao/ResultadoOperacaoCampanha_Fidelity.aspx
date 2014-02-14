<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultadoOperacaoCampanha_Fidelity.aspx.cs" Inherits="_webPainelVerisys.ResultadoOperacao.ResultadoOperacaoCampanha_Fidelity" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ResultadoOperacaoCampanha" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmResultadoOperacaoCampanha_Fidelity" runat="server">
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
        
        <!-- content -->
        <div class="contentInside"  id=divROContent visible="false" runat="server">

            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modListaRO" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Campanhas Associadas</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaROCampanha" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="NUMEROCAMPANHA, NOME"
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
            <div class="ctn" id="modManutencaoCampanhaRO" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar nova Associação de R.O. X Campanha"></asp:Label></b>
                        <asp:Label ID="lblIDCampanhaRO" runat="server" Text="" Visible="false"></asp:Label></b>
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
                <div id="divAssociacao" class="ctt" runat="server">

                    <asp:label ID="lblCampaignAssoc" CssClass="lb_Inside" Text="Campanha" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlCampaignAssoc" runat="server" CssClass="form" Width="500"></asp:DropDownList>
                    <br />
                    <asp:label ID="lblRO" CssClass="lb_Inside" Text="RO" runat="server"></asp:label>

                    <!-- listbox[1] -->
                    <div style="float:left;">
                        <asp:ListBox ID="lbRO" runat="server" SelectionMode="Multiple" CssClass="form" Width="305" Rows="10">
                        </asp:ListBox>
                    </div>
                    
                    <!-- arows -->
                    <div style="float:left; margin:70px 5px 0px 5px;">
                        <asp:ImageButton ID="buttonArrowLeft" runat="server" 
                            ImageUrl="~/img/arrow-left.gif" onclick="buttonArrowLeft_Click" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="buttonArrowRight" runat="server" 
                            ImageUrl="~/img/arrow-right.gif" onclick="buttonArrowRight_Click" />
                    </div>
                    
                    <!-- listbox[2] -->
                    <div style="float:left;">                
                        <asp:ListBox ID="lbROSelecionados" runat="server" SelectionMode="Multiple" CssClass="form" Width="305" Rows="10">
                        </asp:ListBox>
                    </div>
                    
                    <div class="clear"></div>

                    <br /><br />
                
                </div>

            </div>
            
            <div class="ctn" id="modExcluirCampanhaRO" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblExluirCampanhaRO" runat="server" Text="Exclusão de Associação de R.O. X Campanha"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Campanha de Resultado da Operação :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblCampanhaROExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
                    </center>
                
                </div>
            </div>
            
            <div class="ctn" id="modConfigurarReagendamento" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblConfigurarCampanhaRO" runat="server" Text="Configuração de Associação de R.O. X Campanha"></asp:Label></b>
                    </div>

                    <div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>

                    <div class="clear"></div>

                </div>
                
                <br />
                
                <!-- content -->
                <div id="divCtnListaPerfis" runat="server">

                    <%--Repeater--%>
                    <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                        <thead style="background:#F1F1F1;">
                            <tr>
                                <td align="left" valign="middle" style="padding:5px 3px; width:50px;"><b>ID</b></td>
                                
                                <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Descrição</b></td>
                                
                                <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                    <asp:CheckBox ID="chkReagendarTodos" runat="server" Checked="false" 
                                        AutoPostBack="true" oncheckedchanged="chkReagendarTodos_CheckedChanged"/>&nbsp;&nbsp;Reagendar</b></td>
                                        
                                <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                    <asp:CheckBox ID="chkInvalidaTelefoneTodos" runat="server" Checked="false" 
                                        AutoPostBack="true" oncheckedchanged="chkInvalidaTelefoneTodos_CheckedChanged"/>&nbsp;&nbsp;Invalidar Telefone</b></td>
                                        
                                <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                    <asp:CheckBox ID="chkFoneForcadoTodos" runat="server" Checked="false" 
                                        AutoPostBack="true" oncheckedchanged="chkFoneForcadoTodos_CheckedChanged"/>&nbsp;&nbsp;Insere Telefone</b></td>
                                        
                                <td align="center" valign="middle" style="padding:5px 3px; width:150px;"><b>Cod.Vision</b></td>
                                        
                                <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                    <asp:CheckBox ID="chkNotCallRecTodos" runat="server" Checked="false" 
                                        AutoPostBack="true" oncheckedchanged="chkNotCallRecTodos_CheckedChanged"/>&nbsp;&nbsp;Insere NotCall</b></td>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="rModulos" runat="server">
                            <ItemTemplate>
                            <tr>
                                <td style="padding:5px 5px;" align="left" valign="middle">
                                    <asp:Label ID="lblID" runat="server" Width="50px" Text=<%# Eval("IDROCampanha") %> /></td>
                                
                                <td style="padding:5px 5px;" align="left" valign="middle"><%# Eval("DescricaoRO")%></td>
                                
                                <td style="padding:5px 5px;" align="center" valign="middle">
                                    <asp:CheckBox ID="chkReagendamento" runat="server" Checked=<%# Convert.ToBoolean(Eval("ReagendamentoRO")) %> /></td>
                                    
                                <td style="padding:5px 5px;" align="center" valign="middle">
                                    <asp:CheckBox ID="chkInvalidaTelefone" runat="server" Checked=<%# Convert.ToBoolean(Eval("InvalidaTelefone")) %> /></td>
                                    
                                <td style="padding:5px 5px;" align="center" valign="middle">
                                    <asp:CheckBox ID="chkFoneForcado" runat="server" Checked=<%# Convert.ToBoolean(Eval("FoneForcado")) %> /></td>
                                    
                                <td style="padding:5px 5px;" align="center" valign="middle">
                                    <asp:TextBox ID="txtVision" runat="server" CssClass="form" Width="50px" Text=<%# Eval("Vision") %> /></td>
                                    
                                <td style="padding:5px 5px;" align="center" valign="middle">
                                    <asp:CheckBox ID="chkNotCallRec" runat="server" Checked=<%# Convert.ToBoolean(Eval("NotCallRec")) %> /></td>
                                    
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

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