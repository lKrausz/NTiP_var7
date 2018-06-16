using System;
using System.Windows.Forms;
using NTiP_var7;

namespace WinForm
{
    public partial class AddForm : Form
    {
        /// <summary>
        /// Конструктор формы для добавления элемента
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор формы для редактирования элемента
        /// </summary>
        public AddForm(IElements element)
        {
            InitializeComponent();
            NewElement = element;
        }

        public IElements NewElement {
            get => addFormControl1.Element;
            set => addFormControl1.Element = value;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
