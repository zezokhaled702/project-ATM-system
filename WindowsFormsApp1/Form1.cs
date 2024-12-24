using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.HPControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static WindowsFormsApp1.LoginForm;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Dictionary<BunifuLabel, Timer> labelTimers;

        #region DragTitlebar
/*        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;*/
        #endregion
        public Form1()
        {
            InitializeComponent();


            // Initialize the dictionary
            labelTimers = new Dictionary<BunifuLabel, Timer>();

            #region Titlbar
/*            // Attach mouse events for dragging
            panel2.MouseDown += TitleBar_MouseDown;
            panel2.MouseMove += TitleBar_MouseMove;
            panel2.MouseUp += TitleBar_MouseUp;*/
            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = bunifuTextBox1.Text;
            string password = guna2TextBox1.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowLabelTemporarily(bunifuLabel1, 2500);
                ShowLabelTemporarily(bunifuLabel3, 2500);
            }
            else if (CheckLogin(username, password) == true)
            {
                this.Hide();
                Form2 form2= new Form2(username);
                form2.Show();
            }
            else
            {
                ShowLabelTemporarily(bunifuLabel2, 1500);
            }



        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
            
        }        
        private void guna2Button2_Click(object sender, EventArgs e)
        {

            
        }

        #region centertheform
/*        private void CenterFormOnScreen()
        {
            // Get the screen dimensions
            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;

            // Calculate the new top-left position
            int newX = (workingArea.Width - this.Width) / 2 + workingArea.Left;
            int newY = (workingArea.Height - this.Height) / 2 + workingArea.Top;

            // Set the new location
            this.Location = new Point(newX, newY);
        }*/
        #endregion

        #region MoveTitlebar
        /*        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
                {
                    dragging = true;
                    dragCursorPoint = Cursor.Position;
                    dragFormPoint = this.Location;
                }

                private void TitleBar_MouseMove(object sender, MouseEventArgs e)
                {
                    if (dragging)
                    {
                        Point newLocation = new Point(
                            dragFormPoint.X + Cursor.Position.X - dragCursorPoint.X,
                            dragFormPoint.Y + Cursor.Position.Y - dragCursorPoint.Y);

                        this.Location = newLocation;
                    }
                }

                private void TitleBar_MouseUp(object sender, MouseEventArgs e)
                {
                    dragging = false;
                }*/
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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


        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void titleBar1_Load(object sender, EventArgs e)
        {

        }

        private void titlebar1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFormDock1_FormDragging(object sender, Bunifu.UI.WinForms.BunifuFormDock.FormDraggingEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormDock1_FormDragging_1(object sender, Bunifu.UI.WinForms.BunifuFormDock.FormDraggingEventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

