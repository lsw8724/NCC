using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NCCCommon.ModuleProtocol;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using System.Reflection;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace NADACommonCalibrator.PlotControl
{
    public enum TabularMode
    {
        RealTime,
        WorkSheet,
        Correction,
    }

    public partial class TabularControl : DevExpress.XtraEditors.XtraUserControl
    {
        private static Queue<object[]> ParamQueue = new Queue<object[]>();
        private Queue<float[]> CorrectionQueue = new Queue<float[]>();
        delegate void DataRefreshCallback(List<object> items);
        public List<object> TableItems = new List<object>();
        private object ColumnObj { get; set; }
        private TabularMode Mode { get; set; }
        private System.Reflection.MemberInfo[] Members { get; set; }
        private float[] SWCorrectionValues { get; set; }
        public static int CorrectionValueCalcRowCount = 5;
        private int RcvCount = 0;

        public TabularControl(object columns, TabularMode mode, ref Action<IReceiveData[]> datasRcv)
        {
            InitializeComponent();

            if (columns != null)
            {
                datasRcv += MeasureData_Received;

                var chMembers = columns.GetType().GetProperties().Where(x => x.Name.Contains("Ch")).ToArray();
                SWCorrectionValues = new float[chMembers.Length];

                for (int ch = 0; ch < SWCorrectionValues.Length; ch++)
                    SWCorrectionValues[ch] = 1.0f;

                ColumnObj = columns;
                this.Mode = mode;
                switch (Mode)
                {
                    case TabularMode.RealTime:
                        gvTable.Columns.Add(new GridColumn() { Caption = "Time Stamp", FieldName = "TimeStamp", Visible = true });
                        Members = chMembers;
                        foreach (var member in Members)
                            gvTable.Columns.Add(new GridColumn() { Caption = member.Name, FieldName = member.Name, Visible = true });

                        break;
                    case TabularMode.WorkSheet:
                        Members = columns.GetType().GetProperties().ToArray();
                        foreach (var member in Members)
                            gvTable.Columns.Add(new GridColumn() { Caption = member.Name, FieldName = member.Name, Visible = true });
                        break;
                    case TabularMode.Correction:
                        Members = Members = chMembers;
                        gvTable.Columns.Add(new GridColumn() { Caption = "Ch", FieldName = "Ch", Visible = true });
                        gvTable.Columns.Add(new GridColumn() { Caption = "Direct", FieldName = "Direct", Visible = true });
                        gvTable.Columns.Add(new GridColumn() { Caption = "Correction Value", FieldName = "CV", Visible = true});
                        break;
                }
            }
        }

        private IMeasuredData[] ParseDatas(IReceiveData[] rcvDatas)
        {
            IMeasuredData[] data = null;

            var first = rcvDatas.FirstOrDefault();
            if (first == null) return null;
            switch (first.Type)
            {
                case  DataType.MeasureData :
                    data = rcvDatas as IMeasuredData[];
                    break;
                case DataType.VectorData:
                    var vec = rcvDatas as VectorData[];
                    data = vec.Select(x => new Measure_RMS()
                    {
                        Value = x.Direct,
                        Time = x.DateTime.ToLocalDateTime()
                    }).ToArray();
                    break;
                case DataType.WaveData:
                    break;
            }
            return data;
        }

        private void MeasureData_Received(IReceiveData[] rcvDatas)
        {
            var data = ParseDatas(rcvDatas);
            if (data == null) return;

            if (ColumnObj == null) return;
            switch (Mode)
            {
                case TabularMode.RealTime:
                    Dictionary<string, object> dic_rt = new Dictionary<string, object>();
                    dic_rt.Add("TimeStamp", data[0].TimeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int ch = 0; ch < data.Length; ch++)
                    {
                        string memberName = "Ch" + (ch + 1);
                        var property = ColumnObj.GetType().GetProperty(memberName);
                        if (property == null) continue;
                        dic_rt.Add(memberName, Math.Round(data[ch].Scalar * SWCorrectionValues[ch], 3));
                    }
                    TableItems.Add(Expando(dic_rt));
                    break;
                case TabularMode.WorkSheet:
                    Dictionary<string, object> dic_ws = new Dictionary<string, object>();
                    if (ParamQueue.Count == 0) return;
                    object[] param = null;

                    lock (((ICollection)ParamQueue).SyncRoot)
                    {
                        param = ParamQueue.Dequeue();
                    }
                        
                    for (int i = 0; i < param.Length; i++)
                    {
                        var prop = ColumnObj.GetType().GetProperties();
                        dic_ws.Add(prop[i].Name, param[i]);
                    }

                    for (int ch = 0; ch < data.Length; ch++)
                    {
                        string memberName = "Ch" + (ch + 1);
                        var property = ColumnObj.GetType().GetProperty(memberName);
                        if (property == null) continue;
                        dic_ws.Add(memberName, Math.Round(data[ch].Scalar * SWCorrectionValues[ch], 3));
                    }
                    TableItems.Add(Expando(dic_ws));
                    break;
                case TabularMode.Correction:
                    TableItems.Clear();
                    for (int ch = 0; ch < data.Length; ch++)
                    {
                       
                        Dictionary<string, object> dic_cr = new Dictionary<string, object>();
                        dic_cr.Add("Ch", data[ch].ChannelId);
                        dic_cr.Add("Direct", data[ch].Scalar);
                        dic_cr.Add("CV", Math.Round(SWCorrectionValues[ch],3));
                        TableItems.Add(Expando(dic_cr));
                    }
                    break;
            }
            UpdateCorrectionValue(data);
            DataRefresh(TableItems);
        }

        private void DataRefresh(List<object> items)
        {
            if (this.InvokeRequired)
            {
                DataRefreshCallback callback = new DataRefreshCallback(DataRefresh);
                this.Invoke(callback, items);
            }
            else
            {
                gcTable.DataSource = items;
                gvTable.RefreshData();
            }
        }

        private ExpandoObject Expando(IEnumerable<KeyValuePair<string, object>> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;
            foreach (var item in dictionary)
                expandoDic.Add(item);

            return expando;
        }

        private void gvTable_RowCountChanged(object sender, EventArgs e)
        {
            gvTable.FocusedRowHandle = gvTable.RowCount - 1;
        }

        private void gcTable_Click(object sender, EventArgs e)
        {
            string DownloadedFile = Path.Combine("D:\\문서\\test.csv");

            gvTable.ExportToCsv(DownloadedFile);

            Process.Start(DownloadedFile);
        }

        public static void InsertRow(params object[] p)
        {
            lock (((ICollection)ParamQueue).SyncRoot)
            {
                ParamQueue.Enqueue(p);
            }

            while (ParamQueue.Count > 0)
                Thread.Sleep(100);
        }

        private void UpdateCorrectionValue(IMeasuredData[] data)
        {
            if (RcvCount < CorrectionValueCalcRowCount)
            {
                CorrectionQueue.Enqueue(data.Select(x => x.Scalar).ToArray());
                RcvCount++;
            }
            else if (RcvCount == CorrectionValueCalcRowCount)
            {
                var sumValues = new float[data.Length];
                sumValues = sumValues.Select((x, ch) => CorrectionQueue.Sum(m => m[ch])).ToArray();
                SWCorrectionValues = sumValues.Select(x => x / (float)CorrectionQueue.Count).ToArray();
            }
        }
    }

    public class CorrectionItem
    {
        private IMeasuredData Data;
        private float CorrectionValue;

        public int Ch { get { return Data.ChannelId; } }
        public float Direct { get { return Data.Scalar; } }
        public float CV {get{return CorrectionValue;}}

        public CorrectionItem(IMeasuredData data, float cv)
        {
            Data = data;
            CorrectionValue = cv;
        }
    }
}
