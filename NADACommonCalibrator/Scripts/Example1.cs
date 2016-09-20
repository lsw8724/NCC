using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;

public class NCCScript
{
    [System.ComponentModel.Browsable(false)]
    public VisaConnection Visa { get; set; }
    [System.ComponentModel.Browsable(false)]
    public IWavesReceiver Receiver { get; set; }
    public string Description { get { return "예제 스크립트"; } }
    public string USBId { get; set; }
  
    public string ModuleIp { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }
    public DaqInputType InputType { get; set; }

    public System.Collections.Generic.List<TableItem> Items = new System.Collections.Generic.List<TableItem>();

    public NCCScript()
    {
        Visa = new VisaConnection();
        USBId = "USB0::2391::10759::MY52600381::0::INSTR";

        ModuleIp = "192.168.0.11";
        AsyncLine = 3200;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
        InputType = DaqInputType.AC;
        Receiver = new ReceiverDaq5509(ModuleIp);

        Items.Add(new TableItem(20, 30));
        Items.Add(new TableItem(40, 30));
        Items.Add(new TableItem(60, 30));
        Items.Add(new TableItem(80, 30));
    }

    public void Run()
    {
        Visa.OpenByUSBPort(USBId);
        Visa.Send("Output:SYNC On");
        Visa.Send("Output1 ON");
        Visa.Send("Output1:Load INF");
        Visa.Send("SOURCE1:Function Sin");
        Visa.Send("Output2 ON");
        Visa.Send("Output2:Load INF");
        Visa.Send("SOURCE2:Function Sin");
        Visa.Send("SOURCE1:Freq 60");
        Visa.Send("SOURCE1:Volt:Offset 4.7");
        Visa.Send("SOURCE1:Volt:Unit Vpp");

        Visa.Close();
    }
}

public class TableItem
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
    public TableItem() { }
    public TableItem(int freq, int amp)
    {
        Frequency = freq;
        Amplitude = amp;
    }
}
