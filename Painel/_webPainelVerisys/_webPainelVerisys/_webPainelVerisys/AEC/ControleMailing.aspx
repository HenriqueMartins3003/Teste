<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControleMailing.aspx.cs" Inherits="_webPainelVerisys.AEC.ControleMailing" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ControleMailing" runat="server" ContentPlaceHolderID="ContentPlaceHolder">
<form id="frmControleMailing" runat="server">
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

            <div class="contentInside" id=divCampanhaContent runat="server">
                <div class="cttTitle"><b>Campanhas</b></div>
                
                <div class="ctn" id="divCampanha" runat="server">
                    <div class="ctt">
                    
                        <div class="ctnFormHorizontal">
                            <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                            <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" ></asp:DropDownList>
                        </div>
                    
                    </div>
                </div>
                
            </div>

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>

            <!-- profile -->
            <div class="ctn" visible="true" runat="server">

                <div class="containerBox" id="boxStatusProdutos" runat="server">
                    <div class="titleBox">Status Produtos</div>
                    <div class="contentBox" style="overflow:auto;">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rStatusProdutos" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr1" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDStatusProdutos"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroStatusProdutos"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkStatusProdutos" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <div class="containerBox" id="boxStatusdaDivida" runat="server">
                    <div class="titleBox">Status da Dívida</div>
                    <div class="contentBox" style="overflow:auto">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rStatusdaDivida" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr2" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDStatusdaDivida"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroStatusdaDivida"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkStatusdaDivida" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <br />
                
                <div class="containerBox" id="boxFlagCampanha" runat="server">
                    <div class="titleBox">Flag Campanha</div>
                    <div class="contentBox" style="overflow:auto;">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rFlagCampanha" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr3" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDFlagCampanha"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroFlagCampanha"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkFlagCampanha" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <div class="containerBox" id="boxCobrador" runat="server">
                    <div class="titleBox">Cobrador</div>
                    <div class="contentBox" style="overflow:auto">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rCobrador" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr4" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDCobrador"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroCobrador"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkCobrador" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <br />
                
                <div class="containerBox" id="boxCredor" runat="server">
                    <div class="titleBox">Credor</div>
                    <div class="contentBox" style="overflow:auto;">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rCredor" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr5" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDCredor"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroCredor"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkCredor" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <div class="containerBox" id="boxTipodetelefone" runat="server">
                    <div class="titleBox">Tipo de telefone</div>
                    <div class="contentBox" style="overflow:auto">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rTipodetelefone" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr6" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDTipodetelefone"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroTipodetelefone"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkTipodetelefone" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <br />
                
                <div class="containerBox" id="boxFila" runat="server">
                    <div class="titleBox">Fila</div>
                    <div class="contentBox" style="overflow:auto;">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rFila" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr7" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDFila"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroFila"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkFila" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <div class="containerBox" id="boxGrupodeCobrador" runat="server">
                    <div class="titleBox">Grupo de Cobrador</div>
                    <div class="contentBox" style="overflow:auto">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rGrupodeCobrador" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr8" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDGrupodeCobrador"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroGrupodeCobrador"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkGrupodeCobrador" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
                </div>
                
                <br />
                
                <div class="containerBox" id="boxProdutos" runat="server">
                    <div class="titleBox">Produtos</div>
                    <div class="contentBox" style="overflow:auto;">
                    
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Filtro</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:25px;"><b>Seleção</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rProdutos" runat="server">
                                <ItemTemplate>
                                <tr runat="server" id="Tr9" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblIDProdutos"  Text=<%# Eval("FiltroID") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" CssClass = "gridViewValues1">
                                        <asp:label ID="lblFiltroProdutos"  Text=<%# Eval("FiltroName") %> runat="server"></asp:label></td>
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:CheckBox ID="chkProdutos" runat="server" /></td>
                                
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    
                    </div>
                
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