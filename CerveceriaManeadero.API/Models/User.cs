using System;

namespace CerveceriaManeadero.API.Models
{
    public class User
    {
        public User()
        {

        }


        public User(string password, string username)
        {
            Password = password;
            Username = username;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
