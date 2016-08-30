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

namespace NADACommonCalibrator.PlotControl
{
    public partial class SpectrumControl : DevExpress.XtraEditors.XtraUserControl
    {
        private ChartCursor Cursor;
        private float[] Resolutions;
        public SpectrumControl(int count, XtraForm owner, List<object> items = null)
        {
            InitializeComponent();
            (owner as MainForm).WavesReceived += Waves_Received;
            for (int i = 0; i < count; i++)
                tChart_Spectrum.Series.Add(new FastLine() { Title = "CH " + i+1, Active = (items[i] as IGettableItemProperty).GetActive() });
            Cursor = new ChartCursor(tChart_Spectrum);
            if (items != null)
                Resolutions = items.Select(x => (x as IGettableItemProperty).GetResolution()).ToArray();
            else
            {
                Resolutions = new float[count];
                for (int i = 0; i < count; i++)
                    Resolutions[i] = 1;
            }
        }

        private void Waves_Received(WaveData[] waves)
        {
            foreach (var serise in tChart_Spectrum.Series)
                (serise as FastLine).Clear();

            for (int ch = 0; ch < waves.Length; ch++)
            {
                tChart_Spectrum.Series[ch].BeginUpdate();
                for (int i = 0; i < waves[ch].AsyncDataCount; i++)
                    tChart_Spectrum.Series[ch].Add(i * Resolutions[ch] / (double)waves[ch].AsyncDataCount, waves[ch].AsyncData[i]);
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
}
