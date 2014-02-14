using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoPageConfig
    {
        public dtoPageConfig()
        { }

        private String _Descricao;
        public String Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        private String _Url;
        public String Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        private Int32 _ModuloFilho;
        public Int32 ModuloFilho
        {
            get { return _ModuloFilho; }
            set { _ModuloFilho = value; }
        }

        private Boolean _Flag_Menu;
        public Boolean Flag_Menu
        {
            get { return _Flag_Menu; }
            set { _Flag_Menu = value; }
        }

        private Int32 _Ordem;
        public Int32 Ordem
        {
            get { return _Ordem; }
            set { _Ordem = value; }
        }

    }
}
