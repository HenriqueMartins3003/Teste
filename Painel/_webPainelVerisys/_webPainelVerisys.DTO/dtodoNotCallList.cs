using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtodoNotCallList
    {
        public dtodoNotCallList()
        { }

        private Int16 _Task;
        public Int16 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDMailing;
        public Int64 IDMailing
        {
            get { return _IDMailing; }
            set { _IDMailing = value; }
        }

        private String _TabelaDiscador;
        public String TabelaDiscador
        {
            get { return _TabelaDiscador; }
            set { _TabelaDiscador = value; }
        }

        private Int32 _KYFoneBloqueio;
        public Int32 KYFoneBloqueio
        {
            get { return _KYFoneBloqueio; }
            set { _KYFoneBloqueio = value; }
        }

        private String _LinkedServerMailing;
        public String LinkedServerMailing
        {
            get { return _LinkedServerMailing; }
            set { _LinkedServerMailing = value; }
        }

        private Boolean _Flag_Ativo;
        public Boolean Flag_Ativo
        {
            get { return _Flag_Ativo; }
            set { _Flag_Ativo = value; }
        }

        private String _IDCampanha;
        public String IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private Int64 _ProcessoID;
        public Int64 ProcessoID
        {
            get { return _ProcessoID; }
            set { _ProcessoID = value; }
        }
    }

    public class dtoProcesso
    {
        public dtoProcesso()
        { }

        private Int64 _ProcessoID;
        public Int64 ProcessoID
        {
            get { return _ProcessoID; }
            set { _ProcessoID = value; }
        }

        private String _Processo;
        public String Processo
        {
            get { return _Processo; }
            set { _Processo = value; }
        }
    }

    public class dtoNotCallCampanha
    {
        public dtoNotCallCampanha()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDCampanha;
        public Int64 IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private String _Campanha;
        public String Campanha
        {
            get { return _Campanha; }
            set { _Campanha = value; }
        }

        private Int64 _ProcessoID;
        public Int64 ProcessoID
        {
            get { return _ProcessoID; }
            set { _ProcessoID = value; }
        }
    }

    public class dtoNotCallReceptivo
    {
        public dtoNotCallReceptivo()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 idReceptivo;
        public Int64 IdReceptivo
        {
            get { return idReceptivo; }
            set { idReceptivo = value; }
        }

        private String _CPF;
        public String CPF
        {
            get { return _CPF; }
            set { _CPF = value; }
        }

        private String _DDD;
        public String DDD
        {
            get { return _DDD; }
            set { _DDD = value; }
        }

        private String _Telefone;
        public String Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        private DateTime _DataSolicitacao;
        public DateTime DataSolicitacao
        {
            get { return _DataSolicitacao; }
            set { _DataSolicitacao = value; }
        }
    }
}