using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace clsTools
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
    }
}
