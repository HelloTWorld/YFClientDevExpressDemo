namespace YFClientDevExpressDemo.MenuLoad
{
    partial class MenuMainForm
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.xtControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.buttonLoadMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtControl)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("90a83d6f-e528-4f7b-81ad-89bd8072b8df");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 583);
            this.dockPanel1.Text = "系统导航";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.xtControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 556);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // xtControl
            // 
            this.xtControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtControl.Location = new System.Drawing.Point(0, 0);
            this.xtControl.Name = "xtControl";
            this.xtControl.Size = new System.Drawing.Size(191, 556);
            this.xtControl.TabIndex = 0;
            this.xtControl.Text = "accordionControl1";
            // 
            // buttonLoadMenu
            // 
            this.buttonLoadMenu.AutoSize = true;
            this.buttonLoadMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLoadMenu.Location = new System.Drawing.Point(247, 38);
            this.buttonLoadMenu.Name = "buttonLoadMenu";
            this.buttonLoadMenu.Size = new System.Drawing.Size(63, 22);
            this.buttonLoadMenu.TabIndex = 1;
            this.buttonLoadMenu.Text = "加载菜单";
            this.buttonLoadMenu.UseVisualStyleBackColor = true;
            this.buttonLoadMenu.Click += new System.EventHandler(this.buttonLoadMenu_Click);
            // 
            // MenuMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 583);
            this.Controls.Add(this.buttonLoadMenu);
            this.Controls.Add(this.dockPanel1);
            this.Name = "MenuMainForm";
            this.Text = "MenuMainForm";
            this.Load += new System.EventHandler(this.MenuMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private System.Windows.Forms.Button buttonLoadMenu;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl xtControl;
    }
}