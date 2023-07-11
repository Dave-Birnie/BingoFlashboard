using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for BingoCalledWindow.xaml
    /// </summary>
    public partial class BingoCalledWindow : Window
    {
        private bool isFlashing;
        private SolidColorBrush defaultBrush;
        private SolidColorBrush flashingBrush;
        private SolidColorBrush flashingBrush2;
        private SolidColorBrush flashingBrush3;

        public BingoCalledWindow(string cardnum)
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            CardNum.Content = cardnum;

            isFlashing = true;
            defaultBrush = new SolidColorBrush(Colors.LawnGreen);
            flashingBrush = new SolidColorBrush(Colors.Red);
            flashingBrush2 = new SolidColorBrush(Colors.DarkGoldenrod);
            flashingBrush3 = new SolidColorBrush(Colors.DodgerBlue);

            // Start the flashing animation
            FlashLabel();
        }

        private async void FlashLabel()
        {
            while (true)
            {
                if (isFlashing)
                {
                    GridBackground.Background = flashingBrush;
                    await Task.Delay(200); // Flashing duration
                    GridBackground.Background = flashingBrush2;
                    await Task.Delay(200); // Flashing duration
                    GridBackground.Background = flashingBrush3;
                    await Task.Delay(200); // Flashing duration
                    GridBackground.Background = defaultBrush;
                    await Task.Delay(200); // Delay between flashes
                }
                else
                {
                    await Task.Delay(100); // Delay when not flashing
                }
            }
        }

        private void AcknowledgeBtn_Click(object sender, RoutedEventArgs e)
        {
            string? cardNumber = CardNum.Content.ToString();
            Clipboard.SetText(cardNumber);

            Close();
        }
    }
}
