using Lab4_Krysan.Views;
using System;


namespace Lab4_Krysan.Tools.Navigation
{
    internal class PersonInitializationNavigationModel : BaseNavigationModel
    {
        public PersonInitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
            {
                switch (viewType)
                {
                    case ViewType.PersonInitialization:
                        ViewsDictionary.Add(viewType, new PersonInitializationView());
                        break;
                    case ViewType.Main:
                        ViewsDictionary.Add(viewType, new MainView());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
                }
            }
            else
            {
                switch (viewType)
                {
                    case ViewType.PersonInitialization:
                        break;
                    case ViewType.Main:
                        ViewsDictionary[viewType] = new MainView();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
                }
            }
        }

    }
}
