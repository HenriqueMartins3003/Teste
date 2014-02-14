<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RessubmissaoMailing.aspx.cs" Inherits="_webPainelVerisys.Mailing.RessubmissaoMailing" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportacaoLotes" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmRessubmissaoMailing" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside" id=divParametros runat="server">
        
            <div class="cttTitle"><b>Parâmetros de Busca</b></div>
            
            <div class="ctn" id="divOpcoes" runat="server">
                <div class="ctt">
                
                    <div class="ctnFormHorizontal">

                        <asp:label ID="lblCampanha" CssClass="lb_Inside" Text="Campanha" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" ></asp:DropDownList>
                        <br />

                        <asp:Label ID="lblOpcoes" class="lb_Inside" Width="150px" runat="server" Text="Opções de Busca"></asp:Label>
                        <asp:RadioButtonList ID="rbOpcoes" runat="server" RepeatDirection="Horizontal" 
                            AutoPostBack="true" onselectedindexchanged="rbOpcoes_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Lote&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Registro&nbsp;&nbsp" ></asp:ListItem>
                            <asp:ListItem Value="2" Text="Telefone&nbsp;&nbsp" ></asp:ListItem>
                        </asp:RadioButtonList>
                        
                    </div>
                    <br /><br />
                    
                    <div class="ctt" id="divLote" runat="server" visible="false">
                        <div class="ctnFormHorizontal">
                            <asp:label ID="lblLote" CssClass="lb_Inside" Text="Lote" runat="server"></asp:label>
                            <asp:DropDownList ID="ddlLote" runat="server" CssClass="form"></asp:DropDownList>
                        </div>
                    </div>
                    
                    <div class="ctt" id="divRegistro" runat="server" visible="false">
                        <div class="ctnFormHorizontal">
                            <asp:label ID="lblRegistroID" CssClass="lb_Inside" Text="Registro" runat="server"></asp:label>
                            <asp:TextBox ID="txtRegistroID" CssClass="form" runat="server"  Text="" Width="95px"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="ctt" id="divTelefone" runat="server" visible="false">
                        <div class="ctnFormHorizontal">
                            <asp:label ID="lblDDDTelefone" CssClass="lb_Inside" Text="Telefone" runat="server"></asp:label>
                            <asp:TextBox ID="txtDDD" CssClass="form" runat="server" Text="" MaxLength="2" Width="20px"></asp:TextBox>
                            <asp:TextBox ID="txtTelefone" CssClass="form" runat="server" Text="" MaxLength="9" Width="70px"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    
                    <asp:ImageButton ID="buttonImageFiltrar" runat="server" 
                        ImageUrl="~/img/btn-filtrar.gif" Visible="false" 
                        onclick="buttonImageFiltrar_Click" />
                </div>
            </div>
        </div>

        <!-- content -->
        <div class="contentInside"  id=divContent visible="true" runat="server">

            <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </div>
        
            <div class="ctn" id="modLista" runat="server" visible="false">
                <!-- title[1] -->
                <div class="cttTitle"><b>Registros Encontrados</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="false"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="false"
                                PageSize="20"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="RegistroID, StatusRegistro, StatusLot"
                                onrowcommand="gdRegistros_RowCommand"
                                onrowdatabound="gdRegistros_RowDataBound" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <!-- content -->
            <div id="modDadosRegistro" class="ctt" runat="server" visible="false">
            
                <asp:Label ID="lblIDCampanha" runat="server" class="lb_TB" Width="100px" Text="Campanha"></asp:Label>
                <asp:TextBox ID="txtIDCampanha" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                <br/>

                <asp:Label ID="lblStatus" runat="server" class="lb_TB" Width="100px"  Text="Status"></asp:Label>
                <asp:TextBox ID="txtStatus" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                <br />

                <asp:Label ID="lblMotivo" runat="server" class="lb_TB" Width="100px" Text="Motivo"></asp:Label>
                <asp:TextBox ID="txtMotivo" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                <br />

                <asp:Label ID="lblTentativas" runat="server" class="lb_TB" Width="100px" Text="Tentativas"></asp:Label>
                <asp:TextBox ID="txtTentativas" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                <br />
                
                <asp:Label ID="lblReagendamento" runat="server" class="lb_TB" Width="100px" Text="Regendamento"></asp:Label>
                <asp:TextBox ID="txtReagendamento" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                <br />
                
                <asp:Label ID="lblAgente" runat="server" class="lb_TB" Width="100px" Text="Agente"></asp:Label>
                <asp:TextBox ID="txtAgente" runat="server" Enabled="False" CssClass="form"></asp:TextBox>
                <br />
                
                <asp:Label ID="Label1" runat="server" class="lb_TB" Width="100px" Text="Flag Ativo"></asp:Label>
                <asp:CheckBox ID="cbFlagAtivo" runat="server" Enabled="False"/>
                <br /><br />
                
                <asp:Label ID="Label2" runat="server" class="lb_TB" Width="100px" Text="Lote Ativo"></asp:Label>
                <asp:CheckBox ID="cbLoteAtivo" runat="server" Enabled="False"/>
                <br /><br />
                
                <asp:Label ID="lblDdd1" runat="server" class="lb_TB" Width="100px" Text="Telefone 1"></asp:Label>
                <asp:TextBox ID="txtDdd1" runat="server" Enabled="False" CssClass="form" MaxLength="2" Width="20px" ></asp:TextBox>
                <asp:TextBox ID="txtFone1" runat="server" Enabled="False" CssClass="form" MaxLength="9" Width="70px" ></asp:TextBox>
                <br />
                
                <asp:Label ID="lblDdd2" runat="server" class="lb_TB" Width="100px" Text="Telefone 2"></asp:Label>
                <asp:TextBox ID="txtDdd2" runat="server" Enabled="False" CssClass="form" MaxLength="2" Width="20px"></asp:TextBox>
                <asp:TextBox ID="txtFone2" runat="server" Enabled="False" CssClass="form" MaxLength="9" Width="70px"></asp:TextBox>
                <br />
                
                <asp:Label ID="lblDdd3" runat="server" class="lb_TB" Width="100px" Text="Telefone 3"></asp:Label>
                <asp:TextBox ID="txtDdd3" runat="server" Enabled="False" CssClass="form" MaxLength="2" Width="20px"></asp:TextBox>
                <asp:TextBox ID="txtFone3" runat="server" Enabled="False" CssClass="form" MaxLength="9" Width="70px"></asp:TextBox>
                <br />
                
                <asp:Label ID="lblDdd4" runat="server" class="lb_TB" Width="100px" Text="Telefone 4"></asp:Label>
                <asp:TextBox ID="txtDdd4" runat="server" Enabled="False" CssClass="form" MaxLength="2" Width="20px"></asp:TextBox>
                <asp:TextBox ID="txtFone4" runat="server" Enabled="False" CssClass="form" MaxLength="9" Width="70px"></asp:TextBox>
                <br />
                
                <asp:Label ID="lblDdd5" runat="server" class="lb_TB" Width="100px" Text="Telefone 5"></asp:Label>
                <asp:TextBox ID="txtDdd5" runat="server" Enabled="False" CssClass="form" MaxLength="2" Width="20px"></asp:TextBox>
                <asp:TextBox ID="txtFone5" runat="server" Enabled="False" CssClass="form" MaxLength="9" Width="70px"></asp:TextBox>
            
            </div>

            <div class="ctn" id="modManutencao" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Ressubmissão de Mailing"></asp:Label></b>
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
                <div id="modStatusMotivos" class="ctt" runat="server" visible="false">

                    <div style="float:left;">
                        <asp:Label ID="lblStatusLote" runat="server" Text="Status Atual Registro (( Qtde - (Origem : Status) - Motivo ))"></asp:Label>
                        <br />
                        <asp:ListBox ID="lbStatusLote" runat="server" SelectionMode="Single" CssClass="form" Width="750" Rows="10"></asp:ListBox>
                    </div>
                    <br />
                    <div style="float:left;">                
                        <asp:Label ID="lblStatusLoteNovo" runat="server" Text="Novo Status do Registro"></asp:Label>
                        <br />
                        <asp:ListBox ID="lbStatusLoteNovo" runat="server" SelectionMode="Single" CssClass="form" Width="750" Rows="10" AutoPostBack="true" 
                            onselectedindexchanged="lbStatusLoteNovo_SelectedIndexChanged" ></asp:ListBox>
                    </div>
                </div>    
                <br />
                
                <div id="modStatusMotivosComplemento" class="ctt" runat="server" visible="true">
                    
                    <asp:Label ID="Label3" runat="server" class="lb_TB" Width="250px" Text="Retorna Discagem para Primeiro Telefone ? "></asp:Label>
                    <asp:CheckBox ID="chkZeraIndiceCampoFone" runat="server"/>
                    <br /><br />
                    
                    <asp:Label ID="Label4" runat="server" class="lb_TB" Width="250px" Text="Zera número de Tentativas ?"></asp:Label>
                    <asp:CheckBox ID="chkZeraTentativas" runat="server"/>
                    <br /><br />
                    
                </div>
                
                <div id="modReagendamento" visible="false" runat="server">
                
                    <fieldset class="ctt">
                
                        <div class="ctnInsideModules">
                            <asp:Label ID="lblDataReagendamento" runat="server" class="lb_TB" Width="200px">Data Reagendamento</asp:Label>
                            <br /><br />
                            <asp:Calendar ID="calReagendamento" runat="server"></asp:Calendar>
                        </div>
                    
                        <div class="ctnInsideModules">
                            <div class="clear"></div>
                            <br /><br />
                            <asp:Label ID="lblHoraReagendamento" runat="server" class="lb_TB" Width="150px">Hora Reagendamento</asp:Label>
                            <asp:DropDownList ID="ddlHora" runat="server" CssClass="form" ></asp:DropDownList>
                            <asp:DropDownList ID="ddlMinuto" runat="server" CssClass="form" ></asp:DropDownList>
                            <br /><br />
                            <asp:Label ID="lblReagTelefone" runat="server" class="lb_TB" Width="150px">Telefone</asp:Label>
                            <asp:TextBox ID="txtReagDDD" runat="server" CssClass="form" MaxLength="2" Width="30px"></asp:TextBox>
                            <asp:TextBox ID="txtReagTelefone" runat="server" CssClass="form" MaxLength="8" Width="80px"></asp:TextBox>
                        </div>
                    
                    </fieldset>
                </div>

                <br />
                <asp:ImageButton ID="buttonImageSalvar" runat="server" ImageUrl="~/img/btn-salvar.gif" onclick="buttonImageSalvar_Click" />
                <br /><br />
                
                <div id="divConfirmacao" class="ctt" runat="server" visible="false">
                    <center>
                        <asp:Label ID="lblMessageConfirmation" runat="server" text="Confirma a ressubmissão do(s) registro(s) selecionados ? "></asp:Label>
                        <br />
                        <asp:ImageButton ID="buttonImageSalvarConfirmacao" runat="server" ImageUrl="~/img/btn-salvar.gif" OnClick="Manager_Click" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="buttonImageCancelarConfirmacao" runat="server" 
                            ImageUrl="~/img/btn-cancelar.gif" 
                            onclick="buttonImageCancelarConfirmacao_Click"/>
                    </center>
                </div>
                
            </div>
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>