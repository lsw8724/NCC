namespace NADACommonCalibrator.PlotControl
{
    partial class ChartCursor
    {
        public Steema.TeeChart.Tools.CursorTool GuideCursor;
        private Steema.TeeChart.Tools.RectangleTool CursorInfo;
        private void InitializeComponent(Steema.TeeChart.TChart chart)
        {
            Value = -1;
            chart.Tools.Add(this);
            Pen.Color = System.Drawing.Color.Yellow;
            Axis = chart.Axes.Bottom;
            Steema.TeeChart.Tools.CursorTool cursor = new Steema.TeeChart.Tools.CursorTool();
            cursor.Style = Steema.TeeChart.Tools.CursorToolStyles.Scope;
            cursor.Pen.Color = System.Drawing.Color.LightYellow;
            cursor.Pen.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            cursor.Pen.Transparency = 20;
            cursor.SnapStyle = Steema.TeeChart.Tools.SnapStyle.Vertical;
            cursor.Snap = true;
            cursor.FollowMouse = true;
            chart.Tools.Add(cursor);
            GuideCursor = cursor;

            Steema.TeeChart.Tools.RectangleTool CursorInfoRectTool = new Steema.TeeChart.Tools.RectangleTool();
            chart.Tools.Add(CursorInfoRectTool);
            CursorInfoRectTool.AutoSize = true;
            CursorInfoRectTool.Cursor = System.Windows.Forms.Cursors.Hand;
            CursorInfoRectTool.Shape.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            CursorInfoRectTool.Shape.Brush.Gradient.Transparency = 20;
            CursorInfoRectTool.Shape.Font.Bold = true;
            CursorInfoRectTool.Shape.Font.Brush.Color = System.Drawing.Color.White;
            CursorInfoRectTool.Shape.Font.Brush.Gradient.Transparency = 20;
            CursorInfoRectTool.Shape.Font.Name = "Consolas";
            CursorInfoRectTool.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.Black;
            CursorInfoRectTool.Shape.Font.Size = 11;
            CursorInfoRectTool.Shape.Font.SizeFloat = 11F;
            CursorInfo = CursorInfoRectTool;

            chart.MouseClick += TChart_Click;
        }
    }
}
