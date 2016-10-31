using NCCCommon.ModuleProtocol.Virtual;
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
    public PlotType[] PlotGroup = new PlotType[] { PlotType.TimeBase, PlotType.Spectrum, PlotType.RealTime };
    public string Description { get { return "Virtual Connect Test"; } }
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverVirtual Receiver = new ReceiverVirtual();
    
    public NCCScript()
    {
        AsyncFMax = 3200;
        AsyncLine = 800;
        Receiver.AddSinWaves(60, 0.787f);
        Receiver.AddSinWaves(10, 0.787f);
    }

    public void Run()
    {
        Receiver.Start();
    }
}

