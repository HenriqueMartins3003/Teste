using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace clsTools
{
    public class Logs
    {
        /// <summary>
        /// <para>Grava a Log da Aplicação</para>
        /// <para>na pasta da aplicação, subpasta Logs</para>
        /// </summary>
        /// <param name="strLog">Log a ser gravada</param>
        public void gravaLogs(String strLog)
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

        /// <summary>
        /// <para>Grava a Log da Aplicação</para>
        /// <para>na pasta definida no parametro</para>
        /// </summary>
        /// <param name="strLog">Log a ser gravada</param>
        /// <param name="strCaminhoLog">Caminho a ser gravado o arquivo de logs</param>
        public void gravaLogs(String strLog, String strCaminhoLog)
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
