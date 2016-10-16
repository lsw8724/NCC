using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using NADACommonCalibrator.PlotControl;

public class Items
{
    public int Frequency { get; set; }
    public int Amplitude { get; set; }
    public float? Ch1 { get; set; }
    public float? Ch2 { get; set; }
    public float? Ch3 { get; set; }
    public float? Ch4 { get; set; }
    public float? Ch5 { get; set; }
    public float? Ch6 { get; set; }
    public float? Ch7 { get; set; }
    public float? Ch8 { get; set; }
}

public class NCCScript
{
    public string Description { get { return "5509 Connect Test"; } }
    public DaqGain HWGain { get; set; }
    public DaqSamplingRate SamplingRate { get; set; }
    public DaqInputType InputType { get; set; }
    public string Ip { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }

    public ReceiverDaq5509 Receiver = new ReceiverDaq5509();

    public NCCScript()
    {
        Ip = "192.168.0.14";
        AsyncLine = 3200;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
        InputType = DaqInputType.AC;
        HWGain = DaqGain._1;
        SamplingRate = DaqSamplingRate._8192;
    }

    public void Run()
    {
        Receiver.Start();

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(20,40);

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(520, 450);

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(220, 340);
    }
}

