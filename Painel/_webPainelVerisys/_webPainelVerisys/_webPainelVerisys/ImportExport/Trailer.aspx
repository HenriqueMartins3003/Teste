<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trailer.aspx.cs" Inherits="_webPainelVerisys.ImportExport.Trailer" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportExportTrailer" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportExportTrailer" runat="server">
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
                                DataKeyNames="TrailerID, TrailerName, TrailerSeparator, TrailerLineSize, TrailerStatus, TrailerStatusID"
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

                    <div id="Div3" class="contentBoxListsContentL" runat="server" style="height:80px; border:0px">
                        <asp:label ID="lblTrailerName" CssClass="lb_Inside" Text="Nome" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtTrailerName" runat="server" CssClass="form" Width="200" MaxLength="200" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblTrailerSeparator" CssClass="lb_Inside" Text="Separador" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtTrailerSeparator" runat="server" CssClass="form" Width="30" MaxLength="1" ></asp:TextBox>
                    </div>
                    
                    <div id="Div4" class="contentBoxListsContentR" runat="server" style="height:80px; border:0px">
                        <asp:label ID="lblTrailerLineSize" CssClass="lb_Inside" Text="Tamanho" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtTrailerLineSize" runat="server" CssClass="form" Width="30" MaxLength="12" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblTrailerStatus" CssClass="lb_Inside" Text="Ativo ?" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlTrailerStatus" runat="server" CssClass="form" Width="205">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
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