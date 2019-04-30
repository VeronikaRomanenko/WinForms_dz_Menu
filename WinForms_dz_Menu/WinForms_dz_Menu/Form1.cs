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
        string tmp1, tmp2;
        ContextMenu cm = null;
        ToolBar toolBar = null;
        ImageList imList = null;
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
            textBox1.ContextMenu = cm;

            imList = new ImageList();
            imList.ImageSize = new Size(15, 15);
            imList.Images.Add(new Bitmap("open.png"));
            imList.Images.Add(new Bitmap("save.png"));
            imList.Images.Add(new Bitmap("new_document.png"));
            imList.Images.Add(new Bitmap("copy.png"));
            imList.Images.Add(new Bitmap("cut.png"));
            imList.Images.Add(new Bitmap("paste.png"));
            imList.Images.Add(new Bitmap("undo.png"));
            imList.Images.Add(new Bitmap("settings.png"));
            toolBar = new ToolBar();
            toolBar.Appearance = ToolBarAppearance.Flat;
            toolBar.BorderStyle = BorderStyle.Fixed3D;                      
            toolBar.ImageList = imList;
            ToolBarButton toolBarButton1 = new ToolBarButton();
            toolBarButton1.Tag = "open";
            ToolBarButton toolBarButton2 = new ToolBarButton();
            toolBarButton2.Tag = "save";
            ToolBarButton toolBarButton3 = new ToolBarButton();
            toolBarButton3.Tag = "new_document";
            ToolBarButton toolBarButton4 = new ToolBarButton();
            toolBarButton4.Tag = "copy";
            ToolBarButton toolBarButton5 = new ToolBarButton();
            toolBarButton5.Tag = "cut";
            ToolBarButton toolBarButton6 = new ToolBarButton();
            toolBarButton6.Tag = "paste";
            ToolBarButton toolBarButton7 = new ToolBarButton();
            toolBarButton7.Tag = "undo";
            ToolBarButton toolBarButton8 = new ToolBarButton();
            toolBarButton8.Tag = "settings";
            toolBarButton1.ImageIndex = 0;
            toolBarButton2.ImageIndex = 1;
            toolBarButton3.ImageIndex = 2;
            toolBarButton4.ImageIndex = 3;
            toolBarButton5.ImageIndex = 4;
            toolBarButton6.ImageIndex = 5;
            toolBarButton7.ImageIndex = 6;
            toolBarButton8.ImageIndex = 7;
            toolBar.Buttons.Add(toolBarButton1);
            toolBar.Buttons.Add(toolBarButton2);
            toolBar.Buttons.Add(toolBarButton3);
            toolBar.Buttons.Add(toolBarButton4);
            toolBar.Buttons.Add(toolBarButton5);
            toolBar.Buttons.Add(toolBarButton6);
            toolBar.Buttons.Add(toolBarButton7);
            toolBar.Buttons.Add(toolBarButton8);
            this.Controls.Add(toolBar);
            toolBar.ButtonClick += ToolBar_ButtonClick;
        }

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
            {
                return;
            }
            switch (e.Button.Tag.ToString())
            {
                case "open":
                    openToolStripMenuItem_Click(this, new EventArgs());
                    break;
                case "save":
                    saveToolStripMenuItem_Click(this, new EventArgs());
                    break;
                case "new_document":
                    newDocumentToolStripMenuItem_Click(this, new EventArgs());
                    break;
                case "copy":
                    copyToolStripMenuItem_Click(this, new EventArgs());
                    break;
                case "cut": 
                    cutToolStripMenuItem_Click(this, new EventArgs());
                    break;
                case "paste":
                    pasteToolStripMenuItem_Click(this, new EventArgs());
                    break;
                case "undo":
                    otmenitToolStripMenuItem_Click(this, new EventArgs());
                    break;
                case "settings":
                    nastrojkiToolStripMenuItem_Click(this, new EventArgs());
                    break;
                default:
                    break;
            }
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
                this.Text = dialog.FileName;
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
            textBox1.Text = tmp2;
        }

        private void videlitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tmp2 = tmp1;
            tmp1 = textBox1.Text;
        }

        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem_Click(this, new EventArgs());
            textBox1.Enabled = true;
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