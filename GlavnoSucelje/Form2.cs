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
            bool nazivJeZauzet = false;
            string zeljeniNazivVjezbe = textBox1.Text;
            System.IO.StreamReader file4 = new System.IO.StreamReader(@"vjezbe\popisVlastitih.txt");
            string nazivPostojeceVjezbe = file4.ReadLine();
            if (zeljeniNazivVjezbe == nazivPostojeceVjezbe) nazivJeZauzet = true;
            while (nazivPostojeceVjezbe != null && nazivJeZauzet == false)
            {
                nazivPostojeceVjezbe = file4.ReadLine();
                if (zeljeniNazivVjezbe == nazivPostojeceVjezbe) nazivJeZauzet = true;
            }
            file4.Close();

            if (nazivJeZauzet)
            {
                MessageBox.Show("Greška: Vlastita vježba odabranog naziva već postoji!");
            }
            else if (radioButton1.Checked == true)
            {
                Random random = new Random();
                string[] znakoviKaoStringovi = textBox4.Text.Split(' ');
                List<char> znakovi = new List<char>();
                foreach (var znakKaoString in znakoviKaoStringovi)
                {
                    znakovi.Add(znakKaoString[0]);
                }
              
                int kolikoMogucihZnakova = znakovi.Count();
                int duljinaVjezbe = Convert.ToInt32(textBox3.Text);
                int duljinaRijeci = Convert.ToInt32(textBox5.Text);
                string generiranaVjezba = "";               
                for (int j = 0; j < duljinaVjezbe; j++)
                {
                    char prosli = ' ';
                    for (int i = 0; i < duljinaRijeci; i++)
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
                    if (j != duljinaVjezbe - 1)
                    {
                        generiranaVjezba += ' ';
                    }
                }
                
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"vjezbe\vlastite\" + zeljeniNazivVjezbe + ".txt");
                file.WriteLine(generiranaVjezba);
                file.Close();

                System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"vjezbe\vlastite\" + zeljeniNazivVjezbe + ".txt");
                file2.WriteLine(generiranaVjezba);
                file2.Close();

                System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"vjezbe\popisVlastitih.txt", true);
                file3.WriteLine(zeljeniNazivVjezbe);
                file3.Close();

                this.otac.comboBox2.Items.Add(zeljeniNazivVjezbe); 
            }
            else if (radioButton2.Checked == true)
            {
                string generiranaVjezba;
                System.IO.StreamReader file = new System.IO.StreamReader(textBox2.Text);
                generiranaVjezba = file.ReadToEnd();

                System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"vjezbe\vlastite\" + zeljeniNazivVjezbe + ".txt");
                file2.WriteLine(generiranaVjezba);
                file2.Close();

                System.IO.StreamWriter file3 = new System.IO.StreamWriter(@"vjezbe\popisVlastitih.txt", true);
                file3.WriteLine(zeljeniNazivVjezbe);
                file3.Close();

                this.otac.comboBox2.Items.Add(zeljeniNazivVjezbe);
            }
            if (nazivJeZauzet == false) this.Close();
        }


    }
}
