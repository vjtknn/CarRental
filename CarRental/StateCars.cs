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

        private void load_Cars()
        {
            db = new linqtosqlclassesDataContext();

            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Id";
            var cities = db.Cars.GroupBy(x => x.Brand).Select(y => y.First());
            foreach (var x in cities)
            {
                comboBox1.Items.Add(new { Id = x.Id, Value = x.Brand});
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
                if(x.Brand == value) { 
                comboBox2.Items.Add(new { Id = x.Id, Value = x.Model });
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_Model((comboBox1.SelectedItem as dynamic).Value.ToString());
        }
    }
}
