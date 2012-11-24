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
    public partial class Form3 : Form
    {
        public Form1 otac;

        public Form3()
        {
            InitializeComponent();
            System.IO.StreamReader file = new System.IO.StreamReader(@"statistike\popisKorisnika");
            string imeKorisnika = file.ReadLine();
            while (imeKorisnika != null)
            {
                listBox1.Items.Add(imeKorisnika);
                imeKorisnika = file.ReadLine();
            }
            file.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imeKorisnika = textBox1.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"statistike\popisKorisnika", true);
            file.WriteLine(imeKorisnika);
            file.Close();
            listBox1.Items.Add(imeKorisnika);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.otac.trenutniKorisnik = (string)listBox1.SelectedItem;
            this.otac.label4.Text = (string)listBox1.SelectedItem;
            this.Close();
        }
    }
}
