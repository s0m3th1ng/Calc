using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormCalc : Form
    {
        double a = 0, b = 0;
        bool changed = false;
        int op;
        public FormCalc()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }

        private double setNum()
        {
            if (label1.Text.Length < 1) {
                label1.Text = "0";
            }
            double t = 0;
            int dot = 0;
            for (int i = 0; i < label1.Text.Length; i++)
            {
                if (label1.Text[i] == '.')
                {
                    dot = i;
                }
            }
            if (dot == 0)
            {
                for (int i = 0; i < label1.Text.Length; i++)
                {
                    t = t * 10 + (int)label1.Text[i] - 48;
                }
            }
            else
            {
                int i = 0;
                while (i < dot)
                {
                    t = t * 10 + (int)label1.Text[i] - 48;
                    i++;
                }
                i++;
                double count = label1.Text.Length - i;
                double temp = 0;
                for (int j = i; j < label1.Text.Length; j++)
                {
                    temp = temp * 10 + (int)label1.Text[j] - 48;
                }
                temp = temp / Math.Pow(10, count);
                t += temp;
            }
            return t;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "4";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "1";
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            changed = false;
            label1.Text = "";
            a = 0;
            b = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                label1.Text = label1.Text + (char)e.KeyChar;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "3";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "5";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "6";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "8";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + ".";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                switch (op)
                {
                    case 1:
                        if (double.Parse(label1.Text) == 0)
                        {
                            label1.Text = "Infinity";
                        }
                        else
                        {
                            a = a / double.Parse(label1.Text);
                        }
                        break;
                    case 2:
                        a = a * double.Parse(label1.Text);
                        break;
                    case 3:
                        a = a + double.Parse(label1.Text);
                        break;
                    case 4:
                        a = a - double.Parse(label1.Text);
                        break;
                }
            }
            else
            {
                changed = true;
                a = double.Parse(label1.Text);
            }
            op = 3;
            label1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                switch (op)
                {
                    case 1:
                        if (double.Parse(label1.Text) == 0)
                        {
                            label1.Text = "Infinity";
                        }
                        else
                        {
                            a = a / double.Parse(label1.Text);
                        }
                        break;
                    case 2:
                        a = a * double.Parse(label1.Text);
                        break;
                    case 3:
                        a = a + double.Parse(label1.Text);
                        break;
                    case 4:
                        a = a - double.Parse(label1.Text);
                        break;
                }
            }
            else
            {
                changed = true;
                a = double.Parse(label1.Text);
            }
            label1.Text = "";
            op = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                switch (op)
                {
                    case 1:
                        if (double.Parse(label1.Text) == 0)
                        {
                            label1.Text = "Infinity";
                        }
                        else
                        {
                            a = a / double.Parse(label1.Text);
                        }
                        break;
                    case 2:
                        a = a * double.Parse(label1.Text);
                        break;
                    case 3:
                        a = a + double.Parse(label1.Text);
                        break;
                    case 4:
                        a = a - double.Parse(label1.Text);
                        break;
                }
            }
            else
            {
                changed = true;
                a = double.Parse(label1.Text);
            }
            label1.Text = "";
            op = 2;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                switch (op)
                {
                    case 1:
                        if (double.Parse(label1.Text) == 0)
                        {
                            label1.Text = "Infinity";
                        }
                        else
                        {
                            a = a / double.Parse(label1.Text);
                        }
                        break;
                    case 2:
                        a = a * double.Parse(label1.Text);
                        break;
                    case 3:
                        a = a + double.Parse(label1.Text);
                        break;
                    case 4:
                        a = a - double.Parse(label1.Text);
                        break;
                }
            }
            else
            {
                changed = true;
                a = double.Parse(label1.Text);
            }
            label1.Text = "";
            op = 4;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            b = setNum();
            switch (op)
            {
                case 1:
                    if (b == 0)
                    {
                        label1.Text = "Infinity";
                    }
                    else
                    {
                        label1.Text = (a / b).ToString();
                    }
                break;
                case 2:
                    label1.Text = (a * b).ToString();
                break;
                case 3:
                    label1.Text = (a + b).ToString();
                break;
                case 4:
                    label1.Text = (a - b).ToString();
                break;
            }
        }
    }
}
