namespace Gestao_Centro_Saude
{
    partial class AddNewUser
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
            patient_Name = new TextBox();
            label1 = new Label();
            label2 = new Label();
            patient_mobilePhone = new TextBox();
            button1 = new Button();
            label3 = new Label();
            error = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // patient_Name
            // 
            patient_Name.Location = new Point(23, 45);
            patient_Name.Name = "patient_Name";
            patient_Name.Size = new Size(125, 27);
            patient_Name.TabIndex = 0;
            patient_Name.TextChanged += patient_Name_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 22);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(178, 22);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 3;
            label2.Text = "Numero";
            // 
            // patient_mobilePhone
            // 
            patient_mobilePhone.Location = new Point(178, 45);
            patient_mobilePhone.Name = "patient_mobilePhone";
            patient_mobilePhone.Size = new Size(125, 27);
            patient_mobilePhone.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(107, 166);
            button1.Name = "button1";
            button1.Size = new Size(128, 29);
            button1.TabIndex = 6;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 97);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 7;
            label3.Text = "Gender";
            // 
            // error
            // 
            error.AutoSize = true;
            error.Location = new Point(148, 198);
            error.Name = "error";
            error.Size = new Size(50, 20);
            error.TabIndex = 8;
            error.Text = "Nome";
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "Male";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "M", "F" });
            comboBox1.Location = new Point(23, 120);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 9;
            comboBox1.ValueMember = "Male";
            // 
            // AddNewUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 281);
            Controls.Add(comboBox1);
            Controls.Add(error);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(patient_mobilePhone);
            Controls.Add(label1);
            Controls.Add(patient_Name);
            Name = "AddNewUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddNewUser";
            Load += AddNewUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox patient_Name;
        private Label label1;
        private Label label2;
        private TextBox patient_mobilePhone;
        private Button button1;
        private Label label3;
        private Label error;
        private ComboBox comboBox1;
    }
}