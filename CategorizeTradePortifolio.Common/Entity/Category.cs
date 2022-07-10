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
        public TypeCategory TypeCategory { get; set; }
        public DateTime DatePortifolio { get; set; }
        public DateTime DateReference { get; set; }
        public OutputCategory OutputCategory { get; set; }
    }
}
