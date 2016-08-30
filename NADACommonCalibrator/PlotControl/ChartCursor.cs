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
    public partial class ChartCursor : ColorLine
    {
        public void TChart_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CursorInfo.Text = string.Empty;
                CursorInfo.Text += "X축: " + GuideCursor.XValue + "\nY축: " + GuideCursor.YValue;
                Value = GuideCursor.XValue;
            }
        }

        public ChartCursor(TChart tchart)
        {
            InitializeComponent(tchart);
        }

        public void SetRefSerise(Steema.TeeChart.Styles.Series s = null)
        {
             GuideCursor.Series = s;
        }
    }
}
