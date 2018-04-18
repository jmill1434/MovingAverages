using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MyStockSimulatorForm : Form
    {
        NewSimulationForm simForm;
        ViewReportForm repForm;
        public MyStockSimulatorForm()
        {
            InitializeComponent();
        }

        private void newSimulationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(simForm == null)
            {
                simForm = new NewSimulationForm();
                simForm.MdiParent = this;
                simForm.Show();
            }
            else
            {
                simForm.Activate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (repForm == null)
            {
                repForm = new ViewReportForm();
                repForm.MdiParent = this;
                repForm.Show();
            }
            else
            {
                repForm.Activate();
            }
        }
    }
}
