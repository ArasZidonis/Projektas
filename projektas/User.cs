using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projektas;
using System.Drawing;
using System.Security.Policy;
using System.Data.SqlClient;

namespace LoginApp
{
    public class User : Person
    {
        protected string username;
        protected string password;
        protected string type;

       

        public User(string name, string surname, string username, string password, string type) : base (name, surname)
        {
            if (username != "")
                this.username = username;
            else throw new Exception("Username is required");

            if (password != "")
                this.password = password;
            else throw new Exception("Password is required");

                this.type = type;
        

        }

        public string GetUserName()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetUserType()
        {
            return type;
        }


        public void SetUserType(string type)
        {
            this.type = type;
        }
    }
}
