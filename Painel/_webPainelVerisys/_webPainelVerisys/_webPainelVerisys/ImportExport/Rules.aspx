<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="_webPainelVerisys.ImportExport.Rules"
    MasterPageFile="~/MP.Master" %>

<asp:Content ID="cph_ImportExportRules" runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <form id="frmImportExportRules" runat="server">
    <div class="containerInside">
        <asp:scriptmanager id="ScriptManager" runat="server" enablescriptglobalization="true"
            enablescriptlocalization="true">
        </asp:scriptmanager>
        <asp:updatepanel id="UpPanel" runat="server">
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
                                DataKeyNames="RulesID, RulesName, Campaign, LotStatus, LotStatusDescription, RegistryStatus, RegistryStatusDescription, 
                                              CheckRaw, CheckRawDescription, RulesStatus, RulesStatusDescription, OldLotStatus"
                                onrowcommand="gdRegistros_RowCommand"
                                onsorting="gdRegistros_Sorting"
                                onpageindexchanging="gdRegistros_PageIndexChanging" 
                            onrowdatabound="gdRegistros_RowDataBound"
                            onrowcreated="gdRegistros_RowCreated" >
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
                <div id="Div1" class="ctt" runat="server" style="line-height:18px;">

                        
                    <div id="Div3" class="contentBoxListsContentL" runat="server" style=" border:0px">
                    <p>
                        <asp:label ID="lblRulesName" CssClass="lb_Inside" Text="Nome" runat="server" Width="110" ></asp:label>
                        <asp:TextBox ID="txtRulesName" runat="server" CssClass="form" Width="180" MaxLength="50" ></asp:TextBox>
                       </p> 
                        <p>
                        <asp:label ID="lblCampaign" CssClass="lb_Inside" Text="Campanha(s)" runat="server" Width="110" ></asp:label>                       
                        <asp:ListBox ID="lstCampaign" runat="server" CssClass="form" Width="180" MaxLength="180" SelectionMode="Multiple" AutoPostBack="True"></asp:ListBox>
                        
                        
                        </p>
                                
                   <%--<asp:label ID="lblDefault" CssClass="lb_Inside" Text="Default" runat="server" Width="110" ToolTip="Texto padrão para campos vazios"></asp:label>
                        <asp:TextBox ID="txtDefault" runat="server" CssClass="form" Width="180" MaxLength="180" ></asp:TextBox>
                        <br />--%>
                        <p>
                        
                          <asp:label ID="lblOldLotStatus" CssClass="lb_Inside" Text="Desabilitar lote(s) anterior(es) ?" runat="server" Width="110" ></asp:label>
                        <asp:DropDownList ID="ddlOldLotStatus" runat="server" CssClass="form" Width="110">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                       
                       </p>          
                    </div>
                    <div id="Div4" class="contentBoxListsContentR" runat="server" style=" border:0px">
                    <p>
                      <asp:label ID="lblLotStatus" CssClass="lb_Inside" Text="Lote Ativo?" runat="server" Width="110" ></asp:label>
                        <asp:DropDownList ID="ddlLotStatus" runat="server" CssClass="form" Width="110">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                       
                        <p>
                        <asp:label ID="lblRegistryStatus" CssClass="lb_Inside" Text="Registro Ativo?" runat="server" Width="110" ></asp:label>
                        <asp:DropDownList ID="ddlRegistryStatus" runat="server" CssClass="form" Width="110">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                        </p>
                        
                        <p>
                            <asp:label ID="lblCheckRaw" CssClass="lb_Inside" Text="Valida Arquivo?" runat="server" Width="110" ></asp:label>
                        <asp:DropDownList ID="ddlCheckRaw" runat="server" CssClass="form" Width="110">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                        </p>
                 
                 <p>
                        <asp:label ID="lblRulesStatus" CssClass="lb_Inside" Text="Ativo ?" runat="server" Width="110" ></asp:label>
                        <asp:DropDownList ID="ddlRulesStatus" runat="server" CssClass="form" Width="110">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                 </p>
                    </div>
                    
                    <div class="clear"></div>
                    
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
        </asp:updatepanel>
    </div>
    </form>
</asp:Content>
