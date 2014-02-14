using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class Estatisticas
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        Geral objGeral = new Geral();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();

        public DataSet listaAssetividade(String strCampanha, String strListaRO)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SP_DIS_ASSERTIVIDADE");

                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", strCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@LISTRO", strListaRO));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, strCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet listaCalculoCampanhas(String strCampanha)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SP_HISTORICO_CALCULOCAMPANHAS_MEDIA15");

                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", strCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
