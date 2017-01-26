namespace CarRental
{
    partial class Clients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.carsDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.carsDataSet = new CarRental.CarsDataSet();
            this.carsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carsEqipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsEqipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(161, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nasi klienci";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(503, 295);
            this.dataGridView1.TabIndex = 1;
            // 
            // carsDataSetBindingSource1
            // 
            this.carsDataSetBindingSource1.DataSource = this.carsDataSet;
            this.carsDataSetBindingSource1.Position = 0;
            // 
            // carsDataSet
            // 
            this.carsDataSet.DataSetName = "CarsDataSet";
            this.carsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // carsDataSetBindingSource
            // 
            this.carsDataSetBindingSource.DataSource = this.carsDataSet;
            this.carsDataSetBindingSource.Position = 0;
            // 
            // carsEqipmentBindingSource
            // 
            this.carsEqipmentBindingSource.DataSource = typeof(CarRental.Cars_Equipment);
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 363);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Clients";
            this.Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsEqipmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource carsDataSetBindingSource;
        private CarsDataSet carsDataSet;
        private System.Windows.Forms.BindingSource carsEqipmentBindingSource;
        private System.Windows.Forms.BindingSource carsDataSetBindingSource1;
    }
}