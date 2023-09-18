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
using System.Windows.Shapes;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for FlashboardWindow.xaml
    /// </summary>
    public partial class FlashboardWindow : Window
    {
        public FlashboardWindow()
        {
            InitializeComponent();
            App.flashboardViewModel = new();
            DataContext = App.flashboardViewModel;
            App.miniGrid = new();
            MiniGrid.Content = App.miniGrid;

            if (App.startup is not null && App.startup.FlashboardWidth is not null && App.startup.FlashboardHeight is not null)
            {
                this.Width = (double)App.startup.FlashboardWidth;
                this.Height = (double)App.startup.FlashboardHeight;
            }

        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
