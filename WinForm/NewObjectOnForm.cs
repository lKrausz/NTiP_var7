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
        
        public enum ElementsType
        {
            Inductance,
            Resistor,
            Capacitor
        }

        public IPassiveElement Element
        {
            get
            {
                return new Capacitor(1,1,1);
            }
            set
            {
                if (value is Resistor resistor)
                {
                    comboBox1.SelectedIndex = 0;
                    FirstTextView.Text = resistor.R.ToString();
                }
                //throw new NotImplementedException();
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
                    ConfigureTextBoxText(FirstTextView, "Enter j");
                    ConfigureTextBoxText(SecondTextView, "Enter w");
                    ConfigureTextBoxText(ThirdTextView, "Enter L");
                    SecondTextView.Visible = true;
                    ThirdTextView.Visible = true;
                    break;
                }
                case (int)ElementsType.Resistor:
                {
                    ConfigureTextBoxText(FirstTextView, "Enter R");
                    SecondTextView.Visible = false;
                    ThirdTextView.Visible = false;
                    break;
                }
                case (int)ElementsType.Capacitor:
                {
                    ConfigureTextBoxText(FirstTextView, "Enter j");
                    ConfigureTextBoxText(SecondTextView, "Enter w");
                    ConfigureTextBoxText(ThirdTextView, "Enter C");
                    SecondTextView.Visible = true;
                    ThirdTextView.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (currentType)
            {
                case (int) ElementsType.Inductance:
                {
                    double j = (Convert.ToDouble(FirstTextView.Text));
                    double w = (Convert.ToDouble(SecondTextView.Text));
                    double L = (Convert.ToDouble(ThirdTextView.Text));
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
                    double j = (Convert.ToDouble(FirstTextView.Text));
                    double w = (Convert.ToDouble(SecondTextView.Text));
                    double C = (Convert.ToDouble(ThirdTextView.Text));
                    //Parent.CreateDataForCapacitor(new Capacitor(j, w, C));
                    break;
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
