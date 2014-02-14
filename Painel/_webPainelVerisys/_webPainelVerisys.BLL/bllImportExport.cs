using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class bllImportExport
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();
        String strConn = "";



        public bllImportExport()
        {
            strConn = objConnStr.BuscaDatabase(ConnectionString.Database.ImportExportDatabase);
        }



        #region List

        public List<dtoImportExport_ColumnType> UINT_LISTCOLUMNTYPE(Int64 ProcessoID)
        {
            try
            {
                List<dtoImportExport_ColumnType> listObjAux = new List<dtoImportExport_ColumnType>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTCOLUMNTYPE");

                cmdComando.Parameters.Add(new SqlParameter("@COLUMNTYPEID", null));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", ProcessoID));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_ColumnType objAux = new dtoImportExport_ColumnType();
                    objAux.ColumnTypeID = Convert.ToInt64(drQuery["ColumnTypeID"].ToString());
                    objAux.ColumnType = drQuery["ColumnType"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTCOLUMNTYPE >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_Ambient> UINT_LISTAMBIENT()
        {
            try
            {
                List<dtoImportExport_Ambient> listObjAux = new List<dtoImportExport_Ambient>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTAMBIENT");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_Ambient objAux = new dtoImportExport_Ambient();
                    objAux.AmbientID = Convert.ToInt64(drQuery["AmbientID"].ToString());
                    objAux.Ambient = drQuery["Ambient"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTAMBIENT >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_Process> UINT_LISTPROCESS()
        {
            try
            {
                List<dtoImportExport_Process> listObjAux = new List<dtoImportExport_Process>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTPROCESS");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_Process objAux = new dtoImportExport_Process();
                    objAux.ProcessID = Convert.ToInt64(drQuery["ProcessID"].ToString());
                    objAux.ProcessName = drQuery["ProcessName"].ToString();
                    objAux.ProcessDescription = drQuery["ProcessDescription"].ToString();
                    objAux.ProcessTypeID = Convert.ToInt64(drQuery["ProcessTypeID"].ToString());
                    objAux.ProcessTypeName = drQuery["ProcessTypeName"].ToString();
                    objAux.LotMask = drQuery["LotMask"].ToString();
                    objAux.LotControlbyCampaign = Convert.ToBoolean(drQuery["LotControlbyCampaign"].ToString());
                    objAux.RegistryHeaderID = Convert.ToInt64(drQuery["RegistryHeaderID"].ToString());
                    objAux.RegistryTrailerID = Convert.ToInt64(drQuery["RegistryTrailerID"].ToString());
                    objAux.RegistryID = Convert.ToInt64(drQuery["RegistryID"].ToString());
                    objAux.RulesID = Convert.ToInt64(drQuery["RulesID"].ToString());
                    objAux.ExecutionPlanID = Convert.ToInt64(drQuery["ExecutionPlanID"].ToString());
                    objAux.ProcessStatus = Convert.ToBoolean(drQuery["ProcessStatus"].ToString());
                    objAux.ProcessStatusDescription = drQuery["ProcessStatusDescription"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTPROCESS >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_ProcessType> UINT_LISTPROCESSTYPE()
        {
            try
            {
                List<dtoImportExport_ProcessType> listObjAux = new List<dtoImportExport_ProcessType>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTPROCESSTYPE");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_ProcessType objAux = new dtoImportExport_ProcessType();
                    objAux.ProcessTypeID = Convert.ToInt64(drQuery["ProcessTypeID"].ToString());
                    objAux.ProcessTypeName = drQuery["ProcessTypeName"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTPROCESSTYPE >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_Segmenting> UINT_LISTSEGMENTING(String strCampanha)
        {
            try
            {
                List<dtoImportExport_Segmenting> listObjAux = new List<dtoImportExport_Segmenting>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTSEGMENTING");

                cmdComando.Parameters.Add(new SqlParameter("@CAMPANHA", strCampanha));
                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_Segmenting objAux = new dtoImportExport_Segmenting();
                    objAux.IDSegmentacao = Convert.ToInt64(drQuery["IDSegmentacao"].ToString());
                    objAux.NomeSegmentacao = drQuery["NomeSegmentacao"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTSEGMENTING >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_ExecutionPlan> UINT_LISTEXECUTIONPLAN()
        {
            try
            {
                List<dtoImportExport_ExecutionPlan> listObjAux = new List<dtoImportExport_ExecutionPlan>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTEXECUTIONPLAN");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_ExecutionPlan objAux = new dtoImportExport_ExecutionPlan();
                    objAux.ExecutionPlanID = Convert.ToInt64(drQuery["ExecutionPlanID"].ToString());
                    objAux.ExecutionPlan = drQuery["ExecutionPlan"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTEXECUTIONPLAN >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_ExecutionPlanType> UINT_LISTEXECUTIONPLANTYPE()
        {
            try
            {
                List<dtoImportExport_ExecutionPlanType> listObjAux = new List<dtoImportExport_ExecutionPlanType>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTEXECUTIONPLANTYPE");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_ExecutionPlanType objAux = new dtoImportExport_ExecutionPlanType();
                    objAux.ExecutionPlanTypeID = Convert.ToInt64(drQuery["ExecutionPlanTypeID"].ToString());
                    objAux.ExecutionPlanType = drQuery["ExecutionPlanType"].ToString();
                    objAux.ExecutionPlanTypeDescription = drQuery["ExecutionPlanTypeDescription"].ToString();
                    objAux.ExecutionPlanTypeStatus = Convert.ToBoolean(drQuery["ExecutionPlanTypeStatus"].ToString());
                    objAux.ExecutionPlanTypeStatusDescription = drQuery["ExecutionPlanTypeStatusDescription"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTEXECUTIONPLANTYPE >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_ExecutionPlanFrequency> UINT_LISTEXECUTIONPLANFREQUENCY()
        {
            try
            {
                List<dtoImportExport_ExecutionPlanFrequency> listObjAux = new List<dtoImportExport_ExecutionPlanFrequency>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTEXECUTIONPLANFREQUENCY");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_ExecutionPlanFrequency objAux = new dtoImportExport_ExecutionPlanFrequency();
                    objAux.FrequencyID = Convert.ToInt64(drQuery["FrequencyID"].ToString());
                    objAux.Frequency = drQuery["Frequency"].ToString();
                    objAux.FrequencyDescription = drQuery["FrequencyDescription"].ToString();
                    objAux.FrequencyStatus = Convert.ToBoolean(drQuery["FrequencyStatus"].ToString());
                    objAux.FrequencyStatusDescription = drQuery["FrequencyStatusDescription"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTEXECUTIONPLANFREQUENCY >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_Rules> UINT_LISTRULES()
        {
            try
            {
                List<dtoImportExport_Rules> listObjAux = new List<dtoImportExport_Rules>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTRULES");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_Rules objAux = new dtoImportExport_Rules();
                    objAux.RulesID = Convert.ToInt64(drQuery["RulesID"].ToString());
                    objAux.RulesName = drQuery["RulesName"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTRULES >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_Registry> UINT_LISTREGISTRY()
        {
            try
            {
                List<dtoImportExport_Registry> listObjAux = new List<dtoImportExport_Registry>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTREGISTRY");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_Registry objAux = new dtoImportExport_Registry();
                    objAux.RegistryID = Convert.ToInt64(drQuery["RegistryID"].ToString());
                    objAux.RegistryName = drQuery["RegistryName"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTREGISTRY >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_Header> UINT_LISTREGISTRYHEADER()
        {
            try
            {
                List<dtoImportExport_Header> listObjAux = new List<dtoImportExport_Header>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTREGISTRYHEADER");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_Header objAux = new dtoImportExport_Header();
                    objAux.HeaderID = Convert.ToInt64(drQuery["HeaderID"].ToString());
                    objAux.HeaderName = drQuery["HeaderName"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTREGISTRYHEADER >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_Trailer> UINT_LISTREGISTRYTRAILER()
        {
            try
            {
                List<dtoImportExport_Trailer> listObjAux = new List<dtoImportExport_Trailer>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTREGISTRYTRAILER");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_Trailer objAux = new dtoImportExport_Trailer();
                    objAux.TrailerID = Convert.ToInt64(drQuery["TrailerID"].ToString());
                    objAux.TrailerName = drQuery["TrailerName"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTREGISTRYTRAILER >>> System Error: " + ex.Message);
            }
        }

        public List<dtoImportExport_FilesType> UINT_LISTFILESTYPE()
        {
            try
            {
                List<dtoImportExport_FilesType> listObjAux = new List<dtoImportExport_FilesType>();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTFILESTYPE");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                while (drQuery.Read())
                {
                    dtoImportExport_FilesType objAux = new dtoImportExport_FilesType();
                    objAux.FilesTypeID = Convert.ToInt64(drQuery["FilesTypeID"].ToString());
                    objAux.FilesType = drQuery["FilesType"].ToString();
                    listObjAux.Add(objAux);
                }
                drQuery.Close();

                return listObjAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTFILESTYPE >>> System Error: " + ex.Message);
            }
        }
#endregion

        #region Dataset



        public DataSet UINT_LISTREGISTRYHEADER(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTREGISTRYHEADER");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTREGISTRYHEADER >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTREGISTRYTRAILER(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTREGISTRYTRAILER");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTREGISTRYTRAILER >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTREGISTRY(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTREGISTRY");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTREGISTRY >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTREGISTRYCOLUMN(dtoUsers getUsers, Int64 RegistroID, Int64 ProcessoID)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTREGISTRYCOLUMN");

                cmdComando.Parameters.Add(new SqlParameter("@COLUMNID", null));
                
                if (ProcessoID == 0)
                {
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYID", RegistroID));
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYHEADERID", null));
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYTRAILERID", null));
                }
                else if (ProcessoID == 1)
                {
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYID", null));
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYHEADERID", RegistroID));
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYTRAILERID", null));
                }
                else if (ProcessoID == 2)
                {
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYID", null));
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYHEADERID", null));
                    cmdComando.Parameters.Add(new SqlParameter("@REGISTRYTRAILERID", RegistroID));
                }

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTREGISTRY >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTRULES(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTRULES");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTRULES >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTRULESAFTERPROCESS(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTRULESAFTERPROCESS");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTRULESAFTERPROCESS >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTRULESBEFOREPROCESS(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTRULESBEFOREPROCESS");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTRULESBEFOREPROCESS >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTEXECUTIONPLAN(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTEXECUTIONPLAN");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTEXECUTIONPLAN >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTEXPORTQUERYS(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTEXPORTQUERYS");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTEXPORTQUERYS >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTPROCESS(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTPROCESS");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTPROCESS >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTFILES(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTFILES");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTFILES >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LISTRULESCAMPAIGN(dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LISTRULESCAMPAIGN");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LISTRULESCAMPAIGN >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LOGREGISTRY(dtoImportExport_Logs getValues, dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LOGREGISTRY");

                cmdComando.Parameters.Add(new SqlParameter("@STARTDATETIME", Convert.ToDateTime(getValues.StartDatetime)));
                cmdComando.Parameters.Add(new SqlParameter("@ENDDATETIME", Convert.ToDateTime(getValues.EndDatetime)));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LOGREGISTRY >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LOGIMPORTEXPORT(dtoImportExport_Logs getValues, dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LOGIMPORTEXPORT");

                cmdComando.Parameters.Add(new SqlParameter("@STARTDATETIME", Convert.ToDateTime(getValues.StartDatetime)));
                cmdComando.Parameters.Add(new SqlParameter("@ENDDATETIME", Convert.ToDateTime(getValues.EndDatetime)));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPAIGNID", getValues.CampaignID));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LOGIMPORTEXPORT >>> System Error: " + ex.Message);
            }
        }

        public DataSet UINT_LOGFILES(dtoImportExport_Logs getValues, dtoUsers getUsers)
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_LOGFILES");

                cmdComando.Parameters.Add(new SqlParameter("@STARTDATETIME", Convert.ToDateTime(getValues.StartDatetime)));
                cmdComando.Parameters.Add(new SqlParameter("@ENDDATETIME", Convert.ToDateTime(getValues.EndDatetime)));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));
                cmdComando.Parameters.Add(new SqlParameter("@FILENAME", getValues.FileName));

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_LOGFILES >>> System Error: " 
                                   + ex.Message + " (( Query: " + strSql.ToString() + " Parametros: "
                                   + getValues.StartDatetime + ", "
                                   + getValues.EndDatetime + ", "
                                   + getValues.ProcessID);
            }
        }


        #endregion

        #region dto


        public dtoResponse UINT_MANAGER_REGISTRYHEADER(dtoImportExport_Header getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_REGISTRYHEADER");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@HEADERID", getValues.HeaderID));
                cmdComando.Parameters.Add(new SqlParameter("@HEADERNAME", getValues.HeaderName));
                cmdComando.Parameters.Add(new SqlParameter("@HEADERSEPARATOR", getValues.HeaderSeparator));
                cmdComando.Parameters.Add(new SqlParameter("@HEADERLINESIZE", getValues.HeaderLineSize));
                cmdComando.Parameters.Add(new SqlParameter("@HEADERINITIALLINE", getValues.HeaderInitialLine));
                cmdComando.Parameters.Add(new SqlParameter("@HEADERSTATUS", getValues.HeaderStatus));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_REGISTRYHEADER >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_REGISTRYTRAILER(dtoImportExport_Trailer getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_REGISTRYTRAILER");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@TRAILERID", getValues.TrailerID));
                cmdComando.Parameters.Add(new SqlParameter("@TRAILERNAME", getValues.TrailerName));
                cmdComando.Parameters.Add(new SqlParameter("@TRAILERSEPARATOR", getValues.TrailerSeparator));
                cmdComando.Parameters.Add(new SqlParameter("@TRAILERLINESIZE", getValues.TrailerLineSize));
                cmdComando.Parameters.Add(new SqlParameter("@TRAILERSTATUS", getValues.TrailerStatus));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_REGISTRYTRAILER >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_REGISTRY(dtoImportExport_Registry getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_REGISTRY");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYID", getValues.RegistryID));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYNAME", getValues.RegistryName));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYSEPARATOR", getValues.RegistrySeparator));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYLINESIZE", getValues.RegistryLineSize));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYINITIALLINE", getValues.RegistryInitialLine));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYSTATUS", getValues.RegistryStatus));


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
                throw new Exception("Error bllImportExport.UINT_MANAGER_REGISTRY >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_REGISTRYCOLUMN(dtoImportExport_Column getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_REGISTRYCOLUMN");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNID", getValues.ColumnID));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYID", getValues.RegistryID));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYHEADERID", getValues.RegistryHeaderID));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYTRAILERID", getValues.RegistryTrailerID));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNNAME", getValues.ColumnName));
                cmdComando.Parameters.Add(new SqlParameter("@INITIALPOSITION", getValues.InitialPosition));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNSIZE", getValues.ColumnSize));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNNUMBER", getValues.ColumnNumber));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNTYPEID", getValues.ColumnTypeID));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNGROUP", getValues.ColumnGroup));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNVALIDATION", getValues.ColumnValidation));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNSTATUS", getValues.ColumnStatus));
                cmdComando.Parameters.Add(new SqlParameter("@DATABASETABLE", getValues.DatabaseTable));
                cmdComando.Parameters.Add(new SqlParameter("@DATABASECOLUMN", getValues.DatabaseColumn));
                cmdComando.Parameters.Add(new SqlParameter("@COLUMNJOIN", getValues.ColumnJoin));
                cmdComando.Parameters.Add(new SqlParameter("@TEXTALIGN", getValues.TextAlign));
                cmdComando.Parameters.Add(new SqlParameter("@TEXTCOMPLEMENT", getValues.TextComplement));
                cmdComando.Parameters.Add(new SqlParameter("@DEFAULTVALUE", getValues.DefaultValue));
                cmdComando.Parameters.Add(new SqlParameter("@DEFAULTMANDATORY", getValues.DefaultMandatory));
                cmdComando.Parameters.Add(new SqlParameter("@TABLEID", getValues.TableID));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_REGISTRYCOLUMN >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_RULES(dtoImportExport_Rules getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_RULES");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@RULESID", getValues.RulesID));
                cmdComando.Parameters.Add(new SqlParameter("@RULESNAME", getValues.RulesName));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPAIGN", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@LOTSTATUS", getValues.LotStatus));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYSTATUS", getValues.RegistryStatus));
                cmdComando.Parameters.Add(new SqlParameter("@CHECKRAW", getValues.CheckRaw));
                cmdComando.Parameters.Add(new SqlParameter("@RULESSTATUS", getValues.RulesStatus));
                cmdComando.Parameters.Add(new SqlParameter("@OLDLOTSTATUS", getValues.OldLotStatus));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_RULES >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_RULESAFTERPROCESS(dtoImportExport_RulesAfterProcess getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_RULESAFTERPROCESS");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@RULESID", getValues.RulesID));
                cmdComando.Parameters.Add(new SqlParameter("@RULESNAME", getValues.RulesName));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPAIGN", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@SEGMENTINGID", getValues.SegmentingID));
                cmdComando.Parameters.Add(new SqlParameter("@RULESSTATUS", getValues.RulesStatus));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_RULESAFTERPROCESS >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_RULESBEFOREPROCESS(dtoImportExport_RulesBeforeProcess getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_RULESBEFOREPROCESS");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@RULESID", getValues.RulesID));
                cmdComando.Parameters.Add(new SqlParameter("@RULESNAME", getValues.RulesName));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPAIGN", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@DISABLEANCIENTID", getValues.DisableAncientID));
                cmdComando.Parameters.Add(new SqlParameter("@RULESSTATUS", getValues.RulesStatus));
                cmdComando.Parameters.Add(new SqlParameter("@RELATEDCAMPAIGN", getValues.CampanhasAssociadas));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_RULESBEFOREPROCESS >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_EXECUTIONPLAN(dtoImportExport_ExecutionPlan getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_EXECUTIONPLAN");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONPLANID", getValues.ExecutionPlanID));

                if (getValues.Task != 3)
                {
                    cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONPLAN", getValues.ExecutionPlan));
                    cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONPLANDESCRIPTION", getValues.ExecutionPlanDescription));
                    cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONPLANTYPEID", getValues.ExecutionPlanTypeID));

                    if (getValues.ExecutionDateTime == Convert.ToDateTime("1900-01-01 00:00:00"))
                        cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONDATETIME", Convert.ToDateTime(getValues.StartDateTime.ToShortDateString())));
                    else
                        cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONDATETIME", getValues.ExecutionDateTime));

                    if (getValues.StartDateTime == Convert.ToDateTime("1900-01-01 00:00:00"))
                        cmdComando.Parameters.Add(new SqlParameter("@STARTDATETIME", Convert.ToDateTime(getValues.ExecutionDateTime.ToShortDateString())));
                    else
                        cmdComando.Parameters.Add(new SqlParameter("@STARTDATETIME", getValues.StartDateTime));

                    if (getValues.StartDateTime == Convert.ToDateTime("1900-01-01 00:00:00"))
                        cmdComando.Parameters.Add(new SqlParameter("@ENDDATETIME", Convert.ToDateTime(getValues.ExecutionDateTime.ToShortDateString())));
                    else
                        cmdComando.Parameters.Add(new SqlParameter("@ENDDATETIME", getValues.EndDateTime));

                    
                    cmdComando.Parameters.Add(new SqlParameter("@FREQUENCYID", getValues.FrequencyID));
                    cmdComando.Parameters.Add(new SqlParameter("@MONDAY", getValues.Monday));
                    cmdComando.Parameters.Add(new SqlParameter("@TUESDAY", getValues.Tuesday));
                    cmdComando.Parameters.Add(new SqlParameter("@WEDNESDAY", getValues.Wednesday));
                    cmdComando.Parameters.Add(new SqlParameter("@THURSDAY", getValues.Thursday));
                    cmdComando.Parameters.Add(new SqlParameter("@FRIDAY", getValues.Friday));
                    cmdComando.Parameters.Add(new SqlParameter("@SATURDAY", getValues.Saturday));
                    cmdComando.Parameters.Add(new SqlParameter("@SUNDAY", getValues.Sunday));
                    cmdComando.Parameters.Add(new SqlParameter("@FIRSTWEEK", getValues.FirstWeek));
                    cmdComando.Parameters.Add(new SqlParameter("@SECONDWEEK", getValues.SecondWeek));
                    cmdComando.Parameters.Add(new SqlParameter("@THIRDWEEK", getValues.ThirdWeek));
                    cmdComando.Parameters.Add(new SqlParameter("@FOURTHWEEK", getValues.FourthWeek));
                    cmdComando.Parameters.Add(new SqlParameter("@FREQUENCYINTERVAL", getValues.FrequencyInterval));

                    
                    cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONPLANSTATUS", getValues.ExecutionPlanStatus));
                }

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_EXECUTIONPLAN >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_EXPORTQUERY(dtoImportExport_ExportQuery getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_EXPORTQUERY");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@EXPORTQUERYID", getValues.ExportQueryID));
                cmdComando.Parameters.Add(new SqlParameter("@RULESID", getValues.RulesID));
                cmdComando.Parameters.Add(new SqlParameter("@QUERY", getValues.Query));
                cmdComando.Parameters.Add(new SqlParameter("@EXPORTQUERYSTATUS", getValues.ExportQueryStatus));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_EXPORTQUERY >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_PROCESS(dtoImportExport_Process getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_PROCESS");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSNAME", getValues.ProcessName));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSDESCRIPTION", getValues.ProcessDescription));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSTYPEID", getValues.ProcessTypeID));
                cmdComando.Parameters.Add(new SqlParameter("@LOTMASK", getValues.LotMask));
                cmdComando.Parameters.Add(new SqlParameter("@LOTCONTROLBYCAMPAIGN", getValues.LotControlbyCampaign));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYHEADERID", getValues.RegistryHeaderID));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYTRAILERID", getValues.RegistryTrailerID));
                cmdComando.Parameters.Add(new SqlParameter("@REGISTRYID", getValues.RegistryID));
                cmdComando.Parameters.Add(new SqlParameter("@RULESID", getValues.RulesID));
                cmdComando.Parameters.Add(new SqlParameter("@EXECUTIONPLANID", getValues.ExecutionPlanID));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSSTATUS", getValues.ProcessStatus));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_PROCESS >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_FILES(dtoImportExport_Files getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_FILES");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@FILEID", getValues.FileID));
                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));
                cmdComando.Parameters.Add(new SqlParameter("@FILENAME", getValues.FileName));
                cmdComando.Parameters.Add(new SqlParameter("@FILEEXTENSION", getValues.FileExtension));
                cmdComando.Parameters.Add(new SqlParameter("@FILELOCATION", getValues.FileLocation));
                cmdComando.Parameters.Add(new SqlParameter("@FILELOCATIONBACKUP", getValues.FileLocationBackup));
                cmdComando.Parameters.Add(new SqlParameter("@FILESTYPEID", getValues.FilesTypeID));
                cmdComando.Parameters.Add(new SqlParameter("@FILESTATUS", getValues.FileStatus));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_FILES >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse UINT_MANAGER_RULESCAMPAIGN(dtoImportExport_RulesCampaign getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("UINT_MANAGER_RULESCAMPAIGN");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@USER", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@IDRULESCAMPAIGN", getValues.IDRulesCampaign));
                cmdComando.Parameters.Add(new SqlParameter("@CAMPAIGN", getValues.Campaign));
                cmdComando.Parameters.Add(new SqlParameter("@TABLECOLUMN", getValues.TableColumn));
                cmdComando.Parameters.Add(new SqlParameter("@DATA", getValues.Data));

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
                throw new Exception("Error bllImportExport.UINT_MANAGER_RULESCAMPAIGN >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse SP_EXECUTIONPLAN(dtoImportExport_Process getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SP_EXECUTIONPLAN");

                cmdComando.Parameters.Add(new SqlParameter("@PROCESSID", getValues.ProcessID));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    objResponse.Result = drQuery["RESULT"].ToString();
                    objResponse.ResultCode = Convert.ToInt32(drQuery["RESULTID"].ToString());
                }
                drQuery.Close();
                return objResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Error bllImportExport.UINT_MANAGER_RULESCAMPAIGN >>> System Error: " + ex.Message);
            }
        #endregion
        }
    }
}
