using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Corretora
{
    public partial class Login : Form
    {        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private Button currentButton;
        private string text;
        MessageBox form;

        public Login()
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
        private void ActivateButton(object senderButton, Color color)
        {
            if (senderButton != null)
            {
                DisableButton();
                currentButton = (Button)senderButton;
                currentButton.BackColor = color;
                currentButton.ForeColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.DarkGreen;
                currentButton.ForeColor = Color.White;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Connect.Login(textBox1.Text, textBox2.Text) == 0){
                this.Hide();
                MainWindow form = new MainWindow();
                form.ShowDialog();
                this.Close(); 
            }
            else
            {
                form = new MessageBox();
                form.label1.Text = "USUÁRIO INVÁLIDO!";
                form.ShowDialog();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        { 
            ForgotMyPassword form = new ForgotMyPassword();
            form.ShowDialog();
        }
        
        private void textBox1_Enter(object sender, EventArgs e)
        {
            text = textBox1.Text;
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = text;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            text = textBox2.Text;
            textBox2.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = text;                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register form = new Register();
            form.ShowDialog();
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
