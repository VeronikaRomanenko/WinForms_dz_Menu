using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_dz_Menu
{
    public partial class Form1 : Form
    {
        ContextMenu cm = null;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cm = new ContextMenu();
            MenuItem Copy = new MenuItem("Копировать");
            MenuItem Cut = new MenuItem("Вырезать");
            MenuItem Paste = new MenuItem("Вставить");
            MenuItem Otmena = new MenuItem("Отменить");
            cm.MenuItems.Add(Copy);
            cm.MenuItems.Add(Cut);
            cm.MenuItems.Add(Paste);
            cm.MenuItems.Add(Otmena);
            Copy.Click += copyToolStripMenuItem_Click;
            Cut.Click += cutToolStripMenuItem_Click;
            Paste.Click += pasteToolStripMenuItem_Click;
            Otmena.Click += otmenitToolStripMenuItem_Click;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName);
                textBox1.Enabled = true;
                this.Text = dialog.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(this.Text, textBox1.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, textBox1.Text);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void otmenitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void videlitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nastrojkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.ShowColor = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = dialog.Font;
            }
        }
    }
}