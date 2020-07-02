using Npgsql;
using System.Data;

namespace Examen.Classes
{
    public static class DBConnect
    {
        private static string host = "ec2-34-225-162-157.compute-1.amazonaws.com",
            database = "d22l8nu6kvlpnb",
            userID = "nskpedxsnnfjzm",
            password = "067e160b0da85bda3eae68176b6e3ae18f171a8d55145b916fd0f4acc9d719d5";

        private static string sConnection =
            $"Server={host};Port=5432;User Id={userID};Password={password};Database={database};" +
            "sslmode=Require;Trust Server Certificate=true";

        public static DataTable ExecuteQuery(string query)
        {

            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            DataSet ds = new DataSet();

            connection.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);

            connection.Close();

            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);

            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
