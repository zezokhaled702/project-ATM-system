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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private Dictionary<BunifuLabel, Timer> labelTimers;

        public Form3()
        {
            InitializeComponent();
            labelTimers = new Dictionary<BunifuLabel, Timer>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox1.Text == "" ||
                bunifuTextBox4.Text == "" || bunifuTextBox6.Text == "" ||
                bunifuTextBox7.Text == "" || guna2TextBox1.Text == "" || guna2TextBox2.Text == ""
                || guna2ComboBox1.SelectedIndex == -1)
            {
                ShowLabelTemporarily(bunifuLabel5, 2000);
            }
            else
            {
                #region SignUp_Proberties
                string passConf = guna2TextBox2.Text;
                stClient client = new stClient();
                client.username = bunifuTextBox1.Text;
                client.firstname = bunifuTextBox3.Text;
                client.lastname = bunifuTextBox4.Text;
                client.phone = bunifuTextBox6.Text;
                client.address = bunifuTextBox7.Text;
                client.password = guna2TextBox1.Text;
                client.gender = guna2ComboBox1.Text;
                #endregion
                if (SignUpForm.CheckSignUp(client.username) == true)
                {
                    if (client.password != passConf)
                    {
                        ShowLabelTemporarily(bunifuLabel3, 1000);
                        ShowLabelTemporarily(bunifuLabel2, 1000);
                    }

                    ShowLabelTemporarily(bunifuLabel1, 2000);
                }
                else
                {
                    if (client.password == passConf)
                    {
                        SignUpForm.InsertClient(client);
                        ShowLabelTemporarily(bunifuLabel4, 2000);
                        // Navigate to the first form
                    }
                    else
                    {
                        ShowLabelTemporarily(bunifuLabel3, 1000);
                        ShowLabelTemporarily(bunifuLabel2, 1000);
                    }

                }
            }

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

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void bunifuTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace and Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press if it's not a digit or control key
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
