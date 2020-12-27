using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Corretora
{
    public partial class MainWindow : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private Button currentButton;
        private Form childForm;
       

        public MainWindow()
        {            
            InitializeComponent();
            iconPictureBox6.IconChar = Emoji.emoji();
            openForm(new Form1());
        }
        static public void emoji(object Sender, MouseEventArgs e)
        {
            Random random = new Random();
            int number = random.Next(0, 20);
        }

        private void panel_MouseMove (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
                
        private void openForm(Form currentForm)
        {
            childForm = currentForm;
            childForm.TopLevel = false;
            childForm.Visible = true;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {            
            openForm(new Form1());
        }        
        private void iconButton2_Click(object sender, EventArgs e)
        {
            openForm(new Form2());
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            openForm(new Form3());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            openForm(new Form4());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            openForm(new Form1());
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {            
            WindowState = FormWindowState.Minimized;
        }        
    }
}