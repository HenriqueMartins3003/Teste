using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class Mailings
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();
        Campaigns objCampanha = new Campaigns();

        public DataSet listSegmentacao(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_SEGMENTACAO,                  ");
                strSql.Append("        NOME_SEGMENTACAO,                ");
                strSql.Append("        NUMERO_CAMPANHA,                 ");
                strSql.Append("        NUMERO_LOTE,                     ");
                strSql.Append("        PRIORIDADE,                      ");
                strSql.Append("        FLAG_ATIVO IDFLAG,               ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 1         ");
                strSql.Append("             THEN 'SIM'                  ");
                strSql.Append("             ELSE 'NÃO' END FLAG_ATIVO   ");
                strSql.Append("   FROM SEGMENTACAO WITH(NOLOCK)         ");
                

                if (getValues.IDSegmentacao != string.Empty)
                {
                    strSql.Append("   WHERE ID_SEGMENTACAO = @idSegmentacao     ");
                    cmdComando.Parameters.Add(new SqlParameter("@idSegmentacao", getValues.IDSegmentacao));
                }

                strSql.Append("  ORDER BY ID_SEGMENTACAO                ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUsers.User, "SEGMENTACAO", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Segmentacao >>> System Error: " + ex.Message);
            }
        }

        public DataSet listSegmentacaoProcesso(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_SEGMENTACAO,                  ");
                strSql.Append("        NOME_SEGMENTACAO,                ");
                strSql.Append("        NUMERO_CAMPANHA,                 ");
                strSql.Append("        NUMERO_LOTE,                     ");
                strSql.Append("        PRIORIDADE,                      ");
                strSql.Append("        FLAG_ATIVO IDFLAG,               ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 1         ");
                strSql.Append("             THEN 'SIM'                  ");
                strSql.Append("             ELSE 'NÃO' END FLAG_ATIVO   ");
                strSql.Append("   FROM SEGMENTACAO WITH(NOLOCK)         ");
                strSql.Append("  WHERE NUMERO_LOTE <> '99999'           ");
                strSql.Append("  ORDER BY ID_SEGMENTACAO                ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUsers.User, "SEGMENTACAO", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Segmentacao >>> System Error: " + ex.Message);
            }
        }

        public DataSet listSegmentacaoRegras(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_SEGMENTACAOREGRA				[ID_SEGMENTACAOREGRA],  ");
                strSql.Append("        ISNULL(ABRE_PARENTESES, '')		[ABRE_PARENTESES],      ");
                strSql.Append("        CASE CONJUNCAO                                           ");
                strSql.Append("             WHEN 'AND' THEN 'E'                                 ");
                strSql.Append("             WHEN 'OR'  THEN 'OU'                                ");
                strSql.Append("             ELSE 'E'	                                        ");
                strSql.Append("         END								[CONJUNCAO],            ");
                strSql.Append("        CAMPO_SEGMENTACAO				[CAMPO_SEGMENTACAO],    ");
                strSql.Append("        REGRA_SEGMENTACAO				[REGRA_SEGMENTACAO],    ");
                strSql.Append("        VALOR_SEGMENTACAO				[VALOR_SEGMENTACAO],    ");
                strSql.Append("        TABELA_SEGMENTACAO				[TABELA_SEGMENTACAO],   ");
                strSql.Append("        ISNULL(FECHA_PARENTESES, '')		[FECHA_PARENTESES]      ");
                strSql.Append("   FROM SEGMENTACAO_REGRA WITH(NOLOCK)                           ");
                strSql.Append("  WHERE ID_SEGMENTACAO = @idSegmentacao                          ");
                strSql.Append("  ORDER BY ID_SEGMENTACAOREGRA                                   ");

                cmdComando.Parameters.Add(new SqlParameter("@idSegmentacao", getValues.IDSegmentacao));
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUsers.User, "SEGMENTACAO_REGRA", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Segmentação Regras >>> System Error: " + ex.Message);
            }
        }

        public SqlDataReader listDadosRegistro(dtoMailing getValues)
        {
            try
            {
                String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(getValues.Campaign);
                String StrMotivo = objCampanha.BuscaCampoMotivo(getValues.Campaign);

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_CAMPANHA,                 ");
                strSql.Append("        STATUSCHAMADA,               ");
                strSql.Append("        " + StrMotivo + " AS MOTIVO, ");
                strSql.Append("        NUMEROTENTATIVAS,            ");
                strSql.Append("        DATAREAGENDAMENTO,           ");
                strSql.Append("        AGENTE,                      ");
                strSql.Append("        FLAG_ATIVO,                  ");
                strSql.Append("        LOTE_ATIVO,                  ");
                strSql.Append("        DDD1,                        ");
                strSql.Append("        FONE1,                       ");
                strSql.Append("        DDD2,                        ");
                strSql.Append("        FONE2,                       ");
                strSql.Append("        DDD3,                        ");
                strSql.Append("        FONE3,                       ");
                strSql.Append("        DDD4,                        ");
                strSql.Append("        FONE4,                       ");
                strSql.Append("        DDD5,                        ");
                strSql.Append("        FONE5                        ");
                strSql.Append("   FROM " + StrTabelaDiscador + " WITH(NOLOCK)   ");
                strSql.Append("  WHERE REGISTROID = @registroID     ");

                cmdComando.Parameters.Add(new SqlParameter("@registroID", getValues.RegistroID));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return drQuery;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Dados Registro >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listOperationType(String strIDCampanha)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, strIDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDOPERACAO, DESCRICAO    ");
                strSql.Append("   FROM DESCRICAO_OPERACAO       ");
                strSql.Append("  WHERE FLAG_ATIVO = 1           ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.IdOperation = drQuery["IdOperacao"].ToString();
                    objAux.Operation = drQuery["Descricao"].ToString();

                    listObjAux.Add(objAux);
                }

                drQuery.Close();
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Operations >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listMailingHandler(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("DIS_HistoricoGerenciamentoMailing");

                cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@Operacao", getValues.Operation));
                cmdComando.Parameters.Add(new SqlParameter("@DataInicial", getValues.DateStart));
                cmdComando.Parameters.Add(new SqlParameter("@DataFinal", getValues.DateFinish));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.Campaign = drQuery["CAMPANHA"].ToString();
                    objAux.Lot = drQuery["LOTE"].ToString();
                    objAux.Records = drQuery["REGISTROS"].ToString();
                    objAux.Description = drQuery["DESCRICAO"].ToString();
                    objAux.DateTimeMH = Convert.ToDateTime(drQuery["DATAHORA"]).ToString("dd/MM/yyyy HH:mm:ss");
                    objAux.User = drQuery["USUARIO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "DIS_HistoricoGerenciamentoMailing", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Mailing >>> System Error: " + ex.Message);
            }
        }

        public DataSet listSegmentacaoCamposTBDiscador(dtoMailing getValues)
        {
            try
            {
                String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT SAC.NAME							            AS [COLUNA],              ");
                strSql.Append("        CASE WHEN TABELARELAC.NOME_CAMPO IS NULL                               ");
                strSql.Append("             THEN '0'                                                          ");
                strSql.Append("             ELSE '1' END							AS [ACESSO]               ");
                strSql.Append("   FROM sys.all_columns AS SAC                                                 ");
                strSql.Append(" 	   INNER JOIN sys.all_objects AS SAO                                      ");
                strSql.Append(" 	           ON SAC.OBJECT_ID = SAO.OBJECT_ID                               ");
                strSql.Append("               AND SAO.OBJECT_ID = OBJECT_ID(@NomeTabela)                      ");
                strSql.Append("        LEFT OUTER JOIN ( SELECT NOME_CAMPO, Nome_Tabela                       ");
                strSql.Append("                            FROM SEGMENTACAO_CAMPO WITH(NOLOCK)                ");
                strSql.Append("                           WHERE NOME_TABELA = @NomeTabela ) AS TABELARELAC    ");
                strSql.Append("                     ON SAC.NAME = TABELARELAC.Nome_Campo                      ");

                cmdComando.Parameters.Add(new SqlParameter("@NomeTabela", StrTabelaDiscador));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign Module >>> System Error: " + ex.Message);
            }
        }

        public DataSet listStatusChamada()
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_STATUSCHAMADA			[ID],           ");
                strSql.Append("        DESCRICAOSTATUSCHAMADA	[DESCRICAO]     ");
                strSql.Append("   FROM STATUSCHAMADA WITH(NOLOCK)               ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Status >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listLot(String strIDCampanha)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, strIDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("DIS_ObtemStatusLotesCarregados");

                cmdComando.Parameters.Add(new SqlParameter("@Campanha", strIDCampanha));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                while (drQuery.Read())
                {
                    dtoMailing objList = new dtoMailing();
                    objList.Lot = drQuery["NUMLOTE"].ToString();
                    objList.DateTimeMH = Convert.ToDateTime(drQuery["DATAHORA"]).ToString("dd/MM/yyyy HH:mm:ss");
                    objList.Records = drQuery["REGISTROS"].ToString();
                    
                    // Para exibição de nome do Arquivo Importado
                    objList.Arquivo = drQuery["ARQUIVO"].ToString();




                    if (drQuery["LOTE_ATIVO"].ToString() == "True")
                    {
                        objList.LotActivity = "Ativado";
                        objList.StatusLot = 1;
                    }
                    else if (drQuery["LOTE_ATIVO"].ToString() == "False")
                    {
                        objList.LotActivity = "Desativado";
                        objList.StatusLot = 0;
                    }

                    listObjAux.Add(objList);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Lot >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listLotDropDown(String strIDCampanha)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(strIDCampanha);
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, strIDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT DISTINCT(ID_LOTE)                        ");
                strSql.Append("   FROM " + StrTabelaDiscador + " WITH(NOLOCK)   ");
                strSql.Append("  WHERE ID_CAMPANHA = @Campanha                  ");

                cmdComando.Parameters.Add(new SqlParameter("@Campanha", strIDCampanha));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                while (drQuery.Read())
                {
                    dtoMailing objDtoMailing = new dtoMailing();
                    objDtoMailing.Lot = drQuery["NUMLOTE"].ToString();
                    listObjAux.Add(objDtoMailing);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Lot >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listStatusMailing(String IDCampanha, String strNumLote)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(IDCampanha);
                String StrMotivo = objCampanha.BuscaCampoMotivo(IDCampanha);

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT TDI.StatusChamada							AS CODSTATUS,   ");
                strSql.Append("        TDI." + StrMotivo + "                        AS CODMOTIVO,   ");
                strSql.Append("        COUNT(TDI.StatusChamada)										AS QTDE,        ");
                strSql.Append("        'Discador : ' + VST.DESCRICAOSTATUSCHAMADA   AS STATUS,      ");
                strSql.Append("        VSM.DESC_MOTIVO								AS DESCRICAO    ");
                strSql.Append("   FROM " + StrTabelaDiscador + " TDI WITH(NOLOCK),                  ");
                strSql.Append("        dbo.StatusChamada VST,             ");
                strSql.Append("        dbo.Motivos VSM                    ");
                strSql.Append("  WHERE TDI.StatusChamada NOT IN (1, 99, 100, 150)                   ");
                strSql.Append("    AND TDI.StatusChamada = VST.ID_STATUSCHAMADA                     ");
                strSql.Append("    AND TDI." + StrMotivo + " = VSM.ID_MOTIVO                        ");
                strSql.Append("    AND TDI." + StrMotivo + " IS NOT NULL                            ");
                strSql.Append("    AND TDI.NumLote = @numLote                                       ");
                strSql.Append("    AND TDI.ID_Campanha = @Campanha                                  ");
                strSql.Append("  GROUP BY TDI.StatusChamada,                                        ");
                strSql.Append("           TDI." + StrMotivo + ",                                    ");
                strSql.Append("           VST.DESCRICAOSTATUSCHAMADA,                               ");
                strSql.Append("           VSM.DESC_MOTIVO                                           ");
                strSql.Append("  UNION ALL                                                          ");
                strSql.Append(" SELECT TDI.StatusChamada                             AS CODSTATUS,  ");
                strSql.Append("        TDI." + StrMotivo + "                         AS CODMOTIVO,  ");
                strSql.Append("        COUNT(1)                                      AS QTDE,       ");
                strSql.Append("        'FrontEnd : ' + VST.DESCRICAOSTATUSCHAMADA    AS STATUS,     ");
                strSql.Append("        RCAD.Descricao                                AS DESCRICAO   ");
                strSql.Append("   FROM " + StrTabelaDiscador + " TDI WITH(NOLOCK),                  ");
                strSql.Append("        RO_Cadastro RCAD WITH(NOLOCK),                               ");
                strSql.Append("        dbo.StatusChamada VST              ");
                strSql.Append(" WHERE RCAD.ID_RO =+ TDI." + StrMotivo + "                           ");
                strSql.Append("    AND TDI.StatusChamada = VST.ID_STATUSCHAMADA                     ");
                strSql.Append("    AND TDI.StatusChamada IN (1, 99, 100, 150)                       ");
                strSql.Append("    AND RCAD.FLAG_RESSUBMISSAO = '1'                                 ");
                strSql.Append("    AND TDI.NumLote = @numLote                                       ");
                strSql.Append("    AND TDI.ID_Campanha = @Campanha                                  ");
                strSql.Append("  GROUP BY TDI.StatusChamada,                                        ");
                strSql.Append("           TDI." + StrMotivo + ",                                    ");
                strSql.Append("           VST.DESCRICAOSTATUSCHAMADA,                               ");
                strSql.Append("           RCAD.Descricao                                            ");
                strSql.Append("  ORDER BY 4, 5                                                      ");

                cmdComando.Parameters.Add(new SqlParameter("@numLote", int.Parse(strNumLote) ));
                cmdComando.Parameters.Add(new SqlParameter("@Campanha", IDCampanha));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.idStatusMotivo = drQuery["CODSTATUS"].ToString() + "." + drQuery["CODMOTIVO"].ToString();
                    objAux.DescricaoStatus = drQuery["QTDE"].ToString() + " - (" + drQuery["STATUS"].ToString() + ") - " + drQuery["DESCRICAO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, StrTabelaDiscador, strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Status Mailing >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listNovoStatusMailing(String IDCampanha)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strUniqueLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_STATUSCHAMADA						    AS IDSTATUS,     ");
                strSql.Append("        ID_MOTIVO                                AS IDMOTIVO,     ");
                strSql.Append("        'Discador : ' + DESCRICAOSTATUSCHAMADA   AS DESCRICAO,    ");
                strSql.Append("        DESC_MOTIVO                              AS MOTIVO        ");
                strSql.Append("   FROM " + strUniqueLinkedServer + ".StatusChamada VDS,          ");
                strSql.Append("        " + strUniqueLinkedServer + ".Motivos VDM                 ");
                strSql.Append("  WHERE ID_STATUSCHAMADA NOT IN (1, 2, 99, 100, 150)              ");
                strSql.Append("  UNION ALL                                                       ");
                strSql.Append(" SELECT ID_STATUSCHAMADA						    AS IDSTATUS,     ");
                strSql.Append("        RCAD.ID_RO                               AS IDMOTIVO,     ");
                strSql.Append("        'FrontEnd : ' + DESCRICAOSTATUSCHAMADA   AS DESCRICAO,    ");
                strSql.Append("        Descricao                                AS MOTIVO        ");
                strSql.Append("   FROM " + strUniqueLinkedServer + ".StatusChamada VDS,          ");
                strSql.Append("        RO_Cadastro RCAD WITH(NOLOCK),                            ");
                strSql.Append("        RO_Campanha RCAM WITH(NOLOCK)                             ");
                strSql.Append("  WHERE RCAD.Tipo <> 1                                            ");
                strSql.Append("    AND ID_STATUSCHAMADA = 1                                      ");
                strSql.Append("    AND RCAM.ID_RO = RCAD.ID_RO                                   ");
                strSql.Append("    AND RCAM.Reagendamento = 0                                    ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                dtoMailing objAux1 = new dtoMailing();
                objAux1.idStatusMotivo = "0.NULL";
                objAux1.DescricaoStatus = "(Virgem) - Virgem";
                listObjAux.Add(objAux1);

                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.idStatusMotivo = drQuery["IDSTATUS"].ToString() + "." + drQuery["IDMOTIVO"].ToString();
                    objAux.DescricaoStatus = "(" + drQuery["DESCRICAO"].ToString() + ") - " + drQuery["MOTIVO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, StrTabelaDiscador, strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list new Status Mailing >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listStatusRegistro(String IDCampanha, String strRegistroID)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(IDCampanha);
                String StrMotivo = objCampanha.BuscaCampoMotivo(IDCampanha);

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT TDI.StatusChamada						    AS CODSTATUS,    ");
                strSql.Append("        TDI." + StrMotivo + "									AS CODMOTIVO,    ");
                strSql.Append("        COUNT(TDI.StatusChamada)										AS QTDE,         ");
                strSql.Append("        'Discador : ' + VST.DESCRICAOSTATUSCHAMADA   AS STATUS,       ");
                strSql.Append("        VSM.DESC_MOTIVO								AS DESCRICAO     ");
                strSql.Append("   FROM " + StrTabelaDiscador + " TDI WITH(NOLOCK),                   ");
                strSql.Append("        dbo.StatusChamada VST,              ");
                strSql.Append("        dbo.Motivos VSM                     ");
                strSql.Append("  WHERE TDI.StatusChamada NOT IN (1, 99, 100, 150)                    ");
                strSql.Append("    AND TDI.StatusChamada = VST.ID_STATUSCHAMADA                      ");
                strSql.Append("    AND TDI." + StrMotivo + " = VSM.ID_MOTIVO                         ");
                strSql.Append("    AND TDI." + StrMotivo + " IS NOT NULL                             ");
                strSql.Append("    AND TDI.RegistroID = @registroID                                  ");
                strSql.Append("  GROUP BY TDI.StatusChamada,                                         ");
                strSql.Append("           TDI." + StrMotivo + ",                                     ");
                strSql.Append("           VST.DESCRICAOSTATUSCHAMADA,                                ");
                strSql.Append("           VSM.DESC_MOTIVO                                            ");
                strSql.Append("  UNION ALL                                                           ");
                strSql.Append(" SELECT TDI.StatusChamada                             AS CODSTATUS,   ");
                strSql.Append("        TDI." + StrMotivo + "                         AS CODMOTIVO,   ");
                strSql.Append("        COUNT(TDI.StatusChamada)                                      AS QTDE,        ");
                strSql.Append("        'FrontEnd : ' + VST.DESCRICAOSTATUSCHAMADA    AS STATUS,      ");
                strSql.Append("        RCAD.Descricao                                AS DESCRICAO    ");
                strSql.Append("   FROM " + StrTabelaDiscador + " TDI WITH(NOLOCK),                   ");
                strSql.Append("        RO_Cadastro RCAD WITH(NOLOCK),                                ");
                strSql.Append("        dbo.StatusChamada VST               ");
                strSql.Append(" WHERE RCAD.ID_RO =+ TDI." + StrMotivo + "                            ");
                strSql.Append("    AND TDI.StatusChamada = VST.ID_STATUSCHAMADA                      ");
                strSql.Append("    AND TDI.StatusChamada IN (1, 99, 100, 150)                        ");
                strSql.Append("    AND TDI.RegistroID = @registroID                                  ");
                strSql.Append("  GROUP BY TDI.StatusChamada,                                         ");
                strSql.Append("           TDI." + StrMotivo + ",                                     ");
                strSql.Append("           VST.DESCRICAOSTATUSCHAMADA,                                ");
                strSql.Append("           RCAD.Descricao                                             ");
                strSql.Append("  ORDER BY 4, 5                                                       ");

                cmdComando.Parameters.Add(new SqlParameter("@registroID", strRegistroID));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.idStatusMotivo = drQuery["CODSTATUS"].ToString() + "." + drQuery["CODMOTIVO"].ToString();
                    objAux.DescricaoStatus = drQuery["QTDE"].ToString() + " - (" + drQuery["STATUS"].ToString() + ") - " + drQuery["DESCRICAO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, StrTabelaDiscador, strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Status Registry >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listNovoStatusMailingReagendamento(String IDCampanha)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_STATUSCHAMADA						    AS IDSTATUS,     ");
                strSql.Append("        ID_MOTIVO                                AS IDMOTIVO,     ");
                strSql.Append("        'Discador : ' + DESCRICAOSTATUSCHAMADA   AS DESCRICAO,    ");
                strSql.Append("        DESC_MOTIVO                              AS MOTIVO        ");
                strSql.Append("   FROM dbo.StatusChamada VDS,          ");
                strSql.Append("        dbo.Motivos VDM                 ");
                strSql.Append("  WHERE ID_STATUSCHAMADA NOT IN (1, 2, 99, 100, 150)              ");
                strSql.Append("  UNION ALL                                                       ");
                strSql.Append(" SELECT DISTINCT ID_STATUSCHAMADA 			    AS IDSTATUS,     ");
                strSql.Append("        RCAD.ID_RO                               AS IDMOTIVO,     ");
                strSql.Append("        'FrontEnd : ' + DESCRICAOSTATUSCHAMADA   AS DESCRICAO,    ");
                strSql.Append("        Descricao                                AS MOTIVO        ");
                strSql.Append("   FROM dbo.StatusChamada VDS,          ");
                strSql.Append("        RO_Cadastro RCAD WITH(NOLOCK),                            ");
                strSql.Append("        RO_Campanha RCAM WITH(NOLOCK)                             ");
                strSql.Append("  WHERE RCAD.Tipo <> 1                                            ");
                strSql.Append("    AND ID_STATUSCHAMADA = 1                                      ");
                strSql.Append("    AND RCAM.REAGENDAMENTO = '0'                                    ");
                strSql.Append("    AND RCAM.ID_RO = RCAD.ID_RO                                   ");
                strSql.Append("  UNION ALL                                                       ");
                strSql.Append(" SELECT DISTINCT ID_STATUSCHAMADA 			    AS IDSTATUS,     ");
                strSql.Append("        RCAD.ID_RO                               AS IDMOTIVO,     ");
                strSql.Append("        'FrontEnd : ' + DESCRICAOSTATUSCHAMADA   AS DESCRICAO,    ");
                strSql.Append("        Descricao                                AS MOTIVO        ");
                strSql.Append("   FROM dbo.StatusChamada VDS,          ");
                strSql.Append("        RO_Cadastro RCAD WITH(NOLOCK),                            ");
                strSql.Append("        RO_Campanha RCAM WITH(NOLOCK)                             ");
                strSql.Append("  WHERE RCAD.Tipo <> 1                                            ");
                strSql.Append("    AND ID_STATUSCHAMADA = 99                                     ");
                strSql.Append("    AND RCAM.REAGENDAMENTO = '1'                                    ");
                strSql.Append("    AND RCAM.ID_RO = RCAD.ID_RO                                   ");
                strSql.Append("  ORDER BY 2 DESC, 1, 4, 3                                        ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                dtoMailing objAux1 = new dtoMailing();
                objAux1.idStatusMotivo = "0.NULL";
                objAux1.DescricaoStatus = "(Virgem) - Virgem";
                listObjAux.Add(objAux1);

                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.idStatusMotivo = drQuery["IDSTATUS"].ToString() + "." + drQuery["IDMOTIVO"].ToString();
                    objAux.DescricaoStatus = "(" + drQuery["DESCRICAO"].ToString() + ") - " + drQuery["MOTIVO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, StrTabelaDiscador, strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Status Mailing Reagendamento >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listDadosTelefone(String IDCampanha, String strDDD, String strTelefone)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(IDCampanha);

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT REGISTROID,                          ");
                strSql.Append("        FLAG_ATIVO,                          ");
                strSql.Append("        LOTE_ATIVO                           ");
                strSql.Append("   FROM " + StrTabelaDiscador + "            ");
                strSql.Append("  WHERE (DDD1 = @ddd AND FONE1 = @telefone)  ");
                strSql.Append("     OR (DDD2 = @ddd AND FONE2 = @telefone)  ");
                strSql.Append("     OR (DDD3 = @ddd AND FONE3 = @telefone)  ");
                strSql.Append("     OR (DDD4 = @ddd AND FONE4 = @telefone)  ");
                strSql.Append("     OR (DDD5 = @ddd AND FONE5 = @telefone)  ");

                cmdComando.Parameters.Add(new SqlParameter("@ddd", strDDD));
                cmdComando.Parameters.Add(new SqlParameter("@telefone", strTelefone));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.RegistroID = drQuery["REGISTROID"].ToString();

                    if (drQuery["FLAG_ATIVO"].ToString() == "True")
                    {
                        objAux.StatusRegistro = 1;
                    }
                    else if (drQuery["FLAG_ATIVO"].ToString() == "False")
                    {
                        objAux.StatusRegistro = 0;
                    }

                    if (drQuery["LOTE_ATIVO"].ToString() == "True")
                    {
                        objAux.StatusLot = 1;
                    }
                    else if (drQuery["LOTE_ATIVO"].ToString() == "False")
                    {
                        objAux.StatusLot = 0;
                    }
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, StrTabelaDiscador, strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Dados Telefone >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listRessubmissaoLog(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT LOTE,                                ");
                strSql.Append("        REGISTRO,                            ");
                strSql.Append("        QUERYDE,                             ");
                strSql.Append("        QUERYPARA,                           ");
                strSql.Append("        DATAHORA,                            ");
                strSql.Append("        USUARIO,                             ");
                strSql.Append("        CASE WHEN SUCESSO = 1                ");
                strSql.Append("             THEN 'SUCESSO'                  ");
                strSql.Append("             ELSE 'INSUCESSO' END SUCESSO    ");
                strSql.Append("   FROM LOG_RESSUBMISSAO WITH(NOLOCK)        ");
                strSql.Append("  WHERE IDCAMPANHA = @idCampanha             ");
                strSql.Append("    AND DATAHORA >= @dataInicio              ");
                strSql.Append("    AND DATAHORA <= @dataFim                 ");
                strSql.Append("  ORDER BY DATAHORA DESC                     ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@dataInicio", getValues.DateStart));
                cmdComando.Parameters.Add(new SqlParameter("@dataFim", getValues.DateFinish));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    // create an objAux
                    dtoMailing objAux = new dtoMailing();
                    objAux.Lot = drQuery["LOTE"].ToString();
                    objAux.RegistroID = drQuery["REGISTRO"].ToString();
                    objAux.OperationFrom = drQuery["QUERYDE"].ToString();
                    objAux.OperationTo = drQuery["QUERYPARA"].ToString();
                    objAux.User = drQuery["USUARIO"].ToString();
                    objAux.DateTimeMH = drQuery["DATAHORA"].ToString();
                    objAux.DescricaoStatus = drQuery["SUCESSO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "LOG_RESSUBMISSAO", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error to list Log Ressubmissão >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listSegmentacaoTabela(String IDCampanha)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT DISTINCT(NOME_TABELA)             ");
                strSql.Append("   FROM SEGMENTACAO_CAMPO WITH(NOLOCK)    ");
                strSql.Append("  WHERE FLAG_ATIVO = 1                    ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.SegmentacaoTabela = drQuery["NOME_TABELA"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, "LOG_RESSUBMISSAO", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Segmentação Tabela >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listSegmentacaoCampo(String IDCampanha, String strTabela)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_SEGMENTACAOCAMPOS,             ");
                strSql.Append("        NOME_CAMPO                        ");
                strSql.Append("   FROM SEGMENTACAO_CAMPO WITH(NOLOCK)    ");
                strSql.Append("  WHERE FLAG_ATIVO = 1                    ");

                if (strTabela != String.Empty)
                {
                    strSql.Append("   AND NOME_TABELA = @tabela          ");
                    cmdComando.Parameters.Add(new SqlParameter("@tabela", strTabela));
                }

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.IDSegmentacaoCampo = int.Parse(drQuery["ID_SEGMENTACAOCAMPOS"].ToString());
                    objAux.SegmentacaoCampo = drQuery["NOME_CAMPO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, "LOG_RESSUBMISSAO", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Segmentação Campo >>> System Error: " + ex.Message);
            }
        }

        public List<dtoMailing> listSegmentacaoLog(dtoMailing getValues)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_SEGMENTACAO, CAMPANHA, LOTE, REGISTROS, USUARIO, DATAHORA ");
                strSql.Append("   FROM LOG_SEGMENTACAO WITH(NOLOCK)                                 ");
                strSql.Append("  WHERE DATAHORA >= @dataInicio                                      ");
                strSql.Append("    AND DATAHORA <= @dataFim                                         ");
                strSql.Append("    AND CAMPANHA = @idCampanha                                       ");
                strSql.Append("  ORDER BY DATAHORA                                                  ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@dataInicio", getValues.DateStart));
                cmdComando.Parameters.Add(new SqlParameter("@dataFim", getValues.DateFinish));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoMailing objAux = new dtoMailing();
                    objAux.Campaign = drQuery["CAMPANHA"].ToString();
                    objAux.Lot = drQuery["LOTE"].ToString();
                    objAux.IDSegmentacao = drQuery["ID_SEGMENTACAO"].ToString();
                    objAux.Records = drQuery["REGISTROS"].ToString();
                    objAux.User = drQuery["USUARIO"].ToString();
                    objAux.DateTimeMH = drQuery["DATAHORA"].ToString();

                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                //objGeral.logSQL(getValues.User, "LOG_SEGMENTACAO", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Log Segmentação >>> System Error: " + ex.Message);
            }
        }

        public Int64 managerLot(dtoMailing getValues)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);
                objGeral.logSQL(getValues.User, "DIS_AtivarDesativarMailing : " + "String: " + strConn + " hora : " + DateTime.Now.ToString(), strSql.ToString());

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
                            strSql.Append("DIS_AtivarDesativarMailing");

                            cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campaign));
                            cmdComando.Parameters.Add(new SqlParameter("@Lote", getValues.Lot));
                            cmdComando.Parameters.Add(new SqlParameter("@NovoStatusLote", getValues.LotActivity));
                            cmdComando.Parameters.Add(new SqlParameter("@Usuario", getValues.User));
                            cmdComando.Parameters.Add(new SqlParameter("@Maquina", getValues.Machine));

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

                objGeral.logSQL(getValues.User, "DIS_AtivarDesativarMailing", strSql.ToString() + " hora : " + DateTime.Now.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "DIS_AtivarDesativarMailing", strSql.ToString() + " >>> erro: " + e.Message + " hora : " + DateTime.Now.ToString());
                return 0;
            }
        }

        public Int64 managerRessubmissao(dtoMailing getValues)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PRC_RESSUBMISSAO");

                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@NUMLOTE", getValues.Lot));
                cmdComando.Parameters.Add(new SqlParameter("@STATUSCHAMADA", getValues.StatusChamada));
                cmdComando.Parameters.Add(new SqlParameter("@MOTIVO", getValues.Motivo));
                cmdComando.Parameters.Add(new SqlParameter("@NOVOSTATUSCHAMADA", getValues.StatusChamadaNovo));
                cmdComando.Parameters.Add(new SqlParameter("@NOVOMOTIVO", getValues.MotivoNovo));

                if (getValues.RegistroID == "")
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTROID", getValues.RegistroID));
                else
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTROID", Convert.ToInt32(getValues.RegistroID)));

                cmdComando.Parameters.Add(new SqlParameter("@DATAREAGENDAMENTO", getValues.DateTimeMH));
                cmdComando.Parameters.Add(new SqlParameter("@AGENTE", ""));
                cmdComando.Parameters.Add(new SqlParameter("@DDDFORCADO", getValues.DDD));
                cmdComando.Parameters.Add(new SqlParameter("@FONEFORCADO", getValues.Telefone));
                cmdComando.Parameters.Add(new SqlParameter("@ZERAINDICE", getValues.Tentativas));
                cmdComando.Parameters.Add(new SqlParameter("@ZERATENTATIVAS", getValues.IndiceCampoFone));
                cmdComando.Parameters.Add(new SqlParameter("@USUARIO", getValues.User));
                cmdComando.Parameters.Add(new SqlParameter("@STATUSATUAL", getValues.StatusAtual));
                cmdComando.Parameters.Add(new SqlParameter("@STATUSNOVO", getValues.StatusNovo));

                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                objGeral.logSQL(getValues.User, "PRC_RESSUBMISSAO", strSql.ToString());
                return 1;
            }
            catch (Exception ex)
            {
                objGeral.logSQL(getValues.User, "PRC_RESSUBMISSAO", strSql.ToString() + " >>> erro: " + ex.Message);
                return 0;
            }
        }

        public Int64 managerSegmentacao(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO SEGMENTACAO ( NOME_SEGMENTACAO, NUMERO_CAMPANHA, NUMERO_LOTE, PRIORIDADE, FLAG_ATIVO )  ");
                            strSql.Append("                  VALUES ( @Segmentacao, @Campanha, @Lote, @Prioridade, @FlagAtivo )                 ");

                            cmdComando.Parameters.Add(new SqlParameter("@Segmentacao", getValues.NomeSegmentacao));
                            cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campaign));
                            cmdComando.Parameters.Add(new SqlParameter("@Lote", getValues.Lot));
                            cmdComando.Parameters.Add(new SqlParameter("@Prioridade", getValues.Priority));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", getValues.Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE SEGMENTACAO                      ");
                            strSql.Append("    SET NOME_SEGMENTACAO = @Segmentacao, ");
                            strSql.Append("        NUMERO_CAMPANHA = @Campanha,     ");
                            strSql.Append("        NUMERO_LOTE = @Lote,             ");
                            strSql.Append("        PRIORIDADE = @Prioridade,        ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo          ");
                            strSql.Append(" WHERE ID_SEGMENTACAO = @idSegmentacao   ");

                            cmdComando.Parameters.Add(new SqlParameter("@Segmentacao", getValues.NomeSegmentacao));
                            cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campaign));
                            cmdComando.Parameters.Add(new SqlParameter("@Lote", getValues.Lot));
                            cmdComando.Parameters.Add(new SqlParameter("@Prioridade", getValues.Priority));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", getValues.Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idSegmentacao", getValues.IDSegmentacao));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM SEGMENTACAO                 ");
                            strSql.Append("  WHERE ID_SEGMENTACAO = @idSegmentacao  ");

                            cmdComando.Parameters.Add(new SqlParameter("@idSegmentacao", getValues.IDSegmentacao));
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 4:
                        {
                            String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(getValues.Campaign);

                            strSql.Append(" UPDATE Tabeladiscador_Affinity      ");
                            strSql.Append("    SET CAMPOORDENADOR = 10,         ");
                            strSql.Append("        FLAG_ATIVO = 1               ");
                            strSql.Append("  WHERE ID_Campanha = @Campanha      ");
                            strSql.Append("    AND NumLote = @Lote              ");

                            cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campaign));
                            cmdComando.Parameters.Add(new SqlParameter("@Lote", getValues.Lot));
                            
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

                objGeral.logSQL(getValuesUsers.User, "SEGMENTACAO", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "SEGMENTACAO", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 managerSegmentacaoRegra(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO SEGMENTACAO_REGRA ( ID_SEGMENTACAO, CAMPO_SEGMENTACAO, REGRA_SEGMENTACAO, VALOR_SEGMENTACAO, TABELA_SEGMENTACAO, ABRE_PARENTESES, CONJUNCAO, FECHA_PARENTESES )   ");
                            strSql.Append("                  VALUES ( @idSegmentacao, @Campo, @Regra, @Valor, @Tabela, @AbreParenteses, @Conjuncao, @FechaParenteses )                                                     ");

                            cmdComando.Parameters.Add(new SqlParameter("@idSegmentacao", getValues.IDSegmentacao));
                            cmdComando.Parameters.Add(new SqlParameter("@Campo", getValues.SegmentacaoCampo));
                            cmdComando.Parameters.Add(new SqlParameter("@Regra", getValues.SegmentacaoRegra));
                            cmdComando.Parameters.Add(new SqlParameter("@Valor", getValues.SegmentacaoValor));
                            cmdComando.Parameters.Add(new SqlParameter("@Tabela", getValues.SegmentacaoTabela));

                            cmdComando.Parameters.Add(new SqlParameter("@AbreParenteses", getValues.SegmentacaoAbreParenteses));
                            cmdComando.Parameters.Add(new SqlParameter("@FechaParenteses", getValues.SegmentacaoFechaParenteses));
                            cmdComando.Parameters.Add(new SqlParameter("@Conjuncao", getValues.Conjuncao));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE SEGMENTACAO_REGRA                            ");
                            strSql.Append("    SET CAMPO_SEGMENTACAO = @Campo,                  ");
                            strSql.Append("        REGRA_SEGMENTACAO = @Regra,                  ");
                            strSql.Append("        VALOR_SEGMENTACAO = @Valor,                  ");
                            strSql.Append("        TABELA_SEGMENTACAO = @Tabela,                ");
                            strSql.Append("        ABRE_PARENTESES =  @AbreParenteses,          ");
                            strSql.Append("        CONJUNCAO = @Conjuncao,                      ");
                            strSql.Append("        FECHA_PARENTESES = @FechaParenteses          ");
                            strSql.Append("  WHERE ID_SEGMENTACAOREGRA = @idSegmentacaoRegra    ");

                            cmdComando.Parameters.Add(new SqlParameter("@Campo", getValues.SegmentacaoCampo));
                            cmdComando.Parameters.Add(new SqlParameter("@Regra", getValues.SegmentacaoRegra));
                            cmdComando.Parameters.Add(new SqlParameter("@Valor", getValues.SegmentacaoValor));
                            cmdComando.Parameters.Add(new SqlParameter("@Tabela", getValues.SegmentacaoTabela));
                            
                            cmdComando.Parameters.Add(new SqlParameter("@AbreParenteses", getValues.SegmentacaoAbreParenteses));
                            cmdComando.Parameters.Add(new SqlParameter("@FechaParenteses", getValues.SegmentacaoFechaParenteses));
                            cmdComando.Parameters.Add(new SqlParameter("@Conjuncao", getValues.Conjuncao));

                            cmdComando.Parameters.Add(new SqlParameter("@idSegmentacaoRegra", getValues.IDSegmentacaoRegra));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM SEGMENTACAO_REGRA                       ");
                            strSql.Append("  WHERE ID_SEGMENTACAOREGRA = @idSegmentacaoRegra    ");

                            cmdComando.Parameters.Add(new SqlParameter("@idSegmentacaoRegra", getValues.IDSegmentacaoRegra));
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

                objGeral.logSQL(getValuesUsers.User, "SEGMENTACAO_REGRA", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "SEGMENTACAO_REGRA", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 managerSegmentacaoProcesso(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PRC_SEGMENTACAO");

                cmdComando.Parameters.Add(new SqlParameter("@IDSEGMENTACAO", getValues.IDSegmentacao));
                cmdComando.Parameters.Add(new SqlParameter("@USUARIO", getValues.User));
                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                objGeral.logSQL(getValuesUsers.User, "PRC_SEGMENTACAO", strSql.ToString());
                return 1;
            }
            catch (Exception ex)
            {
                objGeral.logSQL(getValuesUsers.User, "PRC_SEGMENTACAO", strSql.ToString() + " >>> erro: " + ex.Message);
                return 0;
            }
        }

        public DataSet PAN_ListaIdentificadoresLote(String idCampanha, Int32 numLOTE, String strCAMPO, dtoUsers getValuesUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_ListaIdentificadoresLote");

                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", idCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@LOTE", numLOTE));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPO", strCAMPO));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, idCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                objGeral.logSQL(getValuesUsers.User, "PAN_ListaIdentificadoresLote", strSql.ToString());
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Mailing >>> System Error: " + ex.Message);
            }
        }

        public DataSet ListaRegistroMailing(String idCampanha, Int32 numLOTE, String strCampo, String strValor, dtoUsers getValuesUsers)
        {
            try
            {
                List<dtoMailing> listObjAux = new List<dtoMailing>();
                String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(idCampanha);
                String StrMotivo = objCampanha.BuscaCampoMotivo(idCampanha);
                String strUniqueLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

                StringBuilder buildCampos = new StringBuilder();
                buildCampos.Remove(0, buildCampos.Length);

                List<dtoMailing> objMailing = listSegmentacaoCampo(idCampanha, StrTabelaDiscador);
                foreach (dtoMailing dto in objMailing)
                {
                    buildCampos.Append("TDI." + dto.SegmentacaoCampo + " AS [" + dto.SegmentacaoCampo.ToUpper() + "],");
                }

                buildCampos.ToString().Substring(0, buildCampos.ToString().Length - 1);



                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                strSql.Append(" SELECT TOP 10                                                                           ");
                strSql.Append(buildCampos.ToString()                                                                     );
                strSql.Append("        VST.DESCRICAOSTATUSCHAMADA       AS [STATUS],                                    ");

                strSql.Append("        CASE TDI." + StrMotivo + " WHEN NULL THEN ''                                     ");
                strSql.Append("        		           ELSE ( SELECT DESC_MOTIVO                                        ");
                strSql.Append("        		                    FROM " + strUniqueLinkedServer + ".MOTIVOS MOT2 WITH(NOLOCK)  ");
                strSql.Append("        		                   WHERE TDI." + StrMotivo + " = MOT2.ID_MOTIVO )                      ");
                strSql.Append("        		            END             AS [TABULAÇÃO],                                 ");        
                strSql.Append("        TDI.NUMEROTENTATIVAS             AS [TENTATIVAS],                                ");
                strSql.Append("        TDI.DATAHORAULTIMATENTATIVA      AS [ULTIMA TENTATIVA],                          ");
                strSql.Append("        TDI.DATAREAGENDAMENTO            AS [DATA REAGENDAMENTO]                         ");
                strSql.Append("   FROM " + StrTabelaDiscador + " TDI WITH(NOLOCK)                                       ");
                strSql.Append("        INNER JOIN " + strUniqueLinkedServer + ".StatusChamada VST WITH(NOLOCK)          ");
                strSql.Append("                ON ISNULL(TDI.StatusChamada, 0) = VST.ID_STATUSCHAMADA                   ");
                strSql.Append("  WHERE TDI.ID_Campanha = @CAMPANHA                                                      ");
                strSql.Append("    AND TDI.NumLote = @LOTE                                                              ");
                
                strSql.Append("    AND                                                                                  ");
                
                if (strValor == String.Empty)
                {
                    strSql.Append(" ( " + strCampo + " = '' OR " + strCampo + " is NULL )                           ");
                }
                else
                {
                    strSql.Append( strCampo + " = @VALOR ");
                }

                strSql.Append("    AND (TDI." + StrMotivo + " < 1000 OR TDI." + StrMotivo + " IS NULL)                  ");
                strSql.Append("  UNION ALL                                                                          ");
                strSql.Append(" SELECT TOP 10                                                                       ");
                strSql.Append(buildCampos.ToString()                                                                 );
                strSql.Append("        VST.DESCRICAOSTATUSCHAMADA           AS [STATUS],                            ");
                strSql.Append("        RCAD.Descricao                       AS [TABULAÇÃO],                         ");
                strSql.Append("        TDI.NUMEROTENTATIVAS                 AS [TENTATIVAS],                        ");
                strSql.Append("        TDI.DATAHORAULTIMATENTATIVA          AS [ULTIMA TENTATIVA],                  ");
                strSql.Append("        TDI.DATAREAGENDAMENTO                AS [DATA REAGENDAMENTO]                 ");
                strSql.Append("   FROM " + StrTabelaDiscador + " TDI WITH(NOLOCK)                                   ");
                strSql.Append("        INNER JOIN RO_Cadastro RCAD WITH(NOLOCK)                                     ");
                strSql.Append("                ON RCAD.ID_RO =+ TDI." + StrMotivo);
                strSql.Append("        INNER JOIN " + strUniqueLinkedServer + ".StatusChamada VST WITH(NOLOCK)      ");
                strSql.Append("                ON ISNULL(TDI.StatusChamada, 0) = VST.ID_STATUSCHAMADA               ");
                strSql.Append("  WHERE TDI." + StrMotivo + " > 1000                                                 ");
                strSql.Append("    AND TDI.NumLote = @LOTE                                                          ");
                strSql.Append("    AND TDI.ID_Campanha = @CAMPANHA                                                  ");
                strSql.Append("    AND                                                                              ");

                if (strValor == String.Empty)
                {
                    strSql.Append(" ( " + strCampo + " = '' OR " + strCampo + " is NULL )                           ");
                }
                else
                {
                    strSql.Append(strCampo + " = @VALOR ");
                }
                
                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", idCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@LOTE", numLOTE));
                cmdComando.Parameters.Add(new SqlParameter("@VALOR", strValor));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, idCampanha);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                objGeral.logSQL(getValuesUsers.User, "ListaRegistroMailing", strSql.ToString());
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ListaRegistroMailing >>> System Error: " + ex.Message);
            }
        }

        public Int64 managerSegmentacaoCamposTBDiscador(dtoMailing getValues, dtoUsers getValuesUsers)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

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
                            String StrTabelaDiscador = objCampanha.BuscaTabelaDiscador(getValues.Campaign);

                            strSql.Append("PAN_Manager_SegmentacaoCampo");

                            cmdComando.Parameters.Add(new SqlParameter("@Tabela", StrTabelaDiscador));
                            cmdComando.Parameters.Add(new SqlParameter("@Colunas", getValues.SegmentacaoCampo));

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

                objGeral.logSQL(getValues.User, "managerSegmentacaoCamposTBDiscador", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "managerSegmentacaoCamposTBDiscador", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 UINT_ExportacaoMetralhadora(dtoMailingMetralhadora getValues, dtoUsers getValuesUsers)
        {
            try
            {
                Int64 intResultado = 0;
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_ExportacaoMetralhadora");
                
                cmdComando.Parameters.Add(new SqlParameter("@Campanha", getValues.Campanha));
                cmdComando.Parameters.Add(new SqlParameter("@Lote", getValues.Lote));
                cmdComando.Parameters.Add(new SqlParameter("@Status", getValues.ListStatus));
                cmdComando.Parameters.Add(new SqlParameter("@RO", getValues.ListRO));

                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                intResultado = 1;

                objGeral.logSQL(getValuesUsers.User, "UINT_ExportacaoMetralhadora", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "UINT_ExportacaoMetralhadora", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }
    }
}