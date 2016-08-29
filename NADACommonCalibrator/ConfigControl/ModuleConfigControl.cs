using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using NADACommonCalibrator.Receiver;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using NCCCommon.ModuleProtocol.OmapProtocol;
using NADACommonCalibrator;
using NCCCommon.ModuleProtocol;
namespace NADACommonCalibrator.ConfigControl
{
    public partial class ModuleConfigControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ModuleConfigControl()
        {
            InitializeComponent();

            cbSamplingRate.BindEnum<DaqSamplingRate>();
            cbHWGain.BindEnum<DaqGain>();
            cbInputType.BindEnum<DaqInputType>();
        }

        private void gvDaq5509_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selected = gvDaq5509.GetSelectedRows().Select(h => gvDaq5509.GetRow(h) as Daq5509ChannelItem).ToArray();
            if (selected == null || selected.Length == 0)
                return;

            if (selected.Length == 1)
                pgcDaq5509.SelectedObject = selected[0];
            else
                pgcDaq5509.SelectedObjects[0] = selected;
        }

        private void pgcDaq5509_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            gvDaq5509.InvalidateRows();
            gvDaq5509.RefreshData();
        }
    }

    public class Daq5509ChannelItem
    {
        private Daq5509Receiver Rcv;
        private RobinChannel Ch;

        [Category("Module")]
        public string ModuleIp { get { return Rcv.ModuleIp; } set { Rcv.ModuleIp = value; } }
        [Category("Module")]
        public DaqInputType InputType { get { return Rcv.InputType; } set { Rcv.InputType = value; } }
        [Category("Module"),DXDescription]
        public DaqSamplingRate SamplingRate { get { return Rcv.nSamplingRate; } set { Rcv.nSamplingRate = value; } }

        [Category("Channel")]
        public string Channel { get { return "CH" + Ch.Id; } }
        [Category("Channel")]
        public int AsyncFMax { get { return Ch.AsyncFMax; } set { Ch.AsyncFMax = value; } }
        [Category("Channel")]
        public int AsyncLine { get { return Ch.AsyncLine; } set { Ch.AsyncLine = value; } }
        [Category("Channel")]
        public DaqGain HWGain { get { return Ch.HWGain; } set { Ch.HWGain = value; } }
        [Category("Channel")]
        public bool ICP { get { return Ch.ICP; } set { Ch.ICP = value; } }
        [Category("Channel")]
        public float Sensitivity { get { return Ch.Sensitivity; } set { Ch.Sensitivity = value; } }

        public Daq5509ChannelItem(IWavesReceiver receiver, RobinChannel ch)
        {
            this.Rcv = receiver as Daq5509Receiver;
            this.Ch = ch;
        }

    }

    public class OmapChannelItem
    {
    }

    public class BTChannelItem
    {
    }

    public class WifiChannelItem
    {
    }
}
