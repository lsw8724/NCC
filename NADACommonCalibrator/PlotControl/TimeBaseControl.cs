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
using System.Diagnostics;
using NADACommonCalibrator;
using System.Threading.Tasks;

namespace NADACommonCalibrator.PlotControl
{
    public partial class TimeBaseControl : DevExpress.XtraEditors.XtraUserControl, IPlotControl
    {
        private int wheelAccum;
        private float Resolutions = 1;
        public PlotType Type { get; set; }
        public TimeBaseControl()
        {
            InitializeComponent();
            Type = PlotType.TimeBase;
            tChart_timeBase.Axes.Bottom.Automatic = false;
            tChart_timeBase.Axes.Bottom.Maximum = 1;
        }

        public void ControlInit(PlotConfig config)
        {
            for (int i = 0; i < config.ChCount; i++)
                tChart_timeBase.Series.Add(new FastLine() { Title = "CH " + (i + 1), Active = i > 0 ? false : true, Color = PlotControl.colors[i] });

            tChart_timeBase.MouseWheel += (s, e) =>
                {
                    wheelAccum += e.Delta;
                    if (Math.Abs(wheelAccum) > 200)
                        tChart_timeBase.Axes.Left.Automatic = false;
                    var left = tChart_timeBase.Axes.Left.Position;
                    var top = tChart_timeBase.Axes.Left.IStartPos + (wheelAccum > 0 ? 10 : -10);
                    var right = tChart_timeBase.Axes.Bottom.IEndPos;
                    var bottom = tChart_timeBase.Axes.Bottom.Position + (wheelAccum > 0 ? -10 : 10);

                    tChart_timeBase.Zoom.ZoomRect(new Rectangle(left, top, right - left, bottom - top));
                    wheelAccum = 0;
                };
        }

        public void ProcessData(IReceiveData[] rcvData)
        {
            var first = rcvData.FirstOrDefault();
            if (first == null || first.Type != DataType.WaveDatas) return;
            var waves = rcvData as WaveData[];
            Task.Run(() => TimeBase_UpdateChart(waves));
        }

        private void TimeBase_UpdateChart(WaveData[] waves)
        {
            try
            {
                foreach (var serise in tChart_timeBase.Series)
                    (serise as FastLine).Clear();
                for (int ch = 0; ch < waves.Length; ch++)
                {
                    tChart_timeBase.Series[ch].BeginUpdate();
                    for (int i = 0; i < waves[ch].AsyncDataCount; i++)
                        tChart_timeBase.Series[ch].Add(i * Resolutions / (double)waves[ch].AsyncDataCount, waves[ch].AsyncData[i]);
                    tChart_timeBase.Series[ch].EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
