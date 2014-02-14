using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Collections;
using System.Net.Mail;

namespace clsVerisys.Tools
{
    public class Utilitarios
    {
        /// <summary>
        /// Retorna String contendo todos os IPs da Estação
        /// </summary>
        /// <returns> String contendo os IPs separados por | Pipe</returns>
        public String RetornaIpMaquina()
        {
            String strDefaultSeparador = "|";
            IPHostEntry host;
            String localIP = String.Empty;
            String separator = String.Empty;

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP += separator + ip.ToString();
                    separator = strDefaultSeparador;
                }
            }
            return localIP;
        }

        /// <summary>
        /// Retorna o IP da placa de rede solicitada
        /// </summary>
        /// <param name="idPlaca"> NumberID da placa de Rede (0 a 3) </param>
        /// <returns> String </returns>
        public String RetornaIpMaquina(Int64 idPlaca)
        {
            String strHost = "";
            IPAddress[] arrIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            strHost = arrIp[idPlaca].ToString();

            return strHost;
        }

        /// <summary>
        /// Remove os acentos de uma String
        /// </summary>
        /// <param name="strTexto"> String a ser convertida </param>
        /// <returns> String </returns>
        public String TirarAcentos(String strTexto)
        {
            String strTextoRetorno = "";

            for (int i = 0; i < strTexto.Length; i++)
            {
                if (strTexto[i].ToString() == "ã") strTextoRetorno += "a";
                else if (strTexto[i].ToString() == "á") strTextoRetorno += "a";
                else if (strTexto[i].ToString() == "à") strTextoRetorno += "a";
                else if (strTexto[i].ToString() == "â") strTextoRetorno += "a";
                else if (strTexto[i].ToString() == "ä") strTextoRetorno += "a";
                else if (strTexto[i].ToString() == "é") strTextoRetorno += "e";
                else if (strTexto[i].ToString() == "è") strTextoRetorno += "e";
                else if (strTexto[i].ToString() == "ê") strTextoRetorno += "e";
                else if (strTexto[i].ToString() == "ë") strTextoRetorno += "e";
                else if (strTexto[i].ToString() == "í") strTextoRetorno += "i";
                else if (strTexto[i].ToString() == "ì") strTextoRetorno += "i";
                else if (strTexto[i].ToString() == "ï") strTextoRetorno += "i";
                else if (strTexto[i].ToString() == "õ") strTextoRetorno += "o";
                else if (strTexto[i].ToString() == "ó") strTextoRetorno += "o";
                else if (strTexto[i].ToString() == "ò") strTextoRetorno += "o";
                else if (strTexto[i].ToString() == "ö") strTextoRetorno += "o";
                else if (strTexto[i].ToString() == "ú") strTextoRetorno += "u";
                else if (strTexto[i].ToString() == "ù") strTextoRetorno += "u";
                else if (strTexto[i].ToString() == "ü") strTextoRetorno += "u";
                else if (strTexto[i].ToString() == "ç") strTextoRetorno += "c";
                else if (strTexto[i].ToString() == "Ã") strTextoRetorno += "A";
                else if (strTexto[i].ToString() == "Á") strTextoRetorno += "A";
                else if (strTexto[i].ToString() == "À") strTextoRetorno += "A";
                else if (strTexto[i].ToString() == "Â") strTextoRetorno += "A";
                else if (strTexto[i].ToString() == "Ä") strTextoRetorno += "A";
                else if (strTexto[i].ToString() == "É") strTextoRetorno += "E";
                else if (strTexto[i].ToString() == "È") strTextoRetorno += "E";
                else if (strTexto[i].ToString() == "Ê") strTextoRetorno += "E";
                else if (strTexto[i].ToString() == "Ë") strTextoRetorno += "E";
                else if (strTexto[i].ToString() == "Í") strTextoRetorno += "I";
                else if (strTexto[i].ToString() == "Ì") strTextoRetorno += "I";
                else if (strTexto[i].ToString() == "Ï") strTextoRetorno += "I";
                else if (strTexto[i].ToString() == "Õ") strTextoRetorno += "O";
                else if (strTexto[i].ToString() == "Ó") strTextoRetorno += "O";
                else if (strTexto[i].ToString() == "Ò") strTextoRetorno += "O";
                else if (strTexto[i].ToString() == "Ö") strTextoRetorno += "O";
                else if (strTexto[i].ToString() == "Ú") strTextoRetorno += "U";
                else if (strTexto[i].ToString() == "Ù") strTextoRetorno += "U";
                else if (strTexto[i].ToString() == "Ü") strTextoRetorno += "U";
                else if (strTexto[i].ToString() == "Ç") strTextoRetorno += "C";
                else strTextoRetorno += strTexto[i];
            }
            return strTextoRetorno;
        }

        /// <summary>
        /// Mata processo a partir do Nome do mesmo
        /// </summary>
        /// <param name="strNomeProcesso"> String com o nome do Processo </param>
        /// <returns> Boolean </returns>
        public Boolean MataProcesso(String strNomeProcesso)
        {
            System.Diagnostics.Process[] processo = System.Diagnostics.Process.GetProcessesByName(strNomeProcesso);

            try
            {
                if (processo.Count() > 0)
                {
                    foreach (System.Diagnostics.Process processos in processo)
                    {
                        processos.Kill();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converte uma imagem em Bytes
        /// </summary>
        /// <param name="image"> A Imagem a ser convertida</param>
        /// <returns> Byte array </returns>
        public Byte[] ConvertImageToByte(Image image)
        {
            if (image == null)
                return null;

            Byte[] bytes;
            if (image.GetType().ToString() == "System.Drawing.Image")
            {
                ImageConverter converter = new ImageConverter();
                bytes = (Byte[])converter.ConvertTo(image, typeof(Byte[]));
                return bytes;
            }
            else if (image.GetType().ToString() == "System.Drawing.Bitmap")
            {
                bytes = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(image).ConvertTo(image, typeof(Byte[]));
                return bytes;
            }
            else
                throw new NotImplementedException("ConvertImageToByte invalid type " + image.GetType().ToString());
        }

        /// <summary>
        /// Convert Bytes em Imagem
        /// </summary>
        /// <param name="bytes">Byte array, com os dados da Imagem</param>
        /// <returns> System.Drawing.Image </returns>
        public Image ConvertByteToImage(Byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Converte String Hexadecimal em ByteArray
        /// </summary>
        /// <param name="HexString"> String Hexadecimal a ser convertida </param>
        /// <returns> Byte Array </returns>
        public Byte[] convertHexStringToByteArray(String HexString)
        {
            String _hexString = HexString.Replace("0x", "");
            int NumberChars = _hexString.Length;
            Byte[] bytes = new Byte[NumberChars / 2];
            try
            {
                for (int i = 0; i < NumberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(_hexString.Substring(i, 2), 16);
                }
                return bytes;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna a idade em Anos
        /// </summary>
        /// <param name="dataNascimento"> Data de nascimento para Calculo </param>
        /// <returns> Inteiro </returns>
        public Int32 RetornaIdadeAnos(DateTime dataNascimento)
        {
            DateTime dt = dataNascimento;
            TimeSpan ts = DateTime.Today - dt;

            try
            {
                DateTime idade = (new DateTime() + ts).AddYears(-1);
                return idade.Year;
            }
            catch
            {
                return 0;
            }
        }

        public String RetornaMesExtenso(Int32 Mes)
        {
            String Retorno = "";

            switch (Mes)
            {
                case 1:
                    Retorno = "Janeiro";
                    break;
                case 2:
                    Retorno = "Fevereiro";
                    break;
                case 3:
                    Retorno = "Marco";
                    break;
                case 4:
                    Retorno = "Abril";
                    break;
                case 5:
                    Retorno = "Maio";
                    break;
                case 6:
                    Retorno = "Junho";
                    break;
                case 7:
                    Retorno = "Julho";
                    break;
                case 8:
                    Retorno = "Agosto";
                    break;
                case 9:
                    Retorno = "Setembro";
                    break;
                case 10:
                    Retorno = "Outubro";
                    break;
                case 11:
                    Retorno = "Novembro";
                    break;
                case 12:
                    Retorno = "Dezembro";
                    break;
            }

            return Retorno;
        }

        public String RetornaDataHoraSQL(String Valor)
        {
            /* Cobre algumas possibilidades de entrada
             dia;mes;ano
             "04/12/12"
             "04-12-12"
             "04.12.12"
            
             dia;mes;ano
             "04122012"
             "04/12/2012"
             "04-12-2012"
             "04.12.2012"
            
             ano;mes;dia
             "20121204"
             "2012-12-04"
             "2012/05/28"
             "2012.12.04"
             
             */
            String dtfinal = "";
            Char[] charArray = { '/', '-', '.' };
            if (charArray.Any(s => Valor.Contains(s)))
            {
                dtfinal = Convert.ToDateTime(Valor).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                if (Valor.Length == 8)
                {
                    String pos1 = Valor.Substring(0, 2);
                    String pos2 = Valor.Substring(2, 2);
                    String pos3 = Valor.Substring(4, 4);

                    if (int.Parse(pos3) < 1900)
                    {
                        pos1 = Valor.Substring(6, 2);
                        pos2 = Valor.Substring(4, 2);
                        pos3 = Valor.Substring(0, 4);
                    }

                    dtfinal = Convert.ToDateTime(pos1 + "/" + pos2 + "/" + pos3).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

            return dtfinal;
        }

        public Boolean EnviaEmail(String strEmailServidor, int intPortaServidor, String strEmailDe, ArrayList arrDestinatarioTO, ArrayList arrDestinatarioCC,
                                  ArrayList arrDestinatarioBC, String strEmailAssunto, String strEmailTexto, ArrayList arrArquivoAnexo)
        {
            SmtpClient objSmtp = new SmtpClient(strEmailServidor, intPortaServidor);

            String strArqAnexo = "";
            String strDestinatarioTO = "";
            String strDestinatarioCC = "";
            String strDestinatarioBC = "";

            try
            {
                MailMessage objEmail = new MailMessage();

                objEmail.From = new MailAddress(strEmailDe, "");

                if (arrDestinatarioTO != null)
                {
                    for (int intItem = 0; intItem < arrDestinatarioTO.Count; intItem++)
                    {
                        strDestinatarioTO = arrDestinatarioTO[intItem].ToString();

                        objEmail.To.Add(new MailAddress(strDestinatarioTO, ""));
                    }
                }

                if (arrDestinatarioCC != null)
                {
                    for (int intItem = 0; intItem < arrDestinatarioCC.Count; intItem++)
                    {
                        strDestinatarioCC = arrDestinatarioCC[intItem].ToString();

                        objEmail.CC.Add(new MailAddress(strDestinatarioCC, ""));
                    }
                }

                if (arrDestinatarioBC != null)
                {
                    for (int intItem = 0; intItem < arrDestinatarioBC.Count; intItem++)
                    {
                        strDestinatarioBC = arrDestinatarioBC[intItem].ToString();

                        objEmail.Bcc.Add(new MailAddress(strDestinatarioBC, ""));
                    }
                }

                objEmail.Subject = strEmailAssunto;
                objEmail.Body = strEmailTexto;
                objEmail.IsBodyHtml = false;

                if (arrArquivoAnexo != null)
                {
                    for (int intItem = 0; intItem < arrArquivoAnexo.Count; intItem++)
                    {
                        strArqAnexo = arrArquivoAnexo[intItem].ToString();
                        if (File.Exists(strArqAnexo))
                        {
                            objEmail.Attachments.Add(new Attachment(strArqAnexo));
                        }
                    }
                }

                objEmail.BodyEncoding = System.Text.Encoding.UTF8;
                objEmail.Priority = MailPriority.Normal;
                objSmtp.Send(objEmail);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Envio de Email via SMTP
        /// </summary>
        /// <param name="Servidor">Servidor SMTP</param>
        /// <param name="Porta">Porta do Servidor (normalmente 25)</param>
        /// <param name="Autentica">O Servidor de Smtp Precisa ou não de autenticacao</param>
        /// <param name="User">Usuario para Autenticação</param>
        /// <param name="Password">Senha para Autenticação</param>
        /// <param name="EmailDe">Remetente</param>
        /// <param name="DestinatarioTO">Array Destinatários</param>
        /// <param name="DestinatarioCC">Array Destinatários Cópia (Null se não houver)</param>
        /// <param name="DestinatarioBC">Array Destinatários Cópia (Null se não houver)</param>
        /// <param name="EmailAssunto">Assunto</param>
        /// <param name="EmailTexto">Corpo do Email</param>
        /// <param name="isHTML">Se o corpo do email é html ou texto</param>
        /// <returns> Boleano confirmando o envio </returns>
        public Boolean EnviaEmail(String Servidor, Int32 Porta, Boolean isSegura, Boolean Autentica, String User, String Password,
                                  String EmailDe, String EmailDeDisplay, String DestinatarioTO, String EmailAssunto, String EmailTexto)
        {
            try
            {
                SmtpClient objSmtp = new SmtpClient(Servidor, Porta);

                if (Autentica)
                {
                    NetworkCredential basicCredential = new NetworkCredential(User, Password);
                    objSmtp.UseDefaultCredentials = false;
                    objSmtp.Credentials = basicCredential;
                }

                if (isSegura)
                {
                    objSmtp.EnableSsl = true;
                }

                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress(EmailDe, EmailDeDisplay);
                objEmail.To.Add(new MailAddress(DestinatarioTO, ""));
                objEmail.Subject = EmailAssunto;
                objEmail.Body = EmailTexto;
                objEmail.IsBodyHtml = false;
                objEmail.BodyEncoding = System.Text.Encoding.UTF8;
                objEmail.Priority = MailPriority.Normal;
                objSmtp.Send(objEmail);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
