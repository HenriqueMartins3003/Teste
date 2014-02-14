using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoImportExport
    {
        public dtoImportExport()
        { }
    }

    public class dtoImportExport_Header
    {
        public dtoImportExport_Header()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _HeaderID;
        public Int64 HeaderID
        {
            get { return _HeaderID; }
            set { _HeaderID = value; }
        }

        private String _HeaderName;
        public String HeaderName
        {
            get { return _HeaderName; }
            set { _HeaderName = value; }
        }

        private String _HeaderSeparator;
        public String HeaderSeparator
        {
            get { return _HeaderSeparator; }
            set { _HeaderSeparator = value; }
        }

        private Int32 _HeaderLineSize;
        public Int32 HeaderLineSize
        {
            get { return _HeaderLineSize; }
            set { _HeaderLineSize = value; }
        }

        private Int32 _HeaderInitialLine;
        public Int32 HeaderInitialLine
        {
            get { return _HeaderInitialLine; }
            set { _HeaderInitialLine = value; }
        }

        private Boolean _HeaderStatus;
        public Boolean HeaderStatus
        {
            get { return _HeaderStatus; }
            set { _HeaderStatus = value; }
        }
    }

    public class dtoImportExport_Trailer
    {
        public dtoImportExport_Trailer()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _TrailerID;
        public Int64 TrailerID
        {
            get { return _TrailerID; }
            set { _TrailerID = value; }
        }

        private String _TrailerName;
        public String TrailerName
        {
            get { return _TrailerName; }
            set { _TrailerName = value; }
        }

        private String _TrailerSeparator;
        public String TrailerSeparator
        {
            get { return _TrailerSeparator; }
            set { _TrailerSeparator = value; }
        }

        private Int32 _TrailerLineSize;
        public Int32 TrailerLineSize
        {
            get { return _TrailerLineSize; }
            set { _TrailerLineSize = value; }
        }

        private Boolean _TrailerStatus;
        public Boolean TrailerStatus
        {
            get { return _TrailerStatus; }
            set { _TrailerStatus = value; }
        }
    }

    public class dtoImportExport_Registry
    {
        public dtoImportExport_Registry()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _RegistryID;
        public Int64 RegistryID
        {
            get { return _RegistryID; }
            set { _RegistryID = value; }
        }

        private String _RegistryName;
        public String RegistryName
        {
            get { return _RegistryName; }
            set { _RegistryName = value; }
        }

        private String _RegistrySeparator;
        public String RegistrySeparator
        {
            get { return _RegistrySeparator; }
            set { _RegistrySeparator = value; }
        }

        private Int32 _RegistryLineSize;
        public Int32 RegistryLineSize
        {
            get { return _RegistryLineSize; }
            set { _RegistryLineSize = value; }
        }

        private Int32 _RegistryInitialLine;
        public Int32 RegistryInitialLine
        {
            get { return _RegistryInitialLine; }
            set { _RegistryInitialLine = value; }
        }

        private Boolean _RegistryStatus;
        public Boolean RegistryStatus
        {
            get { return _RegistryStatus; }
            set { _RegistryStatus = value; }
        }

    }

    public class dtoImportExport_Column
    {
        public dtoImportExport_Column()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _ColumnID;
        public Int64 ColumnID
        {
            get { return _ColumnID; }
            set { _ColumnID = value; }
        }

        private Int64 _RegistryID;
        public Int64 RegistryID
        {
            get { return _RegistryID; }
            set { _RegistryID = value; }
        }

        private Int64 _RegistryHeaderID;
        public Int64 RegistryHeaderID
        {
            get { return _RegistryHeaderID; }
            set { _RegistryHeaderID = value; }
        }

        private Int64 _RegistryTrailerID;
        public Int64 RegistryTrailerID
        {
            get { return _RegistryTrailerID; }
            set { _RegistryTrailerID = value; }
        }

        private String _ColumnName;
        public String ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        private Int64 _InitialPosition;
        public Int64 InitialPosition
        {
            get { return _InitialPosition; }
            set { _InitialPosition = value; }
        }

        private Int64 _ColumnSize;
        public Int64 ColumnSize
        {
            get { return _ColumnSize; }
            set { _ColumnSize = value; }
        }

        private Int64 _ColumnNumber;
        public Int64 ColumnNumber
        {
            get { return _ColumnNumber; }
            set { _ColumnNumber = value; }
        }
        private Int64 _ColumnTypeID;
        public Int64 ColumnTypeID
        {
            get { return _ColumnTypeID; }
            set { _ColumnTypeID = value; }
        }

        private Int64 _ColumnGroup;
        public Int64 ColumnGroup
        {
            get { return _ColumnGroup; }
            set { _ColumnGroup = value; }
        }

        private Boolean _ColumnValidation;
        public Boolean ColumnValidation
        {
            get { return _ColumnValidation; }
            set { _ColumnValidation = value; }
        }

        private Boolean _ColumnStatus;
        public Boolean ColumnStatus
        {
            get { return _ColumnStatus; }
            set { _ColumnStatus = value; }
        }

        private String _DatabaseTable;
        public String DatabaseTable
        {
            get { return _DatabaseTable; }
            set { _DatabaseTable = value; }
        }

        private String _DatabaseColumn;
        public String DatabaseColumn
        {
            get { return _DatabaseColumn; }
            set { _DatabaseColumn = value; }
        }

        private Boolean _ColumnJoin;
        public Boolean ColumnJoin
        {
            get { return _ColumnJoin; }
            set { _ColumnJoin = value; }
        }

        private String _TextAlign;
        public String TextAlign
        {
            get { return _TextAlign; }
            set { _TextAlign = value; }
        }

        private String _TextComplement;
        public String TextComplement
        {
            get { return _TextComplement; }
            set { _TextComplement = value; }
        }

        private String _DefaultValue;
        public String DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        }

        private Boolean _DefaultMandatory;
        public Boolean DefaultMandatory
        {
            get { return _DefaultMandatory; }
            set { _DefaultMandatory = value; }
        }

        private Int64 _TableID;
        public Int64 TableID
        {
            get { return _TableID; }
            set { _TableID = value; }
        }
    }

    public class dtoImportExport_ColumnType
    {
        public dtoImportExport_ColumnType()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _ColumnTypeID;
        public Int64 ColumnTypeID
        {
            get { return _ColumnTypeID; }
            set { _ColumnTypeID = value; }
        }

        private String _ColumnType;
        public String ColumnType
        {
            get { return _ColumnType; }
            set { _ColumnType = value; }
        }

        private String _ColumnTypeDescription;
        public String ColumnTypeDescription
        {
            get { return _ColumnTypeDescription; }
            set { _ColumnTypeDescription = value; }
        }

        private Boolean _HeaderColumn;
        public Boolean HeaderColumn
        {
            get { return _HeaderColumn; }
            set { _HeaderColumn = value; }
        }

        private Boolean _TrailerColumn;
        public Boolean TrailerColumn
        {
            get { return _TrailerColumn; }
            set { _TrailerColumn = value; }
        }

        private Boolean _RegistryColumn;
        public Boolean RegistryColumn
        {
            get { return _RegistryColumn; }
            set { _RegistryColumn = value; }
        }

        private Boolean _ImportProcess;
        public Boolean ImportProcess
        {
            get { return _ImportProcess; }
            set { _ImportProcess = value; }
        }

        private Boolean _ExportProcess;
        public Boolean ExportProcess
        {
            get { return _ExportProcess; }
            set { _ExportProcess = value; }
        }

        private Boolean _ColumnTypeStatus;
        public Boolean ColumnTypeStatus
        {
            get { return _ColumnTypeStatus; }
            set { _ColumnTypeStatus = value; }
        }

        private Boolean _ColumnTypeStatusDescription;
        public Boolean ColumnTypeStatusDescription
        {
            get { return _ColumnTypeStatusDescription; }
            set { _ColumnTypeStatusDescription = value; }
        }

    }

    public class dtoImportExport_Rules
    {
        public dtoImportExport_Rules()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _RulesID;
        public Int64 RulesID
        {
            get { return _RulesID; }
            set { _RulesID = value; }
        }

        private String _RulesName;
        public String RulesName
        {
            get { return _RulesName; }
            set { _RulesName = value; }
        }

        private String _Campaign;
        public String Campaign
        {
            get { return _Campaign; }
            set { _Campaign = value; }
        }

        private Boolean _LotStatus;
        public Boolean LotStatus
        {
            get { return _LotStatus; }
            set { _LotStatus = value; }
        }

        private String _LotStatusDescription;
        public String LotStatusDescription
        {
            get { return _LotStatusDescription; }
            set { _LotStatusDescription = value; }
        }

        private Boolean _RegistryStatus;
        public Boolean RegistryStatus
        {
            get { return _RegistryStatus; }
            set { _RegistryStatus = value; }
        }

        private String _RegistryStatusDescription;
        public String RegistryStatusDescription
        {
            get { return _RegistryStatusDescription; }
            set { _RegistryStatusDescription = value; }
        }

        private Boolean _CheckRaw;
        public Boolean CheckRaw
        {
            get { return _CheckRaw; }
            set { _CheckRaw = value; }
        }

        private String _CheckRawDescription;
        public String CheckRawDescription
        {
            get { return _CheckRawDescription; }
            set { _CheckRawDescription = value; }
        }



        private Boolean _RulesStatus;
        public Boolean RulesStatus
        {
            get { return _RulesStatus; }
            set { _RulesStatus = value; }
        }

        private String _RulesStatusDescription;
        public String RulesStatusDescription
        {
            get { return _RulesStatusDescription; }
            set { _RulesStatusDescription = value; }
        }

        private Boolean _OldLotStatus;
        public Boolean OldLotStatus 
        {
            get { return _OldLotStatus; }
            set { _OldLotStatus = value; }
        }

    }

    public class dtoImportExport_RulesAfterProcess
    {
        public dtoImportExport_RulesAfterProcess()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _RulesID;
        public Int64 RulesID
        {
            get { return _RulesID; }
            set { _RulesID = value; }
        }

        private String _RulesName;
        public String RulesName
        {
            get { return _RulesName; }
            set { _RulesName = value; }
        }

        private Int64 _ProcessID;
        public Int64 ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        private String _Campaign;
        public String Campaign
        {
            get { return _Campaign; }
            set { _Campaign = value; }
        }

        private Int64 _SegmentingID;
        public Int64 SegmentingID
        {
            get { return _SegmentingID; }
            set { _SegmentingID = value; }
        }

        private Boolean _RulesStatus;
        public Boolean RulesStatus
        {
            get { return _RulesStatus; }
            set { _RulesStatus = value; }
        }
    }

    public class dtoImportExport_RulesBeforeProcess
    {
        public dtoImportExport_RulesBeforeProcess()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _RulesID;
        public Int64 RulesID
        {
            get { return _RulesID; }
            set { _RulesID = value; }
        }

        private String _RulesName;
        public String RulesName
        {
            get { return _RulesName; }
            set { _RulesName = value; }
        }

        private Int64 _ProcessID;
        public Int64 ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        private String _Campaign;
        public String Campaign
        {
            get { return _Campaign; }
            set { _Campaign = value; }
        }

        private Boolean _DisableAncientID;
        public Boolean DisableAncientID
        {
            get { return _DisableAncientID; }
            set { _DisableAncientID = value; }
        }

        private Boolean _RulesStatus;
        public Boolean RulesStatus
        {
            get { return _RulesStatus; }
            set { _RulesStatus = value; }
        }

        private String _CampanhasAssociadas;
        public String CampanhasAssociadas
        {
            get { return _CampanhasAssociadas; }
            set { _CampanhasAssociadas = value; }
        }
    }

    public class dtoImportExport_Ambient
    {
        public dtoImportExport_Ambient()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _AmbientID;
        public Int64 AmbientID
        {
            get { return _AmbientID; }
            set { _AmbientID = value; }
        }

        private String _Ambient;
        public String Ambient
        {
            get { return _Ambient; }
            set { _Ambient = value; }
        }


    }

    public class dtoImportExport_Process
    {
        public dtoImportExport_Process()
        {}

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _ProcessID;
        public Int64 ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        private String _ProcessName;
        public String ProcessName
        {
            get { return _ProcessName; }
            set { _ProcessName = value; }
        }

        private String _ProcessDescription;
        public String ProcessDescription
        {
            get { return _ProcessDescription; }
            set { _ProcessDescription = value; }
        }

        private Int64 _ProcessTypeID;
        public Int64 ProcessTypeID
        {
            get { return _ProcessTypeID; }
            set { _ProcessTypeID = value; }
        }

        private String _ProcessTypeName;
        public String ProcessTypeName
        {
            get { return _ProcessTypeName; }
            set { _ProcessTypeName = value; }
        }

        private String _LotMask;
        public String LotMask
        {
            get { return _LotMask; }
            set { _LotMask = value; }
        }

        private Boolean _LotControlbyCampaign;
        public Boolean LotControlbyCampaign
        {
            get { return _LotControlbyCampaign; }
            set { _LotControlbyCampaign = value; }
        }

        private Int64 _RegistryHeaderID;
        public Int64 RegistryHeaderID
        {
            get { return _RegistryHeaderID; }
            set { _RegistryHeaderID = value; }
        }

        private Int64 _RegistryTrailerID;
        public Int64 RegistryTrailerID
        {
            get { return _RegistryTrailerID; }
            set { _RegistryTrailerID = value; }
        }

        private Int64 _RegistryID;
        public Int64 RegistryID
        {
            get { return _RegistryID; }
            set { _RegistryID = value; }
        }

        private Int64 _RulesID;
        public Int64 RulesID
        {
            get { return _RulesID; }
            set { _RulesID = value; }
        }

        private Int64 _ExecutionPlanID;
        public Int64 ExecutionPlanID
        {
            get { return _ExecutionPlanID; }
            set { _ExecutionPlanID = value; }
        }

        private Boolean _ProcessStatus;
        public Boolean ProcessStatus
        {
            get { return _ProcessStatus; }
            set { _ProcessStatus = value; }
        }

        private String _ProcessStatusDescription;
        public String ProcessStatusDescription
        {
            get { return _ProcessStatusDescription; }
            set { _ProcessStatusDescription = value; }
        }
    }

    public class dtoImportExport_ProcessType
    {
        public dtoImportExport_ProcessType()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _ProcessTypeID;
        public Int64 ProcessTypeID
        {
            get { return _ProcessTypeID; }
            set { _ProcessTypeID = value; }
        }

        private String _ProcessTypeName;
        public String ProcessTypeName
        {
            get { return _ProcessTypeName; }
            set { _ProcessTypeName = value; }
        }

        private String _ProcessTypeDescription;
        public String ProcessTypeDescription
        {
            get { return _ProcessTypeDescription; }
            set { _ProcessTypeDescription = value; }
        }

        private Boolean _ProcessTypeStatus;
        public Boolean ProcessTypeStatus
        {
            get { return _ProcessTypeStatus; }
            set { _ProcessTypeStatus = value; }
        }

        private String _ProcessTypeStatusDescription;
        public String ProcessTypeStatusDescription
        {
            get { return _ProcessTypeStatusDescription; }
            set { _ProcessTypeStatusDescription = value; }
        }
    }

    public class dtoImportExport_Segmenting
    {
        public dtoImportExport_Segmenting()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDSegmentacao;
        public Int64 IDSegmentacao
        {
            get { return _IDSegmentacao; }
            set { _IDSegmentacao = value; }
        }
     
        private String _NomeSegmentacao;
        public String NomeSegmentacao
        {
            get { return _NomeSegmentacao; }
            set { _NomeSegmentacao = value; }
        }
    }

    public class dtoImportExport_ExecutionPlan
    {
        public dtoImportExport_ExecutionPlan()
        {}
        
        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _ExecutionPlanID;
        public Int64 ExecutionPlanID
        {
          get { return _ExecutionPlanID; }
          set { _ExecutionPlanID = value; }
        }

        private String _ExecutionPlan;
        public String ExecutionPlan
        {
            get { return _ExecutionPlan; }
            set { _ExecutionPlan = value; }
        }

        private String _ExecutionPlanDescription;
        public String ExecutionPlanDescription
        {
            get { return _ExecutionPlanDescription; }
            set { _ExecutionPlanDescription = value; }
        }

        private Int64 _ExecutionPlanTypeID;
        public Int64 ExecutionPlanTypeID
        {
            get { return _ExecutionPlanTypeID; }
            set { _ExecutionPlanTypeID = value; }
        }

        private String _ExecutionPlanTypeDescription;
        public String ExecutionPlanTypeDescription
        {
            get { return _ExecutionPlanTypeDescription; }
            set { _ExecutionPlanTypeDescription = value; }
        }

        private DateTime _ExecutionDateTime = Convert.ToDateTime("1900-01-01 00:00:00");
        public DateTime ExecutionDateTime
        {
            get { return _ExecutionDateTime; }
            set { _ExecutionDateTime = value; }
        }

        private Int64 _FrequencyID;
        public Int64 FrequencyID
        {
            get { return _FrequencyID; }
            set { _FrequencyID = value; }
        }

        private String _FrequencyDescription;
        public String FrequencyDescription
        {
            get { return _FrequencyDescription; }
            set { _FrequencyDescription = value; }
        }

        private Boolean _Monday;
        public Boolean Monday
        {
            get { return _Monday; }
            set { _Monday = value; }
        }

        private Boolean _Tuesday;
        public Boolean Tuesday
        {
            get { return _Tuesday; }
            set { _Tuesday = value; }
        }

        private Boolean _Wednesday;
        public Boolean Wednesday
        {
            get { return _Wednesday; }
            set { _Wednesday = value; }
        }

        private Boolean _Thursday;
        public Boolean Thursday
        {
            get { return _Thursday; }
            set { _Thursday = value; }
        }

        private Boolean _Friday;
        public Boolean Friday
        {
            get { return _Friday; }
            set { _Friday = value; }
        }

        private Boolean _Saturday;
        public Boolean Saturday
        {
            get { return _Saturday; }
            set { _Saturday = value; }
        }

        private Boolean _Sunday;
        public Boolean Sunday
        {
            get { return _Sunday; }
            set { _Sunday = value; }
        }

        private Boolean _FirstWeek;
        public Boolean FirstWeek
        {
            get { return _FirstWeek; }
            set { _FirstWeek = value; }
        }

        private Boolean _SecondWeek;
        public Boolean SecondWeek
        {
            get { return _SecondWeek; }
            set { _SecondWeek = value; }
        }

        private Boolean _ThirdWeek;
        public Boolean ThirdWeek
        {
            get { return _ThirdWeek; }
            set { _ThirdWeek = value; }
        }

        private Boolean _FourthWeek;
        public Boolean FourthWeek
        {
            get { return _FourthWeek; }
            set { _FourthWeek = value; }
        }

        private Int64 _FrequencyInterval;
        public Int64 FrequencyInterval
        {
            get { return _FrequencyInterval; }
            set { _FrequencyInterval = value; }
        }

        
        private DateTime _StartDateTime = Convert.ToDateTime("1900-01-01 00:00:00");
        public DateTime StartDateTime
        {
            get { return _StartDateTime; }
            set { _StartDateTime = value; }
        }

        private DateTime _EndDateTime = Convert.ToDateTime("1900-01-01 00:00:00");
        public DateTime EndDateTime
        {
            get { return _EndDateTime; }
            set { _EndDateTime = value; }
        }

        private Boolean _ExecutionPlanStatus;
        public Boolean ExecutionPlanStatus
        {
            get { return _ExecutionPlanStatus; }
            set { _ExecutionPlanStatus = value; }
        }

        private String _ExecutionPlanStatusDescription;
        public String ExecutionPlanStatusDescription
        {
            get { return _ExecutionPlanStatusDescription; }
            set { _ExecutionPlanStatusDescription = value; }
        }
    }

    public class dtoImportExport_ExecutionPlanType
    {
        public dtoImportExport_ExecutionPlanType()
        {}

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _ExecutionPlanTypeID;
        public Int64 ExecutionPlanTypeID
        {
            get { return _ExecutionPlanTypeID; }
            set { _ExecutionPlanTypeID = value; }
        }

        private String _ExecutionPlanType;
        public String ExecutionPlanType
        {
            get { return _ExecutionPlanType; }
            set { _ExecutionPlanType = value; }
        }

        private String _ExecutionPlanTypeDescription;
        public String ExecutionPlanTypeDescription
        {
            get { return _ExecutionPlanTypeDescription; }
            set { _ExecutionPlanTypeDescription = value; }
        }

        private Boolean _ExecutionPlanTypeStatus;
        public Boolean ExecutionPlanTypeStatus
        {
            get { return _ExecutionPlanTypeStatus; }
            set { _ExecutionPlanTypeStatus = value; }
        }

        private String _ExecutionPlanTypeStatusDescription;
        public String ExecutionPlanTypeStatusDescription
        {
            get { return _ExecutionPlanTypeStatusDescription; }
            set { _ExecutionPlanTypeStatusDescription = value; }
        }

    }

    public class dtoImportExport_ExecutionPlanFrequency
    {
        public dtoImportExport_ExecutionPlanFrequency()
        {}

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _FrequencyID;
        public Int64 FrequencyID
        {
            get { return _FrequencyID; }
            set { _FrequencyID = value; }
        }

        private String _Frequency;
        public String Frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }

        private String _FrequencyDescription;
        public String FrequencyDescription
        {
            get { return _FrequencyDescription; }
            set { _FrequencyDescription = value; }
        }

        private Boolean _FrequencyStatus;
        public Boolean FrequencyStatus
        {
            get { return _FrequencyStatus; }
            set { _FrequencyStatus = value; }
        }

        private String _FrequencyStatusDescription;
        public String FrequencyStatusDescription
        {
            get { return _FrequencyStatusDescription; }
            set { _FrequencyStatusDescription = value; }
        }

    }

    public class dtoImportExport_ExportQuery
    {
        public dtoImportExport_ExportQuery()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _ExportQueryID;
        public Int64 ExportQueryID
        {
            get { return _ExportQueryID; }
            set { _ExportQueryID = value; }
        }

        private Int64 _RulesID;
        public Int64 RulesID
        {
            get { return _RulesID; }
            set { _RulesID = value; }
        }

        private String _Query;
        public String Query
        {
            get { return _Query; }
            set { _Query = value; }
        }

        private Boolean _ExportQueryStatus;
        public Boolean ExportQueryStatus
        {
            get { return _ExportQueryStatus; }
            set { _ExportQueryStatus = value; }
        }
    }

    public class dtoImportExport_Files
    {
        public dtoImportExport_Files()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _FileID;
        public Int64 FileID
        {
            get { return _FileID; }
            set { _FileID = value; }
        }

        private Int64 _ProcessID;
        public Int64 ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        private String _FileName;
        public String FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        private String _FileExtension;
        public String FileExtension
        {
            get { return _FileExtension; }
            set { _FileExtension = value; }
        }

        private String _FileLocation;
        public String FileLocation
        {
            get { return _FileLocation; }
            set { _FileLocation = value; }
        }

        private String _FileLocationBackup;
        public String FileLocationBackup
        {
            get { return _FileLocationBackup; }
            set { _FileLocationBackup = value; }
        }

        private Int64 _FilesTypeID;
        public Int64 FilesTypeID
        {
            get { return _FilesTypeID; }
            set { _FilesTypeID = value; }
        }

        private Boolean _FileStatus;
        public Boolean FileStatus
        {
            get { return _FileStatus; }
            set { _FileStatus = value; }
        }
    }

    public class dtoImportExport_FilesType
    {
        public dtoImportExport_FilesType()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _FilesTypeID;
        public Int64 FilesTypeID
        {
            get { return _FilesTypeID; }
            set { _FilesTypeID = value; }
        }

        private String _FilesType;
        public String FilesType
        {
            get { return _FilesType; }
            set { _FilesType = value; }
        }

        private Boolean _FilesTypeStatus;
        public Boolean FilesTypeStatus
        {
            get { return _FilesTypeStatus; }
            set { _FilesTypeStatus = value; }
        }

        private String _FilesTypeStatusDescription;
        public String FilesTypeStatusDescription
        {
            get { return _FilesTypeStatusDescription; }
            set { _FilesTypeStatusDescription = value; }
        }

    }

    public class dtoImportExport_Logs
    {
        public dtoImportExport_Logs()
        { }

        private String _StartDatetime;
        public String StartDatetime
        {
            get { return _StartDatetime; }
            set { _StartDatetime = value; }
        }

        private String _EndDatetime;
        public String EndDatetime
        {
            get { return _EndDatetime; }
            set { _EndDatetime = value; }
        }

        private String _CampaignID;
        public String CampaignID
        {
            get { return _CampaignID; }
            set { _CampaignID = value; }
        }

        private Int64 _ProcessID;
        public Int64 ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        private String filename;

        public String FileName
        {
            get { return filename; }
            set { filename = value; }
        }

    }

    public class dtoImportExport_RulesCampaign
    {
        public dtoImportExport_RulesCampaign()
        { }

        private Int32 _Task;
        public Int32 Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Int64 _IDRulesCampaign;
        public Int64 IDRulesCampaign
        {
            get { return _IDRulesCampaign; }
            set { _IDRulesCampaign = value; }
        }

        private String _Campaign;
        public String Campaign
        {
            get { return _Campaign; }
            set { _Campaign = value; }
        }

        private String _TableColumn;
        public String TableColumn
        {
            get { return _TableColumn; }
            set { _TableColumn = value; }
        }

        private String _Data;
        public String Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
    }
}
