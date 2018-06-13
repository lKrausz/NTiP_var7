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
        public AddFormControl()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Переменная свойства "только для чтения"
        /// </summary>
        public bool _readOnly;


        public void IsReadOnly(bool _readOnly)
        {
            if (_readOnly)
            {
                FirstTextView.ReadOnly = true;
                FirstTextView.Enabled = false;
                comboBox1.Visible = false;
                //SecondTextView.Visible = true;
                //SecondTextView.ReadOnly = true;
                //SecondTextView.Text = "";
            }
            else
            {
                FirstTextView.ReadOnly = false;
                comboBox1.Visible = true;
                //SecondTextView.Visible = false;
            }
        }

        public void IsReadOnly(IElements element)
        {
                FirstTextView.ReadOnly = true;
                FirstTextView.Enabled = false;
                comboBox1.Visible = false;
                FirstTextView.Text = element.Parametrs.ToString();
                SecondTextView.Visible = true;
                SecondTextView.ReadOnly = true;
                SecondTextView.Enabled = false;
                SecondTextView.Text = element.ToString();
        }

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
            ((TextBox)sender).Text = "";
        }

        private void FirstTextView_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "") Setup();
        }

        private void AddFormControl_Load(object sender, EventArgs e)
        {
            IsReadOnly(_readOnly);
        }
    }
}
