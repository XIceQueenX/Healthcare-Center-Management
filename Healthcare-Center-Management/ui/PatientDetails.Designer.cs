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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            userExams = new DataGridView();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userExams).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 21);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "Exams";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 295);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(715, 116);
            dataGridView1.TabIndex = 1;
            // 
            // userExams
            // 
            userExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userExams.Location = new Point(14, 118);
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
            label3.Location = new Point(14, 95);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 5;
            label3.Text = "Exams";
            // 
            // PatientDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(userExams);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "PatientDetails";
            Text = "PatientDetails";
            Load += PatientDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)userExams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridView userExams;
        private Button button1;
        private Label label2;
        private Label label3;
    }
}