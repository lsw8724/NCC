using NCCCommon.ModuleProtocol.Daq5509;
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
    public DaqGain HWGain { get; set; }
    public DaqSamplingRate SamplingRate { get; set; }
    public DaqInputType InputType { get; set; }
    public string Ip { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }

    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public SpectrumControl Spectrum { get; set; }
    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public TimeBaseControl TimeBase { get; set; }
    [PlotControl(240), System.ComponentModel.Browsable(false)]
    public TabularControl Tabular { get; set; }

    public ReceiverDaq5509 Receiver = new ReceiverDaq5509();

    public NCCScript()
    {
        Tabular = new TabularControl(PlotType.RealTime);
        Spectrum = new SpectrumControl();
        TimeBase = new TimeBaseControl();

        Ip = "192.168.0.14";
        AsyncLine = 800;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
        InputType = DaqInputType.AC;
        HWGain = DaqGain._1;
        SamplingRate = DaqSamplingRate._8192;
    }

    public void Run()
    {
        Receiver.Start();
    }
}

