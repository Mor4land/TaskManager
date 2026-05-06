using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class addTask : Form
    {
      
        public string TaskNameValue => TaskName.Text;
        public string PriorityValue => cmbPriority.SelectedItem?.ToString() ?? "Средняя";
        public string[] Subtasks => rtbSubtasks.Lines;
        public bool hvDeadline => notificationCheckBox.Checked;
        public string DeadlineValue => notificationCheckBox.Checked ? dtDeadline.Value.ToString("dd.MM.yy HH:mm") : "";

        
        
        public addTask()
        {
            InitializeComponent();

            dtDeadline.CustomFormat = "HH:mm | dd-MM-yyyy";
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            
            cmbPriority.SelectedIndex = 1; 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void notificationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (notificationCheckBox.Checked == true)
            {
                dtDeadline.Visible = true;
            }
            else 
            {
                dtDeadline.Visible = false;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
