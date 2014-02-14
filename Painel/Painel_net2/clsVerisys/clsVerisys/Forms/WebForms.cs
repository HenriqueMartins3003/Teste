using System;
using System.Data;
using System.Web.UI.WebControls;

namespace clsVerisys.Forms
{
    public class WebForms
    {
        public void CarregaComboWeb(DropDownList cboObjeto, DataSet objDs, Int16 iIndex, Int16 iText, Boolean blnMensagem)
        {
            try
            {
                String strValueMember = objDs.Tables[0].Columns[iIndex].ColumnName;
                String strDisplayMember = objDs.Tables[0].Columns[iText].ColumnName;

                DataSet objDs1 = new DataSet();
                objDs1.Tables.Add("TABLE");
                objDs1.Tables["TABLE"].Columns.Add(strValueMember, Type.GetType("System.String"));
                objDs1.Tables["TABLE"].Columns.Add(strDisplayMember, Type.GetType("System.String"));

                if (blnMensagem)
                {
                    objDs1.Tables["TABLE"].Rows.Add(new object[] { -1, "<..Selecione..>" });
                }

                foreach (DataRow dr in objDs.Tables["TABLE"].Rows)
                {
                    objDs1.Tables["TABLE"].Rows.Add(new object[] { dr[iIndex], dr[iText].ToString() });
                }

                cboObjeto.DataSource = objDs1.Tables["TABLE"];
                cboObjeto.DataTextField = strDisplayMember;
                cboObjeto.DataValueField = strValueMember;
                cboObjeto.DataBind();

                cboObjeto.SelectedIndex = -1;
            }
            catch
            {
                throw;
            }
        }
    }
}





