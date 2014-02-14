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
    public class Users
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();

        public dtoUsers login(String strUser, String strPass)
        {
            try
            {
                dtoUsers objAux = new dtoUsers();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SP_LOGIN");

                cmdComando.Parameters.Add(new SqlParameter("@LOGIN", strUser));
                cmdComando.Parameters.Add(new SqlParameter("@SENHA", strPass));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                if (drQuery.Read())
                {
                    objAux.User = drQuery["Codigo"].ToString();
                    objAux.Name = drQuery["Nome"].ToString();
                    objAux.Type = drQuery["Tipo"].ToString();
                    objAux.Gender = drQuery["Sexo"].ToString();
                    objAux.Status = drQuery["Estado"].ToString();
                    objAux.DateTimeNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    objAux.IdProfile = getProfile(drQuery["Codigo"].ToString());
                    objAux.LoginOK = true;
                }
                else
                {
                    objAux.LoginOK = false;
                }
                drQuery.Close();

                objGeral.logSQL(strUser, "SP_LOGIN", strSql.ToString());
                return objAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to process User >>> System Error: " + ex.Message);
            }
        }

        public Int16 getProfile(String IdUserVerisys)
        {
            try
            {
                Int16 IdUserProfile = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDPERFILUSUARIO                      ");
                strSql.Append("   FROM USERS                                ");
                strSql.Append("  WHERE IDUSUARIOVERISYS = @IdUsuarioVerisys ");

                cmdComando.Parameters.Add(new SqlParameter("@IdUsuarioVerisys", IdUserVerisys));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);

                if (drQuery.Read())
                {
                    IdUserProfile = Int16.Parse(drQuery["IDPERFILUSUARIO"].ToString());
                }
                drQuery.Close();

                objGeral.logSQL(IdUserVerisys, "IDPERFILUSUARIO", strSql.ToString());
                return IdUserProfile;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Profiles >>> System Error: " + ex.Message);
            }
        }

        public DataSet listUsersAssociated(dtoUsers getValues, dtoUsers getValuesUserPanel)
        {
            try
            {
                String strLinkedUnique = ConfigurationSettings.AppSettings["UniqueLinkedServer"].ToString();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT PU.IDPERFILUSUARIO, PU.DESCRICAO, PU.PERFIL, UPD.IDUSUARIO, UV.CODIGO, UV.NOME, UV.GRUPOSUPERVISAO ");
                strSql.Append("   FROM PERFILUSUARIOS PU ");
                strSql.Append("        INNER JOIN USERS UPD ON PU.IDPERFILUSUARIO = UPD.IDPERFILUSUARIO ");
                strSql.Append("        INNER JOIN " + strLinkedUnique + ".[USUARIOS] UV ON UPD.IDUSUARIOVERISYS = UV.CODIGO ");
                strSql.Append("  WHERE UPD.STATUS = 1 ");

                if (getValues.User != null)
                {
                    strSql.Append(" AND UV.CODIGO LIKE @codigo ");
                    cmdComando.Parameters.Add(new SqlParameter("@codigo", getValues.User.Replace("*", "%")));
                }

                if (getValues.Name != null)
                {
                    strSql.Append(" AND UV.NOME LIKE @nome ");
                    cmdComando.Parameters.Add(new SqlParameter("@nome", getValues.Name.Replace("*", "%")));
                }

                strSql.Append(" ORDER BY CODIGO ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "PERFILUSUARIOS INNER JOIN USERS INNER JOIN " + strLinkedUnique + ".USUARIOS", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error to list the users associated's >>> System Error: " + ex.Message);
            }
        }

        public List<dtoUsers> listUsersNotAssociated(dtoUsers getValues, dtoUsers getValuesUserPanel)
        {
            List<dtoUsers> listObjAux = new List<dtoUsers>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CODIGO, NOME, TIPO, SEXO, ESTADO ");
                strSql.Append("   FROM USUARIOS WITH(NOLOCK)            ");

                if (getValues.User != null)
                {
                    strSql.Append(" WHERE CODIGO LIKE @codigo       ");
                    cmdComando.Parameters.Add(new SqlParameter("@codigo", getValues.User.Replace("*", "%").Trim()));
                }
                if (getValues.Name != null)
                {
                    strSql.Append(" WHERE NOME LIKE @nome           ");
                    cmdComando.Parameters.Add(new SqlParameter("@nome", getValues.Name.Replace("*", "%").Trim()));
                }

                strSql.Append(" ORDER BY Codigo ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "USUARIOS", strSql.ToString());

                while (drQuery.Read())
                {
                    dtoUsers objAux = new dtoUsers();
                    objAux.User = drQuery["Codigo"].ToString();
                    objAux.Name = drQuery["Nome"].ToString();
                    objAux.Type = drQuery["Tipo"].ToString();
                    objAux.Gender = drQuery["Sexo"].ToString();
                    objAux.Status = drQuery["Estado"].ToString();

                    if (getValues.User != null)
                    {
                        objAux.UserName = drQuery["Codigo"].ToString() + " - " + drQuery["Nome"].ToString();
                    }
                    if (getValues.Name != null)
                    {
                        objAux.UserName = drQuery["Nome"].ToString() + " - " + drQuery["Codigo"].ToString();
                    }

                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error: List the users >>> System Error: " + ex.Message);
            }
        }

        public List<dtoUsers> listUserProfile(dtoUsers getValuesUserPanel)
        {
            List<dtoUsers> listObjAux = new List<dtoUsers>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDPERFILUSUARIO, DESCRICAO, PERFIL   ");
                strSql.Append("   FROM PERFILUSUARIOS WITH(NOLOCK)          ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drUsersProfiles = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                objGeral.logSQL(getValuesUserPanel.User, "PERFILUSUARIOS", strSql.ToString());

                while (drUsersProfiles.Read())
                {
                    dtoUsers objAux = new dtoUsers();
                    objAux.IdProfile = Convert.ToInt16(drUsersProfiles["IDPERFILUSUARIO"].ToString());
                    objAux.DescriptProfile = drUsersProfiles["DESCRICAO"].ToString();
                    objAux.Type = drUsersProfiles["PERFIL"].ToString();
                    listObjAux.Add(objAux);
                }
                drUsersProfiles.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Erro to list user profile >>> System Error: " + ex.Message);
            }
        }

        public String ManagerUsers(dtoUsers getValues, dtoUsers getValuesUsers)
        {
            String strResultado = "";

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("MANAGER_USERS");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getValuesUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@USERID", getValues.User));
                cmdComando.Parameters.Add(new SqlParameter("@USERPROFILE", getValues.IdProfile));
                cmdComando.Parameters.Add(new SqlParameter("@LISTCAMPAIGN", getValues.ListCampaign));
                cmdComando.Parameters.Add(new SqlParameter("@LISTGROUPS", getValues.ListGroups));

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                objGeral.logSQL(getValuesUsers.User, "MANAGER_USERS", strSql.ToString());

                if (drQuery.Read())
                {
                    strResultado = drQuery[0].ToString();
                }
                drQuery.Close();

                return strResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "MANAGER_USERS", strSql.ToString() + " >>> erro: " + e.Message);
                return "";
            }
        }
    }
}
