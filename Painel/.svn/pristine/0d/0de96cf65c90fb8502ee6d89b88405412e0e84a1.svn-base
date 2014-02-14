using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DAL
{
    public class clsDatabase
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        clsDBSql objBanco = new clsDBSql();

        public enum Database
        {
            Unique = 1,
            Painel = 2,
            Mailing = 3,
            MailingApp = 4,
            Unique_Historico = 5
        }

        public String BuscaDatabase(Database enumDatabase, String strCampanha)
        {
            String strServidor = "";
            String strDataBase = "";
            String strUsuario = "";
            String strSenha = "";
            String strMaxPool = "";
            String strMinPool = "";

            try
            {
                switch(Convert.ToInt32(enumDatabase))
                {
                    case 1:
                        {
                            strServidor = ConfigurationSettings.AppSettings["UniqueServidor"].ToString();
                            strDataBase = ConfigurationSettings.AppSettings["UniqueDatabase"].ToString();
                            strUsuario = ConfigurationSettings.AppSettings["UniqueUsuario"].ToString();
                            strSenha = ConfigurationSettings.AppSettings["UniqueSenha"].ToString();
                            strMaxPool = ConfigurationSettings.AppSettings["UniqueMaxPool"].ToString();
                            strMinPool = ConfigurationSettings.AppSettings["UniqueMinPool"].ToString();
                        }
                        break;
                    case 2:
                        {
                            strServidor = ConfigurationSettings.AppSettings["PainelServidor"].ToString();
                            strDataBase = ConfigurationSettings.AppSettings["PainelDatabase"].ToString();
                            strUsuario = ConfigurationSettings.AppSettings["PainelUsuario"].ToString();
                            strSenha = ConfigurationSettings.AppSettings["PainelSenha"].ToString();
                            strMaxPool = ConfigurationSettings.AppSettings["PainelMaxPool"].ToString();
                            strMinPool = ConfigurationSettings.AppSettings["PainelMinPool"].ToString();
                        }
                        break;
                    case 3:
                        {
                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" SELECT SERVIDORMAILING, DATABASEMAILING, USUARIOMAILING, PASSWORDMAILING    ");
                            strSql.Append("   FROM CAMPANHAS                                                            ");
                            strSql.Append("  WHERE NUMERO = @idCampanha                                                 ");

                            cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));

                            DataSet dsCampanha = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, BuscaDatabase(Database.Unique, ""));

                            if (dsCampanha.Tables[0].Rows.Count > 0)
                            {
                                strServidor = dsCampanha.Tables[0].Rows[0]["SERVIDORMAILING"].ToString();
                                strDataBase = dsCampanha.Tables[0].Rows[0]["DATABASEMAILING"].ToString();
                                strUsuario = dsCampanha.Tables[0].Rows[0]["USUARIOMAILING"].ToString();
                                strSenha = dsCampanha.Tables[0].Rows[0]["PASSWORDMAILING"].ToString();
                                strMaxPool = "80";
                                strMinPool = "10";
                            }
                        }
                        break;
                    case 4:
                        {
                            strServidor = ConfigurationSettings.AppSettings["MailingServidor"].ToString();
                            strDataBase = ConfigurationSettings.AppSettings["MailingDatabase"].ToString();
                            strUsuario = ConfigurationSettings.AppSettings["MailingUsuario"].ToString();
                            strSenha = ConfigurationSettings.AppSettings["MailingSenha"].ToString();
                            strMaxPool = ConfigurationSettings.AppSettings["MailingMaxPool"].ToString();
                            strMinPool = ConfigurationSettings.AppSettings["MailingMinPool"].ToString();
                        }
                        break;
                    case 5:
                        {
                            strServidor = ConfigurationSettings.AppSettings["HistoricoUniqueServidor"].ToString();
                            strDataBase = ConfigurationSettings.AppSettings["HistoricoUniqueDatabase"].ToString();
                            strUsuario = ConfigurationSettings.AppSettings["HistoricoUniqueUsuario"].ToString();
                            strSenha = ConfigurationSettings.AppSettings["HistoricoUniqueSenha"].ToString();
                            strMaxPool = ConfigurationSettings.AppSettings["HistoricoUniqueMaxPool"].ToString();
                            strMinPool = ConfigurationSettings.AppSettings["HistoricoUniqueMinPool"].ToString();
                        }
                        break;

                }

                String strConexao = "Password=" + strSenha + ";User ID=" + strUsuario + ";Initial Catalog=" + strDataBase + ";Data Source=" + strServidor + "; Max Pool Size = " + strMaxPool + "; Min Pool Size = " + strMinPool + ";";
                return strConexao;
            }
            catch
            {
                throw new Exception("Erro ao buscar dados de Conexão do Banco de Dados, acione o Suporte");
            }
        }

        //public String BuscaTabelaDiscador(String strCampanha)
        //{
        //    try
        //    {
        //        cmdComando.Parameters.Clear();
        //        strSql.Remove(0, strSql.Length);
        //        strSql.Append(" SELECT TABELADISCAGEM           ");
        //        strSql.Append("   FROM CAMPANHAS WITH(NOLOCK)   ");
        //        strSql.Append("  WHERE NUMERO = @idCampanha     ");

        //        cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));
        //        DataSet dsCampanha = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, BuscaDatabase(Database.Unique, ""));

        //        if (dsCampanha.Tables[0].Rows.Count > 0)
        //        {
        //            return dsCampanha.Tables[0].Rows[0]["TABELADISCAGEM"].ToString();
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    catch (Exception eBuscaTabelaDiscador)
        //    {
        //        throw;
        //    }
        //}

        //public String BuscaCampoMotivo(String strCampanha)
        //{
        //    try
        //    {
        //        cmdComando.Parameters.Clear();
        //        strSql.Remove(0, strSql.Length);
        //        strSql.Append(" SELECT CAMPOMOTIVOREAGENDAMENTO ");
        //        strSql.Append("   FROM CAMPANHAS WITH(NOLOCK)   ");
        //        strSql.Append("  WHERE NUMERO = @idCampanha     ");

        //        cmdComando.Parameters.Add(new SqlParameter("@idCampanha", strCampanha));
        //        DataSet dsCampanha = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, BuscaDatabase(Database.Unique, ""));

        //        if (dsCampanha.Tables[0].Rows.Count > 0)
        //        {
        //            return dsCampanha.Tables[0].Rows[0]["CAMPOMOTIVOREAGENDAMENTO"].ToString();
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    catch (Exception eBuscaTabelaDiscador)
        //    {
        //        throw;
        //    }
        //}
    }
}
