using System.Windows.Forms;

namespace Corretora
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            iconPictureBox1.IconChar = Emoji.emoji();

            label2.Text = label2.Text + $" { Connect.userInfo[0] }";
            label3.Text = label3.Text + $" { Connect.userInfo[1] }";
            label4.Text = label4.Text + $" { Connect.userInfo[2] }";
            label5.Text = label5.Text + $" { Connect.userInfo[3] }";
            label6.Text = label6.Text + $" { Connect.userInfo[4] }";
            label7.Text = label7.Text + $" { Connect.userInfo[5] }";
        }
    }
}
