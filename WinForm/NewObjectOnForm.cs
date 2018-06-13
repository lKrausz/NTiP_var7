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

        public NewObjectOnForm(IElements element)
        {
            InitializeComponent();
            addFormControl1.Element = element;
        }


        public IElements NewElement { get; set; }

        private void OK_Click(object sender, EventArgs e)
        {
            NewElement = addFormControl1.Element;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
