using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.BLL;
using _webPainelVerisys.DTO;

namespace _webPainelVerisys
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MensRedirecionamento"] != null)
                {
                    LabelErro.Text = "<div class='respostaErro'>" + Session["MensRedirecionamento"].ToString() + "</div>";
                }
            }

            Session.RemoveAll();
            txtLogin.Focus();
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            String User = txtLogin.Text.Trim();
            String Pass = txtSenha.Text.Trim();

            if (User != "" && Pass != "")
            {
                Users bll = new Users();
                dtoUsers objUsers = new dtoUsers();
                
                objUsers = bll.login(User, Pass);
                if (objUsers.LoginOK == true)
                {
                    Session.Add("ObjUsers", objUsers);
                    Session.Add("ObjApplication", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                    Response.Redirect(ConfigurationManager.AppSettings["HomePage"]);
                }
                else
                {
                    LabelErro.Text = "<div class='respostaErro' style='margin:-26px 0px 0px 0px;'>Usuário/Senha inválidos, verifique!</div>";
                }
            }
            else
            {
                LabelErro.Text = "<div class='respostaErro' style='margin:-26px 0px 0px 0px;'>Usuário/Senha inválidos, verifique!</div>";
            }
        }              
    }
}
