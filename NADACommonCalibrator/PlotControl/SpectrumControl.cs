using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NCCCommon.ModuleProtocol;
using Steema.TeeChart.Styles;
using NCCCommon.ModuleProtocol.Daq5509;
using NCCCommon;
using Steema.TeeChart;
using System.Diagnostics;
using NADACommonCalibrator;
using System.Threading.Tasks;

namespace NADACommonCalibrator.PlotControl
{
    public partial class SpectrumControl : DevExpress.XtraEditors.XtraUserControl,IPlotControl
    {
        private int FMax;
        private int wheelAccum;
        public PlotType Type { get; set; }

        public SpectrumControl()
        {
            InitializeComponent();
            Type = PlotType.Spectrum;
        }

        public void ControlInit(PlotConfig config)
        {
            for (int i = 0; i < config.ChCount; i++)
                tChart_Spectrum.Series.Add(new FastLine() { Title = "CH " + (i + 1), Active = i > 0 ? false : true, Color = PlotControl.colors[i] });

            FMax = config.FMax;
            tChart_Spectrum.MouseWheel += (s, e) =>
            {
                wheelAccum += e.Delta;
                if (Math.Abs(wheelAccum) > 200)
                    tChart_Spectrum.Axes.Left.Automatic = false;
                var left = tChart_Spectrum.Axes.Left.Position;
                var top = tChart_Spectrum.Axes.Left.IStartPos + (wheelAccum > 0 ? 10 : -10);
                var right = tChart_Spectrum.Axes.Bottom.IEndPos;
                var bottom = tChart_Spectrum.Axes.Bottom.Position + (wheelAccum > 0 ? -10 : 10);

                tChart_Spectrum.Zoom.ZoomRect(new Rectangle(left, top, right - left, bottom - top));
                wheelAccum = 0;
            };
        }

        public void ProcessData(IReceiveData[] rcvData)
        {
            var first = rcvData.FirstOrDefault();
            if (first == null || first.Type != DataType.FFTDatas) return;
            var fftData = rcvData as SpectrumData[];
            Task.Run(()=>SpectrumChartUpdate(fftData));
        }

        private void SpectrumChartUpdate(SpectrumData[] fftData)
        {
            try
            {
                int limit = Convert.ToInt32(fftData.First().Resolution * FMax);
                foreach (var serise in tChart_Spectrum.Series)
                    (serise as FastLine).Clear();

                for (int ch = 0; ch < fftData.Length; ch++)
                {
                    tChart_Spectrum.Series[ch].BeginUpdate();
                    for (int i = 0; i < limit; i++)
                        tChart_Spectrum.Series[ch].Add(fftData[ch].XValues[i], fftData[ch].YValues[i]);
                    tChart_Spectrum.Series[ch].EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }


}
