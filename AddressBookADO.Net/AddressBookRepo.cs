using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.Net
{
    public class AddressBookRepo
    {
        AddressBookData data = new AddressBookData();

        public static string connectionString = @"Server = (localdb)\MSSQLLocalDB; Initial Catalog = AddressBook;";

        SqlConnection connection = new SqlConnection(connectionString);

        public void DisplayDetails()
        {
            using(this.connection)
            {
                string query = @"select *from Addressbooktable;";

                SqlCommand command = new SqlCommand(query, this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data.FirstName = reader.GetString(0);
                        data.Lastname = reader.GetString(1);
                        data.address = reader.GetString(2);
                        data.city = reader.GetString(3);
                        data.state = reader.GetString(4);
                        data.Zip = reader.GetInt64(5);
                        data.PhoneNumber = reader.GetInt64(6);
                        data.email = reader.GetString(7);
                        data.BookName = reader.GetString(8);
                        data.type = reader.GetString(9);

                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", data.FirstName, data.Lastname, data.address, data.city, data.state, data.Zip, data.PhoneNumber, data.email, data.BookName, data.type);

                    }
                }
                else
                {
                    Console.WriteLine("No data exists....");
                }
                    this.connection.Close();
                }
            }
        }


    
}
