using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        float num = 0, result = 0;
        int loop=0,status=0,first =0,digit =0, equals = 0,start = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            num = result = loop = first = digit = equals = start = 0;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (digit < 8)
            {
                if (start == 0)
                {
                    lblDisplay.Text = ((Button)sender).Text;start = 1;
                }
                else if (loop > 0) { lblDisplay.Text = ((Button)sender).Text; loop = 0; }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + ((Button)sender).Text;
                }
                equals = 0;
                digit++;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text.Contains(".") == false)
            {
                lblDisplay.Text += ".";
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            num = float.Parse(lblDisplay.Text);
            switch (status)
            {
                case 1:
                    result = result + num;
                    break;
                case 2:
                    if (first == 1)
                    {
                        result = result - num;
                    }
                    else
                    {
                        result = num;
                    }
                    break;
                case 3:
                    if (first == 1)
                    {
                        result = result * num;
                    }
                    else
                    {
                        result = 1;
                        result = result * num;
                    }
                    break;
                case 4:
                    if (first == 1)
                    {
                        result = result / num;
                    }
                    else
                    {
                        result = num;
                    }
                    break;
            }
                lblDisplay.Text = result.ToString();
            if (lblDisplay.Text.Length > 9)
            {
                lblDisplay.Text = "Error";
            }
            digit = 0;
            loop = 1;
            equals = 1;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            double percent;
            percent = double.Parse(lblDisplay.Text);
            percent = result*(percent / 100.00);
            loop = 1;
            lblDisplay.Text = percent.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "0")
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
                if(lblDisplay.Text.Length == 0)
                {
                    lblDisplay.Text = "0";
                }
            }

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            double numtoswap;
            numtoswap = double.Parse(lblDisplay.Text);
            numtoswap = numtoswap * -1.0;
            lblDisplay.Text = numtoswap.ToString();
        }
        
        private void btnPlus_Click(object sender, EventArgs e)
        {
            num = float.Parse(lblDisplay.Text);
            if (first == 0){ status = 1; }
            loop = 1;
            if (equals == 0)
                btnEqual_Click(sender, e);
            status = 1;
            first = 1;
            lblDisplay.Text = result.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            num = float.Parse(lblDisplay.Text);
            if (first == 0) { status = 2; }
            loop = 1;
            if (equals == 0)
                btnEqual_Click(sender, e);
            status = 2;
            first = 1;
            lblDisplay.Text = result.ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            num = float.Parse(lblDisplay.Text);
            if (first == 0) { status = 3; }
            loop = 1;
            if (equals == 0)
                btnEqual_Click(sender, e);
            status = 3;
            first = 1;
            lblDisplay.Text = result.ToString();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            num = float.Parse(lblDisplay.Text);
            if (first == 0) { status = 4; }
            loop = 1;
            if (equals == 0)
                btnEqual_Click(sender, e);
            status = 4;
            first = 1;
            lblDisplay.Text = result.ToString();
        }
    }
}
