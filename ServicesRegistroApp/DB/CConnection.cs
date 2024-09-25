using System;
using MySql.Data.MySqlClient;

namespace ServicesRegistroApp.DB
{
    internal class CConnection
    {
        MySqlConnection conex = new MySqlConnection();

        static string _server = "localhost";
        static string _db = "peopledb";
        static string _user = "root";
        static string _password = "admin123";
        static string _port = "3306";

        string _cnstr = "server=" + _server + ";" + "port=" + _port + ";" + "user=" + _user + ";" + "database=" + _db + ";" + "password=" + _password + ";";


        public MySqlConnection startConnection()
        {
            try
            {
                conex.ConnectionString = _cnstr;
                conex.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error CConnection: " + e.Message);
            }
            return conex;
        }
        public void closedConnection()
        {
            conex.Close();
        }
    }
}
