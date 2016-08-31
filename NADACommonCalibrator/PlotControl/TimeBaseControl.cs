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
using NADACommonCalibrator.Receiver;
using NADACommonCalibrator.ConfigControl;

namespace NADACommonCalibrator.PlotControl
{
    public partial class TimeBaseControl : DevExpress.XtraEditors.XtraUserControl
    {
        private ChartCursor Cursor;
        private float[] Resolutions;
        public TimeBaseControl(int count, XtraForm owner, List<object> items = null)
        {
            InitializeComponent();
            (owner as MainForm).WavesReceived += Waves_Received;
            Cursor = new ChartCursor(tChart_timeBase);

            if (items != null)
            {
                for (int i = 0; i < count; i++)
                    tChart_timeBase.Series.Add(new FastLine() { Title = "CH " + i + 1, Active = (items[i] as IChennelItem).GetActive() });
                Resolutions = items.Select(x => (x as IChennelItem).GetResolution()).ToArray();
            }
        }

        private void Waves_Received(WaveData[] waves)
        {
            foreach (var serise in tChart_timeBase.Series)
                (serise as FastLine).Clear();

            for (int ch = 0; ch < waves.Length; ch++)
            {
                tChart_timeBase.Series[ch].BeginUpdate();
                for (int i = 0; i < waves[ch].AsyncDataCount; i++)
                    tChart_timeBase.Series[ch].Add(i * Resolutions[ch] / (double)waves[ch].AsyncDataCount, waves[ch].AsyncData[i]);
                tChart_timeBase.Series[ch].EndUpdate();
            }    
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
    }
}
