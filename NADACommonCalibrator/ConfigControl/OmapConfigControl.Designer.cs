namespace NADACommonCalibrator.ConfigControl
{
    partial class OmapConfigControl
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
            this.pgcOmap = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gcOmap = new DevExpress.XtraGrid.GridControl();
            this.gvOmap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCh_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFMax_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLine_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSensitivity_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcICP_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHWGain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbHWGain = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pgcOmap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOmap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOmap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHWGain)).BeginInit();
            this.SuspendLayout();
            // 
            // pgcOmap
            // 
            this.pgcOmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcOmap.Location = new System.Drawing.Point(489, 0);
            this.pgcOmap.Name = "pgcOmap";
            this.pgcOmap.Size = new System.Drawing.Size(171, 390);
            this.pgcOmap.TabIndex = 5;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(482, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(7, 390);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // gcOmap
            // 
            this.gcOmap.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcOmap.Location = new System.Drawing.Point(0, 0);
            this.gcOmap.MainView = this.gvOmap;
            this.gcOmap.Name = "gcOmap";
            this.gcOmap.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbHWGain});
            this.gcOmap.Size = new System.Drawing.Size(482, 390);
            this.gcOmap.TabIndex = 3;
            this.gcOmap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOmap});
            // 
            // gvOmap
            // 
            this.gvOmap.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCh_5509,
            this.gcFMax_5509,
            this.gcLine_5509,
            this.gcSensitivity_5509,
            this.gcICP_5509,
            this.gcHWGain,
            this.gcActive});
            this.gvOmap.GridControl = this.gcOmap;
            this.gvOmap.Name = "gvOmap";
            this.gvOmap.OptionsSelection.MultiSelect = true;
            // 
            // gcCh_5509
            // 
            this.gcCh_5509.Caption = "CH";
            this.gcCh_5509.FieldName = "Channel";
            this.gcCh_5509.Name = "gcCh_5509";
            this.gcCh_5509.Visible = true;
            this.gcCh_5509.VisibleIndex = 0;
            // 
            // gcFMax_5509
            // 
            this.gcFMax_5509.Caption = "AsyncFMax";
            this.gcFMax_5509.FieldName = "AsyncFMax";
            this.gcFMax_5509.Name = "gcFMax_5509";
            this.gcFMax_5509.Visible = true;
            this.gcFMax_5509.VisibleIndex = 1;
            // 
            // gcLine_5509
            // 
            this.gcLine_5509.Caption = "AsyncLine";
            this.gcLine_5509.FieldName = "AsyncLine";
            this.gcLine_5509.Name = "gcLine_5509";
            this.gcLine_5509.Visible = true;
            this.gcLine_5509.VisibleIndex = 2;
            // 
            // gcSensitivity_5509
            // 
            this.gcSensitivity_5509.Caption = "Sensitivity";
            this.gcSensitivity_5509.FieldName = "Sensitivity";
            this.gcSensitivity_5509.Name = "gcSensitivity_5509";
            this.gcSensitivity_5509.Visible = true;
            this.gcSensitivity_5509.VisibleIndex = 3;
            // 
            // gcICP_5509
            // 
            this.gcICP_5509.Caption = "ICP";
            this.gcICP_5509.FieldName = "ICP";
            this.gcICP_5509.Name = "gcICP_5509";
            this.gcICP_5509.Visible = true;
            this.gcICP_5509.VisibleIndex = 4;
            // 
            // gcHWGain
            // 
            this.gcHWGain.Caption = "HWGain";
            this.gcHWGain.ColumnEdit = this.cbHWGain;
            this.gcHWGain.FieldName = "HWGain";
            this.gcHWGain.Name = "gcHWGain";
            this.gcHWGain.Visible = true;
            this.gcHWGain.VisibleIndex = 5;
            // 
            // cbHWGain
            // 
            this.cbHWGain.AutoHeight = false;
            this.cbHWGain.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbHWGain.Name = "cbHWGain";
            // 
            // gcActive
            // 
            this.gcActive.Caption = "Active";
            this.gcActive.FieldName = "Active";
            this.gcActive.Name = "gcActive";
            this.gcActive.Visible = true;
            this.gcActive.VisibleIndex = 6;
            // 
            // OmapConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pgcOmap);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcOmap);
            this.Name = "OmapConfigControl";
            this.Size = new System.Drawing.Size(660, 390);
            ((System.ComponentModel.ISupportInitialize)(this.pgcOmap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOmap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOmap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHWGain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl pgcOmap;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        public DevExpress.XtraGrid.GridControl gcOmap;
        public DevExpress.XtraGrid.Views.Grid.GridView gvOmap;
        private DevExpress.XtraGrid.Columns.GridColumn gcCh_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcFMax_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcLine_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcSensitivity_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcICP_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcHWGain;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbHWGain;
        private DevExpress.XtraGrid.Columns.GridColumn gcActive;
    }
}
