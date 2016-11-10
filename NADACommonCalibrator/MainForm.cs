using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;
using NADACommonCalibrator.PlotControl;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Virtual;
using System.IO;
using CSScriptLibrary;
using DevExpress.XtraBars;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing;
using DevExpress.XtraNavBar;
using System.Threading;
using System.Reflection;
using NADACommonCalibrator.Properties;

namespace NADACommonCalibrator
{
    public partial class MainForm : XtraForm
    {
        private List<NavBarItemLink> AutomationList = new List<NavBarItemLink>();
        private IWavesReceiver CurrentReceiver;
        private int FMax;
        private object Items;
        private List<IPlotControl> OpenedPlotControls = new List<IPlotControl>();
        private RcvDataController RDC;
        private CancellationTokenSource Cts;

        public MainForm()
        {
            InitializeComponent();
            InitializeThemeItem();
            InitializeScriptItem();
            Cts = new CancellationTokenSource();
            RDC = new RcvDataController(OpenedPlotControls);
        }

        private void InitializeThemeItem()
        {
            var barItems = new BarCheckItem[]{
                new BarCheckItem(){Caption = "Sharp Plus"},
                new BarCheckItem(){Caption = "VS2010"},
                new BarCheckItem(){Caption = "Whiteprint"},
                new BarCheckItem(){Caption = "Money Twins"},
                new BarCheckItem(){Caption = "Foggy"},
                new BarCheckItem(){Caption = "Valentine"},
                new BarCheckItem(){Caption = "DevExpress Style"},
                new BarCheckItem(){Caption = "DevExpress Dark Style"},
                new BarCheckItem(){Caption = "VS2010"},
                new BarCheckItem(){Caption = "Seven Classic"},
                new BarCheckItem(){Caption = "Office 2010 Blue"},
                new BarCheckItem(){Caption = "Office 2010 Black"},
                new BarCheckItem(){Caption = "Office 2010 Silver"},
                new BarCheckItem(){Caption = "Office 2013"},
                new BarCheckItem(){Caption = "Coffee"},
            };

            var themeString = Settings.Default.ThemeName;
            defaultLookAndFeel.LookAndFeel.SkinName = themeString;
            barItems.Where(x => x.Caption.Equals(themeString)).First().Checked = true;
            foreach (var item in barItems)
            {
                item.ItemClick += (s, e) =>
                    {
                        defaultLookAndFeel.LookAndFeel.SkinName = e.Item.Caption;
                        Settings.Default.ThemeName = e.Item.Caption;
                        Settings.Default.Save();
                    };
                item.GroupIndex = 1;
            }
            barItem_theme.ItemLinks.AddRange(barItems);
        }

        private void InitializeScriptItem()
        {
            var paths = Directory.GetFiles("Scripts", "*.cs");
            foreach (var path in paths)
            {
                var link = navAutomationGroup.AddItem();
                AutomationList.Add(link);
                link.Item.LinkClicked += (s, e) =>
                    {
                        try
                        {
                            string code = File.ReadAllText(path);
                            var assembly = CSScript.LoadCode(code);
                            for (int i = snapDockManager.Panels.Count - 1; i > 1; i--)
                                snapDockManager.RemovePanel(snapDockManager.Panels[i]);
                            Items = assembly.CreateInstance("Items");
                            OnOpenScript(assembly.CreateInstance("NCCScript"), path);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    };
                link.Item.Caption = Path.GetFileNameWithoutExtension(path);
            }
        }

        private bool CheckExistMember(object obj, string memberName)
        {
            return obj.GetType().GetMember(memberName).Length != 0;
        }

        private bool CheckExistProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        private void OnOpenScript(dynamic obj, string path)
        {
            try
            {
                barBtn_runScript.Enabled = true;
                pgcScriptConfig.Tag = path;
                pgcScriptConfig.Rows.Clear();
                dockPanel_scriptInfo.Show();
                pgcScriptConfig.Invalidate();
                pgcScriptConfig.SelectedObject = null;
                pgcScriptConfig.SelectedObject = obj;
                if (CheckExistMember(obj, "Receiver"))
                {
                    CurrentReceiver = (IWavesReceiver)obj.Receiver;
                    CurrentReceiver.DatasReceived += (waves) =>
                    {
                        if (RDC.DatasReceived != null)
                            RDC.DatasReceived(waves);
                    };
                }
                else
                    CurrentReceiver = null;

                if (CheckExistProperty(obj, "AsyncFMax") && CheckExistProperty(obj, "AsyncLine"))
                {
                    var dyn = obj as dynamic;
                    FMax = dyn.AsyncFMax;
                    RDC.SpectrumRes = dyn.AsyncLine / (float)dyn.AsyncFMax;
                }

                var props = (obj as object).GetType().GetProperties();
                var plotProps = props.Where(x => x.GetCustomAttributes<PlotControlAttribute>(true).Count() != 0);
                foreach (var p in plotProps)
                {
                    var plot = p.GetValue(obj) as IPlotControl;
                    int h = p.GetCustomAttribute<PlotControlAttribute>().Height;
                    AddDockPanel(plot, plot.Type.ToString(),h);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void navItem_timeBase_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var plot = new TimeBaseControl();
            AddDockPanel(plot, plot.Type.ToString());
        }
        private void navItem_spectrum_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var plot =new SpectrumControl();
            AddDockPanel(plot, plot.ToString());
        }
        private void navItemTable_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var plot = new TabularControl(PlotType.RealTime);
            AddDockPanel(plot, plot.Type.ToString());
        }

        private void navItemCorrection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var plot = new TabularControl(PlotType.Correction);
            AddDockPanel(plot, plot.Type.ToString());
        }

