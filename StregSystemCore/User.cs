using System;

namespace StregSystemCore
{
    public class User
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }

        public User()
        {

        }

        public override string ToString()
        {
            return $"{Firstname}  {Lastname} {Email}";
        }

        // Equals
        // GetHashCode
    }
}
