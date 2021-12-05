using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public class SeasonalProduct : Product
    {
        public SeasonalProduct(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit, DateTime start, DateTime end) : base(id, name, price, active, canBeBoughtOnCredit)
        {
            SeasonStartDate = start;
            SeasonEndDate = end;
        }

        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
    }
}
