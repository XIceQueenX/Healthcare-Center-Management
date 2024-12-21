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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            labelPatientName = new Label();
            labelPatientMobile = new Label();
            labelPatientGender = new Label();
            labelStaffName = new Label();
            labelDate = new Label();
            dataGridAddExam = new DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            Id = new DataGridViewTextBoxColumn();
            ExamName = new DataGridViewTextBoxColumn();
            Selected = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridAddExam).BeginInit();
            SuspendLayout();
            // 
            // labelPatientName
            // 
            labelPatientName.AutoSize = true;
            labelPatientName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPatientName.Location = new Point(38, 53);
            labelPatientName.Name = "labelPatientName";
            labelPatientName.Size = new Size(70, 28);
            labelPatientName.TabIndex = 2;
            labelPatientName.Text = "label2";
            // 
            // labelPatientMobile
            // 
            labelPatientMobile.AutoSize = true;
            labelPatientMobile.Location = new Point(278, 60);
            labelPatientMobile.Name = "labelPatientMobile";
            labelPatientMobile.Size = new Size(50, 20);
            labelPatientMobile.TabIndex = 3;
            labelPatientMobile.Text = "label2";
            // 
            // labelPatientGender
            // 
            labelPatientGender.AutoSize = true;
            labelPatientGender.Location = new Point(537, 60);
            labelPatientGender.Name = "labelPatientGender";
            labelPatientGender.Size = new Size(50, 20);
            labelPatientGender.TabIndex = 4;
            labelPatientGender.Text = "label2";
            // 
            // labelStaffName
            // 
            labelStaffName.AutoSize = true;
            labelStaffName.Location = new Point(40, 91);
            labelStaffName.Name = "labelStaffName";
            labelStaffName.Size = new Size(50, 20);
            labelStaffName.TabIndex = 5;
            labelStaffName.Text = "label2";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelDate.Location = new Point(517, 9);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(70, 28);
            labelDate.TabIndex = 7;
            labelDate.Text = "label2";
            // 
            // dataGridAddExam
            // 
            dataGridAddExam.AllowUserToAddRows = false;
            dataGridAddExam.AllowUserToDeleteRows = false;
            dataGridAddExam.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridAddExam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridAddExam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridAddExam.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridAddExam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAddExam.Columns.AddRange(new DataGridViewColumn[] { Id, ExamName, Selected });
            dataGridAddExam.Location = new Point(40, 244);
            dataGridAddExam.Name = "dataGridAddExam";
            dataGridAddExam.ReadOnly = true;
            dataGridAddExam.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridAddExam.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridAddExam.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAddExam.Size = new Size(670, 125);
            dataGridAddExam.TabIndex = 14;
            dataGridAddExam.CellContentClick += dataGridViewExams_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(243, 388);
            button1.Name = "button1";
            button1.Size = new Size(293, 46);
            button1.TabIndex = 15;
            button1.Text = "Schedule Exam";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(40, 165);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(547, 60);
            textBox1.TabIndex = 16;
            textBox1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 142);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 17;
            label1.Text = "Additional Details";
            // 
            // button2
            // 
            button2.Location = new Point(593, 166);
            button2.Name = "button2";
            button2.Size = new Size(117, 59);
            button2.TabIndex = 18;
            button2.Text = "Save Details";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Id
            // 
            Id.HeaderText = "Exam ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 93;
            // 
            // ExamName
            // 
            ExamName.HeaderText = "Exam Name";
            ExamName.MinimumWidth = 6;
            ExamName.Name = "ExamName";
            ExamName.ReadOnly = true;
            ExamName.Width = 118;
            // 
            // Selected
            // 
            Selected.HeaderText = "Select Exam";
            Selected.MinimumWidth = 6;
            Selected.Name = "Selected";
            Selected.ReadOnly = true;
            Selected.Resizable = DataGridViewTriState.True;
            Selected.SortMode = DataGridViewColumnSortMode.Automatic;
            Selected.Width = 118;
            // 
            // AppointmentDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridAddExam);
            Controls.Add(labelDate);
            Controls.Add(labelStaffName);
            Controls.Add(labelPatientGender);
            Controls.Add(labelPatientMobile);
            Controls.Add(labelPatientName);
            Name = "AppointmentDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppointmentDetailsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridAddExam).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelPatientName;
        private Label labelPatientMobile;
        private Label labelPatientGender;
        private Label labelStaffName;
        private Label labelDate;
        private DataGridView dataGridAddExam;
        private DataGridViewCheckBoxColumn isSelected;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn ExamName;
        private DataGridViewCheckBoxColumn Selected;
    }
}