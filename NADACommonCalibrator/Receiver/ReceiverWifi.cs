using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCCCommon.ModuleProtocol.WifiProtocol;
using NCCCommon.ModuleProtocol.OmapProtocol;
using NCCCommon.ModuleProtocol;
using NCCCommon;
using System.Threading;

namespace NADACommonCalibrator.Receiver
{
    public class ReceiverWifi : SingleTask, IWavesReceiver
    {
        public WifiModule Module = new WifiModule();
        public TcpConnection TcpClient;

        public int AsyncFMax { get { return 3200; } }
        public int AsyncLine { get { return 3200; } }

        public event Action<IReceiveData[]> DatasReceived;

        protected override void OnNewTask(CancellationToken token)
        {
            //Module.Init();

            while (!token.IsCancellationRequested)
            {
                try
                {
                    //ConnectDaq();

                    ReadLoop(token);

                    //CloseDaq();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex);
                    Thread.Sleep(100);
                }
            }
        }

        private void ReadLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
               
            }
        }
    }
}
