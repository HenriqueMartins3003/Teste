using System;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace clsVerisys.Ldap
{
    public class Ldap
    {
        /// <summary>
        /// Autenticação do Usuario no Dominio
        /// </summary>
        /// <returns>Retorna dataset caso autenticação foi com sucesso</returns>
        public DataSet AutenticaUsuario(String strDominio, String strUsuario, String strSenha)
        {
            DataSet dsUsuario = new DataSet();

            DirectoryEntry dEntry = new DirectoryEntry("LDAP://" + strDominio, strDominio + @"\" + strUsuario, strSenha);

            try
            {
                //object objNativo = dEntry.NativeObject;

                DirectorySearcher dSearch = new DirectorySearcher(dEntry);
                SearchResult sResult = null;
                dSearch.Filter = "(SAMAccountName=" + strUsuario + ")";
                sResult = dSearch.FindOne();
                DirectoryEntry user = sResult.GetDirectoryEntry();
                String strStatus = Convert.ToString(sResult.Properties["useraccountcontrol"][0]);

                if (strStatus == "512")
                {
                    try
                    {
                        dsUsuario.Tables.Add("USUARIO");
                        dsUsuario.Tables[0].Columns.Add("CHAVE", Type.GetType("System.String"));
                        dsUsuario.Tables[0].Columns.Add("PROPRIEDADE", Type.GetType("System.String"));
                    }
                    catch
                    {
                        dsUsuario.Tables.Clear();
                    }

                    foreach (string PropriedadeChave in sResult.Properties.PropertyNames)
                    {
                        foreach (object Propriedade in sResult.Properties[PropriedadeChave])
                        {
                            dsUsuario.Tables[0].Rows.Add(new object[] { PropriedadeChave.ToString(), Propriedade.ToString() });
                        }
                    }
                }
                else
                {
                    try
                    {
                        dsUsuario.Tables.Add("FALHA");
                        dsUsuario.Tables[0].Columns.Add("DESCRICAO", Type.GetType("System.String"));
                    }
                    catch
                    {
                        dsUsuario.Tables.Clear();
                    }

                    dsUsuario.Tables[0].Rows.Add(strStatus);
                }
            }
            catch (DirectoryServicesCOMException ex)
            {
                dsUsuario.Tables.Add("FALHA");
                dsUsuario.Tables[0].Columns.Add("DESCRICAO", Type.GetType("System.String"));
                dsUsuario.Tables[0].Rows.Add(ex.Message);
            }

            return dsUsuario;
        }

        /// <summary>
        /// Busca os grupos ao qual o usuario pertence
        /// </summary>
        /// <returns>String com os grupos ao qual o usuario tem acesso, separados por (;)</returns>
        public DataSet BuscaGruposUsuario(String strDominio, String strUsuario)
        {
            try
            {
                DataSet dsGruposUsuario = new DataSet();

                try
                {
                    dsGruposUsuario.Tables.Add("TABLE");
                    dsGruposUsuario.Tables[0].Columns.Add("Grupos", Type.GetType("System.String"));
                }
                catch
                {
                    dsGruposUsuario.Tables.Clear();
                }

                DirectoryEntry dEntry = new DirectoryEntry("LDAP://" + strDominio);
                DirectorySearcher dSearch = new DirectorySearcher(dEntry);
                SearchResult sResult = null;

                dSearch.Filter = "(SAMAccountName=" + strUsuario + ")";
                sResult = dSearch.FindOne();

                DirectoryEntry dEntryUser = sResult.GetDirectoryEntry();
                System.DirectoryServices.PropertyCollection pcoll = dEntryUser.Properties;
                PropertyValueCollection memberOf = pcoll["memberOf"];

                foreach (string cnGroup in memberOf)
                {
                    dSearch.Filter = cnGroup.Substring(0, cnGroup.IndexOf(','));
                    sResult = dSearch.FindOne();
                    if (sResult != null)
                    {
                        DirectoryEntry group = sResult.GetDirectoryEntry();
                        dsGruposUsuario.Tables[0].Rows.Add(group.Properties["SAMAccountName"].Value.ToString());
                    }
                }

                return dsGruposUsuario;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Busca os Dominios disponiveis na Rede
        /// </summary>
        /// <returns></returns>
        public DataSet DominioRede()
        {
            String strCaracter = ".";
            String[] Split = null;
            DataSet dsListaDominio = new DataSet();

            Forest currentForest = Forest.GetCurrentForest();
            DomainCollection myDomains = currentForest.Domains;

            Char[] Delimiter = strCaracter.ToCharArray();

            dsListaDominio.Tables.Add("TABLE");
            dsListaDominio.Tables[0].Columns.Add("Dominios", Type.GetType("System.String"));

            foreach (Domain objDomain in myDomains)
            {
                Split = objDomain.Name.Split(Delimiter);
                dsListaDominio.Tables[0].Rows.Add(Split[0].ToUpper());
            }

            return dsListaDominio;
        }

        public DataSet listUsers(String strDominio, String strUsuario)
        {
            DataSet dsUsuario = new DataSet();
            DirectoryEntry dEntry = new DirectoryEntry("LDAP://" + strDominio);

            try
            {
                DirectorySearcher dSearch = new DirectorySearcher(dEntry);
                SearchResult sResult = null;
                dSearch.Filter = "(SAMAccountName=" + strUsuario + ")";

                sResult = dSearch.FindOne();
                DirectoryEntry user = sResult.GetDirectoryEntry();

                try
                {
                    dsUsuario.Tables.Add("USUARIO");
                    dsUsuario.Tables[0].Columns.Add("CHAVE", Type.GetType("System.String"));
                    dsUsuario.Tables[0].Columns.Add("PROPRIEDADE", Type.GetType("System.String"));
                }
                catch
                {
                    dsUsuario.Tables.Clear();
                }

                foreach (string PropriedadeChave in sResult.Properties.PropertyNames)
                {
                    foreach (object Propriedade in sResult.Properties[PropriedadeChave])
                    {
                        dsUsuario.Tables[0].Rows.Add(new object[] { PropriedadeChave.ToString(), Propriedade.ToString() });
                    }
                }
            }
            catch (DirectoryServicesCOMException ex)
            {
                dsUsuario.Tables.Add("FALHA");
                dsUsuario.Tables[0].Columns.Add("DESCRICAO", Type.GetType("System.String"));
                dsUsuario.Tables[0].Rows.Add(ex.Message);
            }

            return dsUsuario;
        }

        public String RetornaPropriedade(DataSet dsUsuario, String Propriedade)
        {
            String strRetorno = "";
            try
            {
                foreach (DataRow dRow in dsUsuario.Tables[0].Rows)
                {
                    if (dRow["CHAVE"].ToString().Trim().ToUpper() == Propriedade.Trim().ToUpper())
                    {
                        strRetorno = dRow["PROPRIEDADE"].ToString().ToUpper();
                        break;
                    }
                }
                return strRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to list Properties >>> System Error: " + ex.Message);
            }
        }
    }
}
