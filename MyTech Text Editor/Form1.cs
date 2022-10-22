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

namespace MyTech_Text_Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //fill out the combo boxes
            foreach(FontFamily font in FontFamily.Families)
            {
                FontComboBox.Items.Add(font.Name);
            }
            Object[] sizes = {4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0,
                12.0, 14.0, 16.0, 18.0, 20.0, 22.0, 24.0, 28.0, 32.0, 36.0,
                48.0, 72.0};
            FontSizeBox.Items.AddRange(sizes);
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog(this);
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        //left align
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        //centre align
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        //right align
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        //Bold
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //use bitwise operations to keep other elements of the style the same
            if (!richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                    richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, 
                    richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
            }
        }
        //Italics
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, 
                    richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                    richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
            }
        }
        //underline
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                    richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                    richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
            }
        }
        //change the font. I think we have to use constructors for this,
        //which runs the risk of cancelling out styles. To prevent this,
        //don't do anything if SelectionFont comes back null
        private void FontComboBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontFamily font = new FontFamily(FontComboBox.Text);
                richTextBox1.SelectionFont = new Font(font, richTextBox1.SelectionFont.Size,
                                                richTextBox1.SelectionFont.Style);
            }
        }
        //change the font size
        private void FontSizeBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily,
                float.Parse(FontSizeBox.Text), richTextBox1.SelectionFont.Style);
            }
        }


    }
}
