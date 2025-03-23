using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Account : BaseMember
    {
        public bool ExistName(string Name)
        {
            bool exist = false;
            string conn = ConfigurationManager.ConnectionStrings["connstringss"].ToString();

            using (SqlConnection conn2 = new SqlConnection(conn))
            {
                conn2.Open();
                string query = "SELECT COUNT(*) FROM Table_1 WHERE Name = @Name";

                using (SqlCommand cmd = new SqlCommand(query, conn2))
                {
                    cmd.Parameters.AddWithValue("@Name", Name); // Ensure parameter name matches the query
                    int count = (int)cmd.ExecuteScalar(); // COUNT(*) always returns an integer

                    exist = count > 0;
                }
            }
            return exist;
        }
        public bool UpdatePass(string pass, string name)
        {
            bool update = false;
            string conn = ConfigurationManager.ConnectionStrings["connstringss"].ToString();

            using (SqlConnection conn2 = new SqlConnection(conn))
            {
                conn2.Open();
                string query = "UPDATE Table_1 SET Password = @Password WHERE Name = @Name";

                using (SqlCommand cmd = new SqlCommand(query, conn2))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Password", pass);

                    int count = cmd.ExecuteNonQuery(); // Returns affected rows count
                    update = count > 0; // If any row was updated, return true
                }
            }
            return update;
        }


    }

}