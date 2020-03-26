﻿namespace RetroFun.Pages
{
    partial class MakeSayPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BubblesCmbx1 = new RetroFun.Controls.ImageComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioWhisper = new System.Windows.Forms.RadioButton();
            this.RadioShout = new System.Windows.Forms.RadioButton();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.MakeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectUserLabel = new System.Windows.Forms.Label();
            this.MakeSayButton = new Sulakore.Components.SKoreButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TotUserRegistered = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BubblesCmbx1
            // 
            this.BubblesCmbx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BubblesCmbx1.DropDownHeight = 200;
            this.BubblesCmbx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BubblesCmbx1.FormattingEnabled = true;
            this.BubblesCmbx1.IntegralHeight = false;
            this.BubblesCmbx1.ItemHeight = 25;
            this.BubblesCmbx1.Location = new System.Drawing.Point(14, 32);
            this.BubblesCmbx1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BubblesCmbx1.Name = "BubblesCmbx1";
            this.BubblesCmbx1.Size = new System.Drawing.Size(156, 31);
            this.BubblesCmbx1.TabIndex = 0;
            this.BubblesCmbx1.SelectedIndexChanged += new System.EventHandler(this.BubblesCmbx_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioWhisper);
            this.groupBox1.Controls.Add(this.RadioShout);
            this.groupBox1.Controls.Add(this.radioNormal);
            this.groupBox1.Location = new System.Drawing.Point(4, 115);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(200, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speech Type";
            // 
            // RadioWhisper
            // 
            this.RadioWhisper.AutoSize = true;
            this.RadioWhisper.Location = new System.Drawing.Point(9, 109);
            this.RadioWhisper.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioWhisper.Name = "RadioWhisper";
            this.RadioWhisper.Size = new System.Drawing.Size(85, 24);
            this.RadioWhisper.TabIndex = 2;
            this.RadioWhisper.Text = "Whisper";
            this.RadioWhisper.UseVisualStyleBackColor = true;
            // 
            // RadioShout
            // 
            this.RadioShout.AutoSize = true;
            this.RadioShout.Location = new System.Drawing.Point(9, 74);
            this.RadioShout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioShout.Name = "RadioShout";
            this.RadioShout.Size = new System.Drawing.Size(70, 24);
            this.RadioShout.TabIndex = 1;
            this.RadioShout.Text = "Shout";
            this.RadioShout.UseVisualStyleBackColor = true;
            // 
            // radioNormal
            // 
            this.radioNormal.AutoSize = true;
            this.radioNormal.Checked = true;
            this.radioNormal.Location = new System.Drawing.Point(9, 38);
            this.radioNormal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(77, 24);
            this.radioNormal.TabIndex = 0;
            this.radioNormal.TabStop = true;
            this.radioNormal.Text = "Normal";
            this.radioNormal.UseVisualStyleBackColor = true;
            // 
            // MakeTextBox
            // 
            this.MakeTextBox.Location = new System.Drawing.Point(14, 309);
            this.MakeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MakeTextBox.Name = "MakeTextBox";
            this.MakeTextBox.Size = new System.Drawing.Size(622, 26);
            this.MakeTextBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectUserLabel);
            this.groupBox2.Location = new System.Drawing.Point(239, 146);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(368, 92);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected User";
            // 
            // SelectUserLabel
            // 
            this.SelectUserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectUserLabel.AutoSize = true;
            this.SelectUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.SelectUserLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectUserLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.SelectUserLabel.Location = new System.Drawing.Point(44, 38);
            this.SelectUserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectUserLabel.Name = "SelectUserLabel";
            this.SelectUserLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SelectUserLabel.Size = new System.Drawing.Size(20, 23);
            this.SelectUserLabel.TabIndex = 0;
            this.SelectUserLabel.Text = "?";
            this.SelectUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MakeSayButton
            // 
            this.MakeSayButton.Location = new System.Drawing.Point(14, 349);
            this.MakeSayButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MakeSayButton.Name = "MakeSayButton";
            this.MakeSayButton.Size = new System.Drawing.Size(624, 31);
            this.MakeSayButton.TabIndex = 5;
            this.MakeSayButton.Text = "Talk as selected user";
            this.MakeSayButton.Click += new System.EventHandler(this.MakeSayButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TotUserRegistered);
            this.groupBox3.Location = new System.Drawing.Point(239, 32);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(153, 105);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logged Users.";
            // 
            // TotUserRegistered
            // 
            this.TotUserRegistered.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotUserRegistered.AutoSize = true;
            this.TotUserRegistered.BackColor = System.Drawing.Color.Transparent;
            this.TotUserRegistered.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotUserRegistered.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TotUserRegistered.Location = new System.Drawing.Point(58, 38);
            this.TotUserRegistered.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotUserRegistered.Name = "TotUserRegistered";
            this.TotUserRegistered.Size = new System.Drawing.Size(20, 23);
            this.TotUserRegistered.TabIndex = 0;
            this.TotUserRegistered.Text = "?";
            this.TotUserRegistered.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MakeSayPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MakeSayButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MakeTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BubblesCmbx1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MakeSayPage";
            this.Size = new System.Drawing.Size(698, 405);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ImageComboBox BubblesCmbx1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadioWhisper;
        private System.Windows.Forms.RadioButton RadioShout;
        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.TextBox MakeTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private Sulakore.Components.SKoreButton MakeSayButton;
        private System.Windows.Forms.Label SelectUserLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label TotUserRegistered;
    }
}
