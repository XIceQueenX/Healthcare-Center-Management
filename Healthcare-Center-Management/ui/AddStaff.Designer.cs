namespace Gestao_Centro_Saude.ui
{
    partial class AddStaff
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
            comboBox1 = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            label2 = new Label();
            patient_mobilePhone = new TextBox();
            label1 = new Label();
            patient_Name = new TextBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            comboBoxSpeciality = new ComboBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "Male";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "M", "F" });
            comboBox1.Location = new Point(160, 216);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 17;
            comboBox1.ValueMember = "Male";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(160, 193);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 15;
            label3.Text = "Gender";
            // 
            // button1
            // 
            button1.Location = new Point(307, 315);
            button1.Name = "button1";
            button1.Size = new Size(128, 29);
            button1.TabIndex = 14;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(373, 127);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 13;
            label2.Text = "Mobile Phone";
            // 
            // patient_mobilePhone
            // 
            patient_mobilePhone.Location = new Point(373, 150);
            patient_mobilePhone.Name = "patient_mobilePhone";
            patient_mobilePhone.Size = new Size(192, 27);
            patient_mobilePhone.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 127);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 11;
            label1.Text = "Name";
            // 
            // patient_Name
            // 
            patient_Name.Location = new Point(160, 150);
            patient_Name.Name = "patient_Name";
            patient_Name.Size = new Size(183, 27);
            patient_Name.TabIndex = 10;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(307, 216);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(307, 193);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 19;
            label4.Text = "Category";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(477, 193);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 21;
            label5.Text = "Especiality";
            // 
            // comboBoxSpeciality
            // 
            comboBoxSpeciality.FormattingEnabled = true;
            comboBoxSpeciality.Location = new Point(477, 216);
            comboBoxSpeciality.Name = "comboBoxSpeciality";
            comboBoxSpeciality.Size = new Size(151, 28);
            comboBoxSpeciality.TabIndex = 20;
            // 
            // AddStaff
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(comboBoxSpeciality);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(patient_mobilePhone);
            Controls.Add(label1);
            Controls.Add(patient_Name);
            Name = "AddStaff";
            Text = "AddStaff";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label3;
        private Button button1;
        private Label label2;
        private TextBox patient_mobilePhone;
        private Label label1;
        private TextBox patient_Name;
        private ComboBox comboBox2;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxSpeciality;
    }
}