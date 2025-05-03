using System;
using System.IO;
using System.Windows.Forms;

namespace LSBStegoApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void btnEmbedAudio_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Ses Dosyaları (*.wav;*.mp3)|*.wav;*.mp3";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string path = ofd.FileName;
				string message = txtMessage.Text;
				string outPath = Path.Combine(Path.GetDirectoryName(path), "audio_output.wav");
				AudioSteganography.EmbedMessage(path, outPath, message);
				MessageBox.Show("Mesaj başarıyla WAV dosyasına gömüldü.");
			}
		}

		private void btnEmbedVideo_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "AVI Dosyaları (*.avi)|*.avi";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string path = ofd.FileName;
				string message = txtMessage.Text;
				string outPath = Path.Combine(Path.GetDirectoryName(path), "video_output.avi");
				VideoSteganography.EmbedMessage(path, outPath, message);
				MessageBox.Show("Mesaj başarıyla AVI dosyasına gömüldü.");
			}
		}

		private void btnExtractMessage_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Desteklenen Dosyalar (*.wav;*.avi)|*.wav;*.avi";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string path = ofd.FileName;
				string result = "";
				if (Path.GetExtension(path).ToLower() == ".wav")
				{
					result = AudioSteganography.ExtractMessage(path);
				}
				else if (Path.GetExtension(path).ToLower() == ".avi")
				{
					result = VideoSteganography.ExtractMessage(path);
				}
				txtExtracted.Text = result;
			}
		}
	}
}
