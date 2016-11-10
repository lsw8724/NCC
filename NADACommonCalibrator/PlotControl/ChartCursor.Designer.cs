namespace NADACommonCalibrator.PlotControl
{
    partial class ChartCursor
    {
        private Steema.TeeChart.Tools.RectangleTool CursorInfo;
        private Steema.TeeChart.TChart OwnerChart;
        private void InitializeComponent(Steema.TeeChart.TChart chart)
        {
            OwnerChart = chart;
            Pen.Color = System.Drawing.Color.LightYellow;
            Pen.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            SnapStyle = Steema.TeeChart.Tools.SnapStyle.Vertical;
            Style = Steema.TeeChart.Tools.CursorToolStyles.Scope;
            Snap = true;
            chart.Tools.Add(this);

            CursorInfo = new Steema.TeeChart.Tools.RectangleTool();
            chart.Tools.Add(CursorInfo);
            CursorInfo.AutoSize = true;
            CursorInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            CursorInfo.Shape.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            CursorInfo.Shape.Brush.Gradient.Transparency = 20;
            CursorInfo.Shape.Font.Bold = true;
            CursorInfo.Shape.Font.Brush.Color = System.Drawing.Color.White;
            CursorInfo.Shape.Font.Brush.Gradient.Transparency = 20;
            CursorInfo.Shape.Font.Name = "Consolas";
            CursorInfo.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.Black;
            CursorInfo.Shape.Font.Size = 11;
            CursorInfo.Shape.Font.SizeFloat = 11F;
            chart.MouseDown += TChart_MouseDown;
            chart.MouseUp += TChart_MouseUp;
        }
    }
}
