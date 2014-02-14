<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegmentacaoHistorico.aspx.cs" Inherits="_webPainelVerisys.Mailing.SegmentacaoHistorico" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_SegmentacaoHistorico" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmSegmentacaoHistorico" runat="server">
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
                        <br />
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" ></asp:DropDownList>
                    </div>
                
                    <div class="ctnFormHorizontal">
                        <asp:label ID="lblPeriodo" CssClass="lb_Inside" Text="Periodo :" runat="server"></asp:label>
                        <br />
                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form">
                            <asp:ListItem Value="1" Text="03 dias"></asp:ListItem>
                            <asp:ListItem Value="2" Text="07 dias"></asp:ListItem>
                            <asp:ListItem Value="3" Text="15 dias"></asp:ListItem>
                            <asp:ListItem Value="4" Text="30 dias"></asp:ListItem>
                            <asp:ListItem Value="5" Text="60 dias"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <div class="ctnFormHorizontal" style="margin:0px;">
                        &nbsp;<br />
                        <asp:ImageButton ID="buttonImageFilter" runat="server" 
                            ImageUrl="~/img/btn-filtrar.gif" onclick="buttonImageFilter_Click" />
                    </div>
                    
                </div>
            </div>
            
        </div>
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
        
        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <!-- Lista Perfis <Permissão Função - modListaPerfil> -->
            <div class="ctn" id="modLista" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Histórico</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaTipoRO" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="false"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="false"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                onrowdatabound="gdRegistros_RowDataBound" >
                            <AlternatingRowStyle></AlternatingRowStyle>
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