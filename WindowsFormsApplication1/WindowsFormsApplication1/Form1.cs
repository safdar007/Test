using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static int number = 0;
        public Form1()
        {
            InitializeComponent();
        }

        static void readThread()
        {
            Console.WriteLine("Socket connected to {0}");
            number = Decimal.ToInt32(numericUpDown1.Value + numericUpDown2.Value);
            numericUpDown3.Value = number;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Thread clientThread = new Thread(new ThreadStart(readThread));        
            number = Decimal.ToInt32  (numericUpDown1.Value + numericUpDown2.Value);
            numericUpDown3.Value = number;
        }
    }
}
