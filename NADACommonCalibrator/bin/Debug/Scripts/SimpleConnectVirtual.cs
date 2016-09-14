using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using System.ComponentModel;


public partial class NCCScript
{
    public string Description { get { return "가상모듈 연결"; } }
    [Browsable(false)]
    public ReceiverVirtual Receiver { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }

    public NCCScript()
    {
        AsyncLine = 3200;
        AsyncFMax = 3200;
        Receiver = new ReceiverVirtual(AsyncFMax, AsyncLine);
        Receiver.AddSinWaves(60, 5);
    }

    public void Run()
    {
        Receiver.Start();
    }
}

public class TableItem
{
    public string Frequency { get; set; }
    public string Amplitude { get; set; }
    public string Ch1 { get; set; }
    public string Ch2 { get; set; }
    public string Ch3 { get; set; }
    public string Ch4 { get; set; }
    public string Ch5 { get; set; }
    public string Ch6 { get; set; }
    public string Ch7 { get; set; }
    public string Ch8 { get; set; }
}