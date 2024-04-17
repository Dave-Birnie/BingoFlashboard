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
        public string? Logo_ { get; set; }
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
            //if (Logo_ == null || Logo_.Length == 0)
            //    return null;

            //BitmapImage image = new BitmapImage();
            //using (MemoryStream memStream = new MemoryStream(Logo_))
            //{
            //    memStream.Position = 0;
            //    image.BeginInit();
            //    image.CacheOption = BitmapCacheOption.OnLoad;  // Ensures the image is loaded while the stream is open
            //    image.StreamSource = memStream;
            //    image.EndInit();
            //    image.Freeze(); // Optional: make the image cross-thread accessible
            //}
            //return image;

            if (string.IsNullOrEmpty(Logo_))
                return null;

            try
            {
                byte[] imageBytes = Convert.FromBase64String(Logo_); // Convert the Base64 string to byte array
                BitmapImage image = new BitmapImage();
                using (MemoryStream memStream = new MemoryStream(imageBytes))
                {
                    memStream.Position = 0;
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;  // Ensures the image is loaded while the stream is open
                    image.StreamSource = memStream;
                    image.EndInit();
                    image.Freeze(); // Optional: make the image cross-thread accessible
                }
                return image;
            }
            catch (FormatException ex)
            {
                // Handle the case where the string is not a valid Base64
                Console.WriteLine("Error: Invalid Base64 string - " + ex.Message);
                return null;
            }


            //OLD CODE
            //if (Logo_ == null || Logo_.Length == 0)
            //    return null;

            //using (MemoryStream stream = new MemoryStream(Logo_))
            //{
            //    BitmapImage image = new BitmapImage();
            //    image.BeginInit();
            //    // Cache option to load the image from the memory, not from the stream after it's disposed
            //    image.CacheOption = BitmapCacheOption.OnLoad;
            //    image.StreamSource = stream;
            //    image.EndInit();
            //    return image;
            //}
        }
    }
}
