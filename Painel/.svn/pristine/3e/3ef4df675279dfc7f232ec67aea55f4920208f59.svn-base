using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class bllTelecom
    {
        // Construtores
        String strConn = "";
        StringBuilder strSql = new StringBuilder();

        dbSQL objBanco = new dbSQL();
        SqlCommand cmdComando = new SqlCommand();
        ConnectionString objConnStr = new ConnectionString();

        Geral objGeral = new Geral();

        public bllTelecom()
        {
            strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);
        }




        public DataSet PAN_LISTDIALINGRULES(dtoUsers getValuesUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_LISTDIALINGRULES");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                objGeral.logSQL(getValuesUsers.User, "PAN_LISTDIALINGRULES", strSql.ToString());
                return dsQuery;
            }
            catch (Exception ex)
            {
                objGeral.logSQL(getValuesUsers.User, "PAN_LISTDIALINGRULES", strSql.ToString());
                throw new Exception("Error bllTelecom.PAN_LISTDIALINGRULES >>> System Error: " + ex.Message);
            }
        }





        public List<dtoTelecomTrunkGroup> PAN_LISTTRUNKGROUP(dtoUsers getValuesUsers)
        {
            try
            {
                List<dtoTelecomTrunkGroup> listObjAux = new List<dtoTelecomTrunkGroup>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_LISTTRUNKGROUP");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoTelecomTrunkGroup objAux = new dtoTelecomTrunkGroup();
                    objAux.Numero = Convert.ToInt64(drQuery["NUMERO"].ToString());
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "PAN_LISTTRUNKGROUP", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                objGeral.logSQL(getValuesUsers.User, "PAN_LISTTRUNKGROUP", strSql.ToString());
                throw new Exception("Error bllImportExport.PAN_LISTTRUNKGROUP >>> System Error: " + ex.Message);
            }
        }

        public List<dtoTelecomPhoneType> PAN_LISTPHONETYPE(dtoUsers getValuesUsers)
        {
            try
            {
                List<dtoTelecomPhoneType> listObjAux = new List<dtoTelecomPhoneType>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_LISTPHONETYPE");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoTelecomPhoneType objAux = new dtoTelecomPhoneType();
                    objAux.IDPhoneType = Convert.ToInt64(drQuery["IDPhoneType"].ToString());
                    objAux.IDType = Convert.ToInt64(drQuery["IDType"].ToString());
                    objAux.DescriptionType = drQuery["DescriptionType"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "PAN_LISTPHONETYPE", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                objGeral.logSQL(getValuesUsers.User, "PAN_LISTPHONETYPE", strSql.ToString());
                throw new Exception("Error bllImportExport.PAN_LISTPHONETYPE >>> System Error: " + ex.Message);
            }
        }

        public List<dtoTelecomPhoneClassification> PAN_LISTPHONECLASSIFICATION(dtoUsers getValuesUsers)
        {
            try
            {
                List<dtoTelecomPhoneClassification> listObjAux = new List<dtoTelecomPhoneClassification>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_LISTPHONECLASSIFICATION");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoTelecomPhoneClassification objAux = new dtoTelecomPhoneClassification();
                    objAux.IDPhoneClassification = Convert.ToInt64(drQuery["IDPhoneClassification"].ToString());
                    objAux.IDClassification = Convert.ToInt64(drQuery["IDClassification"].ToString());
                    objAux.DescriptionClassification = drQuery["DescriptionClassification"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                objGeral.logSQL(getValuesUsers.User, "PAN_LISTPHONECLASSIFICATION", strSql.ToString());
                return listObjAux;
            }
            catch (Exception ex)
            {
                objGeral.logSQL(getValuesUsers.User, "PAN_LISTPHONECLASSIFICATION", strSql.ToString());
                throw new Exception("Error bllImportExport.PAN_LISTPHONECLASSIFICATION >>> System Error: " + ex.Message);
            }
        }



        public dtoResponse PAN_MANAGERDIALINGRULES(dtoTelecomDialingRules getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_MANAGERDIALINGRULES");

                cmdComando.Parameters.Add(new SqlParameter("@Task", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@ID", getValues.Id));
                cmdComando.Parameters.Add(new SqlParameter("@IDRULE", getValues.IdRule));
                cmdComando.Parameters.Add(new SqlParameter("@TRUNKGROUP", getValues.TrunkGroup));
                cmdComando.Parameters.Add(new SqlParameter("@PHONETYPE", getValues.PhoneType));
                cmdComando.Parameters.Add(new SqlParameter("@PHONECLASSIFICATION", getValues.PhoneClassification));
                cmdComando.Parameters.Add(new SqlParameter("@PRIORITY", getValues.Priority));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    objResponse.Result = drQuery["RESULT"].ToString();
                    objResponse.ResultCode = Convert.ToInt32(drQuery["RESULTCODE"].ToString());
                }
                drQuery.Close();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllTelecom.PAN_MANAGERDIALINGRULES >>> System Error: " + ex.Message);
            }
        }
        //CRUD RULENAMES
        public dtoResponse MANAGERRULES(dtoTelecomRules getValues)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PAN_MANAGERRULES");

                cmdComando.Parameters.Add(new SqlParameter("@Task", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@IDRULE", getValues.IdRule));
                cmdComando.Parameters.Add(new SqlParameter("@NAME", getValues.DsRule));

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

                throw new Exception("Error bllTelecom.PAN_MANAGERRULES >>> System Error: " + e.Message);
            }
        }


        public DataSet listRules()
        {
            // create a list of the objects

            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDRULE, NAME     ");
                strSql.Append("   FROM DIALINGRULESNAME ");

                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.UniqueDatabase);

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
