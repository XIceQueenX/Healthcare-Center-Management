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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            button1 = new Button();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            grid = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(214, 234, 248);
            button1.FlatAppearance.BorderColor = Color.FromArgb(130, 236, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(26, 467);
            button1.Name = "button1";
            button1.Size = new Size(174, 45);
            button1.TabIndex = 1;
            button1.Text = "PATIENTS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 67);
            label1.Name = "label1";
            label1.Size = new Size(0, 26);
            label1.TabIndex = 2;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(214, 234, 248);
            button3.FlatAppearance.BorderColor = Color.FromArgb(130, 236, 255);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(206, 467);
            button3.Name = "button3";
            button3.Size = new Size(174, 45);
            button3.TabIndex = 6;
            button3.Text = "APPOINTMENTS";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(214, 234, 248);
            button4.FlatAppearance.BorderColor = Color.FromArgb(130, 236, 255);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(743, 12);
            button4.Name = "button4";
            button4.Size = new Size(61, 45);
            button4.TabIndex = 7;
            button4.Text = "x";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.BackgroundColor = Color.FromArgb(232, 240, 242);
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(232, 240, 242);
            dataGridViewCellStyle1.Font = new Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            grid.DefaultCellStyle = dataGridViewCellStyle1;
            grid.GridColor = Color.FromArgb(232, 240, 242);
            grid.Location = new Point(26, 116);
            grid.Name = "grid";
            grid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Transparent;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.ScrollBars = ScrollBars.Vertical;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(690, 333);
            grid.TabIndex = 8;
            grid.CellClick += onClickGridCell;
            grid.CellContentClick += grid_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 67);
            label2.Name = "label2";
            label2.Size = new Size(333, 41);
            label2.TabIndex = 9;
            label2.Text = "Appointements of day";
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 240, 242);
            ClientSize = new Size(816, 544);
            Controls.Add(label2);
            Controls.Add(grid);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Clients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clients";
            Load += Clients_Load;
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label label1;
        private Button button3;
        private Button button4;
        private DataGridView grid;
        private Label label2;
    }
}
