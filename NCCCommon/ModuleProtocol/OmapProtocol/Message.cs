using System;
using BOOL = System.Int32;
using System.Runtime.InteropServices;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    [DspMsg(MsgType.MsgType_Conf_Module)]
    [StructLayout(LayoutKind.Sequential)]
    public struct ModuleConfig
    {
        public int AlarmBufferMode;
    }

    [DspMsg(MsgType.MsgType_Conf_Keyphasor)]
    [StructLayout(LayoutKind.Sequential)]
    public struct Keyphasor
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL IsSimulated;
        public int SimulatedRpm;
        public float HysterisisVolt;		// null허용
        public BOOL AutoThreshold;		// null허용
        public float ThresholdVolt;		// null허용
        public int MaxRpm;
        public int PulsePerRev;
    }

    [DspMsg(MsgType.MsgType_Conf_DisChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DisChannel			//진동 변위 채널	/*수정*/  
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit; 		/*추가*/
        public int KeyphasorId;
        public int Integral; 			/*추가*/
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        public float nX;
        public int BandLow;
        public int BandHigh;
        public int SyncSR;
        public int SyncRev;
        public int AsyncFMax;
        public int AsyncLine;
        //public BOOL ACDC;
    }

    [DspMsg(MsgType.MsgType_Conf_AbsDisChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct AbsDisChannel			//진동 절대 변위 채널	/*수정*/ 
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit; 		/*추가*/
        public int KeyphasorId;
        public int Integral; 			/*추가*/
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        public float nX;
        public int BandLow;
        public int BandHigh;
        public int SyncSR;
        public int SyncRev;
        public int AsyncFMax;
        public int AsyncLine;
        public int PloxChannelId;
        //public BOOL ACDC;
    }

    [DspMsg(MsgType.MsgType_Conf_ThrustChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct ThrustChannel			//진동 트러스트 채널	/*추가*/
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit;
        public int KeyphasorId;
        public int Integral;
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        //public BOOL ACDC;
        public float ThrustOffset; // 2013,02.20 추가
    }

    [DspMsg(MsgType.MsgType_Conf_EccChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct EccChannel			//Ecc 채널	/*추가*/
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit;
        public int KeyphasorId;
        public int Integral;
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        //public BOOL ACDC;
        public float ThrustOffset; // 2013,02.20 추가
    }

    [DspMsg(MsgType.MsgType_Conf_DiffExpChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DiffExpChannel			//DiffExp 채널	/*추가*/
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit;
        public int KeyphasorId;
        public int Integral;
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        //public BOOL ACDC;
        public float ThrustOffset; // 2013,02.20 추가
    }

    [DspMsg(MsgType.MsgType_Conf_DiffRampChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DiffRampChannel			//DiffRamp 채널	/*추가*/
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit;
        public int KeyphasorId;
        public int Integral;
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        //public BOOL ACDC;
        public float ThrustOffset; // 2013,02.20 추가
        public int PairChannelId; // 2013,02.20 추가
    }

    [DspMsg(MsgType.MsgType_Conf_CaseExpChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct CaseExpChannel			//DiffRamp 채널	/*추가*/
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit;
        public int KeyphasorId;
        public int Integral;
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        //public BOOL ACDC;
        public float ThrustOffset; // 2013,02.20 추가
        public int PairChannelId; // 2013,02.20 추가
    }

    [DspMsg(MsgType.MsgType_Conf_AccChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct AccChannel			//진동 가속도 속도 채널	/*추가*/
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit; 		/*추가*/
        public int KeyphasorId;
        public int Integral; 			/*추가*/
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        public float nX;
        public int BandLow;
        public int BandHigh;
        public int SyncSR;
        public int SyncRev;
        public int AsyncFMax;
        public int AsyncLine;
        //public BOOL ACDC;
    }

    [DspMsg(MsgType.MsgType_Conf_DcChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DcChannel			//진동 DC 채널		/*수정*/ 
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit; 		/*추가*/
        public int KeyphasorId;
        public float Sensitivity;
        public int HWGain;
        public BOOL ICP;
        public float Offset;
        //public BOOL ACDC;
    }

    [DspMsg(MsgType.MsgType_Conf_ReverseRoationChannel)]
    [StructLayout(LayoutKind.Sequential)]
    public struct ReverseRotationChannel			//Reverse Rotation 채널	/*추가*/
    {
        public int Id;
        public int ModuleId;
        public int PhysicalCh;
        public int Angle;
        public BOOL Active;
        public int TransducerUnit;		// null허용
        public int TransducerUnit2;	// null허용
        public int DisplayUnit;
        public int KeyphasorId;
        public int Integral;
        public float Sensitivity;
        public int HWGain;
        public int Bandwidth;
        public BOOL ICP;
        public int PairChannelId; // 2013,02.20 추가
    }


    [DspMsg(MsgType.MsgType_Conf_SampleMode)]
    [StructLayout(LayoutKind.Sequential)]
    public struct SampleMode
    {
        public int Id;
        public int KeyphasorId;
        public int TransRpm;
        public int NormalRpm;
        public int OverRpm;
        public int NormalInterval;
        public int TranTernRpm;
        public int WaveInterval;
        public BOOL AmpActive;
        public BOOL TransientActive;
        public int AlarmBufferMode;
    }

    [DspMsg(MsgType.MsgType_Conf_SampleModeAmp)]
    [StructLayout(LayoutKind.Sequential)]
    public struct SampleModeAmp
    {
        public int Id;
        public int ChannelId;
        public BOOL Active;
        public int Function;
        public BOOL IncreaseActive;
        public float IncreaseValue;		// null허용
        public BOOL DecreaseActive;
        public float DecreaseValue;		// null허용
    }

    [DspMsg(MsgType.MsgType_Conf_HWAlarmConfig)]
    //채널마다 2개의 HWAlarmConfig가 존재(Alert, Danger)
    [StructLayout(LayoutKind.Sequential)]
    public struct HWAlarmConfig
    {
        public int Id;
        public int ChannelId;
        public int AlarmType2;    //0:Alert, 1:Danger
        public int DigitalOutCh;
        public int Delay;
    }

    [DspMsg(MsgType.MsgType_Conf_HWAlarmFunction)]
    //HWAlarmConfig 마다 여러개의 AlarmFunction이 존재
    [StructLayout(LayoutKind.Sequential)]
    public struct AlarmFunction
    {
        public int Id;
        public int AlarmId;
        public BOOL Active;
        //public AlarmFuncVariable Variable;
        //public AlarmFuncType Type;
        public int Variable;
        public int Type;
        public float Low;
        public float High;
    }

    [DspMsg(MsgType.MsgType_Conf_RecordOutput)]
    [StructLayout(LayoutKind.Sequential)]
    public struct ModbusRecordOutput			//진동 DC 채널		/*수정*/ 
    {
        public int Id;
        //public int ModuleId;
        public int PhysicalCh;
        public int MROType;       // 0: Direct, 1: Gap, 2: 1X Direct, 3: 1X Phase, 4:rpm, 5:cre, 6:band
        public int MRORange;
        public int MRORangeLow;  // Sin 최소값 추가
        //public BOOL RecordOutActive;
    }
}
