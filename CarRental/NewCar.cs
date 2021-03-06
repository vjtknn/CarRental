﻿using System;
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
//            dev_insert_equipment();
            get_all_records();
            get_all_equipments_to_combobox();
            ColorCB.DataSource = Enum.GetValues(typeof(ColorE));
        }

        //Developer Tools!
//        private void dev_insert_equipment()
//        {
//            db = new linqtosqlclassesDataContext();
//
//            Equipment equipment = new Equipment();
//            equipment.Name = "Klima";
//            Equipment equipment2 = new Equipment();
//            equipment2.Name = "Wspomaganie";
//
//            db.Equipments.InsertOnSubmit(equipment);
//            db.Equipments.InsertOnSubmit(equipment2);
//            db.SubmitChanges();
//        }

        //End Developer Tools!!

        private void get_all_records()
        {
            db = new linqtosqlclassesDataContext();
            dataGridView1.DataSource = db.Cars;
//            dataGridView2.DataSource = db.Cars_Equipments;
        }

        private void get_all_equipments_to_combobox()
        {
            db = new linqtosqlclassesDataContext();

            equipments_list.DisplayMember = "Value";
            equipments_list.ValueMember = "Id";
            foreach (var x in db.Equipments)
            {
                equipments_list.Items.Add(new {Id = x.Id, Value = x.Name});
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db = new linqtosqlclassesDataContext();

                Car newCarsCar = new Car();
                newCarsCar.Brand = Brand.Text;
                newCarsCar.Model = Model.Text;
                newCarsCar.Seats = Int32.Parse(Seats.Text);
                newCarsCar.Color = int.Parse(ColorCB.SelectedIndex.ToString());
                newCarsCar.Price = int.Parse(Price.Text);

                db.Cars.InsertOnSubmit(newCarsCar);
                db.SubmitChanges();
                if (addedEquipments.Items.Count != 0)
                {
                    foreach (var items in addedEquipments.Items)
                    {
                        var i = (items as dynamic).Id;
                        Cars_Equipment newCarsEquipment = new Cars_Equipment();
                        newCarsEquipment.Cars_id = newCarsCar.Id;
                        newCarsEquipment.Equipments_id = i;
                        db.Cars_Equipments.InsertOnSubmit(newCarsEquipment);
                        db.SubmitChanges();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Przepraszamy, podano nieprawidłowe dane");
            }
            get_all_records();
            Brand.Clear();
            Model.Clear();
            Seats.Clear();
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

        //        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //        }
        //
        //        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //            allEquipments.Add(dataGridView2.CurrentRow);
        //            MessageBox.Show(addedEquipments.Text);
        //            addedEquipments.Items.Add(dataGridView2.CurrentRow.Cells["Id"].Value.ToString());
        //        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void ColorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addedEquipments.DisplayMember = "Value";
            addedEquipments.ValueMember = "Id";
            addedEquipments.Items.Add(
                new
                {
                    Id = (equipments_list.SelectedItem as dynamic).Id,
                    Value = (equipments_list.SelectedItem as dynamic).Value
                });
        }

        private void addedEquipments_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show((addedEquipments.SelectedItem as dynamic).Id.ToString());
        }

        private void equipments_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}