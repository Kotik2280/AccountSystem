using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem
{
    public class User
    {
        private static int currentId { get; set; } = 0;
        public int ID { get; private set; }
        public string Name { get; private set; } = "Undefined";
        public int Age { get; private set; }
        public string Nickname { get; private set; }
        public string EMail { get; private set; }
        public string Password { get; private set; }

        public User(string nickname, string name, int age, string Email, string password)
        {
            ID = currentId++;
            Nickname = nickname;
            Name = name;
            Age = age;
            Password = password;
        }

        public void ChangePassword(string newPassword) => Password = newPassword;
    }
}
