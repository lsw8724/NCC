using NADACommonCalibrator.PlotControl;
using NCCCommon.ModuleProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NADACommonCalibrator
{
    public class RcvDataController
    {
        public Action<IReceiveData[]> DatasReceived;
        public Action<SpectrumData[]> FFTCalculated;
        private List<IPlotControl> Controls = new List<IPlotControl>();
        public float SpectrumRes { get; set; }

        public RcvDataController(List<IPlotControl> controls)
        {
            
            this.Controls = controls;
            DatasReceived += (datas) => { ProcessRcvDatas(datas); };
            FFTCalculated += (fft) => { ProcessFFTDatas(fft); };
        }

        private void ProcessFFTDatas(SpectrumData[] fftDatas)
        {
            try
            {
                foreach (var conrtrol in Controls.Where(x=>x.Type != PlotType.TimeBase))
                    conrtrol.ProcessData(fftDatas);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void ProcessRcvDatas(IReceiveData[] datas)
        {
            try
            {
                foreach (var conrtrol in Controls.Where(x => x.Type != PlotType.Spectrum))
                    conrtrol.ProcessData(datas);
                var first = datas.FirstOrDefault();
                if (first != null)
                {
                    switch (first.Type)
                    {
                        case DataType.WaveDatas:
                            if (FFTCalculated == null) break;
                            var waves = datas as WaveData[];
                            FFTCalculated(waves.Select(x => new SpectrumData(SpectrumRes, x)).ToArray());
                            break;
                        case DataType.VectorData: break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
