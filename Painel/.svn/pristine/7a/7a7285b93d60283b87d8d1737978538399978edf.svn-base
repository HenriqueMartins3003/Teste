using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace clsTools
{
    public class Validadores
    {
        /// <summary>
        /// Valida se o formato do email é valido
        /// </summary>
        /// <param name="strEmail"> Informe o email a ser validado </param>
        /// <returns> Boolean </returns>
        public Boolean isEmail(String strEmail)
        {
            String strEmailRegex = @"^(([^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+"
                + @"(\.[^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+)*)|(\"".+\""))@"
                + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|"
                + @"(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

            Regex rx = new Regex(strEmailRegex);
            return rx.IsMatch(strEmail);
        }

        /// <summary>
        /// Valida se o numero informado é par
        /// </summary>
        /// <param name="intValor"> Valor numerico a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isPar(Int64 intValor)
        {
            if (intValor % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica se o valor informado é uma data valida
        /// </summary>
        /// <param name="strValor"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isData(String strValor)
        {
            DateTime datData;

            if (!(DateTime.TryParse(strValor, out datData)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifica se o valor informado é um numero
        /// </summary>
        /// <param name="strValor"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isNumero(String strValor)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strValor) &&
                   !objTwoDotPattern.IsMatch(strValor) &&
                   !objTwoMinusPattern.IsMatch(strValor) &&
                   objNumberPattern.IsMatch(strValor);
        }

        /// <summary>
        /// Valida se o valor informado é um CEP
        /// </summary>
        /// <param name="strValor"> String a ser verificado </param>
        /// <param name="bolMascara"> Informa se possui mascara </param>
        /// <returns> Boolean </returns>
        public Boolean isCEP(String strValor, Boolean bolMascara)
        {
            if (bolMascara)
                return Regex.IsMatch(strValor, @"^\d{5}\d{3}$");
            else
                return Regex.IsMatch(strValor, @"^\d{5}\-?\d{3}$");
        }

        /// <summary>
        /// Verifica se o valor informado possui somente Letras e Numeros
        /// </summary>
        /// <param name="strValor"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isAlphaNumber(String strValor)
        {
            return Regex.IsMatch(strValor, @"^[a-zA-Z0-9]+$");
        }

        /// <summary>
        /// Verifica se o valor informado possui somente Letras
        /// </summary>
        /// <param name="strValor"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isLetter(String strValor)
        {
            return Regex.IsMatch(strValor, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Verifica se o valor informado é um DDD valido
        /// </summary>
        /// <param name="strDDD"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isDDD(String strDDD)
        {
            try
            {
                if (strDDD != String.Empty)
                {
                    if (!isNumero(strDDD))
                        return false;

                    if ((strDDD.Length > 3) || (strDDD.Length < 2))
                        return false;

                    if ((Convert.ToInt16(strDDD) < 11) || (Convert.ToInt16(strDDD) > 99))
                        return false;
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica se o valor informado é um Telefone valido
        /// </summary>
        /// <param name="strTelefone"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isTelefone(String strTelefone)
        {
            try
            {
                if (strTelefone != String.Empty)
                {
                    if (!isNumero(strTelefone))
                        return false;

                    if ((strTelefone.Length > 9) || (strTelefone.Length < 8))
                        return false;

                    if (Convert.ToInt16(strTelefone.Substring(0, 1)) < 2)
                        return false;

                    if (strTelefone.Length == 9)
                    {
                        if (strTelefone.Substring(0, 1) != "9")
                            return false;
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica se o valor informado é um CPF valido
        /// </summary>
        /// <param name="strCpf"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isCPF(String strCpf)
        {
            int[] intMultiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] intMultiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string strTempCpf, strDigito;
            int intSoma, intResto;

            try
            {
                strCpf = strCpf.Trim();
                strCpf = strCpf.Replace(".", "").Replace("-", "");

                if (strCpf.Length != 11)
                {
                    return false;
                }

                if ((strCpf == "11111111111") ||
                    (strCpf == "22222222222") ||
                    (strCpf == "33333333333") ||
                    (strCpf == "44444444444") ||
                    (strCpf == "55555555555") ||
                    (strCpf == "66666666666") ||
                    (strCpf == "77777777777") ||
                    (strCpf == "88888888888") ||
                    (strCpf == "99999999999") ||
                    (strCpf == "00000000000"))
                {
                    return false;
                }

                strTempCpf = strCpf.Substring(0, 9);

                intSoma = 0;

                for (int intItem = 0; intItem < 9; intItem++)
                {
                    intSoma += int.Parse(strTempCpf[intItem].ToString()) * intMultiplicador1[intItem];
                }
                intResto = intSoma % 11;

                if (intResto < 2)
                {
                    intResto = 0;
                }
                else
                {
                    intResto = 11 - intResto;
                }

                strDigito = intResto.ToString();
                strTempCpf += strDigito;
                intSoma = 0;

                for (int intItem = 0; intItem < 10; intItem++)
                {
                    intSoma += int.Parse(strTempCpf[intItem].ToString()) * intMultiplicador2[intItem];
                }
                intResto = intSoma % 11;

                if (intResto < 2)
                {
                    intResto = 0;
                }
                else
                {
                    intResto = 11 - intResto;
                }
                strDigito += intResto.ToString();

                return strCpf.EndsWith(strDigito);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica se o valor informado é um CNPJ valido
        /// </summary>
        /// <param name="strCnpj"> String a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isCnpj(String strCnpj)
        {
            int[] intMultiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] intMultiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int intSoma, intResto;
            string strDigito, strTempCnpj;

            try
            {
                strCnpj = strCnpj.Trim();
                strCnpj = strCnpj.Replace(".", "").Replace("-", "").Replace("/", "");

                if (strCnpj.Length != 14)
                {
                    return false;
                }
                strTempCnpj = strCnpj.Substring(0, 12);

                intSoma = 0;
                for (int intItem = 0; intItem < 12; intItem++)
                {
                    intSoma += int.Parse(strTempCnpj[intItem].ToString()) * intMultiplicador1[intItem];
                }
                intResto = (intSoma % 11);

                if (intResto < 2)
                {
                    intResto = 0;
                }
                else
                {
                    intResto = 11 - intResto;
                }

                strDigito = intResto.ToString();
                strTempCnpj += strDigito;
                intSoma = 0;

                for (int intItem = 0; intItem < 13; intItem++)
                    intSoma += int.Parse(strTempCnpj[intItem].ToString()) * intMultiplicador2[intItem];

                intResto = (intSoma % 11);
                if (intResto < 2)
                {
                    intResto = 0;
                }
                else
                {
                    intResto = 11 - intResto;
                }

                strDigito += intResto.ToString();

                return strCnpj.EndsWith(strDigito);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica se o valor informado é um PIS valido
        /// </summary>
        /// <param name="strPis"> Valor a ser verificado </param>
        /// <returns> Boolean </returns>
        public Boolean isPis(String strPis)
        {
            int[] intMultiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int intSoma;
            int intResto;

            if (strPis.Trim().Length == 0)
            {
                return false;
            }

            strPis = strPis.Trim();
            strPis = strPis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            intSoma = 0;
            for (int i = 0; i < 10; i++)
            {
                intSoma += int.Parse(strPis[i].ToString()) * intMultiplicador[i];
            }
            intResto = intSoma % 11;

            if (intResto < 2)
                intResto = 0;
            else
                intResto = 11 - intResto;

            return strPis.EndsWith(intResto.ToString());
        }
    }
}