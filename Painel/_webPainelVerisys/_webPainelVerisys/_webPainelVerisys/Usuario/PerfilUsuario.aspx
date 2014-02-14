<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="_webPainelVerisys.Usuario.PerfilUsuario" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_PerfilUsuario" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmPerfilUsuario" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <!-- content -->
        <div class="contentInside">

            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modListaPerfil" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Perfis Cadastrados</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaPerfis" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="10"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="ID, DESCRICAO, IDTIPOPERFIL, TIPOPERFIL, FLAGATIVO, ATIVO"
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

            <!-- profile -->
            <div class="ctn" id="modManutencaoPerfil" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo perfil"></asp:Label></b>
                        <asp:Label ID="lblIDPerfil" runat="server" Text="" Visible="false"></asp:Label></b>
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

                    <asp:label ID="lblTipo" CssClass="lb_Inside" Text="Tipo Perfil" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlTypeProfile" runat="server" CssClass="form"></asp:DropDownList>

                    <br />

                    <asp:label ID="lblAtivo" CssClass="lb_Inside" Text="Ativo ?" runat="server"></asp:label>
                    <asp:DropDownList ID="ddlAtivo" runat="server" CssClass="form">
                        <asp:ListItem Value="False" Text="NÃO"></asp:ListItem>
                        <asp:ListItem Value="True" Text="SIM"></asp:ListItem>
                    </asp:DropDownList>

                    <br /><br />

                    <div id="divCtnListaPerfis" runat="server">

                        <%--Repeater--%>
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:50px;"></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Árvore</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:250px;"><b>Descrição</b></td>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                        <asp:CheckBox ID="chkInsereTodos" runat="server" Checked="false"
                                            oncheckedchanged="chkInsereTodos_CheckedChanged" AutoPostBack="true"/>&nbsp;&nbsp;Insere</b></td>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                        <asp:CheckBox ID="chkDeletaTodos" runat="server" Checked="false"
                                            oncheckedchanged="chkDeletaTodos_CheckedChanged" AutoPostBack="true"/>&nbsp;&nbsp;Deleta</b></td>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                        <asp:CheckBox ID="chkAlteraTodos" runat="server" Checked="false"
                                            oncheckedchanged="chkAlteraTodos_CheckedChanged" AutoPostBack="true"/>&nbsp;&nbsp;Altera</b></td>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:100px;"><b>
                                        <asp:CheckBox ID="chkConsultaTodos" runat="server" Checked="false"
                                            oncheckedchanged="chkConsultaTodos_CheckedChanged" AutoPostBack="true"/>&nbsp;&nbsp;Consulta</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rModulos" runat="server">
                                <ItemTemplate>
                                <tr runat="server" class=<%# Eval("DESCRICAO") == "" ? "gridViewLine2" : "gridViewLine1" %> id="linha">
                                    <td style="padding:1px 5px;" align="left" valign="middle">
                                        <asp:label ID="lblID" CssClass="lb_Inside" Text=<%# Eval("IDMODULO") %> runat="server" visible="false"></asp:label></td>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle"><%# Eval("ARVORE")%></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle"><%# Eval("DESCRICAO")%></td>

                                    <td style="padding:1px 5px;" align="center" valign="middle">
                                        <asp:CheckBox ID="chkInsere" runat="server" Checked=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean(Eval("INSERE")) : Convert.ToBoolean("FALSE") %> Visible=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean("TRUE") : Convert.ToBoolean("FALSE") %> /></td>

                                    <td style="padding:1px 5px;" align="center" valign="middle">
                                        <asp:CheckBox ID="chkDelete" runat="server" Checked=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean(Eval("DELETA")) : Convert.ToBoolean("FALSE") %> Visible=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean("TRUE") : Convert.ToBoolean("FALSE") %> /></td>

                                    <td style="padding:1px 5px;" align="center" valign="middle">
                                        <asp:CheckBox ID="chkAltera" runat="server" Checked=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean(Eval("ALTERA")) : Convert.ToBoolean("FALSE") %> Visible=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean("TRUE") : Convert.ToBoolean("FALSE") %> /></td>

                                    <td style="padding:1px 5px;" align="center" valign="middle">
                                        <asp:CheckBox ID="chkConsulta" runat="server" Checked=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean(Eval("CONSULTA")) : Convert.ToBoolean("FALSE") %> Visible=<%# Eval("DESCRICAO") != "" ? Convert.ToBoolean("TRUE") : Convert.ToBoolean("FALSE") %> /></td>
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            
            <div class="ctn" id="modExcluirPerfil" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="Label1" runat="server" Text="Excluir perfil"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Perfil :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblPerfilExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
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