using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clsVerisys.ResultadoOperacao
{
    public class dtoRO
    {
        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _CampanhaID;
        public Int64 CampanhaID
        {
            get { return _CampanhaID; }
            set { _CampanhaID = value; }
        }

        private Int64 _CallID;
        public Int64 CallID
        {
            get { return _CallID; }
            set { _CallID = value; }
        }

        private Int64 _ContactID;
        public Int64 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        private Int64 _MailingID;
        public Int64 MailingID
        {
            get { return _MailingID; }
            set { _MailingID = value; }
        }

        private Int64 _AgentID;
        public Int64 AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
        }

        private Int64 _ConfiguracaoID;
        public Int64 ConfiguracaoID
        {
            get { return _ConfiguracaoID; }
            set { _ConfiguracaoID = value; }
        }

        private String _Observacao;
        public String Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        private DateTime _DataReagendamento;
        public DateTime DataReagendamento
        {
          get { return _DataReagendamento; }
          set { _DataReagendamento = value; }
        }

        private String _NovoTelefone;
        public String NovoTelefone
        {
          get { return _NovoTelefone; }
          set { _NovoTelefone = value; }
        }

        private String _DesabilitaTelefone;
        public String DesabilitaTelefone
        {
            get { return _DesabilitaTelefone; }
            set { _DesabilitaTelefone = value; }
        }

        private Boolean _ReagendamentoAgente;
        public Boolean ReagendamentoAgente
        {
            get { return _ReagendamentoAgente; }
            set { _ReagendamentoAgente = value; }
        }




    }


}
