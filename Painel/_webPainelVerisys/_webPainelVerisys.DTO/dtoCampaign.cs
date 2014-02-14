using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoCampaign
    {
        public dtoCampaign()
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

        private String _Campaign;
        public String Campaign
        {
            get { return _Campaign; }
            set { _Campaign = value; }
        }

        private String _NumeroLote;
        public String NumeroLote
        {
            get { return _NumeroLote; }
            set { _NumeroLote = value; }
        }

        private String _NomeLote;
        public String NomeLote
        {
            get { return _NomeLote; }
            set { _NomeLote = value; }
        }

        private String _NomeCampanha;
        public String NomeCampanha
        {
            get { return _NomeCampanha; }
            set { _NomeCampanha = value; }
        }

        private String _ChamadasAgenteLivre;
        public String ChamadasAgenteLivre
        {
            get { return _ChamadasAgenteLivre; }
            set { _ChamadasAgenteLivre = value; }
        }

        private Int32 _TempoAtendimento;
        public Int32 TempoAtendimento
        {
            get { return _TempoAtendimento; }
            set { _TempoAtendimento = value; }
        }

        private Int32 _NumeroTentativas;
        public Int32 NumeroTentativas
        {
            get { return _NumeroTentativas; }
            set { _NumeroTentativas = value; }
        }

        private Int32 _ReagendamentoNaoAtendimento;
        public Int32 ReagendamentoNaoAtendimento
        {
            get { return _ReagendamentoNaoAtendimento; }
            set { _ReagendamentoNaoAtendimento = value; }
        }

        private Int32 _ReagendamentoOcupado;
        public Int32 ReagendamentoOcupado
        {
            get { return _ReagendamentoOcupado; }
            set { _ReagendamentoOcupado = value; }
        }

        private Int32 _ReagendamentoCongestionamento;
        public Int32 ReagendamentoCongestionamento
        {
            get { return _ReagendamentoCongestionamento; }
            set { _ReagendamentoCongestionamento = value; }
        }

        private Int32 _NumeroTentativas_Congestionamento;
        public Int32 NumeroTentativas_Congestionamento
        {
            get { return _NumeroTentativas_Congestionamento; }
            set { _NumeroTentativas_Congestionamento = value; }
        }

        private Int32 _NumeroTentativas_NaoAtende;
        public Int32 NumeroTentativas_NaoAtende
        {
            get { return _NumeroTentativas_NaoAtende; }
            set { _NumeroTentativas_NaoAtende = value; }
        }

        private Int32 _NumeroTentativas_Ocupado;
        public Int32 NumeroTentativas_Ocupado
        {
            get { return _NumeroTentativas_Ocupado; }
            set { _NumeroTentativas_Ocupado = value; }
        }

        private Int32 _TempoClerical;
        public Int32 TempoClerical
        {
            get { return _TempoClerical; }
            set { _TempoClerical = value; }
        }

        private Boolean _IndiceCampoFoneNaoAtendimento;
        public Boolean IndiceCampoFoneNaoAtendimento
        {
            get { return _IndiceCampoFoneNaoAtendimento; }
            set { _IndiceCampoFoneNaoAtendimento = value; }
        }

        private Boolean _IndiceCampoFoneOcupado;
        public Boolean IndiceCampoFoneOcupado
        {
            get { return _IndiceCampoFoneOcupado; }
            set { _IndiceCampoFoneOcupado = value; }
        }

        private Boolean _IndiceCampoFoneCongestionamento;
        public Boolean IndiceCampoFoneCongestionamento
        {
            get { return _IndiceCampoFoneCongestionamento; }
            set { _IndiceCampoFoneCongestionamento = value; }
        }

        private String _QtdMaxChamadasSimultaneas;
        public String QtdMaxChamadasSimultaneas
        {
            get { return _QtdMaxChamadasSimultaneas; }
            set { _QtdMaxChamadasSimultaneas = value; }
        }

        private String _PrefixoClausulaWhere;
        public String PrefixoClausulaWhere
        {
            get { return _PrefixoClausulaWhere; }
            set { _PrefixoClausulaWhere = value; }
        }

        private String _IndiceAgressividadeMaximo;
        public String IndiceAgressividadeMaximo
        {
            get { return _IndiceAgressividadeMaximo; }
            set { _IndiceAgressividadeMaximo = value; }
        }

        private Int32 _TipoVarredura;
        public Int32 TipoVarredura
        {
            get { return _TipoVarredura; }
            set { _TipoVarredura = value; }
        }

        private String _MultiCampo;
        public String MultiCampo
        {
            get { return _MultiCampo; }
            set { _MultiCampo = value; }
        }

        private String _Modulo;
        public String Modulo
        {
            get { return _Modulo; }
            set { _Modulo = value; }
        }

        private Int32 _ModoDiscagem;
        public Int32 ModoDiscagem
        {
            get { return _ModoDiscagem; }
            set { _ModoDiscagem = value; }
        }

        private Int32 _IDRegra;
        public Int32 IDRegra
        {
            get { return _IDRegra; }
            set { _IDRegra = value; }
        }

        private Int32 _IDRegraRota;
        public Int32 IDRegraRota
        {
            get { return _IDRegraRota; }
            set { _IDRegraRota = value; }
        }

        private Boolean _RecadoCPAtivo;
        public Boolean RecadoCPAtivo
        {
            get { return _RecadoCPAtivo; }
            set { _RecadoCPAtivo = value; }
        }

        private Int32 _MetaCanaisSimultaneosEmAtendimento;
        public Int32 MetaCanaisSimultaneosEmAtendimento
        {
            get { return _MetaCanaisSimultaneosEmAtendimento; }
            set { _MetaCanaisSimultaneosEmAtendimento = value; }
        }

    }

    public class dtoCampaignMascara
    {
        public dtoCampaignMascara()
        { }

        private String _IDMascara;
        public String IDMascara
        {
            get { return _IDMascara; }
            set { _IDMascara = value; }
        }

        private String _Mascara;
        public String Mascara
        {
            get { return _Mascara; }
            set { _Mascara = value; }
        }

        private String _DDD;
        public String DDD
        {
            get { return _DDD; }
            set { _DDD = value; }
        }

        private String _Fone;
        public String Fone
        {
            get { return _Fone; }
            set { _Fone = value; }
        }
    }

    public class dtoCampaignRule
    {
        public dtoCampaignRule()
        { }

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

        private Int32 idSequenciamento;
        public Int32 IdSequenciamento
        {
            get { return idSequenciamento; }
            set { idSequenciamento = value; }
        }

        private String _NumeroRegra;
        public String NumeroRegra
        {
            get { return _NumeroRegra; }
            set { _NumeroRegra = value; }
        }

        private String _NomeRegra;
        public String NomeRegra
        {
            get { return _NomeRegra; }
            set { _NomeRegra = value; }
        }

        private String _IDModoAgrupamento;
        public String IDModoAgrupamento
        {
            get { return _IDModoAgrupamento; }
            set { _IDModoAgrupamento = value; }
        }

        private DateTime _HoraInicial;
        public DateTime HoraInicial
        {
            get { return _HoraInicial; }
            set { _HoraInicial = value; }
        }

        private DateTime _HoraFinal;
        public DateTime HoraFinal
        {
            get { return _HoraFinal; }
            set { _HoraFinal = value; }
        }

        private String _DefinicaoSequenciamento;
        public String DefinicaoSequenciamento
        {
            get { return _DefinicaoSequenciamento; }
            set { _DefinicaoSequenciamento = value; }
        }

        private String _DefinicaoSequenciamentoUserView;
        public String DefinicaoSequenciamentoUserView
        {
            get { return _DefinicaoSequenciamentoUserView; }
            set { _DefinicaoSequenciamentoUserView = value; }
        }


    }

    public class dtoModoAgrupamentoDia
    {
        public dtoModoAgrupamentoDia()
        { }

        private String _ID;
        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private String _Descricao;
        public String Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }
    }

    public class dtoCampaignGroup
    {
        public dtoCampaignGroup()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int32 _GrupoID;
        public Int32 GrupoID
        {
            get { return _GrupoID; }
            set { _GrupoID = value; }
        }

        private String _Grupo;
        public String Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }

        private Int32 _QtdeMaximaCanais;
        public Int32 QtdeMaximaCanais
        {
            get { return _QtdeMaximaCanais; }
            set { _QtdeMaximaCanais = value; }
        }

        private Int32 _Ativo;
        public Int32 Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }

        private String _Campaigns;
        public String Campaigns
        {
            get { return _Campaigns; }
            set { _Campaigns = value; }
        }
    }

    public class dtoIdentificadores
    {
        public dtoIdentificadores()
        { }

        private String _IDCampanha;
        public String IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private String _Identificador;
        public String Identificador
        {
            get { return _Identificador; }
            set { _Identificador = value; }
        }
    }
}
