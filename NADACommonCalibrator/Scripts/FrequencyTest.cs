﻿using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;

public class NCCScript
{
    public string Description { get { return "주파수 검사"; } }
    public string USBId { get; set; }
    public DaqGain HWGain { get; set; }
    public DaqSamplingRate SamplingRate { get; set; }
    public DaqInputType InputType { get; set; }
    public string ModuleIp { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }

    public VisaConnection Visa = new VisaConnection();
    public ReceiverDaq5509 Receiver = new ReceiverDaq5509();
    public System.Collections.Generic.List<TableItem> Items = new System.Collections.Generic.List<TableItem>();

    public NCCScript()
    {
        USBId = "USB0::2391::10759::MY52600381::0::INSTR";
        ModuleIp = "192.168.0.14";
        AsyncLine = 3200;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
        InputType = DaqInputType.AC;
        HWGain = DaqGain._1;
        SamplingRate = DaqSamplingRate._8192;

        Items.Add(new TableItem() { Frequency = 20, Amplitude = 30 });
        Items.Add(new TableItem() { Frequency = 40, Amplitude = 30 });
        Items.Add(new TableItem() { Frequency = 60, Amplitude = 30 });
        Items.Add(new TableItem() { Frequency = 80, Amplitude = 30 });
    }

    public void Run()
    {
        Receiver.Module.ModuleIp = this.ModuleIp;
        Receiver.Module.AsyncLine = this.AsyncLine;
        Receiver.Module.AsyncFMax = this.AsyncFMax;
        Receiver.Module.ICP = this.ICP;
        Receiver.Module.Sensitivity = this.Sensitivity;
        Receiver.Module.InputType = this.InputType;
        Receiver.Module.HWGain = this.HWGain;
        Receiver.Module.SamplingRate = this.SamplingRate;
        
        Receiver.Start();

        Visa.OpenByUSBPort(USBId);
        System.Threading.Thread.Sleep(1000);

        Visa.Send("Output:SYNC On");
        Visa.Send("Output1 ON");
        Visa.Send("Output1:Load INF");
        Visa.Send("SOURCE1:Function Sin");
        Visa.Send("SOURCE1:Freq 60");
        Visa.Send("SOURCE1:Volt:Offset 4.7");
        Visa.Send("SOURCE1:Volt:Unit Vpp");

        Visa.Close();

        Receiver.Stop();
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
}