using System;
using System.Windows.Forms;

namespace RepAlignCheckBoxTableCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            XtraReport1 report = new XtraReport1();

            report.DataSource = ManualDataSet.CreateData();
            //report.ShowDesignerDialog();
            report.ShowPreviewDialog();
        }
    }
}