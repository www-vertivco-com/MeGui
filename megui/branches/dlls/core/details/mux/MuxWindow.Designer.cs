namespace MeGUI
{
    partial class MuxWindow
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
            this.muxedInput = new System.Windows.Forms.TextBox();
            this.muxedInputOpenButton = new System.Windows.Forms.Button();
            this.videoGroupbox.SuspendLayout();
            this.outputGroupbox.SuspendLayout();
            this.audioGroupbox.SuspendLayout();
            this.subtitleGroupbox.SuspendLayout();
            this.chaptersGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoInput
            // 
            this.videoInput.Location = new System.Drawing.Point(118, 20);
            // 
            // inputOpenButton
            // 
            this.inputOpenButton.Location = new System.Drawing.Point(382, 19);
            // 
            // videoInputLabel
            // 
            this.videoInputLabel.Location = new System.Drawing.Point(16, 24);
            // 
            // muxButton
            // 
            this.muxButton.Location = new System.Drawing.Point(294, 448);
            // 
            // MuxFPSLabel
            // 
            this.MuxFPSLabel.Location = new System.Drawing.Point(16, 79);
            // 
            // muxFPS
            // 
            this.muxFPS.Location = new System.Drawing.Point(118, 77);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(376, 448);
            // 
            // videoGroupbox
            // 
            this.videoGroupbox.Controls.Add(this.muxedInput);
            this.videoGroupbox.Controls.Add(this.label1);
            this.videoGroupbox.Controls.Add(this.muxedInputOpenButton);
            this.videoGroupbox.Location = new System.Drawing.Point(8, 3);
            this.videoGroupbox.Size = new System.Drawing.Size(424, 102);
            this.videoGroupbox.Controls.SetChildIndex(this.videoNameLabel, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.MuxFPSLabel, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.videoName, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.muxedInputOpenButton, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.label1, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.muxFPS, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.muxedInput, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.inputOpenButton, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.videoInputLabel, 0);
            this.videoGroupbox.Controls.SetChildIndex(this.videoInput, 0);
            // 
            // outputGroupbox
            // 
            this.outputGroupbox.Location = new System.Drawing.Point(8, 362);
            // 
            // audioGroupbox
            // 
            this.audioGroupbox.Location = new System.Drawing.Point(8, 109);
            // 
            // subtitleGroupbox
            // 
            this.subtitleGroupbox.Location = new System.Drawing.Point(8, 222);
            // 
            // chaptersGroupbox
            // 
            this.chaptersGroupbox.Location = new System.Drawing.Point(8, 308);
            // 
            // videoName
            // 
            this.videoName.Location = new System.Drawing.Point(283, 77);
            // 
            // videoNameLabel
            // 
            this.videoNameLabel.Location = new System.Drawing.Point(243, 80);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Muxed Input";
            // 
            // muxedInput
            // 
            this.muxedInput.Location = new System.Drawing.Point(118, 50);
            this.muxedInput.Name = "muxedInput";
            this.muxedInput.ReadOnly = true;
            this.muxedInput.Size = new System.Drawing.Size(256, 21);
            this.muxedInput.TabIndex = 36;
            // 
            // muxedInputOpenButton
            // 
            this.muxedInputOpenButton.Location = new System.Drawing.Point(382, 48);
            this.muxedInputOpenButton.Name = "muxedInputOpenButton";
            this.muxedInputOpenButton.Size = new System.Drawing.Size(24, 23);
            this.muxedInputOpenButton.TabIndex = 37;
            this.muxedInputOpenButton.Text = "...";
            this.muxedInputOpenButton.UseVisualStyleBackColor = true;
            this.muxedInputOpenButton.Click += new System.EventHandler(this.muxedInputOpenButton_Click);
            // 
            // MuxWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 474);
            this.Name = "MuxWindow";
            this.Text = "MuxWindow";
            this.videoGroupbox.ResumeLayout(false);
            this.videoGroupbox.PerformLayout();
            this.outputGroupbox.ResumeLayout(false);
            this.outputGroupbox.PerformLayout();
            this.audioGroupbox.ResumeLayout(false);
            this.audioGroupbox.PerformLayout();
            this.subtitleGroupbox.ResumeLayout(false);
            this.subtitleGroupbox.PerformLayout();
            this.chaptersGroupbox.ResumeLayout(false);
            this.chaptersGroupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox muxedInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button muxedInputOpenButton;
    }
}