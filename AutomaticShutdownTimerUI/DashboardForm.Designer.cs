
namespace AutomaticShutdownTimerUI {
    partial class DashboardForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.hoursPicker = new System.Windows.Forms.NumericUpDown();
            this.minutesPicker = new System.Windows.Forms.NumericUpDown();
            this.secondsPicker = new System.Windows.Forms.NumericUpDown();
            this.timerTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.hoursPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(36, 118);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 29);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(166, 118);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(94, 29);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // hoursPicker
            // 
            this.hoursPicker.Location = new System.Drawing.Point(54, 63);
            this.hoursPicker.Name = "hoursPicker";
            this.hoursPicker.Size = new System.Drawing.Size(44, 27);
            this.hoursPicker.TabIndex = 6;
            // 
            // minutesPicker
            // 
            this.minutesPicker.Location = new System.Drawing.Point(126, 63);
            this.minutesPicker.Name = "minutesPicker";
            this.minutesPicker.Size = new System.Drawing.Size(44, 27);
            this.minutesPicker.TabIndex = 7;
            // 
            // secondsPicker
            // 
            this.secondsPicker.Location = new System.Drawing.Point(199, 63);
            this.secondsPicker.Name = "secondsPicker";
            this.secondsPicker.Size = new System.Drawing.Size(44, 27);
            this.secondsPicker.TabIndex = 8;
            // 
            // timerTextBox
            // 
            this.timerTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timerTextBox.Location = new System.Drawing.Point(74, 62);
            this.timerTextBox.Name = "timerTextBox";
            this.timerTextBox.PlaceholderText = "00:00:00";
            this.timerTextBox.ReadOnly = true;
            this.timerTextBox.Size = new System.Drawing.Size(150, 27);
            this.timerTextBox.TabIndex = 9;
            this.timerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timerTextBox.Visible = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 163);
            this.Controls.Add(this.timerTextBox);
            this.Controls.Add(this.secondsPicker);
            this.Controls.Add(this.minutesPicker);
            this.Controls.Add(this.hoursPicker);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shutdown Timer";
            ((System.ComponentModel.ISupportInitialize)(this.hoursPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.NumericUpDown hoursPicker;
        private System.Windows.Forms.NumericUpDown minutesPicker;
        private System.Windows.Forms.NumericUpDown secondsPicker;
        private System.Windows.Forms.TextBox timerTextBox;
    }
}