using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class GruposDac
    {
        // Construtores
        String strConn = "";
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();


        public GruposDac()
        {
            strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
        }

        public List<dtoGruposDac> listGruposDac(dtoUsers getValues)
        {
            List<dtoGruposDac> listObjAux = new List<dtoGruposDac>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT DISTINCT G.GRUPO, G.NOME                                                 ");
                strSql.Append("   FROM USERSCAMPAIGN UC                                                         ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".CAMPANHAS C ON UC.CAMPAIGN = C.NUMERO ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".GRUPOSDAC G ON G.Grupo = C.GrupoDAC   ");
                strSql.Append("  WHERE IDUSER = @idUser                                                         ");

                //strSql.Append(" SELECT DISTINCT G.GRUPO, G.NOME             ");
                //strSql.Append("   FROM " + strLinkedServer + ".GRUPOSDAC G  ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoGruposDac objAux = new dtoGruposDac();
                    objAux.GrupoDac = drQuery["GRUPO"].ToString();
                    //objAux.NomeGrupoDac = drQuery["NOME"].ToString();
                    objAux.NomeGrupoDac = drQuery["GRUPO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ACDList >>> System Error: " + ex.Message);
            }
        }

        public List<dtoGruposDac> listGruposDacFull(dtoUsers getValues)
        {
            List<dtoGruposDac> listObjAux = new List<dtoGruposDac>();
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                //strSql.Append(" SELECT DISTINCT G.GRUPO, G.NOME                                                 ");
                //strSql.Append("   FROM USERSCAMPAIGN UC                                                         ");
                //strSql.Append("        INNER JOIN " + strLinkedServer + ".CAMPANHAS C ON UC.CAMPAIGN = C.NUMERO ");
                //strSql.Append("        INNER JOIN " + strLinkedServer + ".GRUPOSDAC G ON G.Grupo = C.GrupoDAC   ");
                //strSql.Append("  WHERE IDUSER = @idUser                                                         ");

                strSql.Append(" SELECT DISTINCT G.GRUPO, G.NOME             ");
                strSql.Append("   FROM " + strLinkedServer + ".GRUPOSDAC G  ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoGruposDac objAux = new dtoGruposDac();
                    objAux.GrupoDac = drQuery["GRUPO"].ToString();
                    objAux.NomeGrupoDac = drQuery["GRUPO"].ToString() + " - " + drQuery["NOME"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ACDList >>> System Error: " + ex.Message);
            }
        }

        public SqlDataReader listGruposDacDetails(dtoGruposDac getValues)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT ISNULL(TEMPOCLERICAL, 0) AS TEMPOCLERICAL,   ");
                strSql.Append("        ISNULL(PRIORIDADE, 0)	AS PRIORIDADE       ");
                strSql.Append("   FROM GRUPOSDAC WITH(NOLOCK)                       ");
                strSql.Append("  WHERE GRUPO = @grupoDac                            ");

                cmdComando.Parameters.Add(new SqlParameter("@grupoDac", getValues.GrupoDac));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return drQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ACDList Details >>> System Error: " + ex.Message);
            }
        }

        public Int64 managerGruposDac(dtoGruposDac getValues)
        {
            try
            {
                Int64 intResultado = 0;

                switch (getValues.Task)
                {
                    case 1:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 2:
                        {
                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" UPDATE GRUPOSDAC                    ");
                            strSql.Append("    SET TEMPOCLERICAL = @clerical    ");
                            strSql.Append("  WHERE GRUPO = @GrupoDac            ");

                            cmdComando.Parameters.Add(new SqlParameter("@clerical", getValues.TempoClerical));
                            cmdComando.Parameters.Add(new SqlParameter("@GrupoDac", getValues.GrupoDac));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

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

                objGeral.logSQL(getValues.User, "GRUPOSDAC", strSql.ToString() + " >> parametros: " + getValues.TempoClerical + " / " + getValues.Prioridade + " / " + getValues.GrupoDac);
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "GRUPOSDAC", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 managerGruposDacPrioridade(dtoGruposDac getValues)
        {
            try
            {
                Int64 intResultado = 0;

                switch (getValues.Task)
                {
                    case 1:
                        {
                            intResultado = 0;
                        }
                        break;
                    case 2:
                        {
                            cmdComando.Parameters.Clear();
                            strSql.Remove(0, strSql.Length);
                            strSql.Append(" UPDATE GRUPOSDAC                    ");
                            strSql.Append("    SET PRIORIDADE = @Prioridade     ");
                            strSql.Append("  WHERE GRUPO = @GrupoDac            ");

                            cmdComando.Parameters.Add(new SqlParameter("@Prioridade", getValues.Prioridade));
                            cmdComando.Parameters.Add(new SqlParameter("@GrupoDac", getValues.GrupoDac));

                            String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);

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

                objGeral.logSQL(getValues.User, "GRUPOSDAC", strSql.ToString() + " >> parametros: " + getValues.TempoClerical + " / " + getValues.Prioridade + " / " + getValues.GrupoDac);
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValues.User, "GRUPOSDAC", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        //CRUD Grupo DAC
        public dtoResponse MANAGERGRUPODACPERMISSION(dtoGrupoDacPermission getValues)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_MANAGERGRUPODACPERMISSION");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@IDGRUPODACPERMISSION", getValues.IdGrupoDACRestricao));
                cmdComando.Parameters.Add(new SqlParameter("@GRUPODAC", getValues.GrupoDAC));
                cmdComando.Parameters.Add(new SqlParameter("@TIPO", getValues.Tipo));
                cmdComando.Parameters.Add(new SqlParameter("@CLASSIFICACAO", getValues.Classificacao));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    objResponse.Result = drQuery["RESULT"].ToString();
                    objResponse.ResultCode = Convert.ToInt32(drQuery["RESULTCODE"].ToString());
                }
                drQuery.Close();

                return objResponse;
            }
            catch (Exception e)
            {

                throw new Exception("Error bllTelecom.PAN_MANAGERGRUPODACPERMISSION >>> System Error: " + e.Message);
            }
        }



        public DataSet listGrupoDacPermission(dtoUsers getValues)
        {
            // create a list of the objects
            String strLinkedServer = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                strSql.Append(" SELECT G.Grupo, G.nome, ph.DescriptionType, ph.IDType, cl.DescriptionClassification, t1.GrupoDAC, t1.IDGrupoDACRestricao, t1.Classificacao ");
                strSql.Append("   FROM " + strLinkedServer + ".GRUPOSDAC G   ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".GruposDACRestricao  t1                ");
                strSql.Append("        ON t1.GrupoDAC = g.Grupo                                                         ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".[PhoneClassification] cl              ");
                strSql.Append("        ON t1.Classificacao = cl.IDClassification                                        ");
                strSql.Append("        INNER JOIN " + strLinkedServer + ".[PhoneType]  ph                       ");
                strSql.Append("        ON t1.Tipo = ph.IDType                                                           ");

                cmdComando.Parameters.Add(new SqlParameter("@idUser", getValues.User));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }
    }
}
