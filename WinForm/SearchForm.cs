using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            FirstTextView.Visible = false;
            SecondTextView.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            comboBox2.Visible = false;
            label2.Text = "";
        }
        private int _currentType;

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentType = ((ComboBox)sender).SelectedIndex;
            Setup();
        }

        //Переменные, задающие критерии поиска. 
        /// <summary>
        /// Диапазон значений от minValue до maxValue. 
        /// </summary>
        private double minValue;
        /// <summary>
        /// Диапазон значений от minValue до maxValue. 
        /// </summary>
        private double maxValue;
        /// <summary>
        /// Выбранный тип элемента.
        /// </summary>
        private ElementsType elementType;

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
                    label2.Text = "Выберите тип элемента";
                    break;
                }
                case 1:
                {
                    FirstTextView.Visible = true;
                    SecondTextView.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    comboBox2.Visible = false;
                    label2.Text = "Укажите диапазон значений";
                    break;
                }
                case 2:
                {
                    FirstTextView.Visible = true;
                    SecondTextView.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    comboBox2.Visible = false;
                    label2.Text = "Укажите диапазон значений";
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
