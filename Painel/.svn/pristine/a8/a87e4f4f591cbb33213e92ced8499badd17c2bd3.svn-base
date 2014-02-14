<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaModulo.aspx.cs" Inherits="_webPainelVerisys.Campanha.CampanhaModulo" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_CampanhaModulo" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmCampanhaModulo" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Campanhas X Modulos</div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Campanhas</b></div>
            
            <div class="ctn" id="divCampanha" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlCampaign_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                
                </div>
            </div>
            
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>

            <div class="ctn" id="modCampanhaModulo" runat="server" visible="false">
                <!-- title[1] -->
                <div class="cttTitle"><b>Modulos</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div class="ctt">
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:50px;"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Nome Modulo</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Modulo</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:50px;"><b>Acesso</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rModulos" runat="server">
                                <ItemTemplate>
                                <tr runat="server" class="gridViewValues1" id="linha">
                                    <td style="padding:1px 5px;" align="left" valign="middle">
                                        <asp:label ID="lblID" CssClass="lb_Inside" Text=<%# Eval("IDMODULO") %> runat="server"></asp:label></td>
                                    
                                    <td style="padding:1px 5px;" align="left" valign="middle">
                                        <asp:label ID="lblNomeModulo" CssClass="lb_Inside" Text=<%# Eval("NOMEMODULO") %> runat="server"></asp:label></td>
                                        
                                    <td style="padding:1px 5px;" align="left" valign="middle"><%# Eval("DESCRICAO")%></td>

                                    <td style="padding:1px 5px;" align="center" valign="middle">
                                        <asp:CheckBox ID="chkAcesso" runat="server" Checked=<%# Eval("ACESSO").ToString() == "1" ? Convert.ToBoolean("TRUE") : Convert.ToBoolean("FALSE") %> /></td>
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                
                </div>
                <br /><br />
                
                <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-salvar.gif" onclick="Manager_Click" />&nbsp;
                <asp:ImageButton ID="buttonImageLimpar" runat="server" ImageUrl="~/img/btn-limpar.gif" onclick="buttonImageLimpar_Click" />    
                
            </div>
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>