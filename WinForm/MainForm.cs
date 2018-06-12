using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NTiP_var7;

namespace WinForm
{
    //TODO: отключить в datagridview воможность пользователю вводить данные вручную, отключить столбец для выделения строк (САМЫЙ первый столбец с треугольничком)
    //done
    public partial class MainForm : Form
    {
        private uint _w;
        private List<IElements> _elements = new List<IElements>();
        private BindingSource _bindingSource = new BindingSource();
        
        //newtonsoft JSON.NET
        public MainForm()
        {
            InitializeComponent();
            _bindingSource.DataSource = _elements;
            dataGridView1.DataSource = _bindingSource;
            //bindingNavigator1.BindingSource = _bindingSource;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.MultiSelect = true;
            this.dataGridView1.AutoGenerateColumns = true;

        }

        private void Add_Click(object sender, EventArgs e)
        {
            NewObjectOnForm NewForm = new NewObjectOnForm();
            if (NewForm.ShowDialog() == DialogResult.OK)
            {
                var element = NewForm.Element;
                //_elements.Add(element);
                //int m = dataGridView1.Rows.Add();
                //dataGridView1.Rows[m].Cells[0].Value = element.ToString();
                //dataGridView1.Rows[m].Cells[1].Value = element.GetParametr();
                _bindingSource.Add(element);
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            _w = Convert.ToUInt32(WValueTextBox.Text);
            //TODO: Забудь про while, он плохо читаем и используется редко
            //Заменить на foreach!
            //done
            int n = 0;
            foreach (IElements element in _elements)
            {
                dataGridView1.Rows[n].Cells[2].Value = element.GetImpedance(_w);
                n++;
            }
 
        }

        private void Remove_button_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (IElements element in _elements.ToArray())
            {
                //if (dataGridView1.Rows[n].Selected)
                //{
                //    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                //    _elements.Remove(element);
                //}
                //n++;
                if (dataGridView1.CurrentRow.Selected)
                {
                    _bindingSource.Remove(dataGridView1.CurrentRow);
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchForm newForm = new SearchForm();
            newForm.ShowDialog();
        }
    }
}
