using System;
using System.Data;
using System.Windows.Forms;

namespace clsVerisys.Forms
{
    public class WindowsForms
    {
        public void CarregaCombo(ComboBox cboObjeto, DataSet objDs, Int16 iIndex, Int16 iText, Boolean blnMensagem)
        {
            DataSet objDs1 = new DataSet();
            String strValueMember, strDisplayMember;

            try
            {
                cboObjeto.DataSource = null;
                cboObjeto.Items.Clear();

                strValueMember = objDs.Tables[0].Columns[iIndex].ColumnName;
                strDisplayMember = objDs.Tables[0].Columns[iText].ColumnName;

                objDs1.Tables.Add("TABLE");
                objDs1.Tables[0].Columns.Add(strValueMember, Type.GetType("System.String"));
                objDs1.Tables[0].Columns.Add(strDisplayMember, Type.GetType("System.String"));

                if (blnMensagem)
                {
                    objDs1.Tables[0].Rows.Add(new object[] { -1, "<..Selecione..>" });
                }

                foreach (DataRow dr in objDs.Tables[0].Rows)
                {
                    objDs1.Tables[0].Rows.Add(new object[] { dr[iIndex].ToString(), dr[iText].ToString() });
                }

                cboObjeto.DisplayMember = strDisplayMember;
                cboObjeto.ValueMember = strValueMember;
                cboObjeto.DataSource = objDs1.Tables[0];

                cboObjeto.SelectedValue = -1;
            }
            catch
            {
                throw;
            }
        }
    }
}
