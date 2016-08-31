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

using NCCCommon.ModuleProtocol.OmapProtocol;
using NADACommonCalibrator;
using NCCCommon.ModuleProtocol;

namespace NADACommonCalibrator.ConfigControl
{
    public partial class OmapConfigControl : DevExpress.XtraEditors.XtraUserControl
    {
       public OmapConfigControl()
        {
            InitializeComponent();
        }

        private void gvDaq5509_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selected = gvOmap.GetSelectedRows().Select(h => gvOmap.GetRow(h) as Daq5509ChannelItem).ToArray();
            if (selected == null || selected.Length == 0)
                return;

            if (selected.Length == 1)
                pgcOmap.SelectedObject = selected[0];
            else
                pgcOmap.SelectedObjects[0] = selected;
        }

        private void pgcDaq5509_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            gvOmap.InvalidateRows();
            gvOmap.RefreshData();
        }
    }

    public class OmapChannelItem : IChennelItem
    {
        private OmapModule module;
        private OmapChannel Ch;

        [Category("Module")]
        public string ModuleIp { get { return module.ModuleIp; } set { module.ModuleIp = value; } }

        [Category("Channel")]
        public string Channel { get { return "CH" + Ch.Id; } }
        [Category("Channel")]
        public bool Active { get; set; }

        public OmapChannelItem(IWavesReceiver receiver, OmapChannel ch)
        {
            this.module = (receiver as Receiver_Omap).Module;
            this.Ch = ch;
            if (ch.Id == 1)
                Active = true;
        }
        
        public float GetResolution() { return 3200 / (float)3200; }
        public int GetAsyncFMax() { return 3200; }
        public bool GetActive(){ return Active;}
    }
}
