using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCCCommon.ModuleProtocol.Daq5509Protocol
{
    public enum DaqCmdType : ushort
    {
        //_Start = 0x0001,
        //PING = 0x0001,
        DAQ_START = 0x0002,
        DAQ_STOP = 0x0003,
        DAQ_SAMPLE = 0x0004,
        DAQ_IN_TYPE = 0x0005,
        DAQ_GAIN = 0x0006,
        DAQ_OPMODE = 0x0007,
        DAQ_SYNCSET = 0x0008,
        DAQ_KEYSET = 0x0009,
        DAQ_DOSET = 0x000A,
        //DAQ_ETHSET = 0x000B,
        //_End = 0x000B,
    }
    public enum DaqDataType : ushort
    {
        //_Start = 0x0038,
        DAQ_DATA = 0x0038,
        GAP_DATA = 0x0039,
        SYNC_AMP = 0x0040,
        //_End = 0x0040,
    }

    public enum DaqHeaderType : byte
    {
        Invalid = 0,
        Cmd,
        Data
    }

    public enum DaqResponse : ushort
    {
        SUCCESS = 0x0001,
        FAIL = 0x0021,
        TEST = 0x1001,      //byte범위를 벗어남에 주의
    }

    public enum DaqSamplingRate
    {
        [Description("65536")]
        _65536 = 0,
        [Description("32768")]
        _32768 = 1,
        [Description("16384")]
        _16384 = 2,
        [Description("8192")]
        _8192 = 3,
        [Description("4096")]
        _4096 = 4,
        [Description("2048")]
        _2048 = 5,
        [Description("1024")]
        _1024 = 6,
        [Description("512")]
        _512 = 7
    }

    public enum DaqGain
    {
        [Description("1")]
        _1 = 0,
        [Description("2")]
        _2,
        [Description("5")]
        _5,
        [Description("10")]
        _10,
        [Description("20")]
        _20,
        [Description("50")]
        _50,
        [Description("100")]
        _100,
    }

    public enum DaqInputType
    {
        AC = 0,
        DC = 1
    }
}
