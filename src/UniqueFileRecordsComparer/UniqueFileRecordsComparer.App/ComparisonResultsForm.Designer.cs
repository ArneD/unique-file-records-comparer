namespace UniqueFileRecordsComparer.App
{
    partial class ComparisonResultsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExportNewRowsButton = new System.Windows.Forms.Button();
            this.ExportDeletedRowsButton = new System.Windows.Forms.Button();
            this.NewRowsGrid = new System.Windows.Forms.DataGridView();
            this.DeletedRowsGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewRowsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletedRowsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NewRowsGrid);
            this.groupBox1.Controls.Add(this.ExportNewRowsButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1082, 327);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New rows (rows found in target but not in source)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeletedRowsGrid);
            this.groupBox2.Controls.Add(this.ExportDeletedRowsButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1082, 327);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deleted rows (rows found in source but not in target)";
            // 
            // ExportNewRowsButton
            // 
            this.ExportNewRowsButton.Location = new System.Drawing.Point(971, 298);
            this.ExportNewRowsButton.Name = "ExportNewRowsButton";
            this.ExportNewRowsButton.Size = new System.Drawing.Size(105, 23);
            this.ExportNewRowsButton.TabIndex = 4;
            this.ExportNewRowsButton.Text = "Export to csv";
            this.ExportNewRowsButton.UseVisualStyleBackColor = true;
            // 
            // ExportDeletedRowsButton
            // 
            this.ExportDeletedRowsButton.Location = new System.Drawing.Point(971, 298);
            this.ExportDeletedRowsButton.Name = "ExportDeletedRowsButton";
            this.ExportDeletedRowsButton.Size = new System.Drawing.Size(105, 23);
            this.ExportDeletedRowsButton.TabIndex = 5;
            this.ExportDeletedRowsButton.Text = "Export to csv";
            this.ExportDeletedRowsButton.UseVisualStyleBackColor = true;
            // 
            // NewRowsGrid
            // 
            this.NewRowsGrid.AllowUserToAddRows = false;
            this.NewRowsGrid.AllowUserToDeleteRows = false;
            this.NewRowsGrid.AllowUserToOrderColumns = true;
            this.NewRowsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewRowsGrid.Location = new System.Drawing.Point(6, 19);
            this.NewRowsGrid.Name = "NewRowsGrid";
            this.NewRowsGrid.ReadOnly = true;
            this.NewRowsGrid.Size = new System.Drawing.Size(1070, 273);
            this.NewRowsGrid.TabIndex = 5;
            // 
            // DeletedRowsGrid
            // 
            this.DeletedRowsGrid.AllowUserToAddRows = false;
            this.DeletedRowsGrid.AllowUserToDeleteRows = false;
            this.DeletedRowsGrid.AllowUserToOrderColumns = true;
            this.DeletedRowsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeletedRowsGrid.Location = new System.Drawing.Point(6, 19);
            this.DeletedRowsGrid.Name = "DeletedRowsGrid";
            this.DeletedRowsGrid.ReadOnly = true;
            this.DeletedRowsGrid.Size = new System.Drawing.Size(1070, 273);
            this.DeletedRowsGrid.TabIndex = 6;
            // 
            // ComparisonResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 690);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ComparisonResultsForm";
            this.Text = "Results";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NewRowsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeletedRowsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ExportNewRowsButton;
        private System.Windows.Forms.Button ExportDeletedRowsButton;
        private System.Windows.Forms.DataGridView NewRowsGrid;
        private System.Windows.Forms.DataGridView DeletedRowsGrid;
    }
}