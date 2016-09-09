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
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.AutomationGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navItem_Timebase = new DevExpress.XtraNavBar.NavBarItem();
            this.navItem_spectrum = new DevExpress.XtraNavBar.NavBarItem();
            this.largeImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.smallImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.snapDockManager = new DevExpress.Snap.Extensions.SnapDockManager(this.components);
            this.dockPanel_scriptTxt = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.recScript = new DevExpress.XtraRichEdit.RichEditControl();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainBar = new DevExpress.XtraBars.Bar();
            this.barItem_file = new DevExpress.XtraBars.BarSubItem();
            this.barItem_view = new DevExpress.XtraBars.BarSubItem();
            this.barItem_theme = new DevExpress.XtraBars.BarSubItem();
            this.barItem_help = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barBtn_5509 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_remove = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_omap = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_bt = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_wifi = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.dockPanel_scriptGrid = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pgcScriptConfig = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.dockPanel_MenuList = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.snapDocumentManager = new DevExpress.Snap.Extensions.SnapDocumentManager(this.components);
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.draftsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.outboxItem = new DevExpress.XtraNavBar.NavBarItem();
            this.inboxItem = new DevExpress.XtraNavBar.NavBarItem();
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document3 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document4 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document5 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager)).BeginInit();
            this.dockPanel_scriptTxt.SuspendLayout();
            this.controlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.dockPanel_scriptGrid.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgcScriptConfig)).BeginInit();
            this.dockPanel_MenuList.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapDocumentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.AutomationGroup;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Font = new System.Drawing.Font("Tahoma", 11F);
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.AutomationGroup,
            this.navBarGroup1});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navItem_Timebase,
            this.navItem_spectrum});
            this.navBarControl.LargeImages = this.largeImageCollection;
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 188;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.navBarControl.Size = new System.Drawing.Size(188, 489);
            this.navBarControl.SmallImages = this.smallImageCollection;
            this.navBarControl.StoreDefaultPaintStyleName = true;
            this.navBarControl.TabIndex = 2;
            this.navBarControl.Text = "navBarControl1";
            // 
            // AutomationGroup
            // 
            this.AutomationGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.AutomationGroup.Appearance.Options.UseFont = true;
            this.AutomationGroup.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.AutomationGroup.AppearanceHotTracked.Options.UseFont = true;
            this.AutomationGroup.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.AutomationGroup.AppearancePressed.Options.UseFont = true;
            this.AutomationGroup.Caption = "자동화";
            this.AutomationGroup.Expanded = true;
            this.AutomationGroup.LargeImageIndex = 3;
            this.AutomationGroup.Name = "AutomationGroup";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarGroup1.Appearance.Options.UseFont = true;
            this.navBarGroup1.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarGroup1.AppearanceHotTracked.Options.UseFont = true;
            this.navBarGroup1.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarGroup1.AppearancePressed.Options.UseFont = true;
            this.navBarGroup1.Caption = "분석";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItem_Timebase),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItem_spectrum)});
            this.navBarGroup1.LargeImageIndex = 2;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImageIndex = 8;
            // 
            // navItem_Timebase
            // 
            this.navItem_Timebase.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_Timebase.Appearance.Options.UseFont = true;
            this.navItem_Timebase.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_Timebase.AppearanceHotTracked.Options.UseFont = true;
            this.navItem_Timebase.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_Timebase.AppearancePressed.Options.UseFont = true;
            this.navItem_Timebase.Caption = "타임";
            this.navItem_Timebase.Name = "navItem_Timebase";
            this.navItem_Timebase.SmallImageIndex = 5;
            this.navItem_Timebase.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItem_timeBase_LinkClicked);
            // 
            // navItem_spectrum
            // 
            this.navItem_spectrum.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_spectrum.Appearance.Options.UseFont = true;
            this.navItem_spectrum.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_spectrum.AppearanceHotTracked.Options.UseFont = true;
            this.navItem_spectrum.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_spectrum.AppearancePressed.Options.UseFont = true;
            this.navItem_spectrum.Caption = "스펙트럼";
            this.navItem_spectrum.Name = "navItem_spectrum";
            this.navItem_spectrum.SmallImageIndex = 4;
            this.navItem_spectrum.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItem_spectrum_LinkClicked);
            // 
            // largeImageCollection
            // 
            this.largeImageCollection.ImageSize = new System.Drawing.Size(24, 24);
            this.largeImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("largeImageCollection.ImageStream")));
            this.largeImageCollection.Images.SetKeyName(0, "Feature.png");
            this.largeImageCollection.Images.SetKeyName(1, "Motherboard-icon.png");
            this.largeImageCollection.Images.SetKeyName(2, "Plot.png");
            this.largeImageCollection.Images.SetKeyName(3, "daily.png");
            // 
            // smallImageCollection
            // 
            this.smallImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("smallImageCollection.ImageStream")));
            // 
            // snapDockManager
            // 
            this.snapDockManager.Form = this;
            this.snapDockManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel_scriptTxt,
            this.dockPanel_scriptGrid});
            this.snapDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel_MenuList});
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
            // dockPanel_scriptTxt
            // 
            this.dockPanel_scriptTxt.Controls.Add(this.controlContainer2);
            this.dockPanel_scriptTxt.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel_scriptTxt.ID = new System.Guid("f1adc87f-9cf1-4f44-aed3-61821f8795c0");
            this.dockPanel_scriptTxt.Location = new System.Drawing.Point(524, 24);
            this.dockPanel_scriptTxt.Name = "dockPanel_scriptTxt";
            this.dockPanel_scriptTxt.OriginalSize = new System.Drawing.Size(353, 200);
            this.dockPanel_scriptTxt.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel_scriptTxt.SavedIndex = 2;
            this.dockPanel_scriptTxt.Size = new System.Drawing.Size(353, 522);
            this.dockPanel_scriptTxt.Text = "Script Txt";
            this.dockPanel_scriptTxt.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer2
            // 
            this.controlContainer2.Controls.Add(this.recScript);
            this.controlContainer2.Location = new System.Drawing.Point(6, 27);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(341, 489);
            this.controlContainer2.TabIndex = 0;
            // 
            // recScript
            // 
            this.recScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recScript.Location = new System.Drawing.Point(0, 0);
            this.recScript.MenuManager = this.barManager;
            this.recScript.Name = "recScript";
            this.recScript.Options.Fields.UseCurrentCultureDateTimeFormat = false;
            this.recScript.Options.MailMerge.KeepLastParagraph = false;
            this.recScript.Size = new System.Drawing.Size(341, 489);
            this.recScript.TabIndex = 0;
            this.recScript.Text = "richEditControl1";
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainBar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItem_file,
            this.barItem_view,
            this.barItem_theme,
            this.barItem_help,
            this.barBtn_5509,
            this.barBtn_remove,
            this.barBtn_omap,
            this.barBtn_bt,
            this.barBtn_wifi,
            this.barButtonItem1});
            this.barManager.MainMenu = this.mainBar;
            this.barManager.MaxItemId = 16;
            // 
            // mainBar
            // 
            this.mainBar.BarName = "Main menu";
            this.mainBar.DockCol = 0;
            this.mainBar.DockRow = 0;
            this.mainBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItem_file),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItem_view),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItem_theme),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItem_help)});
            this.mainBar.OptionsBar.MultiLine = true;
            this.mainBar.OptionsBar.UseWholeRow = true;
            this.mainBar.Text = "Main menu";
            // 
            // barItem_file
            // 
            this.barItem_file.Caption = "File";
            this.barItem_file.Id = 0;
            this.barItem_file.Name = "barItem_file";
            // 
            // barItem_view
            // 
            this.barItem_view.Caption = "View";
            this.barItem_view.Id = 1;
            this.barItem_view.Name = "barItem_view";
            // 
            // barItem_theme
            // 
            this.barItem_theme.Caption = "Theme";
            this.barItem_theme.Id = 2;
            this.barItem_theme.Name = "barItem_theme";
            // 
            // barItem_help
            // 
            this.barItem_help.Caption = "Help";
            this.barItem_help.Id = 3;
            this.barItem_help.Name = "barItem_help";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(994, 24);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 522);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(994, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 522);
            // 
            // barBtn_5509
            // 
            this.barBtn_5509.Id = 10;
            this.barBtn_5509.Name = "barBtn_5509";
            // 
            // barBtn_remove
            // 
            this.barBtn_remove.Id = 11;
            this.barBtn_remove.Name = "barBtn_remove";
            // 
            // barBtn_omap
            // 
            this.barBtn_omap.Id = 12;
            this.barBtn_omap.Name = "barBtn_omap";
            // 
            // barBtn_bt
            // 
            this.barBtn_bt.Id = 13;
            this.barBtn_bt.Name = "barBtn_bt";
            // 
            // barBtn_wifi
            // 
            this.barBtn_wifi.Id = 14;
            this.barBtn_wifi.Name = "barBtn_wifi";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // dockPanel_scriptGrid
            // 
            this.dockPanel_scriptGrid.Controls.Add(this.controlContainer1);
            this.dockPanel_scriptGrid.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel_scriptGrid.FloatSize = new System.Drawing.Size(640, 404);
            this.dockPanel_scriptGrid.FloatVertical = true;
            this.dockPanel_scriptGrid.ID = new System.Guid("8d03dedf-db7b-4816-88b2-ad81ebc2dca6");
            this.dockPanel_scriptGrid.Location = new System.Drawing.Point(200, 24);
            this.dockPanel_scriptGrid.Name = "dockPanel_scriptGrid";
            this.dockPanel_scriptGrid.OriginalSize = new System.Drawing.Size(324, 200);
            this.dockPanel_scriptGrid.Size = new System.Drawing.Size(324, 522);
            this.dockPanel_scriptGrid.Text = "Script Grid";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.pgcScriptConfig);
            this.controlContainer1.Location = new System.Drawing.Point(6, 27);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(312, 489);
            this.controlContainer1.TabIndex = 0;
            // 
            // pgcScriptConfig
            // 
            this.pgcScriptConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcScriptConfig.Location = new System.Drawing.Point(0, 0);
            this.pgcScriptConfig.Name = "pgcScriptConfig";
            this.pgcScriptConfig.Size = new System.Drawing.Size(312, 489);
            this.pgcScriptConfig.TabIndex = 0;
            // 
            // dockPanel_MenuList
            // 
            this.dockPanel_MenuList.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dockPanel_MenuList.Appearance.Options.UseBackColor = true;
            this.dockPanel_MenuList.Controls.Add(this.dockPanel1_Container);
            this.dockPanel_MenuList.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel_MenuList.ID = new System.Guid("10e1913e-1f43-42cd-98bd-ef28ceafcfbd");
            this.dockPanel_MenuList.Location = new System.Drawing.Point(0, 24);
            this.dockPanel_MenuList.Name = "dockPanel_MenuList";
            this.dockPanel_MenuList.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel_MenuList.Size = new System.Drawing.Size(200, 522);
            this.dockPanel_MenuList.Text = "Menu Box";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navBarControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(6, 27);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(188, 489);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // snapDocumentManager
            // 
            this.snapDocumentManager.ContainerControl = this;
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Sharp Plus";
            // 
            // draftsItem
            // 
            this.draftsItem.Caption = "회전수 검사";
            this.draftsItem.Name = "draftsItem";
            this.draftsItem.SmallImageIndex = 2;
            // 
            // outboxItem
            // 
            this.outboxItem.Caption = "주파수 검사";
            this.outboxItem.Name = "outboxItem";
            this.outboxItem.SmallImageIndex = 1;
            // 
            // inboxItem
            // 
            this.inboxItem.Caption = "진폭검사";
            this.inboxItem.Name = "inboxItem";
            this.inboxItem.SmallImageIndex = 0;
            // 
            // document1
            // 
            this.document1.Caption = "Daq5509 Configuration";
            this.document1.FloatLocation = new System.Drawing.Point(227, 203);
            this.document1.FloatSize = new System.Drawing.Size(640, 404);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2
            // 
            this.document2.Caption = "Daq5509 Configuration";
            this.document2.FloatLocation = new System.Drawing.Point(312, 182);
            this.document2.FloatSize = new System.Drawing.Size(640, 404);
            this.document2.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document3
            // 
            this.document3.Caption = "Daq5509 Configuration";
            this.document3.FloatLocation = new System.Drawing.Point(231, 227);
            this.document3.FloatSize = new System.Drawing.Size(640, 404);
            this.document3.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document3.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document3.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document4
            // 
            this.document4.Caption = "panelContainer1";
            this.document4.FloatLocation = new System.Drawing.Point(249, 243);
            this.document4.FloatSize = new System.Drawing.Size(640, 404);
            this.document4.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document4.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document4.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document5
            // 
            this.document5.Caption = "panelContainer1";
            this.document5.FloatLocation = new System.Drawing.Point(207, 237);
            this.document5.FloatSize = new System.Drawing.Size(640, 404);
            this.document5.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document5.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document5.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.True;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 546);
            this.Controls.Add(this.dockPanel_scriptGrid);
            this.Controls.Add(this.dockPanel_MenuList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "NCC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager)).EndInit();
            this.dockPanel_scriptTxt.ResumeLayout(false);
            this.controlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.dockPanel_scriptGrid.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgcScriptConfig)).EndInit();
            this.dockPanel_MenuList.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.snapDocumentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup AutomationGroup;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navItem_Timebase;
        private DevExpress.XtraNavBar.NavBarItem navItem_spectrum;
        private DevExpress.Snap.Extensions.SnapDockManager snapDockManager;
        private DevExpress.Snap.Extensions.SnapDocumentManager snapDocumentManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_MenuList;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.Utils.ImageCollection smallImageCollection;
        private DevExpress.XtraNavBar.NavBarItem draftsItem;
        private DevExpress.XtraNavBar.NavBarItem outboxItem;
        private DevExpress.XtraNavBar.NavBarItem inboxItem;
        private DevExpress.Utils.ImageCollection largeImageCollection;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar mainBar;
        private DevExpress.XtraBars.BarSubItem barItem_file;
        private DevExpress.XtraBars.BarSubItem barItem_view;
        private DevExpress.XtraBars.BarSubItem barItem_theme;
        private DevExpress.XtraBars.BarSubItem barItem_help;
        private DevExpress.XtraBars.BarButtonItem barBtn_5509;
        private DevExpress.XtraBars.BarButtonItem barBtn_remove;
        private DevExpress.XtraBars.BarButtonItem barBtn_omap;
        private DevExpress.XtraBars.BarButtonItem barBtn_wifi;
        private DevExpress.XtraBars.BarButtonItem barBtn_bt;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_scriptGrid;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document2;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document3;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document4;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document5;
        private DevExpress.XtraVerticalGrid.PropertyGridControl pgcScriptConfig;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_scriptTxt;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
        private DevExpress.XtraRichEdit.RichEditControl recScript;
    }
}
