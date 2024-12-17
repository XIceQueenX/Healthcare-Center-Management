namespace Gestao_Centro_Saude
{
    partial class PatientDetails
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
            userAppointments = new DataGridView();
            userExams = new DataGridView();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)userAppointments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userExams).BeginInit();
            SuspendLayout();
            // 
            // userAppointments
            // 
            userAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userAppointments.Location = new Point(14, 295);
            userAppointments.Name = "userAppointments";
            userAppointments.RowHeadersWidth = 51;
            userAppointments.Size = new Size(715, 116);
            userAppointments.TabIndex = 1;
            // 
            // userExams
            // 
            userExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userExams.Location = new Point(12, 143);
            userExams.Name = "userExams";
            userExams.RowHeadersWidth = 51;
            userExams.Size = new Size(715, 114);
            userExams.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(505, 12);
            button1.Name = "button1";
            button1.Size = new Size(224, 59);
            button1.TabIndex = 3;
            button1.Text = "Schedule Appointment";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 272);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 4;
            label2.Text = "Appointment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 120);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 5;
            label3.Text = "Exams";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(70, 28);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // button2
            // 
            button2.Location = new Point(505, 77);
            button2.Name = "button2";
            button2.Size = new Size(224, 59);
            button2.TabIndex = 7;
            button2.Text = "Edit Personal Info";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PatientDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 450);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(userExams);
            Controls.Add(userAppointments);
            Name = "PatientDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PatientDetails";
            Load += PatientDetails_Load;
            ((System.ComponentModel.ISupportInitialize)userAppointments).EndInit();
            ((System.ComponentModel.ISupportInitialize)userExams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView userAppointments;
        private DataGridView userExams;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label1;
        private Button button2;
    }
}