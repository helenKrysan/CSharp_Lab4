using Lab4_Krysan.Models;
using System.Collections.Generic;


namespace Lab4_Krysan.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool PersonExists(string name);

        Person GetPersonByName(string name);

        void AddPerson(Person person);
        void DeletePerson(Person person);
        void Update(string name, string surname, string email);


        List<Person> PersonsList { get; }
    }
}
