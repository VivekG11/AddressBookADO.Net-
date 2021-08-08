using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.Net
{
    public class Transactions
    {
        AddressBookRepo book = new AddressBookRepo();
        //establishing connection
        public static string connectionString = @"Server = (localdb)\MSSQLLocalDB; Initial Catalog = AddressBook;";

        SqlConnection connection = new SqlConnection(connectionString);


        public void AddContact()
        {
            using (this.connection)
            {
                //opening connection
                this.connection.Open();
                //starting transaction
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = @"insert into ContactPerson values (2,'Aditya','S','Sironcha','GDCL','Maharashtra',60021,'9649510','Aditya114@gmail.com')";
                    command.ExecuteNonQuery();
                    command.CommandText = @"insert into ContactType values ('Friends');";
                    command.ExecuteNonQuery();
                    command.CommandText = @"insert into Relation values (8,2);";
                    command.ExecuteNonQuery();
                    //If all commands gets executed transaction commits
                    transaction.Commit();

                    Console.WriteLine("Record added successfully....");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //if any command fails i will rollback
                    transaction.Rollback();
                }
                //closing connection
                this.connection.Close();            
            }
        }
    }
}
