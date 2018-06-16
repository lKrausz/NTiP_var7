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
        /// <summary>
        /// Частота
        /// </summary>
        private uint _w;

        /// <summary>
        /// Список пассивных элементов
        /// </summary>
        private List<IElements> _elements = new List<IElements>();

        /// <summary>
        ///  Связующий _elements и gridview список
        /// </summary>
        private BindingSource _bindingSource = new BindingSource();

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ElementType", "Элемент");
            _bindingSource.DataSource = _elements;
            dataGridView1.DataSource = _bindingSource;
            dataGridView1.MultiSelect = true;
            dataGridView1.Columns.Add("ResistanceColumn", "Сопротивление");
            addFormControl1.IsEnable(true);
        }

        /// <summary>
        ///  Кнопка добавления нового элемента
        /// </summary>
        private void Add_Click(object sender, EventArgs e)
        {
            addFormControl1.isModify = true;
            AddForm NewForm = new AddForm();
            if (NewForm.ShowDialog() == DialogResult.OK)
            {
                var element = NewForm.NewElement;
                _bindingSource.Add(element);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = element.ToString();
            }
        }

        /// <summary>
        /// Кнопка для вычисления комплексного сопротивления для всех элементов в таблице
        /// </summary>
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

        /// <summary>
        /// Кнопка удаления элементов
        /// </summary>
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

        /// <summary>
        /// Хранение текущего критерия поиска
        /// </summary>
        private int _currentType;

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentType = ((ComboBox)sender).SelectedIndex;
        }

        /// <summary>
        /// Выбранный в критериях поиска тип элемента
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

        /// <summary>
        /// Список для элементов, которых подходят по критериям поиска
        /// </summary>
        private List<IElements> _searchResult = new List<IElements>();

        /// <summary>
        /// Кнопка поиска
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            switch (_currentType)
            {
                case 0:
                {
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
            }
        }

        /// <summary>
        /// Кнопка для очистки критериев поиска и возвращения к полному списку элементов
        /// </summary>
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

        /// <summary>
        /// Кнопка для создания рандомных данных
        /// </summary>
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

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addFormControl1.IsEnable(true);
            addFormControl1.Element = _elements[dataGridView1.CurrentCell.RowIndex];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addFormControl1.IsEnable(true);
            int index = dataGridView1.CurrentCell.RowIndex;
            addFormControl1.isModify = true;
            AddForm NewForm = new AddForm(_elements[index]);
            if (NewForm.ShowDialog() == DialogResult.OK)
            {
                var element = NewForm.NewElement;
                _bindingSource.Remove(_elements[index]);
                _bindingSource.Insert(index, element);
                dataGridView1.Rows[index].Cells[0].Value = element.ToString();
            }     
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Serializer.SerializeBinary(saveFileDialog1.FileName, ref _elements);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
           
            Serializer.DeserializeBinary(openFileDialog1.FileName, ref _elements);
            _bindingSource.DataSource = null;
            _bindingSource.DataSource = _elements;
        }
    }
}
