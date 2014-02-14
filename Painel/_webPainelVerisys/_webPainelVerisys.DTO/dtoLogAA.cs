using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoLogAA
    {
        string ramal;
        public string Ramal
        {
            get { return ramal; }
            set { ramal = value; }
        }

        string ip;
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        string versaoAnterior;
        public string VersaoAnterior
        {
            get { return versaoAnterior; }
            set { versaoAnterior = value; }
        }

        string versaoAtualizacao;
        public string VersaoAtualizacao
        {
            get { return versaoAtualizacao; }
            set { versaoAtualizacao = value; }
        }

        string resultado;
        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        string dataHora;
        public string DataHora
        {
            get { return dataHora; }
            set { dataHora = value; }
        }
    }
}
