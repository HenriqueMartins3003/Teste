using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using _webPainelVerisys.DTO;
using clsDatabaseSQL;

namespace _webPainelVerisys.BLL
{
    public class bllFrontEnd
    {
        // Construtores
        StringBuilder strSql = new StringBuilder();
        SqlCommand cmdComando = new SqlCommand();
        dbSQL objBanco = new dbSQL();
        ConnectionString objConnStr = new ConnectionString();
        Geral objGeral = new Geral();

        public List<dtoProduto> listProdutoAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                List<dtoProduto> AuxList = new List<dtoProduto>();

                dtoProduto objAux = new dtoProduto();
                objAux.IDProduto = 0;
                objAux.DescricaoProduto = "Selecione o Produto...";
                AuxList.Add(objAux);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDPRODUTO, DESCRICAOPRODUTO  ");
                strSql.Append("   FROM FE_PRODUTO WITH(NOLOCK)      ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoProduto objAux2 = new dtoProduto();
                    objAux2.IDProduto = Convert.ToInt64(drQuery["IDPRODUTO"].ToString());
                    objAux2.DescricaoProduto = drQuery["DESCRICAOPRODUTO"].ToString();

                    AuxList.Add(objAux2);
                }
                drQuery.Close();

                return AuxList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ProdutoAffinity >>> System Error: " + ex.Message);
            }
        }

        public List<dtoTipoPlano> listTipoPlanoAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                List<dtoTipoPlano> AuxList = new List<dtoTipoPlano>();
                
                dtoTipoPlano objAux = new dtoTipoPlano();
                objAux.IDTipoPlano = 0;
                objAux.TipoPlano = "Selecione o Tipo de Plano...";
                AuxList.Add(objAux);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDTIPOPLANO, TIPOPLANO       ");
                strSql.Append("   FROM FE_PLANOSTIPO WITH(NOLOCK)   ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoTipoPlano objAux2 = new dtoTipoPlano();
                    objAux2.IDTipoPlano = Convert.ToInt64(drQuery["IDTIPOPLANO"].ToString());
                    objAux2.TipoPlano = drQuery["TIPOPLANO"].ToString();

                    AuxList.Add(objAux2);
                }
                drQuery.Close();

                return AuxList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list TipoPlanoAffinity >>> System Error: " + ex.Message);
            }
        }

        public List<dtoTipoMeioCobranca> listTipoMeioCobrancaAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);
                List<dtoTipoMeioCobranca> AuxList = new List<dtoTipoMeioCobranca>();

                dtoTipoMeioCobranca objAux = new dtoTipoMeioCobranca();
                objAux.IDTipoMeioCobranca = 0;
                objAux.TipoMeioCobranca = "Selecione o Tipo de Meio de Cobranca...";
                AuxList.Add(objAux);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDTIPOMEIOCOBRANCA, DESCRICAOTIPOMEIOCOBRANCA    ");
                strSql.Append("   FROM [dbo].[FE_TIPOMEIOCOBRANCA] WITH(NOLOCK)         ");
                strSql.Append("  WHERE FLAG_ATIVO = 1                                   ");

                SqlDataReader drQuery = objBanco.RetornaDataReader(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                while (drQuery.Read())
                {
                    dtoTipoMeioCobranca objAux2 = new dtoTipoMeioCobranca();
                    objAux2.IDTipoMeioCobranca = Convert.ToInt64(drQuery["IDTIPOMEIOCOBRANCA"].ToString());
                    objAux2.TipoMeioCobranca = drQuery["DESCRICAOTIPOMEIOCOBRANCA"].ToString();

                    AuxList.Add(objAux2);
                }
                drQuery.Close();

                return AuxList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list TipoMeioCobrancaAffinity >>> System Error: " + ex.Message);
            }
        }

        public DataSet dslistAuditor(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDAUDITOR,                       ");
                strSql.Append("        CODIGO,                          ");
                strSql.Append("        NOME,                            ");
                strSql.Append("        SENHA,                           ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 1         ");
                strSql.Append("             THEN 'Sim'                  ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO   ");
                strSql.Append("   FROM [dbo].[FE_AUDITOR] WITH(NOLOCK)  ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Auditor >>> System Error: " + ex.Message);
            }
        }
        
        public DataSet dslistTipoPlanoAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDTIPOPLANO,                         ");
                strSql.Append("        TIPOPLANO,                           ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 1             ");
                strSql.Append("             THEN 'Sim'                      ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO       ");
                strSql.Append("   FROM [dbo].[FE_PLANOSTIPO] WITH(NOLOCK)   ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list TipoPlano >>> System Error: " + ex.Message);
            }
        }

        public DataSet dslistPlanosAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT PLA.IDPLANO,                                                                                                         ");
                strSql.Append("        PLA.IDPRODUTO,                                                                                                       ");
                strSql.Append("        PRO.DESCRICAOPRODUTO,                                                                                                ");
                strSql.Append("        PLA.CODIGOPLANO,                                                                                                     ");
                strSql.Append("                                                                                                                             ");
                strSql.Append("        PLA.IMPORTANCIASEGURADA XIMPORTANCIASEGURADA,                                                                        ");
                strSql.Append("        CASE PLA.IMPORTANCIASEGURADA WHEN 0 THEN '0' ELSE                                                                    ");
                strSql.Append("        'R$ ' +                                                                                                              ");
                strSql.Append("        SUBSTRING(CAST(PLA.IMPORTANCIASEGURADA AS VARCHAR), 1, LEN(PLA.IMPORTANCIASEGURADA) - 2) + ',' +                     ");
                strSql.Append("        SUBSTRING(CAST(PLA.IMPORTANCIASEGURADA AS VARCHAR), LEN(PLA.IMPORTANCIASEGURADA) - 2, 2) END IMPORTANCIASEGURADA,    ");
                strSql.Append("                                                                                                                             ");
                strSql.Append("        PLA.TITULAR XTITULAR,                                                                                                ");
                strSql.Append("        CASE PLA.TITULAR WHEN 0 THEN '0' ELSE                                                                                ");
                strSql.Append("        'R$ ' +                                                                                                              ");
                strSql.Append("        SUBSTRING(CAST(PLA.TITULAR AS VARCHAR), 1, LEN(PLA.TITULAR) - 2) + ',' +                                             ");
                strSql.Append("        SUBSTRING(CAST(PLA.TITULAR AS VARCHAR), LEN(PLA.TITULAR) - 2, 2) END TITULAR,                                        ");
                strSql.Append("                                                                                                                             ");
                strSql.Append("        PLA.CONJUGE XCONJUGE,                                                                                                ");
                strSql.Append("        CASE PLA.CONJUGE WHEN 0 THEN '0' ELSE                                                                                ");
                strSql.Append("        'R$ ' +                                                                                                              ");
                strSql.Append("        SUBSTRING(CAST(PLA.CONJUGE AS VARCHAR), 1, LEN(PLA.CONJUGE) - 2) + ',' +                                             ");
                strSql.Append("        SUBSTRING(CAST(PLA.CONJUGE AS VARCHAR), LEN(PLA.CONJUGE) - 2, 2) END CONJUGE,                                        ");
                strSql.Append("                                                                                                                             ");
                strSql.Append("        PLA.FILHO XFILHO,                                                                                                    ");
                strSql.Append("        'R$ ' +                                                                                                              ");
                strSql.Append("        CASE PLA.FILHO WHEN 0 THEN '0' ELSE                                                                                  ");
                strSql.Append("        SUBSTRING(CAST(PLA.FILHO AS VARCHAR), 1, LEN(PLA.FILHO) - 2) + ',' +                                                 ");
                strSql.Append("        SUBSTRING(CAST(PLA.FILHO AS VARCHAR), LEN(PLA.FILHO) - 2, 2) END FILHO,                                              ");
                strSql.Append("                                                                                                                             ");
                strSql.Append("        PLA.IDADEMIN,                                                                                                        ");
                strSql.Append("        PLA.IDADEMAX,                                                                                                        ");
                strSql.Append("        PLA.TIPOPLANO IDTIPOPLANO,                                                                                           ");
                strSql.Append("        TPL.TIPOPLANO,                                                                                                       ");
                strSql.Append("        CASE WHEN PLA.FLAG_ATIVO = 1                                                                                         ");
                strSql.Append("             THEN 'Sim'                                                                                                      ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO                                                                                       ");
                strSql.Append("   FROM [dbo].[FE_PLANOS] PLA WITH(NOLOCK)                                                                                   ");
                strSql.Append("        INNER JOIN [dbo].[FE_PRODUTO] PRO WITH(NOLOCK) ON PLA.IDPRODUTO = PRO.IDPRODUTO                                      ");
                strSql.Append("        INNER JOIN [dbo].[FE_PLANOSTIPO] TPL WITH(NOLOCK) ON PLA.TIPOPLANO = TPL.IDTIPOPLANO                                 ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list PlanosAffinity >>> System Error: " + ex.Message);
            }
        }

        public DataSet dslistProdutoAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDPRODUTO,                       ");
                strSql.Append("        DESCRICAOPRODUTO,                ");
                strSql.Append("        CAMPANHAMAILING,                 ");
                strSql.Append("        IDCAMPANHA,                      ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 1         ");
                strSql.Append("             THEN 'Sim'                  ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO   ");
                strSql.Append("   FROM FE_PRODUTO WITH(NOLOCK)          ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ProdutoAffinity >>> System Error: " + ex.Message);
            }
        }
        
        public DataSet dslistMeioCobrancaAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT MCO.IDMEIOCOBRANCA,                                                                                          ");
                strSql.Append("        MCO.CLIENTE,                                                                                                 ");
                strSql.Append("        MCO.NMEIOCOBRANCA,                                                                                           ");
                strSql.Append("        MCO.NADMCOBRANCA,                                                                                            ");
                strSql.Append("        MCO.NCICLOADMCOBRANCA,                                                                                       ");
                strSql.Append("        MCO.IDTIPOMEIOCOBRANCA,                                                                                      ");
                strSql.Append("        TME.DESCRICAOTIPOMEIOCOBRANCA,                                                                               ");
                strSql.Append("        MCO.IDPRODUTO,                                                                                               ");
                strSql.Append("        PRO.DESCRICAOPRODUTO,                                                                                        ");
                strSql.Append("        CASE WHEN MCO.FLAG_ATIVO = 1                                                                                 ");
                strSql.Append("             THEN 'Sim'                                                                                              ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO                                                                               ");
                strSql.Append("   FROM [dbo].[FE_MEIOCOBRANCA] MCO WITH(NOLOCK)                                                                     ");
                strSql.Append("        INNER JOIN [dbo].[FE_PRODUTO] PRO WITH(NOLOCK) ON MCO.IDPRODUTO = PRO.IDPRODUTO                              ");
                strSql.Append("        INNER JOIN [dbo].[FE_TIPOMEIOCOBRANCA] TME WITH(NOLOCK) ON MCO.IDTIPOMEIOCOBRANCA = TME.IDTIPOMEIOCOBRANCA   ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ProdutoAffinity >>> System Error: " + ex.Message);
            }
        }

        public DataSet dslistTipoMeioCobrancaAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT IDTIPOMEIOCOBRANCA,                      ");
                strSql.Append("        DESCRICAOTIPOMEIOCOBRANCA,               ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 1                 ");
                strSql.Append("             THEN 'Sim'                          ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO           ");
                strSql.Append("   FROM [dbo].[FE_TIPOMEIOCOBRANCA] WITH(NOLOCK) ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list TipoMeioCobrancaAffinity >>> System Error: " + ex.Message);
            }
        }

        public DataSet dslistTipoCartaoAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT CODIGO,                              ");
                strSql.Append("        TIPOCARTAO,                          ");
                strSql.Append("        CASE WHEN FLAG_ATIVO = 1             ");
                strSql.Append("             THEN 'Sim'                      ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO       ");
                strSql.Append("   FROM [dbo].[FE_TIPOCARTAO] WITH(NOLOCK)   ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list TipoCartaoAffinity >>> System Error: " + ex.Message);
            }
        }

        public DataSet dslistParcelamentoAffinity(String IDCampanha)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, IDCampanha);

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);
                strSql.Append(" SELECT PAR.CODIGO,                                                                      ");
                strSql.Append("        PAR.TIPOPARCELAMENTO,                                                            ");
                strSql.Append("        PAR.IDPRODUTO,                                                                   ");
                strSql.Append("        PRO.DESCRICAOPRODUTO,                                                            ");
                strSql.Append("        CASE WHEN PAR.FLAG_ATIVO = 1                                                     ");
                strSql.Append("             THEN 'Sim'                                                                  ");
                strSql.Append("             ELSE 'Não' END FLAG_ATIVO                                                   ");
                strSql.Append("   FROM [dbo].[FE_PARCELAMENTO] PAR WITH(NOLOCK)                                         ");
                strSql.Append("        INNER JOIN [dbo].[FE_PRODUTO] PRO WITH(NOLOCK) ON PAR.IDPRODUTO = PRO.IDPRODUTO  ");

                DataSet dsQuery = objBanco.RetornaDataSet(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                return dsQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list ParcelamentoAffinity >>> System Error: " + ex.Message);
            }
        }

        public Int64 ManagerAuditor(dtoAuditor objdtoAuditor, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoAuditor.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoAuditor.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_AUDITOR] ( CODIGO, NOME, SENHA, FLAG_ATIVO )      ");
                            strSql.Append("                         VALUES ( @Codigo, @Nome, @Senha, @FlagAtivo )   ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoAuditor.Codigo));
                            cmdComando.Parameters.Add(new SqlParameter("@Nome", objdtoAuditor.Nome));
                            cmdComando.Parameters.Add(new SqlParameter("@Senha", objdtoAuditor.Senha));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoAuditor.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_AUDITOR]       ");
                            strSql.Append("    SET CODIGO = @Codigo,        ");
                            strSql.Append("        NOME = @Nome,            ");
                            strSql.Append("        SENHA = @Senha,          ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo  ");
                            strSql.Append("  WHERE IDAUDITOR = @idAuditor   ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoAuditor.Codigo));
                            cmdComando.Parameters.Add(new SqlParameter("@Nome", objdtoAuditor.Nome));
                            cmdComando.Parameters.Add(new SqlParameter("@Senha", objdtoAuditor.Senha));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoAuditor.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idAuditor", objdtoAuditor.IDAuditor));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                          ");
                            strSql.Append("   FROM [dbo].[FE_AUDITOR]       ");  
                            strSql.Append("  WHERE IDAUDITOR = @idAuditor   ");

                            cmdComando.Parameters.Add(new SqlParameter("@idAuditor", objdtoAuditor.IDAuditor));
                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "AUDITOR", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "AUDITOR", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerTipoPlanoAffinity(dtoTipoPlano objdtoTipoPlano, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoTipoPlano.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoTipoPlano.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_PLANOSTIPO] ( TIPOPLANO, FLAG_ATIVO )     ");
                            strSql.Append("                            VALUES ( @TipoPlano, @FlagAtivo )    ");

                            cmdComando.Parameters.Add(new SqlParameter("@TipoPlano", objdtoTipoPlano.TipoPlano));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoTipoPlano.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_PLANOSTIPO]        ");
                            strSql.Append("    SET TIPOPLANO = @TipoPlano,      ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo      ");
                            strSql.Append("  WHERE IDTIPOPLANO =  @idTipoPlano  ");

                            cmdComando.Parameters.Add(new SqlParameter("@TipoPlano", objdtoTipoPlano.TipoPlano));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoTipoPlano.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idTipoPlano", objdtoTipoPlano.IDTipoPlano));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                              ");
                            strSql.Append("   FROM [dbo].[FE_PLANOSTIPO]        ");
                            strSql.Append("  WHERE IDTIPOPLANO =  @idTipoPlano  ");

                            cmdComando.Parameters.Add(new SqlParameter("@idTipoPlano", objdtoTipoPlano.IDTipoPlano));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "TIPOPLANOAFFINITY", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "TIPOPLANOAFFINITY", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerPlanoAffinity(dtoPlano objdtoPlano, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoPlano.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoPlano.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_PLANOS] ( IDPRODUTO, CODIGOPLANO, IMPORTANCIASEGURADA, TITULAR, CONJUGE,  ");
                            strSql.Append("                                 FILHO, IDADEMIN, IDADEMAX, TIPOPLANO, FLAG_ATIVO )              ");
                            strSql.Append("                        VALUES ( @idProduto, @codPlano, @impSegurada, @titular, @conjuge,        ");
                            strSql.Append("                                 @filho, @idadeMin, @idadeMax, @TipoPlano, @FlagAtivo )          ");

                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoPlano.IDProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@codPlano", objdtoPlano.CodigoPlano));
                            cmdComando.Parameters.Add(new SqlParameter("@impSegurada", objdtoPlano.ImportanciaSegurada));
                            cmdComando.Parameters.Add(new SqlParameter("@titular", objdtoPlano.Titular));
                            cmdComando.Parameters.Add(new SqlParameter("@conjuge", objdtoPlano.Conjuge));
                            cmdComando.Parameters.Add(new SqlParameter("@filho", objdtoPlano.Filho));
                            cmdComando.Parameters.Add(new SqlParameter("@idadeMin", objdtoPlano.IdadeMin));
                            cmdComando.Parameters.Add(new SqlParameter("@idadeMax", objdtoPlano.IdadeMax));
                            cmdComando.Parameters.Add(new SqlParameter("@TipoPlano", objdtoPlano.TipoPlano));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoPlano.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_PLANOS]                        ");
                            strSql.Append("    SET IDPRODUTO = @idProduto ,                 ");
                            strSql.Append("        CODIGOPLANO = @codPlano ,                ");
                            strSql.Append("        IMPORTANCIASEGURADA = @impSegurada ,     ");
                            strSql.Append("        TITULAR = @titular ,                     ");
                            strSql.Append("        CONJUGE = @conjuge ,                     ");
                            strSql.Append("        FILHO = @filho ,                         ");
                            strSql.Append("        IDADEMIN = @idadeMin ,                   ");
                            strSql.Append("        IDADEMAX = @idadeMax ,                   ");
                            strSql.Append("        TIPOPLANO = @TipoPlano ,                 ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo                  ");
                            strSql.Append("  WHERE IDPLANO = @idPlano                       ");

                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoPlano.IDProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@codPlano", objdtoPlano.CodigoPlano));
                            cmdComando.Parameters.Add(new SqlParameter("@impSegurada", objdtoPlano.ImportanciaSegurada));
                            cmdComando.Parameters.Add(new SqlParameter("@titular", objdtoPlano.Titular));
                            cmdComando.Parameters.Add(new SqlParameter("@conjuge", objdtoPlano.Conjuge));
                            cmdComando.Parameters.Add(new SqlParameter("@filho", objdtoPlano.Filho));
                            cmdComando.Parameters.Add(new SqlParameter("@idadeMin", objdtoPlano.IdadeMin));
                            cmdComando.Parameters.Add(new SqlParameter("@idadeMax", objdtoPlano.IdadeMax));
                            cmdComando.Parameters.Add(new SqlParameter("@TipoPlano", objdtoPlano.TipoPlano));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoPlano.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idPlano", objdtoPlano.IDPlano));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                      ");
                            strSql.Append("   FROM [dbo].[FE_PLANOS]    ");
                            strSql.Append("  WHERE IDPLANO = @idPlano   ");

                            cmdComando.Parameters.Add(new SqlParameter("@idPlano", objdtoPlano.IDPlano));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "TIPOPLANOAFFINITY", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "TIPOPLANOAFFINITY", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerProdutoAffinity(dtoProduto objdtoProduto, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoProduto.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoProduto.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_PRODUTO] ( DESCRICAOPRODUTO, CAMPANHAMAILING, IDCAMPANHA, FLAG_ATIVO )    ");
                            strSql.Append("                         VALUES ( @Produto, @CampMailing, @idCampanha, @FlagAtivo)  ");

                            cmdComando.Parameters.Add(new SqlParameter("@Produto", objdtoProduto.DescricaoProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@CampMailing", objdtoProduto.CampanhaMailing));
                            cmdComando.Parameters.Add(new SqlParameter("@idCampanha", objdtoProduto.IDCampanha));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoProduto.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_PRODUTO]               ");
                            strSql.Append("    SET DESCRICAOPRODUTO = @Produto,     ");
                            strSql.Append("        CAMPANHAMAILING = @CampMailing,  ");
                            strSql.Append("        IDCAMPANHA = @idCampanha,        ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo          ");
                            strSql.Append("  WHERE IDPRODUTO = @idProduto           ");

                            cmdComando.Parameters.Add(new SqlParameter("@Produto", objdtoProduto.DescricaoProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@CampMailing", objdtoProduto.CampanhaMailing));
                            cmdComando.Parameters.Add(new SqlParameter("@idCampanha", objdtoProduto.IDCampanha));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoProduto.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoProduto.IDProduto));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                          ");
                            strSql.Append("   FROM [dbo].[FE_PRODUTO]       ");
                            strSql.Append("  WHERE IDPRODUTO = @idProduto   ");

                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoProduto.IDProduto));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "MANAGERPRODUTOAFFINITY", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "MANAGERPRODUTOAFFINITY", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerMeioCobrancaAffinity(dtoMeioCobranca objdtoMeioCobranca, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoMeioCobranca.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoMeioCobranca.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_MEIOCOBRANCA] ( CLIENTE, NMEIOCOBRANCA, NADMCOBRANCA, NCICLOCOBRANCA,     ");
                            strSql.Append("                                       IDTIPOMEIOCOBRANCA, IDPRODUTO, FLAG_ATIVO )               ");
                            strSql.Append("                              VALUES ( @Cliente, @nMeioCobranca, @nAdmCobranca, @nCicloCobranca, ");
                            strSql.Append("                                       @idTipoMeioCobranca, @idProduto, @FlagAtivo )             ");

                            cmdComando.Parameters.Add(new SqlParameter("@Cliente", objdtoMeioCobranca.Cliente));
                            cmdComando.Parameters.Add(new SqlParameter("@nMeioCobranca", objdtoMeioCobranca.NMeioCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@nAdmCobranca", objdtoMeioCobranca.NAdmCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@nCicloCobranca", objdtoMeioCobranca.NCicloAdmCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@idTipoMeioCobranca", objdtoMeioCobranca.IDTipoMeioCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoMeioCobranca.IDProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoMeioCobranca.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_MEIOCOBRANCA]                      ");
                            strSql.Append("    SET CLIENTE = @Cliente,                          ");
                            strSql.Append("        NMEIOCOBRANCA = @nMeioCobranca,              ");
                            strSql.Append("        NADMCOBRANCA = @nAdmCobranca,                ");
                            strSql.Append("        NCICLOCOBRANCA = @nCicloCobranca,            ");
                            strSql.Append("        IDTIPOMEIOCOBRANCA = @idTipoMeioCobranca,    ");
                            strSql.Append("        IDPRODUTO = @idProduto,                      ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo                      ");
                            strSql.Append("  WHERE IDMEIOCOBRANCA = @idMeioCobranca             ");

                            cmdComando.Parameters.Add(new SqlParameter("@Cliente", objdtoMeioCobranca.Cliente));
                            cmdComando.Parameters.Add(new SqlParameter("@nMeioCobranca", objdtoMeioCobranca.NMeioCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@nAdmCobranca", objdtoMeioCobranca.NAdmCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@nCicloCobranca", objdtoMeioCobranca.NCicloAdmCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@idTipoMeioCobranca", objdtoMeioCobranca.IDTipoMeioCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoMeioCobranca.IDProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoMeioCobranca.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idMeioCobranca", objdtoMeioCobranca.IDMeioCobranca));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                                  ");
                            strSql.Append("   FROM [dbo].[FE_MEIOCOBRANCA]          ");
                            strSql.Append("  WHERE IDMEIOCOBRANCA = @idMeioCobranca ");

                            cmdComando.Parameters.Add(new SqlParameter("@idMeioCobranca", objdtoMeioCobranca.IDMeioCobranca));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "MANAGERMEIOCOBRANCAAFFINITY", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "MANAGERMEIOCOBRANCAAFFINITY", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerTipoMeioCobrancaAffinity(dtoTipoMeioCobranca objdtoTipoMeioCobranca, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoTipoMeioCobranca.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoTipoMeioCobranca.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_TIPOMEIOCOBRANCA] ( DESCRICAOTIPOMEIOCOBRANCA, FLAG_ATIVO )   ");
                            strSql.Append("                                  VALUES ( @TipoMeioCobranca, @FlagAtivo )          ");

                            cmdComando.Parameters.Add(new SqlParameter("@TipoMeioCobranca", objdtoTipoMeioCobranca.TipoMeioCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoTipoMeioCobranca.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_TIPOMEIOCOBRANCA]                      ");
                            strSql.Append("    SET DESCRICAOTIPOMEIOCOBRANCA = @TipoMeioCobranca,   ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo                          ");
                            strSql.Append("  WHERE IDTIPOMEIOCOBRANCA = @idTipoMeioCobranca         ");

                            cmdComando.Parameters.Add(new SqlParameter("@TipoMeioCobranca", objdtoTipoMeioCobranca.TipoMeioCobranca));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoTipoMeioCobranca.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@idTipoMeioCobranca", objdtoTipoMeioCobranca.IDTipoMeioCobranca));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                                          ");
                            strSql.Append("   FROM [dbo].[FE_TIPOMEIOCOBRANCA]              ");
                            strSql.Append("  WHERE IDTIPOMEIOCOBRANCA = @idTipoMeioCobranca ");

                            cmdComando.Parameters.Add(new SqlParameter("@idTipoMeioCobranca", objdtoTipoMeioCobranca.IDTipoMeioCobranca));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "MANAGERTIPOMEIOCOBRANCAAFFINITY", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "MANAGERTIPOMEIOCOBRANCAAFFINITY", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerTipoCartaoAffinity(dtoTipoCartao objdtoTipoCartao, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoTipoCartao.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoTipoCartao.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_TIPOCARTAO] ( CODIGO, TIPOCARTAO, FLAG_ATIVO )   ");
                            strSql.Append("                            VALUES ( @Codigo, @TipoCartao, @FlagAtivo ) ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoTipoCartao.Codigo));
                            cmdComando.Parameters.Add(new SqlParameter("@TipoCartao", objdtoTipoCartao.TipoCartao));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoTipoCartao.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_TIPOCARTAO]        ");
                            strSql.Append("    SET CODIGO = @Codigo,            ");
                            strSql.Append("        TIPOCARTAO = @TipoCartao,    ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo      ");
                            strSql.Append("  WHERE CODIGO = @Codigo2            ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoTipoCartao.Codigo));
                            cmdComando.Parameters.Add(new SqlParameter("@TipoCartao", objdtoTipoCartao.TipoCartao));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoTipoCartao.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@Codigo2", objdtoTipoCartao.Codigo));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                          ");
                            strSql.Append("   FROM [dbo].[FE_TIPOCARTAO]    ");
                            strSql.Append("  WHERE CODIGO = @Codigo         ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoTipoCartao.Codigo));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "MANAGERTIPOMEIOCOBRANCAAFFINITY", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "MANAGERTIPOMEIOCOBRANCAAFFINITY", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }

        public Int64 ManagerParcelamentoAffinity(dtoParcelamento objdtoParcelamento, dtoUsers objdtoUsers)
        {
            try
            {
                String strConn = objConnStr.BuscaDatabase(ConnectionString.Database.MailingAppDatabase, objdtoParcelamento.IDCampanha);
                Int64 intResultado = 0;

                cmdComando.Parameters.Clear();
                strSql.Remove(0, strSql.Length);

                switch (objdtoParcelamento.Task)
                {
                    case 1:
                        {
                            strSql.Append(" INSERT INTO [dbo].[FE_PARCELAMENTO] ( CODIGO, TIPOPARCELAMENTO, IDPRODUTO, FLAG_ATIVO )     ");
                            strSql.Append("                              VALUES ( @Codigo, @TipoParcelamento, @idProduto, @FlagAtivo )  ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoParcelamento.Codigo));
                            cmdComando.Parameters.Add(new SqlParameter("@TipoParcelamento", objdtoParcelamento.TipoParcelamento));
                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoParcelamento.IDProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoParcelamento.Flag_Ativo));

                            intResultado = objBanco.ExecutaComandoRetorno(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                        }
                        break;
                    case 2:
                        {
                            strSql.Append(" UPDATE [dbo].[FE_PARCELAMENTO]                  ");
                            strSql.Append("    SET CODIGO = @Codigo,                        ");
                            strSql.Append("        TIPOPARCELAMENTO = @TipoParcelamento,    ");
                            strSql.Append("        IDPRODUTO = @idProduto,                  ");
                            strSql.Append("        FLAG_ATIVO = @FlagAtivo                  ");
                            strSql.Append("  WHERE CODIGO = @Codigo2                        ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoParcelamento.Codigo));
                            cmdComando.Parameters.Add(new SqlParameter("@TipoParcelamento", objdtoParcelamento.TipoParcelamento));
                            cmdComando.Parameters.Add(new SqlParameter("@idProduto", objdtoParcelamento.IDProduto));
                            cmdComando.Parameters.Add(new SqlParameter("@FlagAtivo", objdtoParcelamento.Flag_Ativo));
                            cmdComando.Parameters.Add(new SqlParameter("@Codigo2", objdtoParcelamento.Codigo));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    case 3:
                        {
                            strSql.Append(" DELETE                          ");
                            strSql.Append("   FROM [dbo].[FE_PARCELAMENTO]    ");
                            strSql.Append("  WHERE CODIGO = @Codigo         ");

                            cmdComando.Parameters.Add(new SqlParameter("@Codigo", objdtoParcelamento.Codigo));

                            objBanco.ExecutaComando(strSql.ToString(), cmdComando, CommandType.Text, strConn);
                            intResultado = 1;
                        }
                        break;
                    default:
                        {
                            intResultado = 0;
                        }
                        break;
                }

                objGeral.logSQL(objdtoUsers.User, "MANAGERPARCELAMENTOAFFINITY", strSql.ToString());
                return intResultado;
            }
            catch (Exception e)
            {
                objGeral.logSQL(objdtoUsers.User, "MANAGERPARCELAMENTOAFFINITY", strSql.ToString() + " >>> erro: " + e.Message);
                return 0;
            }
        }
    }
}
