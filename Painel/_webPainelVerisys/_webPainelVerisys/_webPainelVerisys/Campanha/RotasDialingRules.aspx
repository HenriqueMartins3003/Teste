<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RotasDialingRules.aspx.cs" Inherits="_webPainelVerisys.Campanha.RotasDialingRules" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_RotasDialingRules" runat="server" ContentPlaceHolderID="ContentPlaceHolder">


<form id="frmRotasDialingRules" runat="server">
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
                                DataKeyNames="Id, idRule, TrunkGroup, PhoneType, PhoneTypeDescription, PhoneClassification, PhoneClassificationDescription, Priority"
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
                    <asp:label ID="lblRuleName" CssClass="lb_Inside" Text="Rule" runat="server" Width="100"></asp:label>
                    <asp:DropDownList ID="ddlRuleName" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                    <br />

                    <asp:label ID="lblTrunkGroup" CssClass="lb_Inside" Text="Rota" runat="server" Width="100"></asp:label>
                    <asp:DropDownList ID="ddlTrunkGroup" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                    <br />

                    <asp:label ID="lblPhoneType" CssClass="lb_Inside" Text="Tipo" runat="server" Width="100"></asp:label>
                    <asp:DropDownList ID="ddlPhoneType" runat="server" CssClass="form" Width="205" 
                        onselectedindexchanged="ddlPhoneType_SelectedIndexChanged" autopostback="true"></asp:DropDownList>
                    <br />

                    <asp:label ID="lblPhoneClassification" CssClass="lb_Inside" Text="Classificação" runat="server" Width="100"></asp:label>
                    <asp:DropDownList ID="ddlPhoneClassification" runat="server" CssClass="form" 
                        Width="205" 
                        onselectedindexchanged="ddlPhoneClassification_SelectedIndexChanged" autopostback="true"></asp:DropDownList>
                    <br />

                    <asp:label ID="lblPriority" CssClass="lb_Inside" Text="Prioridade" runat="server" Width="100"></asp:label>
                    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form" Width="205"></asp:DropDownList>

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