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
        linqtosqlclassesDataContext db;
        public NewCar()
        {
            InitializeComponent();
            get_all_records();
        }
        private void get_all_records()
        {
            db = new linqtosqlclassesDataContext();
            dataGridView1.DataSource = db.Cars;
            dataGridView2.DataSource = db.Equipments;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            try {
                db = new linqtosqlclassesDataContext();

                Car newCarsCar = new Car();
                newCarsCar.Brand = Brand.Text;
                newCarsCar.Model = Model.Text;
                newCarsCar.Seats = Int32.Parse(Seats.Text);

                db.Cars.InsertOnSubmit(newCarsCar);
                db.SubmitChanges();

                
            }catch{
                MessageBox.Show("Przepraszamy, podano nieprawidłowe dane");
            }
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
            // TODO: This line of code loads data into the 'carsDataSet.Equipments' table. You can move, or remove it, as needed.
            this.equipmentsTableAdapter.Fill(this.carsDataSet.Equipments);
            // TODO: This line of code loads data into the 'carsDataSet1.Cars' table. You can move, or remove it, as needed.
            //this.carsTableAdapter.Fill(this.carsDataSet1.Cars);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
