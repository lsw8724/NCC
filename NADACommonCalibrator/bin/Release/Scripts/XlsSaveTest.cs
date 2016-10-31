using NCCCommon.ModuleProtocol.Virtual;
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
    public PlotType[] PlotGroup = new PlotType[] { PlotType.TimeBase, PlotType.WorkSheet };
    public string Description { get { return "Xls Save Test"; } }
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverVirtual Receiver = new ReceiverVirtual();
    
    public NCCScript()
    {
        AsyncFMax = 3200;
        AsyncLine = 800;
        Receiver.AddSinWaves(60, 0.787f);
        Receiver.AddSinWaves(10, 0.787f);
    }

    public void Run()
    {
        Receiver.Start();

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
        TabularControl.SaveXLS("DAQ & Omap Template.xlsx", "D:\\문서\\Result.xlsx");
    }

    private void Sleep(int millisec)
    {
        System.Threading.Thread.Sleep(millisec);
    }

    private void SetAmp(float amp)
    {
        //Sleep(1000);
        TabularControl.InsertRow(100, amp);
    }

    private void SetFreq(int freq)
    {
        //Sleep(1000);
        TabularControl.InsertRow(freq, 787);
    }
}

