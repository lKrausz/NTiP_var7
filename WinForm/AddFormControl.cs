using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTiP_var7;

namespace WinForm
{
    public partial class AddFormControl : UserControl
    {
        public bool isModify;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public AddFormControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка на доступность полей контроллера
        /// </summary>
        public void IsEnable(bool _readOnly)
        {
            if (_readOnly)
            {
                FirstTextView.Enabled = false;
                comboBox1.Enabled = false;
            }
            else
            {
                FirstTextView.Enabled = true;
                comboBox1.Enabled = true;
            }
        }

        /// <summary>
        /// Хранение текущего типа элемента в combobox
        /// </summary>
        private int _currentType;

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentType = ((ComboBox)sender).SelectedIndex;
            Setup();
        }

        public IElements Element
        {
            get
            {
                switch (_currentType)
                {
                    case (int)ElementsType.Inductor:
                        {
                            double L = (Convert.ToDouble(FirstTextView.Text));
                            IElements element = new Inductor(L);
                            return element;
                        }
                    case (int)ElementsType.Resistor:
                        {
                            double R = (Convert.ToDouble(FirstTextView.Text));
                            IElements element = new Resistor(R);
                            return element;
                        }
                    case (int)ElementsType.Capacitor:
                        {
                            double C = (Convert.ToDouble(FirstTextView.Text));
                            IElements element = new Capacitor(C);
                            return element;
                        }
                }
                return null;
            }
            set
            {
                if (value is Inductor inductor)
                {
                    comboBox1.SelectedIndex = 0;
                    FirstTextView.Text = inductor.Parametrs.ToString();
                }
                else if (value is Resistor resistor)
                {
                    comboBox1.SelectedIndex = 1;
                    FirstTextView.Text = resistor.Parametrs.ToString();
                }
                else if (value is Capacitor capacitor)
                {
                    comboBox1.SelectedIndex = 2;
                    FirstTextView.Text = capacitor.Parametrs.ToString();
                }
                else throw new NotImplementedException();
            }
        }

        /// <summary>
        ///  Метод, выводящий подсказки по заполнению textbox в зависимости от типа в combobox
        /// </summary>
        private void Setup()
        {
            switch (_currentType)
            {
                case (int)ElementsType.Inductor:
                    {
                        ConfigureTextBoxText(FirstTextView, "Введите L");
                        break;
                    }
                case (int)ElementsType.Resistor:
                    {
                        ConfigureTextBoxText(FirstTextView, "Введите R");
                        break;
                    }
                case (int)ElementsType.Capacitor:
                    {
                        ConfigureTextBoxText(FirstTextView, "Введите С");
                        break;
                    }
            }
        }

        private void ConfigureTextBoxText(TextBox textbox, string title)
        {
            if (textbox.Text == "") textbox.Text = title;
        }

        private void FirstTextView_Click(object sender, EventArgs e)
        {
            if (isModify = false)
            {
                ((TextBox)sender).Text = ""; //meh

            }
        }

        private void FirstTextView_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "") Setup();
        }
    }
}
