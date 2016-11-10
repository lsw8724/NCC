using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCCCommon.ModuleProtocol;

namespace NADACommonCalibrator.PlotControl
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PlotControlAttribute : Attribute
    {
        public int Height { get; set; }
        public PlotControlAttribute(int h = 300)
        {
            this.Height = h;
        }
    }

    public interface IPlotControl
    {
        PlotType Type { get; set; }
        void ControlInit(PlotConfig Config);
        void ProcessData(IReceiveData[] rcvData);
    }

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

    public class PlotConfig
    {
        public PlotType Type;
        public int ChCount;
        public int FMax;
        public object Columns;
        public Dictionary<string, int> KeyphasorMap;
    }
}