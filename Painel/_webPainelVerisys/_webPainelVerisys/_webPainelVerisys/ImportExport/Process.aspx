<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Process.aspx.cs" Inherits="_webPainelVerisys.ImportExport.Process" MasterPageFile="~/MP.Master"%>

<asp:Content ID="cph_ImportExportProcess" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportExportProcess" runat="server">
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
                                DataKeyNames="ProcessID, ProcessName, ProcessDescription, ProcessTypeID, ProcessTypeName, LotMask, LotControlbyCampaign, 
                                              RegistryHeaderID, RegistryTrailerID, RegistryID, RulesID, ExecutionPlanID, ProcessStatus, ProcessStatusDescription"
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
                <div id="Div1" class="ctt" runat="server">

                    <div id="Div3" class="contentBoxListsContentL" runat="server" style="height:200px; border:0px">
                        
                        <asp:label ID="lblProcessName" CssClass="lb_Inside" Text="Nome" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtProcessName" runat="server" CssClass="form" Width="200" MaxLength="200" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblProcessDescription" CssClass="lb_Inside" Text="Descrição" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtProcessDescription" runat="server" CssClass="form" Width="200" MaxLength="200" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblProcessTypeID" CssClass="lb_Inside" Text="Tipo" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlProcessTypeID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblLotMask" CssClass="lb_Inside" Text="Mascara (Lote)" runat="server" Width="100"></asp:label>
                        <asp:TextBox ID="txtLotMask" runat="server" CssClass="form" Width="200" MaxLength="50" ></asp:TextBox>
                        <br />
                        
                        <asp:label ID="lblLotControlbyCampaign" CssClass="lb_Inside" Text="Lote (Campanha)" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlLotControlbyCampaign" runat="server" CssClass="form" Width="205">
                            <asp:ListItem Value="True" Text="Sim"></asp:ListItem>
                            <asp:ListItem Value="False" Text="Não"></asp:ListItem>
                        </asp:DropDownList>
                        <br />

                    </div>
                    
                    <div id="Div4" class="contentBoxListsContentR" runat="server" style="height:200px; border:0px">
                        
                        <asp:label ID="lblRegistryHeaderID" CssClass="lb_Inside" Text="Header" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlRegistryHeaderID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblRegistryTrailerID" CssClass="lb_Inside" Text="Trailer" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlRegistryTrailerID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblRegistryID" CssClass="lb_Inside" Text="Registry" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlRegistryID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblRulesID" CssClass="lb_Inside" Text="Regras" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlRulesID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblExecutionPlanID" CssClass="lb_Inside" Text="Execution Plan" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlExecutionPlanID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                        <br />
                        
                        <asp:label ID="lblProcessStatus" CssClass="lb_Inside" Text="Ativo ?" runat="server" Width="100"></asp:label>
                        <asp:DropDownList ID="ddlProcessStatus" runat="server" CssClass="form" Width="205">
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
            
            
            
            
            
            
            
            <div class="ctn" id="modSchedule" visible="false" runat="server">
                <!-- title -->
                <div class="cttTitle">

                    <div style="float:left;"><b>
                        <asp:Label ID="Label111" runat="server" Text="Execução"></asp:Label></b>
                    </div>

                    <div style="float:right;">
                        <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                        <ProgressTemplate>
                            <img src="../img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    
                    <div class="clear"></div>

                </div>
                
                <!-- content -->
                <div id="Div6" class="ctt" runat="server">

                    <center>
                        <asp:label ID="lblMensagemSchedule" Text="Confirma a inclusão da execução do processo, conforme abaixo ?" runat="server"></asp:label>
                        <br /><br />
                        
                        <asp:label ID="lblProcessSchedule" CssClass="lb_InsideConfirm" Text="Processo" runat="server" Width="200"></asp:label>
                        <br />
                        <asp:label ID="lblProcessType" CssClass="lb_InsideConfirm" Text="Tipo" runat="server" Width="200"></asp:label>
                        <br />
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