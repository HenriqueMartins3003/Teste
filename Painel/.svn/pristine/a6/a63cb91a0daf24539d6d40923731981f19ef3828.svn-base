using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class RO
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();

        public dtoRO totalRO(String IDCampanha, Int16 Tipo, dtoUsers getValuesUserPanel)
        {
            // create a list of the objects
            dtoRO objAux = new dtoRO();
            int iContador = 0;

            try
            {
                // data atual
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.ID_RO, CD.DESCRICAO, C.NUMEROCAMPANHA, COUNT(H.ID_CAMPANHA) AS TOTAL                    ");
                strSql.Append("   FROM RO_CAMPANHA C WITH(NOLOCK)                                                                ");
                strSql.Append("        INNER JOIN RO_CADASTRO CD WITH(NOLOCK) ON C.ID_RO = CD.ID_RO                              ");
                strSql.Append("        LEFT OUTER JOIN (SELECT ID_CAMPANHA, ID_RO                                                ");
                strSql.Append("                           FROM RO_HISTORICO WITH(NOLOCK)                                         ");
                strSql.Append("                          WHERE DATAHORAFINALIZACAO BETWEEN @currentDateIni AND @currentDateFim   ");
                strSql.Append("                            AND ID_CAMPANHA = @idCampanha ) H ON C.ID_RO = H.ID_RO                ");
                strSql.Append("  WHERE C.NUMEROCAMPANHA = @IDCAMPANHA                                                            ");
                strSql.Append("  GROUP BY C.ID_RO, CD.DESCRICAO, C.NUMEROCAMPANHA                                                ");
                strSql.Append("  ORDER BY C.ID_RO, C.NUMEROCAMPANHA                                                              ");

                cmdComando.Parameters.Add(new SqlParameter("@currentDateIni", currentDate + " 00:00:00"));
                cmdComando.Parameters.Add(new SqlParameter("@currentDateFim", currentDate + " 23:59:59"));
                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", IDCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    iContador = iContador + int.Parse(drQuery["TOTAL"].ToString());
                }

                if (Tipo == 1)
                {
                    objAux.Total = iContador.ToString();
                }
                if (Tipo == 2)
                {
                    objAux.Total = calcularPorcentagem(iContador, iContador) + "%";
                }

                objGeral.logSQL(getValuesUserPanel.User, "totalRO", strSql.ToString());
                return objAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s >>> System Error: " + ex.Message);
            }
        }

        public DataSet DatasetRO(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ROCA.ID_RO                IDRO,                                                                  ");
                strSql.Append("        ROCA.DESCRICAO            DESCRICAORO,                                                           ");
                strSql.Append("        ROCA.TIPO				 IDTIPO,                                                                ");
                strSql.Append("        ROTI.DESCRICAO            DESCRICACAOTIPO,                                                       ");
                strSql.Append("        ROCA.CLASSIFICACAO		 IDCLASSIFICACAO,                                                       ");
                strSql.Append("        ROCL.NOM_CLASSIFICACAO    NOMECLASSIFICACAO,                                                     ");
                strSql.Append("        CASE WHEN ROCA.ATIVO = 0 THEN 'NÃO' ELSE 'SIM' END ATIVO                                         ");
                strSql.Append("   FROM RO_CADASTRO AS ROCA WITH(NOLOCK)                                                                 ");
                strSql.Append("        INNER JOIN RO_TIPOS AS ROTI WITH(NOLOCK) ON ROCA.TIPO = ROTI.ID_TIPO_RO                          ");
                strSql.Append("        INNER JOIN RO_CLASSIFICACAO AS ROCL WITH(NOLOCK) ON ROCA.CLASSIFICACAO = ROCL.ID_CLASSIFICACAO   ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "DatasetRO_Fidelity", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s >>> System Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Exclusivo Fidelity
        /// </summary>
        /// <param name="ID_Campanha"></param>
        /// <returns></returns>
        public DataSet DatasetRO_Fidelity(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ROCA.ID_RO                IDRO,                                                                  ");
                strSql.Append("        ROCA.DESCRICAO            DESCRICAORO,                                                           ");
                strSql.Append("        ROCA.TIPO				 IDTIPO,                                                                ");
                strSql.Append("        ROTI.DESCRICAO            DESCRICACAOTIPO,                                                       ");
                strSql.Append("        CASE WHEN ROCA.CONTATOCERTO = 1 THEN 'SIM' ELSE 'NÃO' END            CC,                         ");
                strSql.Append("        CASE WHEN ROCA.CONTATOEFETIVO = 1 THEN 'SIM' ELSE 'NÃO' END          CE,                         ");
                strSql.Append("        CASE WHEN ROCA.VENDA = 1 THEN 'SIM' ELSE 'NÃO' END                   VE,                         ");
                strSql.Append("        CASE WHEN ROCA.REEMITIDA = 1 THEN 'SIM' ELSE 'NÃO' END               RE,                         ");
                strSql.Append("        CASE WHEN ROCA.FINALIZACAOEFETIVA = 1 THEN 'SIM' ELSE 'NÃO' END      FE,                         ");
                strSql.Append("        CASE WHEN ROCA.REAGENDAMENTO = 1 THEN 'SIM' ELSE 'NÃO' END           RA,                         ");
                strSql.Append("        CASE WHEN ROCA.LIGACOESNAOATENDIDAS = 1 THEN 'SIM' ELSE 'NÃO' END    LN,                         ");
                strSql.Append("        CASE WHEN ROCA.ATIVO = 0 THEN 'NÃO' ELSE 'SIM' END                   ATIVO,                      ");
                strSql.Append("        CASE WHEN ROCA.FLAG_RESSUBMISSAO = 0 THEN 'NÃO' ELSE 'SIM' END       RESSUBMISSAO                ");
                strSql.Append("   FROM RO_CADASTRO AS ROCA WITH(NOLOCK)                                                                 ");
                strSql.Append("        INNER JOIN RO_TIPOS AS ROTI WITH(NOLOCK) ON ROCA.TIPO = ROTI.ID_TIPO_RO                          ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "DatasetRO_Fidelity", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s >>> System Error: " + ex.Message);
            }
        }

        public DataSet DatasetROType(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_TIPO_RO, DESCRICAO    ");
                strSql.Append("   FROM RO_TIPOS WITH(NOLOCK)    ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "DatasetROType", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s Types >>> System Error: " + ex.Message);
            }
        }

        public DataSet DatasetROClassificacao(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_CLASSIFICACAO,                                        ");
                strSql.Append("        NOM_CLASSIFICACAO,                                       ");
                strSql.Append("        DESC_CLASSIFICACAO,                                      ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 0 THEN 'NÃO' ELSE 'SIM' END ATIVO ");
                strSql.Append("   FROM RO_CLASSIFICACAO WITH(NOLOCK)                            ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "DatasetROClassificacao", strSql.ToString());
                
                return dsQuery;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list R.O.s Classifications >>> System Error: " + ex.Message);
            }
        }

        public DataSet DatasetCampaignAssoc(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            String strUniqueLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();
            String strPainelLinkedServer = ConfigurationSettings.AppSettings["PainelLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT RCA.NUMEROCAMPANHA,                                                                                  ");
                strSql.Append("        CAM.NOME                                                                                             ");
                strSql.Append("   FROM " + strPainelLinkedServer + ".USERSCAMPAIGN AS UCA WITH(NOLOCK)                                      ");
                strSql.Append("        INNER JOIN " + strUniqueLinkedServer + ".CAMPANHAS AS CAM WITH(NOLOCK) ON UCA.CAMPAIGN = CAM.NUMERO  ");
                strSql.Append("        INNER JOIN RO_CAMPANHA AS RCA WITH(NOLOCK) ON CAM.NUMERO = RCA.NUMEROCAMPANHA                        ");
                strSql.Append("  WHERE IDUSER = @idUser                                                                                     ");
                strSql.Append("  GROUP BY RCA.NUMEROCAMPANHA, CAM.NOME                                                                      ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValuesUserPanel.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "DatasetCampaignAssoc", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campign Associated >>> System Error: " + ex.Message + " --- " + @strSql.ToString() + " --- " + getValuesUserPanel.User);
            }
        }
        
        public List<dtoRO> historyRO(String IDCampanha, Int16 Tipo, dtoUsers getValuesUserPanel)
        {
            // var aux
            int iCounter = 0;

            // create a list of the objects
            List<dtoRO> listObjAux = new List<dtoRO>();

            try
            {
                // data atual
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.ID_RO, CD.DESCRICAO, C.NUMEROCAMPANHA, COUNT(H.ID_CAMPANHA) AS TOTAL                    ");
                strSql.Append("   FROM RO_CAMPANHA C (NOLOCK)                                                                    ");
                strSql.Append("        INNER JOIN RO_CADASTRO CD (NOLOCK) ON C.ID_RO = CD.ID_RO                                  ");
                strSql.Append("        LEFT OUTER JOIN (SELECT ID_CAMPANHA, ID_RO                                                ");
                strSql.Append("                           FROM RO_HISTORICO (NOLOCK)                                             ");
                strSql.Append("                          WHERE DATAHORAFINALIZACAO BETWEEN @currentDateIni AND @currentDateFim   ");
                strSql.Append("                            AND ID_CAMPANHA = @idCampanha ) H ON C.ID_RO = H.ID_RO                ");
                strSql.Append("  WHERE C.NUMEROCAMPANHA = @idCampanha                                                            ");
                strSql.Append("  GROUP BY C.ID_RO, CD.DESCRICAO, C.NUMEROCAMPANHA                                                ");
                strSql.Append("  ORDER BY C.ID_RO, C.NUMEROCAMPANHA                                                              ");

                cmdComando.Parameters.Add(new SqlParameter("@currentDateIni", currentDate + " 00:00:00"));
                cmdComando.Parameters.Add(new SqlParameter("@currentDateFim", currentDate + " 23:59:59"));
                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", IDCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                SqlDataReader drQuery2 = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery2.Read())
                {
                    iCounter = iCounter + int.Parse(drQuery2["TOTAL"].ToString());
                }
                

                while (drQuery.Read())
                {
                    dtoRO objAux = new dtoRO();

                    if (Tipo == 1)
                    {
                        objAux.IdRO = int.Parse(drQuery["ID_RO"].ToString());
                        objAux.DescricaoRO = drQuery["DESCRICAO"].ToString();
                        objAux.TotalRO = drQuery["TOTAL"].ToString();
                    }

                    if (Tipo == 2)
                    {
                        objAux.IdRO = int.Parse(drQuery["ID_RO"].ToString());
                        objAux.DescricaoRO = drQuery["DESCRICAO"].ToString();
                        objAux.TotalRO = calcularPorcentagem(iCounter, int.Parse(drQuery["TOTAL"].ToString())) + "%";
                    }

                    listObjAux.Add(objAux);
                }

                drQuery.Close();
                drQuery2.Close();

                objGeral.logSQL(getValuesUserPanel.User, "historyRO", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list History R.O.s >>> System Error: " + ex.Message);
            }
        }

        public List<dtoRO> listTypeRO(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            List<dtoRO> listObjAux = new List<dtoRO>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_TIPO_RO, DESCRICAO    ");
                strSql.Append("   FROM RO_TIPOS WITH(NOLOCK)    ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoRO objAux = new dtoRO();

                    objAux.IDTipoRO = int.Parse(drQuery["ID_TIPO_RO"].ToString());
                    objAux.TipoRO = drQuery["DESCRICAO"].ToString();
                    
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUserPanel.User, "listTypeRO", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Type R.O.s >>> System Error: " + ex.Message);
            }
        }

        public List<dtoRO> listClassificacaoRO(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            List<dtoRO> listObjAux = new List<dtoRO>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_CLASSIFICACAO, NOM_CLASSIFICACAO, DESC_CLASSIFICACAO  ");
                strSql.Append("   FROM RO_CLASSIFICACAO WITH(NOLOCK)                            ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoRO objAux = new dtoRO();

                    objAux.IDClassificacaoRO = int.Parse(drQuery["ID_CLASSIFICACAO"].ToString());
                    objAux.DescClassificacaoRO = drQuery["NOM_CLASSIFICACAO"].ToString() + " - " + drQuery["DESC_CLASSIFICACAO"].ToString();

                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUserPanel.User, "listClassificacaoRO", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s Classification >>> System Error: " + ex.Message);
            }
        }

        public List<dtoRO> listROAssociated(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            List<dtoRO> listObjAux = new List<dtoRO>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ROCA.ID_RO                IDRO,                                          ");
                strSql.Append("        ROCA.DESCRICAO            DESCRICAORO                                    ");
                strSql.Append("   FROM RO_CADASTRO AS ROCA WITH(NOLOCK)                                         ");
                strSql.Append("        INNER JOIN RO_CAMPANHA AS RCAM WITH(NOLOCK) ON ROCA.ID_RO = RCAM.ID_RO   ");
                strSql.Append("  WHERE RCAM.NUMEROCAMPANHA = @idCampanha                                        ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", IDCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoRO objAux = new dtoRO();
                    objAux.IdRO = int.Parse(drQuery["IDRO"].ToString());
                    objAux.DescricaoRO = drQuery["DESCRICAORO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUserPanel.User, "listROAssociated", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s Associated >>> System Error: " + ex.Message);
            }
        }

        public List<dtoRO> listROConfiguration(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            List<dtoRO> listObjAux = new List<dtoRO>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT RCAM.ID_RO_CAMPANHA,                                                     ");
                strSql.Append("        RCAD.DESCRICAO,                                                          ");
                strSql.Append("        RCAM.REAGENDAMENTO,                                                      ");
                strSql.Append("        RCAM.FLAG_REAGESPECIFICO,                                                ");
                strSql.Append("        RCAM.TEMPORETORNO                                                        ");
                strSql.Append("   FROM RO_CADASTRO AS RCAD WITH(NOLOCK)                                         ");
                strSql.Append("        INNER JOIN RO_CAMPANHA AS RCAM WITH(NOLOCK) ON RCAD.ID_RO = RCAM.ID_RO   ");
                strSql.Append("  WHERE RCAM.NUMEROCAMPANHA = @idCampanha                                        ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", IDCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoRO objAux = new dtoRO();
                    objAux.IDROCampanha = int.Parse(drQuery["ID_RO_CAMPANHA"].ToString());
                    objAux.DescricaoRO = drQuery["DESCRICAO"].ToString();
                    objAux.ReagendamentoRO = Convert.ToBoolean(drQuery["REAGENDAMENTO"].ToString());
                    objAux.ReagendamentoEspecificoRO = Convert.ToBoolean(drQuery["FLAG_REAGESPECIFICO"].ToString());
                    objAux.TempoReagendamentoRO = Convert.ToInt16(drQuery["TEMPORETORNO"].ToString());
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUserPanel.User, "listROConfiguration", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s Configuration >>> System Error: " + ex.Message);
            }
        }

        public List<dtoRO> listRO(String idCampanha)
        {
            List<dtoRO> listObjAux = new List<dtoRO>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT RCAD.ID_RO		[ID_RO],                                            ");
                strSql.Append("        RCAD.DESCRICAO	[DESCRICAO]                                         ");
                strSql.Append("   FROM RO_CADASTRO RCAD WITH(NOLOCK)                                        ");
                strSql.Append("        INNER JOIN RO_CAMPANHA RCAM WITH(NOLOCK) ON RCAD.ID_RO = RCAM.ID_RO  ");
                strSql.Append("  WHERE RCAM.NUMEROCAMPANHA  = @idCampanha                                   ");
                strSql.Append("    AND RCAD.ATIVO = 1                                                       ");
                strSql.Append("  ORDER BY RCAD.DESCRICAO                                                    ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", idCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, idCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoRO objAux = new dtoRO();
                    objAux.IdRO = int.Parse(drQuery["ID_RO"].ToString());
                    objAux.DescricaoRO = drQuery["DESCRICAO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();
                
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s >>> System Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Exclusivo Fidelity
        /// </summary>
        /// <param name="ID_Campanha"></param>
        /// <returns></returns>
        public List<dtoRO> listROConfiguration_Fidelity(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            List<dtoRO> listObjAux = new List<dtoRO>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT RCAM.ID_RO_CAMPANHA,                                                     ");
                strSql.Append("        RCAD.DESCRICAO,                                                          ");
                strSql.Append("        ISNULL(RCAM.REAGENDAMENTO, 0)  REAGENDAMENTO,                            ");
                strSql.Append("        ISNULL(RCAM.FLAG_INVALIDATELEFONE, 0) FLAG_INVALIDATELEFONE,             ");
                strSql.Append("        ISNULL(RCAM.FLAG_FONEFORCADO, 0) FLAG_FONEFORCADO,                       ");
                strSql.Append("        CODIGOVISION CODIGOVISION,                                 ");
                strSql.Append("        ISNULL(RCAM.FLAG_NOTCALLREC, 0) FLAG_NOTCALLREC                          ");
                strSql.Append("   FROM RO_CADASTRO AS RCAD WITH(NOLOCK)                                         ");
                strSql.Append("        INNER JOIN RO_CAMPANHA AS RCAM WITH(NOLOCK) ON RCAD.ID_RO = RCAM.ID_RO   ");
                strSql.Append("  WHERE RCAM.NUMEROCAMPANHA = @idCampanha                                        ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", IDCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoRO objAux = new dtoRO();
                    objAux.IDROCampanha = int.Parse(drQuery["ID_RO_CAMPANHA"].ToString());
                    objAux.DescricaoRO = drQuery["DESCRICAO"].ToString();
                    objAux.ReagendamentoRO = Convert.ToBoolean(drQuery["REAGENDAMENTO"].ToString());
                    objAux.InvalidaTelefone = Convert.ToBoolean(drQuery["FLAG_INVALIDATELEFONE"].ToString());
                    objAux.FoneForcado = Convert.ToBoolean(drQuery["FLAG_FONEFORCADO"].ToString());
                    objAux.Vision = drQuery["CODIGOVISION"].ToString();
                    objAux.NotCallRec = Convert.ToBoolean(drQuery["FLAG_NOTCALLREC"].ToString());
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUserPanel.User, "listROConfiguration_Fidelity", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list R.O.s Configuration >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignNotAssociated(String IDCampanha, dtoUsers getValuesUserPanel)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strUniqueLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();
            String strPainelLinkedServer = ConfigurationSettings.AppSettings["PainelLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.NUMERO, C.NOME                                                                             ");
                strSql.Append("   FROM " + strPainelLinkedServer + ".USERSCAMPAIGN UC WITH(NOLOCK)                                  ");
                strSql.Append("        INNER JOIN " + strUniqueLinkedServer + ".CAMPANHAS C WITH(NOLOCK) ON UC.CAMPAIGN = C.NUMERO  ");
                strSql.Append("  WHERE IDUSER = @idUser                                                                             ");
                strSql.Append("    AND C.NUMERO NOT IN ( SELECT DISTINCT(NUMEROCAMPANHA)                                            ");
                strSql.Append("                            FROM RO_CAMPANHA WITH(NOLOCK) )                                          ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValuesUserPanel.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["Numero"].ToString();
                    objAux.NomeCampanha = drQuery["Numero"].ToString() + " - " + drQuery["Nome"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUserPanel.User, "listCampaignNotAssociated", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Not Associated >>> System Error: " + ex.Message);
            }
        }

        public Int64 ManagerRO(dtoRO getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                Int64 intResultado = 0;
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            
                            strSql.Append(" INSERT INTO RO_CADASTRO (TIPO, DESCRICAO, ATIVO, CLASSIFICACAO) ");
                            strSql.Append("      VALUES ( @Tipo, @Descricao, @Ativo, @Classificacao )       ");

                            cmdComando.Parameters.Add(new SqlParameter("@Tipo", getValues.IDTipoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.DescricaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@Classificacao", getValues.IDClassificacaoRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE RO_CADASTRO                      ");
                            strSql.Append("    SET TIPO = @Tipo,                    ");
                            strSql.Append("        DESCRICAO = @Descricao,          ");
                            strSql.Append("        ATIVO = @Ativo,                  ");
                            strSql.Append("        CLASSIFICACAO = @Classificacao   ");
                            strSql.Append("  WHERE ID_RO = @idRO                    ");

                            cmdComando.Parameters.Add(new SqlParameter("@Tipo", getValues.IDTipoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.DescricaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@Classificacao", getValues.IDClassificacaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@idRO", getValues.IdRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM RO_CADASTRO WHERE ID_RO = @idRO ");

                            cmdComando.Parameters.Add(new SqlParameter("@idRO", getValues.IdRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(getValuesUserPanel.User, "ManagerRO", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUserPanel.User, "ManagerRO", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Exclusivo Fidelity
        /// </summary>
        /// <param name="RO"></param>
        /// <returns></returns>
        public Int64 ManagerRO_Fidelity(dtoRO getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                Int64 intResultado = 0;
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO RO_CADASTRO (TIPO, DESCRICAO, ATIVO, CONTATOCERTO, CONTATOEFETIVO, VENDA, REEMITIDA,        ");
                            strSql.Append("                          FINALIZACAOEFETIVA, REAGENDAMENTO, LIGACOESNAOATENDIDAS, FLAG_RESSUBMISSAO )   ");
                            strSql.Append("      VALUES ( @Tipo, @Descricao, @Ativo, @ContatoCerto, @ContatoEfetivo, @Venda, @Reemitida,            ");
                            strSql.Append("               @FinalizacaoEfetva, @Reagendamento, @LigacoesNaoAtendidas, @Ressubmissao )                ");

                            cmdComando.Parameters.Add(new SqlParameter("@Tipo", getValues.IDTipoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.DescricaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@ContatoCerto", getValues.Contatocerto));
                            cmdComando.Parameters.Add(new SqlParameter("@ContatoEfetivo", getValues.Contatoefetivo));
                            cmdComando.Parameters.Add(new SqlParameter("@Venda", getValues.Venda));
                            cmdComando.Parameters.Add(new SqlParameter("@Reemitida", getValues.Reemitida));
                            cmdComando.Parameters.Add(new SqlParameter("@FinalizacaoEfetva", getValues.Finalizacaoefetiva));
                            cmdComando.Parameters.Add(new SqlParameter("@Reagendamento", getValues.Reagendamento));
                            cmdComando.Parameters.Add(new SqlParameter("@LigacoesNaoAtendidas", getValues.Ligacoesnaoatendidas));
                            cmdComando.Parameters.Add(new SqlParameter("@Ressubmissao", getValues.Ressubmissao));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE RO_CADASTRO                                  ");
                            strSql.Append("    SET TIPO = @Tipo,                                ");
                            strSql.Append("        DESCRICAO = @Descricao,                      ");
                            strSql.Append("        ATIVO = @Ativo,                              ");
                            strSql.Append("        CONTATOCERTO = @ContatoCerto,                ");
                            strSql.Append("        CONTATOEFETIVO = @ContatoEfetivo,            ");
                            strSql.Append("        VENDA = @Venda,                              ");
                            strSql.Append("        REEMITIDA = @Reemitida,                      ");
                            strSql.Append("        FINALIZACAOEFETIVA = @FinalizacaoEfetva,     ");
                            strSql.Append("        REAGENDAMENTO = @Reagendamento,                  ");
                            strSql.Append("        LIGACOESNAOATENDIDAS = @LigacoesNaoAtendidas,    ");
                            strSql.Append("        FLAG_RESSUBMISSAO = @Ressubmissao                ");
                            strSql.Append("  WHERE ID_RO = @idRO                                ");

                            cmdComando.Parameters.Add(new SqlParameter("@Tipo", getValues.IDTipoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.DescricaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@ContatoCerto", getValues.Contatocerto));
                            cmdComando.Parameters.Add(new SqlParameter("@ContatoEfetivo", getValues.Contatoefetivo));
                            cmdComando.Parameters.Add(new SqlParameter("@Venda", getValues.Venda));
                            cmdComando.Parameters.Add(new SqlParameter("@Reemitida", getValues.Reemitida));
                            cmdComando.Parameters.Add(new SqlParameter("@FinalizacaoEfetva", getValues.Finalizacaoefetiva));
                            cmdComando.Parameters.Add(new SqlParameter("@Reagendamento", getValues.Reagendamento));
                            cmdComando.Parameters.Add(new SqlParameter("@LigacoesNaoAtendidas", getValues.Ligacoesnaoatendidas));
                            cmdComando.Parameters.Add(new SqlParameter("@Ressubmissao", getValues.Ressubmissao));
                            cmdComando.Parameters.Add(new SqlParameter("@idRO", getValues.IdRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM RO_CADASTRO WHERE ID_RO = @idRO ");

                            cmdComando.Parameters.Add(new SqlParameter("@idRO", getValues.IdRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(getValuesUserPanel.User, "ManagerRO_Fidelity", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUserPanel.User, "ManagerRO_Fidelity", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerROType(dtoRO getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                Int64 intResultado = 0;
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO RO_TIPOS ( DESCRICAO )  ");
                            strSql.Append("      VALUES ( @Descricao )          ");

                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.TipoRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE RO_TIPOS                 ");
                            strSql.Append("    SET DESCRICAO = @Descricao   ");
                            strSql.Append("  WHERE ID_TIPO_RO = @idTipo     ");

                            cmdComando.Parameters.Add(new SqlParameter("@idTipo", getValues.IDTipoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.TipoRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM RO_TIPOS WHERE ID_TIPO_RO = @idTipo ");

                            cmdComando.Parameters.Add(new SqlParameter("@idTipo", getValues.IDTipoRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }
                objGeral.logSQL(getValuesUserPanel.User, "ManagerROType", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUserPanel.User, "ManagerROType", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerROClassificacao(dtoRO getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                Int64 intResultado = 0;
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO RO_CLASSIFICACAO (NOM_CLASSIFICACAO, DESC_CLASSIFICACAO, FLAG_ATIVO)    ");
                            strSql.Append("      VALUES ( @Nome, @Descricao, @Ativo )                                           ");

                            cmdComando.Parameters.Add(new SqlParameter("@Nome", getValues.NomeClassificacaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.DescClassificacaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE RO_CLASSIFICACAO                     ");
                            strSql.Append("    SET NOM_CLASSIFICACAO = @Nome,           ");
                            strSql.Append("        DESC_CLASSIFICACAO = @Descricao,     ");
                            strSql.Append("        FLAG_ATIVO = @Ativo                  ");
                            strSql.Append("  WHERE ID_CLASSIFICACAO = @idClassificacao  ");

                            cmdComando.Parameters.Add(new SqlParameter("@Nome", getValues.NomeClassificacaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Descricao", getValues.DescClassificacaoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idClassificacao", getValues.IDClassificacaoRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM RO_CLASSIFICACAO WHERE ID_CLASSIFICACAO = @idClassificacao ");

                            cmdComando.Parameters.Add(new SqlParameter("@idClassificacao", getValues.IDClassificacaoRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(getValuesUserPanel.User, "ManagerROClassificacao", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUserPanel.User, "ManagerROClassificacao", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerROCampanha(dtoRO getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                Int64 intResultado = 0;
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO RO_CAMPANHA ( NUMEROCAMPANHA, ID_RO )   ");
                            strSql.Append("                  VALUES ( @idCampanha, @IDRo )      ");

                            cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campanha));
                            cmdComando.Parameters.Add(new SqlParameter("@IDRo", getValues.IdRO));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM RO_CAMPANHA WHERE NUMEROCAMPANHA = @idCampanha ");

                            cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campanha));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 4:
                        {
                            strSql.Append(" UPDATE RO_CAMPANHA                              ");
                            strSql.Append("    SET REAGENDAMENTO = @Reagendamento,          ");
                            strSql.Append("        FLAG_REAGESPECIFICO = @FlagEspecifico,   ");
                            strSql.Append("        TEMPORETORNO = @TempoRetorno             ");
                            strSql.Append("  WHERE ID_RO_CAMPANHA = @idROCampanha           ");

                            cmdComando.Parameters.Add(new SqlParameter("@Reagendamento", getValues.ReagendamentoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagEspecifico", getValues.ReagendamentoEspecificoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@TempoRetorno", getValues.TempoReagendamentoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@idROCampanha", getValues.IDROCampanha));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(getValuesUserPanel.User, "ManagerROCampanha", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUserPanel.User, "ManagerROCampanha", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        /// <summary>
        /// Exclusivo Fidelity
        /// </summary>
        /// <param name="RO"></param>
        /// <returns></returns>
        public Int64 ManagerROCampanha_Fidelity(dtoRO getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                Int64 intResultado = 0;
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        {
                            strSql.Append(" UPDATE RO_CAMPANHA                              ");
                            strSql.Append("    SET REAGENDAMENTO = @Reagendamento           ");
                            strSql.Append("  WHERE ID_RO_CAMPANHA = @idROCampanha           ");

                            cmdComando.Parameters.Add(new SqlParameter("@Reagendamento", getValues.ReagendamentoRO));
                            cmdComando.Parameters.Add(new SqlParameter("@idROCampanha", getValues.IDROCampanha));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(getValuesUserPanel.User, "ManagerROCampanha_Fidelity", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUserPanel.User, "ManagerROCampanha_Fidelity", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public String calcularPorcentagem(int valorTotal, int valorParcial)
        {
            string resultado = String.Empty;
            double parcial = 0;

            if (valorParcial != 0 || valorTotal != 0)
            {
                parcial = (double)valorParcial / (double)valorTotal * 100;

                return Math.Round(parcial, 2).ToString();
            }
            else
            {
                parcial = 0;

                return Math.Round(parcial, 2).ToString();
            }
        }









        // NOVOS
        public String PAN_ManagerROCampanha(dtoRO getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                String strResultado = "";

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                strSql.Append("PAN_ManagerROCampanha");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", getValues.Campanha));
                cmdComando.Parameters.Add(new SqlParameter("@LISTRO", getValues.ListaRO));
                cmdComando.Parameters.Add(new SqlParameter("@ID_RO", getValues.IdRO));
                cmdComando.Parameters.Add(new SqlParameter("@ID_RO_CAMPANHA", getValues.IDROCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@REAGENDAMENTO", getValues.ReagendamentoRO));
                cmdComando.Parameters.Add(new SqlParameter("@FLAG_REAGESPECIFICO", getValues.ReagendamentoEspecificoRO));
                cmdComando.Parameters.Add(new SqlParameter("@TEMPORETORNO", getValues.TempoReagendamentoRO));

                cmdComando.Parameters.Add(new SqlParameter("@INVALIDATELEFONE", getValues.InvalidaTelefone));
                cmdComando.Parameters.Add(new SqlParameter("@FONEFORCADO", getValues.FoneForcado));

                cmdComando.Parameters.Add(new SqlParameter("@VISION", getValues.Vision));
                cmdComando.Parameters.Add(new SqlParameter("@NOTCALLREC", getValues.NotCallRec));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                if (drQuery.Read())
                {
                    strResultado = drQuery[0].ToString();
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUserPanel.User, "ManagerROCampanha_Fidelity", strSql.ToString());
                return strResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUserPanel.User, "ManagerROCampanha_Fidelity", strSql.ToString() + " >>> erro: " + e.Message);
                return "";
            }
        }
    }
}
