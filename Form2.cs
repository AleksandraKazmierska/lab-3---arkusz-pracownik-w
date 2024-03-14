using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3___arkusz_pracowników
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        string[] Tab = { "Stażysta", "Adiunkt", "Profesor", "Dyrektor" };
        int indeks;
        string imie;
        string nazwisko;
        int wiek;
        string stanowisko;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stanowisko = comboBox1.SelectedItem.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form1.Dodajdogrind(indeks, imie, nazwisko, wiek, stanowisko);
            indeks = indeks + 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            imie = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            nazwisko = textBox3.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            wiek = int.Parse(textBox1.Text);
        }
    }
}
