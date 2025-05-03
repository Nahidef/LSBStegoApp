using System;
using System.Drawing;
using System.Drawing.Imaging;
using Accord.Video.FFMPEG;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace LSBStegoApp
{
	public static class VideoSteganography
	{
		public static void EmbedMessage(string inputPath, string outputPath, string message)
		{
			VideoFileReader reader = new VideoFileReader();
			reader.Open(inputPath);

			VideoFileWriter writer = new VideoFileWriter();
			writer.Open(outputPath, reader.Width, reader.Height, reader.FrameRate, VideoCodec.MPEG4);

			string bits = ToBits(message);
			int bitIndex = 0;

			for (int i = 0; i < reader.FrameCount; i++)
			{
				Bitmap frame = reader.ReadVideoFrame();

				if (bitIndex < bits.Length)
				{
					for (int y = 0; y < frame.Height; y++)
					{
						for (int x = 0; x < frame.Width; x++)
						{
							if (bitIndex >= bits.Length) break;
							Color pixel = frame.GetPixel(x, y);
							int r = (pixel.R & 0xFE) | (bits[bitIndex] - '0');
							frame.SetPixel(x, y, Color.FromArgb(r, pixel.G, pixel.B));
							bitIndex++;
						}
						if (bitIndex >= bits.Length) break;
					}
				}

				writer.WriteVideoFrame(frame);
				frame.Dispose();
			}

			reader.Close();
			writer.Close();
		}

		public static string ExtractMessage(string inputPath)
		{
			VideoFileReader reader = new VideoFileReader();
			reader.Open(inputPath);

			string bits = "";
			for (int i = 0; i < reader.FrameCount; i++)
			{
				Bitmap frame = reader.ReadVideoFrame();
				for (int y = 0; y < frame.Height; y++)
				{
					for (int x = 0; x < frame.Width; x++)
					{
						Color pixel = frame.GetPixel(x, y);
						bits += (pixel.R & 1).ToString();
						if (bits.Length % 8 == 0 && bits.EndsWith("00000000")) break;
					}
				}
				frame.Dispose();
			}

			reader.Close();
			return FromBits(bits.TrimEnd('0'));
		}

		public static string ToBits(string text)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in text)
			{
				sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
			}
			sb.Append("00000000"); 
			return sb.ToString();
		}

		public static string FromBits(string bits)
		{
			List<byte> bytes = new List<byte>();
			for (int i = 0; i + 8 <= bits.Length; i += 8)
			{
				bytes.Add(Convert.ToByte(bits.Substring(i, 8), 2));
			}
			return Encoding.UTF8.GetString(bytes.ToArray());
		}
	}
}
