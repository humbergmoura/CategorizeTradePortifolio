using CategorizeTradePortifolio.ConsoleUI.Entity;
using CategorizeTradePortifolio.ConsoleUI.Enum;
using CategorizeTradePortifolio.ConsoleUI.Repository;
using static CategorizeTradePortifolio.ConsoleUI.Validation.ValidationCategory;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;

CultureInfo culture = new CultureInfo("en-US");
List<Category> lstCategory = new List<Category>();
string? dateReference = string.Empty;
string? amount = string.Empty;
int number = 0;

for (int i = 0; i < 1; i++)
{
    dateReference = Console.ReadLine();
    if (!DateTime.TryParse(dateReference, culture, DateTimeStyles.None, out DateTime date))
    {
        i--;
        Console.WriteLine("Invalid reference date!");
    }
}

for (int i = 0; i < 1; i++)
{
    amount = Console.ReadLine();
    if (!int.TryParse(amount, out number) || number == 0)
    {
        i--;
        Console.WriteLine("Invalid trade amount!");
    }
}

for (int i = 0; i < number; i++)
{
    Category category = new Category();
    string? data = Console.ReadLine();

    if (Validated(data, culture, dateReference, ref category))
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        var resultado = categoryRepository.PostCategoryTradeAsync(category);

        var cat = resultado.Result as Category;
        lstCategory.Add(cat);
    }
    else
    {
        i--;
    }
}

Console.WriteLine();
for (int i = 0; i < number; i++)
{
    Console.WriteLine((OutputCategory)lstCategory[i].OutputCategory);
}

Console.ReadKey();
