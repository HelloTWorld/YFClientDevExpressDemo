﻿namespace YFClientDevExpressDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMenu = new System.Windows.Forms.Button();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.buttonOLEDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMenu
            // 
            this.buttonMenu.AutoSize = true;
            this.buttonMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMenu.Location = new System.Drawing.Point(12, 12);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(39, 22);
            this.buttonMenu.TabIndex = 0;
            this.buttonMenu.Text = "菜单";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.treeList1.Location = new System.Drawing.Point(471, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(237, 512);
            this.treeList1.TabIndex = 1;
            // 
            // buttonOLEDB
            // 
            this.buttonOLEDB.AutoSize = true;
            this.buttonOLEDB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOLEDB.Location = new System.Drawing.Point(12, 57);
            this.buttonOLEDB.Name = "buttonOLEDB";
            this.buttonOLEDB.Size = new System.Drawing.Size(45, 22);
            this.buttonOLEDB.TabIndex = 2;
            this.buttonOLEDB.Text = "OLEDB";
            this.buttonOLEDB.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 512);
            this.Controls.Add(this.buttonOLEDB);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.buttonMenu);
            this.Name = "MainForm";
            this.Text = "主菜单";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMenu;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.Button buttonOLEDB;
    }
}

