namespace OOD.UI.Notification
{
    partial class NotificationInbox
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.exhibitionNotificationPage = new System.Windows.Forms.TabPage();
            this.showButton1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.exhibitionNotificationListBox = new System.Windows.Forms.ListBox();
            this.exhibitionNotificationCreationDateTextBox = new System.Windows.Forms.TextBox();
            this.exhibitionNotificationContentTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.exhibitionNotificationTitleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userNotificationPage = new System.Windows.Forms.TabPage();
            this.showButton2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.userNotificationListBox = new System.Windows.Forms.ListBox();
            this.userNotificationCreationDateTextBox = new System.Windows.Forms.TextBox();
            this.userNotificationContentTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.userNotificationTitleTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.exhibitionNotificationPage.SuspendLayout();
            this.userNotificationPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(144, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 381);
            this.panel2.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.exhibitionNotificationPage);
            this.tabControl1.Controls.Add(this.userNotificationPage);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 375);
            this.tabControl1.TabIndex = 0;
            // 
            // exhibitionNotificationPage
            // 
            this.exhibitionNotificationPage.Controls.Add(this.showButton1);
            this.exhibitionNotificationPage.Controls.Add(this.label7);
            this.exhibitionNotificationPage.Controls.Add(this.exhibitionNotificationListBox);
            this.exhibitionNotificationPage.Controls.Add(this.exhibitionNotificationCreationDateTextBox);
            this.exhibitionNotificationPage.Controls.Add(this.exhibitionNotificationContentTextBox);
            this.exhibitionNotificationPage.Controls.Add(this.label6);
            this.exhibitionNotificationPage.Controls.Add(this.label5);
            this.exhibitionNotificationPage.Controls.Add(this.exhibitionNotificationTitleTextBox);
            this.exhibitionNotificationPage.Controls.Add(this.label4);
            this.exhibitionNotificationPage.Location = new System.Drawing.Point(4, 23);
            this.exhibitionNotificationPage.Name = "exhibitionNotificationPage";
            this.exhibitionNotificationPage.Padding = new System.Windows.Forms.Padding(3);
            this.exhibitionNotificationPage.Size = new System.Drawing.Size(474, 348);
            this.exhibitionNotificationPage.TabIndex = 0;
            this.exhibitionNotificationPage.Text = "رخدادهای عمومی نمایشگاه";
            this.exhibitionNotificationPage.UseVisualStyleBackColor = true;
            // 
            // showButton1
            // 
            this.showButton1.Location = new System.Drawing.Point(10, 109);
            this.showButton1.Name = "showButton1";
            this.showButton1.Size = new System.Drawing.Size(71, 24);
            this.showButton1.TabIndex = 9;
            this.showButton1.Text = "نمایش";
            this.showButton1.UseVisualStyleBackColor = true;
            this.showButton1.Click += new System.EventHandler(this.showButton1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "لیست رخدادها: ";
            // 
            // exhibitionNotificationListBox
            // 
            this.exhibitionNotificationListBox.FormattingEnabled = true;
            this.exhibitionNotificationListBox.ItemHeight = 14;
            this.exhibitionNotificationListBox.Location = new System.Drawing.Point(10, 15);
            this.exhibitionNotificationListBox.Name = "exhibitionNotificationListBox";
            this.exhibitionNotificationListBox.Size = new System.Drawing.Size(328, 88);
            this.exhibitionNotificationListBox.TabIndex = 7;
            // 
            // exhibitionNotificationCreationDateTextBox
            // 
            this.exhibitionNotificationCreationDateTextBox.Location = new System.Drawing.Point(138, 173);
            this.exhibitionNotificationCreationDateTextBox.Name = "exhibitionNotificationCreationDateTextBox";
            this.exhibitionNotificationCreationDateTextBox.ReadOnly = true;
            this.exhibitionNotificationCreationDateTextBox.Size = new System.Drawing.Size(200, 22);
            this.exhibitionNotificationCreationDateTextBox.TabIndex = 6;
            // 
            // exhibitionNotificationContentTextBox
            // 
            this.exhibitionNotificationContentTextBox.Location = new System.Drawing.Point(10, 209);
            this.exhibitionNotificationContentTextBox.Multiline = true;
            this.exhibitionNotificationContentTextBox.Name = "exhibitionNotificationContentTextBox";
            this.exhibitionNotificationContentTextBox.ReadOnly = true;
            this.exhibitionNotificationContentTextBox.Size = new System.Drawing.Size(328, 125);
            this.exhibitionNotificationContentTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "متن رخداد:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "تاریخ رخداد:";
            // 
            // exhibitionNotificationTitleTextBox
            // 
            this.exhibitionNotificationTitleTextBox.Location = new System.Drawing.Point(138, 143);
            this.exhibitionNotificationTitleTextBox.Name = "exhibitionNotificationTitleTextBox";
            this.exhibitionNotificationTitleTextBox.ReadOnly = true;
            this.exhibitionNotificationTitleTextBox.Size = new System.Drawing.Size(200, 22);
            this.exhibitionNotificationTitleTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "تیتر رخداد:";
            // 
            // userNotificationPage
            // 
            this.userNotificationPage.Controls.Add(this.showButton2);
            this.userNotificationPage.Controls.Add(this.label8);
            this.userNotificationPage.Controls.Add(this.userNotificationListBox);
            this.userNotificationPage.Controls.Add(this.userNotificationCreationDateTextBox);
            this.userNotificationPage.Controls.Add(this.userNotificationContentTextBox);
            this.userNotificationPage.Controls.Add(this.label9);
            this.userNotificationPage.Controls.Add(this.label10);
            this.userNotificationPage.Controls.Add(this.userNotificationTitleTextBox);
            this.userNotificationPage.Controls.Add(this.label11);
            this.userNotificationPage.Location = new System.Drawing.Point(4, 23);
            this.userNotificationPage.Name = "userNotificationPage";
            this.userNotificationPage.Padding = new System.Windows.Forms.Padding(3);
            this.userNotificationPage.Size = new System.Drawing.Size(474, 348);
            this.userNotificationPage.TabIndex = 1;
            this.userNotificationPage.Text = "رخدادهای کاربر";
            this.userNotificationPage.UseVisualStyleBackColor = true;
            // 
            // showButton2
            // 
            this.showButton2.Location = new System.Drawing.Point(10, 109);
            this.showButton2.Name = "showButton2";
            this.showButton2.Size = new System.Drawing.Size(71, 24);
            this.showButton2.TabIndex = 18;
            this.showButton2.Text = "نمایش";
            this.showButton2.UseVisualStyleBackColor = true;
            this.showButton2.Click += new System.EventHandler(this.showButton2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(374, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "لیست رخدادها: ";
            // 
            // userNotificationListBox
            // 
            this.userNotificationListBox.FormattingEnabled = true;
            this.userNotificationListBox.ItemHeight = 14;
            this.userNotificationListBox.Location = new System.Drawing.Point(10, 15);
            this.userNotificationListBox.Name = "userNotificationListBox";
            this.userNotificationListBox.Size = new System.Drawing.Size(328, 88);
            this.userNotificationListBox.TabIndex = 16;
            // 
            // userNotificationCreationDateTextBox
            // 
            this.userNotificationCreationDateTextBox.Location = new System.Drawing.Point(138, 173);
            this.userNotificationCreationDateTextBox.Name = "userNotificationCreationDateTextBox";
            this.userNotificationCreationDateTextBox.ReadOnly = true;
            this.userNotificationCreationDateTextBox.Size = new System.Drawing.Size(200, 22);
            this.userNotificationCreationDateTextBox.TabIndex = 15;
            // 
            // userNotificationContentTextBox
            // 
            this.userNotificationContentTextBox.Location = new System.Drawing.Point(10, 209);
            this.userNotificationContentTextBox.Multiline = true;
            this.userNotificationContentTextBox.Name = "userNotificationContentTextBox";
            this.userNotificationContentTextBox.ReadOnly = true;
            this.userNotificationContentTextBox.Size = new System.Drawing.Size(328, 125);
            this.userNotificationContentTextBox.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(402, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "متن رخداد:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(399, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "تاریخ رخداد:";
            // 
            // userNotificationTitleTextBox
            // 
            this.userNotificationTitleTextBox.Location = new System.Drawing.Point(138, 143);
            this.userNotificationTitleTextBox.Name = "userNotificationTitleTextBox";
            this.userNotificationTitleTextBox.ReadOnly = true;
            this.userNotificationTitleTextBox.Size = new System.Drawing.Size(200, 22);
            this.userNotificationTitleTextBox.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(405, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 14);
            this.label11.TabIndex = 10;
            this.label11.Text = "تیتر رخداد:";
            // 
            // NotificationCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.panel2);
            this.Name = "NotificationCenter";
            this.Text = "NotificationCenter";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.exhibitionNotificationPage.ResumeLayout(false);
            this.exhibitionNotificationPage.PerformLayout();
            this.userNotificationPage.ResumeLayout(false);
            this.userNotificationPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage exhibitionNotificationPage;
        private System.Windows.Forms.TabPage userNotificationPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox exhibitionNotificationTitleTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox exhibitionNotificationContentTextBox;
        private System.Windows.Forms.TextBox exhibitionNotificationCreationDateTextBox;
        private System.Windows.Forms.ListBox exhibitionNotificationListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button showButton1;
        private System.Windows.Forms.Button showButton2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox userNotificationListBox;
        private System.Windows.Forms.TextBox userNotificationCreationDateTextBox;
        private System.Windows.Forms.TextBox userNotificationContentTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox userNotificationTitleTextBox;
        private System.Windows.Forms.Label label11;

    }
}