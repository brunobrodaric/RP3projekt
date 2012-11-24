using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlavnoSucelje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();

        public Form1 otac;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "TXT|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog.FileName;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label3.Enabled = true;
                label4.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                label5.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                label3.Enabled = false;
                label4.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                label5.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Random random = new Random();
                string[] znakoviKaoStringovi = textBox4.Text.Split(' ');
                List<char> znakovi = new List<char>();
                foreach (var znakKaoString in znakoviKaoStringovi)
                {
                    znakovi.Add(znakKaoString[0]);
                }
                znakovi.Add(' '); znakovi.Add(' '); znakovi.Add(' ');
                int kolikoMogucihZnakova = znakovi.Count();
                int duljinaVjezbe = Convert.ToInt32(textBox3.Text);
                string generiranaVjezba = "";
                char prosli = ' ';
                for (int i = 0; i < duljinaVjezbe; i++)
                {
                    int randomNumber = random.Next(0, kolikoMogucihZnakova);
                    if (prosli == ' ' && znakovi[randomNumber] == ' ')
                    {
                        i--;
                        continue;
                    }
                    generiranaVjezba += znakovi[randomNumber].ToString();
                    prosli = znakovi[randomNumber];
                }
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"vjezbe\vlastite\" + textBox1.Text);
                file.WriteLine(generiranaVjezba);
                file.Close();

                System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"vjezbe\vlastite\" + textBox1.Text);
                file2.WriteLine(generiranaVjezba);
                file2.Close();

                System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"vjezbe\popisVlastitih", true);
                file3.WriteLine(textBox1.Text);
                file3.Close();

                this.otac.comboBox2.Items.Add(textBox1.Text);
            }
            else if (radioButton2.Checked == true)
            {
                string generiranaVjezba;
                System.IO.StreamReader file = new System.IO.StreamReader(textBox2.Text);
                generiranaVjezba = file.ReadToEnd();

                System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"vjezbe\vlastite\" + textBox1.Text);
                file2.WriteLine(generiranaVjezba);
                file2.Close();

                System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"vjezbe\popisVlastitih", true);
                file3.WriteLine(textBox1.Text);
                file3.Close();

                this.otac.comboBox2.Items.Add(textBox1.Text);
            }
            this.Close();
        }


    }
}
