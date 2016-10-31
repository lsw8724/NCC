using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.Omap
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

    public enum KeyphasorEdgeMode
    {
        Rising,
        Falling
    }

    public enum ResponseCodeTyoe : int
    {
        RCT_Ok,
        RCT_Error,
    }

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
