using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NADACommonCalibrator.PlotControl
{
    public class PlotControl
    {
        public static Color[] colors = new Color[] { Color.Pink, Color.YellowGreen, Color.Aqua, Color.Purple, Color.Lime, Color.White, Color.Red, Color.Yellow };
    }

    public enum PlotType
    {
        Spectrum,
        TimeBase,
        WorkSheet,
        RealTime,
        Correction,
    }
}