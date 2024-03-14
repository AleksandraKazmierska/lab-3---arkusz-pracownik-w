namespace lab_3___arkusz_pracowników
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void Dodajdogrind(int indeks, string imie, string nazwisko,int wiek, string stanowisko)
        {
            dataGridView1.Rows.Add(indeks, imie, nazwisko, wiek, stanowisko);
            indeks = indeks + 1;
        }
    }
}
