using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
   
    public partial class Form1 : Form
    {
        float a, b;
        int count;
        bool znak = true;
        private bool darkTheme = false;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    n13.PerformClick();
                    break;
                case '1':
                    n1.PerformClick();
                    break;
                case '2':
                    n2.PerformClick();
                    break;
                case '3':
                    n3.PerformClick();
                    break;
                case '4':
                    n4.PerformClick();
                    break;
                case '5':
                    n5.PerformClick();
                    break;
                case '6':
                    n6.PerformClick();
                    break;
                case '7':
                    n7.PerformClick();
                    break;
                case '8':
                    n8.PerformClick();
                    break;
                case '9':
                    n9.PerformClick();
                    break;
                case '+':
                    n12.PerformClick();
                    break;
                case '-':
                    n11.PerformClick();
                    break;
                case '*':
                    n10.PerformClick();
                    break;
                case '/':
                    n20.PerformClick();
                    break;
                case '.':
                case ',':
                    n15.PerformClick();
                    break;
                case (char)Keys.Enter:
                    n16.PerformClick();
                    break;
                case (char)Keys.Escape:
                    n18.PerformClick();
                    break;
                case (char)Keys.Back:
                    n17.PerformClick();
                    break;
            }
        }

        private void n1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            { textBox1.Text = "1";
            }
            else
            {
                textBox1.Text += "1";
            }
        }

        private void n2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text += "2";
            }
        }

        private void n3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text += "3";
            }
        }

        private void n4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text += "4";
            }
        }

        private void n5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text += "5";
            }
        }

        private void n6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text += "6";
            }
        }

        private void n7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text += "7";
            }
        }

        private void n8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text += "8";
            }
        }

        private void n9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text += "9";
            }
        }

        private void n13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text += "0";
            }
        }

        private void n15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(","))
                return;

            textBox1.Text += ",";
        }

        private void n10_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label1.Text = a.ToString() + "x";
            znak = true;
        }

        private void n11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "-";
            }
            else
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label1.Text = a.ToString() + "-";
            znak = true;
        }

        private void n20_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "";
            }
        else
                a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label1.Text = a.ToString() + "/";
            znak = true;
        }

        private void n16_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "";
            }
        else
            Calculate();
            label1.Text = "";
        }

        private void n12_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "+";
            }
            else
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 1;
            label1.Text = a.ToString() + "+";
            znak = true;
        }

        private void n18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void n17_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text += text[i];
            }
        }

        private void n14_Click(object sender, EventArgs e)
        {
            if(znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if(znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Theme_Click(object sender, EventArgs e)
        {
            ToggleTheme();
        }

        private void ToggleTheme()
        {
            darkTheme = !darkTheme;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (darkTheme)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                this.ForeColor = Color.White;

                foreach(Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        Button btn = (Button)control;
                        btn.BackColor = Color.FromArgb(63, 63, 70);
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
                    }
                    else if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.BackColor = Color.FromArgb(37, 37, 38);
                        txt.ForeColor = Color.White;
                    }
                    else if (control is Label)
                        {
                        Label lbl = (Label)control;
                        lbl.BackColor = Color.FromArgb(45, 45, 48);
                        lbl.ForeColor = Color.White;
                    }
                }
                textBox1.BackColor = Color.FromArgb(37, 37, 38);
                label1.BackColor = Color.FromArgb(45, 45, 48);
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;

                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        Button btn = (Button)control;
                        btn.BackColor = SystemColors.ControlLight;
                        btn.ForeColor = SystemColors.ControlText;
                        btn.FlatStyle = FlatStyle.Standard;
                    }
                    else if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.BackColor = SystemColors.Window;
                        txt.ForeColor = SystemColors.WindowText;
                    }
                    else if (control is Label)
                    {
                        Label lbl = (Label)control;
                        lbl.BackColor = SystemColors.Control;
                        lbl.ForeColor = SystemColors.ControlText;
                    }
                }

                textBox1.BackColor = SystemColors.Window;
                label1.BackColor = SystemColors.Control;
            }
        }

        private void Calculate()
        {
            switch(count)
            {
                case 1:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 4:
                    if (float.Parse(textBox1.Text) == 0) 
                    {
                        //textBox1.Text = "Деление на ноль";
                        MessageBox.Show("Ошибка! Деление на ноль!");
                        //break;
                    }    
                    else
                    {
                        b = a / float.Parse(textBox1.Text);
                        textBox1.Text = b.ToString();
                    }
                        break;
                    
                default:
                    break;
            }
        }
    }
}
