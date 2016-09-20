using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;

public class NCCScript
{
    [System.ComponentModel.Browsable(false)]
    public ReceiverVirtual Receiver { get; set; }
    public string Description { get { return "가상모듈 연결"; } }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }

    public NCCScript()
    {
        AsyncLine = 3200;
        AsyncFMax = 3200;
        Receiver = new ReceiverVirtual();
        Receiver.AddSinWaves(60, 5);
    }

    public void Run()
    {
        Receiver.Start();
    }
}