<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogImportExport.aspx.cs" Inherits="_webPainelVerisys.ImportExport.LogImportExport" Culture="pt-BR" MasterPageFile="~/MP.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cph_ImportExportLogImportExport" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmImportExportLogImportExport" runat="server">
    <div class="containerInside">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>  

        <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>

        <div class="titleContentInside">
            <asp:Label id="lblTitulo" runat="server" text="Titulo"></asp:Label>
        </div>

        <div class="contentInside" id=divContent runat="server">
            <div class="cttTitle"><b>Filtro de Pesquisa</b></div>
            
            <div class="ctn" id="divPesquisa" runat="server">
                
                <div id="Div3" class="contentBoxListsContentL" runat="server" style="height:80px; border:0px">
            
                    <asp:label ID="lblStartDate" CssClass="lb_Inside" Text="Periodo Inicial" runat="server" Width="100" ></asp:label>
                    <asp:TextBox ID="txtStartDate" CssClass="form" runat="server" Width="80" MaxLength="10" ></asp:TextBox>
                    <asp:CalendarExtender runat="server" ID="calStartDate" TargetControlID="txtStartDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                    
                    <asp:TextBox ID="txtStartTime"  runat="server" CssClass="form" Width="50" Text="00:00:00"
                                 onkeypress="startTabCheck();return MM_formatoDigitos(event,this,'##:##:##');" 
                                 onkeyup="exibeValor(this, 8, 0)" onfocus="stopTabCheck(this)" MaxLength="8"></asp:TextBox>
                    <br />
                    
                    <asp:label ID="lblEndDate" CssClass="lb_Inside" Text="Periodo Final" runat="server" Width="100" ></asp:label>
                    <asp:TextBox ID="txtEndDate" CssClass="form" runat="server" Width="80" MaxLength="10" ></asp:TextBox>
                    <asp:CalendarExtender runat="server" ID="calEndDate" TargetControlID="txtEndDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                    
                    <asp:TextBox ID="txtEndTime" runat="server" CssClass="form" Width="50" Text="23:59:59"
                                 onkeypress="startTabCheck();return MM_formatoDigitos(event,this,'##:##:##');" 
                                 onkeyup="exibeValor(this, 8, 0)" onfocus="stopTabCheck(this)" MaxLength="8"></asp:TextBox>
                    <br /><br />
                    
                    <asp:ImageButton ID="buttonImageFilter" runat="server" ImageUrl="~/img/btn-filtrar.gif" onclick="buttonImageFilter_Click" />
                
                </div>
                
                <div id="Div1" class="contentBoxListsContentR" runat="server" style="height:80px; border:0px">
                    
                    <asp:label ID="lblCampaign" CssClass="lb_Inside" Text="Campanha" runat="server" Width="100" ></asp:label>
                    <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                    <br />
                    
                    <asp:label ID="lblProcessID" CssClass="lb_Inside" Text="Processo" runat="server" Width="100" ></asp:label>
                    <asp:DropDownList ID="ddlProcessID" runat="server" CssClass="form" Width="205"></asp:DropDownList>
                
                </div>
            
            </div>
        </div>
        
        <div id="divResponse" runat="server" visible="false" class="ctt">
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
        
        <div class="contentInside" id=divGridContent visible="true" runat="server">
        
            <div class="ctn" id="modLista" runat="server" visible="true">
                <div class="ctt">
                    <div id="ctnLista" runat="server">
                        <asp:GridView ID="gdRegistros" runat="server" 
                                AllowSorting="False"
                                GridLines="None"
                                CellPadding="4"
                                AllowPaging="False"
                                AlternatingRowStyle-HorizontalAlign="Left"
                                onrowdatabound="gdRegistros_RowDataBound" 
                            onrowcreated="gdRegistros_RowCreated" >
                            <PagerSettings LastPageText="&amp;gt; &amp;gt;" Mode="NumericFirstLast" FirstPageText="&amp;lt;&amp;lt;" />
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            
            
        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</form>
</asp:Content>