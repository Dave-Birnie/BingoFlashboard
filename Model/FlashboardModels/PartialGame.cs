using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BingoFlashboard.Model.FlashboardModels
{
    public class PartialGame
    {
        public int Id_ { get; set; }
        public string Name_ { get; set; } = string.Empty;
        public GameColor? Border_Color_ { get; set; }
        public GameColor? Font_Color_ { get; set; }
        public string GameType_ { get; set; } = string.Empty;
        public Pattern? Pattern_ { get; set; }
        public string Prize_ { get; set; } = string.Empty;
        public string Jackpot_Prize_ { get; set; } = string.Empty;
        public string Designated_Number_ { get; set; } = string.Empty;
        public string? Four_Ball_ { get; set; }
        public string? Four_Ball_Prize_ { get; set; }
        public byte[]? LastBallImage { get; set; }

        public void ConvertBitmapImageToByteArray(BitmapImage bitmapImage)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder(); // Choose an appropriate encoder based on your requirements
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(stream);

                LastBallImage = stream.ToArray();
            }
        }
    }
}
