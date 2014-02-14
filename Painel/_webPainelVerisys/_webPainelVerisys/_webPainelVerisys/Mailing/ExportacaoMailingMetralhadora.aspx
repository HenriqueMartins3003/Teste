<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportacaoMailingMetralhadora.aspx.cs" Inherits="_webPainelVerisys.Mailing.ExportacaoMailingMetralhadora" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ExportacaoMailingMetralhadora" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmExportacaoMailingMetralhadora" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Campanhas</b></div>
            
            <div class="ctn" id="divCampanha" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlCampaign_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblLote" CssClass="lb_Inside" Text="Lote :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlLote" runat="server" CssClass="form"></asp:DropDownList>
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

                    <div class="ctt" style="width:350px; float:left">
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:25px"><b>Seleção</b></td>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:25px"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:200px"><b>Status</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rStatus" runat="server" onitemdatabound="rStatus_ItemDataBound">
                                <ItemTemplate>
                                <tr runat="server" id="linha" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    <td style="padding:1px 5px;" align="center" valign="middle" CssClass="gridViewValues1" >
                                        <asp:CheckBox ID="chkAcesso" runat="server" style="width:50px" Checked="False" /></td>
                                    
                                    <td style="padding:1px 5px;" align="center" valign="middle" >
                                        <asp:label ID="lblColunaID" CssClass="lb_Inside" style="width:50px" Text=<%# Eval("ID") %> runat="server"></asp:label></td>
                                        
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:label ID="lblColuna" CssClass="lb_Inside" style="width:300px" Text=<%# Eval("DESCRICAO") %> runat="server"></asp:label></td>
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    
                    <div class="ctt" style="width:350px; float:right">
                        <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                            <thead class="gridViewHeader">
                                <tr>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:25px"><b>Seleção</b></td>
                                    <td align="center" valign="middle" style="padding:5px 3px; width:25px"><b>ID</b></td>
                                    <td align="left" valign="middle" style="padding:5px 3px; width:200px"><b>Motivo</b></td>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="rMotivo" runat="server" onitemdatabound="rMotivo_ItemDataBound">
                                <ItemTemplate>
                                <tr runat="server" id="Tr1" class='<%# Container.ItemIndex % 2 == 0 ? "gridViewValues1" : "gridViewValues1a" %>'>
                                    <td style="padding:1px 5px;" align="center" valign="middle" CssClass="gridViewValues1" >
                                        <asp:CheckBox ID="chkAcessoMotivo" runat="server" style="width:50px" Checked="False" /></td>
                                    
                                    <td style="padding:1px 5px;" align="center" valign="middle" >
                                        <asp:label ID="lblColunaIDMotivo" CssClass="lb_Inside" style="width:50px" Text=<%# Eval("IDRO") %> runat="server"></asp:label></td>
                                        
                                    <td style="padding:1px 5px;" align="left" valign="middle" >
                                        <asp:label ID="lblColunaMotivo" CssClass="lb_Inside" style="width:300px" Text=<%# Eval("DESCRICAORO") %> runat="server"></asp:label></td>
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