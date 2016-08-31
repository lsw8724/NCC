using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Docking;
using NADACommonCalibrator.PlotControl;
using NADACommonCalibrator.ConfigControl;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using System.IO;
using CSScriptLibrary;
using DevExpress.XtraBars;
using System.Linq;
using NCCCommon;
using NADACommonCalibrator.Receiver;

namespace NADACommonCalibrator
{
    public interface IVisaScript
    {
        string Name { get; }
        string Run();
    }

    public partial class MainForm : XtraForm
    {
        private List<XtraUserControl> OpenedPlotControl = new List<XtraUserControl>();
        public event Action<WaveData[]> WavesReceived;
        private IWavesReceiver CurrentReceiver;

        public MainForm()
        {
            InitializeComponent();
            InitializeThemeItem();
            InitializeScriptItem();

            barBtn_5509.Tag = ReceiverType.Daq5509;
            barBtn_omap.Tag = ReceiverType.Omap;
            barBtn_wifi.Tag = ReceiverType.Daq5509;
            barBtn_bt.Tag = ReceiverType.Daq5509;

            lb_ModuleList.Items.ListChanged += lb_ModuleList_listChanged;
            lb_ModuleList.Items.Clear();
        }

        private void lb_ModuleList_listChanged(object sender, ListChangedEventArgs e)
        {
            if (lb_ModuleList.ItemCount == 0)
            {
                navItem_spectrum.Visible = false;
                navItem_Timebase.Visible = false;
                if (dockPanel_5509Config.State == DockPanelState.Docking)
                    dockPanel_5509Config.Hide();
                navItem_connect.Visible = false;
                navItem_disConnect.Visible = false;
            }
            else
            {
                navItem_spectrum.Visible = true;
                navItem_Timebase.Visible = true;
                navItem_disConnect.Visible = true;
                navItem_connect.Visible = true;
            }
        }

        private void InitializeThemeItem()
        {
            var barItems = new BarCheckItem[]{
                new BarCheckItem(){Caption = "Sharp Plus"},
                new BarCheckItem(){Caption = "VS2010"},
                new BarCheckItem(){Caption = "Whiteprint"},
                new BarCheckItem(){Caption = "Money Twins"},
            };

            var themeString = "Sharp Plus";
            defaultLookAndFeel.LookAndFeel.SkinName = themeString;
            barItems.Where(x => x.Caption.Equals(themeString)).First().Checked = true;

            foreach (var item in barItems)
            {
                item.ItemClick += (s, e) => defaultLookAndFeel.LookAndFeel.SkinName = e.Item.Caption;
                item.GroupIndex = 1;
            }

            barItem_theme.ItemLinks.AddRange(barItems);
        }

        private void InitializeScriptItem()
        {
            var paths = Directory.GetFiles("Scripts", "*.cs");
            foreach (var path in paths)
            {
                var sourceText = File.ReadAllText(path);
                var script = sourceText.StartsWith("using ") ? CSScript.Evaluator.LoadCode<IVisaScript>(sourceText) : CSScript.Evaluator.LoadMethod<IVisaScript>(sourceText);
                var link = AutomationGroup.AddItem();
                link.Item.LinkClicked += (s, e) => RunScript(e.Link.Item.Tag as IVisaScript);
                link.Item.Caption = script.Name;
                link.Item.Tag = script;
            }
        }

        private void RunScript(IVisaScript script)
        {
            try
            {
                var temp = script.Run();
            }
            catch (Exception ex)
            {
            }
        }

        private void navItem_timeBase_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timebasePlot = new TimeBaseControl(8, this, lb_ModuleList.SelectedItem == null ? null : (lb_ModuleList.SelectedItem as IConvertableItems).ToItems()) { Dock = DockStyle.Fill };
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = "TimeBase";
            dockPanel.Controls.Add(timebasePlot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControl.Remove(timebasePlot);
            dockPanel.Height = 300;
            OpenedPlotControl.Add(timebasePlot);
        }

        private void navItem_spectrum_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var spectrumPlot = new SpectrumControl(8, this, lb_ModuleList.SelectedItem == null ? null : (lb_ModuleList.SelectedItem as IConvertableItems).ToItems()) { Dock = DockStyle.Fill };
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = "Spectrum";
            dockPanel.Controls.Add(spectrumPlot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControl.Remove(spectrumPlot);
            dockPanel.Height = 300;
            OpenedPlotControl.Add(spectrumPlot);
        }

        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu.ShowPopup(barManager, lb_ModuleList.PointToScreen(new Point(e.X, e.Y)));
        }

        private void barBtn_add_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch ((ReceiverType)e.Item.Tag)
            {
                case ReceiverType.Daq5509:
                    var receiver = new Receiver_5509();
                    receiver.WavesReceived += WaveDatas_Received;
                    lb_ModuleList.Items.Add(receiver);
                    dockPanel_5509Config.Show();
                    break;
                case ReceiverType.Omap: break;
                case ReceiverType.Bluetooth: break;
                case ReceiverType.Wifi: break;
            }
        }

        private void WaveDatas_Received(NCCCommon.ModuleProtocol.WaveData[] waves)
        {
            WavesReceived(waves);
        }

        private void barBtn_remove_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lb_ModuleList.SelectedItem != null)
                lb_ModuleList.Items.Remove(lb_ModuleList.SelectedItem);
        }

        private void lb_ModuleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBoxControl)sender;
            if (listBox.SelectedItem == null) return;
            switch (((IGettableReceiverType)listBox.SelectedItem).GetReceiverType())
            {
                case ReceiverType.Daq5509: break;
                case ReceiverType.Omap: break;
                case ReceiverType.Bluetooth: break;
                case ReceiverType.Wifi: break;
            }
            var receiver = lb_ModuleList.SelectedItem as IConvertableItems;
            ConfigControl_5509.gcDaq5509.DataSource = receiver.ToItems();
        }

        private void lb_ModuleList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listBox = (ListBoxControl)sender;
            var receiver = lb_ModuleList.SelectedItem as IConvertableItems;
            switch (((IGettableReceiverType)listBox.SelectedItem).GetReceiverType())
            {
                case ReceiverType.Daq5509:
                    ConfigControl_5509.gcDaq5509.DataSource = receiver.ToItems();
                    break;
                case ReceiverType.Omap: ConfigControl_5509.gcDaq5509.DataSource = receiver.ToItems();
                    break;
                case ReceiverType.Bluetooth: break;
                case ReceiverType.Wifi: break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (var panel in new DockPanel[] { dockPanel_5509Config })
            {
                panel.DockAsMdiDocument();
                panel.DockTo(DockingStyle.Fill);
            }
        }

        private void navItem_connect_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CurrentReceiver = lb_ModuleList.SelectedItem as IWavesReceiver;
            CurrentReceiver.Start();
        }

        private void navItem_disConnect_ItemChanged(object sender, EventArgs e)
        {
            if (CurrentReceiver != null)
                CurrentReceiver.Stop();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurrentReceiver != null)
                CurrentReceiver.Stop();
        }
    }
}