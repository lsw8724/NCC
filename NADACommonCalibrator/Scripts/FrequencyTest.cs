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
    public float? Rpm { get; set; }
}

public class NCCScript
{
    public string Description { get { return "주파수 검사"; } }
    public string USBId { get; set; }
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
        USBId = "USB0::2391::10759::MY52600381::0::INSTR";
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
        //Receiver.Start();

        Visa.OpenByUSBPort(USBId);

        Visa.Send("Output:SYNC On");
        Visa.Send("Output1 ON");
        Visa.Send("Output1:Load INF");
        Visa.Send("SOURCE1:Function Sin");
        Visa.Send("SOURCE1:Volt:Offset 4.7");
        Visa.Send("SOURCE1:Volt:Unit Vpp");



        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(20, 40);

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(520, 450);

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(220, 340);


        //var millisec = 2000;
        //Visa.Send("SOURCE1:Freq 60");
        //Visa.Send("SOURCE1:Volt 100", millisec);

        //Visa.Send("SOURCE1:Freq 80");
        //Visa.Send("SOURCE1:Volt 100", millisec);

        //Visa.Send("SOURCE1:Freq 100");
        //Visa.Send("SOURCE1:Volt 100", millisec);

        //Visa.Send("SOURCE1:Freq 120");
        //Visa.Send("SOURCE1:Volt 100", millisec);

        //Visa.Send("SOURCE1:Freq 140");
        //Visa.Send("SOURCE1:Volt 100", millisec);

        //Visa.Close();

        //Receiver.Stop();
    }
}