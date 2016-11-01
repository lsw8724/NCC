using NCCCommon.ModuleProtocol.Wifi;
using NADACommonCalibrator.PlotControl;

public class Items
{
    public float? Ch1 { get; set; }
}

public class NCCScript
{
    public PlotType[] PlotGroup = new PlotType[] { PlotType.TimeBase, PlotType.Spectrum, PlotType.RealTime };
    public string Description { get { return "Wifi Connect Test"; } }
    public string Ip { get; set; }
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverWifi Receiver = new ReceiverWifi();

    public NCCScript()
    {
        Ip = "192.168.7.1";
        AsyncLine = 3200;
        AsyncFMax = 3200;
    }

    public void Run()
    {
        Receiver.Start();
    }
}

