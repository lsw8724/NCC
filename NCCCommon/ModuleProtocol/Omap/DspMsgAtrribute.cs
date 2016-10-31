using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.Omap
{
    public enum MsgType
    {
        MsgType_Unknown = 0x000,
        MsgType_Response = 0x001,
        MsgType_Session_Init = 0x002,

        MsgType_Cmd_Start = 0x101,
        MsgType_Cmd_Stop = 0x102,
        MsgType_Cmd_SetTime = 0x103,
        MsgType_Cmd_RealTime = 0x104,
        MsgType_Cmd_RemoveSDCard = 0x105,

        MsgType_Conf_Module = 0x200,
        MsgType_Conf_Keyphasor = 0x201,
        MsgType_Conf_DisChannel = 0x202,
        MsgType_Conf_AbsDisChannel = 0x203,
        MsgType_Conf_AccChannel = 0x204,
        MsgType_Conf_DcChannel = 0x205,
        MsgType_Conf_ThrustChannel = 0x206,

        MsgType_Conf_SampleMode = 0x207,
        MsgType_Conf_SampleModeAmp = 0x208,
        MsgType_Conf_HWAlarmConfig = 0x209,
        MsgType_Conf_HWAlarmFunction = 0x20A,
        MsgType_Conf_RecordOutput = 0x20B,

        // Eccentricity Channel 추가
        MsgType_Conf_EccChannel = 0x210,
        MsgType_Conf_DiffExpChannel = 0x211,
        MsgType_Conf_DiffRampChannel = 0x212,
        MsgType_Conf_CaseExpChannel = 0x213,
        MsgType_Conf_ReverseRoationChannel = 0x214, //rjy for Reverse Rotation

        //ExConfig는 구버전 펌웨어에서 무시됨
        MsgType_ExConf_SystemOkDO = 0x251,
        MsgType_ExConf_PeakWindowSize = 0x252,
        MsgType_ExConf_SampleModeAbsAmp = 0x253,
        MsgType_ExConf_AfterScheduler = 0x254,
        MsgType_ExConf_DspPath = 0x255,
        MsgType_ExConf_DspCms = 0x256,

        MsgType_Data_HeartBeat = 0x300,        //1분에 한번씩 전송
        MsgType_Data_VectorData = 0x301,
        MsgType_Data_WaveData = 0x302,
        MsgType_Data_AlarmLog = 0x303,
        MsgType_Data_EventLog = 0x304,
        MsgType_Data_WorkStatus = 0x305,
        MsgType_Data_ModuleVectors = 0x306,
        MsgType_Data_ModuleWaves = 0x307,

        MsgType_Display_HeartBeat = 0x400,                  //1분에 한번씩 전송
        MsgType_Display_RealTime = 0x401,                   //Display -> Agent 로 가는 메세지
        MsgType_Display_AlarmDigitalOutChange = 0x402,      //Agent -> Display
    };

    public class DspMsgAttribute : Attribute
    {
        public MsgType MsgType { get; set; }

        public DspMsgAttribute(MsgType msgType)
        {
            MsgType = msgType;
        }
    }
}
