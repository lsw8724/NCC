using NCCCommon;
using NCCCommon.ModuleProtocol.Daq5509;
using NADACommonCalibrator.PlotControl;

public class NCCScript
{
    public string Description { get { return "펑션 LAN 테스트"; } }
    public string ConnectionStr { get; set; }

    public VisaConnection Visa = new VisaConnection();

    public NCCScript()
    {
        ConnectionStr = "TCP0::192.168.0.201";
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