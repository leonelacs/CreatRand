using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatRand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (nudLower.Value >= nudUpper.Value)
            {
                lblSign.Text = "Range error!";
                lblSign.ForeColor = Color.Red;
                return;
            }
            lblSign.Text = "Generating...";
            lblSign.ForeColor = Color.DeepSkyBlue;
            List<int> Num = new List<int>();
            Random rd;
            for(int i = 0; i < nudAmount.Value; i++)
            {
                rd = new Random(GetRandomSeed());
                Num.Add(rd.Next((int)nudLower.Value, (int)nudUpper.Value + 1));
            }
            using (StreamWriter sw = new StreamWriter("random.txt"))
            {
                //sw.WriteLine(nudAmount.Value);
                foreach (int num in Num)
                {
                    sw.WriteLine(num);
                }
            }
            lblSign.Text = "Data saved";
            lblSign.ForeColor = Color.DarkGreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
