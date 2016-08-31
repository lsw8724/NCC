using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NADACommonCalibrator.ConfigControl;
using NCCCommon.ModuleProtocol.OmapProtocol;
using NCCCommon.ModuleProtocol;
using NCCCommon;

namespace NADACommonCalibrator.Receiver
{
    public class Receiver_Omap : IWavesReceiver, IConvertableItems, IGettableReceiverType
    {
        private OmapReceiver OmapReceiver = new OmapReceiver();

        public Receiver_Omap()
        {
            OmapReceiver.ModuleIp = "192.168.0.10";
            OmapReceiver.WavesReceived += Waves_Received;
        }

        public event Action<WaveData[]> WavesReceived;

        private void ModuleWaves_Received(ModuleWaves waves)
        {
            throw new NotImplementedException();
        }

        private void Waves_Received(WaveData[] waves)
        {
            WavesReceived(waves);
        }

        public void Start()
        {
            OmapReceiver.Start();
        }

        public void Stop()
        {
            if (OmapReceiver != null)
                OmapReceiver.Stop();
        }

        public void Dispose()
        {
        }

        public override string ToString()
        {
            return "Omap Module";
        }

        public List<object> ToItems()
        {
            var items = new List<object>();
            foreach (var ch in OmapReceiver.SensorChannels)
                items.Add(new OmapChannelItem(OmapReceiver, ch));
            return items;
        }

        public ReceiverType GetReceiverType()
        {
            return ReceiverType.Omap;
        }
    }
}
