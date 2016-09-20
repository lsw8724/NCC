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

namespace NADACommonCalibrator.PlotControl
{
    public partial class TabularControl : DevExpress.XtraEditors.XtraUserControl
    {
        private Type TableItemType { get; set; }
        List<object> TableItems = new List<object>();
        private System.Reflection.MemberInfo[] Members { get; set; }
        public TabularControl(object columns ,object items)
        {
            InitializeComponent();
            MeasureCalculator.AfterFFT += FFTData_Received;

            if (columns != null)
            {
                TableItemType = columns.GetType();
                Members = columns.GetType().GetMembers().Where(x => x.MemberType == System.Reflection.MemberTypes.Property).ToArray();
                foreach (var member in Members)
                    gvTable.Columns.Add(new GridColumn() { Caption = member.Name, FieldName = member.Name, Visible = true });
            }
            gcTable.DataSource = items;
        }

        private void FFTData_Received(SpectrumData[] fftData)
        {
            //dynamic obj = TableItemType.Assembly.CreateInstance("TableItem");
            //obj.Ch1 = fftData[0].YValues[20];
            //obj.Ch2 = fftData[1].YValues[20];
            //obj.Ch3 = fftData[2].YValues[20];
            //obj.Ch4 = fftData[3].YValues[20];
            //obj.Ch5 = fftData[4].YValues[20];
            //obj.Ch6 = fftData[5].YValues[20];
            //obj.Ch7 = fftData[6].YValues[20];
            //obj.Ch8 = fftData[7].YValues[20];
            //TableItems.Add(obj);
            //gcTable.Invoke(new Action(() => { gcTable.DataSource = TableItems; gvTable.RefreshData(); }));
        }
    }
}
