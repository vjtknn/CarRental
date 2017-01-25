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
        public DateTime StartDate;
        public DateTime EndDate;
        public int cena { get; set; }
        public string klient { get; set; }

       


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
            comboBox3.DataSource = null;
            comboBox5.DataSource = null;
            listaklientow();
        }

        public void listaklientow()
        {
            db = new linqtosqlclassesDataContext();
            comboBox4.DisplayMember = "Value";
            comboBox4.ValueMember = "Id";
            foreach(var c in db.Customers)
            {
                comboBox4.Items.Add(new { Id = c.Id, Value = c.Last_name + " " + c.Firts_name });
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            marka = comboBox1.SelectedItem.ToString();
            comboBox2.DataSource = (from c in db.Cars where c.Brand == marka select c.Model).ToList();
            comboBox2.DisplayMember = "Model";
            comboBox2.Refresh();
         }

        private void RentACar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDataSet.Cars);

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            kolor = comboBox5.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            modell = comboBox2.SelectedItem.ToString();
            comboBox3.DataSource = (from c in db.Cars where (c.Brand == marka && c.Model == modell) select c.Seats).ToList();
            comboBox3.DisplayMember = "Seats";
            comboBox3.Refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            seats = int.Parse(comboBox3.SelectedItem.ToString());
            comboBox5.DataSource = (from c in db.Cars where (c.Brand == marka && c.Model == modell && c.Seats == seats) select  c.Color).ToList();
            comboBox5.DisplayMember = "Color";
            comboBox5.Refresh();
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
            int? cena = ((from c in db.Cars where (c.Brand == marka && c.Model == modell && c.Seats == seats) select c.Price).SingleOrDefault());
            label9.Text = (cena * totaltime).ToString();
            label9.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\wwinnic1\Documents\test.txt";
            using (StreamWriter zapisz = new StreamWriter(path))
            {
                zapisz.WriteLine($"Marka {marka}");
                zapisz.WriteLine($"Model {modell}");
                zapisz.WriteLine($"Liczba siedzeń {seats}");
                zapisz.WriteLine($"Kolor {kolor}");
                zapisz.WriteLine($"Klient {klient}");
                zapisz.WriteLine($"Od {StartDate}");
                zapisz.WriteLine($"Do {EndDate}");
                zapisz.WriteLine($"Cena za okres {cena}");                               
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            klient = comboBox5.SelectedItem.ToString();
        }
    }
}
