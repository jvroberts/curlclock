namespace CurlClock
{
    partial class ClockSetDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.minutesValue = new System.Windows.Forms.NumericUpDown();
            this.secondsValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minutesValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsValue)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 45);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(96, 45);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // minutesValue
            // 
            this.minutesValue.Location = new System.Drawing.Point(49, 12);
            this.minutesValue.Name = "minutesValue";
            this.minutesValue.Size = new System.Drawing.Size(36, 20);
            this.minutesValue.TabIndex = 2;
            this.minutesValue.Enter += new System.EventHandler(this.minutesValue_Enter);
            // 
            // secondsValue
            // 
            this.secondsValue.Location = new System.Drawing.Point(101, 12);
            this.secondsValue.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secondsValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.secondsValue.Name = "secondsValue";
            this.secondsValue.Size = new System.Drawing.Size(36, 20);
            this.secondsValue.TabIndex = 3;
            this.secondsValue.ValueChanged += new System.EventHandler(this.secondsValue_ValueChanged);
            this.secondsValue.Enter += new System.EventHandler(this.secondsValue_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = ":";
            // 
            // ClockSetDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(183, 80);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondsValue);
            this.Controls.Add(this.minutesValue);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClockSetDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Set Clock";
            ((System.ComponentModel.ISupportInitialize)(this.minutesValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown minutesValue;
        private System.Windows.Forms.NumericUpDown secondsValue;
        private System.Windows.Forms.Label label1;
    }
}