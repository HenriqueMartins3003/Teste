using System;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace clsVerisys.Tools
{
    public static class Logs
    {
        private static Int32 _fileCount = 0;
        const Int32 MAX_FILE_SIZE = 5000000;
        private static readonly Object _syncObject = new Object();
        
        private static Boolean _logEnabled = true;
        public static Boolean LogEnabled
        {
            get
            {
                if ((ConfigurationManager.ConnectionStrings["LogFile"] != null))
                {
                    try
                    {
                        _logEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["LogFile"].ToString());
                    }
                    catch
                    {
                        _logEnabled = true;
                    }
                    return _logEnabled;
                }
                else
                {
                    _logEnabled = true;
                    return _logEnabled;
                }
            }
        }

        /// <summary>
        /// Tipo de Log
        /// </summary>
        public enum LogType
        {
            Aplicacao,
            Conexao,
            Acesso
        }

        /// <summary>
        /// Grava arquivo de log da aplicação, de acordo com as opções enviadas
        /// </summary>
        /// <param name="strLog">Texto a ser inserido na log</param>
        /// <param name="enLogType">Tipo de Log (Enumerador)</param>
        public static void GravaLogs(String strLog, LogType enLogType)
        {
            if (LogEnabled)
            {
                try
                {
                    String dataAtual = DateTime.Now.ToString("yyyyMMdd");
                    String strCaminho = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    String strPasta = "";

                    switch (enLogType)
                    {
                        case LogType.Acesso:
                            {
                                strPasta = "LogAcesso";
                            }
                            break;
                        case LogType.Aplicacao:
                            {
                                strPasta = "LogAplicacao";
                            }
                            break;
                        case LogType.Conexao:
                            {
                                strPasta = "LogConexao";
                            }
                            break;
                    }

                    if (!Directory.Exists(Path.Combine(strCaminho, strPasta)))
                        Directory.CreateDirectory(Path.Combine(strCaminho, strPasta));

                    String strArquivo = Path.Combine(strCaminho, strPasta) + "\\Log_" + dataAtual + "_" + _fileCount + ".log";

                    FileStream fileStream = new FileStream(strArquivo, FileMode.Append, FileAccess.Write, FileShare.Read);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(String.Format("{0} -->> {1}", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), strLog));
                    
                    if (fileStream.Length > MAX_FILE_SIZE)
                    {
                        _fileCount++;
                    }
                    
                    streamWriter.Close();
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao gravar Log do Servidor : " + ex.Message);
                }
            }
        }









        [System.Obsolete("\nComponente ficando obsoleto: Utilize GravaLogs(String strLog, LogType enLogType)")]
        /// <summary>
        /// <para>Grava a Log da Aplicação</para>
        /// <para>na pasta da aplicação, subpasta Logs</para>
        /// </summary>
        /// <param name="strLog">Log a ser gravada</param>
        public static void gravaLogs(String strLog)
        {
            try
            {
                String dataAtual = DateTime.Now.ToString("yyyyMMdd");
                String strCaminho = Path.GetDirectoryName(Application.ExecutablePath);

                if (!Directory.Exists(Path.Combine(strCaminho, "Logs")))
                    Directory.CreateDirectory(Path.Combine(strCaminho, "Logs"));

                String strArquivo = Path.Combine(strCaminho, "Logs") + "\\Log_" + dataAtual + ".log";

                FileStream fileStream = new FileStream(strArquivo, FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " --> " + strLog);
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Log do Servidor : " + ex.Message);
            }
        }

        [System.Obsolete("\nComponente ficando obsoleto: Utilize GravaLogs(String strLog, LogType enLogType)")]
        /// <summary>
        /// <para>Grava a Log da Aplicação</para>
        /// <para>na pasta definida no parametro</para>
        /// </summary>
        /// <param name="strLog">Log a ser gravada</param>
        /// <param name="strCaminhoLog">Caminho a ser gravado o arquivo de logs</param>
        public static void gravaLogs(String strLog, String strCaminhoLog)
        {
            try
            {
                String dataAtual = DateTime.Now.ToString("yyyyMMdd");
                String strCaminho = strCaminhoLog;

                String strArquivo = strCaminhoLog + "\\Log_" + dataAtual + ".log";

                FileStream fileStream = new FileStream(strArquivo, FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " --> " + strLog);
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Log do Servidor : " + ex.Message);
            }
        }


    }
}
