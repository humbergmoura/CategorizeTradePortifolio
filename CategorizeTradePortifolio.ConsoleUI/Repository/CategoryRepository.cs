using CategorizeTradePortifolio.ConsoleUI.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeTradePortifolio.ConsoleUI.Repository
{
    public class CategoryRepository
    {
        HttpClient client = new HttpClient();
        public CategoryRepository()
        {
            client.BaseAddress = new Uri("https://localhost:7025");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Category> PostCategoryTradeAsync(Category category)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Category", category);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Category>(data);
            }

            return new Category();
        }
    }
}
