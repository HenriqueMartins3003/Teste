<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_webPainelVerisys.Login" %>

<html>

<head id="Head1" runat="server">
    <title>Painel - Verisys</title>

    <link rel="Stylesheet" media="all" href="css/login.css" />
    <link rel="SHORTCUT ICON" href="img/icon_page.png" />
</head>

<body>
<form id="frmLogin" runat="server">

    <!-- Geral login -->
    <div class="containerLogin">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
            <!-- Formulário de Login -->
            <div class="div_formulario">
                <div class="ctnResposta">
                    <asp:Label ID="LabelErro" runat="server">&nbsp;</asp:Label>
                </div>
            
                <b>Usuário</b><br />
                <asp:TextBox CssClass="form" ID="txtLogin" runat="server" Width="175"></asp:TextBox><br />
                
                <b>Senha</b><br />
                <asp:TextBox CssClass="form" ID="txtSenha" TextMode="Password" runat="server" Width="175"></asp:TextBox><br />
                
                <div style="float:left;">
                    <asp:ImageButton ID="buttonImageEntrar" runat="server" ImageUrl="~/img/btn-entrar.gif" OnClick="Enviar_Click" />
                </div>

                <div style="float:left; padding:6px 0px 0px 10px;">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img src="img/ajax-loader-mini.gif" alt="aguarde..." />
                    </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                
                <div style="clear:both;"></div>
            </div>
        
        </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>

</form>
</body>
</html>
