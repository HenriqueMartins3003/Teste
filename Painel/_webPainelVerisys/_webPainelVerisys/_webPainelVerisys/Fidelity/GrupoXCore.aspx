<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrupoXCore.aspx.cs" Inherits="_webPainelVerisys.Fidelity.GrupoXCore" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_GrupoXCore" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmGrupoXCore" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Grupo X Core</div>

        <!-- content -->
        <div class="contentInside">

            <div class="ctn" id="modListaGrupoXCore" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Grupo X Core Cadastrados</b></div>

                <!-- content[1] -->
                <div class="ctt">
                    <p>
                        <asp:Label ID="lblSearchText" runat="server" Text="Grupo DAC" style="float=right"></asp:Label>
                        <asp:TextBox ID="txtSearchText" runat="server" OnTextChanged="txtSearchText_TextChanged" AutoPostBack="True" />
                     </p>
                    <div id="ctnListaGrupoXCore" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                           AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="10"
                                DataKeyNames="ID, GRUPODAC, CORE, DESCRITIVO"
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
            <div class="ctn" id="modManutencaoGrupoXCore" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo Grupo X Core"></asp:Label></b>
                        <asp:Label ID="lblIDGrupoXCore" runat="server" Text="" Visible="false"></asp:Label></b>
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

                    <asp:label ID="lblGrupoXCore" CssClass="lb_Inside" Text="Grupo DAC" runat="server" Width="150"></asp:label>
                    <asp:TextBox ID="txtGrupoXCore" runat="server" CssClass="form" Width="100"></asp:TextBox>

                    <br />

                    <asp:label ID="lblCore" CssClass="lb_Inside" Text="Core" runat="server" Width="150"></asp:label>
                    <asp:DropDownList ID="ddlCore" runat="server" CssClass="form"></asp:DropDownList>

                    <br /><br />

                </div>
            </div>
            
            <div class="ctn" id="modExcluirGrupoXCore" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="Label1" runat="server" Text="Excluir Grupo X Core"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Grupo X Core :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblGrupoXCoreExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
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




 <div id="modLista" runat="server" class="contentDefault" style="height: auto; width: 99%;
                padding: 0; margin: 0 auto; overflow: auto;" visible="false">
                <div class="btnPesquisar">
                        <asp:TextBox ID="txtFilter" runat="server" Visible="false" OnTextChanged="txtFilter_TextChanged" AutoPostBack="True" ></asp:TextBox>
                        <asp:ImageButton ID="btnPesquisar" runat="server" ImageUrl="~/Images/finder.png"
                            Height="16px" Width="16px" OnClick="btnPesquisar_Click"
                            ToolTip="Pesquisar" Visible="false" Style="vertical-align: middle" />
                    </div>
                    <p>&nbsp;</p>
                    <div class="clear"></div>