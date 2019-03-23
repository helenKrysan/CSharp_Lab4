using Lab4_Krysan.Tools.Navigation;
using System.Windows.Controls;
using Lab4_Krysan.ViewModels;


namespace Lab4_Krysan.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
