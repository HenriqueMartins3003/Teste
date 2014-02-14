using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoGruposDac
    {
        public dtoGruposDac()
        {
        }

        private Int16 _Task;
        public Int16 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private String _User;
        public String User
        {
            get { return _User; }
            set { _User = value; }
        }

        private String _GrupoDac;
        public String GrupoDac
        {
            get { return _GrupoDac; }
            set { _GrupoDac = value; }
        }

        private String _NomeGrupoDac;
        public String NomeGrupoDac
        {
            get { return _NomeGrupoDac; }
            set { _NomeGrupoDac = value; }
        }

        private String _TempoClerical;
        public String TempoClerical
        {
            get { return _TempoClerical; }
            set { _TempoClerical = value; }
        }

        private Int64 _Prioridade;
        public Int64 Prioridade
        {
            get { return _Prioridade; }
            set { _Prioridade = value; }
        }

    }

    public class dtoGrupoDacPermission
    {
        public int Task { get; set; }
        public int IdGrupoDACRestricao { get; set; }
        public int GrupoDAC { get; set; }
        public int Classificacao { get; set; }
        public int Tipo { get; set; }

    }
}
