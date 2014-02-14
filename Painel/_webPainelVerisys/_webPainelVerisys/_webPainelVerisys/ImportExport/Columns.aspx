<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Columns.aspx.cs" Inherits="_webPainelVerisys.ImportExport.Columns" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportExportColumns" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportExportColumns" runat="server">
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
                                DataKeyNames="ColumnID, RegistryID, RegistryHeaderID, RegistryTrailerID, ColumnName, InitialPosition, ColumnSize, ColumnNumber,
                                              ColumnTypeID,  ColumnValidation, ColumnStatusDescription, DatabaseColumn, ColumnJoin,
                                              TextAlign, TextComplement, DefaultValue, DefaultMandatory, TableID"
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

                    <div id="Div3" class="contentBoxListsContentL" runat="server" style="height:150px; border:0px">
                        
                        <asp:label ID="lblColumnName" CssClass="lb_Inside" Text="Nome" Width="100" runat="server"></asp:label>
                        <asp:TextBox ID="txtColumnName" runat="server" CssClass="form" Width="200" MaxLength="100" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblInitialPosition" CssClass="lb_Inside" Text="Posição Inicial" Width="100" runat="server"></asp:label>
                        <asp:TextBox ID="txtInitialPosition" runat="server" CssClass="form" Width="30" MaxLength="12" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblColumnSize" CssClass="lb_Inside" Text="Tamanho" Width="100" runat="server"></asp:label>
                        <asp:TextBox ID="txtColumnSize" runat="server" CssClass="form" Width="30" MaxLength="12" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblColumnNumber" CssClass="lb_Inside" Text="Nº Coluna" Width="100" runat="server"></asp:label>
                        <asp:TextBox ID="txtColumnNumber" runat="server" CssClass="form" Width="30" MaxLength="12" ></asp:TextBox>
                        <br />
                        
                    </div>
                    
                    <div id="Div4" class="contentBoxListsContentR" runat="server" style="height:150px; border:0px">
                        
                        <asp:label ID="lblDatabaseTable" CssClass="lb_Inside" Text="Tabela BD" Width="100" runat="server"></asp:label>
                        <asp:TextBox ID="txtDatabaseTable" runat="server" CssClass="form" Width="200" MaxLength="200" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblDatabaseColumn" CssClass="lb_Inside" Text="Coluna BD" Width="100" runat="server"></asp:label>
                        <asp:TextBox ID="txtDatabaseColumn" runat="server" CssClass="form" Width="200" MaxLength="200" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblColumnTypeID" CssClass="lb_Inside" Text="Tipo" Width="100" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlColumnTypeID" runat="server" CssClass="form" Width="200"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblColumnValidation" CssClass="lb_Inside" Text="Valida?" Width="100" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlColumnValidation" runat="server" CssClass="form" Width="200">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblColumnStatus" CssClass="lb_Inside" Text="Ativo?" Width="100" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlColumnStatus" runat="server" CssClass="form" Width="200">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    
                    </div>
                    
                    <br /><br />
                    
                    <div id="Div5" class="contentBoxListsContentL" runat="server" style="height:100px; border:0px;">
                    
                        <small>Exclusivo Exportação</small>
                        <br />
                        
                        <asp:label ID="lblColumnJoin" CssClass="lb_Inside" Text="Join?" Width="100" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlColumnJoin" runat="server" CssClass="form" Width="200">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblTextAlign" CssClass="lb_Inside" Text="Alinhamento" Width="100" runat="server"></asp:label>
                        <asp:DropDownList ID="ddlTextAlign" runat="server" CssClass="form" Width="200">
                            <asp:ListItem Value="R" Text="Direita"></asp:ListItem>
                            <asp:ListItem Value="L" Text="Esquerda"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblTextComplement" CssClass="lb_Inside" Text="Preenchimento" Width="100" runat="server"></asp:label>
                        <asp:TextBox ID="txtTextComplement" runat="server" CssClass="form" Width="30" MaxLength="1" ></asp:TextBox>
                        <br />
                        
                        
                    </div>
                    
                
                        <asp:label ID="lblDefaultValue" CssClass="lb_Inside" Text="Valor Default" Width="100" runat="server" visible="false"></asp:label>
                        <asp:TextBox ID="txtDefaultValue" runat="server" CssClass="form" Width="200" MaxLength="200"  visible="false"></asp:TextBox>
                        
                        <asp:label ID="lblDefaultMandatory" CssClass="lb_Inside" Text="Mandatório?" Width="100" runat="server" visible="false"></asp:label>
                        <asp:DropDownList ID="ddlDefaultMandatory" runat="server" CssClass="form" Width="200" visible="false">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                    
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