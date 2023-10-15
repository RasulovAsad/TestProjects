using Aquality.Selenium.Browsers;
using MySqlConnector;
using System.Data;

namespace DatabaseTask.Utilities
{
    public static class DatabaseUtil
    {
        private static MySqlConnection connection;

        public static void SetConnectionSettings(string connectionString)
        {
            AqualityServices.Logger.Info("Calling SetConnection method from DataBaseUtil");
            connection = new MySqlConnection(connectionString);
        }

        public static void OpenConnection()
        {
            AqualityServices.Logger.Info("Calling OpenConnection method from DataBaseUtil");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            AqualityServices.Logger.Info("Calling CloseConnection method from DataBaseUtil");
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static MySqlConnection GetConnection()
        {
            AqualityServices.Logger.Info("Calling GetConnection method from DataBaseUtil");
            return connection;
        }

        public static void Get(out DataTable dataTable, string column, string tableName, string optionalElementRequest = "")
        {
            AqualityServices.Logger.Info("Calling Get method from DataBaseUtil");
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT {column} FROM {tableName}" + $" {optionalElementRequest}", GetConnection());
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        public static void Add(string tableName, string columnsName, string values)
        {
            AqualityServices.Logger.Info("Calling Add method from DataBaseUtil");
            new MySqlCommand($"INSERT {tableName}({columnsName}) VALUES ({values})", GetConnection()).ExecuteNonQuery();
        }

        public static void Update(string tableName, string setСolumnValues, string condition)
        {
            AqualityServices.Logger.Info("Calling Refresh method from DataBaseUtil");
            new MySqlCommand($"UPDATE {tableName} SET {setСolumnValues} WHERE {condition}", GetConnection()).ExecuteNonQuery();
        }

        public static void Delete(string tableName, string condition)
        {
            AqualityServices.Logger.Info("Calling Delete method from DataBaseUtil");
            new MySqlCommand($"DELETE FROM {tableName} WHERE {condition}", GetConnection()).ExecuteNonQuery();
        }
    }
}
