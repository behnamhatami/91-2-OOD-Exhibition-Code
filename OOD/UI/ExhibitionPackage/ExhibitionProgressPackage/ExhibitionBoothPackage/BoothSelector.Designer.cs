namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    partial class BoothSelector
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
            this.saloonShowButton = new System.Windows.Forms.Button();
            this.saloonListComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // saloonShowButton
            // 
            this.saloonShowButton.Location = new System.Drawing.Point(351, 40);
            this.saloonShowButton.Name = "saloonShowButton";
            this.saloonShowButton.Size = new System.Drawing.Size(71, 24);
            this.saloonShowButton.TabIndex = 6;
            this.saloonShowButton.Text = "مشاهده";
            this.saloonShowButton.UseVisualStyleBackColor = true;
            this.saloonShowButton.Click += new System.EventHandler(this.saloonShowButton_Click);
            // 
            // saloonListComboBox
            // 
            this.saloonListComboBox.FormattingEnabled = true;
            this.saloonListComboBox.Location = new System.Drawing.Point(131, 9);
            this.saloonListComboBox.Name = "saloonListComboBox";
            this.saloonListComboBox.Size = new System.Drawing.Size(291, 22);
            this.saloonListComboBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "لیست سالن ها:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 80);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 240);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // BoothSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 333);
            this.Controls.Add(this.saloonShowButton);
            this.Controls.Add(this.saloonListComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BoothSelector";
            this.Text = "انتخاب غرفه";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saloonShowButton;
        private System.Windows.Forms.ComboBox saloonListComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}