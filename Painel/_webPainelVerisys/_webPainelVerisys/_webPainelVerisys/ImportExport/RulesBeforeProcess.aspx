<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RulesBeforeProcess.aspx.cs" Inherits="_webPainelVerisys.ImportExport.RulesBeforeProcess" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportExportRulesBeforeProcess" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportExportRulesBeforeProcess" runat="server">
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

            <div class="ctn" id="modLista" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Cadastrados</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="50"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="RulesID, RulesName, ProcessID, ProcessName, Campaign, DisableAncientID, DisableAncientIDDescription, RulesStatus, RulesStatusDescription"
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
            <div class="ctn" id="modManutencao" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastro"></asp:Label></b>
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

                    <asp:label ID="lblRulesName" CssClass="lb_Inside" Text="Nome" runat="server" Width="100" ></asp:label>
                    <asp:TextBox ID="txtRulesName" runat="server" CssClass="form" Width="200" MaxLength="200" ></asp:TextBox>
                    <br />
                    
                    <asp:label ID="lblProcessID" CssClass="lb_Inside" Text="Processo" runat="server" Width="100" ></asp:label>
                    <asp:DropDownList ID="ddlProcessID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                    <br />
                    
                    <asp:label ID="lblCampaign" CssClass="lb_Inside" Text="Campanha(s)" runat="server" Width="100" ></asp:label>
                    <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                    <br />
                    
                    <asp:label ID="lblDisableAncientID" CssClass="lb_Inside" Text="Desabilita?" runat="server" Width="100" ></asp:label>
                    <asp:DropDownList ID="ddlDisableAncientID" runat="server" CssClass="form" Width="205">
                        <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                        <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    
                    <asp:label ID="lblRulesStatus" CssClass="lb_Inside" Text="Ativo ?" runat="server" Width="100" ></asp:label>
                    <asp:DropDownList ID="ddlRulesStatus" runat="server" CssClass="form" Width="205">
                        <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                        <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                    </asp:DropDownList>
                    <br /><br />
                    
                    <asp:label ID="lblCampanhasAssociadas" CssClass="lb_Inside" Text="Campanhas Associadas" runat="server" Width="200" ></asp:label>
                    <table cellpadding="0" cellspacing="0" border="0" class="odd" width="60%">
                        <thead class="gridViewHeader">
                            <tr>
                                <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Campanha</b></td>
                                <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Nome</b></td>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="rCampanhasAssociadas" runat="server">
                            <ItemTemplate>
                            <tr runat="server" id="Tr1" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                <td style="padding:1px 5px;" align="left" valign="middle" width="25px" >
                                    <asp:CheckBox ID="chkCampanha" runat="server" /></td>
                                    
                                <td style="padding:1px 5px;" align="left" valign="middle"  width="25px" CssClass = "gridViewValues1">
                                    <asp:label ID="lblIDCampanhaAssociada"  Text=<%# Eval("Campaign") %> runat="server"></asp:label></td>
                                
                                <td style="padding:1px 5px;" align="left" valign="middle"  width="150px" CssClass = "gridViewValues1">
                                    <asp:label ID="lblCampanhaAssociada"  Text=<%# Eval("NomeCampanha") %> runat="server"></asp:label></td>
                            
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    
                </div>
            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="Label1" runat="server" Text="Exclusão"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Registro :" runat="server"></asp:label>
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