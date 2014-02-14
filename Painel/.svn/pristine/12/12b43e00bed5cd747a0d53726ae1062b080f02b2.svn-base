using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class Versao
    {
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();

        // construtor
        public Versao()
        {

        }

        public List<dtoLogAA> ListLogsAA(string orderBy, bool desc)
        {
            List<dtoLogAA> logs = new List<dtoLogAA>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                strSql.Append("select l.Ramal, l.IpMaquina as Ip, l.VersaoAnterior, v.Versao as VersaoAtualizacao,");
                strSql.Append("Resultado = CASE WHEN l.Resultado = 0 THEN 'Sucesso' else 'Insucesso' END, ");
                strSql.Append("l.DataHora from AAFE_Logs l inner join AAFE_Versoes v on l.IdPacoteAtualizacao = v.IdPacoteVersao ");

                strSql.Append(orderBy);
                if (desc)
                {
                    strSql.Append(" desc");
                }

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoLogAA logAA = new dtoLogAA();
                    logAA.Ramal = drQuery["Ramal"].ToString();
                    logAA.Ip = drQuery["Ip"].ToString();
                    logAA.VersaoAnterior = drQuery["VersaoAnterior"].ToString();
                    logAA.VersaoAtualizacao = drQuery["VersaoAtualizacao"].ToString();
                    logAA.Resultado = drQuery["Resultado"].ToString();
                    logAA.DataHora = drQuery["DataHora"].ToString();

                    logs.Add(logAA);
                }
                drQuery.Close();

                return logs;
            }

            catch (Exception ex)
            {
                throw new System.Exception("Error to list the RAMAL" + ex.Message);
            }
        }

        public List<dtoRamaisVersao> listRamais()
        {
            // start the list object
            List<dtoRamaisVersao> listObjAux = new List<dtoRamaisVersao>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SELECT DISTINCT(RAMAL) FROM AAFE_CONTROLEVERSAO WITH(NOLOCK)");

                // Execute query
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                // Put into the list
                while (drQuery.Read())
                {
                    dtoRamaisVersao objAux = new dtoRamaisVersao();
                    objAux.Ramal = drQuery["RAMAL"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error to list the RAMAL" + ex.Message);
            }

        }

        public List<dtoRamaisVersao> listRamaisGrid(string orderBy, bool desc)
        {
            List<dtoRamaisVersao> ramais = new List<dtoRamaisVersao>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("select Ramal, ModoAtualizacao, VersaoAtual, AtualizarPara = [dbo].[RetornaVersaoSoftwareFrontEnd](idpacoteespecifico) from AAFE_ControleVersao");
                strSql.Append(orderBy);
                if (desc)
                {
                    strSql.Append(" desc");
                }

                // Execute query
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                while (drQuery.Read())
                {
                    dtoRamaisVersao ramalVersao = new dtoRamaisVersao();
                    ramalVersao.Ramal = drQuery["Ramal"].ToString();
                    ramalVersao.ModoAtualizacao = ObtemDescricaoModo(Int32.Parse(drQuery["ModoAtualizacao"].ToString()));
                    ramalVersao.VersaoAtual = drQuery["VersaoAtual"].ToString();
                    ramalVersao.AtualizarPara = drQuery["AtualizarPara"].ToString();

                    ramais.Add(ramalVersao);
                }
                drQuery.Close();

                return ramais;
            }

            catch (Exception ex)
            {
                throw new System.Exception("Error to list the RAMAL" + ex.Message);
            }
        }

        private string ObtemDescricaoModo(int modo)
        {
            string descricao = string.Empty;
            switch (modo)
            {
                case 0:
                    descricao = "Nunca";
                    break;
                case 1:
                    descricao = "Versões mais Recentes";
                    break;
                case 3:
                    descricao = "Sempre";
                    break;
            }

            return descricao;
        }

        private int obtemModo(string descricao)
        {
            int modo = 0;
            switch (descricao)
            {
                case "Nunca":
                    modo = 0;
                    break;
                case "Versões mais Recentes":
                    modo = 1;
                    break;
                case "Sempre":
                    modo = 3;
                    break;
            }

            return modo;
        }

        public string ObtemVersaoDefault()
        {

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SELECT v.Descricao as versao from AAFE_Versoes v inner join AAFE_VersaoEstadoDaArte veda on v.IdPacoteVersao = veda.IdPacoteVersao");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                // Put into the list
                if (drQuery.Read())
                {
                    string versao = drQuery["versao"].ToString();
                    return versao;

                }
                drQuery.Close();

            }
            catch (Exception ex)
            {
                throw new System.Exception("Error to list the Versions" + ex.Message);
            }

            return "";
        }

        public bool SalvaVersaoDefault(int idVersao)
        {
            try
            {
                // start the StringBuilder to query
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                strSql.Append(" update AAFE_VersaoEstadoDaArte set IdPacoteVersao = @idPacote");
                cmdComando.Parameters.Add(new SqlParameter("@idPacote", idVersao));

                // execute query
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                bool result = objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return result;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Update Version not realized.<br />Error: " + ex.Message);
            }
        }

        public List<dtoVersao> listVersao()
        {
            // start the list object
            List<dtoVersao> listObjAux = new List<dtoVersao>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SELECT IdPacoteVersao as Versao, Versao + ' - ' + Descricao as Descricao FROM AAFE_VERSOES WITH(NOLOCK)");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                // Put into the list
                while (drQuery.Read())
                {
                    dtoVersao objAux = new dtoVersao();
                    objAux.IdPacoteVersao = drQuery["Versao"].ToString();
                    objAux.DescricaoVersao = drQuery["Descricao"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error to list the Versions" + ex.Message);
            }

        }

        public Boolean managerVersao(string ramal, int idVersao, int modo, String UserTask)
        {
            try
            {
                // start the StringBuilder to query
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                strSql.Append(" UPDATE AAFE_ControleVersao");
                strSql.Append(" SET IdPacoteEspecifico = @IdPacote, ModoAtualizacao=@Modo");
                strSql.Append(" WHERE Ramal = @Ramal");

                cmdComando.Parameters.Add(new SqlParameter("@IdPacote", idVersao));
                cmdComando.Parameters.Add(new SqlParameter("@Ramal", ramal));
                cmdComando.Parameters.Add(new SqlParameter("@Modo", modo));

                // execute query
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                return objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Update Version not realized.<br />Error: " + ex.Message);
            }

        }
    }
}
