using NCCCommon;
using NCCCommon.ModuleProtocol.Daq5509;
using NADACommonCalibrator.PlotControl;

public class NCCScript
{
    public string ConnectionStr { get; set; }

    public VisaConnection Visa = new VisaConnection();

    public NCCScript()
    {
        ConnectionStr = "USB0::2391::8967::MY50001685::0::INSTR";
    }

    public void Run()
    {
        Visa.Open(ConnectionStr);

        Visa.Send("Output:SYNC On");
        Visa.Send("Output1 ON");
        Visa.Send("Output1:Load INF");
        Visa.Send("SOURCE1:Function Sin");
        Visa.Send("SOURCE1:Freq 100");
        Visa.Send("SOURCE1:Volt:Offset 4.7");
        Visa.Send("SOURCE1:Volt:Unit Vpp");

        Visa.Close();
    }
}