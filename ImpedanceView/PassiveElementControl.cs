using System;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class PassiveElementControl : UserControl
    {
        /// <summary>
        /// Хранение текущего типа элемента в combobox
        /// </summary>
        private int _currentType;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public PassiveElementControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Переменная, показывающая, редактируется элемент или добавляется новый
        /// </summary>
        public bool ModifyChecker;

        //TODO: rsdn
        //TODO: сделать свойством вместо метода
        //done
        /// <summary>
        /// Проверка на доступность полей контроллера
        /// </summary>
        public bool EnabledChecker
        {
            set
            {
                FirstTextView.Enabled = value;
                ElementTypeComboBox.Enabled = value;
            }
        }

        //TODO: именование комбобокса
        //TODO: надо использовать событие SelectedIndexChanged
        //done
        private void ElementTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentType = ((ComboBox)sender).SelectedIndex;
            ConfigureTextBoxPlaceholder();
        }

        public IElement Element
        {
            get
            {
                switch (_currentType)
                {
                    case (int)ElementsType.Inductor:
                        {
                            double L = (Convert.ToDouble(FirstTextView.Text));
                            IElement element = new Inductor(L);
                            return element;
                        }
                    case (int)ElementsType.Resistor:
                        {
                            double R = (Convert.ToDouble(FirstTextView.Text));
                            IElement element = new Resistor(R);
                            return element;
                        }
                    case (int)ElementsType.Capacitor:
                        {
                            double C = (Convert.ToDouble(FirstTextView.Text));
                            IElement element = new Capacitor(C);
                            return element;
                        }
                }
                return null;
            }
            set
            {
                if (value is Inductor inductor)
                {
                    ElementTypeComboBox.SelectedIndex = 0;
                    FirstTextView.Text = inductor.Parameter.ToString();
                }
                else if (value is Resistor resistor)
                {
                    ElementTypeComboBox.SelectedIndex = 1;
                    FirstTextView.Text = resistor.Parameter.ToString();
                }
                else if (value is Capacitor capacitor)
                {
                    ElementTypeComboBox.SelectedIndex = 2;
                    FirstTextView.Text = capacitor.Parameter.ToString();
                }
                else throw new NotImplementedException();
            }
        }

        //TODO: название метода не отражает его назначение
        //done
        /// <summary>
        ///  Метод, выводящий подсказки по заполнению textbox в зависимости от типа в combobox
        /// </summary>
        private void ConfigureTextBoxPlaceholder()
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
            if (textbox.Text == string.Empty)
                textbox.Text = title;
        }

        private void FirstTextView_Click(object sender, EventArgs e)
        {
            if (!ModifyChecker)
                FirstTextView.Text = string.Empty; 
        }

        private void FirstTextView_Leave(object sender, EventArgs e)
        {
            if (FirstTextView.Text == String.Empty)
                ConfigureTextBoxPlaceholder();
        }

        private void PassiveElementControl_Load(object sender, EventArgs e)
        {

        }
    }
}
