using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient_socket
{
    public class PersonInfo : IEquatable<PersonInfo>
    {
        public string Name;
        public string LastName;
        public string NickName;
        public string Password;
        public string Email;
        public PersonInfo(string name, string lastName, string nickName, string password, string email)
        {
            Name = name;
            LastName = lastName;
            NickName = nickName;
            Password = password;
            Email = email;
        }
        public PersonInfo()
        {
                
        }
        public bool Equals(PersonInfo other)
        {
            throw new NotImplementedException();
        }
    }
}