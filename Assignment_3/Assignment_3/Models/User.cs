using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Assignment_3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

        public bool SaveData()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["connstringss"].ToString();
                using (SqlConnection coon2 = new SqlConnection(conn))
                {
                    coon2.Open();
                    string commandText = "INSERT INTO signUp (FirstName, LastName, Email, Password, Gender, Role) " +
                                       "VALUES (@FirstName, @LastName, @Email, @Password, @Gender, @Role)";
                    using (SqlCommand command = new SqlCommand(commandText, coon2))
                    {
                        command.CommandTimeout = 30;
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@FirstName", this.FirstName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", this.LastName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Email", this.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Password", this.Password); // Or use hashing
                        command.Parameters.AddWithValue("@Gender", this.Gender ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Role", this.Role ?? (object)DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User> ShowData()
        {
            List<User> list = new List<User>();
            try
            {
                string con = ConfigurationManager.ConnectionStrings["connstringss"].ConnectionString;
                using (SqlConnection coon2 = new SqlConnection(con))
                {
                    coon2.Open();
                    using (SqlCommand command = new SqlCommand("GetAllUsers", coon2))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Debugging: Check if reader has rows
                            System.Diagnostics.Debug.WriteLine("Reader has rows: " + reader.HasRows);

                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                    Role = reader.GetString(reader.GetOrdinal("Role"))
                                };
                                list.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR in ShowData: " + ex.ToString());
                throw; // Re-throw to see error details
            }
            return list;
        }
    }
}