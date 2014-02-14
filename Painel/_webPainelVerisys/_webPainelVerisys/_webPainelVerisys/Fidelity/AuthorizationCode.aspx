<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorizationCode.aspx.cs" Inherits="_webPainelVerisys.Exclusive.Fidelity.AuthorizationCode" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_AuthorizationCode" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmAuthorizationCode" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Authorization Code</div>

        <!-- content -->
        <div class="contentInside">

            <div class="ctn" id="modListaAuthorizationCode" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Authorization Codes Cadastrados</b></div>

                <!-- content[1] -->
                <div class="ctt">

                    <div id="ctnListaAuthorizationCode" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="True"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="True"
                                PageSize="50"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                DataKeyNames="ID_AUTHORIZATIONCODE, AUTHCODE, CORE, DESCRITIVO"
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
            <div class="ctn" id="modManutencaoAuthorizationCode" visible="true" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo Authorization Code"></asp:Label></b>
                        <asp:Label ID="lblIDAuthorizationCode" runat="server" Text="" Visible="false"></asp:Label></b>
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

                    <asp:label ID="lblAuthorizationCode" CssClass="lb_Inside" Text="Authorization Code" runat="server" Width="150"></asp:label>
                    <asp:TextBox ID="txtAuthorizationCode" runat="server" CssClass="form" Width="100"></asp:TextBox>

                    <br />

                    <asp:label ID="lblCore" CssClass="lb_Inside" Text="Core" runat="server" Width="150"></asp:label>
                    <asp:DropDownList ID="ddlCore" runat="server" CssClass="form"></asp:DropDownList>

                    <br /><br />

                </div>
            </div>
            
            <div class="ctn" id="modExcluirAuthorizationCode" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="Label1" runat="server" Text="Excluir Authorization Code"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do AuthorizationCode :" runat="server"></asp:label>
                    <br /><br />
                    <asp:label ID="lblAuthorizationCodeExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
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