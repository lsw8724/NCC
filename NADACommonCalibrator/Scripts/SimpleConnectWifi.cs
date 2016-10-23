using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.OmapProtocol;
using NADACommonCalibrator.PlotControl;

public class Items
{
    public float? Ch1 { get; set; }
    public float? Rpm { get; set; }
}

public class NCCScript
{
    public string Description { get { return "Wfs Connect Test"; } }
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverWifi Receiver = new ReceiverWifi();

    public NCCScript()
    {
        AsyncFMax = 3200;
        AsyncLine = 3200;
    }

    public void Run()
    {
        Receiver.Start();
    }
}

