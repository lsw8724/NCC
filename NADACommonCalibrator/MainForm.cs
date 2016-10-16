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
using System.Threading.Tasks;

namespace NADACommonCalibrator
{
    public partial class MainForm : XtraForm
    {
        public IWavesReceiver CurrentReceiver;
        public static event Action<WaveData[]> DataReceived;
        private object Items;
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
                        for (int i = snapDockManager.Panels.Count-1; i > 1; i--)
                            snapDockManager.RemovePanel(snapDockManager.Panels[i]);

                        OpenScriptConfig(e.Link.Item.Tag, path);
                        try
                        {
                            Items = assembly.CreateInstance("Items");
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
                    if (DataReceived != null)
                        DataReceived(waves);
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
            AddDockPanel(new TimeBaseControl(8), "TimeBase");
        }

        private void navItem_spectrum_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new SpectrumControl(8), "Spectrum");
        }

        private void navItemTable_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new TabularControl(Items, TabularMode.RealTime), "RealTime Tabular");
        }
         
        private void navItemWorkSheet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new TabularControl(Items, TabularMode.WorkSheet), "Work Sheet");
        }

        private void AddDockPanel(XtraUserControl control, string text)
        {
            control.Dock = DockStyle.Fill;
            var plot = control;
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = text;
            dockPanel.Controls.Add(plot);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControls.Remove(plot);
            dockPanel.Height = 300;
            OpenedPlotControls.Add(plot);
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

                var scrProps = (script as object).GetType().GetProperties().ToList();
                var obj = (script.Receiver.Module as object);
                foreach(var prop in scrProps)
                {
                    var validProp = obj.GetType().GetProperty(prop.Name);
                    if (validProp == null) continue;
                    validProp.SetValue(obj, prop.GetValue(script));
                }
                Task.Run(() =>{ script.Run(); });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}