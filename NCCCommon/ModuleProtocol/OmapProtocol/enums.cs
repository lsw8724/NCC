using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public enum ModuleType
    {
        [Description("Vibration")]
        Vibration = 0,

        [Description("Absolute Vibration")]
        AbsoluteVibration = 1,

        [Description("CMS")]
        Robin = 2,

        [Description("CMS Legacy")]
        Robin5509 = 3,

        [Description("External")]
        External = 4,
    }

    //public enum ChannelType
    //{
    //    Keyphasor = 100,
    //    Displacement = 201,         //변위
    //    AbsoluteDisplacement = 202, //절대 변위
    //    Accelate = 205,             //가속도
    //    DC = 203,
    //    Thrust = 204,
    //    Eccentricity = 206,
    //    DiffExp = 207,
    //    DiffRamp = 208,
    //    CaseExp = 209,
    //    ReverseRotation = 210,
    //    Robin = 300,
    //}

    public enum AlarmBufferMode
    {
        Slow,
        Fast
    }

    public enum SessionType : int
    {
        [Description("Vector")]
        SessionType_Vector,
        [Description("Wave")]
        SessionType_Wave,
        [Description("Alarm")]
        SessionType_Alarm,
    };

    public enum DataSaveType
    {
        Unknown = 0,
        Normal,     //Realtime
        TimeSave,
        AmpSave,
        RpmSave,
        AlarmSave
    }

    public enum AngleDirection
    {
        Left = 0,
        Right = 1
    }

    public enum ShaftDirection
    {
        CW,
        CCW
    }
}
