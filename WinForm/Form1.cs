using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTiP_var7;

namespace WinForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private List<Capacitor> elements = new List<Capacitor>();

        private void button1_Click(object sender, EventArgs e)
        {
            //elements.Add(new Capacitor() {C = 11, J = 8, W = 4.2});
            //elements.Add(new Capacitor() { C = 11, J = 88, W = 4.2 });
            // elements.Add(new Inductance() { L = 15.6, J = 2, W = 3.9 });
            // elements.Add(new Resistor() { R = 4.7 });
            //dataGridView1.Rows.Add();
            NewObjectOnForm NewForm = new NewObjectOnForm(this);
            NewForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        public void CreateDataForInductance(Inductance inductance)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[1].Value = "Inductance";
            dataGridView1.Rows[n].Cells[2].Value = "j = " + (inductance.J) + ", w = " + (inductance.W) + ", L = " + (inductance.L);
            dataGridView1.Rows[n].Cells[3].Value = inductance.ComplexImpedances();
        }
        public void CreateDataForResistor(Resistor resistor)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[1].Value = "Resistor";
            dataGridView1.Rows[n].Cells[2].Value = "R = " + (resistor.R);
            dataGridView1.Rows[n].Cells[3].Value = resistor.ComplexImpedances();
        }
        public void CreateDataForCapacitor(Capacitor capacitor)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[1].Value = "Capacitor";
            dataGridView1.Rows[n].Cells[2].Value = "j = " + (capacitor.J) + ", w = " + (capacitor.W) + ", C = " + (capacitor.C);
            dataGridView1.Rows[n].Cells[3].Value = capacitor.ComplexImpedances();
        }
    }
}
