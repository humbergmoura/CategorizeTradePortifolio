using CategorizeTradePortifolio.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeTradePortifolio.Common.Entity
{
    public class Category
    {
        public double ValuePortifolio { get; set; }
        public int TypeCategory { get; set; }
        public DateTime DatePortifolio { get; set; }
        public DateTime DateReference { get; set; }
        public int OutputCategory { get; set; }
    }
}
