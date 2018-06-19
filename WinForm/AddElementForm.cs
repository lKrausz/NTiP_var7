using System;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class AddElementForm : Form

    {
        /// <summary>
        /// Конструктор формы для добавления элемента
        /// </summary>
        public AddElementForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор формы для редактирования элемента
        /// </summary>
        public AddElementForm(IElement element, bool isModify)
        {
            InitializeComponent();
            addFormControl1.ModifyChecker = isModify;
            NewElement = element;
        }

        public IElement NewElement {
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
