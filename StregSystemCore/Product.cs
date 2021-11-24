using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product()
        {

        }

        public override string ToString()
        {
            return $"{ID} {Name} {Price}"; 
        }
    }
}
