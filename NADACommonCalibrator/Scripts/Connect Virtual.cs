using NCCCommon.ModuleProtocol.Virtual;
using NADACommonCalibrator.PlotControl;
using NCCCommon.ModuleProtocol;

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
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverVirtual Receiver = new ReceiverVirtual();

    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public SpectrumControl Spectrum { get; set; }
    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public TimeBaseControl TimeBase { get; set; }
    [PlotControl(240), System.ComponentModel.Browsable(false)]
    public TabularControl Tabular { get; set; }
    
    public NCCScript()
    {
        Tabular = new TabularControl(PlotType.RealTime);
        Spectrum = new SpectrumControl();
        TimeBase = new TimeBaseControl();

        Tabular.LowFreq = 90;
        Tabular.HighFreq = 110;
        TabularControl.CorrectionValueCalcRowCount = 5;

        AsyncFMax = 800;
        AsyncLine = 800;
        Receiver.SingleSinWave(100, 0.1f);
    }

    public void Run()
    {
        Receiver.Start();
    }
}

