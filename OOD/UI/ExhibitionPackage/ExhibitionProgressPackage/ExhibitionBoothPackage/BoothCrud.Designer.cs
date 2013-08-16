using System.Linq;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.editSaloonTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.editSaloonShowButton = new System.Windows.Forms.Button();
            this.editSaloonListComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boothConstructorCreationTabPage = new System.Windows.Forms.TabPage();
            this.boothConstructorCancelButton = new System.Windows.Forms.Button();
            this.boothConstructorCreateButton = new System.Windows.Forms.Button();
            this.boothConstructorCostTextBox = new System.Windows.Forms.TextBox();
            this.boothConstructorDurationTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.boothConstructorQualityTextBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.boothConstructorProfessionTextBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boothConstructorNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boothConstructorAssignmentTabPage = new System.Windows.Forms.TabPage();
            this.boothConstructionAssignemtConstuctorsComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.boothConstructionAssignemtBoothsComboBox = new System.Windows.Forms.ComboBox();
            this.boothConstructionAssignemtSaloonsComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.boothConstructionAssignemtCancelButton = new System.Windows.Forms.Button();
            this.boothConstructionAssignemtAssignButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.editSaloonTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.boothConstructorCreationTabPage.SuspendLayout();
            this.boothConstructorAssignmentTabPage.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.editSaloonTabPage);
            this.tabControl1.Controls.Add(this.boothConstructorCreationTabPage);
            this.tabControl1.Controls.Add(this.boothConstructorAssignmentTabPage);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 372);
            this.tabControl1.TabIndex = 0;
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
            // editSaloonListComboBox
            // 
            this.editSaloonListComboBox.FormattingEnabled = true;
            this.editSaloonListComboBox.Location = new System.Drawing.Point(38, 14);
            this.editSaloonListComboBox.Name = "editSaloonListComboBox";
            this.editSaloonListComboBox.Size = new System.Drawing.Size(267, 22);
            this.editSaloonListComboBox.TabIndex = 1;
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
            // boothConstructorCreationTabPage
            // 
            this.boothConstructorCreationTabPage.Controls.Add(this.boothConstructorCancelButton);
            this.boothConstructorCreationTabPage.Controls.Add(this.boothConstructorCreateButton);
            this.boothConstructorCreationTabPage.Controls.Add(this.boothConstructorCostTextBox);
            this.boothConstructorCreationTabPage.Controls.Add(this.boothConstructorDurationTextBox);
            this.boothConstructorCreationTabPage.Controls.Add(this.label7);
            this.boothConstructorCreationTabPage.Controls.Add(this.label8);
            this.boothConstructorCreationTabPage.Controls.Add(this.boothConstructorQualityTextBox);
            this.boothConstructorCreationTabPage.Controls.Add(this.label6);
            this.boothConstructorCreationTabPage.Controls.Add(this.boothConstructorProfessionTextBox);
            this.boothConstructorCreationTabPage.Controls.Add(this.label5);
            this.boothConstructorCreationTabPage.Controls.Add(this.boothConstructorNameTextBox);
            this.boothConstructorCreationTabPage.Controls.Add(this.label4);
            this.boothConstructorCreationTabPage.Location = new System.Drawing.Point(4, 23);
            this.boothConstructorCreationTabPage.Name = "boothConstructorCreationTabPage";
            this.boothConstructorCreationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.boothConstructorCreationTabPage.Size = new System.Drawing.Size(486, 345);
            this.boothConstructorCreationTabPage.TabIndex = 4;
            this.boothConstructorCreationTabPage.Text = "سازندگان غرفه ها";
            this.boothConstructorCreationTabPage.UseVisualStyleBackColor = true;
            // 
            // boothConstructorCancelButton
            // 
            this.boothConstructorCancelButton.Location = new System.Drawing.Point(117, 140);
            this.boothConstructorCancelButton.Name = "boothConstructorCancelButton";
            this.boothConstructorCancelButton.Size = new System.Drawing.Size(71, 24);
            this.boothConstructorCancelButton.TabIndex = 11;
            this.boothConstructorCancelButton.Text = "انصراف";
            this.boothConstructorCancelButton.UseVisualStyleBackColor = true;
            // 
            // boothConstructorCreateButton
            // 
            this.boothConstructorCreateButton.Location = new System.Drawing.Point(40, 140);
            this.boothConstructorCreateButton.Name = "boothConstructorCreateButton";
            this.boothConstructorCreateButton.Size = new System.Drawing.Size(71, 24);
            this.boothConstructorCreateButton.TabIndex = 10;
            this.boothConstructorCreateButton.Text = "ثبت";
            this.boothConstructorCreateButton.UseVisualStyleBackColor = true;
            // 
            // boothConstructorCostTextBox
            // 
            this.boothConstructorCostTextBox.Location = new System.Drawing.Point(40, 100);
            this.boothConstructorCostTextBox.Name = "boothConstructorCostTextBox";
            this.boothConstructorCostTextBox.Size = new System.Drawing.Size(140, 22);
            this.boothConstructorCostTextBox.TabIndex = 9;
            // 
            // boothConstructorDurationTextBox
            // 
            this.boothConstructorDurationTextBox.Location = new System.Drawing.Point(251, 100);
            this.boothConstructorDurationTextBox.Name = "boothConstructorDurationTextBox";
            this.boothConstructorDurationTextBox.Size = new System.Drawing.Size(140, 22);
            this.boothConstructorDurationTextBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "هزینه:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "مدت زمان:";
            // 
            // boothConstructorQualityTextBox
            // 
            this.boothConstructorQualityTextBox.FormattingEnabled = true;
            this.boothConstructorQualityTextBox.Location = new System.Drawing.Point(40, 58);
            this.boothConstructorQualityTextBox.Name = "boothConstructorQualityTextBox";
            this.boothConstructorQualityTextBox.Size = new System.Drawing.Size(140, 22);
            this.boothConstructorQualityTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "کیفیت: ";
            // 
            // boothConstructorProfessionTextBox
            // 
            this.boothConstructorProfessionTextBox.FormattingEnabled = true;
            this.boothConstructorProfessionTextBox.Location = new System.Drawing.Point(251, 58);
            this.boothConstructorProfessionTextBox.Name = "boothConstructorProfessionTextBox";
            this.boothConstructorProfessionTextBox.Size = new System.Drawing.Size(140, 22);
            this.boothConstructorProfessionTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "خدمت: ";
            // 
            // boothConstructorNameTextBox
            // 
            this.boothConstructorNameTextBox.Location = new System.Drawing.Point(40, 19);
            this.boothConstructorNameTextBox.Name = "boothConstructorNameTextBox";
            this.boothConstructorNameTextBox.Size = new System.Drawing.Size(351, 22);
            this.boothConstructorNameTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "نام: ";
            // 
            // boothConstructorAssignmentTabPage
            // 
            this.boothConstructorAssignmentTabPage.Controls.Add(this.boothConstructionAssignemtCancelButton);
            this.boothConstructorAssignmentTabPage.Controls.Add(this.boothConstructionAssignemtAssignButton);
            this.boothConstructorAssignmentTabPage.Controls.Add(this.boothConstructionAssignemtConstuctorsComboBox);
            this.boothConstructorAssignmentTabPage.Controls.Add(this.label11);
            this.boothConstructorAssignmentTabPage.Controls.Add(this.boothConstructionAssignemtBoothsComboBox);
            this.boothConstructorAssignmentTabPage.Controls.Add(this.boothConstructionAssignemtSaloonsComboBox);
            this.boothConstructorAssignmentTabPage.Controls.Add(this.label12);
            this.boothConstructorAssignmentTabPage.Controls.Add(this.label10);
            this.boothConstructorAssignmentTabPage.Location = new System.Drawing.Point(4, 23);
            this.boothConstructorAssignmentTabPage.Name = "boothConstructorAssignmentTabPage";
            this.boothConstructorAssignmentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.boothConstructorAssignmentTabPage.Size = new System.Drawing.Size(486, 345);
            this.boothConstructorAssignmentTabPage.TabIndex = 5;
            this.boothConstructorAssignmentTabPage.Text = "تخصیص سازنده ی غرفه";
            this.boothConstructorAssignmentTabPage.UseVisualStyleBackColor = true;
            // 
            // boothConstructionAssignemtConstuctorsComboBox
            // 
            this.boothConstructionAssignemtConstuctorsComboBox.FormattingEnabled = true;
            this.boothConstructionAssignemtConstuctorsComboBox.Location = new System.Drawing.Point(48, 63);
            this.boothConstructionAssignemtConstuctorsComboBox.Name = "boothConstructionAssignemtConstuctorsComboBox";
            this.boothConstructionAssignemtConstuctorsComboBox.Size = new System.Drawing.Size(339, 22);
            this.boothConstructionAssignemtConstuctorsComboBox.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(384, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 5;
            this.label11.Text = "سازندگان: ";
            // 
            // boothConstructionAssignemtBoothsComboBox
            // 
            this.boothConstructionAssignemtBoothsComboBox.FormattingEnabled = true;
            this.boothConstructionAssignemtBoothsComboBox.Location = new System.Drawing.Point(48, 26);
            this.boothConstructionAssignemtBoothsComboBox.Name = "boothConstructionAssignemtBoothsComboBox";
            this.boothConstructionAssignemtBoothsComboBox.Size = new System.Drawing.Size(140, 22);
            this.boothConstructionAssignemtBoothsComboBox.TabIndex = 4;
            // 
            // boothConstructionAssignemtSaloonsComboBox
            // 
            this.boothConstructionAssignemtSaloonsComboBox.FormattingEnabled = true;
            this.boothConstructionAssignemtSaloonsComboBox.Location = new System.Drawing.Point(247, 26);
            this.boothConstructionAssignemtSaloonsComboBox.Name = "boothConstructionAssignemtSaloonsComboBox";
            this.boothConstructionAssignemtSaloonsComboBox.Size = new System.Drawing.Size(140, 22);
            this.boothConstructionAssignemtSaloonsComboBox.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(194, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 2;
            this.label12.Text = "غرفه:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "سالن:";
            // 
            // boothConstructionAssignemtCancelButton
            // 
            this.boothConstructionAssignemtCancelButton.Location = new System.Drawing.Point(125, 102);
            this.boothConstructionAssignemtCancelButton.Name = "boothConstructionAssignemtCancelButton";
            this.boothConstructionAssignemtCancelButton.Size = new System.Drawing.Size(71, 24);
            this.boothConstructionAssignemtCancelButton.TabIndex = 13;
            this.boothConstructionAssignemtCancelButton.Text = "انصراف";
            this.boothConstructionAssignemtCancelButton.UseVisualStyleBackColor = true;
            // 
            // boothConstructionAssignemtAssignButton
            // 
            this.boothConstructionAssignemtAssignButton.Location = new System.Drawing.Point(48, 102);
            this.boothConstructionAssignemtAssignButton.Name = "boothConstructionAssignemtAssignButton";
            this.boothConstructionAssignemtAssignButton.Size = new System.Drawing.Size(71, 24);
            this.boothConstructionAssignemtAssignButton.TabIndex = 12;
            this.boothConstructionAssignemtAssignButton.Text = "ثبت";
            this.boothConstructionAssignemtAssignButton.UseVisualStyleBackColor = true;
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
            this.tabControl1.ResumeLayout(false);
            this.editSaloonTabPage.ResumeLayout(false);
            this.editSaloonTabPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.boothConstructorCreationTabPage.ResumeLayout(false);
            this.boothConstructorCreationTabPage.PerformLayout();
            this.boothConstructorAssignmentTabPage.ResumeLayout(false);
            this.boothConstructorAssignmentTabPage.PerformLayout();
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
        private TabPage boothConstructorCreationTabPage;
        private TabPage boothConstructorAssignmentTabPage;
        private Label label4;
        private TextBox boothConstructorNameTextBox;
        private Label label5;
        private ComboBox boothConstructorProfessionTextBox;
        private ComboBox boothConstructorQualityTextBox;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox boothConstructorCostTextBox;
        private TextBox boothConstructorDurationTextBox;
        private Button boothConstructorCancelButton;
        private Button boothConstructorCreateButton;
        private Label label12;
        private Label label10;
        private ComboBox boothConstructionAssignemtBoothsComboBox;
        private ComboBox boothConstructionAssignemtSaloonsComboBox;
        private Label label11;
        private ComboBox boothConstructionAssignemtConstuctorsComboBox;
        private Button boothConstructionAssignemtCancelButton;
        private Button boothConstructionAssignemtAssignButton;

    }
}