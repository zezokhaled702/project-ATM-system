using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.DashBoard;
namespace WindowsFormsApp1.HPControls
{
    public partial class DashBoard : UserControl
    {
        public static string Usernamee;
        public double AccountBalance;
        public DashBoard()
        {
            InitializeComponent();
            AccountBalance = GetBalance(Usernamee);
        }

        public DashBoard(string username)
        {
            InitializeComponent();
            Usernamee = username;
            AccountBalance= GetBalance(Usernamee);
            Console.WriteLine(AccountBalance);
        }

        public DashBoard(string username,double bl)
        {
            InitializeComponent();
            Usernamee = username;
            AccountBalance = GetBalance(Usernamee);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            label5.Text= GetOriginalName(Usernamee);
            label4.Text = AccountBalance.ToString();
            label6.Text= GetFirstName(Usernamee).ToString()+" "+GetLastName(Usernamee);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
