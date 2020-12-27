using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corretora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            iconPictureBox1.IconChar = Emoji.emoji();
            label1.Text = label1.Text + $" { Connect.userInfo[0] }!!";
        }
    }
}
