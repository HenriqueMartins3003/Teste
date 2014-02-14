<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscaMailing.aspx.cs" Inherits="_webPainelVerisys.Mailing.BuscaMailing" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_BuscaMailing" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmBuscaMailing" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside" id=divCampanhaContent runat="server">
        
            <div class="cttTitle"><b>Filtro de Pesquisa</b></div>
            
            <div class="ctn" id="divCampanha" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblMailing" CssClass="lb_Inside" Text="Campanha :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" Width="205px" AutoPostBack="true" onselectedindexchanged="ddlCampaign_SelectedIndexChanged"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblCampo" CssClass="lb_Inside" Text="Campo :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form" Width="205px"></asp:DropDownList>
                        
                    </div>
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblLote" CssClass="lb_Inside" Text="Lote :" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlLote" runat="server" CssClass="form" Width="205px"></asp:DropDownList>
                        <br />
                    
                        <asp:label ID="lblValor" CssClass="lb_Inside" Text="Valor :" runat="server"></asp:label>
                        <asp:TextBox ID="txtValor" CssClass="form" runat="server" Width="200px"></asp:TextBox>
                    </div>
                    
                    <br /><br />
                    <div class="ctnFormHorizontal" style="margin:0px;">
                        <asp:ImageButton ID="buttonImageFilter" runat="server" ImageUrl="~/img/btn-filtrar.gif" onclick="buttonImageFilter_Click" />
                    </div>
                    
                </div>
            </div>
            
        </div>
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
            <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div class="ctn" id="modListaRO" runat="server" visible="true">
                <div class="cttTitle"><b>Registro(s)</b></div>

                <div class="ctt">
                    <div id="ctnLista" runat="server" style="overflow:auto; height:600px" >
                        <asp:GridView ID="gdRegistros" runat="server" Width="100%"
                            onrowdatabound="gdRegistros_RowDataBound">
                        </asp:GridView>
                    </div>
                    
                </div>
            </div>
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>