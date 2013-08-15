using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth;

namespace OOD.UI.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth
{
    partial class BoothCrud
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.editSaloonTabPage = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.editSaloonListComboBox = new System.Windows.Forms.ComboBox();
            this.editSaloonShowButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel2.SuspendLayout();
            this.editSaloonTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(144, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 380);
            this.panel2.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(486, 345);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "تخصیص سازنده ی غرفه";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(486, 345);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "سازندگان غرفه ها";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // editSaloonTabPage
            // 
            this.editSaloonTabPage.Controls.Add(this.groupBox1);
            this.editSaloonTabPage.Controls.Add(this.editSaloonShowButton);
            this.editSaloonTabPage.Controls.Add(this.editSaloonListComboBox);
            this.editSaloonTabPage.Controls.Add(this.label9);
            this.editSaloonTabPage.Location = new System.Drawing.Point(4, 23);
            this.editSaloonTabPage.Name = "editSaloonTabPage";
            this.editSaloonTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.editSaloonTabPage.Size = new System.Drawing.Size(486, 345);
            this.editSaloonTabPage.TabIndex = 1;
            this.editSaloonTabPage.Text = "ویرایش سالن";
            this.editSaloonTabPage.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "لیست سالن ها:";
            // 
            // editSaloonListComboBox
            // 
            this.editSaloonListComboBox.FormattingEnabled = true;
            this.editSaloonListComboBox.Location = new System.Drawing.Point(38, 14);
            this.editSaloonListComboBox.Name = "editSaloonListComboBox";
            this.editSaloonListComboBox.Size = new System.Drawing.Size(267, 22);
            this.editSaloonListComboBox.TabIndex = 1;
            // 
            // editSaloonShowButton
            // 
            this.editSaloonShowButton.Location = new System.Drawing.Point(38, 42);
            this.editSaloonShowButton.Name = "editSaloonShowButton";
            this.editSaloonShowButton.Size = new System.Drawing.Size(71, 24);
            this.editSaloonShowButton.TabIndex = 2;
            this.editSaloonShowButton.Text = "مشاهده";
            this.editSaloonShowButton.UseVisualStyleBackColor = true;
            this.editSaloonShowButton.Click += new System.EventHandler(this.editSaloonShowButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(38, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 267);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نقشه ی نمایشگاه";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 240);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.editSaloonTabPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 372);
            this.tabControl1.TabIndex = 0;
            // 
            // BoothCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.panel2);
            this.Name = "BoothCrud";
            this.Text = "مدیریت غرفه";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.editSaloonTabPage.ResumeLayout(false);
            this.editSaloonTabPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public static void DrawSaloon(Saloon saloon, FlowLayoutPanel panel)
        {
            var width = saloon.Map.Width;
            var height = saloon.Map.Height;
            var buttonWidth = 30 + 6;
            var buttonHeight = 25 + 6;
            var count = width*height;
            panel.Size = new System.Drawing.Size(width * buttonWidth, height * buttonHeight);
      
            panel.Controls.Clear();
            foreach (var booth in saloon.Map.Booths.OrderBy(booth => booth.Index))
                panel.Controls.Add(CreateButton(booth));
        }


        public static Button CreateButton(Booth booth)
        {
            var button = new Button();
            button.Size = new System.Drawing.Size(30, 25);
            button.TabIndex = booth.Index;
            button.Text = booth.Index + "";
            button.UseVisualStyleBackColor = true;
            ButtonReDraw(booth, button);
            return button;
        }

        public static Booth GetBooth(Button button, Saloon saloon)
        {
            var index = int.Parse(button.Text);
            return saloon.Map.Booths.First(booth1 => booth1.Index == index);
        }

        public static void ButtonReDraw(Booth booth, Button button)
        {
            if (!booth.Enabled)
                button.BackColor = System.Drawing.Color.LightCoral;
            else
            {
                if (booth.Request != null)
                    button.BackColor = System.Drawing.Color.LightGreen;
                else button.BackColor = System.Drawing.Color.LemonChiffon;
            }
        }

        private System.Windows.Forms.Panel panel2;
        private TabControl tabControl1;
        private TabPage editSaloonTabPage;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button editSaloonShowButton;
        private ComboBox editSaloonListComboBox;
        private Label label9;
        private TabPage tabPage2;
        private TabPage tabPage1;

    }
}