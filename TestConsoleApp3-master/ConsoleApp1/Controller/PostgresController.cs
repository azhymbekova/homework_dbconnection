using Npgsql;
using System.Data.Common;

namespace ConsoleApp1.Controller
{
    public class PostgresController
    {
       public const string ConnectionString = "User ID=new_superuser; Password=1212;" +
       "Host=localHost; Port=5432; Database=learn; Pooling=True;";
        public void GetDbInfo()
        {
            using DbConnection connection = new NpgsqlConnection(ConnectionString);
            string query = @"SELECT * FROM product_types
                        INNER JOIN products ON product_types.product_id = products.product_id
                        INNER JOIN sales ON products.product_id = sales.product_id
                        INNER JOIN orders ON sales.order_id = orders.order_id
                        INNER JOIN customers ON orders.customer_id = customers.customer_id";

            connection.Open();

            using (DbCommand command = connection.CreateCommand()) 
            { 
                command.CommandText = query;
                using(DbDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        for(int i = 1; i< reader.FieldCount; i++)
                            Console.WriteLine(reader[i] +"\t");

                        Console.WriteLine() ;
                    }

                }
            }
        }
    }
}