        private void AddDockPanel(IPlotControl control, string text, int height = 300)
        {
            if (CurrentReceiver == null) return;
            var xtraUC = control as XtraUserControl;
            xtraUC.Dock = DockStyle.Fill;
            var config = new PlotConfig()
            {
                Type = control.Type,
                ChCount = (CurrentReceiver as IGetterRcvProperty).ChannelCount,
                FMax = this.FMax,
                Columns = Items,
                KeyphasorMap = (CurrentReceiver as IKeyphasorMapper).KpMap
            };
            control.ControlInit(config);
            DockPanel dockPanel = snapDockManager.AddPanel(DockingStyle.Top);
            dockPanel.Text = text + " - " + CurrentReceiver.ToString();
            dockPanel.Controls.Add(xtraUC);
            dockPanel.HandleDestroyed += (s, de) => OpenedPlotControls.Remove(control);
            dockPanel.ClosedPanel += (s, de) => OpenedPlotControls.Remove(control);
            var heigh = control.GetType().CustomAttributes;
            heigh.GetType();
            dockPanel.Height = height;
            OpenedPlotControls.Add(control);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurrentReceiver != null)
                CurrentReceiver.Stop();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CurrentReceiver != null)
            {
                Cts = new CancellationTokenSource();
                CurrentReceiver.Stop();
                barBtn_runScript.Enabled = true;
                barBtn_StopScript.Enabled = false;
                foreach (var link in AutomationList)
                    link.Item.Enabled = true;
            }
        }

        private void barBtn_runScript_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                barBtn_runScript.Enabled = false;
                barBtn_StopScript.Enabled = true;
                foreach (var link in AutomationList)
                    link.Item.Enabled = false;
                dynamic dyn = null;
                var script = pgcScriptConfig.SelectedObject;
                if (script == null) return;

                var scrProps = script.GetType().GetProperties().ToList();
                if(CheckExistMember(script,"Receiver"))
                {
                    dyn = script as dynamic;
                    var module = dyn.Receiver.Module;

                    foreach (var prop in scrProps)
                    {
                        var validProp = module.GetType().GetProperty(prop.Name);
                        if (validProp == null) continue;
                        validProp.SetValue(module, prop.GetValue(script));
                    }
                }
                Task.Factory.StartNew(() => {
                    (script as dynamic).Run();
                }, Cts.Token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void barBtn_editScript_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (pgcScriptConfig.Tag == null) return;
            var path = pgcScriptConfig.Tag.ToString();
            Process.Start("Notepad2.exe", path);
        }

        private void btn_allClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = snapDockManager.Panels.Count - 1; i > 1; i--)
                snapDockManager.RemovePanel(snapDockManager.Panels[i]);
        }
    }
}