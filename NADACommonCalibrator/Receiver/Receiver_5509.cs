using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NADACommonCalibrator.ConfigControl;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using NCCCommon.ModuleProtocol;
using NCCCommon;

namespace NADACommonCalibrator.Receiver
{
    public interface IGettableReceiverType
    {
        ReceiverType GetReceiverType();
    }

    public interface IConvertableItems
    {
        List<object> ToItems();
    }

    public class Receiver_5509 : IConvertableItems, IGettableReceiverType
    {
        private Daq5509Receiver DaqReceiver = new Daq5509Receiver() { ModuleIp = "192.168.0.10" };
        public event Action<WaveData[]> WavesReceived;

        private void DaqReceiver_WaveReceived(WaveData[] waves)
        {
            WavesReceived(waves);
        }

        public void Start()
        {
            DaqReceiver.Start();
        }

        public void Stop()
        {
            if (DaqReceiver != null)
                DaqReceiver.Stop();
        }

        public void Dispose()
        {
        }

        public override string ToString()
        {
            return "Daq5509 Module";
        }

        public List<object> ToItems()
        {
            var items = new List<object>();
            foreach(var ch in DaqReceiver.Channels)
                items.Add(new Daq5509ChannelItem(DaqReceiver, ch));
            return items;
        }

        public ReceiverType GetReceiverType()
        {
            return ReceiverType.Daq5509;
        }
    }
}
