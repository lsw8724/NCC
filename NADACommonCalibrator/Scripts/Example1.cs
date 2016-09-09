using NADACommonCalibrator;
using System.ComponentModel;

public class NCCScript
{
    public string Description { get { return "주파수 검사"; } }
    public string USBId { get; set; }
    [Browsable(false)]
    public VisaConnection Visa { get; set; }

    public NCCScript()
    {
        Visa = new VisaConnection();
        USBId = "USB0::2391::8967::MY50001685::0::INSTR";
    }

    public void Run()
    {
        Visa.OpenByUSBPort(USBId);

        //TODO Task

        Visa.Close();
    }
}
