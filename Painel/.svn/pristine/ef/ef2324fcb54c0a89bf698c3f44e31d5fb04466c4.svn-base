<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GruposDacParametrosPrioridade.aspx.cs" Inherits="_webPainelVerisys.Campanha.GruposDacParametrosPrioridade" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_GruposDacParametrosPrioridade" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmGruposDacParametrosPrioridade" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Parametros do Grupo Dac Prioridades</div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Grupos Dac</b></div>
            
            <div class="ctn" id="divGruposDac" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Grupos Dac :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlGruposDac" runat="server" CssClass="form" 
                            AutoPostBack="true" onselectedindexchanged="ddlGruposDac_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                
                </div>
            </div>
            
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>

            <div class="ctn" id="modGruposDacParametro" runat="server" visible="false">
                <!-- title[1] -->
                <div class="cttTitle"><b>Parametros</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div class="ctt">
                        <asp:Label ID="lblPrioridade" runat="server" Text="Prioridade" CssClass="lb_Inside" Width="300px" ></asp:Label>
                        <asp:DropDownList ID="ddlPrioridade" runat="server" Width="60px" CssClass="form"></asp:DropDownList>
                    </div>
                
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