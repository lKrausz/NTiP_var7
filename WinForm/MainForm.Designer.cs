namespace WinForm
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Remove_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.WValueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchButton);
            this.groupBox1.Controls.Add(this.Remove_button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CalculateButton);
            this.groupBox1.Controls.Add(this.WValueTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Add);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Remove_button
            // 
            this.Remove_button.Location = new System.Drawing.Point(333, 374);
            this.Remove_button.Name = "Remove_button";
            this.Remove_button.Size = new System.Drawing.Size(86, 39);
            this.Remove_button.TabIndex = 7;
            this.Remove_button.Text = "Удалить элемент";
            this.Remove_button.UseVisualStyleBackColor = true;
            this.Remove_button.Click += new System.EventHandler(this.Remove_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "w = ";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(228, 374);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(99, 39);
            this.CalculateButton.TabIndex = 5;
            this.CalculateButton.Text = "Рассчитать сопротивление";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // WValueTextBox
            // 
            this.WValueTextBox.Location = new System.Drawing.Point(319, 39);
            this.WValueTextBox.Name = "WValueTextBox";
            this.WValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.WValueTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Калькулятор комплексного сопротивления";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(123, 374);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(99, 39);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить элемент";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(6, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(413, 303);
            this.dataGridView1.TabIndex = 0;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(6, 374);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(102, 39);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Найти в списке";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Сопротивление";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Параметры";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Элемент";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 120;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 451);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalculatorView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.TextBox WValueTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Remove_button;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

