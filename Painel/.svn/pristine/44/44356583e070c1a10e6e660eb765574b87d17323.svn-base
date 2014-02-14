using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL.Tribanco
{
    public class Mailing
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();

        public DataSet listDadosPrioridade(_webPainelVerisys.DTO.Tribanco.dtoMailing getValues)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, getValues.Campaign);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CAMPANHA, REGRADISTRIBUICAO, PRIORIDADE, DATAHORA    ");
                strSql.Append("   FROM REGRADISTRIBUICAOMAILING                             ");
                strSql.Append("  WHERE CAMPANHA = @idCampanha                               ");
                strSql.Append("  ORDER BY REGRADISTRIBUICAO                                 ");

                cmdComando.Parameters.Add(new SqlParameter("@idCampanha", getValues.Campaign));
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list the Dados Prioridade >>> System Error: " + ex.Message);
            }
        }

        public Int64 ManagerPriorizacao(_webPainelVerisys.DTO.Tribanco.dtoMailing getValues)
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
                            strSql.Append(" UPDATE REGRADISTRIBUICAOMAILING                 ");
                            strSql.Append("    SET PRIORIDADE = @Prioridade,                ");
                            strSql.Append("        DATAHORA = GETDATE()                     ");
                            strSql.Append("  WHERE REGRADISTRIBUICAO = @regraDistribuicao   ");

                            cmdComando.Parameters.Add(new SqlParameter("@Prioridade", getValues.Prioridade));
                            cmdComando.Parameters.Add(new SqlParameter("@regraDistribuicao", getValues.RegraDistribuicao));
                            
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;

                            objGeral.logSQL(getValues.User, "REGRADISTRIBUICAOMAILING", strSql.ToString());
                        }
                        break;
                    case 3:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 4:
                        {
                            strSql.Append("DIS_AplicarRegraPriorizacaoNoMailingAtivo");

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                            intResultado = 1;

                            objGeral.logSQL(getValues.User, "DIS_AplicarRegraPriorizacaoNoMailingAtivo", strSql.ToString());
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "REGRADISTRIBUICAOMAILING", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }
    }
}
