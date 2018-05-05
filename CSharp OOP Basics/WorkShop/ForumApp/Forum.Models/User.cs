using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class User
    {
        public User(int id, string username, string password, ICollection<int> postsId )
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Posts = new List<int>(postsId);
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<int> Posts { get; set; }
    }
}
