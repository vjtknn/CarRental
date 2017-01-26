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
    public partial class Clients : Form
    {
        linqtosqlclassesDataContext db;

        public Clients()
        {
            InitializeComponent();
            db = new linqtosqlclassesDataContext();
            dataGridView1.DataSource = db.Customers;

        }

       
    }
}
