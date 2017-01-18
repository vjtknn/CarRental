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
    public partial class NewEquipment : Form
    {
        DataClasses1DataContext db;
        public NewEquipment()
        {
            InitializeComponent();
            get_all_records();
        }
        private void get_all_records()
        {
            db = new DataClasses1DataContext();
            dataGridView1.DataSource = db.Equipments;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();

            Equipment newEquipment = new Equipment();
            newEquipment.Name = NameElement.Text;

            db.Equipments.InsertOnSubmit(newEquipment);
            db.SubmitChanges();


            get_all_records();
        }

        private void NewEquipment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet.Equipments' table. You can move, or remove it, as needed.
            this.equipmentsTableAdapter.Fill(this.carsDataSet.Equipments);

        }
    }
}
