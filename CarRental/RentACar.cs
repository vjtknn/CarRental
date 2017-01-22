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

            db = new linqtosqlclassesDataContext();
            comboBox1.DataSource = (from d in db.Cars select d.Brand).ToList();
            comboBox1.DisplayMember = "Brand";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          



        }

        private void RentACar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDataSet.Cars);

        }
    }
}
