using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace BingoFlashboard.Model
{
    public class Hall
    {
        public int Id_ { get; set; }
        public string Name_ { get; set; } = string.Empty;
        public byte[]? Logo_ { get; set; }
        public string? Address_ { get; set; } = string.Empty;
        public string? City_ { get; set; } = string.Empty;
        public string? Postal_ { get; set; } = string.Empty;
        public Country? Country_ { get; set; } = new();
        public Province? Province_ { get; set; } = new();
        public string? Phone_ { get; set; } = string.Empty;
        public string? Website_ { get; set; } = string.Empty;
        public string? Email_ { get; set; } = string.Empty;
        public string? Username_ { get; set; } = string.Empty;
        public string? Login_Password_ { get; set; } = string.Empty;
        public string? Temp_Login_Password_ { get; set; } = string.Empty;
        public string? Comport_ { get; set; } = string.Empty;
        public bool? Auto_Caller_ { get; set; } = false;
        public string? Message_ { get; set; } = string.Empty;
        public bool? Master_ { get; set; } = false;
        public bool? Active_ { get; set; } = true;
        public List<Session>? AllSessions_ { get; set; }

        public BitmapImage ByteArrayToImage()
        {
            if (Logo_ == null || Logo_.Length == 0)
                return null;

            using (MemoryStream stream = new MemoryStream(Logo_))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                // Cache option to load the image from the memory, not from the stream after it's disposed
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }
    }
}
