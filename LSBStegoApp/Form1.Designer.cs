namespace LSBStegoApp
{
	partial class Form1
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
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnEmbedAudio = new System.Windows.Forms.Button();
			this.btnEmbedVideo = new System.Windows.Forms.Button();
			this.btnExtractMessage = new System.Windows.Forms.Button();
			this.txtExtracted = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(205, 49);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(225, 22);
			this.txtMessage.TabIndex = 0;
			// 
			// btnEmbedAudio
			// 
			this.btnEmbedAudio.Location = new System.Drawing.Point(219, 119);
			this.btnEmbedAudio.Name = "btnEmbedAudio";
			this.btnEmbedAudio.Size = new System.Drawing.Size(211, 28);
			this.btnEmbedAudio.TabIndex = 1;
			this.btnEmbedAudio.Text = "WAV dosyasına mesaj göm";
			this.btnEmbedAudio.UseVisualStyleBackColor = true;
			this.btnEmbedAudio.Click += new System.EventHandler(this.btnEmbedAudio_Click);
			// 
			// btnEmbedVideo
			// 
			this.btnEmbedVideo.Location = new System.Drawing.Point(219, 169);
			this.btnEmbedVideo.Name = "btnEmbedVideo";
			this.btnEmbedVideo.Size = new System.Drawing.Size(211, 30);
			this.btnEmbedVideo.TabIndex = 2;
			this.btnEmbedVideo.Text = "\tAVI dosyasına mesaj göm";
			this.btnEmbedVideo.UseVisualStyleBackColor = true;
			this.btnEmbedVideo.Click += new System.EventHandler(this.btnEmbedVideo_Click);
			// 
			// btnExtractMessage
			// 
			this.btnExtractMessage.Location = new System.Drawing.Point(563, 119);
			this.btnExtractMessage.Name = "btnExtractMessage";
			this.btnExtractMessage.Size = new System.Drawing.Size(249, 26);
			this.btnExtractMessage.TabIndex = 3;
			this.btnExtractMessage.Text = "WAV/AVI dosyasından mesaj çıkar";
			this.btnExtractMessage.UseVisualStyleBackColor = true;
			this.btnExtractMessage.Click += new System.EventHandler(this.btnExtractMessage_Click);
			// 
			// txtExtracted
			// 
			this.txtExtracted.Location = new System.Drawing.Point(548, 49);
			this.txtExtracted.Name = "txtExtracted";
			this.txtExtracted.Size = new System.Drawing.Size(321, 22);
			this.txtExtracted.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(93, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Mesaj:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(476, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Çıktı:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1503, 682);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtExtracted);
			this.Controls.Add(this.btnExtractMessage);
			this.Controls.Add(this.btnEmbedVideo);
			this.Controls.Add(this.btnEmbedAudio);
			this.Controls.Add(this.txtMessage);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnEmbedAudio;
		private System.Windows.Forms.Button btnEmbedVideo;
		private System.Windows.Forms.Button btnExtractMessage;
		private System.Windows.Forms.TextBox txtExtracted;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

