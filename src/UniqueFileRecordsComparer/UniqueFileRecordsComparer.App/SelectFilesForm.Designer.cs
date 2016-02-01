namespace UniqueFileRecordsComparer.App
{
    partial class SelectFilesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SourceFilePathLabel = new System.Windows.Forms.Label();
            this.TargetFilePathLabel = new System.Windows.Forms.Label();
            this.ChooseSourceFileButton = new System.Windows.Forms.Button();
            this.ChooseTargetFileButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target:";
            // 
            // SourceFilePathLabel
            // 
            this.SourceFilePathLabel.AutoSize = true;
            this.SourceFilePathLabel.Location = new System.Drawing.Point(12, 33);
            this.SourceFilePathLabel.Name = "SourceFilePathLabel";
            this.SourceFilePathLabel.Size = new System.Drawing.Size(0, 13);
            this.SourceFilePathLabel.TabIndex = 2;
            // 
            // TargetFilePathLabel
            // 
            this.TargetFilePathLabel.AutoSize = true;
            this.TargetFilePathLabel.Location = new System.Drawing.Point(12, 104);
            this.TargetFilePathLabel.Name = "TargetFilePathLabel";
            this.TargetFilePathLabel.Size = new System.Drawing.Size(0, 13);
            this.TargetFilePathLabel.TabIndex = 3;
            // 
            // ChooseSourceFileButton
            // 
            this.ChooseSourceFileButton.Location = new System.Drawing.Point(408, 4);
            this.ChooseSourceFileButton.Name = "ChooseSourceFileButton";
            this.ChooseSourceFileButton.Size = new System.Drawing.Size(103, 23);
            this.ChooseSourceFileButton.TabIndex = 4;
            this.ChooseSourceFileButton.Text = "Choose source";
            this.ChooseSourceFileButton.UseVisualStyleBackColor = true;
            this.ChooseSourceFileButton.Click += new System.EventHandler(this.ChooseSourceFileButton_Click);
            // 
            // ChooseTargetFileButton
            // 
            this.ChooseTargetFileButton.Location = new System.Drawing.Point(408, 66);
            this.ChooseTargetFileButton.Name = "ChooseTargetFileButton";
            this.ChooseTargetFileButton.Size = new System.Drawing.Size(103, 23);
            this.ChooseTargetFileButton.TabIndex = 5;
            this.ChooseTargetFileButton.Text = "Choose target";
            this.ChooseTargetFileButton.UseVisualStyleBackColor = true;
            this.ChooseTargetFileButton.Click += new System.EventHandler(this.ChooseTargetFileButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(408, 202);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(103, 23);
            this.NextButton.TabIndex = 6;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // SelectFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 237);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.ChooseTargetFileButton);
            this.Controls.Add(this.ChooseSourceFileButton);
            this.Controls.Add(this.TargetFilePathLabel);
            this.Controls.Add(this.SourceFilePathLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SelectFilesForm";
            this.Text = "Select files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SourceFilePathLabel;
        private System.Windows.Forms.Label TargetFilePathLabel;
        private System.Windows.Forms.Button ChooseSourceFileButton;
        private System.Windows.Forms.Button ChooseTargetFileButton;
        private System.Windows.Forms.Button NextButton;
    }
}

