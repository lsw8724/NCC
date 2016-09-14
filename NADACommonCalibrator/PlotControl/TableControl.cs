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
    public partial class TableControl : DevExpress.XtraEditors.XtraUserControl
    {
        public TableControl(object source)
        {
            InitializeComponent();
            MeasureCalculator.AfterFFT += FFTData_Received;

            if (source != null)
            {
                gcTable.DataSource = source;
                var members = source.GetType().GetMembers().Where(x => x.MemberType == System.Reflection.MemberTypes.Property).ToArray();
                foreach (var member in members)
                    gvTable.Columns.Add(new GridColumn() { Caption = member.Name, FieldName = member.Name, Visible = true });
            }
        }

        private void FFTData_Received(SpectrumData[] fftData)
        {

        }
    }
}
