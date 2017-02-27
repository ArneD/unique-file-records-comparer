﻿namespace UniqueFileRecordsComparer.App
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
            this.SourceFileTabsDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TargetFileTabsDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target:";
            // 
            // SourceFilePathLabel
            // 
            this.SourceFilePathLabel.AutoSize = true;
            this.SourceFilePathLabel.Location = new System.Drawing.Point(24, 63);
            this.SourceFilePathLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SourceFilePathLabel.Name = "SourceFilePathLabel";
            this.SourceFilePathLabel.Size = new System.Drawing.Size(0, 25);
            this.SourceFilePathLabel.TabIndex = 2;
            // 
            // TargetFilePathLabel
            // 
            this.TargetFilePathLabel.AutoSize = true;
            this.TargetFilePathLabel.Location = new System.Drawing.Point(24, 194);
            this.TargetFilePathLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TargetFilePathLabel.Name = "TargetFilePathLabel";
            this.TargetFilePathLabel.Size = new System.Drawing.Size(0, 25);
            this.TargetFilePathLabel.TabIndex = 3;
            // 
            // ChooseSourceFileButton
            // 
            this.ChooseSourceFileButton.Location = new System.Drawing.Point(816, 8);
            this.ChooseSourceFileButton.Margin = new System.Windows.Forms.Padding(6);
            this.ChooseSourceFileButton.Name = "ChooseSourceFileButton";
            this.ChooseSourceFileButton.Size = new System.Drawing.Size(206, 44);
            this.ChooseSourceFileButton.TabIndex = 4;
            this.ChooseSourceFileButton.Text = "Choose source";
            this.ChooseSourceFileButton.UseVisualStyleBackColor = true;
            this.ChooseSourceFileButton.Click += new System.EventHandler(this.ChooseSourceFileButton_Click);
            // 
            // ChooseTargetFileButton
            // 
            this.ChooseTargetFileButton.Location = new System.Drawing.Point(816, 151);
            this.ChooseTargetFileButton.Margin = new System.Windows.Forms.Padding(6);
            this.ChooseTargetFileButton.Name = "ChooseTargetFileButton";
            this.ChooseTargetFileButton.Size = new System.Drawing.Size(206, 44);
            this.ChooseTargetFileButton.TabIndex = 5;
            this.ChooseTargetFileButton.Text = "Choose target";
            this.ChooseTargetFileButton.UseVisualStyleBackColor = true;
            this.ChooseTargetFileButton.Click += new System.EventHandler(this.ChooseTargetFileButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(816, 322);
            this.NextButton.Margin = new System.Windows.Forms.Padding(6);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(206, 44);
            this.NextButton.TabIndex = 6;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // SourceFileTabsDropDown
            // 
            this.SourceFileTabsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceFileTabsDropDown.Enabled = false;
            this.SourceFileTabsDropDown.FormattingEnabled = true;
            this.SourceFileTabsDropDown.Location = new System.Drawing.Point(151, 88);
            this.SourceFileTabsDropDown.Name = "SourceFileTabsDropDown";
            this.SourceFileTabsDropDown.Size = new System.Drawing.Size(245, 33);
            this.SourceFileTabsDropDown.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select tab:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 238);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select tab:";
            // 
            // TargetFileTabsDropDown
            // 
            this.TargetFileTabsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetFileTabsDropDown.Enabled = false;
            this.TargetFileTabsDropDown.FormattingEnabled = true;
            this.TargetFileTabsDropDown.Location = new System.Drawing.Point(151, 235);
            this.TargetFileTabsDropDown.Name = "TargetFileTabsDropDown";
            this.TargetFileTabsDropDown.Size = new System.Drawing.Size(245, 33);
            this.TargetFileTabsDropDown.TabIndex = 9;
            // 
            // SelectFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 411);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TargetFileTabsDropDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SourceFileTabsDropDown);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.ChooseTargetFileButton);
            this.Controls.Add(this.ChooseSourceFileButton);
            this.Controls.Add(this.TargetFilePathLabel);
            this.Controls.Add(this.SourceFilePathLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
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
        private System.Windows.Forms.ComboBox SourceFileTabsDropDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TargetFileTabsDropDown;
    }
}

