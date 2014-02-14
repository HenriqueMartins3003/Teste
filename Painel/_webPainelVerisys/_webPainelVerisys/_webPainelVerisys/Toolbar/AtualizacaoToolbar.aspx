<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtualizacaoToolbar.aspx.cs" Inherits="_webPainelVerisys.Toolbar.AtualizacaoToolbar" MasterPageFile="~/MP.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="cph_INDEX" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <form id="frmAtualizacaoToolbar" runat="server">
<div class="containerInside">
    
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
    EnableScriptGlobalization="true" 
    EnableScriptLocalization="true">
    </cc1:ToolkitScriptManager>
    
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" 
    EnableScriptGlobalization="true" 
    EnableScriptLocalization="true">
    </asp:ScriptManager>
    --%>
    
   
   <%-- 
<script type="text/javascript" language="javascript">
  function ActiveTabChanged(sender, e) {
            var CurrentTab = $get('<%=CurrentTab.ClientID%>');
            CurrentTab.innerHTML = sender.get_activeTab().get_headerText();
            //add a custom postback
             __doPostBack('TabContainer1', sender.get_activeTab().get_headerText());
            Highlight(CurrentTab);
        }
        </script>
        --%>
   
     
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <!-- title -->
    <div class="titleContentInside">Controle de Versão ToolBar</div>
    
    <!-- content -->
    <div class="contentInside">
    
    <!-- form manager -->
    <div id="div_FormManager" runat="server">
        
        <!-- container -->
        <div class="ctn">
        
            <!-- title -->
            <div class="cttTitle">
            
                <div style="float:left;"><b>Atualização de Versão</b></div>
                
                <div style="float:right;">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img src="img/ajax-loader-mini.gif" alt="aguarde..." align="right" style="margin:3px 10px 0px 0px;" /></ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                
                <div class="clear"></div>
                
            </div>
                 
            <br />
            
           <asp:Label ID="lblResponse" runat="server" visible="false"></asp:Label>
            
           <cc1:TabContainer ID="TabContainer1" CssClass = "ajax__tab_mytheme" 
                runat="server" Width="780px" ActiveTabIndex="3" 
                onactivetabchanged="TabContainer1_ActiveTabChanged" 
            >
          
                <cc1:TabPanel  runat="server" BorderStyle="None"  ID="tabRamais">
                    <HeaderTemplate>Ramais</HeaderTemplate>
                    <ContentTemplate>                                          
                            <div><center>
                                <br />
                                <asp:GridView ID="gridRamais" runat="server" AllowPaging="True" PageSize="100"
                                               OnPageIndexChanging="GridviewRamais_PageIndexChanging"
                                               OnSorting="GridviewRamais_Sorting" 
                                               onrowdatabound="GridviewRamais_RowDataBound"> 
                                               <PagerSettings PageButtonCount="5" ></PagerSettings>
                                               
                                </asp:GridView></center>
                                <br />
                            </div>                         
                    </ContentTemplate>
                </cc1:TabPanel>     
                <cc1:TabPanel runat="server" ID="tabLogs">
                    <HeaderTemplate>Logs</HeaderTemplate>
                    <ContentTemplate>
                            <div ><center>
                                 <br />
                                 <asp:GridView ID="gridLogs" runat="server" AllowPaging="True" PageSize="100"
                                       OnPageIndexChanging="GridviewLogs_PageIndexChanging"
                                       OnSorting="GridviewLogs_Sorting" 
                                       onrowdatabound="GridviewLogs_RowDataBound">
                                       <PagerSettings PageButtonCount="5"></PagerSettings> 
                                       
                                 </asp:GridView>
                                 <br />
                            </div>
                    </ContentTemplate>
                </cc1:TabPanel>     
                <cc1:TabPanel runat="server" ID="tabAtualizacoes">
                    <HeaderTemplate>Atualizações</HeaderTemplate>
                    <ContentTemplate>
                            <div ><center>
                               <!-- resposta -->
                                                                 
                                    <br />               
                                
                                    <div style="float:left; width:345px;">
                                        <asp:Label ID="lblVersao" runat="server">Versão</asp:Label>&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlVersao" Style ="background:#F7F7F7; border:1px solid #999; font:12px  Arial, Helvetica, sans-serif;" runat="server" Width="250"></asp:DropDownList>
                                    </div>    
                                
                                    <div style="float:right; width:350px;">
                                        <asp:Label ID="LabelModoAtualizacao" runat="server" Text="Modo de Atualização"></asp:Label>&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlModo" Style ="background:#F7F7F7; border:1px solid #999; font:12px  Arial, Helvetica, sans-serif;" runat="server" Width ="160">
                                            <asp:ListItem Value="0">Nunca</asp:ListItem>
                                            <asp:ListItem Value="1">Versões Mais Recentes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="3">Sempre</asp:ListItem>
                                        </asp:DropDownList>      
                                    </div>      
                                
                                    <br /> <br /> <br />       
                                           
                                
                                    <div class="cttInside">
                                
                                        Ramais Cadastrados <small>(Para selecionar mais de uma opção faça a seleção com a tecla Crtl de seu teclado pressionada)</small><br />
                                        <div style="float:left; width:345px;">                                        
                                            <asp:ListBox ID="lbRamais" runat="server" CssClass="formInside" Width="100%" SelectionMode="Multiple" Rows="100"></asp:ListBox>
                                        </div>
                                                
                                        <!-- arows -->
                                        <div style="float:left; margin:25px 5px 0px 13px; width: 38px;">                                        
                                            <asp:ImageButton ID="btnLeft" runat="server" ImageUrl="~/img/arrow-left.gif" 
                                                onclick="btnLeft_Click" />
                                            &nbsp;
                                            <asp:ImageButton ID="btnRight" runat="server" ImageUrl="~/img/arrow-right.gif" 
                                                onclick="btnRight_Click" />                                            
                                        </div>
                                        
                                        <div style="float:right; width:350px;">                                        
                                            <asp:ListBox ID="lbRamaisSelecionador" runat="server" CssClass="formInside" Width="100%" SelectionMode="Multiple" Rows="100"></asp:ListBox>
                                        </div>
                                        
                                        <div class="clear"></div>
                                    
                                    </div>
                                
                                    <br />                                
                                
                                <asp:ImageButton ID="buttonImageCadastrar" runat="server" ImageUrl="~/img/btn-salvar.gif" onclick="buttonImageCadastrar_Click"/>&nbsp;
                                  <br />   
                                   <br />  
                                   
                                </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel runat="server" ID="tabVersaoDefault">
                    <HeaderTemplate>Versão Default</HeaderTemplate>                    
                    <ContentTemplate>   
                               <div><center>   
                                  <br /> 
                                  <div>
                                        <asp:Label ID="lblTagVersaoDefault" runat="server">Versão Default:</asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblDadoVersaoDefault" runat="server" style="font-weight:bold"></asp:Label>&nbsp;&nbsp;
                                        <br /> 
                                        <br /> 
                                        <asp:Label ID="lblAlterarVersaoDefault" runat="server">Alterar a Versão Default:</asp:Label>&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlVersaoDefault" Style ="background:#F7F7F7; border:1px solid #999; font:12px  Arial, Helvetica, sans-serif;" runat="server" Width="250"></asp:DropDownList>
                                  </div>
                                  <br />    
                                  <br /> 
                                  <br />    
                                  <asp:ImageButton ID="buttonImageCadastrarDefault" runat="server" ImageUrl="~/img/btn-salvar.gif" onclick="buttonImageCadastrarDefault_Click"/>&nbsp;
                                  <br />
                                  <br />
                           </div>        
                            
                    </ContentTemplate>
                </cc1:TabPanel>     
           </cc1:TabContainer>
                                
            <br /> <br />
                                
      
        
    </div>
    
    </div>
    
   
    </ContentTemplate>
    </asp:UpdatePanel> 

</div>
</form>

</asp:Content>