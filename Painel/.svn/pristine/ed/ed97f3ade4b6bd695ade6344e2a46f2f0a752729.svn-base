using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class UsersProfiles
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();

        public DataSet BuscaPerfis(dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT PERF.IDPERFILUSUARIO     ID,                                                                     ");
                strSql.Append("        PERF.DESCRICAO           DESCRICAO,                                                              ");
                strSql.Append("        PERF.PERFIL              IDTIPOPERFIL,                                                           ");
                strSql.Append("        TPER.DESCRICAO           TIPOPERFIL,                                                             ");
                strSql.Append("        PERF.ATIVO               FLAGATIVO,                                                              ");
                strSql.Append("        CASE WHEN PERF.ATIVO = 0                                                                         ");
                strSql.Append("             THEN 'NÃO'                                                                                  ");
                strSql.Append("             ELSE 'SIM' END      ATIVO                                                                   ");
                strSql.Append("   FROM [DBO].[PERFILUSUARIOS] AS PERF WITH(NOLOCK)                                                      ");
                strSql.Append("        INNER JOIN [DBO].[TIPOPERFILUSUARIOS] AS TPER WITH(NOLOCK) ON PERF.PERFIL = TPER.ID_TIPOPERFIL   ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUsers.User, "PERFILUSUARIOS", strSql.ToString());
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Profiles >>> System Error: " + ex.Message);
            }
        }

        public DataSet BuscaTipoPerfis(dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ID_TIPOPERFIL,                   ");
                strSql.Append("        DESCRICAO                        ");
                strSql.Append("   FROM TIPOPERFILUSUARIOS WITH(NOLOCK)  ");
                strSql.Append("  WHERE FLAG_ATIVO = 1                   ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUsers.User, "TIPOPERFILUSUARIOS", strSql.ToString());
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Profiles >>> System Error: " + ex.Message);
            }
        }

        public List<dtoUsersProfiles> AccessMailing(dtoUsers getValuesUsers)
        {
            List<dtoUsersProfiles> objAuxProfile = new List<dtoUsersProfiles>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT DISTINCT SERVIDORMAILING, DATABASEMAILING        ");
                strSql.Append("   FROM " + strLinkedServer + ".CAMPANHAS WITH(NOLOCK)   ");
                strSql.Append("  WHERE NUMERO IN ( SELECT CAMPAIGN                      ");
                strSql.Append("                      FROM USERSCAMPAIGN WITH(NOLOCK)    ");
                strSql.Append("                     WHERE IDUSER = @idUser )            ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValuesUsers.User));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoUsersProfiles objAux = new dtoUsersProfiles();
                    objAux.ServidorMailing = drQuery["SERVIDORMAILING"].ToString();
                    objAux.DatabaseMailing = drQuery["DATABASEMAILING"].ToString();
                    objAuxProfile.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, strLinkedServer + ".CAMPANHAS", strSql.ToString());
                return objAuxProfile;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Database Mailing >>> System Error: " + ex.Message);
            }
        }
        
        public String ManagerProfiles(dtoUsersProfiles getValues, dtoUsers getValuesUsers)
        {
            String strResultado = "";

            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("MANAGER_PROFILES");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getValuesUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@PROFILEID", getValues.IdUserProfile));
                cmdComando.Parameters.Add(new SqlParameter("@PROFILENAME", getValues.DescriptProfile));
                cmdComando.Parameters.Add(new SqlParameter("@PROFILETYPE", getValues.TypeProfile));
                cmdComando.Parameters.Add(new SqlParameter("@STATUS", getValues.Status));
                cmdComando.Parameters.Add(new SqlParameter("@LISTMODULE", getValues.ModuleList));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                objGeral.logSQL(getValuesUsers.User, "CAMPANHAS", strSql.ToString());

                if (drQuery.Read())
                {
                    strResultado = drQuery[0].ToString();
                }
                drQuery.Close();
                
                return strResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "CAMPANHAS", strSql.ToString() + " >>> erro: " + e.Message);
                return "";
            }
        }

        public Int64 ManagerAcessoModulo(dtoUsersProfiles getValues, dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.TaskAcesso)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO ACESSOMODULO (IDPERFILUSUARIO, IDMODULO, DATAHORA, ATIVO)   ");
                            strSql.Append(" VALUES (@idPerfil, @idModulo, GETDATE(), 1)                             ");

                            cmdComando.Parameters.Add(new SqlParameter("@idPerfil", getValues.IdUserProfile));
                            cmdComando.Parameters.Add(new SqlParameter("@idModulo", getValues.Module));
                         
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
                            strSql.Append(" DELETE FROM ACESSOMODULO WHERE IDPERFILUSUARIO = @idPerfil ");

                            cmdComando.Parameters.Add(new SqlParameter("@idPerfil", getValues.IdUserProfile));
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

                objGeral.logSQL(getValuesUsers.User, "CAMPANHAS", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "CAMPANHAS", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerAcessoOperacaoModulo(dtoUsersProfiles getValues, dtoUsers getValuesUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (getValues.TaskAcessoOperacao)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO ACESSOOPERACAOMODULO (IDACESSOMODULO, DATAHORA, ATIVO, INCLUSAO, ALTERACAO, EXCLUSAO, CONSULTA) ");
                            strSql.Append(" VALUES ( @idAcessoModulo, GETDATE(), 1, @intInclusao, @intAlteracao, @intExclusao, @intConsulta )           ");

                            cmdComando.Parameters.Add(new SqlParameter("@idAcessoModulo", getValues.Module));
                            cmdComando.Parameters.Add(new SqlParameter("@intInclusao", getValues.ModuloInclusao));
                            cmdComando.Parameters.Add(new SqlParameter("@intAlteracao", getValues.ModuloAlteracao));
                            cmdComando.Parameters.Add(new SqlParameter("@intExclusao", getValues.ModuloExclusao));
                            cmdComando.Parameters.Add(new SqlParameter("@intConsulta", getValues.ModuloConsulta));

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
                            strSql.Append(" DELETE FROM ACESSOOPERACAOMODULO                                ");
                            strSql.Append("  WHERE IDACESSOMODULO IN ( SELECT IDACESSOMODULO                ");
                            strSql.Append("                              FROM ACESSOMODULO WITH(NOLOCK)     ");
                            strSql.Append("                             WHERE IDPERFILUSUARIO = @idPerfil ) ");

                            cmdComando.Parameters.Add(new SqlParameter("@idPerfil", getValues.IdUserProfile));
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

                objGeral.logSQL(getValuesUsers.User, "CAMPANHAS", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "CAMPANHAS", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Boolean AcessProfileButton(ImageButton btDefault, String btDisable, String strFormID, dtoUsersProfiles.AccessType AType, Int64 idProfile)
        {
            try
            {
                Boolean bolResultado = false;
                UsersProfiles objUsersProfiles = new UsersProfiles();

                bolResultado = objUsersProfiles.AccessProfile(strFormID, AType, idProfile) == 0 ? false : true;
                btDefault.Enabled = bolResultado;

                if (bolResultado == false)
                    btDefault.ImageUrl = btDisable;

                return bolResultado;
            }
            catch
            {
                return false;
            }
        }

        public Int32 AccessProfile(String strForm, dtoUsersProfiles.AccessType enumType, Int64 idProfile)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                Int32 intResult = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CAST(AOPE." + enumType.ToString() + " AS INTEGER) PERMISSAO                          ");
                strSql.Append("   FROM MODULO AS MODU                                                                       ");
                strSql.Append("        INNER JOIN ACESSOMODULO AS AMO ON MODU.IDMODULO = AMO.IDMODULO                       ");
                strSql.Append("        INNER JOIN ACESSOOPERACAOMODULO AS AOPE ON AMO.IDACESSOMODULO = AOPE.IDACESSOMODULO  ");
                strSql.Append("  WHERE MODU.MODULOFILHO IS NOT NULL                                                         ");
                strSql.Append("    AND MODU.FLAG_ATIVO = 1                                                                  ");
                strSql.Append("    AND AMO.IDPERFILUSUARIO = @idProfile                                                     ");
                strSql.Append("    AND MODU.NOMEMODULO = @strForm                                                           ");

                cmdComando.Parameters.Add(new SqlParameter("@idProfile", idProfile));
                cmdComando.Parameters.Add(new SqlParameter("@strForm", strForm));

                SqlDataReader drProfile = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                if (drProfile.Read())
                {
                    intResult = Convert.ToInt32(drProfile["PERMISSAO"].ToString());
                }
                drProfile.Close();

                return intResult;
            }
            catch
            {
                return 0;
            }
        }

        public Boolean AccessTabPanel(String strFormID, dtoUsersProfiles.AccessType AType, Int64 idProfile)
        {
            try
            {
                Boolean bolResultado = false;
                UsersProfiles objUsersProfiles = new UsersProfiles();

                bolResultado = objUsersProfiles.AccessProfile(strFormID, AType, idProfile) == 0 ? false : true;
                return bolResultado;

            }
            catch
            {
                return false;
            }
        }
    }
}
