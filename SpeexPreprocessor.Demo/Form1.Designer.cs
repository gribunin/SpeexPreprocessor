
namespace SpeexPreprocessor.Demo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbCapture = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPlayback = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAgc = new System.Windows.Forms.CheckBox();
            this.tbAgcLevel = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAgcMaxGain = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAgcIncrement = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAgcDecrement = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcMaxGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcDecrement)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCapture
            // 
            this.cbCapture.DisplayMember = "Text";
            this.cbCapture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCapture.FormattingEnabled = true;
            this.cbCapture.Location = new System.Drawing.Point(12, 129);
            this.cbCapture.Name = "cbCapture";
            this.cbCapture.Size = new System.Drawing.Size(389, 21);
            this.cbCapture.TabIndex = 0;
            this.cbCapture.ValueMember = "Device";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Capture device:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Playback device:";
            // 
            // cbPlayback
            // 
            this.cbPlayback.DisplayMember = "Text";
            this.cbPlayback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayback.FormattingEnabled = true;
            this.cbPlayback.Location = new System.Drawing.Point(12, 178);
            this.cbPlayback.Name = "cbPlayback";
            this.cbPlayback.Size = new System.Drawing.Size(389, 21);
            this.cbPlayback.TabIndex = 3;
            this.cbPlayback.ValueMember = "Device";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(594, 97);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Location = new System.Drawing.Point(441, 129);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(166, 70);
            this.btnCapture.TabIndex = 5;
            this.btnCapture.Text = "Start";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbAgcDecrement);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbAgcIncrement);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbAgcMaxGain);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbAgcLevel);
            this.groupBox1.Controls.Add(this.cbAgc);
            this.groupBox1.Location = new System.Drawing.Point(12, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 296);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preprocessor options";
            // 
            // cbAgc
            // 
            this.cbAgc.AutoSize = true;
            this.cbAgc.Checked = true;
            this.cbAgc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAgc.Location = new System.Drawing.Point(7, 20);
            this.cbAgc.Name = "cbAgc";
            this.cbAgc.Size = new System.Drawing.Size(86, 17);
            this.cbAgc.TabIndex = 0;
            this.cbAgc.Text = "Agc enabled";
            this.cbAgc.UseVisualStyleBackColor = true;
            // 
            // tbAgcLevel
            // 
            this.tbAgcLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAgcLevel.LargeChange = 2;
            this.tbAgcLevel.Location = new System.Drawing.Point(7, 67);
            this.tbAgcLevel.Minimum = 1;
            this.tbAgcLevel.Name = "tbAgcLevel";
            this.tbAgcLevel.Size = new System.Drawing.Size(581, 45);
            this.tbAgcLevel.TabIndex = 1;
            this.tbAgcLevel.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Agc level:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Agc Max Gain:";
            // 
            // tbAgcMaxGain
            // 
            this.tbAgcMaxGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAgcMaxGain.LargeChange = 2;
            this.tbAgcMaxGain.Location = new System.Drawing.Point(7, 125);
            this.tbAgcMaxGain.Maximum = 30;
            this.tbAgcMaxGain.Minimum = 1;
            this.tbAgcMaxGain.Name = "tbAgcMaxGain";
            this.tbAgcMaxGain.Size = new System.Drawing.Size(581, 45);
            this.tbAgcMaxGain.TabIndex = 3;
            this.tbAgcMaxGain.Value = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Agc increment:";
            // 
            // tbAgcIncrement
            // 
            this.tbAgcIncrement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAgcIncrement.LargeChange = 2;
            this.tbAgcIncrement.Location = new System.Drawing.Point(7, 183);
            this.tbAgcIncrement.Minimum = 1;
            this.tbAgcIncrement.Name = "tbAgcIncrement";
            this.tbAgcIncrement.Size = new System.Drawing.Size(581, 45);
            this.tbAgcIncrement.TabIndex = 5;
            this.tbAgcIncrement.Value = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Agc decrement:";
            // 
            // tbAgcDecrement
            // 
            this.tbAgcDecrement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAgcDecrement.LargeChange = 2;
            this.tbAgcDecrement.Location = new System.Drawing.Point(7, 241);
            this.tbAgcDecrement.Minimum = 1;
            this.tbAgcDecrement.Name = "tbAgcDecrement";
            this.tbAgcDecrement.Size = new System.Drawing.Size(581, 45);
            this.tbAgcDecrement.TabIndex = 7;
            this.tbAgcDecrement.Value = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 532);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbPlayback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speex Preprocessor Demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcMaxGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAgcDecrement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCapture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPlayback;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbAgc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbAgcLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbAgcIncrement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbAgcMaxGain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbAgcDecrement;
    }
}

