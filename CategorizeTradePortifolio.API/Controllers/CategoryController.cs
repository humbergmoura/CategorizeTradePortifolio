using CategorizeTradePortifolio.Common.Entity;
using CategorizeTradePortifolio.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace CategorizeTradePortifolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public Category Category(Category category)
        {
            CategoryService categoryService = new CategoryService(category);

            return category;
        }
    }
}
