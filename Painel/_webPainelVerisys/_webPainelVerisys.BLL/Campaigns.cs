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
    public class Campaigns
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        Geral objGeral = new Geral();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();

        public SqlDataReader listCampaignDetails(dtoCampaign getValues)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CHAMADASPORAGENTELIVRE,              ");
                strSql.Append("        TEMPOPARAATENDIMENTO,                ");
                strSql.Append("        NUMEROTENTATIVAS,                    ");
                strSql.Append("        REAGENDAMENTONAOATENDIMENTO,         ");
                strSql.Append("        REAGENDAMENTOOCUPADO,                ");
                strSql.Append("        REAGENDAMENTOCONGESTIONAMENTO,       ");
                strSql.Append("        NUMEROTENTATIVAS_CONGESTIONAMENTO,   ");
                strSql.Append("        NUMEROTENTATIVAS_NAOATENDE,          ");
                strSql.Append("        NUMEROTENTATIVAS_OCUPADO,            ");
                strSql.Append("        INCINDICECAMPOFONENAOATENDIMENTO,    ");
                strSql.Append("        INCINDICECAMPOFONEOCUPADO,           ");
                strSql.Append("        INCINDICECAMPOFONECONGESTIONAMENTO,  ");
                strSql.Append("        QTDMAXCHAMADASSIMULTANEAS,           ");
                strSql.Append("        PREFIXOCLAUSULAWHERE,                ");
                strSql.Append("        INDICEAGRESSIVIDADEMAXIMO,           ");
                strSql.Append("        TIPOVARREDURA,                       ");
                strSql.Append("        MODODISCAGEM,                        ");
                strSql.Append("        IDREGRAROTA,                        ");
                strSql.Append("        IDREGRA                              ");
                strSql.Append("   FROM CAMPANHAS WITH(NOLOCK)               ");
                strSql.Append("  WHERE NUMERO = @idCampanha                 ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campaign));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return drQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Details >>> System Error: " + ex.Message);
            }
        }

        public SqlDataReader UINT_RecadoCP(String strCampanha)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_RecadoCP");

                cmdComando.Parameters.Add(new SqlParameter("@IDCAMPANHA", strCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return drQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list UINT_RecadoCP >>> System Error: " + ex.Message);
            }
        }

        public DataSet listCampaignModule(dtoCampaign getValues)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT MODU.IDMODULO									IDMODULO,               ");
                strSql.Append("        MODU.NOMEMODULO									NOMEMODULO,             ");
                strSql.Append("        MODU.DESCRICAO									DESCRICAO,              ");
                strSql.Append("        TABELARELAC.IDCAMPANHA							CAMPANHA,               ");
                strSql.Append("        CASE WHEN TABELARELAC.IDRELACIONAMENTO IS NULL                           ");
                strSql.Append("             THEN '0'                                                            ");
                strSql.Append("             ELSE '1' END								ACESSO                  ");
                strSql.Append("   FROM MODULO MODU WITH(NOLOCK)                                                 ");
                strSql.Append("        LEFT OUTER JOIN ( SELECT IDRELACIONAMENTO, IDCAMPANHA, NOMEMODULO        ");
                strSql.Append(" 		                   FROM MODULOCAMPANHA MCAM WITH(NOLOCK)                ");
                strSql.Append(" 		                  WHERE MCAM.IDCAMPANHA = @idCampanha ) AS TABELARELAC  ");
                strSql.Append(" 	   ON MODU.NomeModulo = TABELARELAC.NomeModulo                              ");
                strSql.Append("  WHERE MODULOFILHO = 1                                                          ");
                strSql.Append("    AND MODU.FLAG_ATIVO = 1                                                      ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campaign));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Module >>> System Error: " + ex.Message);
            }
        }

        public DataSet listCampaignDialSequence(String idRegra)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDDEFINICAO,                                                                                             ");
                strSql.Append("        MAG.DESCRICAO MODOAGRUPAMENTO_DESC,                                                                      ");
                strSql.Append("        MODOAGRUPAMENTO AS MODOAGRUPAMENTO,                                                                      ");
                strSql.Append("        SUBSTRING(CAST(CONVERT(nvarchar(30), HORAINICIAL, 126) AS VARCHAR(24)), 12, 8) AS HORAINICIAL_DESC,      ");
                strSql.Append("        HORAINICIAL AS HORAINICIAL,                                                                              ");
                strSql.Append("        SUBSTRING(CAST(CONVERT(nvarchar(30), HORAFINAL, 126) AS VARCHAR(24)), 12, 8) AS HORAFINAL_DESC,          ");
                strSql.Append("        HORAFINAL AS HORAFINAL,                                                                                  ");
                strSql.Append("        DEFINICAOSEQUENCIAMENTO,                                                                                 ");
                strSql.Append("        DEFINICAOSEQUENCIAMENTOUSERVIEW                                                                          ");
                strSql.Append("   FROM CAMPANHA_DEFINICAOSEQUENCIAMENTO CDE WITH(NOLOCK)                                                        ");
                strSql.Append("        INNER JOIN DIS_MODOAGRUPAMENTODIA MAG WITH(NOLOCK) ON CDE.ModoAgrupamento = MAG.ID                       ");
                strSql.Append("  WHERE IDRegra = @idRegra                                                                                       ");

                cmdComando.Parameters.Add(new SqlParameter("@idRegra", idRegra));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Dial Sequence >>> System Error: " + ex.Message);
            }
        }

        public DataSet listCampaignRulesSequence()
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDREGRA,                             ");
                strSql.Append("        NOMEREGRA,                           ");
                strSql.Append("        DATACRIACAO                          ");
                strSql.Append("   FROM [dbo].[Campanha_Regra] WITH(NOLOCK)  ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Dial Rules Sequence >>> System Error: " + ex.Message);
            }
        }

        public DataSet listCampaignStatistics(String strCampanha)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SP_DIS_EstatisticaCampanha");

                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", strCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Statistics >>> System Error: " + ex.Message);
            }
        }

        public DataSet listGroups()
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_ListGroups");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list listCampaignCanais >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignNotAssociatedGroup()
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("  SELECT NUMERO, NOME                                        ");
                strSql.Append("    FROM " + strLinkedServer + ".[CAMPANHAS] WITH(NOLOCK)    ");
                strSql.Append("   WHERE ModoDiscagem = 4                                    ");
                strSql.Append("     AND ATIVA = 1                                           ");
                strSql.Append("     AND DriverMailing = @driver                             ");
                strSql.Append("     AND NUMERO NOT IN (SELECT CAMPAIGN                      ");
                strSql.Append("                          FROM GROUPSCAMPAIGN WITH(NOLOCK))  ");

                cmdComando.Parameters.Add(new SqlParameter("@driver", "SQLOLEDB.1"));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Not Associated Group >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignAssociatedGroup(Int32 GroupID)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("  SELECT NUMERO, NOME                                        ");
                strSql.Append("    FROM " + strLinkedServer + ".[CAMPANHAS] WITH(NOLOCK)    ");
                strSql.Append("   WHERE ModoDiscagem = 4                                    ");
                strSql.Append("     AND ATIVA = 1                                           ");
                strSql.Append("     AND DriverMailing = @driver                             ");
                strSql.Append("     AND NUMERO IN ( SELECT CAMPAIGN                         ");
                strSql.Append("                       FROM GROUPSCAMPAIGN WITH(NOLOCK)      ");
                strSql.Append("                      WHERE GROUPID = @GROUPID )             ");

                cmdComando.Parameters.Add(new SqlParameter("@GROUPID", GroupID));
                cmdComando.Parameters.Add(new SqlParameter("@driver", "SQLOLEDB.1"));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Not Associated Group >>> System Error: " + ex.Message);
            }
        }
        public List<dtoCampaign> listCampaignAssociatedGroupAndMysql(Int32 GroupID)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("  SELECT NUMERO, NOME                                        ");
                strSql.Append("    FROM " + strLinkedServer + ".[CAMPANHAS] WITH(NOLOCK)    ");
                strSql.Append("   WHERE ModoDiscagem = 4                                    ");
                strSql.Append("     AND ATIVA = 1                                           ");
                strSql.Append("     AND NUMERO IN ( SELECT CAMPAIGN                         ");
                strSql.Append("                       FROM GROUPSCAMPAIGN WITH(NOLOCK)      ");
                strSql.Append("                      WHERE GROUPID = @GROUPID )             ");

                cmdComando.Parameters.Add(new SqlParameter("@GROUPID", GroupID));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Not Associated Group >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaignGroup> listCampaignAssociatedGroupUser(dtoUsers getValues)
        {
            List<dtoCampaignGroup> listObjAux = new List<dtoCampaignGroup>();
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT UG.GroupID	AS [GroupID],               ");
                strSql.Append("        GR.Grupo		AS [Grupo]                  ");
                strSql.Append("   FROM dbo.UsersGroup UG WITH(NOLOCK)           ");
                strSql.Append("        INNER JOIN dbo.Groups GR WITH(NOLOCK)    ");
                strSql.Append("                ON UG.GroupID = GR.ID            ");
                strSql.Append("  WHERE UG.idUser = @idUser                      ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaignGroup objAux = new dtoCampaignGroup();
                    objAux.GrupoID = Convert.ToInt32(drQuery["GroupID"].ToString());
                    objAux.Grupo = drQuery["Grupo"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaignGroup> listCampaignNotAssociatedGroupUser(dtoUsers getValues)
        {
            List<dtoCampaignGroup> listObjAux = new List<dtoCampaignGroup>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT GR.ID    	AS [GroupID],                                                       ");
                strSql.Append("        GR.Grupo		AS [Grupo]                                                          ");
                strSql.Append("   FROM dbo.Groups GR WITH(NOLOCK)                                                       ");
                strSql.Append("       LEFT OUTER JOIN dbo.UsersGroup UG ON UG.GroupID = GR.ID AND UG.idUser = @idUser   ");
                strSql.Append(" WHERE UG.IDUSER IS NULL                                                                 ");
                strSql.Append("   AND GR.Ativo = 1                                                                      ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaignGroup objAux = new dtoCampaignGroup();
                    objAux.GrupoID = Convert.ToInt32(drQuery["GroupID"].ToString());
                    objAux.Grupo = drQuery["Grupo"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaignGroup> listGroupsDto(String idGrupo)
        {
            try
            {
                List<dtoCampaignGroup> listObjAux = new List<dtoCampaignGroup>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_ListGroups");

                cmdComando.Parameters.Add(new SqlParameter("@GROUPID", idGrupo));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoCampaignGroup objAux = new dtoCampaignGroup();
                    objAux.GrupoID = Convert.ToInt32(drQuery["ID"].ToString());
                    objAux.Grupo = drQuery["Grupo"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list listCampaignCanais >>> System Error: " + ex.Message);
            }
        }

        public DataSet listCampaignStatisticsLOG(String strCampanha, String dtInicial, String dtFinal)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SP_HISTORICO_CALCULOCAMPANHAS");

                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", strCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@DATAINI", dtInicial));
                cmdComando.Parameters.Add(new SqlParameter("@DATAFIM", dtFinal));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Statistics >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaign()
        {
            // create a list of the objects
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT NUMERO, NOME ");
                strSql.Append("   FROM CAMPANHAS    ");
                strSql.Append("  WHERE ATIVA = 1    ");
                strSql.Append("    AND DriverMailing = @driver ");

                cmdComando.Parameters.Add(new SqlParameter("@driver", "SQLOLEDB.1"));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["Numero"].ToString();
                    objAux.NomeCampanha = drQuery["Numero"].ToString() + " - " + drQuery["Nome"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignAndMysql()
        {
            // create a list of the objects
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT NUMERO, NOME ");
                strSql.Append("   FROM CAMPANHAS    ");
                strSql.Append("  WHERE ATIVA = 1    ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["Numero"].ToString();
                    objAux.NomeCampanha = drQuery["Numero"].ToString() + " - " + drQuery["Nome"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignMetralhadora(String strGroupID)
        {
            // create a list of the objects
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT NUMERO, NOME,                                                                    ");
                strSql.Append("        QtdMaxChamadasSimultaneas,                                                       ");
                strSql.Append("        ISNULL(MetaCanaisSimultaneosEmAtendimento, 0) MetaCanaisSimultaneosEmAtendimento ");
                strSql.Append("   FROM " + strLinkedServer + ".[CAMPANHAS] CA WITH(NOLOCK)                          ");
                strSql.Append(" 	   INNER JOIN [dbo].[GroupsCampaign] GC WITH(NOLOCK) ON CA.Numero = GC.Campaign     ");
                strSql.Append("  WHERE ATIVA = 1                                                                        ");
                strSql.Append("    AND ModoDiscagem = 4                                                                 ");
                strSql.Append("     AND DriverMailing = @driver                             ");
                strSql.Append("    AND GC.GroupID = @GroupID ");

                cmdComando.Parameters.Add(new SqlParameter("@driver", "SQLOLEDB.1"));
                cmdComando.Parameters.Add(new SqlParameter("@GroupID", strGroupID));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["Numero"].ToString();
                    objAux.NomeCampanha = drQuery["Numero"].ToString() + " - " + drQuery["Nome"].ToString();
                    objAux.QtdMaxChamadasSimultaneas = drQuery["QtdMaxChamadasSimultaneas"].ToString();
                    objAux.MetaCanaisSimultaneosEmAtendimento = Convert.ToInt32(drQuery["MetaCanaisSimultaneosEmAtendimento"].ToString());
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaignRule> listCampaignRules()
        {
            // create a list of the objects
            List<dtoCampaignRule> listObjAux = new List<dtoCampaignRule>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDREGRA, NOMEREGRA           ");
                strSql.Append("   FROM CAMPANHA_REGRA WITH(NOLOCK)  ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaignRule objAux = new dtoCampaignRule();
                    objAux.NumeroRegra = drQuery["IDREGRA"].ToString();
                    objAux.NomeRegra = drQuery["NOMEREGRA"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public List<dtoModoAgrupamentoDia> listModoAgrupamentoDia()
        {
            // create a list of the objects
            List<dtoModoAgrupamentoDia> listObjAux = new List<dtoModoAgrupamentoDia>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID                                           ");
                strSql.Append("       ,DESCRICAO                                    ");
                strSql.Append(" FROM [dbo].[DIS_ModoAgrupamentoDia] WITH(NOLOCK)    ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoModoAgrupamentoDia objAux = new dtoModoAgrupamentoDia();
                    objAux.ID = drQuery["ID"].ToString();
                    objAux.Descricao = drQuery["DESCRICAO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignAssociated(dtoUsers getValues)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.NUMERO, C.NOME                                                         ");
                strSql.Append("   FROM USERSCAMPAIGN UC                                                         ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".CAMPANHAS C ON UC.CAMPAIGN = C.NUMERO ");
                strSql.Append("  WHERE IDUSER = @idUser                                                         ");
                strSql.Append("    AND DriverMailing = @driver                                                  ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));
                cmdComando.Parameters.Add(new SqlParameter("@driver", "SQLOLEDB.1"));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }
        public List<dtoCampaign> listCampaignAssociatedAndMysql(dtoUsers getValues)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.NUMERO, C.NOME                                                         ");
                strSql.Append("   FROM USERSCAMPAIGN UC                                                         ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".CAMPANHAS C ON UC.CAMPAIGN = C.NUMERO ");
                strSql.Append("  WHERE IDUSER = @idUser                                                         ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignAssociatedModule(dtoUsers getValues, String Module)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.NUMERO, C.NOME                                                         ");
                strSql.Append("   FROM USERSCAMPAIGN UC WITH(NOLOCK)                                            ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".CAMPANHAS C ON UC.CAMPAIGN = C.NUMERO ");
                strSql.Append("  WHERE IDUSER = @idUser                                                         ");
                strSql.Append("     AND DriverMailing = @driver                             ");
                strSql.Append("     AND C.NUMERO IN ( SELECT IDCAMPANHA                                         ");
                strSql.Append("                         FROM MODULOCAMPANHA WITH(NOLOCK)                        ");
                strSql.Append("                        WHERE NOMEMODULO = @strModule )                          ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));
                cmdComando.Parameters.Add(new SqlParameter("@strModule", Module));
                cmdComando.Parameters.Add(new SqlParameter("@driver", "SQLOLEDB.1"));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignAssociatedModuleAndMysql(dtoUsers getValues, String Module)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.NUMERO, C.NOME                                                         ");
                strSql.Append("   FROM USERSCAMPAIGN UC WITH(NOLOCK)                                            ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".CAMPANHAS C ON UC.CAMPAIGN = C.NUMERO ");
                strSql.Append("  WHERE IDUSER = @idUser                                                         ");
                strSql.Append("     AND C.NUMERO IN ( SELECT IDCAMPANHA                                         ");
                strSql.Append("                         FROM MODULOCAMPANHA WITH(NOLOCK)                        ");
                strSql.Append("                        WHERE NOMEMODULO = @strModule )                          ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));
                cmdComando.Parameters.Add(new SqlParameter("@strModule", Module));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }


        public List<dtoCampaign> listCampaignNotAssociated(dtoUsers getValues)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.NUMERO, C.NOME                                                                     ");
                strSql.Append("   FROM " + strLinkedServer + ".CAMPANHAS C                                                  ");
                strSql.Append("        LEFT OUTER JOIN USERSCAMPAIGN UC ON UC.CAMPAIGN = C.NUMERO AND UC.IDUSER = @idUser   ");
                strSql.Append("  WHERE UC.IDUSER IS NULL                                                                    ");
                strSql.Append("    AND C.ATIVA = 1                                                                          ");
                strSql.Append("     AND DriverMailing = @driver                             ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));
                cmdComando.Parameters.Add(new SqlParameter("@driver", "SQLOLEDB.1"));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listCampaignNotAssociatedAndMysql(dtoUsers getValues)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT C.NUMERO, C.NOME                                                                     ");
                strSql.Append("   FROM " + strLinkedServer + ".CAMPANHAS C                                                  ");
                strSql.Append("        LEFT OUTER JOIN USERSCAMPAIGN UC ON UC.CAMPAIGN = C.NUMERO AND UC.IDUSER = @idUser   ");
                strSql.Append("  WHERE UC.IDUSER IS NULL                                                                    ");
                strSql.Append("    AND C.ATIVA = 1                                                                          ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.Campaign = drQuery["NUMERO"].ToString();
                    objAux.NomeCampanha = drQuery["NUMERO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Associated >>> System Error: " + ex.Message);
            }
        }



        public List<dtoCampaignMascara> listCampaignMask(String strCampanha)
        {
            // create a list of the objects
            List<dtoCampaignMascara> listObjAux = new List<dtoCampaignMascara>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDMASCARA, MASCARA, COALESCE(ORDEM, 99, ORDEM) AS ORDEM ");
                strSql.Append("   FROM CAMPANHA_MULTICAMPO          ");
                strSql.Append("  WHERE IDCAMPANHA = @idCampanha     ");
                strSql.Append("  ORDER BY ORDEM                     ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaignMascara objAux = new dtoCampaignMascara();
                    objAux.IDMascara = drQuery["IDMASCARA"].ToString();

                    if (drQuery["ORDEM"].ToString() != "99")
                        objAux.Mascara = "+ " + drQuery["MASCARA"].ToString();
                    else
                        objAux.Mascara = drQuery["MASCARA"].ToString();

                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaignMascara> listCampaignMaskSequence(String Sequence, String strCampanha)
        {
            List<dtoCampaignMascara> listObjAux = new List<dtoCampaignMascara>();

            try
            {
                Boolean bolDDD1 = false;
                Boolean bolDDD2 = false;
                Boolean bolDDD3 = false;
                Boolean bolDDD4 = false;
                Boolean bolDDD5 = false;

                String strSequenciamento = Sequence;
                while (Sequence.Length > 45)
                {
                    dtoCampaignMascara objAux = new dtoCampaignMascara();

                    Int32 posicao = Sequence.IndexOf('+');
                    objAux.DDD = Sequence.Substring(0, posicao).Trim();
                    Sequence = Sequence.Substring(posicao + 1, Sequence.Length - posicao - 1);

                    Int32 posicao2 = Sequence.IndexOf('#');
                    objAux.Fone = "+ " + Sequence.Substring(0, posicao2).Trim();
                    Sequence = Sequence.Substring(posicao2 + 1, Sequence.Length - posicao2 - 1);

                    Int32 posicao3 = Sequence.IndexOf("DDD");
                    Sequence = Sequence.Substring(posicao3 == -1 ? 0 : posicao3, Sequence.Length - (posicao3 == -1 ? 0 : posicao3));

                    if (objAux.DDD == "DDD1")
                        bolDDD1 = true;
                    if (objAux.DDD == "DDD2")
                        bolDDD2 = true;
                    if (objAux.DDD == "DDD3")
                        bolDDD3 = true;
                    if (objAux.DDD == "DDD4")
                        bolDDD4 = true;
                    if (objAux.DDD == "DDD5")
                        bolDDD5 = true;

                    listObjAux.Add(objAux);
                }

                if (bolDDD1 == false)
                {
                    dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                    objAux2.DDD = "DDD1";
                    objAux2.Fone = "FONE1";
                    listObjAux.Add(objAux2);
                }
                if (bolDDD2 == false)
                {
                    dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                    objAux2.DDD = "DDD2";
                    objAux2.Fone = "FONE2";
                    listObjAux.Add(objAux2);
                }
                if (bolDDD3 == false)
                {
                    dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                    objAux2.DDD = "DDD3";
                    objAux2.Fone = "FONE3";
                    listObjAux.Add(objAux2);
                }
                if (bolDDD4 == false)
                {
                    dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                    objAux2.DDD = "DDD4";
                    objAux2.Fone = "FONE4";
                    listObjAux.Add(objAux2);
                }
                if (bolDDD5 == false)
                {
                    dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                    objAux2.DDD = "DDD5";
                    objAux2.Fone = "FONE5";
                    listObjAux.Add(objAux2);
                }

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaignMascara> listCampaignMaskSequence(String Sequence, String strCampanha, Boolean bolUse)
        {
            List<dtoCampaignMascara> listObjAux = new List<dtoCampaignMascara>();

            try
            {
                Boolean bolDDD1 = false;
                Boolean bolDDD2 = false;
                Boolean bolDDD3 = false;
                Boolean bolDDD4 = false;
                Boolean bolDDD5 = false;

                String strSequenciamento = Sequence;
                while (Sequence.Length > 45)
                {
                    dtoCampaignMascara objAux = new dtoCampaignMascara();

                    Int32 posicao = Sequence.IndexOf('+');
                    objAux.DDD = Sequence.Substring(0, posicao).Trim();
                    Sequence = Sequence.Substring(posicao + 1, Sequence.Length - posicao - 1);

                    Int32 posicao2 = Sequence.IndexOf('#');
                    objAux.Fone = Sequence.Substring(0, posicao2).Trim();
                    Sequence = Sequence.Substring(posicao2 + 1, Sequence.Length - posicao2 - 1);

                    Int32 posicao3 = Sequence.IndexOf("DDD");
                    Sequence = Sequence.Substring(posicao3 == -1 ? 0 : posicao3, Sequence.Length - (posicao3 == -1 ? 0 : posicao3));

                    if (objAux.DDD == "DDD1")
                        bolDDD1 = true;
                    if (objAux.DDD == "DDD2")
                        bolDDD2 = true;
                    if (objAux.DDD == "DDD3")
                        bolDDD3 = true;
                    if (objAux.DDD == "DDD4")
                        bolDDD4 = true;
                    if (objAux.DDD == "DDD5")
                        bolDDD5 = true;

                    if (bolUse)
                        listObjAux.Add(objAux);
                }

                if (!bolUse)
                {
                    if (bolDDD1 == false)
                    {
                        dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                        objAux2.DDD = "DDD1";
                        objAux2.Fone = "FONE1";
                        listObjAux.Add(objAux2);
                    }
                    if (bolDDD2 == false)
                    {
                        dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                        objAux2.DDD = "DDD2";
                        objAux2.Fone = "FONE2";
                        listObjAux.Add(objAux2);
                    }
                    if (bolDDD3 == false)
                    {
                        dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                        objAux2.DDD = "DDD3";
                        objAux2.Fone = "FONE3";
                        listObjAux.Add(objAux2);
                    }
                    if (bolDDD4 == false)
                    {
                        dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                        objAux2.DDD = "DDD4";
                        objAux2.Fone = "FONE4";
                        listObjAux.Add(objAux2);
                    }
                    if (bolDDD5 == false)
                    {
                        dtoCampaignMascara objAux2 = new dtoCampaignMascara();
                        objAux2.DDD = "DDD5";
                        objAux2.Fone = "FONE5";
                        listObjAux.Add(objAux2);
                    }
                }

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public SqlDataReader listCampaignMaskDetails(String strCampanha, Int32 Mascara)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CAMPODDD,                ");
                strSql.Append("        CAMPOFONE,               ");
                strSql.Append("        HORAINICIAL,             ");
                strSql.Append("        HORAFINAL                ");
                strSql.Append("   FROM CAMPANHA_MULTICAMPO      ");
                strSql.Append("  WHERE IDCAMPANHA = @idCampanha ");
                strSql.Append("    AND IDMASCARA = @idMascara ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@idMascara", Mascara));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return drQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Details >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listLot(dtoCampaign getValues)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strTabelaDiscador = BuscaTabelaDiscador(getValues.Campaign);

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT DISTINCT(NUMLOTE) NUMLOTE                ");
                strSql.Append("   FROM " + strTabelaDiscador + " WITH(NOLOCK)   ");
                strSql.Append("  WHERE NUMLOTE IS NOT NULL                      ");
                strSql.Append("  ORDER BY NUMLOTE DESC                          ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.NumeroLote = drQuery["NUMLOTE"].ToString();
                    objAux.NomeLote = drQuery["NUMLOTE"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Lot >>> System Error: " + ex.Message);
            }
        }

        public List<dtoCampaign> listLotAssociated(dtoCampaign getValues)
        {
            List<dtoCampaign> listObjAux = new List<dtoCampaign>();
            String strTabelaDiscador = BuscaTabelaDiscador(getValues.Campaign);

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT DISTINCT(NUMLOTE) NUMLOTE                ");
                strSql.Append("   FROM " + strTabelaDiscador + " WITH(NOLOCK)   ");
                strSql.Append("  WHERE ID_CAMPANHA = @idCampanha                ");
                strSql.Append("    AND NUMLOTE IS NOT NULL                      ");
                strSql.Append("  ORDER BY NUMLOTE DESC                          ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campaign));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoCampaign objAux = new dtoCampaign();
                    objAux.NumeroLote = drQuery["NUMLOTE"].ToString();
                    objAux.NomeLote = drQuery["NUMLOTE"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Lot Associated >>> System Error: " + ex.Message);
            }
        }

        public List<dtoIdentificadores> listIdentificadoresAssociados(dtoCampaign getValues)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("   SELECT KEYID, IDCAMPANHA, IDENTIFICADOR       ");
                strSql.Append("     FROM [dbo].[IdentificadorLote] WITH(NOLOCK) ");
                strSql.Append("    WHERE IDCAMPANHA = @idCampanha               ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campaign));
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                List<dtoIdentificadores> listObjAux = new List<dtoIdentificadores>();
                while (drQuery.Read())
                {
                    dtoIdentificadores objAux = new dtoIdentificadores();
                    objAux.IDCampanha = drQuery["IDCAMPANHA"].ToString();
                    objAux.Identificador = drQuery["IDENTIFICADOR"].ToString();

                    listObjAux.Add(objAux);
                }
                drQuery.Close();
                return listObjAux;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list listIdentificadoresAssociados >>> System Error: " + ex.Message);
            }
        }

        public Int64 managerCampaign(dtoCampaign getValues)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE CAMPANHAS                                                                 ");
                            strSql.Append("    SET CHAMADASPORAGENTELIVRE = CAST(@CHAMADASPORAGENTELIVRE AS FLOAT),          ");
                            strSql.Append("        TEMPOPARAATENDIMENTO = @TEMPOPARAATENDIMENTO,                             ");
                            strSql.Append("        NUMEROTENTATIVAS = @NUMEROTENTATIVAS,                                     ");
                            strSql.Append("        REAGENDAMENTONAOATENDIMENTO = @REAGENDAMENTONAOATENDIMENTO,               ");
                            strSql.Append("        REAGENDAMENTOOCUPADO = @REAGENDAMENTOOCUPADO,                             ");
                            strSql.Append("        REAGENDAMENTOCONGESTIONAMENTO = @REAGENDAMENTOCONGESTIONAMENTO,           ");
                            strSql.Append("        NUMEROTENTATIVAS_CONGESTIONAMENTO = @NUMEROTENTATIVAS_CONGESTIONAMENTO,   ");
                            strSql.Append("        NUMEROTENTATIVAS_NAOATENDE = @NUMEROTENTATIVAS_NAOATENDE,                 ");
                            strSql.Append("        NUMEROTENTATIVAS_OCUPADO = @NUMEROTENTATIVAS_OCUPADO,                     ");
                            strSql.Append("        IncIndiceCampoFoneNaoAtendimento = @IncIndiceCampoFoneNaoAtendimento,     ");
                            strSql.Append("        IncIndiceCampoFoneOcupado = @IncIndiceCampoFoneOcupado,                   ");
                            strSql.Append("        IncIndiceCampoFoneCongestionamento = @IncIndiceCampoFoneCongestionamento, ");
                            strSql.Append("        PrefixoClausulaWhere = @PrefixoClausulaWhere,                             ");
                            strSql.Append("        IndiceAgressividadeMaximo = @IndiceAgressividadeMaximo,                   ");
                            strSql.Append("        TipoVarredura = @TipoVarredura,                                           ");
                            strSql.Append("        IdRegraRota = @idRegraRota,                                               ");
                            strSql.Append("        IdRegra = @idRegra                                                        ");

                            if (getValues.MultiCampo != String.Empty)
                                strSql.Append("        ,DefinicaoSequenciamento = @DefinicaoSequenciamento                   ");

                            strSql.Append("  WHERE NUMERO = @ID_CAMPANHA                                                     ");

                            cmdComando.Parameters.Add(new SqlParameter("@CHAMADASPORAGENTELIVRE", Convert.ToDouble(getValues.ChamadasAgenteLivre)));
                            cmdComando.Parameters.Add(new SqlParameter("@TEMPOPARAATENDIMENTO", getValues.TempoAtendimento));
                            cmdComando.Parameters.Add(new SqlParameter("@NUMEROTENTATIVAS", getValues.NumeroTentativas));
                            cmdComando.Parameters.Add(new SqlParameter("@REAGENDAMENTONAOATENDIMENTO", getValues.ReagendamentoNaoAtendimento));
                            cmdComando.Parameters.Add(new SqlParameter("@REAGENDAMENTOOCUPADO", getValues.ReagendamentoOcupado));
                            cmdComando.Parameters.Add(new SqlParameter("@REAGENDAMENTOCONGESTIONAMENTO", getValues.ReagendamentoCongestionamento));
                            cmdComando.Parameters.Add(new SqlParameter("@NUMEROTENTATIVAS_CONGESTIONAMENTO", getValues.NumeroTentativas_Congestionamento));
                            cmdComando.Parameters.Add(new SqlParameter("@NUMEROTENTATIVAS_NAOATENDE", getValues.NumeroTentativas_NaoAtende));
                            cmdComando.Parameters.Add(new SqlParameter("@NUMEROTENTATIVAS_OCUPADO", getValues.NumeroTentativas_Ocupado));
                            cmdComando.Parameters.Add(new SqlParameter("@IncIndiceCampoFoneNaoAtendimento", getValues.IndiceCampoFoneNaoAtendimento));
                            cmdComando.Parameters.Add(new SqlParameter("@IncIndiceCampoFoneOcupado", getValues.IndiceCampoFoneOcupado));
                            cmdComando.Parameters.Add(new SqlParameter("@IncIndiceCampoFoneCongestionamento", getValues.IndiceCampoFoneCongestionamento));
                            cmdComando.Parameters.Add(new SqlParameter("@PrefixoClausulaWhere", getValues.PrefixoClausulaWhere));
                            cmdComando.Parameters.Add(new SqlParameter("@IndiceAgressividadeMaximo", getValues.IndiceAgressividadeMaximo));
                            cmdComando.Parameters.Add(new SqlParameter("@TipoVarredura", getValues.TipoVarredura));
                            cmdComando.Parameters.Add(new SqlParameter("@idRegra", getValues.IDRegra));
                            cmdComando.Parameters.Add(new SqlParameter("@idRegraRota", getValues.IDRegraRota));

                            if (getValues.MultiCampo != String.Empty)
                                cmdComando.Parameters.Add(new SqlParameter("@DefinicaoSequenciamento", getValues.MultiCampo));

                            cmdComando.Parameters.Add(new SqlParameter("@ID_CAMPANHA", getValues.Campaign));
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" UPDATE RECADOCP                     ");
                            strSql.Append("    SET FLAG_ATIVO = @FLAGATIVO      ");
                            strSql.Append("  WHERE IDCAMPANHA = @IDCAMPANHA     ");

                            cmdComando.Parameters.Add(new SqlParameter("@FLAGATIVO", getValues.RecadoCPAtivo));
                            cmdComando.Parameters.Add(new SqlParameter("@IDCAMPANHA", getValues.Campaign));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            intResultado = 0;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(getValues.User, "CAMPANHAS", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "CAMPANHAS", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public void managerCampaignMask(Int32 idMascara, Int32 iPosicao)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" UPDATE CAMPANHA_MULTICAMPO      ");
                strSql.Append("    SET ORDEM = @iPosicao        ");
                strSql.Append("  WHERE IDMASCARA = @idMascara   ");

                cmdComando.Parameters.Add(new SqlParameter("@iPosicao", iPosicao));
                cmdComando.Parameters.Add(new SqlParameter("@idMascara", idMascara));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
            }
            catch (Exception e)
            {

            }
        }

        public void ManagerCampaignMask_Clear(String strCampanha)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" UPDATE CAMPANHA_MULTICAMPO      ");
                strSql.Append("    SET ORDEM = 99               ");
                strSql.Append("  WHERE IDCAMPANHA = @idCampanha ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
            }
            catch
            {

            }
        }

        public Int64 managerCampaignModule(dtoCampaign getValues)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 2:
                        {
                            strSql.Append("CAMPAIGNMODULE");

                            cmdComando.Parameters.Add(new SqlParameter("@IDCampanha", getValues.Campaign));
                            cmdComando.Parameters.Add(new SqlParameter("@Modulo", getValues.Modulo));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            intResultado = 0;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(getValues.User, "CAMPANHASMODULO", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "CAMPANHASMODULO", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 managerCampaignCanais(String strCampanha, Int32 intMeta, Int32 idGrupo)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                strSql.Append("UINT_CampanhaCanais");
                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", strCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@META", intMeta));
                cmdComando.Parameters.Add(new SqlParameter("@GRUPOID", idGrupo));
                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                intResultado = 1;

                objGeral.logSQL("", "managerCampaignCanais", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL("", "managerCampaignCanais", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 managerCampaignRulesSequence(dtoCampaignRule getValues)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT                                                                                  ");
                            strSql.Append("   INTO Campanha_DefinicaoSequenciamento                                                 ");
                            strSql.Append("      ( IDREGRA, MODOAGRUPAMENTO, HORAINICIAL, HORAFINAL, DEFINICAOSEQUENCIAMENTO, DEFINICAOSEQUENCIAMENTOUSERVIEW )      ");
                            strSql.Append(" VALUES                                                                                  ");
                            strSql.Append("      ( @idRegra, @ModoAgrupamento, @HoraInicial, @HoraFinal, @DefinicaoSequenciamento, @DefinicaoSequenciamentoUserView ) ");

                            cmdComando.Parameters.Add(new SqlParameter("@idRegra", getValues.NumeroRegra));
                            cmdComando.Parameters.Add(new SqlParameter("@ModoAgrupamento", getValues.IDModoAgrupamento));
                            cmdComando.Parameters.Add(new SqlParameter("@HoraInicial", getValues.HoraInicial));
                            cmdComando.Parameters.Add(new SqlParameter("@HoraFinal", getValues.HoraFinal));
                            cmdComando.Parameters.Add(new SqlParameter("@DefinicaoSequenciamento", getValues.DefinicaoSequenciamento));
                            cmdComando.Parameters.Add(new SqlParameter("@DefinicaoSequenciamentoUserView", getValues.DefinicaoSequenciamentoUserView));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE CAMPANHA_DEFINICAOSEQUENCIAMENTO                                     ");
                            strSql.Append("    SET IDREGRA = @idRegra,                                                  ");
                            strSql.Append("        MODOAGRUPAMENTO = @ModoAgrupamento,                                  ");
                            strSql.Append("        HORAINICIAL = @HoraInicial,                                          ");
                            strSql.Append("        HORAFINAL = @HoraFinal,                                              ");
                            strSql.Append("        DEFINICAOSEQUENCIAMENTO = @DefinicaoSequenciamento,                  ");
                            strSql.Append("        DEFINICAOSEQUENCIAMENTOUSERVIEW = @DefinicaoSequenciamentoUserView   ");
                            strSql.Append("  WHERE IDDEFINICAO = @idSequenciamento                                      ");


                            cmdComando.Parameters.Add(new SqlParameter("@idRegra", getValues.NumeroRegra));
                            cmdComando.Parameters.Add(new SqlParameter("@ModoAgrupamento", getValues.IDModoAgrupamento));
                            cmdComando.Parameters.Add(new SqlParameter("@HoraInicial", getValues.HoraInicial));
                            cmdComando.Parameters.Add(new SqlParameter("@HoraFinal", getValues.HoraFinal));
                            cmdComando.Parameters.Add(new SqlParameter("@DefinicaoSequenciamento", getValues.DefinicaoSequenciamento));
                            cmdComando.Parameters.Add(new SqlParameter("@DefinicaoSequenciamentoUserView", getValues.DefinicaoSequenciamentoUserView));
                            cmdComando.Parameters.Add(new SqlParameter("@idSequenciamento", getValues.IdSequenciamento));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM CAMPANHA_DEFINICAOSEQUENCIAMENTO    ");
                            strSql.Append("  WHERE IDDEFINICAO = @idSequenciamento          ");

                            cmdComando.Parameters.Add(new SqlParameter("@idSequenciamento", getValues.IdSequenciamento));

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

                objGeral.logSQL(getValues.User, "CAMPANHAS", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "CAMPANHAS", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 managerCampaignRulesNameSequence(dtoCampaignRule getValues)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT                          ");
                            strSql.Append("   INTO CAMPANHA_REGRA           ");
                            strSql.Append("      ( NOMEREGRA, DATACRIACAO ) ");
                            strSql.Append(" VALUES                          ");
                            strSql.Append("      ( @NomeRegra, GetDate() )  ");

                            cmdComando.Parameters.Add(new SqlParameter("@NomeRegra", getValues.NomeRegra));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE CAMPANHA_REGRA           ");
                            strSql.Append("    SET NOMEREGRA = @NomeRegra,  ");
                            strSql.Append("        DATACRIACAO = GetDate()  ");
                            strSql.Append("  WHERE IDREGRA = @idRegra       ");

                            cmdComando.Parameters.Add(new SqlParameter("@NomeRegra", getValues.NomeRegra));
                            cmdComando.Parameters.Add(new SqlParameter("@idRegra", getValues.NumeroRegra));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM CAMPANHA_REGRA  ");
                            strSql.Append("  WHERE IDREGRA = @idRegra   ");

                            cmdComando.Parameters.Add(new SqlParameter("@idRegra", getValues.NumeroRegra));

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

                objGeral.logSQL(getValues.User, "CAMPANHAS", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "CAMPANHAS", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 managerGroups(dtoCampaignGroup getValues)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT                                          ");
                            strSql.Append("   INTO [dbo].[Groups]                           ");
                            strSql.Append("        ( [Grupo], [QtdeMaximaCanais], [Ativo] ) ");
                            strSql.Append(" VALUES ( @Grupo, @QtdeMaximaCanais, @Ativo)     ");

                            cmdComando.Parameters.Add(new SqlParameter("@Grupo", getValues.Grupo));
                            cmdComando.Parameters.Add(new SqlParameter("@QtdeMaximaCanais", getValues.QtdeMaximaCanais));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            if (intResultado > 0)
                            {
                                cmdComando.Parameters.Clear();
                                strSql.Remove(0, strSql.Length);
                                strSql.Append(" INSERT INTO [dbo].[GroupsCampaign]              ");
                                strSql.Append("             ( [GroupID], [Campaign] )           ");
                                strSql.Append("  SELECT " + intResultado + ", ITEM FROM SPLIT (@Campanha, ',', null)  ");

                                cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campaigns));
                                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            }
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[Groups]                           ");
                            strSql.Append("    SET [Grupo] = @Grupo                         ");
                            strSql.Append("       ,[QtdeMaximaCanais] = @QtdeMaximaCanais   ");
                            strSql.Append("       ,[Ativo] = @Ativo                         ");
                            strSql.Append("  WHERE [ID] = @GrupoID                          ");

                            cmdComando.Parameters.Add(new SqlParameter("@GrupoID", getValues.GrupoID));
                            cmdComando.Parameters.Add(new SqlParameter("@Grupo", getValues.Grupo));
                            cmdComando.Parameters.Add(new SqlParameter("@QtdeMaximaCanais", getValues.QtdeMaximaCanais));
                            cmdComando.Parameters.Add(new SqlParameter("@Ativo", getValues.Ativo));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = getValues.GrupoID;

                            if (intResultado > 0)
                            {
                                cmdComando.Parameters.Clear();
                                strSql.Remove(0, strSql.Length);
                                strSql.Append(" DELETE FROM [dbo].[GroupsCampaign]  ");
                                strSql.Append("  WHERE [GroupID] = @GrupoID         ");

                                cmdComando.Parameters.Add(new SqlParameter("@GrupoID", getValues.GrupoID));
                                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                                cmdComando.Parameters.Clear();
                                strSql.Remove(0, strSql.Length);
                                strSql.Append(" INSERT INTO [dbo].[GroupsCampaign]              ");
                                strSql.Append("             ( [GroupID], [Campaign] )           ");
                                strSql.Append("  SELECT " + intResultado + ", ITEM FROM SPLIT (@Campanha, ',', null)  ");

                                cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campaigns));
                                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            }
                        }
                        break;
                    case 3:
                        {
                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" DELETE FROM [dbo].[GroupsCampaign]  ");
                            strSql.Append("  WHERE [GroupID] = @GrupoID         ");

                            cmdComando.Parameters.Add(new SqlParameter("@GrupoID", getValues.GrupoID));
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);



                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" DELETE FROM [dbo].[Groups]  ");
                            strSql.Append("  WHERE [ID] = @GrupoID      ");

                            cmdComando.Parameters.Add(new SqlParameter("@GrupoID", getValues.GrupoID));
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = getValues.GrupoID;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL("", "Groups", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL("", "Groups", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public String BuscaTabelaDiscador(String strCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT TABELADISCAGEM           ");
                strSql.Append("   FROM CAMPANHAS WITH(NOLOCK)   ");
                strSql.Append("  WHERE NUMERO = @idCampanha     ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));
                DataSet dsCampanha = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                if (dsCampanha.Tables[0].Rows.Count > 0)
                {
                    return dsCampanha.Tables[0].Rows[0]["TABELADISCAGEM"].ToString();
                }
                else
                {
                    return "TABELADISCADOR";
                }
            }
            catch (Exception eBuscaTabelaDiscador)
            {
                throw;
            }
        }

        public String BuscaCampoMotivo(String strCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CAMPOMOTIVOREAGENDAMENTO ");
                strSql.Append("   FROM CAMPANHAS WITH(NOLOCK)   ");
                strSql.Append("  WHERE NUMERO = @idCampanha     ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));
                DataSet dsCampanha = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                if (dsCampanha.Tables[0].Rows.Count > 0)
                {
                    return dsCampanha.Tables[0].Rows[0]["CAMPOMOTIVOREAGENDAMENTO"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception eBuscaTabelaDiscador)
            {
                throw;
            }
        }

        //CRUD RULENAMES
        public dtoResponse MANAGERRULES(dtoTelecomRules getValues)
        {
            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_MANAGERRULES");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@IDRULE", getValues.IdRule));
                cmdComando.Parameters.Add(new SqlParameter("@NAME", getValues.DsRule));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    objResponse.Result = drQuery["RESULT"].ToString();
                    objResponse.ResultCode = Convert.ToInt32(drQuery["RESULTCODE"].ToString());
                }
                drQuery.Close();

                return objResponse;
            }
            catch (Exception e)
            {

                throw new Exception("Error bllTelecom.PAN_MANAGERRULES >>> System Error: " + e.Message);
            }
        }


        public DataSet listRules()
        {
            // create a list of the objects

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDRULE, NAME     ");
                strSql.Append("   FROM DIALINGRULESNAME ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }


    }
}
