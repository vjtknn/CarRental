using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class NewCar : Form
    {
        DataClasses1DataContext db;
        public NewCar()
        {
            InitializeComponent();
            get_all_records();
        }
        private void get_all_records()
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Cars;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();

            Car newCarsCar = new Car();
            newCarsCar.Brand = Brand.Text;
            newCarsCar.Model = Model.Text;
            newCarsCar.Seats = Int32.Parse(Seats.Text);

            db.Cars.InsertOnSubmit(newCarsCar);
            db.SubmitChanges();


            get_all_records();
        }

        private void Brand_TextChanged(object sender, EventArgs e)
        {

        }

        private void Seats_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewCar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet1.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDataSet1.Cars);

        }
    }
}
