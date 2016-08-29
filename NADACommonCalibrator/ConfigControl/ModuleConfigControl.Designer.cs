namespace NADACommonCalibrator.ConfigControl
{
    partial class ModuleConfigControl
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
            this.tabPage_ModuleConfig = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitCt_5509 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcDaq5509 = new DevExpress.XtraGrid.GridControl();
            this.gvDaq5509 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCh_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFMax_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLine_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSensitivity_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcICP_5509 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHWGain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbHWGain = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pgcDaq5509 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.cbSamplingRate = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cbInputType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChannel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAsyncFMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAsyncLine = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabPage_ModuleConfig)).BeginInit();
            this.tabPage_ModuleConfig.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCt_5509)).BeginInit();
            this.splitCt_5509.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDaq5509)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDaq5509)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHWGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcDaq5509)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSamplingRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbInputType)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage_ModuleConfig
            // 
            this.tabPage_ModuleConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_ModuleConfig.Location = new System.Drawing.Point(0, 0);
            this.tabPage_ModuleConfig.Name = "tabPage_ModuleConfig";
            this.tabPage_ModuleConfig.SelectedTabPage = this.xtraTabPage1;
            this.tabPage_ModuleConfig.Size = new System.Drawing.Size(724, 402);
            this.tabPage_ModuleConfig.TabIndex = 0;
            this.tabPage_ModuleConfig.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitCt_5509);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(720, 376);
            this.xtraTabPage1.Text = "5509";
            // 
            // splitCt_5509
            // 
            this.splitCt_5509.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCt_5509.Location = new System.Drawing.Point(0, 0);
            this.splitCt_5509.Name = "splitCt_5509";
            this.splitCt_5509.Panel1.Controls.Add(this.gcDaq5509);
            this.splitCt_5509.Panel1.Text = "Panel1";
            this.splitCt_5509.Panel2.Controls.Add(this.pgcDaq5509);
            this.splitCt_5509.Panel2.Text = "Panel2";
            this.splitCt_5509.Size = new System.Drawing.Size(720, 376);
            this.splitCt_5509.SplitterPosition = 575;
            this.splitCt_5509.TabIndex = 1;
            this.splitCt_5509.Text = "splitContainerControl2";
            // 
            // gcDaq5509
            // 
            this.gcDaq5509.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDaq5509.Location = new System.Drawing.Point(0, 0);
            this.gcDaq5509.MainView = this.gvDaq5509;
            this.gcDaq5509.Name = "gcDaq5509";
            this.gcDaq5509.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbHWGain});
            this.gcDaq5509.Size = new System.Drawing.Size(575, 376);
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
            // pgcDaq5509
            // 
            this.pgcDaq5509.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcDaq5509.Location = new System.Drawing.Point(0, 0);
            this.pgcDaq5509.Name = "pgcDaq5509";
            this.pgcDaq5509.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbSamplingRate,
            this.cbInputType});
            this.pgcDaq5509.Size = new System.Drawing.Size(138, 376);
            this.pgcDaq5509.TabIndex = 0;
            this.pgcDaq5509.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.pgcDaq5509_CellValueChanged);
            // 
            // cbSamplingRate
            // 
            this.cbSamplingRate.AutoHeight = false;
            this.cbSamplingRate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSamplingRate.Name = "cbSamplingRate";
            // 
            // cbInputType
            // 
            this.cbInputType.AutoHeight = false;
            this.cbInputType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbInputType.Name = "cbInputType";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(720, 376);
            this.xtraTabPage2.Text = "Omap";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(720, 376);
            this.xtraTabPage3.Text = "BT";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(720, 376);
            this.xtraTabPage4.Text = "Wi-Fi";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(720, 376);
            this.splitContainerControl1.SplitterPosition = 368;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(368, 376);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIp,
            this.gcChannel,
            this.gcAsyncFMax,
            this.gcAsyncLine});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gcIp
            // 
            this.gcIp.Caption = "gridColumn1";
            this.gcIp.Name = "gcIp";
            this.gcIp.Visible = true;
            this.gcIp.VisibleIndex = 0;
            // 
            // gcChannel
            // 
            this.gcChannel.Caption = "gridColumn2";
            this.gcChannel.Name = "gcChannel";
            this.gcChannel.Visible = true;
            this.gcChannel.VisibleIndex = 1;
            // 
            // gcAsyncFMax
            // 
            this.gcAsyncFMax.Caption = "gridColumn3";
            this.gcAsyncFMax.Name = "gcAsyncFMax";
            this.gcAsyncFMax.Visible = true;
            this.gcAsyncFMax.VisibleIndex = 2;
            // 
            // gcAsyncLine
            // 
            this.gcAsyncLine.Caption = "gridColumn4";
            this.gcAsyncLine.Name = "gcAsyncLine";
            this.gcAsyncLine.Visible = true;
            this.gcAsyncLine.VisibleIndex = 3;
            // 
            // ModuleConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPage_ModuleConfig);
            this.Name = "ModuleConfigControl";
            this.Size = new System.Drawing.Size(724, 402);
            ((System.ComponentModel.ISupportInitialize)(this.tabPage_ModuleConfig)).EndInit();
            this.tabPage_ModuleConfig.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCt_5509)).EndInit();
            this.splitCt_5509.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDaq5509)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDaq5509)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHWGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcDaq5509)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSamplingRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbInputType)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabPage_ModuleConfig;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcIp;
        private DevExpress.XtraGrid.Columns.GridColumn gcChannel;
        private DevExpress.XtraGrid.Columns.GridColumn gcAsyncFMax;
        private DevExpress.XtraGrid.Columns.GridColumn gcAsyncLine;
        private DevExpress.XtraVerticalGrid.PropertyGridControl pgcDaq5509;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        public DevExpress.XtraEditors.SplitContainerControl splitCt_5509;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbSamplingRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbInputType;
        public DevExpress.XtraGrid.GridControl gcDaq5509;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDaq5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcCh_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcFMax_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcLine_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcSensitivity_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcICP_5509;
        private DevExpress.XtraGrid.Columns.GridColumn gcHWGain;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbHWGain;
    }
}
