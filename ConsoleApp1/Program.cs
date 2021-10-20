using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection connection = new SqlConnection("Data Source=sqlverify.database.windows.net;Initial Catalog=sqlverify;Persist Security Info=True;User ID=anup;Password=Reenah240986#");
            //connection.Open();
            //connection.Close();
            var connection = new SqlDatabase("Data Source=sqlverify.database.windows.net;Initial Catalog=sqlverify;Persist Security Info=True;User ID=anup;Password=Reenah240986#");

            //var factory = new DatabaseProviderFactory();
            //var db = factory.Create("Data Source=sqlverify.database.windows.net;Initial Catalog=sqlverify;Persist Security Info=True;User ID=anup;Password=Reenah240986#");
            var command = connection.GetSqlStringCommand("select * from dbo.employee");
            IDataReader reader = connection.ExecuteReader(command);
            while (reader.Read())
            {
                Console.WriteLine(reader["id"]);
                Console.WriteLine(reader["name"]);
                Console.WriteLine(reader["city"]);
            }

            var storedCommand = connection.GetStoredProcCommand("GetEmployee");
            var result=connection.ExecuteDataSet(storedCommand);

            for (int i = 0; i < result.Tables.Count; i++)
            {

            }

            foreach (DataTable item in result.Tables)
            {
                foreach (DataRow item1 in item.Rows)
                {

                }
            }
            Console.WriteLine( result.Tables[0].Rows[0]["id"]);
            Console.WriteLine(result.Tables[1].Rows[0]["name"]);
            //var result1 = connection.ExecuteReader(storedCommand);
            //while (result1.Read())
            //{
            //    Console.WriteLine(result1["id"]);
            //    Console.WriteLine(result1["name"]);
            //    Console.WriteLine(result1["city"]);
            //}
            foreach (var table in result.Tables)
            {
               
            }
            Console.ReadLine();
        }
    }
}
