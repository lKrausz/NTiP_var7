using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using NTiP_var7;

namespace WinForm
{
    public partial class MainForm : Form
    {
        //newtonsoft JSON.NET
        public MainForm()
        {
            InitializeComponent();
        }

        Complex j = Complex.ImaginaryOne;
        private uint w;
        private List<IPassiveElement> elements = new List<IPassiveElement>(); //IBindingSource

        private void Add_Click(object sender, EventArgs e)
        {
            NewObjectOnForm NewForm = new NewObjectOnForm();
            if (NewForm.ShowDialog() == DialogResult.OK)
            {
                var element = NewForm.Element;
                elements.Add(element);
                int n = dataGridView1.Rows.Add();
                if (element is Inductance inductance)
                {
                    dataGridView1.Rows[n].Cells[1].Value = "Inductance";
                    dataGridView1.Rows[n].Cells[2].Value = "L = " + (inductance.L);
                }
                else if (element is Resistor resistor)
                {
                    dataGridView1.Rows[n].Cells[1].Value = "Resistor";
                    dataGridView1.Rows[n].Cells[2].Value = "R = " + (resistor.R);
                }
                else if (element is Capacitor capacitor)
                {
                    dataGridView1.Rows[n].Cells[1].Value = "Capacitor";
                    dataGridView1.Rows[n].Cells[2].Value = "C = " + (capacitor.C);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            w = (Convert.ToUInt32(WValueTextBox.Text));
            int n = 1;
            while (n <= elements.Count)
            {
                if (elements[n] is Inductance inductance)
                {
                    dataGridView1.Rows[n].Cells[3].Value = inductance.ComplexImpedances(j, w);
                }
                else if (elements[n] is Resistor resistor)
                {
                    dataGridView1.Rows[n].Cells[3].Value = resistor.ComplexImpedances(j, w);
                }
                else if (elements[n] is Capacitor capacitor)
                {
                    dataGridView1.Rows[n].Cells[3].Value = capacitor.ComplexImpedances(j, w);
                }
                n++;
            }
        }
    }
}
