using NCCCommon.ModuleProtocol.Wifi;
using NADACommonCalibrator.PlotControl;

public class Items
{
    public float? Ch1 { get; set; }
}

public class NCCScript
{
    public string Ip { get; set; }
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverWifi Receiver = new ReceiverWifi();

    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public SpectrumControl Spectrum { get; set; }
    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public TimeBaseControl TimeBase { get; set; }
    [PlotControl(240), System.ComponentModel.Browsable(false)]
    public TabularControl Tabular { get; set; }

    public NCCScript()
    {
        Tabular = new TabularControl(PlotType.RealTime);
        Tabular.HighFreq = 1000;
        Tabular.LowFreq = 20;
        Spectrum = new SpectrumControl();
        TimeBase = new TimeBaseControl();

        Ip = "192.168.7.1";
        AsyncLine = 3200;
        AsyncFMax = 3200;
    }

    public void Run()
    {
        Receiver.Start();
    }
}

