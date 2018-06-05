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

        public IPassiveElement Element
        {
            get
            {
                switch (currentType)
                {
                    case (int)ElementsType.Inductance:
                    {
                        double L = (Convert.ToDouble(FirstTextView.Text));
                        return new Inductance(L);
                    }
                    case (int)ElementsType.Resistor:
                    {
                        double R = (Convert.ToDouble(FirstTextView.Text));
                        return new Resistor(R);
                    }
                    case (int)ElementsType.Capacitor:
                    {
                        double C = (Convert.ToDouble(FirstTextView.Text));
                        return new Capacitor(C);
                    }
                }
                return Element; //new Capacitor(1);
            }
            set
            {
                if (value is Inductance inductance)
                {
                    comboBox1.SelectedIndex = 0;
                    FirstTextView.Text = inductance.L.ToString();
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

        private int currentType;

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
             currentType = ((ComboBox)sender).SelectedIndex;
             Setup();
        }

        private void Setup()
        {
            switch (currentType)
            {
                case (int)ElementsType.Inductance:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите L");
                    ConfigureTextBoxText(SecondTextView, "Введите w");
                    SecondTextView.Visible = true;
                    break;
                }
                case (int)ElementsType.Resistor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите R");
                    SecondTextView.Visible = false;
                    break;
                }
                case (int)ElementsType.Capacitor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите С");
                    ConfigureTextBoxText(SecondTextView, "Введите w");
                    SecondTextView.Visible = true;
                    break;
                }
            }
        }


        private void FirstTextView_Click(object sender, EventArgs e)
        {
            ((TextBox) sender).Text = "";
        }

        private void FirstTextView_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "" ) Setup();
        }

        private void ConfigureTextBoxText(TextBox textbox, string title)
        {
            if (textbox.Text == "") textbox.Text = title;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            switch (currentType)
            {
                case (int) ElementsType.Inductance:
                {
                    double L = (Convert.ToDouble(FirstTextView.Text));
                    double w = (Convert.ToDouble(SecondTextView.Text));
                    //Parent.CreateDataForInductance(new Inductance(j, w, L));
                    break;
                }
                case (int)ElementsType.Resistor:
                {
                    double R = (Convert.ToDouble(FirstTextView.Text));
                    //Parent.CreateDataForResistor(new Resistor(R));
                    break;
                }
                case (int)ElementsType.Capacitor:
                {
                    double C = (Convert.ToDouble(FirstTextView.Text));
                    double w = (Convert.ToDouble(SecondTextView.Text));
                    //Parent.CreateDataForCapacitor(new Capacitor(j, w, C));
                    break;
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
