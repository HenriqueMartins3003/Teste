using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoFrontEnd
    {
    }

    public class dtoAuditor
    {
        public dtoAuditor()
        { }

        private Int16 _Task;
        public Int16 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDAuditor;
        public Int64 IDAuditor
        {
            get { return _IDAuditor; }
            set { _IDAuditor = value; }
        }
        
        private String _Codigo;
        public String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        
        private String _Nome;
        public String Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        
        private String _Senha;
        public String Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }

        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
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
    }

    public class dtoTipoPlano
    {
        public dtoTipoPlano()
        {}

        private Int16 _Task;
        public Int16 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDTipoPlano;
        public Int64 IDTipoPlano
        {
            get { return _IDTipoPlano; }
            set { _IDTipoPlano = value; }
        }

        private String _TipoPlano;
        public String TipoPlano
        {
            get { return _TipoPlano; }
            set { _TipoPlano = value; }
        }

        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
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
    }

    public class dtoPlano
    {
        public dtoPlano()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDPlano;
        public Int64 IDPlano
        {
            get { return _IDPlano; }
            set { _IDPlano = value; }
        }

        private Int64 _IDProduto;
        public Int64 IDProduto
        {
            get { return _IDProduto; }
            set { _IDProduto = value; }
        }

        private Int64 _CodigoPlano;
        public Int64 CodigoPlano
        {
            get { return _CodigoPlano; }
            set { _CodigoPlano = value; }
        }

        private Int64 _ImportanciaSegurada;
        public Int64 ImportanciaSegurada
        {
            get { return _ImportanciaSegurada; }
            set { _ImportanciaSegurada = value; }
        }

        private Int64 _Titular;
        public Int64 Titular
        {
            get { return _Titular; }
            set { _Titular = value; }
        }

        private Int64 _Conjuge;
        public Int64 Conjuge
        {
            get { return _Conjuge; }
            set { _Conjuge = value; }
        }

        private Int64 _Filho;
        public Int64 Filho
        {
            get { return _Filho; }
            set { _Filho = value; }
        }

        private Int64 _IdadeMin;
        public Int64 IdadeMin
        {
            get { return _IdadeMin; }
            set { _IdadeMin = value; }
        }

        private Int64 _IdadeMax;
        public Int64 IdadeMax
        {
            get { return _IdadeMax; }
            set { _IdadeMax = value; }
        }

        private Int64 _TipoPlano;
        public Int64 TipoPlano
        {
            get { return _TipoPlano; }
            set { _TipoPlano = value; }
        }

        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
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
    }

    public class dtoProduto
    {
        public dtoProduto()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }
        
        private Int64 _IDProduto;
        public Int64 IDProduto
        {
            get { return _IDProduto; }
            set { _IDProduto = value; }
        }
        
        private String _DescricaoProduto;
        public String DescricaoProduto
        {
            get { return _DescricaoProduto; }
            set { _DescricaoProduto = value; }
        }
        
        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
        {
            get { return _Flag_Ativo; }
            set { _Flag_Ativo = value; }
        }
        
        private String _CampanhaMailing;
        public String CampanhaMailing
        {
            get { return _CampanhaMailing; }
            set { _CampanhaMailing = value; }
        }
        
        private String _IDCampanha;
        public String IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }
    }

    public class dtoMeioCobranca
    {
        public dtoMeioCobranca()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDMeioCobranca;
        public Int64 IDMeioCobranca
        {
            get { return _IDMeioCobranca; }
            set { _IDMeioCobranca = value; }
        }

        private String _Cliente;
        public String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        
        private String _NMeioCobranca;
        public String NMeioCobranca
        {
            get { return _NMeioCobranca; }
            set { _NMeioCobranca = value; }
        }
        
        private String _NAdmCobranca;
        public String NAdmCobranca
        {
            get { return _NAdmCobranca; }
            set { _NAdmCobranca = value; }
        }
        
        private String _NCicloAdmCobranca;
        public String NCicloAdmCobranca
        {
            get { return _NCicloAdmCobranca; }
            set { _NCicloAdmCobranca = value; }
        }
        
        private Int64 _IDTipoMeioCobranca;
        public Int64 IDTipoMeioCobranca
        {
            get { return _IDTipoMeioCobranca; }
            set { _IDTipoMeioCobranca = value; }
        }
        
        private Int64 _IDProduto;
        public Int64 IDProduto
        {
            get { return _IDProduto; }
            set { _IDProduto = value; }
        }

        private String _IDCampanha;
        public String IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
        {
            get { return _Flag_Ativo; }
            set { _Flag_Ativo = value; }
        }
    }

    public class dtoTipoMeioCobranca
    {
        public dtoTipoMeioCobranca()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDTipoMeioCobranca;
        public Int64 IDTipoMeioCobranca
        {
            get { return _IDTipoMeioCobranca; }
            set { _IDTipoMeioCobranca = value; }
        }

        private String _TipoMeioCobranca;
        public String TipoMeioCobranca
        {
            get { return _TipoMeioCobranca; }
            set { _TipoMeioCobranca = value; }
        }

        private String _IDCampanha;
        public String IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
        {
            get { return _Flag_Ativo; }
            set { _Flag_Ativo = value; }
        }
    }

    public class dtoTipoCartao
    {
        public dtoTipoCartao()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private String _Codigo;
        public String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private String _TipoCartao;
        public String TipoCartao
        {
            get { return _TipoCartao; }
            set { _TipoCartao = value; }
        }

        private String _IDCampanha;
        public String IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
        {
            get { return _Flag_Ativo; }
            set { _Flag_Ativo = value; }
        }
    }

    public class dtoParcelamento
    {
        public dtoParcelamento()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private String _Codigo;
        public String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        
        private String _TipoParcelamento;
        public String TipoParcelamento
        {
            get { return _TipoParcelamento; }
            set { _TipoParcelamento = value; }
        }
        
        private String _IDProduto;
        public String IDProduto
        {
            get { return _IDProduto; }
            set { _IDProduto = value; }
        }

        private String _IDCampanha;
        public String IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private Int16 _Flag_Ativo;
        public Int16 Flag_Ativo
        {
            get { return _Flag_Ativo; }
            set { _Flag_Ativo = value; }
        }
    }
}
