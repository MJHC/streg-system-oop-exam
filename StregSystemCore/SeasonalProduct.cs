using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
    }
}
