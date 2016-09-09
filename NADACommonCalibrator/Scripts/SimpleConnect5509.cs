using NADACommonCalibrator;
using NCCCommon;

public partial class NCCScript
{
    public string Description { get { return "5509 연결"; } }
    public ReceiverType Receiver {get;set;}
    public string ModuleIp { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }

    public NCCScript()
    {
        Receiver = ReceiverType.Daq5509;
        ModuleIp = "192.168.0.10";
        AsyncLine = 3200;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
    }

    public void Run()
    {
        var rcv = ReceiverUtil.GetReceiver(Receiver);
        rcv.Start();
    }
}
