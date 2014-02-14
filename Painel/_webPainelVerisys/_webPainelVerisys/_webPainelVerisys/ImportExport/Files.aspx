<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="_webPainelVerisys.ImportExport.Files" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportExportFiles" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportExportFiles" runat="server">
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
                                DataKeyNames="FileID, ProcessID, FileName, FileExtension, FileLocation, FileLocationBackup, FilesTypeID, FileStatus"
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

                    <div id="Div3" class="contentBoxListsContentL" runat="server" style="height:120px; border:0px">

                        <asp:label ID="lblProcessID" CssClass="lb_Inside" Text="Processo" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlProcessID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblFileName" CssClass="lb_Inside" Text="Arquivo" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtFileName" runat="server" CssClass="form" Width="200"></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblFileExtension" CssClass="lb_Inside" Text="Extensão" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtFileExtension" runat="server" CssClass="form" Width="200"></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblFilesTypeID" CssClass="lb_Inside" Text="Tipo" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlFilesTypeID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />

                    </div>
                    
                    <div id="Div4" class="contentBoxListsContentR" runat="server" style="height:120px; border:0px">

                        <asp:label ID="lblFileLocation" CssClass="lb_Inside" Text="Pasta" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtFileLocation" runat="server" CssClass="form" Width="250"></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblFileLocationBackup" CssClass="lb_Inside" Text="Pasta Backup" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtFileLocationBackup" runat="server" CssClass="form" Width="250"></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblFileStatus" CssClass="lb_Inside" Text="Ativo?" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlFileStatus" runat="server" CssClass="form" Width="205">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        
                    </div>
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