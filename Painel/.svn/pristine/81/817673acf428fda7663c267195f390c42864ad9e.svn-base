<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScreenCaptureACDList.aspx.cs" Inherits="_webPainelVerisys.Fidelity.ScreenCaptureACDList" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ScreenCaptureACDList" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmScreenCaptureACDList" runat="server">
    <div class="containerInside">

        <asp:ScriptManager ID="ScriptManager" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">Screen Capture ACD List</div>

        <!-- content -->
        <div class="contentInside">

            <div class="ctn" id="modLista" runat="server" visible="true">
                <!-- title[1] -->
                <div class="cttTitle"><b>Grupos DAC Cadastrados</b></div>

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
                                DataKeyNames="ACDGROUP, IDSTATUS, ACTIVATED, PERCENTAGERATE, LASTCHANGE"
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
                        <asp:Label ID="lblTituloDiv" runat="server" Text="Cadastrar novo Grupo DAC"></asp:Label></b>
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

                    <asp:Label ID="lblGrupoDac" class="lb_Inside" runat="server" Width="150" Text="Grupo DAC"></asp:Label>
                    <asp:DropDownList ID="ddlGrupoDac" runat="server" CssClass="form" Width="150"></asp:DropDownList>
                    <br />

                    <asp:Label ID="lblStatus" class="lb_Inside" Width="150px" runat="server" Text="Status"></asp:Label>
                    <asp:RadioButtonList ID="rbStatus" runat="server" RepeatDirection="Horizontal" class="form">
                        <asp:ListItem Value="0" Text="&nbsp;Inativo&nbsp;&nbsp;" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="&nbsp;Ativo&nbsp;&nbsp;" Selected="True" ></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <asp:Label ID="lblPorcentagem" class="lb_Inside" Width="150px" runat="server" Text="Porcentagem"></asp:Label>
                    <asp:DropDownList ID="ddlPorcentagem" runat="server" CssClass="form" Width="150"></asp:DropDownList>
                    <%--<asp:TextBox ID="txtPorcentagem" class="form" width="150px" runat="server"></asp:TextBox>--%>

                    <br /><br />

                </div>
            </div>
            
            <div class="ctn" id="modExcluir" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="Label1" runat="server" Text="Excluir Grupo DAC"></asp:Label></b>
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
                    <asp:label ID="lblMensagemExclusao" Text="Confirma a exclusão do Grupo DAC :" runat="server"></asp:label>
                    <br /><br />
                    
                    <asp:label ID="lblExclusao" CssClass="lb_InsideConfirm" Text="" runat="server"></asp:label>
                    </center>
                    <br /><br />
                
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