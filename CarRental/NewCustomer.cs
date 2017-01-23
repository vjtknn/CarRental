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
    public partial class NewCustomer : Form
    {
        linqtosqlclassesDataContext db;

        public NewCustomer()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db = new linqtosqlclassesDataContext();

                Customer newCustomer = new Customer();
                newCustomer.Firts_name = first_name.Text;
                newCustomer.Last_name = last_name.Text;
                db.Customers.InsertOnSubmit(newCustomer);
                db.SubmitChanges();
            }
            catch 
            {
                MessageBox.Show("Przepraszamy, podano nieprawidłowe dane");

            }
            MessageBox.Show("Dodano klienta");
            first_name.Clear();
            last_name.Clear();

        }
    }
}
