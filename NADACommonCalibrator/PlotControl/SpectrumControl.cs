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
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using NCCCommon;
using Steema.TeeChart;
using System.Diagnostics;

namespace NADACommonCalibrator.PlotControl
{
    public partial class SpectrumControl : DevExpress.XtraEditors.XtraUserControl
    {
        private int FMax;
        public SpectrumControl(int count,int fMax, ref Action<SpectrumData[]> fftCalc)
        {
            InitializeComponent();
            fftCalc += FFTData_Received;
            Cursor = new ChartCursor(tChart_Spectrum);
            for (int i = 0; i < count; i++)
                tChart_Spectrum.Series.Add(new FastLine() { Title = "CH " + (i + 1), Active = i > 0 ? false : true });

            FMax = fMax;
            tChart_Spectrum.MouseWheel += (s, e) =>
                {                    
                    tChart_Spectrum.Axes.Left.Automatic = false;
                    tChart_Spectrum.Axes.Left.AutomaticMaximum = false;
                    if (e.Delta < 0)
                    {
                        tChart_Spectrum.Axes.Left.Maximum += 5;
                        tChart_Spectrum.Axes.Left.Minimum -= 5;
                    }
                    else
                    {
                        tChart_Spectrum.Axes.Left.Maximum -= 5;
                        tChart_Spectrum.Axes.Left.Minimum += 5;
                    }
                };
        }

        private void FFTData_Received(SpectrumData[] fftData)
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

        private void tChart_Spectrum_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<int, bool>> activePair = new List<KeyValuePair<int, bool>>();
            for (int i = 0; i < tChart_Spectrum.Series.Count; i++)
                activePair.Add(new KeyValuePair<int, bool>(i, tChart_Spectrum.Series[i].Active));
            if (activePair.Where(x => x.Value).Count() == 1)
                Cursor.SetRefSerise(tChart_Spectrum.Series[activePair.Where(x => x.Value).First().Key]);
            else
                Cursor.SetRefSerise();
        }
    }


}
