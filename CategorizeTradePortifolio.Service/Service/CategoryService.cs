using CategorizeTradePortifolio.Common.Entity;
using CategorizeTradePortifolio.Common.Enum;
using CategorizeTradePortifolio.Service.Abstract;
using CategorizeTradePortifolio.Service.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeTradePortifolio.Service.Service
{
    public class CategoryService 
    {
        private Trade trade;
        private Category category;

        public CategoryService(Category category)
        {
            this.category = category;
            this.trade = new Expired(this.category);
        }
    }
}
