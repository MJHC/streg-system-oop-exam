using System;

namespace StregSystem.Core
{
    public class User : IComparable<User>
    {
        public int ID { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public decimal Balance { get; set; }

        public User(int id, string firstname, string lastname, string username, decimal balance,string email)
        {
            ID = id;
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname} {Username} {Balance} {Email}";
        }

        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is User))
            {
                return false;
            }
            return (GetHashCode() == obj.GetHashCode());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Firstname, Lastname, Username);
        }

        public int CompareTo(User other)
        {
            return ID.CompareTo(other.ID);
        }
    }
}
