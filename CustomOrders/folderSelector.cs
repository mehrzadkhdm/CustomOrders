using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomOrders
{
    public partial class folderSelector : Form
    {
        public CustomOrders parentForm = null;
        public folderSelector(CustomOrders customOrders, string initialFolder)
        {
            InitializeComponent();
            parentForm = (CustomOrders)this.Owner;
            parentForm = customOrders;
            comboBox1.Text = initialFolder;

        }

        private void folderSelector_Load(object sender, EventArgs e)
        {
            //comboBox1.Text = Application.StartupPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.searchFolder = comboBox1.Text;
            Close();
        }
    }
}
