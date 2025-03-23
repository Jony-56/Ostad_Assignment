using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaseMember
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }




        public DataTable validationMemberDtable(string Password, string Name)
        {
            DataTable dataTable = new DataTable();

            // Read connection string
            string conn = ConfigurationManager.ConnectionStrings["connstringss"].ToString();

            // Create the connection object
            using (SqlConnection conn2 = new SqlConnection(conn))
            {
                // Open the connection
                conn2.Open();

                // SQL query with parameters to avoid SQL Injection
                string commandText = "SELECT * FROM Table_1 WHERE Name = '" + Name + "' AND password = '" + Password + "'";

                // Create command object
                using (SqlCommand cmd = new SqlCommand(commandText, conn2))
                {
                    // Set command timeout
                    cmd.CommandTimeout = 30;  // Set to 30 seconds or adjust as necessary
                    cmd.CommandType = CommandType.Text;

                    // Add parameters to the query

                    // Use SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }

            // Return the DataTable containing the result
            return dataTable;
        }
        //public List<BaseMember> validationMemberList(string Email, string Password)
        //{
        //    List<BaseMember> memberlist = new List<BaseMember>();
        //    //to read connectionstring
        //    //connectionstring
        //    string conn = ConfigurationManager.ConnectionStrings["connstring"].ToString();
        //    //appsettings
        //    string appconn = ConfigurationManager.AppSettings["appConnsting"].ToString();
        //    SqlConnection conn2 = new SqlConnection(conn);
        //    conn2.Open();
        //    string commandText = "select * from Login_Table where Email ='" + Email + "' and Password ='" + Password + "' "; SqlCommand cmd = conn2.CreateCommand();
        //    cmd.CommandTimeout = 0;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Clear();



        //    //to retuen list data
        //    SqlDataReader sqlDataReader = cmd.ExecuteReader();
        //    if (sqlDataReader.HasRows)
        //    {
        //        while (sqlDataReader.Read())
        //        {
        //            BaseMember member = new BaseMember();
        //            member.Email = sqlDataReader["Email"].ToString();
        //            member.Password = sqlDataReader["Password"].ToString();
        //            memberlist.Add(member);
        //        }
        //    }
        //    cmd.Dispose();
        //    conn2.Close();
        //    return memberlist;
        //}
    }

}