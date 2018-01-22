namespace CurlClock
{
    partial class ClockConfigDialog
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
            this.teamNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clockColorComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textColorComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startKeyTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // teamNameTextBox
            // 
            this.teamNameTextBox.Location = new System.Drawing.Point(89, 12);
            this.teamNameTextBox.Name = "teamNameTextBox";
            this.teamNameTextBox.Size = new System.Drawing.Size(218, 20);
            this.teamNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Team Name:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(64, 135);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(86, 26);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(156, 135);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(86, 26);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // clockColorComboBox
            // 
            this.clockColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.clockColorComboBox.FormattingEnabled = true;
            this.clockColorComboBox.IntegralHeight = false;
            this.clockColorComboBox.Location = new System.Drawing.Point(89, 38);
            this.clockColorComboBox.MaxDropDownItems = 1;
            this.clockColorComboBox.Name = "clockColorComboBox";
            this.clockColorComboBox.Size = new System.Drawing.Size(41, 21);
            this.clockColorComboBox.TabIndex = 6;
            this.clockColorComboBox.TextUpdate += new System.EventHandler(this.clockColorComboBox_TextUpdate);
            this.clockColorComboBox.Click += new System.EventHandler(this.clockColorComboBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Clock Color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Text Color:";
            // 
            // textColorComboBox
            // 
            this.textColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.textColorComboBox.FormattingEnabled = true;
            this.textColorComboBox.Location = new System.Drawing.Point(89, 65);
            this.textColorComboBox.Name = "textColorComboBox";
            this.textColorComboBox.Size = new System.Drawing.Size(41, 21);
            this.textColorComboBox.TabIndex = 8;
            this.textColorComboBox.TextUpdate += new System.EventHandler(this.textColorComboBox_TextUpdate);
            this.textColorComboBox.Click += new System.EventHandler(this.textColorComboBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Start Key:";
            // 
            // startKeyTextBox
            // 
            this.startKeyTextBox.Location = new System.Drawing.Point(89, 90);
            this.startKeyTextBox.Name = "startKeyTextBox";
            this.startKeyTextBox.Size = new System.Drawing.Size(41, 20);
            this.startKeyTextBox.TabIndex = 11;
            this.startKeyTextBox.TextChanged += new System.EventHandler(this.startKeyTextBox_TextChanged);
            this.startKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startKeyTextBox_KeyDown);
            // 
            // ClockConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 173);
            this.Controls.Add(this.startKeyTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textColorComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clockColorComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teamNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClockConfigDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configure Clock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teamNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox clockColorComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox textColorComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox startKeyTextBox;
    }
}