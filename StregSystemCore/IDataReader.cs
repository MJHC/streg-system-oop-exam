using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public interface IDataReader
    {
        List<User> ReadUsers();
        List<Product> ReadProducts();
    }
}
