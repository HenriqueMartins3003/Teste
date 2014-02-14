using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoUsersProfiles
    {
        public enum AccessType
        {
            INCLUSAO,
            EXCLUSAO,
            ALTERACAO,
            CONSULTA
        }

        private Int16 _Task;
        public Int16 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int16 _TaskAcesso;
        public Int16 TaskAcesso
        {
            get { return _TaskAcesso; }
            set { _TaskAcesso = value; }
        }

        private Int16 _TaskAcessoOperacao;
        public Int16 TaskAcessoOperacao
        {
            get { return _TaskAcessoOperacao; }
            set { _TaskAcessoOperacao = value; }
        }

        private Int64 _IdUserProfile;
        public Int64 IdUserProfile
        {
            get { return _IdUserProfile; }
            set { _IdUserProfile = value; }
        }

        private String _DescriptProfile;
        public String DescriptProfile
        {
            get { return _DescriptProfile; }
            set { _DescriptProfile = value; }
        }
        
        private Int16 _TypeProfile;
        public Int16 TypeProfile
        {
            get { return _TypeProfile; }
            set { _TypeProfile = value; }
        }

        private Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private String _ResultTask;
        public String ResultTask
        {
            get { return _ResultTask; }
            set { _ResultTask = value; }
        }

        private Int64 _Module;
        public Int64 Module
        {
            get { return _Module; }
            set { _Module = value; }
        }

        private Int32 _ModuloInclusao;
        public Int32 ModuloInclusao
        {
            get { return _ModuloInclusao; }
            set { _ModuloInclusao = value; }
        }

        private Int32 _ModuloAlteracao;
        public Int32 ModuloAlteracao
        {
            get { return _ModuloAlteracao; }
            set { _ModuloAlteracao = value; }
        }

        private Int32 _ModuloExclusao;
        public Int32 ModuloExclusao
        {
            get { return _ModuloExclusao; }
            set { _ModuloExclusao = value; }
        }

        private Int32 _ModuloConsulta;
        public Int32 ModuloConsulta
        {
            get { return _ModuloConsulta; }
            set { _ModuloConsulta = value; }
        }

        private String _ServidorMailing;
        public String ServidorMailing
        {
            get { return _ServidorMailing; }
            set { _ServidorMailing = value; }
        }

        private String _DatabaseMailing;
        public String DatabaseMailing
        {
            get { return _DatabaseMailing; }
            set { _DatabaseMailing = value; }
        }



        private String _ModuleList;
        public String ModuleList
        {
            get { return _ModuleList; }
            set { _ModuleList = value; }
        }






        // constructor
        public dtoUsersProfiles()
        {
            // to-do
        }
    }
}
