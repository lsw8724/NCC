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
using NADACommonCalibrator;

namespace NADACommonCalibrator.PlotControl
{
    public partial class TabularControl : DevExpress.XtraEditors.XtraUserControl
    {
        public static MeasureCalcType MeasureType = MeasureCalcType.RMS;
        private static Queue<object[]> ParamQueue = new Queue<object[]>();
        private Queue<float[]> CorrectionQueue = new Queue<float[]>();
        delegate void DataRefreshCallback(List<object> items);
        public List<object> TableItems = new List<object>();
        public static List<object> XlsItems = new List<object>();
        private object ColumnObj { get; set; }
        private PlotType TableType { get; set; }
        private System.Reflection.MemberInfo[] Members { get; set; }
        private static float[] SWCorrectionValues { get; set; }
        public static int CorrectionValueCalcRowCount = 5;
        private int RcvCount = 0;

        public TabularControl(object columns, PlotType type, ref Action<IReceiveData[]> datasRcv)
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
                this.TableType = type;
                switch (type)
                {
                    case PlotType.RealTime:
                        gvTable.Columns.Add(new GridColumn() { Caption = "Time Stamp", FieldName = "TimeStamp", Visible = true });
                        gvTable.Columns.Add(new GridColumn() { Caption = "Kp1", FieldName = "Kp1", Visible = true });
                        gvTable.Columns.Add(new GridColumn() { Caption = "Kp2", FieldName = "Kp2", Visible = true });
                        Members = chMembers;
                        foreach (var member in Members)
                            gvTable.Columns.Add(new GridColumn() { Caption = member.Name, FieldName = member.Name, Visible = true });

                        break;
                    case PlotType.WorkSheet:
                        Members = columns.GetType().GetProperties().ToArray();
                        foreach (var member in Members)
                            gvTable.Columns.Add(new GridColumn() { Caption = member.Name, FieldName = member.Name, Visible = true });
                        break;
                    case PlotType.Correction:
                        Members = Members = chMembers;
                        gvTable.Columns.Add(new GridColumn() { Caption = "Ch", FieldName = "Ch", Visible = true });
                        gvTable.Columns.Add(new GridColumn() { Caption = "Direct", FieldName = "Direct", Visible = true });
                        gvTable.Columns.Add(new GridColumn() { Caption = "Correction Value", FieldName = "CV", Visible = true});
                        break;
                    default: break;
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
                case DataType.WaveDatas:
                    break;
            }
            return data;
        }

        private void MeasureData_Received(IReceiveData[] rcvDatas)
        {
            var data = ParseDatas(rcvDatas);
            if (data == null) return;

            if (ColumnObj == null) return;
            switch (TableType)
            {
                case PlotType.RealTime:
                    Dictionary<string, object> dic_rt = new Dictionary<string, object>();
                    dic_rt.Add("TimeStamp", data[0].TimeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    dic_rt.Add("Kp1", data[0].Rpm);
                    dic_rt.Add("Kp2", data[4].Rpm);
                    for (int ch = 0; ch < data.Length; ch++)
                    {
                        string memberName = "Ch" + (ch + 1);
                        var property = ColumnObj.GetType().GetProperty(memberName);
                        if (property == null) continue;
                        dic_rt.Add(memberName, Math.Round(data[ch].Scalar * SWCorrectionValues[ch], 3));
                    }
                    TableItems.Add(Expando(dic_rt));
                    break;
                case PlotType.WorkSheet:
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

                    for (int kpId = 0; kpId < 2; kpId++)
                    {
                        string memberName = "Kp" + (kpId + 1);
                        var property = ColumnObj.GetType().GetProperty(memberName);
                        if (property == null) continue;
                        dic_ws.Add(memberName, data[kpId*4].Rpm);
                    }
                   
                    var obj = Expando(dic_ws);
                    TableItems.Add(obj);
                    XlsItems.Add(obj);
                    break;
                case PlotType.Correction:
                    TableItems.Clear();
                    for (int ch = 0; ch < data.Length; ch++)
                    {
                        Dictionary<string, object> dic_cr = new Dictionary<string, object>();
                        dic_cr.Add("Ch", data[ch].ChannelId);
                        dic_cr.Add("Direct",Math.Round(data[ch].Scalar,3));
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
            var mouseEA = e as MouseEventArgs;
            if (mouseEA.Button == MouseButtons.Left) return;
            popupMenu1.ShowPopup(PointToScreen(new Point(mouseEA.X,mouseEA.Y)));
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

        private void barBtn_saveCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.DefaultExt = ".csv";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            string destFileName = Path.Combine(sfd.FileName);
            gvTable.ExportToCsv(destFileName);
            if (File.Exists(destFileName))
                Process.Start(destFileName);
        }

        private void barBtn_saveXLS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xlsx";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            string destFileName = Path.Combine(sfd.FileName);
            SaveXLS("DAQ & Omap Template.xlsx", destFileName);
            if (File.Exists(destFileName))
                Process.Start(destFileName);
        }

        private void barBtn_copy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        public static void SaveXLS(string templateFileName, string saveFileName)
        {
            var xlsManager = new ExcelIOManager();

            var sheetItems = new SheetItems(XlsItems);
            xlsManager.CreateExcel(templateFileName, saveFileName, sheetItems);
            if (File.Exists(saveFileName))
                Process.Start(saveFileName);
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
