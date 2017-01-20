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
        public List<object> allEquipments = new List<object>();
        public NewCar()
        {
            InitializeComponent();
            dev_insert_equipment();
            get_all_records();
            
        }

        //Developer Tools!
        private void dev_insert_equipment()
        {
            db = new linqtosqlclassesDataContext();

            Equipment equipment = new Equipment();
            equipment.Name = "Klima";
            Equipment equipment2 = new Equipment();
            equipment2.Name = "Wspomaganie";

            db.Equipments.InsertOnSubmit(equipment);
            db.Equipments.InsertOnSubmit(equipment2);
            db.SubmitChanges();
        }
        //End Developer Tools!!

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


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            allEquipments.add
            MessageBox.Show(addedEquipments.Text);
            addedEquipments.Items.Add(dataGridView2.CurrentRow.Cells["Id"].Value.ToString());

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
