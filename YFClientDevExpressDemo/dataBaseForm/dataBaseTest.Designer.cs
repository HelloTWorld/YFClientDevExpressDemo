namespace YFClientDevExpressDemo.dataBaseTest
{
    partial class dataBaseTest
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
            this.treeListTest = new DevExpress.XtraTreeList.TreeList();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeListTest)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListTest
            // 
            this.treeListTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListTest.Location = new System.Drawing.Point(12, 54);
            this.treeListTest.Name = "treeListTest";
            this.treeListTest.Size = new System.Drawing.Size(931, 530);
            this.treeListTest.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(860, 20);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(83, 28);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "加载";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // dataBaseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 596);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.treeListTest);
            this.Name = "dataBaseTest";
            this.Text = "dataBaseTest";
            ((System.ComponentModel.ISupportInitialize)(this.treeListTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListTest;
        private System.Windows.Forms.Button buttonLoad;
    }
}