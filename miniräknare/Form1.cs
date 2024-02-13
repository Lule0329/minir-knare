using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniräknare
{
    public partial class Form1 : Form
    {
        string mode = ""; // Håller koll på vilket räknesätt som används
        double number = 0; // kommer ihåg vilka siffror som används
        double number2 = 0; // kommer ihåg det andra nummret
        double mr;
        double mc;
        double ms;
        public Form1()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // sender är den knapp som tryckes på
            Button btn = (Button)sender;

            // Lägger till siffran som står i knappen in i textboxen
            label1.Text += btn.Text; 
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            number = double.Parse(label1.Text); // sparar siffrorna i label1
            label1.Text = ""; // rensar texten i label1
            mode = btn.Text; // kommer ihåg vilket räknesätt det är
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            number = double.Parse(label1.Text); // sparar siffrorna i label1
            label1.Text = ""; // rensar texten i label1
            mode = btn.Text; // kommer ihåg vilket räknesätt det är
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Alla "Modes"
            number2 = double.Parse(label1.Text);
            label1.Text = "0";
            
            // Kollar vilket 'Mode' det är och kalkylerar svaret baserat på det.
            if (mode == "+")
            {
                double answer = number + number2;
                label1.Text = answer.ToString();
            }
            else if (mode == "-")
            {
                double answer = number - number2;
                label1.Text = answer.ToString();
            }
            else if (mode == "*")
            {
                double answer = number * number2;
                label1.Text = answer.ToString();
            }
            else if (mode == "/")
            {
                if (number2 == 0)
                {
                    MessageBox.Show("Går inte att dela på 0, :/");
                }
                else
                {
                    double answer = number / number2;  
                    label1.Text = answer.ToString();
                }
                            }
            else if (mode == "X^Y")
            {
                double answer = Math.Pow(number, number2);
                label1.Text = answer.ToString();
            }
            else if (mode == "%")
            {
                if (number != 0)
                {
                    double procent = (number / number2) * 100;
                    label1.Text = procent.ToString() + "%";
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Roten ur
            number = double.Parse(label1.Text);
            double answer = Math.Sqrt(number);
            label1.Text = answer.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Clear
            label1.Text = "";
            number = 0;
            number2 = 0;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            // backspace
            if (!string.IsNullOrEmpty(label1.Text))
            {
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // decimal till binärt 
            int number = int.Parse(label1.Text);
            string binary = Convert.ToString(number, 2);
            label1.Text = binary;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // Binärt till decimal
            string number = label1.Text;
            int binary = Convert.ToInt32(number, 2);
            label1.Text = binary.ToString();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            // Sparfunktionen MR
            if (double.TryParse(label1.Text, out double currentValue))
            {
                mr = currentValue;

            }
            else
            {
                label1.Text = mr.ToString();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            // sparfunktionen MS
            if (double.TryParse(label1.Text, out double currentValue))
            {
                ms = currentValue;

            }
            else
            {
                label1.Text = ms.ToString();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {            
            // Sparfunktionen MC
            if (double.TryParse(label1.Text, out double currentValue))
            {
                mc = currentValue;

            }
            else 
            {
                label1.Text = mc.ToString();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // +/-
            double invert = double.Parse(label1.Text) * -1;
            label1.Text = invert.ToString();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            // Skriver ','
            label1.Text += CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }
    }
}
