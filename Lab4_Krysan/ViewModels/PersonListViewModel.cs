using Lab4_Krysan.Models;
using Lab4_Krysan.Tools;
using Lab4_Krysan.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Krysan.ViewModels
{
    class PersonListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _persons;

        private RelayCommand _deletePersonCommand;
        
        public event PropertyChangedEventHandler PropertyChanged;

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        internal PersonListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);


        }

        public RelayCommand DeletePersonCommand
        {
            get
            {
                return _deletePersonCommand ?? (_deletePersonCommand = new RelayCommand(
                           DeletePersonImpl, o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return true;
        }

        private void DeletePersonImpl(object o)
        {
            StationManager.DataStorage.DeletePerson(SelectedPerson);
        }



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
