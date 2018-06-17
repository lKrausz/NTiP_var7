using System;
//TODO: неиспользуемые юзинги удалить
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
    //TODO: переименовать контрол - не отражает его назначение. Например, textbox явно говорит о редактировании текста
    public partial class AddFormControl : UserControl
    {
        //TODO: rsdn
        public bool isModify;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public AddFormControl()
        {
            InitializeComponent();
        }

        //TODO: rsdn
        //TODO: сделать свойством вместо метода
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

        //TODO: поля в начале класса
        /// <summary>
        /// Хранение текущего типа элемента в combobox
        /// </summary>
        private int _currentType;

        //TODO: именование комбобокса
        //TODO: надо использовать событие SelectedIndexChanged
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

        //TODO: название метода не отражает его назначение
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
            //TODO: string.Empty
            if (textbox.Text == "") textbox.Text = title;
        }

        private void FirstTextView_Click(object sender, EventArgs e)
        {
            if (isModify = false)
            {
                //TODO: string.Empty
                //TODO: зачем преобразование? На контроле один текстбокс
                ((TextBox)sender).Text = ""; //meh

            }
        }

        private void FirstTextView_Leave(object sender, EventArgs e)
        {
            //TODO: string.Empty
            //TODO: зачем преобразование? На контроле один текстбокс
            if (((TextBox)sender).Text == "") Setup();
        }
    }
}
