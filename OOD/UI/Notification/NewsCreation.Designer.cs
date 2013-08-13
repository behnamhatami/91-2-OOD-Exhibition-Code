namespace OOD.UI.Notification
{
    partial class NewsCreation
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
            this.newsCancelButton = new System.Windows.Forms.Button();
            this.newsCreationButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newsRemoveAttachmentButton = new System.Windows.Forms.Button();
            this.newsAddAttachmentButton = new System.Windows.Forms.Button();
            this.newsAttachmentListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.newsImageSelectionButton = new System.Windows.Forms.Button();
            this.newsImageTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.newsContentTextBox = new System.Windows.Forms.TextBox();
            this.newsTitleTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.newsPublicNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.newsPhoneTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.newsPublicNotificationCheckBox);
            this.panel2.Controls.Add(this.newsCancelButton);
            this.panel2.Controls.Add(this.newsCreationButton);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.newsImageSelectionButton);
            this.panel2.Controls.Add(this.newsImageTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.newsContentTextBox);
            this.panel2.Controls.Add(this.newsTitleTextBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(144, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 381);
            this.panel2.TabIndex = 6;
            // 
            // newsCancelButton
            // 
            this.newsCancelButton.Location = new System.Drawing.Point(126, 343);
            this.newsCancelButton.Name = "newsCancelButton";
            this.newsCancelButton.Size = new System.Drawing.Size(71, 24);
            this.newsCancelButton.TabIndex = 9;
            this.newsCancelButton.Text = "انصراف";
            this.newsCancelButton.UseVisualStyleBackColor = true;
            this.newsCancelButton.Click += new System.EventHandler(this.newsCancelButton_Click);
            // 
            // newsCreationButton
            // 
            this.newsCreationButton.Location = new System.Drawing.Point(49, 343);
            this.newsCreationButton.Name = "newsCreationButton";
            this.newsCreationButton.Size = new System.Drawing.Size(71, 24);
            this.newsCreationButton.TabIndex = 8;
            this.newsCreationButton.Text = "ثبت";
            this.newsCreationButton.UseVisualStyleBackColor = true;
            this.newsCreationButton.Click += new System.EventHandler(this.newsCreationButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.newsPhoneTextBox);
            this.groupBox1.Controls.Add(this.newsRemoveAttachmentButton);
            this.groupBox1.Controls.Add(this.newsAddAttachmentButton);
            this.groupBox1.Controls.Add(this.newsAttachmentListBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(49, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 177);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الحاقات";
            // 
            // newsRemoveAttachmentButton
            // 
            this.newsRemoveAttachmentButton.Location = new System.Drawing.Point(77, 147);
            this.newsRemoveAttachmentButton.Name = "newsRemoveAttachmentButton";
            this.newsRemoveAttachmentButton.Size = new System.Drawing.Size(71, 24);
            this.newsRemoveAttachmentButton.TabIndex = 8;
            this.newsRemoveAttachmentButton.Text = "حذف";
            this.newsRemoveAttachmentButton.UseVisualStyleBackColor = true;
            this.newsRemoveAttachmentButton.Click += new System.EventHandler(this.newsRemoveAttachmentButton_Click);
            // 
            // newsAddAttachmentButton
            // 
            this.newsAddAttachmentButton.Location = new System.Drawing.Point(6, 147);
            this.newsAddAttachmentButton.Name = "newsAddAttachmentButton";
            this.newsAddAttachmentButton.Size = new System.Drawing.Size(71, 24);
            this.newsAddAttachmentButton.TabIndex = 7;
            this.newsAddAttachmentButton.Text = "اضافه";
            this.newsAddAttachmentButton.UseVisualStyleBackColor = true;
            this.newsAddAttachmentButton.Click += new System.EventHandler(this.newsAddAttachmentButton_Click);
            // 
            // newsAttachmentListBox
            // 
            this.newsAttachmentListBox.FormattingEnabled = true;
            this.newsAttachmentListBox.ItemHeight = 14;
            this.newsAttachmentListBox.Location = new System.Drawing.Point(6, 21);
            this.newsAttachmentListBox.Name = "newsAttachmentListBox";
            this.newsAttachmentListBox.Size = new System.Drawing.Size(284, 88);
            this.newsAttachmentListBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "لیست الحاقات:";
            // 
            // newsImageSelectionButton
            // 
            this.newsImageSelectionButton.Location = new System.Drawing.Point(49, 121);
            this.newsImageSelectionButton.Name = "newsImageSelectionButton";
            this.newsImageSelectionButton.Size = new System.Drawing.Size(71, 24);
            this.newsImageSelectionButton.TabIndex = 6;
            this.newsImageSelectionButton.Text = "انتخاب";
            this.newsImageSelectionButton.UseVisualStyleBackColor = true;
            this.newsImageSelectionButton.Click += new System.EventHandler(this.newsImageSelectionButton_Click);
            // 
            // newsImageTextBox
            // 
            this.newsImageTextBox.Location = new System.Drawing.Point(49, 93);
            this.newsImageTextBox.Name = "newsImageTextBox";
            this.newsImageTextBox.Size = new System.Drawing.Size(236, 22);
            this.newsImageTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "آدرس عکس:";
            // 
            // newsContentTextBox
            // 
            this.newsContentTextBox.Location = new System.Drawing.Point(49, 39);
            this.newsContentTextBox.Multiline = true;
            this.newsContentTextBox.Name = "newsContentTextBox";
            this.newsContentTextBox.Size = new System.Drawing.Size(236, 48);
            this.newsContentTextBox.TabIndex = 3;
            // 
            // newsTitleTextBox
            // 
            this.newsTitleTextBox.Location = new System.Drawing.Point(49, 10);
            this.newsTitleTextBox.Name = "newsTitleTextBox";
            this.newsTitleTextBox.Size = new System.Drawing.Size(236, 22);
            this.newsTitleTextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "متن خبر:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "تیتر خبر:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // newsPublicNotificationCheckBox
            // 
            this.newsPublicNotificationCheckBox.AutoSize = true;
            this.newsPublicNotificationCheckBox.Location = new System.Drawing.Point(187, 136);
            this.newsPublicNotificationCheckBox.Name = "newsPublicNotificationCheckBox";
            this.newsPublicNotificationCheckBox.Size = new System.Drawing.Size(98, 18);
            this.newsPublicNotificationCheckBox.TabIndex = 10;
            this.newsPublicNotificationCheckBox.Text = "ارسال عمومی";
            this.newsPublicNotificationCheckBox.UseVisualStyleBackColor = true;
            this.newsPublicNotificationCheckBox.CheckedChanged += new System.EventHandler(this.newsPublicNotificationCheckBox_CheckedChanged);
            // 
            // newsPhoneTextBox
            // 
            this.newsPhoneTextBox.Location = new System.Drawing.Point(6, 115);
            this.newsPhoneTextBox.Name = "newsPhoneTextBox";
            this.newsPhoneTextBox.Size = new System.Drawing.Size(284, 22);
            this.newsPhoneTextBox.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "شماره تلفن جدید:";
            // 
            // NewsCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.panel2);
            this.Name = "NewsCreation";
            this.Text = "NewsCreation";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newsContentTextBox;
        private System.Windows.Forms.TextBox newsTitleTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button newsImageSelectionButton;
        private System.Windows.Forms.TextBox newsImageTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox newsAttachmentListBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button newsRemoveAttachmentButton;
        private System.Windows.Forms.Button newsAddAttachmentButton;
        private System.Windows.Forms.Button newsCancelButton;
        private System.Windows.Forms.Button newsCreationButton;
        private System.Windows.Forms.CheckBox newsPublicNotificationCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox newsPhoneTextBox;

    }
}