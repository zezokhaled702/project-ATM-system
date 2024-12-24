using Bunifu.UI.WinForms;
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

namespace WindowsFormsApp1.HPControls
{

    public partial class WithDraw : UserControl
    {
        private Dictionary<BunifuLabel, Timer> labelTimers;
        public static string withdrawUsername;
        public double withdrawAccountBalance;
        public WithDraw()
        {
            InitializeComponent();
            labelTimers = new Dictionary<BunifuLabel, Timer>();
        }
        public WithDraw(string username)
        {
            withdrawUsername = username;
            withdrawAccountBalance = GetBalance(withdrawUsername);
            InitializeComponent();

            // Initialize the dictionary
            labelTimers = new Dictionary<BunifuLabel, Timer>();
        }

        private void WithDraw_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double newbalance;


            if (bunifuTextBox1.Text == "")
                ShowLabelTemporarily(bunifuLabel2, 1500);

            else if (double.Parse(bunifuTextBox1.Text) > withdrawAccountBalance)
            {
                ShowLabelTemporarily(bunifuLabel3, 1500);
            }
            else 
            {
                double input = double.Parse(bunifuTextBox1.Text);
                newbalance = withdrawAccountBalance - input;
                Balance.UpdateBalance(withdrawUsername, newbalance);
                bunifuLabel2.Visible = false;
                bunifuLabel3.Visible = false;
                ShowLabelTemporarily(bunifuLabel1, 1500);
                withdrawAccountBalance = newbalance;
                Form2.AccountBalanceStatic = newbalance;
                Form2 form2 = new Form2(withdrawUsername, newbalance);
            }
        }
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

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

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
