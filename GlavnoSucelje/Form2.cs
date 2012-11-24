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
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();

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


    }
}
