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

namespace NADACommonCalibrator.PlotControl
{
    public partial class TimeBaseControl : DevExpress.XtraEditors.XtraUserControl,IPlotControl
    {
        private int wheelAccum;
        private float Resolutions = 1;
        public TimeBaseControl(int count)
        {
            InitializeComponent();
            Cursor = new ChartCursor(tChart_timeBase);
            for (int i = 0; i < count; i++)
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

                    tChart_timeBase.Zoom.ZoomRect(new Rectangle(left, top, right - left, bottom- top));
                    wheelAccum = 0;
                };
        }

        private void Datas_Received(IReceiveData[] datas)
        {
           
        }

        private void tChart_timeBase_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<int,bool>> activePair = new List<KeyValuePair<int,bool>>();
            for (int i = 0; i < tChart_timeBase.Series.Count; i++)
                activePair.Add(new KeyValuePair<int,bool>(i,tChart_timeBase.Series[i].Active));
            if (activePair.Where(x => x.Value).Count() == 1)
                Cursor.SetRefSerise(tChart_timeBase.Series[activePair.Where(x => x.Value).First().Key]);
            else
                Cursor.SetRefSerise();
        }

        public void ProcessData(IReceiveData[] rcvData)
        {
            try
            {
                var first = rcvData.FirstOrDefault();
                if (first == null || first.Type != DataType.WaveDatas) return;
                var waves = rcvData as WaveData[];
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
