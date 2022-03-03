using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edytor_tekstu_MyNote_4._10
{
    public partial class Form1 : Form
    {
        public bool CzyZmodyfikowany = true;
        public const string NazwaProgramu = "NotePad";
        readonly DateTime CzasStartu = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
        }

        private void Czcionka_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void Kolor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void Styl_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionBackColor = colorDialog1.Color;
        }

       private void OtworzPlik_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            richTextBox1.LoadFile(openFileDialog1.FileName);
           this.Text = "NotePad" + " - " + openFileDialog1.SafeFileName;
            CzyZmodyfikowany = false;
        }

        private void Zapisz_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            richTextBox1.SaveFile(saveFileDialog1.FileName);
            this.Text = "NotePad" + " - " + saveFileDialog1.FileName;
             CzyZmodyfikowany = false;
        }

        private void NowyPlik_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
                return;
            if (MessageBox.Show("Na pewno chcesz wyczyścić notatkę?", "Jesteś pewien?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            richTextBox1.Clear();
            this.Text = "NotePad";
            CzyZmodyfikowany = false;
        }

        private void InformacjeOautorze_Click(object sender, EventArgs e)
        {
            Form2 okno = new Form2();
            okno.ShowDialog();
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
                Close();
            if (MessageBox.Show("Czy na pewno zakończyć", "Jesteś pewien?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Close();
        }

        private void Lewa_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void Środek_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void Prawe_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void Kopiuj_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void Wytnij_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void Wklej_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void Cofnij_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void Ponów_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void Obrazek_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() != DialogResult.OK) return;
            IDataObject org = Clipboard.GetDataObject();
            Image img = Image.FromFile(openFileDialog2.FileName);
            Clipboard.SetImage(img);
            richTextBox1.Paste();
            Clipboard.SetDataObject(org);
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            richTextBox1.SaveFile(saveFileDialog1.FileName);
            this.Text = "NotePad" + " - " + saveFileDialog1.FileName;
            CzyZmodyfikowany = false;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            richTextBox1.LoadFile(openFileDialog1.FileName);
            this.Text = "NotePad" + " - " + openFileDialog1.SafeFileName;
            CzyZmodyfikowany = false;
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
                return;
            if (MessageBox.Show("Na pewno chcesz wyczyścić notatkę?", "Jesteś pewien?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            richTextBox1.Clear();
            this.Text = "NotePad";
            CzyZmodyfikowany = false;
        }

        private void Przegladarka_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int min = (int)(DateTime.Now - CzasStartu).TotalMinutes;
            toolStripStatusLabel1.Text = "Pracujesz " + min + " minut ";
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
