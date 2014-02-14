using System;

namespace clsVerisys.Tools
{
    public class Formatacao
    {
        /// <summary>
        /// Formata uma seguencia de Strings com mascara de CPF
        /// </summary>
        /// <param name="strCpf"> String a ser "mascarada" </param>
        /// <returns> String </returns>
        public String FormataCPF(String strCpf)
        {
            try
            {
                return String.Format("{0}.{1}.{2}-{3}", strCpf.Substring(0, 3), strCpf.Substring(3, 3), strCpf.Substring(6, 3), strCpf.Substring(9, 2));
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Formata uma seguencia de Strings com mascara de CNPJ
        /// </summary>
        /// <param name="strCnpj"> String a ser "mascarada" </param>
        /// <returns> String </returns>
        public String FormataCNPJ(String strCnpj)
        {
            try
            {
                return String.Format("{0}.{1}.{2}/{3}-{4}", strCnpj.Substring(0, 2), strCnpj.Substring(2, 3), strCnpj.Substring(5, 3), strCnpj.Substring(8, 4), strCnpj.Substring(12, 2));
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Formata uma seguencia de Strings com mascara de CEP
        /// </summary>
        /// <param name="strCep"> String a ser "mascarada" </param>
        /// <returns> String </returns>
        public String FormataCEP(String strCep)
        {
            try
            {
                return String.Format("{0}{1}-{2}", strCep.Substring(0, 2), strCep.Substring(2, 3), strCep.Substring(5, 3));
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
