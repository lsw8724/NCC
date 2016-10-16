﻿using NADACommonCalibrator;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.OmapProtocol;
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
    public string Description { get { return "Omap Connect Test"; } }
    public int HWGain { get; set; }
    public string Ip { get; set; }
    public int AsyncLine { get; set; }
    public int AsyncFMax { get; set; }
    public bool ICP { get; set; }
    public float Sensitivity { get; set; }
    public AlarmBufferMode AlarmBufferMode { get; set; }

    public ReceiverOmap Receiver = new ReceiverOmap();

    public NCCScript()
    {
        Ip = "192.168.0.11";
        HWGain = 1;
        AsyncLine = 3200;
        AsyncFMax = 3200;
        ICP = true;
        Sensitivity = 7.87f;
        AlarmBufferMode = AlarmBufferMode.Slow;
    }

    public void Run()
    {        
        Receiver.Start();

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(20, 40);

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(520, 450);

        System.Threading.Thread.Sleep(2000);
        TabularControl.InsertRow(220, 340);
    }
}

