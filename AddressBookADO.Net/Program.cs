﻿using System;

namespace AddressBookADO.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook..........");
            AddressBookRepo repo = new AddressBookRepo();
            repo.DisplayDetails();
        }
    }
}
