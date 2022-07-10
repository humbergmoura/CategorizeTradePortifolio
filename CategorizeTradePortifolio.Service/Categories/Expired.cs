using CategorizeTradePortifolio.Common.Enum;
using CategorizeTradePortifolio.Common.Entity;
using CategorizeTradePortifolio.Service.Abstract;
using CategorizeTradePortifolio.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeTradePortifolio.Service.Categories
{
    public class Expired : Trade
    {
        public Expired(Trade trade) : this(trade.Category) { }

        public Expired(Category category)
        {
            this.category = category;
            IsTradeCategorized();
        }

        public override void IsTradeCategorized()
        {
            if (category.DatePortifolio < category.DateReference.AddDays(-30))
            {
                Category.OutputCategory = OutputCategory.EXPIRED;
            }
            else
            {
                new HighRisk(this.category);
            }
        }
    }
}
