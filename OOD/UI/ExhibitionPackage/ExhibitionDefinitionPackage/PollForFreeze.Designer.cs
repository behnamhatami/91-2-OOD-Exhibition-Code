using System.Linq;
using System.Windows.Forms;
using OOD.Model.NotificationPackage;

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinitionPackage
{
    partial class PollForFreeze
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(144, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 380);
            this.panel2.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 67);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(427, 118);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 24);
            this.button2.TabIndex = 10;
            this.button2.Text = "تائید";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(427, 37);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(445, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "سوال:";
            // 
            // PollForFreeze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.panel2);
            this.Name = "PollForFreeze";
            this.Text = "شرکت در رای گیری انجماد";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void drawPoll(Poll poll)
        {
            this.textBox1.Text = poll.Question;

            var choices = poll.PollChoices.ToArray();
            this.radioButtons = new RadioButton[choices.Length];
            
            for(int i = 0; i < choices.Length; i++)
                radioButtons[i] = new RadioButton();

            for(int i = 0; i < choices.Length; i++)
                this.flowLayoutPanel1.Controls.Add(this.radioButtons[i]);

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
        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton[] radioButtons;
    }
}