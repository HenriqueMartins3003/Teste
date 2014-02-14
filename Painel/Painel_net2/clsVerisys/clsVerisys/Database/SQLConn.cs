using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace clsVerisys.Database
{
    public class SQLConn
    {
        /// <summary>
        /// Realiza a abertura de Banco na Aplicação
        /// </summary>
        private SqlConnection AbreBanco(String strConexao)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(strConexao);
                objConn.Open();

                return objConn;
            }
            catch (SqlException eSql)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < eSql.Errors.Count; i++)
                {
                    errorMessages.Append("Index # " + i + "\n" +
                                         "Message: " + eSql.Errors[i].Message + "\n" +
                                         "LineNumber: " + eSql.Errors[i].LineNumber + "\n" +
                                         "Source: " + eSql.Errors[i].Source + "\n" +
                                         "Procedure: " + eSql.Errors[i].Procedure + "\n");
                }

                throw new Exception("Erro ao abrir banco de dados >> " + errorMessages.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir banco de dados >> " + e.Message);
            }
        }

        /// <summary>
        /// Fecha a conexão do Banco de dados Aberta
        /// </summary>
        /// <param name="objConn"></param>
        private void FechaBanco(SqlConnection objConn)
        {
            try
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
            catch (SqlException eSql)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < eSql.Errors.Count; i++)
                {
                    errorMessages.Append("Index # " + i + "\n" +
                                         "Message: " + eSql.Errors[i].Message + "\n" +
                                         "LineNumber: " + eSql.Errors[i].LineNumber + "\n" +
                                         "Source: " + eSql.Errors[i].Source + "\n" +
                                         "Procedure: " + eSql.Errors[i].Procedure + "\n");
                }

                throw new Exception("Erro ao fechar banco de dados >> " + errorMessages.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao fechar banco de dados >> " + e.Message);
            }
        }

        /// <summary>
        /// Executa comando no banco de dados Insert, Update, Delete
        /// </summary>
        /// <returns></returns>
        public Boolean ExecutaComando(String strQuery, SqlCommand cmdComando, CommandType TipoComando, String db)
        {
            SqlConnection objConn = new SqlConnection();
            try
            {
                //Abre a conexão com o banco de dados
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                objConn = AbreBanco(db);

                //Passa os valores da query Sql, tipo do comando, conexão e executa o comando
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = TipoComando;
                cmdComando.Connection = objConn;
                cmdComando.ExecuteNonQuery();

                return true;
            }
            //Tratamento de excessões
            catch (SqlException eSql)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < eSql.Errors.Count; i++)
                {
                    errorMessages.Append("Index # " + i + "\n" +
                                         "Message: " + eSql.Errors[i].Message + "\n" +
                                         "LineNumber: " + eSql.Errors[i].LineNumber + "\n" +
                                         "Source: " + eSql.Errors[i].Source + "\n" +
                                         "Procedure: " + eSql.Errors[i].Procedure + "\n");
                }

                throw new Exception("Erro ao executar comando >> " + errorMessages.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao executar comando >> " + e.Message);
            }
            finally
            {
                FechaBanco(objConn);
            }
        }

        /// <summary>
        /// Executa comando no banco de dados Insert, Update, Delete - retornando o @@IDENTITY
        /// </summary>
        /// <returns>@@IDENTITY</returns>
        public Int64 ExecutaComandoRetorno(String strQuery, SqlCommand cmdComando, CommandType TipoComando, String db)
        {
            SqlConnection objConn = new SqlConnection();

            try
            {
                //Abre a conexão com o banco de dados
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                objConn = AbreBanco(db);

                //Passa os valores da query Sql, tipo do comando, conexão e executa o comando
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = TipoComando;
                cmdComando.Connection = objConn;
                cmdComando.ExecuteNonQuery();

                cmdComando.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt64(cmdComando.ExecuteScalar());
            }
            //Tratamento de excessões
            catch (SqlException eSql)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < eSql.Errors.Count; i++)
                {
                    errorMessages.Append("Index # " + i + "\n" +
                                         "Message: " + eSql.Errors[i].Message + "\n" +
                                         "LineNumber: " + eSql.Errors[i].LineNumber + "\n" +
                                         "Source: " + eSql.Errors[i].Source + "\n" +
                                         "Procedure: " + eSql.Errors[i].Procedure + "\n");
                }

                throw new Exception("Erro ao executar comando de retorno >> " + errorMessages.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao executar comando de retorno >> " + e.Message);
            }
            finally
            {
                FechaBanco(objConn);
            }
        }

        /// <summary>
        /// Retorna comandos Select executados na Base de dados em um DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet RetornaDataSet(String strQuery, SqlCommand cmdComando, CommandType TipoComando, String db)
        {
            //Cria o objeto de conexão
            SqlConnection objConn = new SqlConnection();
            try
            {
                //Abre a conexão com o banco de dados
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                objConn = AbreBanco(db);

                //Passa os valores da Query SQL, tipo do comando, conexão e executa o comando
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = TipoComando;
                cmdComando.Connection = objConn;

                //Declarações
                SqlDataAdapter daAdaptador = new SqlDataAdapter();
                DataSet dsDataSet = new DataSet();

                //Passa o comando a ser executado pelo DataAdapter
                daAdaptador.SelectCommand = cmdComando;

                //O DataAdapter faz o conexão com o banco de dados, carrega o DataSet e fecha a conexão
                daAdaptador.Fill(dsDataSet);

                //Retorna o DataSet carregado
                return dsDataSet;
            }
            //Tratatamento de exceções
            catch (SqlException eSql)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < eSql.Errors.Count; i++)
                {
                    errorMessages.Append("Index # " + i + "\n" +
                                         "Message: " + eSql.Errors[i].Message + "\n" +
                                         "LineNumber: " + eSql.Errors[i].LineNumber + "\n" +
                                         "Source: " + eSql.Errors[i].Source + "\n" +
                                         "Procedure: " + eSql.Errors[i].Procedure + "\n");
                }

                throw new Exception("Erro ao retornar DataSet >> " + errorMessages.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao retornar DataSet >> " + e.Message);
            }
            finally
            {
                FechaBanco(objConn);
            }
        }

        /// <summary>
        /// Retorna comandos Select executados na Base de dados em um DataReader
        /// </summary>
        /// <returns></returns>
        public SqlDataReader RetornaDataReader(String strQuery, SqlCommand cmdComando, CommandType TipoComando, String db)
        {
            //Cria o objeto de conexão
            SqlConnection objConn = new SqlConnection();
            try
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                objConn = AbreBanco(db);

                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = TipoComando;
                cmdComando.Connection = objConn;

                return cmdComando.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException eSql)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < eSql.Errors.Count; i++)
                {
                    errorMessages.Append("Index # " + i + "\n" +
                                         "Message: " + eSql.Errors[i].Message + "\n" +
                                         "LineNumber: " + eSql.Errors[i].LineNumber + "\n" +
                                         "Source: " + eSql.Errors[i].Source + "\n" +
                                         "Procedure: " + eSql.Errors[i].Procedure + "\n");
                }

                throw new Exception("Erro ao retornar DataReader >> " + errorMessages.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao retornar DataReader >> " + e.Message);
            }
        }

        /// <summary>
        /// Retorna DataHora do Banco de Dados
        /// </summary>
        /// <returns></returns>
        public DateTime RetornaDataHora(SqlCommand cmdComando, CommandType TipoComando, String db)
        {
            SqlConnection objConn = new SqlConnection();

            try
            {
                //Abre a conexão com o banco de dados
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                objConn = AbreBanco(db);

                //Passa os valores da query Sql, tipo do comando, conexão e executa o comando
                cmdComando.CommandText = "SELECT GETDATE()";
                cmdComando.CommandType = TipoComando;
                cmdComando.Connection = objConn;

                return Convert.ToDateTime(cmdComando.ExecuteScalar());
            }
            //Tratamento de excessões
            catch (SqlException eSql)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < eSql.Errors.Count; i++)
                {
                    errorMessages.Append("Index # " + i + "\n" +
                                         "Message: " + eSql.Errors[i].Message + "\n" +
                                         "LineNumber: " + eSql.Errors[i].LineNumber + "\n" +
                                         "Source: " + eSql.Errors[i].Source + "\n" +
                                         "Procedure: " + eSql.Errors[i].Procedure + "\n");
                }

                throw new Exception("Erro ao executar comando de retorno >> " + errorMessages.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao executar comando de retorno >> " + e.Message);
            }
            finally
            {
                FechaBanco(objConn);
            }
        }
    }
}
