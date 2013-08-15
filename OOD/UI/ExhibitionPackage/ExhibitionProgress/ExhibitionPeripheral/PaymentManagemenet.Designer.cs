namespace OOD.UI.ExhibitionPackage.ExhibitionProgress.ExhibitionPeripheral
{
    partial class PaymentManagemenet
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
            this.createItemPage = new System.Windows.Forms.TabPage();
            this.createItemDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.createItemButton = new System.Windows.Forms.Button();
            this.createItemAmountTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listPage = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.listIdTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listDateTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listAmountTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listShowButton = new System.Windows.Forms.Button();
            this.listListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.createItemPage.SuspendLayout();
            this.listPage.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(144, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 379);
            this.panel2.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.createItemPage);
            this.tabControl1.Controls.Add(this.listPage);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 372);
            this.tabControl1.TabIndex = 1;
            // 
            // createItemPage
            // 
            this.createItemPage.Controls.Add(this.createItemDateTimePicker);
            this.createItemPage.Controls.Add(this.label6);
            this.createItemPage.Controls.Add(this.createItemButton);
            this.createItemPage.Controls.Add(this.createItemAmountTextBox);
            this.createItemPage.Controls.Add(this.label4);
            this.createItemPage.Location = new System.Drawing.Point(4, 23);
            this.createItemPage.Name = "createItemPage";
            this.createItemPage.Padding = new System.Windows.Forms.Padding(3);
            this.createItemPage.Size = new System.Drawing.Size(486, 345);
            this.createItemPage.TabIndex = 0;
            this.createItemPage.Text = "ثبت فیش فالی";
            this.createItemPage.UseVisualStyleBackColor = true;
            // 
            // createItemDateTimePicker
            // 
            this.createItemDateTimePicker.Location = new System.Drawing.Point(104, 71);
            this.createItemDateTimePicker.Name = "createItemDateTimePicker";
            this.createItemDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.createItemDateTimePicker.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "تاریخ فیش:";
            // 
            // createItemButton
            // 
            this.createItemButton.Location = new System.Drawing.Point(104, 118);
            this.createItemButton.Name = "createItemButton";
            this.createItemButton.Size = new System.Drawing.Size(71, 24);
            this.createItemButton.TabIndex = 11;
            this.createItemButton.Text = "ثبت";
            this.createItemButton.UseVisualStyleBackColor = true;
            this.createItemButton.Click += new System.EventHandler(this.createItemButton_Click);
            // 
            // createItemAmountTextBox
            // 
            this.createItemAmountTextBox.Location = new System.Drawing.Point(104, 31);
            this.createItemAmountTextBox.Name = "createItemAmountTextBox";
            this.createItemAmountTextBox.Size = new System.Drawing.Size(200, 22);
            this.createItemAmountTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "بهای فیش:";
            // 
            // listPage
            // 
            this.listPage.Controls.Add(this.groupBox);
            this.listPage.Controls.Add(this.listShowButton);
            this.listPage.Controls.Add(this.listListBox);
            this.listPage.Controls.Add(this.label7);
            this.listPage.Location = new System.Drawing.Point(4, 23);
            this.listPage.Name = "listPage";
            this.listPage.Padding = new System.Windows.Forms.Padding(3);
            this.listPage.Size = new System.Drawing.Size(486, 345);
            this.listPage.TabIndex = 1;
            this.listPage.Text = "لیست فیش بانکی";
            this.listPage.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.listIdTextBox);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.listDateTextBox);
            this.groupBox.Controls.Add(this.label11);
            this.groupBox.Controls.Add(this.listAmountTextBox);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Location = new System.Drawing.Point(28, 184);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(409, 118);
            this.groupBox.TabIndex = 11;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "فیش مالی";
            // 
            // listIdTextBox
            // 
            this.listIdTextBox.Location = new System.Drawing.Point(24, 18);
            this.listIdTextBox.Name = "listIdTextBox";
            this.listIdTextBox.ReadOnly = true;
            this.listIdTextBox.Size = new System.Drawing.Size(199, 22);
            this.listIdTextBox.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "شماره پیگیری:";
            // 
            // listDateTextBox
            // 
            this.listDateTextBox.Location = new System.Drawing.Point(23, 83);
            this.listDateTextBox.Name = "listDateTextBox";
            this.listDateTextBox.ReadOnly = true;
            this.listDateTextBox.Size = new System.Drawing.Size(200, 22);
            this.listDateTextBox.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 14);
            this.label11.TabIndex = 9;
            this.label11.Text = "تاریخ ارسال:";
            // 
            // listAmountTextBox
            // 
            this.listAmountTextBox.Location = new System.Drawing.Point(24, 50);
            this.listAmountTextBox.Name = "listAmountTextBox";
            this.listAmountTextBox.ReadOnly = true;
            this.listAmountTextBox.Size = new System.Drawing.Size(200, 22);
            this.listAmountTextBox.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(339, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 14);
            this.label9.TabIndex = 5;
            this.label9.Text = "میزان:";
            // 
            // listShowButton
            // 
            this.listShowButton.Location = new System.Drawing.Point(28, 140);
            this.listShowButton.Name = "listShowButton";
            this.listShowButton.Size = new System.Drawing.Size(71, 24);
            this.listShowButton.TabIndex = 2;
            this.listShowButton.Text = "نمایش";
            this.listShowButton.UseVisualStyleBackColor = true;
            this.listShowButton.Click += new System.EventHandler(this.listShowButton_Click);
            // 
            // listListBox
            // 
            this.listListBox.FormattingEnabled = true;
            this.listListBox.ItemHeight = 14;
            this.listListBox.Location = new System.Drawing.Point(28, 23);
            this.listListBox.Name = "listListBox";
            this.listListBox.Size = new System.Drawing.Size(309, 102);
            this.listListBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "لیست فیش ها: ";
            // 
            // PaymentManagemenet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.panel2);
            this.Name = "PaymentManagemenet";
            this.Text = "مدیریت امور مالی";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.createItemPage.ResumeLayout(false);
            this.createItemPage.PerformLayout();
            this.listPage.ResumeLayout(false);
            this.listPage.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage createItemPage;
        private System.Windows.Forms.DateTimePicker createItemDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button createItemButton;
        private System.Windows.Forms.TextBox createItemAmountTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage listPage;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox listIdTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox listDateTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox listAmountTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button listShowButton;
        private System.Windows.Forms.ListBox listListBox;
        private System.Windows.Forms.Label label7;

    }
}