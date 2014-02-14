using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace clsDatabaseSQL
{
    public class ConnectionString
    {
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objdbSQL = new dbSQL();

        public enum Database
        {
            UserDatabase = 0,
            ChatDatabase = 1,
            WebDatabase = 2,
            UniqueDatabase = 3,
            PainelDatabase = 4,
            MailingDatabase = 5,
            MailingAppDatabase = 6,
            ImportExportDatabase = 7,
            
            doNotCallList = 9,
            UniqueDatabaseHistorico = 10
        }

        /// <summary>
        /// Retorna String de Conexão de Database especifica a partir de informações em Arquivo XML de configuração
        /// </summary>
        /// <param name="enumDatabase">Enumerador com as bases disponiveis para pesquisa</param>
        /// <returns></returns>
        public String BuscaDatabase(Database enumDatabase)
        {
            String strServidor = "";
            String strDataBase = "";
            String strUsuario = "";
            String strSenha = "";
            String strMaxPool = "";
            String strMinPool = "";

            String strTimeout = "";

            if (ConfigurationManager.AppSettings["TimeOutSQL"] != null)
            {
                strTimeout = ConfigurationManager.AppSettings["TimeOutSQL"].ToString();
            }


            try
            {
                switch (Convert.ToInt32(enumDatabase))
                {
                    case 0:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["UserServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["UserDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["UserUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["UserSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["UserMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["UserMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    case 1:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["ChatServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["ChatDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["ChatUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["ChatSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["ChatMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["ChatMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["WebServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["WebDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["WebUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["WebSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["WebMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["WebMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    case 3:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["UniqueServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["UniqueDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["UniqueUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["UniqueSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["UniqueMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["UniqueMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    case 4:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["PainelServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["PainelDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["PainelUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["PainelSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["PainelMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["PainelMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    case 5:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["MailingServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["MailingDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["MailingUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["MailingSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["MailingMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["MailingMinPool"].ToString();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    case 6:
                        break;
                    case 7:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["ImportExportServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["ImportExportDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["ImportExportUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["ImportExportSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["ImportExportMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["ImportExportMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    case 8:
                        break;

                    case 9:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["doNotCallServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["doNotCallDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["doNotCallUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["doNotCallSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["doNotCallMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["doNotCallMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;

                    case 10:
                        {
                            try
                            {
                                strServidor = ConfigurationManager.AppSettings["HistoricoUniqueServidor"].ToString();
                                strDataBase = ConfigurationManager.AppSettings["HistoricoUniqueDatabase"].ToString();
                                strUsuario = ConfigurationManager.AppSettings["HistoricoUniqueUsuario"].ToString();
                                strSenha = ConfigurationManager.AppSettings["HistoricoUniqueSenha"].ToString();
                                strMaxPool = ConfigurationManager.AppSettings["HistoricoUniqueMaxPool"].ToString();
                                strMinPool = ConfigurationManager.AppSettings["HistoricoUniqueMinPool"].ToString();
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;

                    default:
                        break;
                }

                String strApplication = "";

                try
                {
                    Int32 iPosicao = System.AppDomain.CurrentDomain.FriendlyName.IndexOf('.');
                    strApplication = System.AppDomain.CurrentDomain.FriendlyName.ToString().Substring(0, iPosicao);
                }
                catch
                {
                    System.Reflection.AssemblyName assembly = System.Reflection.Assembly.GetCallingAssembly().GetName();
                    strApplication = assembly.Name;
                }


                String strConexao = "Password=" + strSenha + ";User ID=" + strUsuario + ";Initial Catalog=" + strDataBase + ";Data Source=" + strServidor + "; Max Pool Size = " + strMaxPool + "; Min Pool Size = " + strMinPool + "; Application Name=" + strApplication + "; Connection Timeout=" + strTimeout + ";";

                if (strDataBase != String.Empty)
                    return strConexao;
                else
                    return "";

            }
            catch (Exception ex)
            {
                throw new Exception(" Erro ao buscar dados de Conexão do Banco de Dados !! --> " + ex.Message);
            }
        }

        /// <summary>
        /// <para>Retorna String de Conexão de Database especifica a partir de informações em Arquivo XML de configuração</para>
        /// <para>Os dados da Base de Mailing, são localizadas na base do Unique</para>
        /// </summary>
        /// <param name="enumDatabase">Enumerador com as bases disponiveis para pesquisa</param>
        /// <param name="strCampanha">ID da Campanha a ter a base de Mailing Localizada</param>
        /// <returns></returns>
        public String BuscaDatabase(Database enumDatabase, String strCampanha)
        {
            String strServidor = "";
            String strDataBase = "";
            String strUsuario = "";
            String strSenha = "";

            String strTimeout = "";

            if (ConfigurationManager.AppSettings["TimeOutSQL"] != null)
            {
                strTimeout = ConfigurationManager.AppSettings["TimeOutSQL"].ToString();
            }

            try
            {
                switch (Convert.ToInt32(enumDatabase))
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        {
                            try
                            {
                                String strConn = BuscaDatabase(ConnectionString.Database.UniqueDatabase);

                                cmdComando.Parameters.Clear();
                                strSql.Remove(0, strSql.Length);
                                strSql.Append(" SELECT SERVIDORMAILING, DATABASEMAILING, USUARIOMAILING, PASSWORDMAILING    ");
                                strSql.Append("   FROM CAMPANHAS                                                            ");
                                strSql.Append("  WHERE NUMERO = @idCampanha                                                 ");

                                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));

                                DataSet dsCampanha = objdbSQL.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                                if (dsCampanha.Tables[0].Rows.Count > 0)
                                {
                                    strServidor = dsCampanha.Tables[0].Rows[0]["SERVIDORMAILING"].ToString();
                                    strDataBase = dsCampanha.Tables[0].Rows[0]["DATABASEMAILING"].ToString();
                                    strUsuario = dsCampanha.Tables[0].Rows[0]["USUARIOMAILING"].ToString();
                                    strSenha = dsCampanha.Tables[0].Rows[0]["PASSWORDMAILING"].ToString();
                                }
                            }
                            catch
                            {
                                throw new Exception(" Arquivo de Configuração não pode ser Lido, ou parametros inexistentes !! ");
                            }
                        }
                        break;
                    default:
                        break;
                }

                String strApplication = "";

                try
                {
                    Int32 iPosicao = System.AppDomain.CurrentDomain.FriendlyName.IndexOf('.');
                    strApplication = System.AppDomain.CurrentDomain.FriendlyName.ToString().Substring(0, iPosicao);
                }
                catch
                {
                    System.Reflection.AssemblyName assembly = System.Reflection.Assembly.GetCallingAssembly().GetName();
                    strApplication = assembly.Name;
                }

                String strConexao = "Password=" + strSenha + ";User ID=" + strUsuario + ";Initial Catalog=" + strDataBase + ";Data Source=" + strServidor + ";" + "; Application Name=" + strApplication + "; Connection Timeout=" + strTimeout + ";";

                if (strDataBase != String.Empty)
                    return strConexao;
                else
                    return "";

            }
            catch (Exception ex)
            {
                throw new Exception(" Erro ao buscar dados de Conexão do Banco de Dados !! --> " + ex.Message);
            }
        }
    }
}
