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
    public partial class Form1 : Form
    {
        double sum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username_ = "test";
            string password_ = "Test123";

            string username = textBox_username.Text;
            string password = textBox_password.Text;

            if (username.Equals(username_) && password.Equals(password_))
            {
                MyStockSimulatorForm myForm = new MyStockSimulatorForm();

                myForm.Show();
            }
            else
            {
                MessageBox.Show("Password or username is invalid");
            }
        }
    }
}
