using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class Geral
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();

        /// <summary>
        /// método RetornaDadosXML_Historico
        /// este método retorna um DataSet a página
        /// </summary>
        /// <param name="NomeArquivo"></param>
        /// <returns></returns>
        public static DataSet RetornaDadosXML_Historico(string NomeArquivo)
        {
            string NomeArquivoCarregado = string.Empty;
            if (PesquisaArquivos(NomeArquivo, out NomeArquivoCarregado))
            {
                DataSet dataset = new DataSet();
                dataset.ReadXml(NomeArquivoCarregado);
                return dataset;
            }
            return null;
        }

        /// <summary>
        /// método PesquisaArquivos(NomeArquivo, out NomeArquivoCarregado)
        /// este método prôve meios de manipulação de arquivos XML
        /// </summary>
        /// <param name="NomeArquivo"></param>
        /// <param name="NomeArquivoCarregado"></param>
        /// <returns></returns>
        private static bool PesquisaArquivos(string NomeArquivo, out string NomeArquivoCarregado)
        {
            string sPathXML = ConfigurationSettings.AppSettings["PathXML_Novo"].ToString() + "\\";

            System.IO.DirectoryInfo DirInfo;
            System.IO.FileInfo[] AFileInfo;
            //        System.Int32 qtdArquivos = 0;

            DirInfo = new System.IO.DirectoryInfo(Path.GetDirectoryName(sPathXML));

            try
            {
                //obtem arquivos do diretorio
                AFileInfo = DirInfo.GetFiles("*" + NomeArquivo);
                foreach (FileInfo fInfo in AFileInfo)
                {
                    NomeArquivo = fInfo.FullName;
                    //                qtdArquivos++;
                }

                NomeArquivoCarregado = NomeArquivo;
                return true;
            }
            catch
            {
                NomeArquivoCarregado = string.Empty;
                return false;
            }

        }

        public void logSQL(String IDUsuario, String Tabela, String ComandoSQL)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" INSERT INTO LOG_SQL ( ID_USUARIO, TABELA, COMANDO_SQL ) ");
                strSql.Append("              VALUES ( @idUsuario, @Tabela, @ComandoSql) ");

                cmdComando.Parameters.Add(new SqlParameter("@idUsuario", IDUsuario));
                cmdComando.Parameters.Add(new SqlParameter("@Tabela", Tabela));
                cmdComando.Parameters.Add(new SqlParameter("@ComandoSql", ComandoSQL));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error to logging the query on the database. " + ex.Message);
            }
        }
    }
}
