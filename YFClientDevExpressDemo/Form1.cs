using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YFClientDevExpressDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            MenuLoad.MenuMainForm menuMain = new MenuLoad.MenuMainForm();
            menuMain.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
