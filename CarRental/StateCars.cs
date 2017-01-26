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
    public partial class StateCars : Form
    {
        linqtosqlclassesDataContext db;

        public StateCars()
        {
            InitializeComponent();
            load_Cars();
        }

        private void StateCars_Load(object sender, EventArgs e)
        {
        }

        private void clear_combobox2()
        {
            listBox1.DataSource = null;
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void load_Cars()
        {
            db = new linqtosqlclassesDataContext();

            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Id";
            var cities = db.Cars.GroupBy(x => x.Brand).Select(y => y.First());
            foreach (var x in cities)
            {
                comboBox1.Items.Add(new {Id = x.Id, Value = x.Brand});
            }
        }

        private void load_Model(string value)
        {
            db = new linqtosqlclassesDataContext();

            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Id";
            var cities = db.Cars.GroupBy(x => x.Model).Select(y => y.First());
            comboBox2.Items.Clear();
            foreach (var x in cities)
            {
                if (x.Brand == value)
                {
                    comboBox2.Items.Add(new {Id = x.Id, Value = x.Model});
                }
            }
        }

        private string colors_(string id)
        {
            switch (id)
            {
                case "0":
                    return "Czarny";
                case "1":
                    return "Biały";
                case "2":
                    return "Czerwony";
                case "3":
                    return "Niebieski";
                case "4":
                    return "Żółty";
                case "5":
                    return "Zielony";
                default:
                    return null;
            }
        }

        private void parse_car()
        {
            db = new linqtosqlclassesDataContext();
            int item_id = (comboBox2.SelectedItem as dynamic).Id;
            foreach (var v in (from c in db.Cars_Equipments where c.Cars_id == item_id select c.Equipments_id).ToList())
            {
                listBox1.Items.Add((from i in db.Equipments where i.Id == v select i.Name).FirstOrDefault());

            }
            textBox1.Text = (from c in db.Cars where c.Id == item_id select c.Brand).FirstOrDefault();
            textBox2.Text = (from c in db.Cars where c.Id == item_id select c.Model).FirstOrDefault();
            textBox3.Text = (from c in db.Cars where c.Id == item_id select c.Seats).FirstOrDefault().ToString();
            
            textBox4.Text = colors_((from c in db.Cars where c.Id == item_id select c.Color).FirstOrDefault().ToString());
            textBox5.Text = (from c in db.Cars where c.Id == item_id select c.Price).FirstOrDefault().ToString() + " PLN";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear_combobox2();
            load_Model((comboBox1.SelectedItem as dynamic).Value.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                listBox1.DataSource = null;
                parse_car();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}