using Lab4_Krysan.Tools;
using Lab4_Krysan.Tools.Managers;
using Lab4_Krysan.Tools.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Lab4_Krysan.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {

        private RelayCommand _addPerson;


        public MainViewModel()
        {
        }


        public RelayCommand AddPerson
        {
            get
            {
                return _addPerson ?? (_addPerson = new RelayCommand(
                           o => { NavigationManager.Instance.Navigate(ViewType.PersonInitialization); }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
