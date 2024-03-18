using System.Data;

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

        public void Dodajdogrind(int indeks, string imie, string nazwisko, int wiek, string stanowisko)
        {
            Random random = new Random();
            do
            {
                int randomNumber = random.Next(100, 1000);
                indeks = randomNumber;
                
            } while (CzyIndeksIstnieje(indeks));

            dataGridView1.Rows.Add(indeks, imie, nazwisko, wiek, stanowisko);
        }

        private bool CzyIndeksIstnieje(int indeks)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == indeks)
                {
                    return true; 
                }
            }
            return false; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }

        }

        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            
            string csvContent = "Indeks,Imię,Nazwisko,Wiek,Stanowisko" + Environment.NewLine;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                
                if (!row.IsNewRow)
                {
                    
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            
            File.WriteAllText(filePath, csvContent);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.Title = "Wybierz lokalizację zapisu pliku CSV";
            saveFileDialog1.ShowDialog();
            
            if (saveFileDialog1.FileName != "")
            {
                ExportToCSV(dataGridView1, saveFileDialog1.FileName);
            }

        }

        private void LoadCSVToDataGridView(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string[] lines = File.ReadAllLines(filePath);
            DataTable dataTable = new DataTable();
            string[] headers = lines[0].Split(",");
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            dataGridView1.Columns.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(",");
                dataTable.Rows.Add(values);
            }
            dataGridView1.DataSource = dataTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            openFileDialog1.Title = "Wybierz plik CSV do wczytania";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                LoadCSVToDataGridView(openFileDialog1.FileName);
            }

        }
    }
}
