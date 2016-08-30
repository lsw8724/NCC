namespace NADACommonCalibrator.ConfigControl
{
    partial class Daq5509ConfigControl
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
            this.gcDaq5509 = new DevExpress.XtraGrid.GridControl();
            this.gvDaq5509 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCh_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFMax_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLine_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSensitivity_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcICP_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHWGain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbHWGain = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.pgcDaq5509 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcDaq5509)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDaq5509)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHWGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcDaq5509)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDaq5509
            // 
            this.gcDaq5509.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcDaq5509.Location = new System.Drawing.Point(0, 0);
            this.gcDaq5509.MainView = this.gvDaq5509;
            this.gcDaq5509.Name = "gcDaq5509";
            this.gcDaq5509.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbHWGain});
            this.gcDaq5509.Size = new System.Drawing.Size(452, 402);
            this.gcDaq5509.TabIndex = 0;
            this.gcDaq5509.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDaq5509});
            // 
            // gvDaq5509
            // 
            this.gvDaq5509.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCh_5509,
            this.gcFMax_5509,
            this.gcLine_5509,
            this.gcSensitivity_5509,
            this.gcICP_5509,
            this.gcHWGain});
            this.gvDaq5509.GridControl = this.gcDaq5509;
            this.gvDaq5509.Name = "gvDaq5509";
            this.gvDaq5509.OptionsSelection.MultiSelect = true;
            this.gvDaq5509.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvDaq5509_SelectionChanged);
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
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(452, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(7, 402);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // pgcDaq5509
            // 
            this.pgcDaq5509.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcDaq5509.Location = new System.Drawing.Point(459, 0);
            this.pgcDaq5509.Name = "pgcDaq5509";
            this.pgcDaq5509.Size = new System.Drawing.Size(265, 402);
            this.pgcDaq5509.TabIndex = 2;
            // 
            // Daq5509ConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pgcDaq5509);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcDaq5509);
            this.Name = "Daq5509ConfigControl";
            this.Size = new System.Drawing.Size(724, 402);
            ((System.ComponentModel.ISupportInitialize)(this.gcDaq5509)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDaq5509)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHWGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcDaq5509)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gcDaq5509;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDaq5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcCh_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcFMax_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcLine_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcSensitivity_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcICP_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcHWGain;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbHWGain;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraVerticalGrid.PropertyGridControl pgcDaq5509;
    }
}
