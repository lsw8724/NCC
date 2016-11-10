using Steema.TeeChart;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NADACommonCalibrator.PlotControl
{
    public partial class ChartCursor : CursorTool
    {
        public void TChart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                XValue = OwnerChart.Axes.Bottom.InternalCalcPosPoint(e.X);
            }

            List<KeyValuePair<int, bool>> activePair = new List<KeyValuePair<int, bool>>();
            for (int i = 0; i < OwnerChart.Series.Count; i++)
                activePair.Add(new KeyValuePair<int, bool>(i, OwnerChart.Series[i].Active));
            if (activePair.Where(x => x.Value).Count() == 1)
                Series = OwnerChart.Series[activePair.Where(x => x.Value).First().Key];
            else
                Series = null;
        }

        public void TChart_MouseUp(object sender, MouseEventArgs e)
        {
            CursorInfo.Text = string.Empty;
            CursorInfo.Text += "X축: " + Math.Round(XValue, 3) + "\nY축: " + Math.Round(YValue, 3);
        }

        public ChartCursor(TChart tchart)
        {
            InitializeComponent(tchart);
        }
    }
}
