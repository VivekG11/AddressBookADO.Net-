using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.Net
{
    public class AddressBookRepo
    {
        //creating object for AddressBoookdata class
        AddressBookData data = new AddressBookData();

        //establishing connection to server
        public static string connectionString = @"Server = (localdb)\MSSQLLocalDB; Initial Catalog = AddressBook;";

        SqlConnection connection = new SqlConnection(connectionString);

        public void DisplayDetails()
        {
            using(this.connection)
            {
                //Query to retireve details from table
                string query = @"select *from Addressbooktable;";

                SqlCommand command = new SqlCommand(query, this.connection);
                //Opening connection
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
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

                            Console.WriteLine("Records in the table are .....");
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", data.FirstName, data.Lastname, data.address, data.city, data.state, data.Zip, data.PhoneNumber, data.email, data.BookName, data.type);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data exists....");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //Closing connectio
                    this.connection.Close();
                }
            }

        public void UpdateRecord()
        {         
                using (this.connection)
                {
                    //Updating address  using Sql Query 
                    string query = @"update Addressbooktable set address = 'Bhpl' where FirstName = 'Kumar'";

                    SqlCommand command = new SqlCommand(query, this.connection);

                    this.connection.Open();
                    
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                    {
                        Console.WriteLine("Query Not Executed..");
                    }
                    else
                    {
                        Console.WriteLine("Query Executed successfully...");
                    }
                    this.connection.Close();
                }
            
        }
        public void UpdateCityName()
        {
            
            using (this.connection)
            {
                SqlCommand command = new SqlCommand("UpdateCity", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@city", data.city);

                command.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
                
               
                this.connection.Open();
                int res = command.ExecuteNonQuery();
                if (res == 0)
                {
                    Console.WriteLine("Query NOt executed...");
                }
                else
                {
                    Console.WriteLine("Query executed successfully...");
                }
                this.connection.Close();
            }
        }
       
        public void RetrieveCount()
        {

            using (this.connection)
            {
                //retrieving number of contacts using stored procedure
                SqlCommand command = new SqlCommand("ContactCount", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Zip", data.Zip);
                //openin connection
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data.count = reader.GetInt32(0);

                        Console.WriteLine("Total number of contacts in book are ..{0}", data.count);
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
