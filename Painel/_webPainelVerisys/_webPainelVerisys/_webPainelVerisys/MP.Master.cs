using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.DTO;
using _webPainelVerisys.BLL;

namespace _webPainelVerisys
{
    public partial class MP : System.Web.UI.MasterPage
    {
        dtoUsers UsuarioObj = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNameApp.Text = ConfigurationManager.AppSettings["NameApplication"];

                if (Session["ObjUsers"] != null)
                {
                    UsuarioObj = (dtoUsers)Session["ObjUsers"];
                    lblDataUsers.Text = "Usuário: <b>" + UsuarioObj.Name + "</b>";
                }
                else
                {
                    Response.Redirect("../login.aspx");
                }
            }

            CarregaMenu();
        }

        protected void CarregaMenu()
        {
            try
            {
                Modulos objModulos = new Modulos();
                UsuarioObj = (dtoUsers)Session["ObjUsers"];
                String strApplication = Session["ObjApplication"].ToString();

                rpMenuEsquerdo.DataSource = objModulos.RetornaModulosMenu(UsuarioObj, strApplication);
                rpMenuEsquerdo.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar informações do Menu ! " + ex.Message);
            }
        }
    }
}
