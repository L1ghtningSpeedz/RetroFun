﻿namespace RetroFun.Pages
{
    partial class FurniHandlerEventPage
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
            this.FreezeMovementCheck = new System.Windows.Forms.CheckBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FreezeMovementCheck
            // 
            this.FreezeMovementCheck.AutoSize = true;
            this.FreezeMovementCheck.Location = new System.Drawing.Point(13, 5);
            this.FreezeMovementCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FreezeMovementCheck.Name = "FreezeMovementCheck";
            this.FreezeMovementCheck.Size = new System.Drawing.Size(209, 24);
            this.FreezeMovementCheck.TabIndex = 2;
            this.FreezeMovementCheck.Text = "Freeze User Movements";
            this.FreezeMovementCheck.UseVisualStyleBackColor = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(403, 3);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.ReadOnly = true;
            this.UsernameTextBox.Size = new System.Drawing.Size(463, 26);
            this.UsernameTextBox.TabIndex = 10;
            this.UsernameTextBox.Text = "Finding Username...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Your Username: ";
            // 
            // BottomPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.FreezeMovementCheck);
            this.Name = "BottomPage";
            this.Size = new System.Drawing.Size(894, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox FreezeMovementCheck;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label label1;
    }
}