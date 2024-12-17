namespace Gestao_Centro_Saude.ui
{
    partial class AddAppointment
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
            textBoxPatientName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxSpecialization = new ComboBox();
            comboStaff = new ComboBox();
            button1 = new Button();
            dateTimePickerAppointment = new DateTimePicker();
            SuspendLayout();
            // 
            // textBoxPatientName
            // 
            textBoxPatientName.Location = new Point(293, 201);
            textBoxPatientName.Name = "textBoxPatientName";
            textBoxPatientName.Size = new Size(125, 27);
            textBoxPatientName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Paciente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(214, 86);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 3;
            label2.Text = "Especialidade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(509, 82);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 4;
            label3.Text = "Data da Consulta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 86);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 5;
            label4.Text = "Médico";
            // 
            // comboBoxSpecialization
            // 
            comboBoxSpecialization.FormattingEnabled = true;
            comboBoxSpecialization.Location = new Point(214, 109);
            comboBoxSpecialization.Name = "comboBoxSpecialization";
            comboBoxSpecialization.Size = new Size(250, 28);
            comboBoxSpecialization.TabIndex = 7;
            // 
            // comboStaff
            // 
            comboStaff.FormattingEnabled = true;
            comboStaff.Location = new Point(26, 109);
            comboStaff.Name = "comboStaff";
            comboStaff.Size = new Size(151, 28);
            comboStaff.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(28, 371);
            button1.Name = "button1";
            button1.Size = new Size(740, 49);
            button1.TabIndex = 10;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePickerAppointment
            // 
            dateTimePickerAppointment.Location = new Point(509, 109);
            dateTimePickerAppointment.Name = "dateTimePickerAppointment";
            dateTimePickerAppointment.Size = new Size(250, 27);
            dateTimePickerAppointment.TabIndex = 11;
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePickerAppointment);
            Controls.Add(button1);
            Controls.Add(comboStaff);
            Controls.Add(comboBoxSpecialization);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPatientName);
            Name = "AddAppointment";
            Text = "AddAppointment";
            Load += AddAppointment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPatientName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxSpecialization;
        private ComboBox comboStaff;
        private Button button1;
        private DateTimePicker dateTimePickerAppointment;
    }
}