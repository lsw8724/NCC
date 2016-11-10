namespace NADACommonCalibrator
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            this.largeImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.smallImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtn_runScript = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_StopScript = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_editScript = new DevExpress.XtraBars.BarButtonItem();
            this.btn_allClose = new DevExpress.XtraBars.BarButtonItem();
            this.barItem_theme = new DevExpress.XtraBars.BarSubItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.snapDockManager = new DevExpress.Snap.Extensions.SnapDockManager(this.components);
            this.dockPanel_menuList = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navAutomationGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navPlotGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navItemTimePlot = new DevExpress.XtraNavBar.NavBarItem();
            this.navItemSpectrum = new DevExpress.XtraNavBar.NavBarItem();
            this.navItemTabular = new DevExpress.XtraNavBar.NavBarItem();
            this.navItemCorrection = new DevExpress.XtraNavBar.NavBarItem();
            this.dockPanel_scriptInfo = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pgcScriptConfig = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.snapDocumentManager1 = new DevExpress.Snap.Extensions.SnapDocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.largeImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager)).BeginInit();
            this.dockPanel_menuList.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            this.dockPanel_scriptInfo.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgcScriptConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDocumentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            this.SuspendLayout();
            // 
            // largeImageCollection
            // 
            this.largeImageCollection.ImageSize = new System.Drawing.Size(24, 24);
            this.largeImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("largeImageCollection.ImageStream")));
            this.largeImageCollection.Images.SetKeyName(0, "Feature.png");
            this.largeImageCollection.Images.SetKeyName(1, "Motherboard-icon.png");
            this.largeImageCollection.Images.SetKeyName(2, "Plot.png");
            this.largeImageCollection.Images.SetKeyName(3, "daily.png");
            this.largeImageCollection.Images.SetKeyName(4, "running.png");
            // 
            // smallImageCollection
            // 
            this.smallImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("smallImageCollection.ImageStream")));
            this.smallImageCollection.Images.SetKeyName(0, "running.png");
            this.smallImageCollection.Images.SetKeyName(1, "stop.png");
            this.smallImageCollection.Images.SetKeyName(3, "AllClose.ico");
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.Controller = this.barAndDockingController1;
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.snapDockManager;
            this.barManager.Form = this;
            this.barManager.Images = this.smallImageCollection;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtn_runScript,
            this.barBtn_StopScript,
            this.barItem_theme,
            this.barBtn_editScript,
            this.btn_allClose});
            this.barManager.LargeImages = this.largeImageCollection;
            this.barManager.MaxItemId = 31;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_runScript, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_StopScript),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_editScript, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_allClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItem_theme)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Custom 2";
            // 
            // barBtn_runScript
            // 
            this.barBtn_runScript.Caption = "barBtn_runScript";
            this.barBtn_runScript.Enabled = false;
            this.barBtn_runScript.Id = 23;
            this.barBtn_runScript.ImageIndex = 0;
            this.barBtn_runScript.Name = "barBtn_runScript";
            toolTipItem7.Text = "Run Script";
            superToolTip7.Items.Add(toolTipItem7);
            this.barBtn_runScript.SuperTip = superToolTip7;
            this.barBtn_runScript.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_runScript_ItemClick);
            // 
            // barBtn_StopScript
            // 
            this.barBtn_StopScript.Caption = "barBtn_stopScript";
            this.barBtn_StopScript.Enabled = false;
            this.barBtn_StopScript.Id = 24;
            this.barBtn_StopScript.ImageIndex = 1;
            this.barBtn_StopScript.Name = "barBtn_StopScript";
            this.barBtn_StopScript.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barBtn_editScript
            // 
            this.barBtn_editScript.Caption = "barBtn_editScript";
            this.barBtn_editScript.Id = 29;
            this.barBtn_editScript.ImageIndex = 2;
            this.barBtn_editScript.Name = "barBtn_editScript";
            this.barBtn_editScript.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_editScript_ItemClick);
            // 
            // btn_allClose
            // 
            this.btn_allClose.Caption = "btn_allClose";
            this.btn_allClose.Id = 30;
            this.btn_allClose.ImageIndex = 3;
            this.btn_allClose.Name = "btn_allClose";
            this.btn_allClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_allClose_ItemClick);
            // 
            // barItem_theme
            // 
            this.barItem_theme.Caption = "Theme";
            this.barItem_theme.Id = 27;
            this.barItem_theme.Name = "barItem_theme";
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(994, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 546);
            this.barDockControlBottom.Size = new System.Drawing.Size(994, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 520);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(994, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 520);
            // 
            // snapDockManager
            // 
            this.snapDockManager.Form = this;
            this.snapDockManager.MenuManager = this.barManager;
            this.snapDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel_menuList,
            this.dockPanel_scriptInfo});
            this.snapDockManager.SnapControl = null;
            this.snapDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel_menuList
            // 
            this.dockPanel_menuList.Controls.Add(this.dockPanel1_Container);
            this.dockPanel_menuList.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel_menuList.ID = new System.Guid("518281eb-5104-4b61-bd37-c4480c74f627");
            this.dockPanel_menuList.Location = new System.Drawing.Point(0, 26);
            this.dockPanel_menuList.Name = "dockPanel_menuList";
            this.dockPanel_menuList.OriginalSize = new System.Drawing.Size(188, 200);
            this.dockPanel_menuList.Size = new System.Drawing.Size(188, 520);
            this.dockPanel_menuList.Text = "Menu List";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navBarControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(182, 494);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.navAutomationGroup;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navAutomationGroup,
            this.navPlotGroup});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navItemTimePlot,
            this.navItemSpectrum,
            this.navItemTabular,
            this.navItemCorrection});
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 182;
            this.navBarControl.Size = new System.Drawing.Size(182, 494);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "navBarControl1";
            // 
            // navAutomationGroup
            // 
            this.navAutomationGroup.Caption = "Stripts";
            this.navAutomationGroup.Expanded = true;
            this.navAutomationGroup.Name = "navAutomationGroup";
            // 
            // navPlotGroup
            // 
            this.navPlotGroup.Caption = "Plot";
            this.navPlotGroup.Expanded = true;
            this.navPlotGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItemTimePlot),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItemSpectrum),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItemTabular),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItemCorrection)});
            this.navPlotGroup.Name = "navPlotGroup";
            // 
            // navItemTimePlot
            // 
            this.navItemTimePlot.Caption = "Timebase";
            this.navItemTimePlot.Name = "navItemTimePlot";
            this.navItemTimePlot.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItem_timeBase_LinkClicked);
            // 
            // navItemSpectrum
            // 
            this.navItemSpectrum.Caption = "Spectrum";
            this.navItemSpectrum.Name = "navItemSpectrum";
            this.navItemSpectrum.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItem_spectrum_LinkClicked);
            // 
            // navItemTabular
            // 
            this.navItemTabular.Caption = "RealTime Tabular";
            this.navItemTabular.Name = "navItemTabular";
            this.navItemTabular.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItemTable_LinkClicked);
            // 
            // navItemCorrection
            // 
            this.navItemCorrection.Caption = "Correction";
            this.navItemCorrection.Name = "navItemCorrection";
            this.navItemCorrection.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItemCorrection_LinkClicked);
            // 
            // dockPanel_scriptInfo
            // 
            this.dockPanel_scriptInfo.Controls.Add(this.dockPanel2_Container);
            this.dockPanel_scriptInfo.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel_scriptInfo.ID = new System.Guid("97520603-e275-4506-87ce-338c7e818ec2");
            this.dockPanel_scriptInfo.Location = new System.Drawing.Point(188, 26);
            this.dockPanel_scriptInfo.Name = "dockPanel_scriptInfo";
            this.dockPanel_scriptInfo.OriginalSize = new System.Drawing.Size(261, 200);
            this.dockPanel_scriptInfo.Size = new System.Drawing.Size(261, 520);
            this.dockPanel_scriptInfo.Text = "Script Info";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.pgcScriptConfig);
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(255, 494);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // pgcScriptConfig
            // 
            this.pgcScriptConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcScriptConfig.Location = new System.Drawing.Point(0, 0);
            this.pgcScriptConfig.Name = "pgcScriptConfig";
            this.pgcScriptConfig.Size = new System.Drawing.Size(255, 494);
            this.pgcScriptConfig.TabIndex = 0;
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Coffee";
            // 
            // snapDocumentManager1
            // 
            this.snapDocumentManager1.ContainerControl = this;
            this.snapDocumentManager1.MenuManager = this.barManager;
            this.snapDocumentManager1.View = this.tabbedView1;
            this.snapDocumentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // document1
            // 
            this.document1.Caption = "Script Info";
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.True;
            // 
            // MainForm
            // 
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 546);
            this.Controls.Add(this.dockPanel_scriptInfo);
            this.Controls.Add(this.dockPanel_menuList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NCC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.largeImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager)).EndInit();
            this.dockPanel_menuList.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.dockPanel_scriptInfo.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgcScriptConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDocumentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.Utils.ImageCollection smallImageCollection;
        private DevExpress.Utils.ImageCollection largeImageCollection;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Snap.Extensions.SnapDockManager snapDockManager;
        private DevExpress.Snap.Extensions.SnapDocumentManager snapDocumentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_scriptInfo;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_menuList;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup navAutomationGroup;
        private DevExpress.XtraVerticalGrid.PropertyGridControl pgcScriptConfig;
        private DevExpress.XtraNavBar.NavBarGroup navPlotGroup;
        private DevExpress.XtraNavBar.NavBarItem navItemTimePlot;
        private DevExpress.XtraNavBar.NavBarItem navItemSpectrum;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barBtn_runScript;
        private DevExpress.XtraNavBar.NavBarItem navItemTabular;
        private DevExpress.XtraBars.BarButtonItem barBtn_StopScript;
        private DevExpress.XtraNavBar.NavBarItem navItemCorrection;
        private DevExpress.XtraBars.BarSubItem barItem_theme;
        private DevExpress.XtraBars.BarButtonItem barBtn_editScript;
        private DevExpress.XtraBars.BarButtonItem btn_allClose;
    }
}
