namespace WinForm
{
    partial class AddFormControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FirstTextView = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SecondTextView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FirstTextView
            // 
            this.FirstTextView.Location = new System.Drawing.Point(3, 35);
            this.FirstTextView.Name = "FirstTextView";
            this.FirstTextView.Size = new System.Drawing.Size(184, 20);
            this.FirstTextView.TabIndex = 3;
            this.FirstTextView.Click += new System.EventHandler(this.FirstTextView_Click);
            this.FirstTextView.Leave += new System.EventHandler(this.FirstTextView_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Катушка индуктивности",
            "Резистор",
            "Конденсатор"});
            this.comboBox1.Location = new System.Drawing.Point(3, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // SecondTextView
            // 
            this.SecondTextView.Location = new System.Drawing.Point(3, 9);
            this.SecondTextView.Name = "SecondTextView";
            this.SecondTextView.Size = new System.Drawing.Size(184, 20);
            this.SecondTextView.TabIndex = 4;
            // 
            // AddFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SecondTextView);
            this.Controls.Add(this.FirstTextView);
            this.Controls.Add(this.comboBox1);
            this.Name = "AddFormControl";
            this.Size = new System.Drawing.Size(190, 66);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstTextView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox SecondTextView;
    }
}
