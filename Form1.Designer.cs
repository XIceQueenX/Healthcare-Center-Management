namespace Gestao_Centro_Saude
{
    partial class Clients
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addPersonName = new TextBox();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            grid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // addPersonName
            // 
            addPersonName.Location = new Point(82, 51);
            addPersonName.Multiline = true;
            addPersonName.Name = "addPersonName";
            addPersonName.Size = new Size(125, 34);
            addPersonName.TabIndex = 0;
            addPersonName.Text = "Name";
            // 
            // button1
            // 
            button1.Location = new Point(391, 141);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(417, 173);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(82, 91);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 34);
            textBox1.TabIndex = 3;
            textBox1.Text = "mobile phoen";
            // 
            // grid
            // 
            grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(96, 281);
            grid.Name = "grid";
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(773, 252);
            grid.TabIndex = 4;
            grid.CellContentClick += onClickGridCell;
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 673);
            Controls.Add(grid);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(addPersonName);
            Name = "Clients";
            Text = "Clients";
            Load += Clients_Load;
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox addPersonName;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private DataGridView grid;
    }
}
