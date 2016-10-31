namespace NADACommonCalibrator.PlotControl
{
    partial class TabularControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gcTable = new DevExpress.XtraGrid.GridControl();
            this.gvTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barBtn_saveCSV = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_saveXLS = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_copy = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTable
            // 
            this.gcTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTable.Location = new System.Drawing.Point(0, 0);
            this.gcTable.MainView = this.gvTable;
            this.gcTable.Name = "gcTable";
            this.gcTable.Size = new System.Drawing.Size(737, 379);
            this.gcTable.TabIndex = 0;
            this.gcTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTable});
            this.gcTable.Click += new System.EventHandler(this.gcTable_Click);
            // 
            // gvTable
            // 
            this.gvTable.GridControl = this.gcTable;
            this.gvTable.Name = "gvTable";
            this.gvTable.OptionsBehavior.Editable = false;
            this.gvTable.OptionsView.ShowGroupPanel = false;
            this.gvTable.RowCountChanged += new System.EventHandler(this.gvTable_RowCountChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_saveCSV),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_saveXLS),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_copy)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barBtn_saveCSV
            // 
            this.barBtn_saveCSV.Caption = "SaveCSV";
            this.barBtn_saveCSV.Id = 0;
            this.barBtn_saveCSV.Name = "barBtn_saveCSV";
            this.barBtn_saveCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_saveCSV_ItemClick);
            // 
            // barBtn_saveXLS
            // 
            this.barBtn_saveXLS.Caption = "SaveXLS";
            this.barBtn_saveXLS.Id = 1;
            this.barBtn_saveXLS.Name = "barBtn_saveXLS";
            this.barBtn_saveXLS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_saveXLS_ItemClick);
            // 
            // barBtn_copy
            // 
            this.barBtn_copy.Caption = "Copy";
            this.barBtn_copy.Id = 2;
            this.barBtn_copy.Name = "barBtn_copy";
            this.barBtn_copy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_copy_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtn_saveCSV,
            this.barBtn_saveXLS,
            this.barBtn_copy});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(737, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 379);
            this.barDockControlBottom.Size = new System.Drawing.Size(737, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 379);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(737, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 379);
            // 
            // TabularControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TabularControl";
            this.Size = new System.Drawing.Size(737, 379);
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gvTable;
        private DevExpress.XtraGrid.GridControl gcTable;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barBtn_saveCSV;
        private DevExpress.XtraBars.BarButtonItem barBtn_saveXLS;
        private DevExpress.XtraBars.BarButtonItem barBtn_copy;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
