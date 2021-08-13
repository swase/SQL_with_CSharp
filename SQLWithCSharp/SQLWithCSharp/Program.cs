using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {


                connection.Open();
                Console.WriteLine(connection.State);
                using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
                {
                    updateCustomerCommand.CommandType = CommandType.StoredProcedure;
                    updateCustomerCommand.Parameters.AddWithValue("ID", "BEARD");
                    updateCustomerCommand.Parameters.AddWithValue("NewName", "Eric Smith");
                    int affected = updateCustomerCommand.ExecuteNonQuery();
                }

                //var newCustomer = new Customer()
                //{
                //    CustomID = "007",
                //    ContactName = "Francois Gouws",
                //    City = "Atlantis",
                //    CompanyName = "Sparta Global"
                //};

                //string sqlString = $"INSERT INTO Customers(CustomerID, ContactName," +
                //    $"CompanyName, City) VALUES('{newCustomer.CustomID}', '{newCustomer.ContactName}'," +
                //    $"'{newCustomer.CompanyName}', '{newCustomer.City}');";
                //string sqlUpdateString = $"UPDATE Customers SET CITY = 'BARCELONA' " +
                //            $"WHERE CustomerID = '007'";
                //using (var command2 = new SqlCommand(sqlUpdateString, connection))
                //{
                //    int affected = command2.ExecuteNonQuery();
                //    Console.WriteLine(affected);
                //}

                //            string sqlDelString = $"DELETE FROM Customers" +
                //$"WHERE ContactName = 'Francois Gouws';";
                //            using (var command3 = new SqlCommand(sqlDelString, connection))
                //            {
                //                int affected = command3.ExecuteNonQuery();
                //                Console.WriteLine(affected);
                //            }

                //using (var command = new SqlCommand("select * from Customers", connection))
                //{
                //    SqlDataReader sqlReader = command.ExecuteReader();
                //    while (sqlReader.Read())
                //    {
                //        var customerID = sqlReader["CustomerID"].ToString();
                //        var contactName = sqlReader["ContactName"].ToString();
                //        var companyName = sqlReader["CompanyName"].ToString();
                //        var city = sqlReader["City"].ToString();
                //        var contactTitle = sqlReader["ContactTitle"].ToString();

                //        var customer = new Customer()
                //        {
                //            ContactTitle = contactTitle,
                //            CustomID = customerID,
                //            ContactName = contactName,
                //            City = city,
                //            CompanyName = companyName
                //        };
                //        customers.Add(customer);
                //    }

                //    foreach(var c in customers)
                //    {
                //        Console.WriteLine($"Customer {c.GetFullName()} " +
                //            $"has ID {c.CustomID} and live in city {c.City}");
                //    }
                //    sqlReader.Close();
                connection.Close();
                //}


            }

        }
    }

    class Customer
    {
        public string CustomID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }

        public string GetFullName()
        {
            return $"{ContactTitle} - {ContactName}";
        }
         

    };
}
