using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class Modulos
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();

        public DataSet RetornaModulosMenu(dtoUsers objUser, String strApplication)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("MENU");

                cmdComando.Parameters.Add(new SqlParameter("@IDPERFIL", objUser.IdProfile));
                cmdComando.Parameters.Add(new SqlParameter("@APPLICATION", strApplication));
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Modulos Menu >>> System Error: " + ex.Message);
            }
        }

        public DataSet RetornaModulosPerfil(String strIDPerfil, String strApplication)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("PROFILES");

                cmdComando.Parameters.Add(new SqlParameter("@IDPERFIL", strIDPerfil));
                cmdComando.Parameters.Add(new SqlParameter("@APPLICATION", strApplication));
                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);

                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Modulos Perfil >>> System Error: " + ex.Message);
            }
        }
    }
}
