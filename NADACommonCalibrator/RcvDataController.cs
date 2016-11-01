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
                switch (TabularControl.MeasureType)
                {
                    case MeasureCalcType.RMS:
                        DatasReceived(fftDatas.Select(x => new Measure_RMS(x)).ToArray());
                        break;
                    default: break;
                }
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
                foreach (var conrtrol in Controls)
                    conrtrol.ProcessData(datas);
                var first = datas.FirstOrDefault();
                if (first != null)
                {
                    switch (first.Type)
                    {
                        case DataType.WaveDatas:
                            if (FFTCalculated == null) break;
                            var waves = datas as WaveData[];
                            FFTCalculated(waves.Select(x => new SpectrumData(1, x)).ToArray());
                            switch (TabularControl.MeasureType)
                            {
                                case MeasureCalcType.PK:
                                    DatasReceived(waves.Select(x => new Measure_Peak(x)).ToArray());
                                    break;
                                case MeasureCalcType.PP:
                                    DatasReceived(waves.Select(x => new Measure_P2P(x)).ToArray());
                                    break;
                                default: break;
                            }
                            break;
                        case DataType.VectorData: break;
                        case DataType.MeasureData: break;
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
