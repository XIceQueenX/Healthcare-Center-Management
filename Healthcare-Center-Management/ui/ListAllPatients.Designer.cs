namespace Gestao_Centro_Saude.ui
{
    partial class ListAllPatients
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
            grid = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // grid
            // 
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(12, 99);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(776, 339);
            grid.TabIndex = 0;
            grid.CellContentClick += onClickGridCell;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Location = new Point(617, 26);
            button1.Name = "button1";
            button1.Size = new Size(171, 55);
            button1.TabIndex = 1;
            button1.Text = "New Patient";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 55);
            label1.Name = "label1";
            label1.Size = new Size(190, 41);
            label1.TabIndex = 2;
            label1.Text = "List Pacients";
            // 
            // ListAllPatients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(grid);
            Name = "ListAllPatients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListAllUsers";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grid;
        private Button button1;
        private Label label1;
    }
}