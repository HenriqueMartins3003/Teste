<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="_webPainelVerisys.Campanha.Rules" MasterPageFile="~/MP.Master" %>

<asp:Content ID="cph_Rules" runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <form ID="frmNewRule" runat="server">
    <div class="containerInside">
        <asp:scriptmanager ID="ScriptManager" runat="server" enablescriptglobalization="true"
            enablescriptlocalization="true">
        </asp:scriptmanager>
        <asp:updatepanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label ID="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <!-- content -->
        <div class="contentInside">
       
           
            <div class="ctn" ID="modLista" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Cadastrados</b></div>
                <!-- carrega lista de rules -->
                <div class="ctt">

                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                           AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="10"
                                DataKeyNames=" IdRule, Name"
                                onrowcommand="gdRegistros_RowCommand"
                                onsorting="gdRegistros_Sorting"
                                onpageindexchanging="gdRegistros_PageIndexChanging" 
                            onrowdatabound="gdRegistros_RowDataBound" >
                               <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
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
                <div id="Div2" class="ctt" runat="server">
                    <asp:label ID="lblDecricao" CssClass="lb_Inside" Text="Descrição" runat="server" Width="100"></asp:label>
                   <asp:TextBox ID="txtDescricaoRule" runat="server" />
                   <p>
                </p>

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
                <div id="Div3" class="ctt" runat="server">

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
