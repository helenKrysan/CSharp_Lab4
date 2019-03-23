using Lab4_Krysan.Tools.Navigation;
using System.Windows.Controls;
using Lab4_Krysan.ViewModels;

namespace Lab4_Krysan.Views
{
    /// <summary>
    /// Interaction logic for PersonInitializationView.xaml
    /// </summary>
    public partial class PersonInitializationView : UserControl, INavigatable
    {
        public PersonInitializationView()
        {
            InitializeComponent();
            DataContext = new PersonInitializationViewModel();
        }
    }
}
