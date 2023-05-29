using System.Windows;
using System.Windows.Controls;

namespace BingoFlashboard.Data
{
    public class CustomLabel : Label
    {
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(int), typeof(CustomLabel), new PropertyMetadata(0));

        public int State
        {
            get { return (int) GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
    }
}
