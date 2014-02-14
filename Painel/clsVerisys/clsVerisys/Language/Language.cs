using System;
using System.Xml.XPath;

namespace clsVerisys.Language
{
    public class Language
    {
        public void ctrlLanguage(System.Windows.Forms.Control Control, String File)
        {
            foreach (System.Windows.Forms.Control ctrl in Control.Controls)
            {
                String traducao = xmlLanguage(File, ctrl.Name);
                if (!String.IsNullOrEmpty(traducao))
                    ctrl.Text = traducao;
            }
        }

        public void ctrlLanguageWeb(System.Web.UI.Control Control, String File)
        {
            foreach (System.Web.UI.Control ctrl in Control.Controls)
            {

                if (ctrl.GetType().ToString().Equals("System.Web.UI.WebControls.Label"))
                {
                    System.Web.UI.WebControls.Label myLabel = (System.Web.UI.WebControls.Label)ctrl;
                    String traducao = xmlLanguage(File, myLabel.ID.ToString());

                    if (!String.IsNullOrEmpty(traducao))
                        myLabel.Text = traducao;
                }
            }
        }

        private String xmlLanguage(String File, String Control)
        {
            try
            {
                XPathDocument xpathDoc = new XPathDocument(File);
                XPathNavigator xpathNav = xpathDoc.CreateNavigator();
                XPathNodeIterator xpathNodeIter = xpathNav.Select(String.Format("Language/{0}", Control));

                if (!xpathNodeIter.MoveNext())
                    return String.Empty;
                else
                    return xpathNodeIter.Current.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(" Erro ao ler arquivo XML Language !! -- > " + ex.Message);
            }
        }
    }
}
