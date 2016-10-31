using System;
using BOOL = System.Int32;
using System.Runtime.InteropServices;

namespace NCCCommon.ModuleProtocol.Omap
{
    [DspMsg(MsgType.MsgType_Conf_Module)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DSPMsg_ModuleConfig
    {
        public int AlarmBufferMode;
    }

    [DspMsg(MsgType.MsgType_Session_Init)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DSPMsg_SessionInit
    {
        public int InitType;
    }

    [DspMsg(MsgType.MsgType_Conf_Keyphasor)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DSPMsg_Keyphasor
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
    public struct DSPMsg_DisChannel			//진동 변위 채널	/*수정*/  
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
    public struct DSPMsg_AbsDisChannel			//진동 절대 변위 채널	/*수정*/ 
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
    public struct DSPMsg_ThrustChannel			//진동 트러스트 채널	/*추가*/
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
    public struct DSPMsg_EccChannel			//Ecc 채널	/*추가*/
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
    public struct DSPMsg_DiffExpChannel			//DiffExp 채널	/*추가*/
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
    public struct DSPMsg_DiffRampChannel			//DiffRamp 채널	/*추가*/
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
    public struct DSPMsg_CaseExpChannel			//DiffRamp 채널	/*추가*/
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
    public struct DSPMsg_AccChannel			//진동 가속도 속도 채널	/*추가*/
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
    public struct DSPMsg_DcChannel			//진동 DC 채널		/*수정*/ 
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
    public struct DSPMsg_ReverseRotationChannel			//Reverse Rotation 채널	/*추가*/
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

    [DspMsg(MsgType.MsgType_Response)]
    [StructLayout(LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct DSPMsg_CommandResponse
    {
        public int ResponseCode;	//응답코드(enum ResponseCodeTyoe 값)
        //public fixed char Args[252];		//응답정보

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 252)]
        public string Args;
    }

    [DspMsg(MsgType.MsgType_Conf_SampleMode)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DSPMsg_SampleMode
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
    public struct DSPMsg_SampleModeAmp
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
    public struct DSPMsg_HWAlarmConfig
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
    public struct DSPMsg_AlarmFunction
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
    public struct DSPMsg_ModbusRecordOutput			//진동 DC 채널		/*수정*/ 
    {
        public int Id;
        //public int ModuleId;
        public int PhysicalCh;
        public int MROType;       // 0: Direct, 1: Gap, 2: 1X Direct, 3: 1X Phase, 4:rpm, 5:cre, 6:band
        public int MRORange;
        public int MRORangeLow;  // Sin 최소값 추가
        //public BOOL RecordOutActive;
    }

    [DspMsg(MsgType.MsgType_Data_WaveData)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DSPMsg_WaveData
    {
        public uint Idx;
        public int ChannelId;
        public int SaveType;
        public UtcAndMiliseconds DateTime;
        public float Rpm;
        public int SyncDataCount;
        public int AsyncDataCount;
        public float[] SyncData;
        public float[] AsyncData;

        public static DSPMsg_WaveData Parse(DspMessage msg)
        {
            var data = new DSPMsg_WaveData();
            int i = 0;
            var buff = msg.Data;

            i += ReadHeader(ref data, i, buff);

            i += ReadBody(ref data, i, buff);

            return data;
        }

        public static WaveData ParseWave(DspMessage msg)
        {
            var oMapWave = Parse(msg);
            var wave = new WaveData();
            wave.Idx = oMapWave.Idx;
            wave.DateTime = oMapWave.DateTime.ToLocalDateTime();
            wave.ChannelId = oMapWave.ChannelId;
            wave.AsyncData = oMapWave.AsyncData;
            wave.AsyncDataCount = oMapWave.AsyncDataCount;
            wave.Rpm = oMapWave.Rpm;
            wave.SaveType = oMapWave.SaveType;
            wave.SyncData = oMapWave.SyncData;
            wave.SyncDataCount = oMapWave.SyncDataCount;

            return wave;
        }

        public static DSPMsg_WaveData ParseHeader(DspMessage msg)
        {
            var data = new DSPMsg_WaveData();
            int i = 0;
            var buff = msg.Data;
            ReadHeader(ref data, i, buff);

            return data;
        }

        internal static int ReadHeader(ref DSPMsg_WaveData data, int i, byte[] buff)
        {
            data.Idx = (uint)ByteUtil.ReadInt32(buff, i);
            i += 4;
            data.ChannelId = ByteUtil.ReadInt32(buff, i);
            i += 4;
            data.SaveType = ByteUtil.ReadInt32(buff, i);
            i += 4;

            data.DateTime.UtcSeconds = ByteUtil.ReadInt32(buff, i);
            i += 4;
            data.DateTime.Miliseconds = ByteUtil.ReadInt32(buff, i);
            i += 4;

            data.Rpm = ByteUtil.ReadFloat(buff, i);
            i += 4;

            data.SyncDataCount = ByteUtil.ReadInt32(buff, i);
            i += 4;
            data.AsyncDataCount = ByteUtil.ReadInt32(buff, i);
            i += 4;

            //아래는 C구조체의 주소 저장부분
            i += 4;
            i += 4;

            return i;
        }

        internal static int ReadBody(ref DSPMsg_WaveData data, int i, byte[] buff)
        {
            data.SyncData = new float[data.SyncDataCount];
            int syncDataSize = sizeof(float) * data.SyncDataCount;
            Buffer.BlockCopy(buff, i, data.SyncData, 0, syncDataSize);
            i += syncDataSize;

            data.AsyncData = new float[data.AsyncDataCount];
            int asyncDataSize = sizeof(float) * data.AsyncDataCount;
            var overSize = (asyncDataSize + i) - buff.Length;
            if (overSize > 0)
                asyncDataSize -= overSize;

            Buffer.BlockCopy(buff, i, data.AsyncData, 0, asyncDataSize);
            i += asyncDataSize;
            return i;
        }

        public byte[] ToBytes()
        {
            int syncDataSize = sizeof(float) * SyncDataCount;
            int asyncDataSize = sizeof(float) * AsyncDataCount;

            var buff = new byte[8 * 4 + syncDataSize + asyncDataSize + 2 * 4];
            int i = 0;

            i += ByteUtil.WriteInt32((int)Idx, buff, i);
            i += ByteUtil.WriteInt32((int)ChannelId, buff, i);
            i += ByteUtil.WriteInt32((int)SaveType, buff, i);
            i += ByteUtil.WriteInt32(DateTime.UtcSeconds, buff, i);
            i += ByteUtil.WriteInt32((int)DateTime.Miliseconds, buff, i);
            i += ByteUtil.WriteFloat(Rpm, buff, i);
            i += ByteUtil.WriteInt32(SyncDataCount, buff, i);
            i += ByteUtil.WriteInt32(AsyncDataCount, buff, i);

            i += 4;
            i += 4;

            Buffer.BlockCopy(SyncData, 0, buff, i, syncDataSize);
            i += syncDataSize;

            Buffer.BlockCopy(AsyncData, 0, buff, i, asyncDataSize);
            i += asyncDataSize;

            return buff;
        }
    }

    [DspMsg(MsgType.MsgType_Data_VectorData)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DSPMsg_VectorData
    {
        public uint Idx;
        public int ChannelId;
        public int SaveType;
        public UtcAndMiliseconds DateTime;
        public float Rpm;
        public float Gap;            // null 가능
        public float Direct;
        public float OneXAmp;        // null 가능
        public float OneXPhase;      // null 가능
        public float TwoXAmp;        // null 가능
        public float TwoXPhase;      // null 가능
        public float NXAmp;          // null 가능
        public float NXPhase;        // null 가능
        public float Bandpass;       // null 가능
        public float CrestFactor;    // null 가능

        public VectorData ParseVector(DSPMsg_VectorData msg)
        {
            return new VectorData()
            {
                Idx = Idx,
                ChannelId = ChannelId,
                SaveType = SaveType,
                DateTime = DateTime,
                Rpm = Rpm,
                Gap = Gap,
                Direct = Direct,
                OneXAmp = OneXAmp,
                OneXPhase = OneXPhase,
                TwoXAmp = TwoXAmp,
                TwoXPhase = TwoXPhase,
                NXAmp = NXAmp,
                NXPhase = NXPhase,
                Bandpass = Bandpass,
                CrestFactor = CrestFactor
            };
        }
    }
}
