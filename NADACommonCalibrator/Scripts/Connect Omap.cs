using NCCCommon.ModuleProtocol.Omap;
using NADACommonCalibrator.PlotControl;

public class Items
{
    public float? Ch1 { get; set; }
    public float? Ch2 { get; set; }
    public float? Ch3 { get; set; }
    public float? Ch4 { get; set; }
    public float? Ch5 { get; set; }
    public float? Ch6 { get; set; }
    public float? Ch7 { get; set; }
    public float? Ch8 { get; set; }
    public float? Kp1 { get; set; }
    public float? Kp2 { get; set; }
}

public class NCCScript
{
    public int HWGain { get; set; }
    public string Ip { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }
    public AlarmBufferMode AlarmBufferMode { get; set; }

    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public SpectrumControl Spectrum { get; set; }
    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public TimeBaseControl TimeBase { get; set; }
    [PlotControl(240), System.ComponentModel.Browsable(false)]
    public TabularControl Tabular { get; set; }

    public ReceiverOmap Receiver = new ReceiverOmap();

    public NCCScript()
    {
        Tabular = new TabularControl(PlotType.RealTime);
        Spectrum = new SpectrumControl();
        TimeBase = new TimeBaseControl();

        Ip = "192.168.0.11";
        HWGain = 1;
        AsyncLine = 800;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
        AlarmBufferMode = AlarmBufferMode.Slow;
    }

    public void Run()
    {        
        Receiver.Start();
    }
}

