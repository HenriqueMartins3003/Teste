using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace clsVerisys.Database
{
    public class SQLConnString
    {
        Cryptography.Cryptography objCripto = new Cryptography.Cryptography();







        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cUNIQUE;
        public String cUNIQUE
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["UNIQUE"] != null) && (_cUNIQUE == null))
                {
                    _cUNIQUE = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["UNIQUE"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cUNIQUE;
                }
                else
                {
                    return _cUNIQUE;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cUNIQUEHISTORICO;
        public String cUNIQUEHISTORICO
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["UNIQUEHISTORICO"] != null) && (_cUNIQUEHISTORICO == null))
                {
                    if (ConfigurationManager.ConnectionStrings["UNIQUEHISTORICO"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("UNIQUEHISTORICO", ConfigurationManager.ConnectionStrings["UNIQUEHISTORICO"].ToString());
                    }

                    _cUNIQUEHISTORICO = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["UNIQUEHISTORICO"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cUNIQUEHISTORICO;
                }
                else
                {
                    return _cUNIQUEHISTORICO;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cMAILING;
        public String cMAILING
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["MAILING"] != null) && (_cMAILING == null))
                {
                    if (ConfigurationManager.ConnectionStrings["MAILING"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("MAILING", ConfigurationManager.ConnectionStrings["MAILING"].ToString());
                    }

                    _cMAILING = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["MAILING"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cMAILING;
                }
                else
                {
                    return _cMAILING;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cMAILINGAPP;
        public String cMAILINGAPP
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["MAILINGAPP"] != null) && (_cMAILINGAPP == null))
                {
                    if (ConfigurationManager.ConnectionStrings["MAILINGAPP"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("MAILINGAPP", ConfigurationManager.ConnectionStrings["MAILINGAPP"].ToString());
                    }

                    _cMAILINGAPP = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["MAILINGAPP"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cMAILINGAPP;
                }
                else
                {
                    return _cMAILINGAPP;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cMAILINGHISTORICO;
        public String cMAILINGHISTORICO
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["MAILINGHISTORICO"] != null) && (_cMAILINGHISTORICO == null))
                {
                    if (ConfigurationManager.ConnectionStrings["MAILINGHISTORICO"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("MAILINGHISTORICO", ConfigurationManager.ConnectionStrings["MAILINGHISTORICO"].ToString());
                    }

                    _cMAILINGHISTORICO = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["MAILINGHISTORICO"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cMAILINGHISTORICO;
                }
                else
                {
                    return _cMAILINGHISTORICO;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cPAINEL;
        public String cPAINEL
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["PAINEL"] != null) && (_cPAINEL == null))
                {
                    if (ConfigurationManager.ConnectionStrings["PAINEL"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("PAINEL", ConfigurationManager.ConnectionStrings["PAINEL"].ToString());
                    }

                    _cPAINEL = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["PAINEL"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cPAINEL;
                }
                else
                {
                    return _cPAINEL;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cIMPORTEXPORT;
        public String cIMPORTEXPORT
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["IMPORTEXPORT"] != null) && (_cIMPORTEXPORT == null))
                {
                    if (ConfigurationManager.ConnectionStrings["IMPORTEXPORT"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("IMPORTEXPORT", ConfigurationManager.ConnectionStrings["IMPORTEXPORT"].ToString());
                    }

                    _cIMPORTEXPORT = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["IMPORTEXPORT"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cIMPORTEXPORT;
                }
                else
                {
                    return _cIMPORTEXPORT;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cDONOTCALL;
        public String cDONOTCALL
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["DONOTCALL"] != null) && (_cDONOTCALL == null))
                {
                    if (ConfigurationManager.ConnectionStrings["DONOTCALL"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("DONOTCALL", ConfigurationManager.ConnectionStrings["DONOTCALL"].ToString());
                    }

                    _cDONOTCALL = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["DONOTCALL"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cDONOTCALL;
                }
                else
                {
                    return _cDONOTCALL;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _cCONFIG;
        public String cCONFIG
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["CONFIG"] != null) && (cCONFIG == null))
                {
                    if (ConfigurationManager.ConnectionStrings["CONFIG"].ConnectionString.Contains("Data Source"))
                    {
                        WriteConnectionStringEncrypted("CONFIG", ConfigurationManager.ConnectionStrings["CONFIG"].ToString());
                    }

                    _cCONFIG = objCripto.Criptografia(ConfigurationManager.ConnectionStrings["CONFIG"].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                    return _cCONFIG;
                }
                else
                {
                    return _cCONFIG;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dUNIQUE;
        public String dUNIQUE
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["UNIQUE"] != null) && (_dUNIQUE == null))
                {
                    _dUNIQUE = ConfigurationManager.ConnectionStrings["UNIQUE"].ToString();
                    return _dUNIQUE;
                }
                else
                {
                    return _dUNIQUE;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dUNIQUEHISTORICO;
        public String dUNIQUEHISTORICO
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["UNIQUEHISTORICO"] != null) && (_dUNIQUEHISTORICO == null))
                {
                    _dUNIQUEHISTORICO = ConfigurationManager.ConnectionStrings["UNIQUEHISTORICO"].ToString();
                    return _dUNIQUEHISTORICO;
                }
                else
                {
                    return _dUNIQUEHISTORICO;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dMAILING;
        public String dMAILING
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["MAILING"] != null) && (_dMAILING == null))
                {
                    _dMAILING = ConfigurationManager.ConnectionStrings["MAILING"].ToString();
                    return _dMAILING;
                }
                else
                {
                    return _dMAILING;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dMAILINGAPP;
        public String dMAILINGAPP
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["MAILINGAPP"] != null) && (_dMAILINGAPP == null))
                {
                    _dMAILINGAPP = ConfigurationManager.ConnectionStrings["MAILINGAPP"].ToString();
                    return _dMAILINGAPP;
                }
                else
                {
                    return _dMAILINGAPP;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dMAILINGHISTORICO;
        public String dMAILINGHISTORICO
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["MAILINGHISTORICO"] != null) && (_dMAILINGHISTORICO == null))
                {
                    _dMAILINGHISTORICO = ConfigurationManager.ConnectionStrings["MAILINGHISTORICO"].ToString();
                    return _dMAILINGHISTORICO;
                }
                else
                {
                    return _dMAILINGHISTORICO;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dPAINEL;
        public String dPAINEL
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["PAINEL"] != null) && (_dPAINEL == null))
                {
                    _dPAINEL = ConfigurationManager.ConnectionStrings["PAINEL"].ToString();
                    return _dPAINEL;
                }
                else
                {
                    return _dPAINEL;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dIMPORTEXPORT;
        public String dIMPORTEXPORT
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["IMPORTEXPORT"] != null) && (_dIMPORTEXPORT == null))
                {
                    _dIMPORTEXPORT = ConfigurationManager.ConnectionStrings["IMPORTEXPORT"].ToString();
                    return _dIMPORTEXPORT;
                }
                else
                {
                    return _dIMPORTEXPORT;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dDONOTCALL;
        public String dDONOTCALL
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["DONOTCALL"] != null) && (_dDONOTCALL == null))
                {
                    _dDONOTCALL = ConfigurationManager.ConnectionStrings["DONOTCALL"].ToString();
                    return _dDONOTCALL;
                }
                else
                {
                    return _dDONOTCALL;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _dCONFIG;
        public String dCONFIG
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["CONFIG"] != null) && (_dCONFIG == null))
                {
                    _dCONFIG = ConfigurationManager.ConnectionStrings["CONFIG"].ToString();
                    return _dCONFIG;
                }
                else
                {
                    return _dCONFIG;
                }
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        private String _ConnectionString;
        public String ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        
        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        /// <summary>
        /// 
        /// </summary>
        public enum Database
        {
            UNIQUE = 0,
            UNIQUEHISTORICO = 1,
            MAILING = 2,
            MAILINGAPP = 3,
            MAILINGHISTORICO = 4,
            PAINEL = 5,
            IMPORTEXPORT = 6,
            DONOTCALL = 8,
            CONFIG = 9
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao")]
        /// <summary>
        /// Retorna String de Conexão de Database especifica a partir de informações em Arquivo XML de configuração
        /// </summary>
        /// <param name="enumDatabase">Enumerador com as bases disponiveis para pesquisa</param>
        /// <returns></returns>
        public String BuscaDatabase(Database eDatabase, AplicationType eAplicationType)
        {
            String strConnectionString = "";
            try
            {
                if (eAplicationType == AplicationType.Desktop)
                {
                    switch (Convert.ToInt32(eDatabase))
                    {
                        case 0:
                            strConnectionString = cUNIQUE;
                            break;
                        case 1:
                            strConnectionString = cUNIQUEHISTORICO;
                            break;
                        case 2:
                            strConnectionString = cMAILING;
                            break;
                        case 3:
                            break;
                        case 4:
                            strConnectionString = cMAILINGHISTORICO;
                            break;
                        case 5:
                            strConnectionString = cPAINEL;
                            break;
                        case 6:
                            strConnectionString = cIMPORTEXPORT;
                            break;
                        case 7:
                            break;
                        case 8:
                            strConnectionString = cDONOTCALL;
                            break;
                        case 9:
                            strConnectionString = cCONFIG;
                            break;
                        default:
                            break;
                    }
                }
                else if (eAplicationType == AplicationType.Intranet)
                {
                    switch (Convert.ToInt32(eDatabase))
                    {
                        case 0:
                            strConnectionString = dUNIQUE;
                            break;
                        case 1:
                            strConnectionString = dUNIQUEHISTORICO;
                            break;
                        case 2:
                            strConnectionString = dMAILING;
                            break;
                        case 3:
                            break;
                        case 4:
                            strConnectionString = dMAILINGHISTORICO;
                            break;
                        case 5:
                            strConnectionString = dPAINEL;
                            break;
                        case 6:
                            strConnectionString = dIMPORTEXPORT;
                            break;
                        case 7:
                            break;
                        case 8:
                            strConnectionString = dDONOTCALL;
                            break;
                        case 9:
                            strConnectionString = dCONFIG;
                            break;
                        default:
                            break;
                    }
                }


                if (strConnectionString != String.Empty)
                {
                    Int32 iPosicao = 0;
                    String strApplication = "";

                    try
                    {
                        iPosicao = System.AppDomain.CurrentDomain.FriendlyName.IndexOf('.');
                        strApplication = System.AppDomain.CurrentDomain.FriendlyName.ToString().Substring(0, iPosicao);

                    }
                    catch
                    {
                        System.Reflection.AssemblyName assembly = System.Reflection.Assembly.GetCallingAssembly().GetName();
                        strApplication = assembly.Name;
                    }

                    return strConnectionString += "; Application Name = " + strApplication;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" Erro ao buscar dados de Conexão do Banco de Dados !! --> " + ex.Message);
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto, utilize BuscaConexao com o parametro de Campanha")]
        /// <summary>
        /// <para>Retorna String de Conexão de Database especifica a partir de informações em Arquivo XML de configuração</para>
        /// <para>Os dados da Base de Mailing, são localizadas na base do Unique</para>
        /// </summary>
        /// <param name="enumDatabase">Enumerador com as bases disponiveis para pesquisa</param>
        /// <param name="strCampanha">ID da Campanha a ter a base de Mailing Localizada</param>
        /// <returns></returns>
        public String BuscaDatabase(Database enumDatabase, AplicationType eAplicationType, String strCampanha)
        {
            StringBuilder strSql = new StringBuilder();
            SqlCommand cmdComando = new SqlCommand();
            SQLConn objSQLConn = new SQLConn();

            String strConnectionString = "";

            try
            {
                switch (Convert.ToInt32(enumDatabase))
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        {
                            String strConn = cUNIQUE;

                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" SELECT SERVIDORMAILING, DATABASEMAILING, USUARIOMAILING, PASSWORDMAILING    ");
                            strSql.Append("   FROM CAMPANHAS                                                            ");
                            strSql.Append("  WHERE NUMERO = @idCampanha                                                 ");

                            cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));

                            IDataReader drQuery = objSQLConn.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            if (drQuery.Read())
                            {
                                strConnectionString = "Password=" + drQuery["PASSWORDMAILING"];
                                strConnectionString += "; User ID=" + drQuery["USUARIOMAILING"];
                                strConnectionString += "; Initial Catalog=" + drQuery["DATABASEMAILING"];
                                strConnectionString += "; Data Source=" + drQuery["SERVIDORMAILING"];

                                if (eAplicationType == AplicationType.Intranet)
                                {
                                    strConnectionString += "; Max Pool Size = 50";
                                    strConnectionString += "; Min Pool Size = 10";
                                }
                            }
                            drQuery.Close();
                        }
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 101:
                        break;
                    case 102:
                        break;
                    case 103:
                        {
                            String strConn = dUNIQUE;

                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" SELECT SERVIDORMAILING, DATABASEMAILING, USUARIOMAILING, PASSWORDMAILING    ");
                            strSql.Append("   FROM CAMPANHAS                                                            ");
                            strSql.Append("  WHERE NUMERO = @idCampanha                                                 ");

                            cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));

                            IDataReader drQuery = objSQLConn.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                            if (drQuery.Read())
                            {
                                strConnectionString = "Password=" + drQuery["PASSWORDMAILING"];
                                strConnectionString += "; User ID=" + drQuery["USUARIOMAILING"];
                                strConnectionString += "; Initial Catalog=" + drQuery["DATABASEMAILING"];
                                strConnectionString += "; Data Source=" + drQuery["SERVIDORMAILING"];

                                if (eAplicationType == AplicationType.Intranet)
                                {
                                    strConnectionString += "; Max Pool Size = 50";
                                    strConnectionString += "; Min Pool Size = 10";
                                }
                            }
                            drQuery.Close();
                        }
                        break;
                    case 104:
                        break;
                    case 105:
                        break;
                    case 106:
                        break;
                    case 107:
                        break;
                    case 108:
                        break;
                    case 109:
                        break;
                    default:
                        break;
                }

                if (strConnectionString != String.Empty)
                {
                    Int32 iPosicao = 0;
                    String strApplication = "";

                    try
                    {
                        iPosicao = System.AppDomain.CurrentDomain.FriendlyName.IndexOf('.');
                        strApplication = System.AppDomain.CurrentDomain.FriendlyName.ToString().Substring(0, iPosicao);

                    }
                    catch
                    {
                        System.Reflection.AssemblyName assembly = System.Reflection.Assembly.GetCallingAssembly().GetName();
                        strApplication = assembly.Name;
                    }

                    return strConnectionString += "; Application Name = " + strApplication;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" Erro ao buscar dados de Conexão do Banco de Dados !! --> " + ex.Message);
            }
        }














        public enum AplicationType
        {
            Desktop = 0,
            Intranet = 1
        }

        /// <summary>
        /// Busca a String de Conexão para Bancos de Dados SQL
        /// </summary>
        /// <param name="strDatabase">Nome da String de Conexão no web.Config / app.Config</param>
        /// <param name="eAplicationType">Tipo de Aplicação (Desktop será criptografada, Intranet/Internet acesso convencional) </param>
        /// <returns>String de Conexão</returns>
        public String BuscaConexao(String strDatabase, AplicationType eAplicationType)
        {
            String strConnectionString = "";

            try
            {
                switch (eAplicationType)
                {
                    case AplicationType.Desktop:
                        {
                            if (ConfigurationManager.ConnectionStrings[strDatabase].ConnectionString.Contains("Data Source"))
                            {
                                strConnectionString = ConfigurationManager.ConnectionStrings[strDatabase].ToString();
                                WriteConnectionStringEncrypted(strDatabase, ConfigurationManager.ConnectionStrings[strDatabase].ToString());
                            }
                            else
                            {
                                strConnectionString = objCripto.Criptografia(ConfigurationManager.ConnectionStrings[strDatabase].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                            }
                        }
                        break;
                    case AplicationType.Intranet:
                        {
                            strConnectionString = ConfigurationManager.ConnectionStrings[strDatabase].ToString();
                        }
                        break;
                    default:
                        break;
                }

                return strConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception(" Erro ao buscar dados de Conexão do Banco de Dados !! --> " + ex.Message);
            }
        
        }

        /// <summary>
        /// Busca a String de Conexão para Bancos de Dados SQL, a partir de uma campanha Unique especifica.
        /// </summary>
        /// <param name="strDatabase">Nome da String de Conexão no web.Config / app.Config (Neste caso do Servidor Telecom Unique)</param>
        /// <param name="eAplicationType">Tipo de Aplicação (Desktop será criptografada, Intranet/Internet acesso convencional) </param>
        /// <returns>String de Conexão</returns>
        public String BuscaConexao(String strDatabase, AplicationType eAplicationType, String strCampanha)
        {
            String strConnectionString = "";

            try
            {
                switch (eAplicationType)
                {
                    case AplicationType.Desktop:
                        {
                            if (ConfigurationManager.ConnectionStrings[strDatabase].ConnectionString.Contains("Data Source"))
                            {
                                strConnectionString = ConfigurationManager.ConnectionStrings[strDatabase].ToString();
                                WriteConnectionStringEncrypted(strDatabase, ConfigurationManager.ConnectionStrings[strDatabase].ToString());
                            }
                            else
                            {
                                strConnectionString = objCripto.Criptografia(ConfigurationManager.ConnectionStrings[strDatabase].ToString(), Cryptography.Cryptography.Metodo.Decriptograr);
                            }
                        }
                        break;
                    case AplicationType.Intranet:
                        {
                            strConnectionString = ConfigurationManager.ConnectionStrings[strDatabase].ToString();
                        }
                        break;
                    default:
                        break;
                }

                return BuscaDadosCampanha(strCampanha, strConnectionString, eAplicationType);
            }
            catch (Exception ex)
            {
                throw new Exception(" Erro ao buscar dados de Conexão do Banco de Dados !! --> " + ex.Message);
            }
        }

        /// <summary>
        /// Função Interna, utilizada pelo Busca Conexão com Campanha
        /// </summary>
        /// <param name="strCampanha"></param>
        /// <param name="strDatabase"></param>
        /// <param name="eAplicationType"></param>
        /// <returns></returns>
        private String BuscaDadosCampanha(String strCampanha, String strDatabase, AplicationType eAplicationType)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                SqlCommand cmdComando = new SqlCommand();
                SQLConn objSQLConn = new SQLConn();

                SqlConnectionStringBuilder newConn = new SqlConnectionStringBuilder(strDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT [ServidorMailing],               ");
                strSql.Append("        [DatabaseMailing],               ");
                strSql.Append("        [UsuarioMailing],                ");
                strSql.Append("        [PasswordMailing]                ");
                strSql.Append("   FROM [dbo].[CAMPANHAS] WITH(NOLOCK)   ");
                strSql.Append("  WHERE [Numero] = @Campanha             ");

                cmdComando.Parameters.Add(new SqlParameter("@Campanha", strCampanha));

                String strConnString = this.BuscaConexao(strDatabase, eAplicationType);
                IDataReader drQuery = objSQLConn.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConnString);
                if (drQuery.Read())
                {
                    newConn.DataSource = drQuery["ServidorMailing"].ToString();
                    newConn.InitialCatalog = drQuery["DatabaseMailing"].ToString();
                    newConn.UserID = drQuery["UsuarioMailing"].ToString();
                    newConn.Password = drQuery["PasswordMailing"].ToString();
                }
                drQuery.Close();

                return newConn.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Função Interna, Usada para a criptografia de Strings de Conexão
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void WriteConnectionStringEncrypted(String key, String value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString = objCripto.Criptografia(value, Cryptography.Cryptography.Metodo.Criptografar);
            configuration.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
