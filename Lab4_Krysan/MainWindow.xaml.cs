using System.Windows;
using System;
using System.Windows.Controls;
using Lab4_Krysan.Tools.Managers;
using Lab4_Krysan.Tools.Navigation;
using Lab4_Krysan.ViewModels;
using Lab4_Krysan.Tools.DataStorage;
using System.ComponentModel;
using Lab4_Krysan.Models;

namespace Lab4_Krysan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            StationManager.Initialize(new SerializedDataStorage());

            for (int i = 0; i < 50; i++)
            {
                Person person = new Person("Per" + i, "PerSurname" + i, "per" + i + "@email.com", new DateTime(2000 - i, 10, 2 + i / 2));
                if (!StationManager.DataStorage.PersonExists("Per" + i))
                {
                    StationManager.DataStorage.AddPerson(person);
                }
            }

            NavigationManager.Instance.Initialize(new PersonInitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            StationManager.CloseApp();
        }
    }
}
