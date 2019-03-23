namespace Lab4_Krysan.Tools.Navigation
{
    internal enum ViewType
    {
        PersonInitialization,
        Main
    }


    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
