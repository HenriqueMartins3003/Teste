using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _webPainelVerisys
{
    public partial class Sair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // limpa as sessões
            Session.Clear();

            // redireciona para o login
            Response.Redirect("login.aspx", false);
        }
    }
}
