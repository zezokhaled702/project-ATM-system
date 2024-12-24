using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.DashBoard;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static string homeUsernamee;
        public static double AccountBalanceStatic;
        public double homeAccountBalance;
        public Form2()
        {
            InitializeComponent();
            homeAccountBalance = GetBalance(homeUsernamee);
            this.Shown += Form2_Shown;
        }
        public Form2(string username)
        {
            InitializeComponent();
            homeUsernamee = username;
            homeAccountBalance = GetBalance(homeUsernamee);
            this.Shown += Form2_Shown;
        }
        public Form2(string username, double bl)
        {
            InitializeComponent();  
            homeUsernamee = username;
            homeAccountBalance = GetBalance(homeUsernamee);
            this.Shown += Form2_Shown;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HPControls.DashBoard dashboard = new HPControls.DashBoard(homeUsernamee);
            this.Shown += Form2_Shown;
            panel4.Controls.Clear();
            dashboard.Dock = DockStyle.Fill;
            panel4.Controls.Add(dashboard);
        }


        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            HPControls.DashBoard dashboard = new HPControls.DashBoard(homeUsernamee);
            panel4.Controls.Clear();
            dashboard.Dock = DockStyle.Fill;
            panel4.Controls.Add(dashboard);
            HPControls.DashBoard d = new HPControls.DashBoard();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            HPControls.Deposite deposite = new HPControls.Deposite(homeUsernamee);
            panel4.Controls.Clear();
            deposite.Dock = DockStyle.Fill;
            panel4.Controls.Add(deposite);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            HPControls.WithDraw withDraw = new HPControls.WithDraw(homeUsernamee);
            panel4.Controls.Clear();
            withDraw.Dock = DockStyle.Fill;
            panel4.Controls.Add(withDraw);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            HPControls.ChangePassword ChangePassword = new HPControls.ChangePassword(homeUsernamee);
            panel4.Controls.Clear();
            ChangePassword.Dock = DockStyle.Fill;
            panel4.Controls.Add(ChangePassword);
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            bunifuButton1.Focus();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1= new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
