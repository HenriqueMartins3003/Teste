using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using clsVerisys.Database;
using clsVerisys.Forms;

namespace clsVerisys.ResultadoOperacao
{
    public class RO
    {
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        SQLConn objBanco = new SQLConn();
        SQLConnString objConnStr = new SQLConnString();
        WindowsForms objForms = new WindowsForms();

        public DataSet SP_ListConfiguracao(String strCampanha, String SqlConexao, SQLConnString.AplicationType eTipoAplicacao)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_ListROConfiguracaoApp");
                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", strCampanha));

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, objConnStr.BuscaConexao(SqlConexao, eTipoAplicacao));
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet Manager_Historico(dtoRO getRO, String SqlConexao, SQLConnString.AplicationType eTipoAplicacao)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_ManagerROHistorico");

                cmdComando.Parameters.Add(new SqlParameter("@Task", getRO.Task));
                cmdComando.Parameters.Add(new SqlParameter("@ConfiguracaoID", getRO.ConfiguracaoID));
                cmdComando.Parameters.Add(new SqlParameter("@CampanhaID", getRO.CampanhaID));
                cmdComando.Parameters.Add(new SqlParameter("@CallID", getRO.CallID));
                cmdComando.Parameters.Add(new SqlParameter("@ContactID", getRO.ContactID));
                cmdComando.Parameters.Add(new SqlParameter("@MailingID", getRO.MailingID));
                cmdComando.Parameters.Add(new SqlParameter("@AgentID", getRO.AgentID));
                cmdComando.Parameters.Add(new SqlParameter("@DataReagendamento", getRO.DataReagendamento.ToString() == "01/01/0001 00:00:00" ? null : getRO.DataReagendamento.ToString()));
                cmdComando.Parameters.Add(new SqlParameter("@NovoTelefone", getRO.NovoTelefone));
				cmdComando.Parameters.Add(new SqlParameter("@DesabilitaTelefone", getRO.DesabilitaTelefone));
                cmdComando.Parameters.Add(new SqlParameter("@ReagendamentoAgente", getRO.ReagendamentoAgente));
                cmdComando.Parameters.Add(new SqlParameter("@Observacao", getRO.Observacao));

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, objConnStr.BuscaConexao(SqlConexao, eTipoAplicacao));
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CarregaTipoRO(ComboBox cmbBox, DataSet dsConfiguracao)
        {
            if (dsConfiguracao.Tables[0].Rows.Count > 0)
            {
                DataTable dt = dsConfiguracao.Tables[0].DefaultView.ToTable(true, "TipoID", "TipoDescricao");
                DataSet dsQuery = new DataSet();
                dsQuery.Tables.Add(dt);

                objForms.CarregaCombo(cmbBox, dsQuery, 0, 1, true);
                cmbBox.SelectedValue = -1;
            }
        }

        public void CarregaRO(ComboBox cmbBox, DataSet dsConfiguracao, String iIndexTipoRO)
        {
            if (!String.IsNullOrEmpty(iIndexTipoRO))
            {
                dsConfiguracao.Tables[0].DefaultView.RowFilter = "TipoID = '" + iIndexTipoRO + "'";
                DataTable dt = dsConfiguracao.Tables[0].DefaultView.ToTable();
                DataSet dsQuery = new DataSet();
                dsQuery.Tables.Add(dt);
                
                objForms.CarregaCombo(cmbBox, dsQuery, 0, 2, true);
                cmbBox.SelectedValue = -1;
            }
        }
    }
}
