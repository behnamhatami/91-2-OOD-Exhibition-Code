namespace OOD.UI.NotificationPackage
{
    partial class VisitorReportCreation
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.visitorReportCancelButton = new System.Windows.Forms.Button();
            this.visitorReportOkeyButton = new System.Windows.Forms.Button();
            this.visitorReportContentTextBox = new System.Windows.Forms.TextBox();
            this.visitorReportBoothsComboBox = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.visitorReportBoothsComboBox);
            this.panel2.Controls.Add(this.visitorReportContentTextBox);
            this.panel2.Controls.Add(this.visitorReportCancelButton);
            this.panel2.Controls.Add(this.visitorReportOkeyButton);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(144, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 379);
            this.panel2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "غرفه:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "متن گزارش:";
            // 
            // visitorReportCancelButton
            // 
            this.visitorReportCancelButton.Location = new System.Drawing.Point(104, 122);
            this.visitorReportCancelButton.Name = "visitorReportCancelButton";
            this.visitorReportCancelButton.Size = new System.Drawing.Size(71, 24);
            this.visitorReportCancelButton.TabIndex = 9;
            this.visitorReportCancelButton.Text = "انصراف";
            this.visitorReportCancelButton.UseVisualStyleBackColor = true;
            this.visitorReportCancelButton.Click += new System.EventHandler(this.visitorReportCancelButton_Click);
            // 
            // visitorReportOkeyButton
            // 
            this.visitorReportOkeyButton.Location = new System.Drawing.Point(27, 122);
            this.visitorReportOkeyButton.Name = "visitorReportOkeyButton";
            this.visitorReportOkeyButton.Size = new System.Drawing.Size(71, 24);
            this.visitorReportOkeyButton.TabIndex = 8;
            this.visitorReportOkeyButton.Text = "ثبت";
            this.visitorReportOkeyButton.UseVisualStyleBackColor = true;
            this.visitorReportOkeyButton.Click += new System.EventHandler(this.visitorReportOkeyButton_Click);
            // 
            // visitorReportContentTextBox
            // 
            this.visitorReportContentTextBox.Location = new System.Drawing.Point(27, 19);
            this.visitorReportContentTextBox.Multiline = true;
            this.visitorReportContentTextBox.Name = "visitorReportContentTextBox";
            this.visitorReportContentTextBox.Size = new System.Drawing.Size(356, 67);
            this.visitorReportContentTextBox.TabIndex = 10;
            // 
            // visitorReportBoothsComboBox
            // 
            this.visitorReportBoothsComboBox.FormattingEnabled = true;
            this.visitorReportBoothsComboBox.Location = new System.Drawing.Point(27, 92);
            this.visitorReportBoothsComboBox.Name = "visitorReportBoothsComboBox";
            this.visitorReportBoothsComboBox.Size = new System.Drawing.Size(356, 22);
            this.visitorReportBoothsComboBox.TabIndex = 11;
            // 
            // VisitorReportCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.panel2);
            this.Name = "VisitorReportCreation";
            this.Text = "VisitorReportCreation";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button visitorReportCancelButton;
        private System.Windows.Forms.Button visitorReportOkeyButton;
        private System.Windows.Forms.TextBox visitorReportContentTextBox;
        private System.Windows.Forms.ComboBox visitorReportBoothsComboBox;

    }
}