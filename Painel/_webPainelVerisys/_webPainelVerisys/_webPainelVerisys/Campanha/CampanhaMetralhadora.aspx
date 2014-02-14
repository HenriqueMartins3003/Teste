<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaMetralhadora.aspx.cs" Inherits="_webPainelVerisys.Campanha.CampanhaMetralhadora" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_CampanhasCanais" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmCampanhasCanais" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Parametros de Canais</div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Grupos</b></div>
            
            <div class="ctn" id="divGrupos" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblGrupos" CssClass="lb_Inside" Text="Grupos :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlGrupos_SelectedIndexChanged"  ></asp:DropDownList>
                    </div>
                
                </div>
            </div>
            
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>

            <div class="ctn" id="modCampanha" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Campanhas Metralhadora</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <table cellpadding="0" cellspacing="0" border="0" class="odd" width="100%">
                        <thead style="background:#F1F1F1;">
                            <tr>
                                <td align="left" valign="middle" style="padding:5px 3px; width:50px;"><b>Campanha</b></td>
                                
                                <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Nome</b></td>
                                
                                <td align="left" valign="middle" style="padding:5px 3px; width:150px;"><b>Canais</b></td>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="rModulos" runat="server">
                            <ItemTemplate>
                            <tr>
                                <td style="padding:5px 5px;" align="left" valign="middle">
                                    <asp:Label ID="lblID" runat="server" Width="50px" Text=<%# Eval("Campaign") %> /></td>
                                
                                <td style="padding:5px 5px;" align="left" valign="middle"><%# Eval("NomeCampanha")%></td>

                                <td style="padding:5px 5px;" align="left" valign="middle">
                                    <asp:TextBox ID="txtMeta" runat="server" CssClass="form" Width="50px" Text=<%# Eval("MetaCanaisSimultaneosEmAtendimento") %> /></td>
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                
                    <br /><br />
                    
                    <asp:label ID="lblCanaisMaximo" CssClass="lb_Inside" Text="Max Canais" Width="120" runat="server"></asp:label>
                    <asp:TextBox ID="txtCanaisMaximo" runat="server" CssClass="form" Width="50" Enabled="false"></asp:TextBox>
                    <br />
                    
                    <asp:label ID="lblCanaisUtilizados" CssClass="lb_Inside" Text="Canais Utilizados" Width="120" runat="server"></asp:label>
                    <asp:TextBox ID="txtCanaisUtilizados" runat="server" CssClass="form" Width="50" Enabled="false"></asp:TextBox>
                
                </div>
                <br /><br />
                
                <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-salvar.gif" OnClick="Manager_Click"/>&nbsp;
                <asp:ImageButton ID="buttonImageLimpar" runat="server" ImageUrl="~/img/btn-limpar.gif" OnClick="buttonImageLimpar_Click"/>    
                
            </div>
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>