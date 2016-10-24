using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.WifiProtocol;
using NADACommonCalibrator.PlotControl;

public class Items
{
    public float? Ch1 { get; set; }
    public float? Rpm { get; set; }
}

public class NCCScript
{
    public string Description { get { return "Wfs Connect Test"; } }
    public string Ip { get; set; }
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverWifi Receiver = new ReceiverWifi();

    public NCCScript()
    {
        Ip = "192.168.7.1";
        AsyncLine = 25600;
        AsyncFMax = 25600;
    }

    public void Run()
    {
        Receiver.Start();
    }
}

