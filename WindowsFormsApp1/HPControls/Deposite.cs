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
using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.UI.WinForms;

namespace WindowsFormsApp1.HPControls
{
    public partial class Deposite : UserControl
    {
        private Dictionary<BunifuLabel, Timer> labelTimers;
        public static string depositeUsername;
        public double AccountBalance;
        public Deposite()
        {
            InitializeComponent();

            // Initialize the dictionary
            labelTimers = new Dictionary<BunifuLabel, Timer>();
        }
        public Deposite(string username)
        {
            depositeUsername = username;
            AccountBalance = GetBalance(depositeUsername);
            InitializeComponent();

            // Initialize the dictionary
            labelTimers = new Dictionary<BunifuLabel, Timer>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double newbalance;


            if (bunifuTextBox1.Text=="")
            ShowLabelTemporarily(bunifuLabel2, 1500);

            else
            {
                double input = double.Parse(bunifuTextBox1.Text);
                newbalance = AccountBalance + input;
                Balance.UpdateBalance(depositeUsername, newbalance);
                bunifuLabel2.Visible=false;
                ShowLabelTemporarily(bunifuLabel1, 1500);
                AccountBalance = newbalance;
                Form2.AccountBalanceStatic = newbalance;
                Form2 form2 = new Form2(depositeUsername, newbalance);
            }
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Deposite_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        #region Show_Lable
        private void ShowLabelTemporarily(BunifuLabel label, int duration)
        {
            // Make the label visible
            label.Visible = true;

            // Check if the label already has a timer
            if (!labelTimers.ContainsKey(label))
            {
                // Create a new timer for this label
                Timer timer = new Timer();
                timer.Interval = duration; // Duration in milliseconds
                timer.Tick += (sender, e) => Timer_Tick(sender, e, label);

                // Add the timer to the dictionary
                labelTimers[label] = timer;
            }

            // Start the timer
            labelTimers[label].Start();
        }

        private void Timer_Tick(object sender, EventArgs e, BunifuLabel label)
        {
            // Hide the label
            label.Visible = false;

            // Stop and remove the timer from the dictionary
            if (labelTimers.ContainsKey(label))
            {
                labelTimers[label].Stop();
                labelTimers[label].Dispose();
                labelTimers.Remove(label);
            }
        }
        #endregion

        private void bunifuTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace and Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press if it's not a digit or control key
            }
        }
    }
}
