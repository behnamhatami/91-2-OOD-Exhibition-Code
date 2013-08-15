using System.Linq;
using System.Windows.Forms;
using OOD.Model.NotificationPackage;
using OOD.UI.Utility.Helper;

namespace OOD.UI.Notification
{
    partial class Polling
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pollChoiceLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pollQuestionTextBox = new System.Windows.Forms.TextBox();
            this.pollingButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.showButton = new System.Windows.Forms.Button();
            this.pollListComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.showButton);
            this.panel2.Controls.Add(this.pollListComboBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(144, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 381);
            this.panel2.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pollChoiceLayoutPanel);
            this.groupBox1.Controls.Add(this.pollQuestionTextBox);
            this.groupBox1.Controls.Add(this.pollingButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(43, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 284);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نظرسنجی";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "گزینه ها:";
            // 
            // pollChoiceLayoutPanel
            // 
            this.pollChoiceLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pollChoiceLayoutPanel.Location = new System.Drawing.Point(6, 69);
            this.pollChoiceLayoutPanel.Name = "pollChoiceLayoutPanel";
            this.pollChoiceLayoutPanel.Size = new System.Drawing.Size(316, 162);
            this.pollChoiceLayoutPanel.TabIndex = 15;
            // 
            // pollQuestionTextBox
            // 
            this.pollQuestionTextBox.Location = new System.Drawing.Point(6, 19);
            this.pollQuestionTextBox.Multiline = true;
            this.pollQuestionTextBox.Name = "pollQuestionTextBox";
            this.pollQuestionTextBox.ReadOnly = true;
            this.pollQuestionTextBox.Size = new System.Drawing.Size(316, 31);
            this.pollQuestionTextBox.TabIndex = 13;
            // 
            // pollingButton
            // 
            this.pollingButton.Location = new System.Drawing.Point(6, 237);
            this.pollingButton.Name = "pollingButton";
            this.pollingButton.Size = new System.Drawing.Size(64, 24);
            this.pollingButton.TabIndex = 14;
            this.pollingButton.Text = "تائید";
            this.pollingButton.UseVisualStyleBackColor = true;
            this.pollingButton.Click += new System.EventHandler(this.pollingButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "سوال:";
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(42, 40);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(71, 24);
            this.showButton.TabIndex = 2;
            this.showButton.Text = "نمایش";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // pollListComboBox
            // 
            this.pollListComboBox.FormattingEnabled = true;
            this.pollListComboBox.Location = new System.Drawing.Point(42, 12);
            this.pollListComboBox.Name = "pollListComboBox";
            this.pollListComboBox.Size = new System.Drawing.Size(235, 22);
            this.pollListComboBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "لیست نظرسنجی:";
            // 
            // Polling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.panel2);
            this.Name = "Polling";
            this.Text = "نظرسنجی";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void drawPoll(Poll poll)
        {
            this.pollQuestionTextBox.Text = poll.Question;

            var choices = poll.PollChoices.ToArray();
            this.radioButtons = new RadioButton[choices.Length];

            for (int i = 0; i < choices.Length; i++)
                radioButtons[i] = new RadioButton();

            for (int i = 0; i < choices.Length; i++)
                this.pollChoiceLayoutPanel.Controls.Add(this.radioButtons[i]);

            for (int i = 0; i < radioButtons.Length; i++)
            {
                // 
                // radioButtoni
                // 
                this.radioButtons[i].AutoSize = true;
                this.radioButtons[i].Name = "" + choices[i].Id;
                this.radioButtons[i].TabIndex = i;
                this.radioButtons[i].TabStop = true;
                this.radioButtons[i].Text = choices[i].Content;
                this.radioButtons[i].UseVisualStyleBackColor = true;
            }
            pollingButton.Enabled = true;
        }

        private void resetPoll()
        {
            ResetHelper.Empty(pollQuestionTextBox);
            this.pollChoiceLayoutPanel.Controls.Clear();
            pollingButton.Enabled = false;
            radioButtons = null;
        }


        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox pollListComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel pollChoiceLayoutPanel;
        private System.Windows.Forms.TextBox pollQuestionTextBox;
        private System.Windows.Forms.Button pollingButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton[] radioButtons;
    }
}