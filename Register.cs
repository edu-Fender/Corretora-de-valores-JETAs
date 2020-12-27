using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Corretora
{
    public partial class Register : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        string[] array;
        MessageBox form;

        public Register()
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
            array = new string[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text };
            
            //Checa se string é nula, menor que 3 ou maior que 30
            foreach (string i in array)
            {
                if (3 > i.Length || i.Length > 30)
                {
                    form = new MessageBox();
                    form.label1.Text = "POR FAVOR, PRENCHA OS CAMPOS CORRETAMENTE.";
                    form.ShowDialog();
                    this.Close();
                    return;
                }
            }

            if (textBox7.Text == textBox8.Text)
            {
                if (Connect.Register(array[0], array[1], array[2], array[3], array[4], array[5], array[6]) == 0)
                {
                    form = new MessageBox();
                    form.label1.Text = "USUÁRIO CADASTRADO COM SUCESSO!";
                    form.ShowDialog();
                    this.Close();
                }
                else
                {
                    form = new MessageBox();
                    form.label1.Text = "FALHA. USUÁRIO NÃO PODE SER CADASTRADO.";
                    form.ShowDialog();
                }
            }
            else
            {
                form = new MessageBox();
                form.label1.Text = "SENHAS NÃO COMBINAM. TENTE NOVAMENTE.";
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
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            box.PasswordChar = '*';
        }
    }
}
