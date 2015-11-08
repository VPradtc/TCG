using System.Windows;
using System.Windows.Controls;
using TCG.Core.Cards;

namespace Task4_GUI.Controls
{
    /// <summary>
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this;
        }

        public Card Card
        {
            set { SetValue(CardProperty, value); }
            get { return (Card)GetValue(CardProperty); }
        }

        public static readonly DependencyProperty CardProperty = 
            DependencyProperty.Register(
                name: "Card",
                propertyType: typeof(Card),
                ownerType: typeof(CardControl),
                typeMetadata: null);
    }
}
