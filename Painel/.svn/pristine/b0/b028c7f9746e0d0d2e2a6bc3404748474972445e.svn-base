using System;
using System.Text;
using System.Web.UI;

namespace clsVerisys.Tools
{
    public class Mensagem
    {
        public enum idMensagem
        {
            Insucesso = 1,
            Sucesso = 2,
            Informacao = 3
        }

        public void Mensagens(String strMensagem, idMensagem enumMensagem, Page idPage)
        {
            StringBuilder script = new StringBuilder();
            script.Remove(0, script.Length);
            script.Append("<script type=\"text/javascript\">");
            script.Append("var hm = $('body').wHumanMsg();");

            if (enumMensagem == idMensagem.Insucesso) // NOK
            {
                script.Append("hm.wHumanMsg(" + strMensagem + ", {theme: 'red'});");
            }
            if (enumMensagem == idMensagem.Sucesso) // OK
            {
                script.Append("hm.wHumanMsg(" + strMensagem + ", {theme: 'green'});");
            }
            if (enumMensagem == idMensagem.Informacao) // INFO
            {
                script.Append("hm.wHumanMsg(" + strMensagem + ", {theme: 'yellow'});");
            }

            script.Append("</script>");
            idPage.ClientScript.RegisterClientScriptBlock(typeof(object), "JavaScriptBlock", script.ToString());
        }
    }
}
