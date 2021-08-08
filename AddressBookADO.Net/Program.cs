using System;

namespace AddressBookADO.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook..........");
            AddressBookRepo repo = new AddressBookRepo();
            // repo.UpdateCityName();
            //  repo.DisplayDetails();
            //  repo.UpdateRecord();
           // repo.RetrieveContactsCount();
            repo.RetrieveCount();
        }
    }
}
