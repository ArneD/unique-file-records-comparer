namespace UniqueFileRecordsComparer.App
{
    partial class SelectColumnsForm
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
            this.SourceColumnsCheckList = new System.Windows.Forms.CheckedListBox();
            this.TargetColumnsCheckList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Compare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SourceColumnsCheckList
            // 
            this.SourceColumnsCheckList.FormattingEnabled = true;
            this.SourceColumnsCheckList.Location = new System.Drawing.Point(34, 31);
            this.SourceColumnsCheckList.Name = "SourceColumnsCheckList";
            this.SourceColumnsCheckList.Size = new System.Drawing.Size(211, 274);
            this.SourceColumnsCheckList.TabIndex = 0;
            // 
            // TargetColumnsCheckList
            // 
            this.TargetColumnsCheckList.FormattingEnabled = true;
            this.TargetColumnsCheckList.Location = new System.Drawing.Point(379, 31);
            this.TargetColumnsCheckList.Name = "TargetColumnsCheckList";
            this.TargetColumnsCheckList.Size = new System.Drawing.Size(211, 274);
            this.TargetColumnsCheckList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target columns";
            // 
            // Compare
            // 
            this.Compare.Location = new System.Drawing.Point(515, 315);
            this.Compare.Name = "Compare";
            this.Compare.Size = new System.Drawing.Size(75, 23);
            this.Compare.TabIndex = 4;
            this.Compare.Text = "Compare";
            this.Compare.UseVisualStyleBackColor = true;
            this.Compare.Click += new System.EventHandler(this.Compare_Click);
            // 
            // SelectColumnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 350);
            this.Controls.Add(this.Compare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TargetColumnsCheckList);
            this.Controls.Add(this.SourceColumnsCheckList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SelectColumnsForm";
            this.Text = "Select columns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox SourceColumnsCheckList;
        private System.Windows.Forms.CheckedListBox TargetColumnsCheckList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Compare;
    }
}