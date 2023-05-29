using System.Windows;
using System.Windows.Controls;

namespace Flashboard.Data
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
