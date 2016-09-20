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
using System.Diagnostics;

namespace NADACommonCalibrator
{
    public partial class MainForm : XtraForm
    {
        public IWavesReceiver CurrentReceiver;
        public static event Action<WaveData[]> WavesReceived;
        private object TableColumns;
        private object TableItems;
        private MeasureCalculator MeasCalc = new MeasureCalculator();

        private List<XtraUserControl> OpenedPlotControls = new List<XtraUserControl>();

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
                var assembly = CSScript.Load(path);
                dynamic instance = assembly.CreateInstance("NCCScript");
                var link = navAutomationGroup.AddItem();
                link.Item.LinkClicked += (s, e) =>
                    {
                        OpenScriptConfig(e.Link.Item.Tag, path);
                        try
                        {
                            TableColumns = assembly.CreateInstance("TableItem");
                            TableItems = instance.Items;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    };
                link.Item.Caption = instance.Description;
                link.Item.Tag = instance;
                (instance.Receiver as IWavesReceiver).WavesReceived += (waves) =>
                {
                    if (WavesReceived != null)
                        WavesReceived(waves);
                };
            }
        }

        private void OpenScriptConfig(object obj, string path)
        {
            pgcScriptConfig.Rows.Clear();
            dockPanel_scriptInfo.Show();
            pgcScriptConfig.Invalidate();
            pgcScriptConfig.SelectedObject = null;
            pgcScriptConfig.SelectedObject = obj;
        }

        private void navItem_timeBase_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timebasePlot = new TimeBaseControl(8) { Dock = DockStyle.Fill };
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = "TimeBase";
            dockPanel.Controls.Add(timebasePlot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControls.Remove(timebasePlot);
            dockPanel.Height = 300;
            OpenedPlotControls.Add(timebasePlot);
        }

        private void navItem_spectrum_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var spectrumPlot = new SpectrumControl(8) { Dock = DockStyle.Fill };
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = "Spectrum";
            dockPanel.Controls.Add(spectrumPlot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControls.Remove(spectrumPlot);
            dockPanel.Height = 300;
            OpenedPlotControls.Add(spectrumPlot);
        }

        private void navItemTable_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var tablePlot = new TabularControl(TableColumns, TableItems) { Dock = DockStyle.Fill };
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = "Tabular";
            dockPanel.Controls.Add(tablePlot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControls.Remove(tablePlot);
            dockPanel.Height = 300;
            OpenedPlotControls.Add(tablePlot);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurrentReceiver != null)
                CurrentReceiver.Stop();
        }

        private void barBtn_runScript_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var script = pgcScriptConfig.SelectedObject as dynamic;
                if (script == null) return;
                CurrentReceiver = (IWavesReceiver)script.Receiver;
                script.Run();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}