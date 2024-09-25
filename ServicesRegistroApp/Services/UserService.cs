using ServicesRegistroApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ServicesRegistroApp.DB;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Reflection;

namespace ServicesRegistroApp
{
    public class UserService : IUserService
    {
        public IList<Area> GetAreas()
        {
            IList<Area> areaList = new List<Area>();
            CConnection objConnection = new CConnection();
            try
            {
                string query = "select Id, Name from area;";
                MySqlCommand cmd = new MySqlCommand(query, objConnection.startConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Area area = new Area
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["Name"].ToString()
                    };

                    areaList.Add(area);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                objConnection.closedConnection();
            }
            return areaList;
        }

        public bool CreateUser(User user)
        {
            CConnection objConnection = new CConnection();
            bool isCreated = false;

            try
            {
                string query = "INSERT INTO user (IdUser, Id_area, Name, LastName, Address, Phone, Email) " +
                               "VALUES (@IdUser, @Id_area, @Name, @LastName, @Address, @Phone, @Email);";

                MySqlCommand cmd = new MySqlCommand(query, objConnection.startConnection());
                cmd.Parameters.AddWithValue("@IdUser", user.Identification);
                cmd.Parameters.AddWithValue("@Id_area", user.Area.Id);
                cmd.Parameters.AddWithValue("@Name", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    isCreated = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error CreateUser: " + e.Message);
            }
            finally
            {
                objConnection.closedConnection();
            }

            return isCreated;
        }

        public User GetUserById(int idUser)
        {
            CConnection objConnection = new CConnection();
            User user = null;

            try
            {
                string query = @"SELECT user.Id as userId, 
                                                           user.IdUser as userIdent, 
                                                           user.Id_area as userIdArea, 
                                                           area.Name as areaName, 
                                                           user.Name as userName, 
                                                           user.LastName as userLastName, 
                                                           user.Address as userAddress, 
                                                           user.Phone as userPhone, 
                                                           user.Email as userEmail
                                           FROM user
                                           INNER JOIN area ON user.Id_area = area.Id
                                           WHERE user.Id  = @IdUser;";

                MySqlCommand cmd = new MySqlCommand(query, objConnection.startConnection());
                cmd.Parameters.AddWithValue("@IdUser", idUser);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader["userId"]),
                        Identification = Convert.ToInt32(reader["userIdent"]).ToString(),
                        Area = new Area()
                        {
                            Id = Convert.ToInt32(reader["userIdArea"]),
                            Name = reader["areaName"].ToString(),
                        },
                        FirstName = reader["userName"].ToString(),
                        LastName = reader["userLastName"].ToString(),
                        Address = reader["userAddress"].ToString(),
                        Phone = reader["userPhone"].ToString(),
                        Email = reader["userEmail"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                objConnection.closedConnection();
            }

            return user;
        }

        public IList<User> GetUsers()
        {
            IList<User> userList = new List<User>();
            CConnection objConnection = new CConnection();
            try
            {
                string query = @"SELECT user.Id as userId, 
                                                           user.IdUser as userIdent, 
                                                           user.Id_area as userIdArea, 
                                                           area.Name as areaName, 
                                                           user.Name as userName, 
                                                           user.LastName as userLastName, 
                                                           user.Address as userAddress, 
                                                           user.Phone as userPhone, 
                                                           user.Email as userEmail
                                           FROM user
                                           INNER JOIN area ON user.Id_area = area.Id
                                           ORDER BY user.Id DESC
                                           LIMIT 10";

                MySqlCommand cmd = new MySqlCommand(query, objConnection.startConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(row["userId"]),
                        Identification = Convert.ToInt32(row["userIdent"]).ToString(),
                        Area = new Area() 
                            { 
                                Id = Convert.ToInt32(row["userIdArea"]),
                                Name = row["areaName"].ToString(),
                        },
                        FirstName = row["userName"].ToString(),
                        LastName = row["userLastName"].ToString(),
                        Address = row["userAddress"].ToString(),
                        Phone = row["userPhone"].ToString(),
                        Email = row["userEmail"].ToString()
                    };

                    userList.Add(user);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                objConnection.closedConnection();
            }
            return userList;
        }

        public bool UpdateUser(User user)
        {
            CConnection objConnection = new CConnection();
            bool isUpdated = false;

            try
            {
                string query = "UPDATE user SET IdUser = @IdUser, Id_area = @Id_area, Name = @Name, " +
                               "LastName = @LastName, Address = @Address, Phone = @Phone, Email = @Email " +
                               "WHERE Id = @Id;";

                MySqlCommand cmd = new MySqlCommand(query, objConnection.startConnection());
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@IdUser", user.Identification);
                cmd.Parameters.AddWithValue("@Id_area", user.Area.Id);
                cmd.Parameters.AddWithValue("@Name", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error UpdateUser: " + e.Message);
            }
            finally
            {
                objConnection.closedConnection();
            }

            return isUpdated;
        }
    }
}
