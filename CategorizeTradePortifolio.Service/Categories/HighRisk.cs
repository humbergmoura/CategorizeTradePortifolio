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
    public class HighRisk : Trade
    {
        public HighRisk(Trade trade) : this(trade.Category) { }

        public HighRisk(Category category)
        {
            this.category = category;
            IsTradeCategorized();
        }

        public override void IsTradeCategorized()
        {
            if (Category.TypeCategory == TypeCategory.Private && Category.ValuePortifolio >= 1000000)
            {
                Category.OutputCategory = OutputCategory.HIGHRISK;
            }
            else
            {
                new MediumRisk(this.category);
            }
        }
    }
}
