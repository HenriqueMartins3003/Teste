using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class bllPageConfig
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();
        String strConn = "";

        public bllPageConfig()
        {
            strConn = objConnStr.BuscaDatabase(ConnectionString.Database.PainelDatabase);
        }

        public dtoPageConfig listPageConfig(String strModuleName, String strApplication)
        {
            try
            {
                dtoPageConfig objAux = new dtoPageConfig();

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append("pageConfig");

                cmdComando.Parameters.Add(new SqlParameter("@MODULENAME", strModuleName));
                cmdComando.Parameters.Add(new SqlParameter("@APPLICATION", strApplication));

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.StoredProcedure, strConn);
                if (drQuery.Read())
                {
                    objAux.Descricao = drQuery["DESCRICAO"].ToString();
                    objAux.Url = drQuery["URL"].ToString();
                    objAux.ModuloFilho = Convert.ToInt32(drQuery["MODULOFILHO"].ToString());
                    objAux.Flag_Menu = Convert.ToBoolean(drQuery["FLAG_MENU"].ToString());
                    objAux.Ordem = Convert.ToInt32(drQuery["ORDEM"].ToString());
                }
                drQuery.Close();

                return objAux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ProdutoAffinity >>> System Error: " + ex.Message);
            }
        }
    }
}
