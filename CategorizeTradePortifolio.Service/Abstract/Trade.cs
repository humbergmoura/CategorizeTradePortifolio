using CategorizeTradePortifolio.Common.Entity;
using CategorizeTradePortifolio.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeTradePortifolio.Service.Abstract
{
    public abstract class Trade
    {
        protected Category category = new Category();

        public Category Category { get => category; set => category = value; }

        public abstract void IsTradeCategorized();
    }
}
