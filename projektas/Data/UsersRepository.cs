using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using projektas;
using System.Data.SqlClient;

namespace LoginApp
{
    public class UsersRepository
    {

        private SqlConnection conn;


        public UsersRepository()
        {
            conn = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");
        }

        public void Register(User user)
        {
            try
            {
                string sql = "insert into [user](name, surname, username, password, type) " +
                    "values (@name, @surname, @username, @password, @type)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", user.GetName());
                cmd.Parameters.AddWithValue("@surname", user.GetSurname());
                cmd.Parameters.AddWithValue("@username", user.GetUserName());
                cmd.Parameters.AddWithValue("@password", user.GetPassword());
                cmd.Parameters.AddWithValue("@type", user.GetUserType());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public User Login(string username, string password)
        {
            try
            {
                string sql = "select name, surname, username, password, type from [User] " +
                        "where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string surname = reader["surname"].ToString();
                        string usrname = reader["username"].ToString();
                        string pass = reader["password"].ToString();
                        string type = reader["type"].ToString();
                        return new User(name, surname, usrname, pass, type);
                    }
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            throw new Exception("Bad credentials");
        }
 

        public void CheckLogin(string username)
        {
            try
            {
                string sql = "select name, surname, username, password, type from [user] " +
                        "where username=@username";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string usrname = reader["username"].ToString();
                        if(username == usrname)
                        {
                            throw new Exception("User with the same username exists");
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public string GetUsername(string userid)
        {
            try
            {
                string username = "";
                conn.Open();
                string sql = "select userId, name, surname, username, password, type, group_id from [user] " +
                         "where userId=@userId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sReader;
                cmd.Parameters.AddWithValue("@userId", userid);
                sReader = cmd.ExecuteReader();
                if (sReader.Read())
                {
                    username = sReader["username"].ToString();
                }
                return username;

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetUserId(string username)
        {
            try
            {
                string id = "";
                conn.Open();
                string sql = "select id, name, surname, username, password, type, group_id from [user] " +
                         "where username=@username";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sReader;
                cmd.Parameters.AddWithValue("@username", username);
                sReader = cmd.ExecuteReader();
                if (sReader.Read())
                {
                    id = sReader["id"].ToString();
                }
                return id;

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void InsertGroup(string group) {
            try
            {

                string sql = "insert into [Groups](name) " + "values (@name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", group);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            
            }
        
        
        }
        public void InsertSubject(string subject)
        {
            try
            {

                string sql = "insert into [Subject](name) " + "values (@name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", subject);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);

            }


        }


        }






    }
