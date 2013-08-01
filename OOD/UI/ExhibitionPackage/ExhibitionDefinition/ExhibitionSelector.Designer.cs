namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    partial class ExhibitionSelector
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
            this.ExhibitionComboBox = new System.Windows.Forms.ComboBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "نمایشگاه:";
            // 
            // ExhibitionComboBox
            // 
            this.ExhibitionComboBox.FormattingEnabled = true;
            this.ExhibitionComboBox.Location = new System.Drawing.Point(42, 40);
            this.ExhibitionComboBox.Name = "ExhibitionComboBox";
            this.ExhibitionComboBox.Size = new System.Drawing.Size(170, 22);
            this.ExhibitionComboBox.TabIndex = 1;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(42, 83);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(71, 24);
            this.selectButton.TabIndex = 2;
            this.selectButton.Text = "انتخاب";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // ExhibitionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 165);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.ExhibitionComboBox);
            this.Controls.Add(this.label1);
            this.Name = "ExhibitionSelector";
            this.Text = "ExhibitionSelector";
            this.Load += new System.EventHandler(this.ExhibitionSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ExhibitionComboBox;
        private System.Windows.Forms.Button selectButton;
    }
}