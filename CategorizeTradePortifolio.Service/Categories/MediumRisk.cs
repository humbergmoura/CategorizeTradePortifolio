using CategorizeTradePortifolio.Common.Entity;
using CategorizeTradePortifolio.Common.Enum;
using CategorizeTradePortifolio.Service.Abstract;
using CategorizeTradePortifolio.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeTradePortifolio.Service.Categories
{
    public class MediumRisk : Trade
    {
        public MediumRisk(Trade trade) : this(trade.Category) { }

        public MediumRisk(Category category)
        {
            this.category = category;
            IsTradeCategorized();
        }

        public override void IsTradeCategorized()
        {
            if (Category.TypeCategory == TypeCategory.Public && Category.ValuePortifolio >= 1000000)
            {
                Category.OutputCategory = OutputCategory.MEDIUMRISK;
            }
        }
    }
}
