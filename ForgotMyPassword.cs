using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using Dapper;
using System.Runtime.InteropServices;

namespace Corretora
{
    public partial class ForgotMyPassword : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private MessageBox form;
        private string password;

        public ForgotMyPassword()
        {            
            InitializeComponent();
            iconPictureBox1.IconChar = Emoji.emoji();
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password = Connect.ForgotMyPassword(textBox1.Text, textBox2.Text, textBox3.Text);
            if (password != null)
            {
                form = new MessageBox();
                form.label1.Text = $"SUA SENHA É: { password }";
                form.ShowDialog();
                this.Close();
            }
            else
            {
                form = new MessageBox();
                form.label1.Text = "USUÁRIO NÃO ENCONTRADO!";
                form.ShowDialog();
            }            
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }     
    }
}
