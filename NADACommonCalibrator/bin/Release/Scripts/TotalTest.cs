using NCCCommon;
using NCCCommon.ModuleProtocol.Daq5509;
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
    public float? Kp1 { get; set; }
    public float? Kp2 { get; set; }
}

public class NCCScript
{
    public PlotType[] PlotGroup = new PlotType[] { PlotType.WorkSheet, PlotType.Correction };
    public string Description { get { return "종합 검사"; } }
    public string ConnectionStr { get; set; }
    public DaqGain HWGain { get; set; }
    public DaqSamplingRate SamplingRate { get; set; }
    public DaqInputType InputType { get; set; }
    public string Ip { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }

    public VisaConnection Visa = new VisaConnection();
    public ReceiverDaq5509 Receiver = new ReceiverDaq5509();

    public NCCScript()
    {
        ConnectionStr = "USB0::2391::10759::MY52600381::0::INSTR";
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
        System.Threading.Thread.Sleep(3000);

        Visa.Open(ConnectionStr);

        Visa.Send("Output:SYNC On");
        Visa.Send("Output1 ON");
        Visa.Send("Output1:Load INF");
        Visa.Send("SOURCE1:Function Sin");
        Visa.Send("SOURCE1:Volt:Unit Vpp");
        Visa.Send("SOURCE1:Volt:Offset 4.7");
        Visa.Send("SOURCE1:Volt 0.787");

        //주파수 검사
        SetFreq(20);
        SetFreq(40);
        SetFreq(80);
        SetFreq(100);
        SetFreq(160);
        SetFreq(315);
        SetFreq(630);
        SetFreq(1250);
        SetFreq(2500);
        SetFreq(5000);

        //진폭 검사
        Visa.Send("SOURCE1:Freq 100");
        SetAmp(50);
        SetAmp(100);
        SetAmp(200);
        SetAmp(500);
        SetAmp(1000);

        //회전수 검사
        SetFreq(20);
        SetFreq(30);
        SetFreq(60);
        SetFreq(90);
        SetFreq(120);

        Visa.Close();

        Receiver.Stop();
    }

    private void SetAmp(float amp)
    {
        Visa.Send("SOURCE1:Volt " + amp / 1000f, 5000);
        TabularControl.InsertRow(100, amp);
    }

    private void SetFreq(int freq)
    {
        Visa.Send("SOURCE1:Freq " + freq, 5000);
        TabularControl.InsertRow(freq, 787);
    }
}