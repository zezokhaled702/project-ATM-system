using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.HPControls
{
    public partial class ChangePassword : UserControl
    {
        private Dictionary<BunifuLabel, Timer> labelTimers;
        public static string passUsername;
        public ChangePassword()
        {
            labelTimers = new Dictionary<BunifuLabel, Timer>();
            InitializeComponent();
        }
        public ChangePassword(string username)
        {
            labelTimers = new Dictionary<BunifuLabel, Timer>();
            passUsername = username;
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox3.Text != "")
            {
                string oldPass = guna2TextBox1.Text;
                string newPass = guna2TextBox2.Text;
                string confPass = guna2TextBox3.Text;
                if (newPass != confPass)
                {
                    ShowLabelTemporarily(bunifuLabel3, 1500);
                    ShowLabelTemporarily(bunifuLabel4, 1500);
                }
                else if (ChangePin.CheckOldPin(passUsername, oldPass))
                {
                    ChangePin.UpdatePin(passUsername, newPass);
                    ShowLabelTemporarily(bunifuLabel1, 1500);
                }
                else if (!ChangePin.CheckOldPin(passUsername, oldPass))
                {
                    ShowLabelTemporarily(bunifuLabel2, 1500);
                }
            }
            else
                ShowLabelTemporarily(bunifuLabel5, 1500);
        
        }

        private void Old_Click(object sender, EventArgs e)
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

    }
}
