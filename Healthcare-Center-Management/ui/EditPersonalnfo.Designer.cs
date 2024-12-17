namespace Gestao_Centro_Saude.ui
{
    partial class EditPersonalnfo
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
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "Male";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "M", "F" });
            comboBox1.Location = new Point(12, 120);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 17;
            comboBox1.ValueMember = "Male";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 15;
            label3.Text = "Gender";
            // 
            // button1
            // 
            button1.Location = new Point(96, 166);
            button1.Name = "button1";
            button1.Size = new Size(128, 29);
            button1.TabIndex = 14;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 22);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 13;
            label2.Text = "Numero";
            // 
            // patient_mobilePhone
            // 
            patient_mobilePhone.Location = new Point(167, 45);
            patient_mobilePhone.Name = "patient_mobilePhone";
            patient_mobilePhone.Size = new Size(125, 27);
            patient_mobilePhone.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 11;
            label1.Text = "Nome";
            // 
            // patient_Name
            // 
            patient_Name.Location = new Point(12, 45);
            patient_Name.Name = "patient_Name";
            patient_Name.Size = new Size(125, 27);
            patient_Name.TabIndex = 10;
            // 
            // EditPersonalnfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(patient_mobilePhone);
            Controls.Add(label1);
            Controls.Add(patient_Name);
            Name = "EditPersonalnfo";
            Text = "EditPersonalnfo";
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
    }
}