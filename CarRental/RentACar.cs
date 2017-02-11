using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.IO;

namespace CarRental
{
    public partial class RentACar : Form
    {
        linqtosqlclassesDataContext db;
        public string marka { get; set; }
        public string modell { get; set; }
        public int seats { get; set; }
        public string kolor { get; set; }
        public DateTime StartDate = DateTime.Today;
        public DateTime EndDate = DateTime.Today;
        public int cena { get; set; }
        public string klient { get; set; }
        public List<string> wyposazenie { get; set; }
 

        public RentACar()
        {
            InitializeComponent();
            Load_car();
        }


        public void Load_car()
        {
            db = new linqtosqlclassesDataContext();
            comboBox1.DataSource = (from d in db.Cars select d.Brand).Distinct();
            comboBox1.DisplayMember = "Brand";
            comboBox2.DataSource = null;
            comboBox4.DataSource = null;
            comboBox5.DataSource = null;
            listBox1.Items.Clear();
            listaklientow();
        }

        public void listaklientow()
        {
            db = new linqtosqlclassesDataContext();
            comboBox4.DisplayMember = "Names";
            comboBox4.ValueMember = "Id";
            var klienci = (from c in db.Customers select new {c.Id, Names = c.Last_name + " " + c.Firts_name}).ToList();
            comboBox4.DataSource = klienci;
         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            marka = comboBox1.SelectedItem.ToString();
            comboBox2.DataSource = (from c in db.Cars where c.Brand == marka select c.Model).ToList();
            comboBox2.DisplayMember = "Model";

            comboBox2.Refresh();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            modell = comboBox2.SelectedItem.ToString();

            comboBox3.DataSource =
                (from c in db.Cars where (c.Brand == marka && c.Model == modell) select c.Seats).ToList();
            comboBox3.DisplayMember = "Seats";
            comboBox3.Refresh();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            seats = int.Parse(comboBox3.SelectedItem.ToString());

            comboBox5.DataSource =
                  (from c in db.Cars where (c.Brand == marka && c.Model == modell && c.Seats == seats) select c.Color)
                  .ToList().Cast<ColorE>().ToList();
            comboBox5.DisplayMember = "Color";
            comboBox5.Refresh();

        }

        private void RentACar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDataSet.Cars);
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            klient = comboBox4.SelectedItem.ToString();

        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            kolor = comboBox5.SelectedItem.ToString();
            List<int> carId =
       (from c in db.Cars where (c.Brand == marka && c.Model == modell && c.Seats == seats) select c.Id).ToList();
            List<int?> equipId =
                (from c in db.Cars_Equipments where c.Cars_id == carId.FirstOrDefault() select c.Equipments_id).ToList();

            foreach (var v in equipId)
            {
                listBox1.Items.Add((from c in db.Equipments where c.Id == v select c.Name).FirstOrDefault());
                wyposazenie.Add((from c in db.Equipments where c.Id == v select c.Name).FirstOrDefault());
            }

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            StartDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            EndDate = dateTimePicker2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan ts = (StartDate - EndDate);
            int totaltime = Math.Abs(ts.Days);
            var cena =
            ((from c in db.Cars where (c.Brand == marka && c.Model == modell && c.Seats == seats) select c.Price)
                .SingleOrDefault());
            label9.Text = (cena * totaltime).ToString();
            label9.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"D:\Downloads\test.txt";
            using (StreamWriter zapisz = new StreamWriter(path))
            {
                zapisz.WriteLine($"Marka {marka}");
                zapisz.WriteLine($"Model {modell}");
                zapisz.WriteLine($"Liczba siedzeń {seats.ToString()}");
                zapisz.WriteLine($"Kolor: {kolor}");
                /* zapisz.Write("Wyposażenie: ");
                foreach (var v in wyposazenie)
                {
                    zapisz.Write($" {v.ToString()},");
                } */
                zapisz.WriteLine($"Klient {klient}");
                zapisz.WriteLine($"Od {StartDate}");
                zapisz.WriteLine($"Do {EndDate}");
                zapisz.WriteLine($"Cena za okres {cena}");
            }
        }

   

        private void RentACar_Load_1(object sender, EventArgs e)
        {
        }

      
    }
}