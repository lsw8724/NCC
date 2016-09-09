using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;

public partial class NCCScript
{
    public string Description { get { return "5509 연결"; } }
    public IWavesReceiver Receiver {get;set;}
    public string ModuleIp { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }

    public NCCScript()
    {
        ModuleIp = "192.168.0.11";
        Receiver = new ReceiverDaq5509(ModuleIp);
        AsyncLine = 3200;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
    }

    public void Run()
    {
        Receiver.Start();
    }
}
