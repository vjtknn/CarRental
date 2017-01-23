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

namespace CarRental
{
    public partial class RentACar : Form
    {
        linqtosqlclassesDataContext db;




        public RentACar()
        {
            InitializeComponent();
            Load_car();
           


        }

        public void Load_car()
        {
            db = new linqtosqlclassesDataContext();
            comboBox1.DataSource = (from d in db.Cars select d.Brand).ToList();
            comboBox1.DisplayMember = "Brand";
            comboBox2.DataSource = (from c in db.Cars select c.Model).ToList();
            comboBox2.DisplayMember = "Model";
            comboBox3.DataSource = (from c in db.Cars select c.Seats).ToList();
            comboBox3.DisplayMember = "Model";
            comboBox5.DataSource = (from c in db.Cars select c.Color).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          



        }

        private void RentACar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDataSet.Cars);

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
