using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using System.ComponentModel;


public partial class NCCScript
{
    public string Description { get { return "5509 연결"; } }
    [Browsable(false)]
    public IWavesReceiver Receiver {get;set;}
    public string ModuleIp { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }
    public DaqInputType InputType { get; set; }

    public NCCScript()
    {
        ModuleIp = "192.168.0.11";
        AsyncLine = 3200;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
        InputType = DaqInputType.AC;
        Receiver = new ReceiverDaq5509(ModuleIp);
    }

    public void Run()
    {
        Receiver.Start();
    }
}

public class TableItem
{
    public string row1 { get; set; }
    public string row2 { get; set; }
    public string row3 { get; set; }
}
