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
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using NCCCommon.ModuleProtocol.OmapProtocol;
using System.IO;
using CSScriptLibrary;
using DevExpress.XtraBars;
using System.Linq;
using NCCCommon;
using NADACommonCalibrator.Receiver;

namespace NADACommonCalibrator
{
    public partial class MainForm : XtraForm
    {
        public IWavesReceiver CurrentReceiver;
        public static event Action<WaveData[]> WavesReceived;

        private List<XtraUserControl> OpenedPlotControl = new List<XtraUserControl>();
        
        public MainForm()
        {
            InitializeComponent();
            InitializeThemeItem();
            InitializeScriptItem();
        }

        private void InitializeThemeItem()
        {
            var barItems = new BarCheckItem[]{
                new BarCheckItem(){Caption = "Sharp Plus"},
                new BarCheckItem(){Caption = "VS2010"},
                new BarCheckItem(){Caption = "Whiteprint"},
                new BarCheckItem(){Caption = "Money Twins"},
                new BarCheckItem(){Caption = "Foggy"},
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
                dynamic instance = CSScript.Load(path).CreateInstance("NCCScript");
                var link = navAutomationGroup.AddItem();
                link.Item.LinkClicked += (s, e) => OpenScriptConfig(e.Link.Item.Tag, path);
                link.Item.Caption = instance.Description;
                link.Item.Tag = instance;
            }
        }

        private void OpenScriptConfig(object obj, string path)
        {
            pgcScriptConfig.Rows.Clear();
            dockPanel_scriptInfo.Show();
            pgcScriptConfig.Invalidate();
            pgcScriptConfig.SelectedObject = obj;
        }

        private void navItem_timeBase_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timebasePlot = new TimeBaseControl(8) { Dock = DockStyle.Fill };
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = "TimeBase";
            dockPanel.Controls.Add(timebasePlot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControl.Remove(timebasePlot);
            dockPanel.Height = 300;
            OpenedPlotControl.Add(timebasePlot);
        }

        private void navItem_spectrum_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var spectrumPlot = new SpectrumControl(8) { Dock = DockStyle.Fill };
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = "Spectrum";
            dockPanel.Controls.Add(spectrumPlot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControl.Remove(spectrumPlot);
            dockPanel.Height = 300;
            OpenedPlotControl.Add(spectrumPlot);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurrentReceiver != null)
                CurrentReceiver.Stop();
        }

        private void barBtn_runScript_ItemClick(object sender, ItemClickEventArgs e)
        {
            var script = pgcScriptConfig.SelectedObject as dynamic;
            CurrentReceiver = (IWavesReceiver)script.Receiver;
            CurrentReceiver.WavesReceived += AfterWavesReceived;
            script.Run();
        }

        private void AfterWavesReceived(WaveData[] waves)
        {
            WavesReceived(waves);
        }
    }
}