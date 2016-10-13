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
using NADACommonCalibrator.Measure;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace NADACommonCalibrator.PlotControl
{
    public enum TabularMode
    {
        RealTime,
        WorkSheet
    }

    public partial class TabularControl : DevExpress.XtraEditors.XtraUserControl
    {
        private static Queue<object[]> ParamQueue { get; set; }
        delegate void DataRefreshCallback(List<object> items);
        List<object> TableItems = new List<object>();
        private object ColumnObj { get; set; }
        private TabularMode Mode { get; set; }
        private System.Reflection.MemberInfo[] Members { get; set; }
        public TabularControl(object columns, TabularMode mode)
        {
            InitializeComponent();
            ParamQueue = new Queue<object[]>();
            MeasureCalculator.AfterMeasureCalc += MeasureData_Received;

            if (columns != null)
            {
                ColumnObj = columns;
                this.Mode = mode;
                switch (Mode)
                {
                    case TabularMode.RealTime:
                        gvTable.Columns.Add(new GridColumn() { Caption = "Time Stamp", FieldName = "TimeStamp", Visible = true });
                        Members = columns.GetType().GetProperties().Where(x => x.Name.Contains("Ch")).ToArray();
                        break;
                    case TabularMode.WorkSheet:
                        Members = columns.GetType().GetProperties().ToArray();
                        break;
                }
                foreach (var member in Members)
                    gvTable.Columns.Add(new GridColumn() { Caption = member.Name, FieldName = member.Name, Visible = true });
            }
        }

        private void MeasureData_Received(IMeasure[] data)
        {
            if (ColumnObj == null) return;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            switch (Mode)
            {
                case TabularMode.RealTime:
                    dic.Add("TimeStamp", data[0].GetTimeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case TabularMode.WorkSheet:
                    if (ParamQueue.Count > 0)
                    {
                        object[] param = null;

                        lock (((ICollection)ParamQueue).SyncRoot)
                        {
                            param = ParamQueue.Dequeue();
                        }
                        
                        for (int i = 0; i < param.Length; i++)
                        {
                            var prop = ColumnObj.GetType().GetProperties();
                            dic.Add(prop[i].Name, param[i]);
                        }
                    }
                    else
                        return;

                    for (int i = 0; i < data.Length; i++)
                    {
                        string memberName = "Ch" + (i + 1);
                        var property = ColumnObj.GetType().GetProperty(memberName);
                        if (property == null) continue;
                        dic.Add(memberName, Math.Round(data[i].GetScalar, 3));
                    }
                    TableItems.Add(Expando(dic));
                    DataRefresh(TableItems);
                    break;
            }
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

        public ExpandoObject Expando(IEnumerable<KeyValuePair<string, object>> dictionary)
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

        public static void InsertRow(params object[] p)
        {
            lock (((ICollection)ParamQueue).SyncRoot)
            {
                ParamQueue.Enqueue(p);
            }

            while (ParamQueue.Count > 0)
                Thread.Sleep(100);
        }
    }
}
