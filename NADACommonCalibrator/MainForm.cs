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

namespace NADACommonCalibrator
{
    public partial class MainForm : XtraForm
    {
        private IWavesReceiver CurrentReceiver;
        private IModuleConfig CurrentModule {get { return CurrentReceiver==null? new ReceiverVirtual() : CurrentReceiver as IModuleConfig;}}
        private ReceivedDatasControl RcvDatasCtrl = new ReceivedDatasControl();
        private int FMax;
        private float SpectrumRes;
        private object Items;
        public event Action<IReceiveData[]> DatasReceived;
        public event Action<SpectrumData[]> FFTCalculated;

        private List<XtraUserControl> OpenedPlotControls = new List<XtraUserControl>();

        private void ProcessFFTDatas(SpectrumData[] fftDatas)
        {
            try
            {
                switch (TabularControl.MeasureType)
                {
                    case MeasureCalcType.RMS:
                        DatasReceived(fftDatas.Select(x => new Measure_RMS(x)).ToArray());
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void ProcessRcvDatas(IReceiveData[] datas)
        {
            try
            {
                var first = datas.FirstOrDefault();
                if (first != null)
                {
                    switch (first.Type)
                    {
                        case DataType.WaveDatas:
                            if (FFTCalculated == null) break;
                            var waves = datas as WaveData[];
                            FFTCalculated(waves.Select(x => new SpectrumData(SpectrumRes, x)).ToArray());
                            switch (TabularControl.MeasureType)
                            {
                                case MeasureCalcType.PK:
                                    DatasReceived(waves.Select(x => new Measure_Peak(x)).ToArray());
                                    break;
                                case MeasureCalcType.PP:
                                    DatasReceived(waves.Select(x => new Measure_P2P(x)).ToArray());
                                    break;
                                default: break;
                            }
                            break;
                        case DataType.VectorData: break;
                        case DataType.MeasureData: break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
            
        public MainForm()
        {
            InitializeComponent();
            InitializeThemeItem();
            InitializeScriptItem();

            DatasReceived += (datas) =>{ProcessRcvDatas(datas);};
            FFTCalculated += (fft) => {ProcessFFTDatas(fft);};
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
                        for (int i = snapDockManager.Panels.Count - 1; i > 1; i--)
                            snapDockManager.RemovePanel(snapDockManager.Panels[i]);

                        OnOpenScript(e.Link.Item.Tag, path);
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
                if ((instance as object).GetType().GetMember("Receiver").Length == 0) continue;
                (instance.Receiver as IWavesReceiver).DatasReceived += (waves) =>
                {
                    if (DatasReceived != null)
                        DatasReceived(waves);
                };
            }
        }

        private void OnOpenScript(dynamic obj, string path)
        {
            try
            {
                pgcScriptConfig.Rows.Clear();
                dockPanel_scriptInfo.Show();
                pgcScriptConfig.Invalidate();
                pgcScriptConfig.SelectedObject = null;
                pgcScriptConfig.SelectedObject = obj;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void navItem_timeBase_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new TimeBaseControl(CurrentModule.ChannelCount, ref DatasReceived), "TimeBase - " + CurrentModule.ToString());
        }

        private void navItem_spectrum_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new SpectrumControl(CurrentModule.ChannelCount, FMax, ref FFTCalculated), "Spectrum - " + CurrentModule.ToString());
        }

        private void navItemTable_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new TabularControl(Items, TabularMode.RealTime, ref DatasReceived), "RealTime Tabular - " + CurrentModule.ToString());
        }

        private void navItemWorkSheet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new TabularControl(Items, TabularMode.WorkSheet, ref DatasReceived), "Work Sheet - " + CurrentModule.ToString());
        }
        private void navItemCorrection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddDockPanel(new TabularControl(Items, TabularMode.Correction, ref DatasReceived), "Correction Tabular - " + CurrentModule.ToString());
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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CurrentReceiver != null)
                CurrentReceiver.Stop();
        }

        private void barBtn_runScript_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                dynamic dyn = null;
                var script = pgcScriptConfig.SelectedObject;
                if (script == null) return;
                if (script.GetType().GetProperty("AsyncFMax") != null && script.GetType().GetProperty("AsyncLine") != null)
                {
                    dyn = script as dynamic;
                    FMax = dyn.AsyncFMax;
                    SpectrumRes = dyn.AsyncLine / (float)dyn.AsyncFMax;
                }

                var scrProps = script.GetType().GetProperties().ToList();
                if (script.GetType().GetMember("Receiver").Length != 0)
                {

                    dyn = script as dynamic;
                    CurrentReceiver = (IWavesReceiver)dyn.Receiver;
                    var module = dyn.Receiver.Module;

                    foreach (var prop in scrProps)
                    {
                        var validProp = module.GetType().GetProperty(prop.Name);
                        if (validProp == null) continue;
                        validProp.SetValue(module, prop.GetValue(script));
                    }
                }

                Task.Run(() => { (script as dynamic).Run(); });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}