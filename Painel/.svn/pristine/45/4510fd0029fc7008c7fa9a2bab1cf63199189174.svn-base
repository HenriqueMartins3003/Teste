using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class blldoNotCallList
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();

        String strConn = "";

        public blldoNotCallList()
        {
            strConn = objConnStr.BuscaDatabase(ConnectionString.Database.doNotCallList);
        }

        public List<dtoProcesso> listProcesso()
        {
            // create a list of the objects
            List<dtoProcesso> listObjAux = new List<dtoProcesso>();

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT PROCESSOID, PROCESSO     ");
                strSql.Append("   FROM PROCESSO WITH(NOLOCK)    ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoProcesso objAux = new dtoProcesso();
                    objAux.ProcessoID = Convert.ToInt64(drQuery["PROCESSOID"].ToString());
                    objAux.Processo = drQuery["PROCESSO"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign >>> System Error: " + ex.Message);
            }
        }

        public DataSet listdoNotCallListMailing(dtoUsers getValuesUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_ListaMailing");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                objGeral.logSQL(getValuesUsers.User, "listdoNotCallListMailing", strSql.ToString());
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Mailing doNotCallList >>> System Error: " + ex.Message);
            }
        }

        public DataSet listdoNotCallListCampaign(dtoUsers getValuesUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_ListaCampanhas");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                objGeral.logSQL(getValuesUsers.User, "listdoNotCallListCampaign", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Campaign doNotCallList >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTRECEPTIVO(dtoUsers getValuesUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTRECEPTIVO");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                objGeral.logSQL(getValuesUsers.User, "blldoNotCallList.UINT_LISTRECEPTIVO", strSql.ToString());

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error blldoNotCallList.UINT_LISTRECEPTIVO >>> System Error: " + ex.Message);
            }
        }




        public String PAN_ManagerMailing(dtodoNotCallList getValues, dtoUsers getValuesUsers)
        {
            try
            {
                String strResultado = "";

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_ManagerMailing");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@IDMAILING", getValues.IDMailing));
                cmdComando.Parameters.Add(new SqlParameter("@TABELADISCADOR", getValues.TabelaDiscador));
                cmdComando.Parameters.Add(new SqlParameter("@KYFONEBLOQUEIO", getValues.KYFoneBloqueio));
                cmdComando.Parameters.Add(new SqlParameter("@LINKEDSERVERMAILING", getValues.LinkedServerMailing));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSOID", getValues.ProcessoID));
                cmdComando.Parameters.Add(new SqlParameter("@FLAG_ATIVO", getValues.Flag_Ativo));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    strResultado = drQuery[0].ToString();
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "PAN_ManagerMailing", strSql.ToString());
                return strResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "PAN_ManagerMailing", strSql.ToString() + " >>> erro: " + e.Message);
                return "";
            }

        }




        public dtoResponse PAN_ManagerCampaign(dtoNotCallCampanha getValues, dtoUsers getValuesUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_ManagerCampanhas");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getValuesUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@IDCAMPANHA", getValues.IDCampanha));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", getValues.Campanha));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSOID", getValues.ProcessoID));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    objResponse.Result = drQuery["RESULT"].ToString();
                    objResponse.ResultCode = Convert.ToInt32(drQuery["RESULTCODE"].ToString());
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "PAN_ManagerMailing", strSql.ToString());
                return objResponse;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "PAN_ManagerMailing", strSql.ToString() + " >>> erro: " + e.Message);
                throw new Exception("Error blldoNotCallList.PAN_ManagerCampaign >>> System Error: " + e.Message);
            }

        }

        public dtoResponse UINT_MANAGER_RECEPTIVO(dtoNotCallReceptivo getValues, dtoUsers getValuesUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_RECEPTIVO");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@IDRECEPTIVO", getValues.IdReceptivo));
				cmdComando.Parameters.Add(new SqlParameter("@DDD", getValues.DDD));
                cmdComando.Parameters.Add(new SqlParameter("@NUMEROTELEFONE", getValues.Telefone));
                cmdComando.Parameters.Add(new SqlParameter("@CPF", getValues.CPF));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    objResponse.Result = drQuery["RESULT"].ToString();
                    objResponse.ResultCode = Convert.ToInt32(drQuery["RESULTCODE"].ToString());
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "UINT_MANAGER_RECEPTIVO", strSql.ToString());
                return objResponse;
            }
            catch (Exception e)
            {
                objGeral.logSQL(getValuesUsers.User, "UINT_MANAGER_RECEPTIVO", strSql.ToString() + " >>> erro: " + e.Message);
                throw new Exception("Error blldoNotCallList.UINT_MANAGER_RECEPTIVO >>> System Error: " + e.Message);
            }

        }
    }
}
