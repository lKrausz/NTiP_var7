using System;
using System.Windows.Forms;
using NTiP_var7;

namespace WinForm
{
    public partial class NewObjectOnForm : Form
    {
        public NewObjectOnForm()
        {
            InitializeComponent();
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
                    FirstTextView.Text = inductor.L.ToString();
                }
                else if (value is Resistor resistor)
                {
                    comboBox1.SelectedIndex = 1;
                    FirstTextView.Text = resistor.R.ToString();
                }
                else if (value is Capacitor capacitor)
                {
                    comboBox1.SelectedIndex = 2;
                    FirstTextView.Text = capacitor.C.ToString();
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
            ((TextBox) sender).Text = "";
        }

        private void FirstTextView_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "" ) Setup();
        }
        
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
