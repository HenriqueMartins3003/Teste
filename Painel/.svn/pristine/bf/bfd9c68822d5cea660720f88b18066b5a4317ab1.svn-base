using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
using clsVerisys.Database;

namespace _webPainelVerisys.BLL
{
    public class bllAEC
    {
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        SQLConn objBanco = new SQLConn();
        SQLConnString objConnStr = new SQLConnString();
        String SQLString = "";

        public bllAEC()
        {
            SQLString = objConnStr.BuscaConexao("Verisys_AEC", SQLConnString.AplicationType.Intranet);
        }

        public DataSet ListGetFiltros()
        {
            try
            {
                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("ListGetFiltros");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, SQLString);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ListGetFiltros >>> System Error: " + ex.Message);
            }
        }

        public dtoResponse SP_ManagerProcessamento(dtoAEC getValues, dtoUsers getUsers)
        {
            try
            {
                dtoResponse objResponse = new dtoResponse();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("SP_ManagerProcessamento");

                cmdComando.Parameters.Add(new SqlParameter("@TASK", getValues.Task));
                cmdComando.Parameters.Add(new SqlParameter("@ID", getValues.FiltroID));
                cmdComando.Parameters.Add(new SqlParameter("@Filtro", getValues.Filtro));
                cmdComando.Parameters.Add(new SqlParameter("@Usuario", getUsers.User));
                cmdComando.Parameters.Add(new SqlParameter("@IDCampanha", getValues.IDCampanha));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, SQLString);
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
                throw new Exception("Error bllAEC.SP_ManagerProcessamento >>> System Error: " + ex.Message);
            }
        }
    }
}
