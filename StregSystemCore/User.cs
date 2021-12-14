using StregSystem.Core.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace StregSystem.Core
{
    public class User : IComparable<User>
    {
        public int ID { get; private set; }

        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            private set
            {
                if (value == null || value == "")
                    throw new NameNullOrEmptyException("Firstname cannot be null or empty!");
                _firstname = char.ToUpper(value[0]) + value[1..];
            }
        }
        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            private set
            {
                if (value == null || value == "")
                    throw new NameNullOrEmptyException("Lastname cannot be null or empty!");
                _lastname = char.ToUpper(value[0]) + value[1..];
            }
        }
        private string _username;
        public string Username
        {
            get { return _username; }

            private set
            {
                if (!Regex.IsMatch(value, "^[a-zA-Z0-9_]+$"))
                    throw new InvalidUsernameException("Username can not have illegal characters! Legal: a-z, A-Z, 0-9 and _");
                _username = value;
            }
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }

            private set
            {
                string[] values = value.Split("@");
                string pattern = "^[a-zA-Z0-9_.-]+$";
                if (values.Length == 2)
                {
                    if (Regex.IsMatch(values[0], pattern) &&
                       Regex.IsMatch(values[1], pattern) &&
                       !values[1].StartsWith("-") &&
                       !values[1].StartsWith("_") &&
                        values[1].Contains("."))
                        _email = value;
                    else
                        throw new EmailNotValidException($"{value} is not a valid email!");
                }
            }
        }
        public decimal Balance { get; set; }

        public User(int id, string firstname, string lastname, string username, decimal balance, string email)
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
            return $"{Firstname} {Lastname} {Username} {Email} Balance: {Balance}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
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
