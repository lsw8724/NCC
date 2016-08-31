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
using NADACommonCalibrator.ConfigControl;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using NCCCommon;
using Steema.TeeChart;

namespace NADACommonCalibrator.PlotControl
{
    public partial class SpectrumControl : DevExpress.XtraEditors.XtraUserControl
    {
        private ChartCursor Cursor;
        private float[] Resolutions;
        private int FMax;
        public SpectrumControl(int count, XtraForm owner, List<object> items = null)
        {
            InitializeComponent();
            (owner as MainForm).WavesReceived += Waves_Received;
            Cursor = new ChartCursor(tChart_Spectrum);

            if (items != null)
            {
                for (int i = 0; i < count; i++)
                    tChart_Spectrum.Series.Add(new FastLine() { Title = "CH " + (i + 1), Active = (items[i] as IChennelItem).GetActive() });
                Resolutions = items.Select(x => (x as IChennelItem).GetResolution()).ToArray();
                FMax = items.Select(x => (x as IChennelItem).GetAsyncFMax()).First();
            }
            tChart_Spectrum.MouseWheel += tChart_mouseWheel;
        }

        private void tChart_mouseWheel(object sender, MouseEventArgs e)
        {
            tChart_Spectrum.Zoom.Direction = ZoomDirections.Vertical;
            if (e.Delta < 0)
                tChart_Spectrum.Zoom.ZoomPercent(0.01);
            else
                tChart_Spectrum.Zoom.ZoomPercent(0.01);
            
        }
         
        private void Waves_Received(WaveData[] waves)
        {
            foreach (var serise in tChart_Spectrum.Series)
                (serise as FastLine).Clear();

            for (int ch = 0; ch < waves.Length; ch++)
            {
                var fftData = new SpectrumData(Resolutions[ch], waves[ch]);
                tChart_Spectrum.Series[ch].BeginUpdate();
                for (int i = 0; i < FMax; i++)
                    tChart_Spectrum.Series[ch].Add(fftData.XValues[i], fftData.YValues[i]);
                tChart_Spectrum.Series[ch].EndUpdate();
            }
        }

        private void tChart_Spectrum_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<int,bool>> activePair = new List<KeyValuePair<int,bool>>();
            for (int i = 0; i < tChart_Spectrum.Series.Count; i++)
                activePair.Add(new KeyValuePair<int, bool>(i, tChart_Spectrum.Series[i].Active));
            if (activePair.Where(x => x.Value).Count() == 1)
                Cursor.SetRefSerise(tChart_Spectrum.Series[activePair.Where(x => x.Value).First().Key]);
            else
                Cursor.SetRefSerise();
        }   
    }

    public class SpectrumData
    {
        public DateTime TimeStamp { get; set; }
        public float[] XValues { get; set; }
        public float[] YValues { get; set; }

        public SpectrumData(float res, WaveData wave)
        {
            YValues= Array.ConvertAll(NadaMath.PositiveFFT(wave.AsyncData), x=> (float)x);
            XValues = YValues.Select((x, i) => (float)i / res).ToArray();
            TimeStamp = wave.DateTime;
        }
    }
}
