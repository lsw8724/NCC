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
    public float? Rpm { get; set; }
}

public class NCCScript
{
    public string Description { get { return "Virtual Connect Test"; } }
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverVirtual Receiver = new ReceiverVirtual();
    
    public NCCScript()
    {
        AsyncFMax = 3200;
        AsyncLine = 800;
    }

    public void Run()
    {
        Receiver.Start();
    }
}

