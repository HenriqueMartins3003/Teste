<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_webPainelVerisys.Painel.Default" MasterPageFile="~/MP.Master" %>

<asp:Content ID="cph_INDEX" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

<form id="frmDefault" runat="server">
<body>
<div class="containerInside">

    <asp:ScriptManager ID="ScriptManager1" runat="server"
        EnableScriptGlobalization="true" 
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <!-- title -->
    <div class="titleContentInside"><asp:Label id="lblNomeAplicacaoTitulo" runat="server" ></asp:Label></div>
        <div class="contentDefault" style="height:700px;">
        
            <br /><br />
            <center>
            <h3>
                Bem Vindo ao
                <br />
                
            </h3>
            <h1>
                <asp:Label id="lblNomeAplicacao" runat="server" ></asp:Label>
            </h1>
            </center>
            
        </div>

    </ContentTemplate>
    </asp:UpdatePanel>

</div>
</body>
</form>

</asp:Content>
    