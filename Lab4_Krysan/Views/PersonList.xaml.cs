using Lab4_Krysan.ViewModels;
using System.Windows.Controls;


namespace Lab4_Krysan.Views
{
    /// <summary>
    /// Interaction logic for PersonList.xaml
    /// </summary>
    public partial class PersonList : UserControl
    {
        public PersonList()
        {
            InitializeComponent();
            DataContext = new PersonListViewModel();
        }
    }
}
