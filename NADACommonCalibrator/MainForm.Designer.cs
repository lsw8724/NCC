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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.AutomationGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.organizerGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navItem_connect = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navItem_Timebase = new DevExpress.XtraNavBar.NavBarItem();
            this.navItem_spectrum = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.largeImageCollection = new DevExpress.Utils.ImageCollection();
            this.smallImageCollection = new DevExpress.Utils.ImageCollection();
            this.snapDockManager = new DevExpress.Snap.Extensions.SnapDockManager();
            this.dockPanel_5509Config = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ConfigControl_5509 = new NADACommonCalibrator.ConfigControl.Daq5509ConfigControl();
            this.dockPanel_ModuleList = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lb_ModuleList = new DevExpress.XtraEditors.ListBoxControl();
            this.dockPanel_MenuList = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.snapDocumentManager = new DevExpress.Snap.Extensions.SnapDocumentManager();
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.trashItem = new DevExpress.XtraNavBar.NavBarItem();
            this.draftsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.outboxItem = new DevExpress.XtraNavBar.NavBarItem();
            this.inboxItem = new DevExpress.XtraNavBar.NavBarItem();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu();
            this.barBtn_5509 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_omap = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_wifi = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_bt = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_remove = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.mainBar = new DevExpress.XtraBars.Bar();
            this.barItem_file = new DevExpress.XtraBars.BarSubItem();
            this.barItem_view = new DevExpress.XtraBars.BarSubItem();
            this.barItem_theme = new DevExpress.XtraBars.BarSubItem();
            this.barItem_help = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager)).BeginInit();
            this.dockPanel_5509Config.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            this.dockPanel_ModuleList.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ModuleList)).BeginInit();
            this.dockPanel_MenuList.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapDocumentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.AutomationGroup;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Font = new System.Drawing.Font("Tahoma", 11F);
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.AutomationGroup,
            this.organizerGroup,
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navItem_Timebase,
            this.navItem_spectrum,
            this.navItem_connect});
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
            // organizerGroup
            // 
            this.organizerGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.organizerGroup.Appearance.Options.UseFont = true;
            this.organizerGroup.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.organizerGroup.AppearanceHotTracked.Options.UseFont = true;
            this.organizerGroup.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.organizerGroup.AppearancePressed.Options.UseFont = true;
            this.organizerGroup.Caption = "측정 모듈";
            this.organizerGroup.Expanded = true;
            this.organizerGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItem_connect)});
            this.organizerGroup.LargeImageIndex = 1;
            this.organizerGroup.Name = "organizerGroup";
            this.organizerGroup.SmallImageIndex = 9;
            // 
            // navItem_connect
            // 
            this.navItem_connect.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_connect.Appearance.Options.UseFont = true;
            this.navItem_connect.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_connect.AppearanceHotTracked.Options.UseFont = true;
            this.navItem_connect.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navItem_connect.AppearancePressed.Options.UseFont = true;
            this.navItem_connect.Caption = "연결";
            this.navItem_connect.Name = "navItem_connect";
            this.navItem_connect.SmallImageIndex = 1;
            this.navItem_connect.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItem_connect_LinkClicked);
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
            // navBarGroup2
            // 
            this.navBarGroup2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarGroup2.Appearance.Options.UseFont = true;
            this.navBarGroup2.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarGroup2.AppearanceHotTracked.Options.UseFont = true;
            this.navBarGroup2.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarGroup2.AppearancePressed.Options.UseFont = true;
            this.navBarGroup2.Caption = "기능";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.LargeImageIndex = 0;
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImageIndex = 7;
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
            this.dockPanel_5509Config});
            this.snapDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel_ModuleList,
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
            // dockPanel_5509Config
            // 
            this.dockPanel_5509Config.Controls.Add(this.controlContainer1);
            this.dockPanel_5509Config.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanel_5509Config.FloatLocation = new System.Drawing.Point(260, 183);
            this.dockPanel_5509Config.FloatSize = new System.Drawing.Size(640, 404);
            this.dockPanel_5509Config.ID = new System.Guid("8d03dedf-db7b-4816-88b2-ad81ebc2dca6");
            this.dockPanel_5509Config.Location = new System.Drawing.Point(-32768, -32768);
            this.dockPanel_5509Config.Name = "dockPanel_5509Config";
            this.dockPanel_5509Config.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel_5509Config.SavedIndex = 2;
            this.dockPanel_5509Config.Size = new System.Drawing.Size(640, 404);
            this.dockPanel_5509Config.Text = "Daq5509 Configuration";
            this.dockPanel_5509Config.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.ConfigControl_5509);
            this.controlContainer1.Location = new System.Drawing.Point(4, 29);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(632, 371);
            this.controlContainer1.TabIndex = 0;
            // 
            // ConfigControl_5509
            // 
            this.ConfigControl_5509.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigControl_5509.Location = new System.Drawing.Point(0, 0);
            this.ConfigControl_5509.Name = "ConfigControl_5509";
            this.ConfigControl_5509.Size = new System.Drawing.Size(632, 371);
            this.ConfigControl_5509.TabIndex = 0;
            // 
            // dockPanel_ModuleList
            // 
            this.dockPanel_ModuleList.Controls.Add(this.dockPanel2_Container);
            this.dockPanel_ModuleList.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel_ModuleList.ID = new System.Guid("0bb1084f-bf72-4055-ba6e-e95e5ccdfa88");
            this.dockPanel_ModuleList.Location = new System.Drawing.Point(803, 24);
            this.dockPanel_ModuleList.Name = "dockPanel_ModuleList";
            this.dockPanel_ModuleList.OriginalSize = new System.Drawing.Size(191, 302);
            this.dockPanel_ModuleList.Size = new System.Drawing.Size(191, 522);
            this.dockPanel_ModuleList.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Right;
            this.dockPanel_ModuleList.Text = "Module List";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.lb_ModuleList);
            this.dockPanel2_Container.Location = new System.Drawing.Point(6, 27);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(179, 489);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // lb_ModuleList
            // 
            this.lb_ModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ModuleList.Location = new System.Drawing.Point(0, 0);
            this.lb_ModuleList.Name = "lb_ModuleList";
            this.lb_ModuleList.Size = new System.Drawing.Size(179, 489);
            this.lb_ModuleList.TabIndex = 0;
            this.lb_ModuleList.SelectedIndexChanged += new System.EventHandler(this.lb_ModuleList_SelectedIndexChanged);
            this.lb_ModuleList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseClick);
            this.lb_ModuleList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_ModuleList_MouseDoubleClick);
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
            this.snapDocumentManager.View = this.tabbedView1;
            this.snapDocumentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Sharp Plus";
            // 
            // trashItem
            // 
            this.trashItem.Caption = "보정값 계산";
            this.trashItem.Name = "trashItem";
            this.trashItem.SmallImageIndex = 3;
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
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_5509),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_omap),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_wifi),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_bt),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_remove, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1, true)});
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // barBtn_5509
            // 
            this.barBtn_5509.Caption = "Add 5509";
            this.barBtn_5509.Id = 4;
            this.barBtn_5509.Name = "barBtn_5509";
            this.barBtn_5509.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_add_ItemClick);
            // 
            // barBtn_omap
            // 
            this.barBtn_omap.Caption = "Add Omap";
            this.barBtn_omap.Id = 6;
            this.barBtn_omap.Name = "barBtn_omap";
            // 
            // barBtn_wifi
            // 
            this.barBtn_wifi.Caption = "Add Wifi";
            this.barBtn_wifi.Id = 8;
            this.barBtn_wifi.Name = "barBtn_wifi";
            // 
            // barBtn_bt
            // 
            this.barBtn_bt.Caption = "Add Bluetooth";
            this.barBtn_bt.Id = 7;
            this.barBtn_bt.Name = "barBtn_bt";
            // 
            // barBtn_remove
            // 
            this.barBtn_remove.Caption = "Remove";
            this.barBtn_remove.Id = 5;
            this.barBtn_remove.Name = "barBtn_remove";
            this.barBtn_remove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_remove_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Rename";
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
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
            this.barManager.MaxItemId = 10;
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
            // document1
            // 
            this.document1.Caption = "Daq5509 Configuration";
            this.document1.FloatLocation = new System.Drawing.Point(227, 203);
            this.document1.FloatSize = new System.Drawing.Size(640, 404);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.True;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 546);
            this.Controls.Add(this.dockPanel_MenuList);
            this.Controls.Add(this.dockPanel_ModuleList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "NCC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager)).EndInit();
            this.dockPanel_5509Config.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.dockPanel_ModuleList.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lb_ModuleList)).EndInit();
            this.dockPanel_MenuList.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.snapDocumentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup AutomationGroup;
        private DevExpress.XtraNavBar.NavBarGroup organizerGroup;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navItem_Timebase;
        private DevExpress.XtraNavBar.NavBarItem navItem_spectrum;
        private DevExpress.XtraNavBar.NavBarItem navItem_connect;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.Snap.Extensions.SnapDockManager snapDockManager;
        private DevExpress.Snap.Extensions.SnapDocumentManager snapDocumentManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_MenuList;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_ModuleList;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.Utils.ImageCollection smallImageCollection;
        private DevExpress.XtraNavBar.NavBarItem trashItem;
        private DevExpress.XtraNavBar.NavBarItem draftsItem;
        private DevExpress.XtraNavBar.NavBarItem outboxItem;
        private DevExpress.XtraNavBar.NavBarItem inboxItem;
        private DevExpress.Utils.ImageCollection largeImageCollection;
        private DevExpress.XtraBars.PopupMenu popupMenu;
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
        private DevExpress.XtraEditors.ListBoxControl lb_ModuleList;
        private DevExpress.XtraBars.BarButtonItem barBtn_omap;
        private DevExpress.XtraBars.BarButtonItem barBtn_wifi;
        private DevExpress.XtraBars.BarButtonItem barBtn_bt;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_5509Config;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private ConfigControl.Daq5509ConfigControl ConfigControl_5509;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
