using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
//using _webPainelVerisys.DTO.Fidelity;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL.Fidelity
{
    public class Telecom
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();

        public DataSet listAuthCode()
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_AUTHORIZATIONCODE, AUTHCODE, CORE, DESCRITIVO ");
                strSql.Append("   FROM AUTHORIZATIONCODE AUTH WITH(NOLOCK),             ");
                strSql.Append("        CORE COR WITH(NOLOCK)                            ");
                strSql.Append("  WHERE AUTH.PERMISSOESRAMAIS = COR.CORE                 ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Authorization Codes >>> System Error: " + ex.Message);
            }
        }

        public DataSet listGrupoxCore()
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID, GRUPODAC, COR.CORE, DESCRITIVO   ");
                strSql.Append("   FROM GRUPOXCORE GCOR WITH(NOLOCK),        ");
                strSql.Append("        CORE COR WITH(NOLOCK)                ");
                strSql.Append("  WHERE GCOR.CORE = COR.CORE                 ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Groups X Cores >>> System Error: " + ex.Message);
            }
        }

        public DataSet listRamalNaoGrava()
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT RM                           ");
                strSql.Append("   FROM RAMAISNAOGRAVA WITH(NOLOCK)  ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Ramal Não Grava >>> System Error: " + ex.Message);
            }
        }

        public DataSet listRamalForaRange()
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_RM, RM                        ");
                strSql.Append("   FROM RAMAIS_FORA_RANGE WITH(NOLOCK)   ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Ramais Fora de Range >>> System Error: " + ex.Message);
            }
        }

        public DataSet listScreenCaptureACDList()
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ACDGROUP,                            ");
                strSql.Append("        ACTIVATED IDSTATUS,                  ");
                strSql.Append("        CASE WHEN ACTIVATED = 1              ");
                strSql.Append("             THEN 'ATIVO'                    ");
                strSql.Append("             ELSE 'INATIVO' END ACTIVATED,   ");
                strSql.Append("        LASTCHANGE,                          ");
                strSql.Append("        PERCENTAGERATE                       ");
                strSql.Append("   FROM SCREENCAPTUREACDLIST WITH(NOLOCK)    ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Screen Capture ACDList >>> System Error: " + ex.Message);
            }
        }

        public DataSet listCartaoCredito()
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabaseHistorico);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID, NUMEROCARTAO, NOMECARTAO ");
                strSql.Append("   FROM CARTAOCREDITO WITH(NOLOCK)   ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Credit Card >>> System Error: " + ex.Message);
            }
        }

        public Boolean searchCartaoCredito(String NumeroBin)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabaseHistorico);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID, NUMEROCARTAO, NOMECARTAO ");
                strSql.Append("   FROM CARTAOCREDITO WITH(NOLOCK)   ");
                strSql.Append("  WHERE NUMEROCARTAO = @Bin          ");

                cmdComando.Parameters.Add(new SqlParameter("@Bin", NumeroBin));

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                if (dsQuery.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Credit Card >>> System Error: " + ex.Message);
            }
        }

        public List<dtoTelecom> listCore()
        {
            // start the list object
            List<dtoTelecom> listObjAux = new List<dtoTelecom>();

            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CORE, DESCRITIVO ");
                strSql.Append(" FROM CORE WITH(NOLOCK)  ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoTelecom objAux = new dtoTelecom();
                    objAux.NumeroCore = drQuery["CORE"].ToString();
                    objAux.DescritivoCore = drQuery["DESCRITIVO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Core >>> System Error: " + ex.Message);
            }
        }

        public List<dtoTelecom> listGrupoDAC()
        {
            List<dtoTelecom> listObjAux = new List<dtoTelecom>();

            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT GRUPO, NOME                                              ");
                strSql.Append("   FROM GRUPOSDAC WITH(NOLOCK)                                   ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoTelecom objAux = new dtoTelecom();
                    objAux.GrupoDAC = drQuery["GRUPO"].ToString();
                    objAux.NomeGrupoDAC = drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the ACD List >>> System Error: " + ex.Message);
            }
        }

        public Int64 ManagerAuthorizationCode(dtoTelecom getValues, dtoUsers getValuesUsers)
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
                            strSql.Append(" INSERT INTO AUTHORIZATIONCODE ( AUTHCODE, PERMISSOESRAMAIS )    ");
                            strSql.Append("                        VALUES ( @authCode, @Core )              ");

                            cmdComando.Parameters.Add(new SqlParameter("@authCode", getValues.AuthCode));
                            cmdComando.Parameters.Add(new SqlParameter("@Core", getValues.NumeroCore));
                            
                            Int64 IdAuthorizationCode = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = IdAuthorizationCode;
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE AUTHORIZATIONCODE                    ");
                            strSql.Append("    SET PERMISSOESRAMAIS = @Core             ");
                            strSql.Append("  WHERE ID_AUTHORIZATIONCODE = @idAuthCode   ");

                            cmdComando.Parameters.Add(new SqlParameter("@Core", getValues.NumeroCore));
                            cmdComando.Parameters.Add(new SqlParameter("@idAuthCode", getValues.IDAuthCode));
                            
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM AUTHORIZATIONCODE               ");
                            strSql.Append("  WHERE ID_AUTHORIZATIONCODE = @idAuthCode   ");

                            cmdComando.Parameters.Add(new SqlParameter("@idAuthCode", getValues.IDAuthCode));
                            
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

                objGeral.logSQL(getValuesUsers.User, "AUTHORIZATIONCODE", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "AUTHORIZATIONCODE", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerGrupoXCore(dtoTelecom getValues, dtoUsers getValuesUsers)
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
                            strSql.Append(" INSERT INTO GRUPOXCORE (GRUPODAC, CORE) ");
                            strSql.Append("                 VALUES (@GrupoDac, @Core )              ");

                            cmdComando.Parameters.Add(new SqlParameter("@GrupoDac", getValues.GrupoDAC));
                            cmdComando.Parameters.Add(new SqlParameter("@Core", getValues.NumeroCore));
                         
                            Int64 IdAuthorizationCode = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = IdAuthorizationCode;
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE GRUPOXCORE           ");
                            strSql.Append("    SET CORE = @Core         ");
                            strSql.Append("  WHERE ID = @idGrupoXCore   ");

                            cmdComando.Parameters.Add(new SqlParameter("@Core", getValues.NumeroCore));
                            cmdComando.Parameters.Add(new SqlParameter("@idGrupoXCore", getValues.IDGrupoxCore));
                            
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM GRUPOXCORE      ");
                            strSql.Append("  WHERE ID = @idGrupoXCore   ");

                            cmdComando.Parameters.Add(new SqlParameter("@idGrupoXCore", getValues.IDGrupoxCore));
                            
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

                objGeral.logSQL(getValuesUsers.User, "GRUPOXCORE", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "GRUPOXCORE", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerRamalNaoGrava(dtoTelecom getValues, dtoUsers getValuesUsers)
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
                            strSql.Append(" INSERT INTO RAMAISNAOGRAVA (RM)     ");
                            strSql.Append("                     VALUES (@ramal) ");

                            cmdComando.Parameters.Add(new SqlParameter("@ramal", getValues.Ramal));
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 2:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM RAMAISNAOGRAVA  ");
                            strSql.Append("  WHERE RM = @ramal          ");

                            cmdComando.Parameters.Add(new SqlParameter("@ramal", getValues.Ramal));
                            
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

                objGeral.logSQL(getValuesUsers.User, "RAMAISNAOGRAVA", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "RAMAISNAOGRAVA", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerRamalForaRange(dtoTelecom getValues, dtoUsers getValuesUsers)
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
                            strSql.Append(" INSERT INTO RAMAIS_FORA_RANGE (RM)      ");
                            strSql.Append("                        VALUES (@ramal)  ");

                            cmdComando.Parameters.Add(new SqlParameter("@ramal", getValues.Ramal));
                         
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 2:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM RAMAIS_FORA_RANGE   ");
                            strSql.Append("  WHERE ID_RM = @idRamal         ");

                            cmdComando.Parameters.Add(new SqlParameter("@idRamal", getValues.IDRamal));
                            
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

                objGeral.logSQL(getValuesUsers.User, "RAMAIS_FORA_RANGE", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "RAMAIS_FORA_RANGE", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerScreenCaptureACDList(dtoTelecom getValues, dtoUsers getValuesUsers)
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
                            strSql.Append(" INSERT INTO SCREENCAPTUREACDLIST ( ACDGROUP, ACTIVATED, PERCENTAGERATE, LASTCHANGE )    ");
                            strSql.Append("                           VALUES ( @acdGroup, @activated, @percentRate, GETDATE() )     ");

                            cmdComando.Parameters.Add(new SqlParameter("@acdGroup", getValues.GrupoDAC));
                            cmdComando.Parameters.Add(new SqlParameter("@activated", getValues.Status));
                            cmdComando.Parameters.Add(new SqlParameter("@percentRate", getValues.PercentageRate));
                            
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE SCREENCAPTUREACDLIST             ");
                            strSql.Append("    SET ACTIVATED = @activated,          ");
                            strSql.Append("        LASTCHANGE = GETDATE(),          ");
                            strSql.Append("        PERCENTAGERATE = @percentRate    ");
                            strSql.Append("  WHERE ACDGROUP = @acdGroup             ");

                            cmdComando.Parameters.Add(new SqlParameter("@activated", getValues.Status));
                            cmdComando.Parameters.Add(new SqlParameter("@acdGroup", getValues.GrupoDAC));
                            cmdComando.Parameters.Add(new SqlParameter("@percentRate", getValues.PercentageRate));
                            
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM SCREENCAPTUREACDLIST    ");
                            strSql.Append("  WHERE ACDGROUP = @acdGroup         ");

                            cmdComando.Parameters.Add(new SqlParameter("@acdGroup", getValues.GrupoDAC));
                            
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

                objGeral.logSQL(getValuesUsers.User, "SCREENCAPTUREACDLIST", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "SCREENCAPTUREACDLIST", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerCartaoCredito(dtoTelecom getValues, dtoUsers getValuesUsers)
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
                            strSql.Append(" INSERT INTO CARTAOCREDITO ( NUMEROCARTAO, NOMECARTAO )      ");
                            strSql.Append("                    VALUES ( @numeroCartao, @nomeCartao )    ");

                            cmdComando.Parameters.Add(new SqlParameter("@numeroCartao", getValues.NumeroCartao));
                            cmdComando.Parameters.Add(new SqlParameter("@nomeCartao", getValues.NomeCartaoCredito));
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            intResultado = 1;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE FROM CARTAOCREDITO   ");
                            strSql.Append("  WHERE ID = @idCartao       ");

                            cmdComando.Parameters.Add(new SqlParameter("@idCartao", getValues.IDCartaoCredito));
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

                objGeral.logSQL(getValuesUsers.User, "CARTAOCREDITO", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "CARTAOCREDITO", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }
    }
}
