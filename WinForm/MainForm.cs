using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using NTiP_var7;

namespace WinForm
{
    public partial class MainForm : Form
    {
        private uint _w;
        private List<IElements> _elements = new List<IElements>();
        private BindingSource _bindingSource = new BindingSource();
        
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ElementType", "Элемент");
            _bindingSource.DataSource = _elements;
            dataGridView1.DataSource = _bindingSource;
            dataGridView1.MultiSelect = true;
            FirstTextView.Visible = false;
            SecondTextView.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            comboBox2.Visible = false;
            label5.Text = "";
            dataGridView1.Columns.Add("ResistanceColumn", "Сопротивление");
            addFormControl1.IsReadOnly(true);
        }


        private void Add_Click(object sender, EventArgs e)
        {
            NewObjectOnForm NewForm = new NewObjectOnForm();
            if (NewForm.ShowDialog() == DialogResult.OK)
            {
                var element = NewForm.NewElement;
                _bindingSource.Add(element);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = element.ToString();
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            _w = Convert.ToUInt32(WValueTextBox.Text);
            int n = 0;
            foreach (IElements element in _bindingSource)
            {
                dataGridView1.Rows[n].Cells["ResistanceColumn"].Value = element.GetImpedance(_w);
                n++;
            }
        }

        private void Remove_button_Click(object sender, EventArgs e)
        {
            for (int n = _elements.Count - 1; n >= 0; n--)
            {
                if (dataGridView1.Rows[_elements.IndexOf(_elements[n])].Selected)
                {
                    _bindingSource.Remove(_elements[n]);
                }
            }
        }

        private int _currentType;

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentType = ((ComboBox)sender).SelectedIndex;
            Setup();
        }

        private void Setup()
        {
            switch (_currentType)
            {
                case 0:
                {
                    FirstTextView.Visible = false;
                    SecondTextView.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    comboBox2.Visible = true;
                    label5.Text = "Выберите тип элемента";
                    break;
                }
                case 1:
                {
                    FirstTextView.Visible = true;
                    SecondTextView.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    comboBox2.Visible = false;
                    label5.Text = "Укажите диапазон значений";
                    break;
                }
                case 2:
                {
                    FirstTextView.Visible = true;
                    SecondTextView.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    comboBox2.Visible = false;
                    label5.Text = "Укажите диапазон значений";
                    break;
                }
            }
        }

        /// <summary>
        /// Выбранный тип элемента.
        /// </summary>
        private ElementsType elementType;

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 0)
                elementType =  ElementsType.Inductor;
            if (((ComboBox)sender).SelectedIndex == 1)
                elementType = ElementsType.Resistor;
            if (((ComboBox)sender).SelectedIndex == 2)
                elementType = ElementsType.Capacitor;
        }

        private List<IElements> _searchResult = new List<IElements>();
        private void SearchButton_Click(object sender, EventArgs e)
        {
            switch (_currentType)
            {
                case 0:
                {
                    //dataGridView1.ClearSelection();
                    //for (int n = _elements.Count - 1; n > 0; n--)
                    //{
                    //    dataGridView1.Rows[n].Visible = false;
                    //}

                    foreach (IElements element in _elements.ToArray())
                    {
                        if (element.ToString() == elementType.ToString())
                        {
                            _searchResult.Add(element);
                        }
                    }
                    _bindingSource.DataSource = null;
                    dataGridView1.DataSource = null;
                    _bindingSource.DataSource = _searchResult;
                    dataGridView1.DataSource = _bindingSource;
                    int n = 0;
                    foreach (IElements element in _searchResult)
                    {
                        dataGridView1.Rows[n].Cells[0].Value = element.ToString();
                        n++;
                    }
                    break;
                }

                case 1:
                {

                    MessageBox.Show("Функция будет добавлена никогда.", "Error");

                        break;
                }

                case 2:
                {
                    MessageBox.Show("Функция будет добавлена никогда.", "Error");
                    break;
                }
            }
        }
        
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            _bindingSource.DataSource = null;
            dataGridView1.DataSource = null;
            _bindingSource.DataSource = _elements;
            dataGridView1.DataSource = _bindingSource;
            int n = 0;
            foreach (IElements element in _elements)
            {
                dataGridView1.Rows[n].Cells[0].Value = element.ToString();
                n++;
            }
        }
        private void RandomButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            for (int i = 0; i < 5; i++)
            {
                var elementType = random.Next(0, 3);
                double value = random.NextDouble() * random.Next(1, 15);
                IElements element;
                switch (elementType)
                {
                    case 0:
                        element = new Inductor(value);
                        _bindingSource.Add(element);
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = element.ToString();
                        break;
                    case 1:
                        element = new Resistor(value);
                        _bindingSource.Add(element);
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = element.ToString(); break;
                    case 2:
                        element = new Capacitor(value);
                        _bindingSource.Add(element);
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = element.ToString(); break;
                }
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string _filePath = "data.cres";

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addFormControl1.IsReadOnly(_elements[dataGridView1.CurrentCell.RowIndex]); /// meh
        }

        private void сохранитьКакToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SerializeBinary(saveFileDialog1.FileName, ref _elements);
        }

        public static void SerializeBinary<T>(string fileName, ref T container)
        {
            var formatter = new BinaryFormatter();
            var serializeFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(serializeFileStream, container);
            serializeFileStream.Close();
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
           
            DeserializeBinary(openFileDialog1.FileName, ref _elements);
            _bindingSource.DataSource = null;
            _bindingSource.DataSource = _elements;
        }

        public static void DeserializeBinary<T>(string fileName, ref T container)
        {
            var formatter = new BinaryFormatter();
            var deserializeFile = new FileStream(fileName, FileMode.OpenOrCreate);
            if (deserializeFile.Length > 0)
            container = (T)formatter.Deserialize(deserializeFile);
            deserializeFile.Close();
        }
    }
}
