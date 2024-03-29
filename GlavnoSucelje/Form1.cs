﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GlavnoSucelje
{
   
    public partial class Form1 : Form
    {
        public string trenutniKorisnik;
        public string inputTekst = "";

        public Form1()
        {
            InitializeComponent();

            trenutniKorisnik = "Guest";
            label4.Text = trenutniKorisnik;
            radioButton1.Checked = true;
            radioButton1_Click(this, null);
            comboBox2.Enabled = false;
            button3.Enabled = false;
            System.IO.StreamReader file2 = new System.IO.StreamReader(@"vjezbe\popisVlastitih.txt");
            string nazivVjezbe = file2.ReadLine();
            while (nazivVjezbe != null)
            {
                comboBox2.Items.Add(nazivVjezbe);
                nazivVjezbe = file2.ReadLine();
            }
            file2.Close(); 
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();
        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "TXT|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
             //   textBox2.Text = openFileDialog.FileName;          
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(@"vjezbe\popisLaganih.txt");
            string nazivVjezbe = file.ReadLine();
            while (nazivVjezbe != null)
            {
                string[] nazivKojiPrikazujemo = nazivVjezbe.Split(' ');
                comboBox1.Items.Add(nazivKojiPrikazujemo[1] + " " + nazivKojiPrikazujemo[2] + " " + nazivKojiPrikazujemo[3] + " " + nazivKojiPrikazujemo[4]);
                nazivVjezbe = file.ReadLine();
            }
            file.Close();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(@"vjezbe\popisSrednjih.txt");
            string nazivVjezbe = file.ReadLine();
            while (nazivVjezbe != null)
            {
                comboBox1.Items.Add(nazivVjezbe);
                nazivVjezbe = file.ReadLine();
            }
            file.Close();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(@"vjezbe\popisTeskih.txt");
            string nazivVjezbe = file.ReadLine();
            while (nazivVjezbe != null)
            {
                comboBox1.Items.Add(nazivVjezbe);
                nazivVjezbe = file.ReadLine();
            }
            file.Close();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Enabled == true)
            {
                comboBox2.Enabled = false;
                button3.Enabled = false;
                label3.Enabled = true;
                comboBox1.Enabled = true;
                label2.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = true;
                button3.Enabled = true;
                label3.Enabled = false;
                comboBox1.Enabled = false;
                label2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
        }

        Form2 forma2 = new Form2();

        private void button3_Click(object sender, EventArgs e)
        {
            forma2.otac = this;
            forma2.Show();
        }

        Form3 forma3 = new Form3();

        private void button4_Click(object sender, EventArgs e)
        {
            forma3.otac = this;
            forma3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)  // izabrana neka od vlastitih
            {
                string izabranaVjezba = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                string nazivDatoteke = @"vjezbe\vlastite\" + izabranaVjezba.Split(' ')[0] + ".txt";
                StreamReader streamReader = new StreamReader(nazivDatoteke);
                string tekstVjezbe = streamReader.ReadToEnd();
                streamReader.Close();
                inputTekst = tekstVjezbe;             
            }
            else if (radioButton1.Checked == true)  // izabrana neka s popisa laganih
            {
                string izabranaVjezba = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string nazivDatoteke = @"vjezbe\easy\easy-";
                string[] izabranaRijeci = izabranaVjezba.Split(' ');
                char prviZnakIzabrane = izabranaRijeci[0][0];
                switch (prviZnakIzabrane)   // ovo je malo ruzno ali je tako bilo najjednostavnije
                {
                    case 'F':
                        nazivDatoteke += "FJDK2";
                        break;
                    case 'G':
                        nazivDatoteke += "GHTZ2";
                        break;
                    case 'R':
                        nazivDatoteke += "RUEI2";
                        break;
                    case 'S':
                        nazivDatoteke += "SLACH2";
                        break;
                    case 'V':
                        nazivDatoteke += "VMBN2";
                        break;
                    case 'W':
                        nazivDatoteke += "WOQP2";
                        break;
                    default:
                        nazivDatoteke += izabranaRijeci[0] + izabranaRijeci[1] + izabranaRijeci[2] + izabranaRijeci[3];
                        break;
                }
                nazivDatoteke += ".txt";
                StreamReader streamReader = new StreamReader(nazivDatoteke);
                string tekstVjezbe = streamReader.ReadToEnd();
                streamReader.Close();
                inputTekst = tekstVjezbe;
            }
            else   // izabrana neka od srednjih ili teskih
            {
                string izabranaVjezba = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string nazivDatoteke;
                if (radioButton2.Checked == true)
                {
                    nazivDatoteke = @"vjezbe\medium\";
                }
                else
                {
                    nazivDatoteke = @"vjezbe\hard\";
                }
                nazivDatoteke += izabranaVjezba.Split(' ')[0] + ".txt";
                StreamReader streamReader = new StreamReader(nazivDatoteke);
                string tekstVjezbe = streamReader.ReadToEnd();
                streamReader.Close();
                inputTekst = tekstVjezbe;
            }
            MessageBox.Show(inputTekst);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

       
    }
}
