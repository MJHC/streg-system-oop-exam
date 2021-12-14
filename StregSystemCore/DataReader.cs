using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public class DataReader : IDataReader
    {
        public List<User> ReadUsers()
        {
            string[] csv = Properties.Resources.users.Split("\n");
            List<User> users = new List<User>();

            foreach (string line in csv)
            {
                if (line == csv[0]) continue;

                string[] values = line.Split(",");

                if (values.Length > 1)
                {
                    users.Add(new User(int.Parse(values[0]), values[1], values[2], values[3], decimal.Parse(values[4]) / 100, values[5]));
                }
            }

            return users;
        }

        public List<Product> ReadProducts()
        {
            string[] csv = Properties.Resources.products.Split("\n");
            List<Product> products = new List<Product>();

            foreach(string line in csv)
            {
                if(line == csv[0]) continue;

                string[] values = line.Split(";");

                if(values.Length > 1)
                {
                    products.Add(new Product(int.Parse(values[0]), StripHTML(values[1]), decimal.Parse(values[2]) / 100,values[3] == "1", false));
                }
            }
            return products;
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>|\"", string.Empty);
        }
    }
}
