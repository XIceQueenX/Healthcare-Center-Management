namespace Gestao_Centro_Saude.ui
{
    partial class AppointmentDetailsForm
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
            labelPatientName = new Label();
            labelPatientMobile = new Label();
            labelPatientGender = new Label();
            labelStaffName = new Label();
            labelStaffSpecialty = new Label();
            labelDate = new Label();
            dataGridAddExam = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridAddExam).BeginInit();
            SuspendLayout();
            // 
            // labelPatientName
            // 
            labelPatientName.AutoSize = true;
            labelPatientName.Location = new Point(40, 28);
            labelPatientName.Name = "labelPatientName";
            labelPatientName.Size = new Size(50, 20);
            labelPatientName.TabIndex = 2;
            labelPatientName.Text = "label2";
            // 
            // labelPatientMobile
            // 
            labelPatientMobile.AutoSize = true;
            labelPatientMobile.Location = new Point(142, 28);
            labelPatientMobile.Name = "labelPatientMobile";
            labelPatientMobile.Size = new Size(50, 20);
            labelPatientMobile.TabIndex = 3;
            labelPatientMobile.Text = "label2";
            // 
            // labelPatientGender
            // 
            labelPatientGender.AutoSize = true;
            labelPatientGender.Location = new Point(214, 30);
            labelPatientGender.Name = "labelPatientGender";
            labelPatientGender.Size = new Size(50, 20);
            labelPatientGender.TabIndex = 4;
            labelPatientGender.Text = "label2";
            // 
            // labelStaffName
            // 
            labelStaffName.AutoSize = true;
            labelStaffName.Location = new Point(465, 30);
            labelStaffName.Name = "labelStaffName";
            labelStaffName.Size = new Size(50, 20);
            labelStaffName.TabIndex = 5;
            labelStaffName.Text = "label2";
            // 
            // labelStaffSpecialty
            // 
            labelStaffSpecialty.AutoSize = true;
            labelStaffSpecialty.Location = new Point(543, 30);
            labelStaffSpecialty.Name = "labelStaffSpecialty";
            labelStaffSpecialty.Size = new Size(50, 20);
            labelStaffSpecialty.TabIndex = 6;
            labelStaffSpecialty.Text = "label2";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(653, 30);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(50, 20);
            labelDate.TabIndex = 7;
            labelDate.Text = "label2";
            // 
            // dataGridAddExam
            // 
            dataGridAddExam.AllowUserToAddRows = false;
            dataGridAddExam.AllowUserToDeleteRows = false;
            dataGridAddExam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAddExam.Location = new Point(40, 81);
            dataGridAddExam.Name = "dataGridAddExam";
            dataGridAddExam.ReadOnly = true;
            dataGridAddExam.RowHeadersWidth = 51;
            dataGridAddExam.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAddExam.Size = new Size(670, 125);
            dataGridAddExam.TabIndex = 14;
            dataGridAddExam.CellContentClick += dataGridViewExams_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(243, 342);
            button1.Name = "button1";
            button1.Size = new Size(293, 46);
            button1.TabIndex = 15;
            button1.Text = "Schedule Exam";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AppointmentDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridAddExam);
            Controls.Add(labelDate);
            Controls.Add(labelStaffSpecialty);
            Controls.Add(labelStaffName);
            Controls.Add(labelPatientGender);
            Controls.Add(labelPatientMobile);
            Controls.Add(labelPatientName);
            Name = "AppointmentDetailsForm";
            Text = "AppointmentDetailsForm";
            Load += AppointmentDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridAddExam).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelPatientName;
        private Label labelPatientMobile;
        private Label labelPatientGender;
        private Label labelStaffName;
        private Label labelStaffSpecialty;
        private Label labelDate;
        private DataGridView dataGridAddExam;
        private DataGridViewCheckBoxColumn isSelected;
        private Button button1;
    }
}