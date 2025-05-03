using System;
using System.IO;
using System.Text;

namespace LSBStegoApp
{
	public static class AudioSteganography
	{
		public static void EmbedMessage(string inputPath, string outputPath, string message)
		{
			byte[] audioBytes = File.ReadAllBytes(inputPath);
			byte[] messageBytes = Encoding.UTF8.GetBytes(message);
			byte[] lengthBytes = BitConverter.GetBytes(messageBytes.Length);

			
			if (audioBytes.Length < 48 + messageBytes.Length * 8)
			{
				throw new Exception("Audio file is too small to hold the message");
			}

			int offset = 44; 

			
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					int bit = (lengthBytes[i] >> j) & 1;
					audioBytes[offset] = (byte)((audioBytes[offset] & 0xFE) | bit);
					offset++;
				}
			}

			
			foreach (byte b in messageBytes)
			{
				for (int i = 0; i < 8; i++)
				{
					int bit = (b >> i) & 1;
					audioBytes[offset] = (byte)((audioBytes[offset] & 0xFE) | bit);
					offset++;
				}
			}

			File.WriteAllBytes(outputPath, audioBytes);
		}

		public static string ExtractMessage(string inputPath)
		{
			byte[] audioBytes = File.ReadAllBytes(inputPath);

			int offset = 44; 
			byte[] lengthBytes = new byte[4];

			
			for (int i = 0; i < 4; i++)
			{
				byte b = 0;
				for (int j = 0; j < 8; j++)
				{
					int bit = audioBytes[offset] & 1;
					b |= (byte)(bit << j);
					offset++;
				}
				lengthBytes[i] = b;
			}

			int msgLength = BitConverter.ToInt32(lengthBytes, 0);

			
			if (msgLength < 0 || msgLength > (audioBytes.Length - offset) / 8)
			{
				throw new Exception("Invalid message length extracted");
			}

			
			byte[] msgBytes = new byte[msgLength];
			for (int i = 0; i < msgLength; i++)
			{
				byte b = 0;
				for (int j = 0; j < 8; j++)
				{
					int bit = audioBytes[offset] & 1;
					b |= (byte)(bit << j);
					offset++;
				}
				msgBytes[i] = b;
			}

			return Encoding.UTF8.GetString(msgBytes);
		}
	}
}