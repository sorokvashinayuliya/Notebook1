using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Notebook1
{
    
    public partial class Form1 : Form
    {
        private string _openFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text="";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openBox1 = new OpenFileDialog();
            openBox1.Filter = "all(*.*) |*.*";
            if (openBox1.ShowDialog()==DialogResult.OK)
            {
                richTextBox2.Text = File.ReadAllText(openBox1.FileName);
                _openFile = openBox1.FileName;
            }
        }


        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void шрифтToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog myFont = new FontDialog();
            if (myFont.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.Font = myFont.Font;
            }
        }

        private void цветToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.ForeColor = colorDialog.Color;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(_openFile, richTextBox2.Text);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("SAVE ERROR");
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SDialog = new SaveFileDialog();
            SDialog.Filter = "all(*.*) |*.*";
            if (SDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SDialog.FileName,richTextBox2.Text);
                _openFile = SDialog.FileName;
            }
        }

        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDocument pDocument = new PrintDocument();
            pDocument.PrintPage += PrintPageH;
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = pDocument;
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                pDialog.Document.Print();
            }
            
        }
        private void PrintPageH(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox2.Text, richTextBox2.Font, Brushes.Black, 0, 0);
        }

        private void выходToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Название: Блокнот");
        }
        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Cut();
        }
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Paste();
        }
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Copy();
        }

    }
}
