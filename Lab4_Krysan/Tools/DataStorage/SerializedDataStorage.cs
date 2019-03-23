using Lab4_Krysan.Models;
using Lab4_Krysan.Tools.Managers;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Lab4_Krysan.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
            }
        }

        public bool PersonExists(string name)
        {
            return _persons.Exists(u => u.Name == name);
        }

        public Person GetPersonByName(string name)
        {
            return _persons.FirstOrDefault(u => u.Name == name);
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
            SaveChanges();
        }

        public void Update(string name, string surname, string email)
        {
            GetPersonByName(name).Surname = surname;
            GetPersonByName(name).Email = email;
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _persons.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }

    }
}
