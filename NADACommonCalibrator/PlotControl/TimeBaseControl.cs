using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace NADACommonCalibrator.PlotControl
{
    public partial class TimeBaseControl : DevExpress.XtraEditors.XtraUserControl
    {
        private int SeriseCount;

        public TimeBaseControl(int count)
        {
            InitializeComponent();
            SeriseCount = count;

            tChart_timeBase.Series[0].FillSampleValues();
        }
    }
}
