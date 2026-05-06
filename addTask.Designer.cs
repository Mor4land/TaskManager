namespace TaskManager
{
    partial class addTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TaskName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.notificationCheckBox = new System.Windows.Forms.CheckBox();
            this.rtbSubtasks = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtDeadline = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // TaskName
            // 
            this.TaskName.Location = new System.Drawing.Point(27, 48);
            this.TaskName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TaskName.Name = "TaskName";
            this.TaskName.Size = new System.Drawing.Size(493, 22);
            this.TaskName.TabIndex = 0;
            this.TaskName.Text = "Введите название задачи";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Сложность:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Легкая",
            "Средняя",
            "Высокая"});
            this.cmbPriority.Location = new System.Drawing.Point(212, 95);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(308, 24);
            this.cmbPriority.TabIndex = 3;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // notificationCheckBox
            // 
            this.notificationCheckBox.AutoSize = true;
            this.notificationCheckBox.Location = new System.Drawing.Point(29, 162);
            this.notificationCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.notificationCheckBox.Name = "notificationCheckBox";
            this.notificationCheckBox.Size = new System.Drawing.Size(166, 20);
            this.notificationCheckBox.TabIndex = 4;
            this.notificationCheckBox.Text = "Включить будильник";
            this.notificationCheckBox.UseVisualStyleBackColor = true;
            this.notificationCheckBox.CheckedChanged += new System.EventHandler(this.notificationCheckBox_CheckedChanged);
            // 
            // rtbSubtasks
            // 
            this.rtbSubtasks.AcceptsTab = true;
            this.rtbSubtasks.Location = new System.Drawing.Point(29, 222);
            this.rtbSubtasks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbSubtasks.Name = "rtbSubtasks";
            this.rtbSubtasks.Size = new System.Drawing.Size(489, 131);
            this.rtbSubtasks.TabIndex = 5;
            this.rtbSubtasks.Text = "";
            this.rtbSubtasks.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Подзадачи (одна на строку):";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(349, 370);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(445, 370);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtDeadline
            // 
            this.dtDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDeadline.Location = new System.Drawing.Point(263, 162);
            this.dtDeadline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtDeadline.Name = "dtDeadline";
            this.dtDeadline.Size = new System.Drawing.Size(257, 22);
            this.dtDeadline.TabIndex = 9;
            this.dtDeadline.Visible = false;
            this.dtDeadline.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // addTask
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(549, 405);
            this.Controls.Add(this.dtDeadline);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbSubtasks);
            this.Controls.Add(this.notificationCheckBox);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TaskName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "addTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить новую задачу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.CheckBox notificationCheckBox;
        private System.Windows.Forms.RichTextBox rtbSubtasks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtDeadline;
    }
}