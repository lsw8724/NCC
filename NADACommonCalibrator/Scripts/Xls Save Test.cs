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
    public int AsyncFMax { get; set; }
    public int AsyncLine { get; set; }
    public ReceiverVirtual Receiver = new ReceiverVirtual();

    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public SpectrumControl Spectrum { get; set; }
    [PlotControl(250), System.ComponentModel.Browsable(false)]
    public TimeBaseControl TimeBase { get; set; }
    [PlotControl(240), System.ComponentModel.Browsable(false)]
    public TabularControl Tabular { get; set; }

    public NCCScript()
    {
        Tabular = new TabularControl(PlotType.WorkSheet);
        Spectrum = new SpectrumControl();
        TimeBase = new TimeBaseControl();

        AsyncFMax = 3200;
        AsyncLine = 800;
        Receiver.SingleSinWave(100, 0.1f);
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
        Tabular.SaveXLS("DAQ & Omap Template.xlsx", "D:\\문서\\Result.xlsx");
    }

    private void SetAmp(float amp)
    {
        Receiver.SingleSinWave(100, amp / 1000);
        Tabular.LowFreq = 90;
        Tabular.HighFreq = 110;
        Tabular.InsertRow(100, amp);
    }

    private void SetFreq(int freq)
    {
        Receiver.SingleSinWave(freq, 0.787f);
        Tabular.LowFreq = freq - 10;
        Tabular.HighFreq = freq + 10;
        Tabular.InsertRow(freq, 787);
    }
}

