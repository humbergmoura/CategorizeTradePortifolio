using CategorizeTradePortifolio.Common.Entity;
using CategorizeTradePortifolio.Common.Enum;
using CategorizeTradePortifolio.ConsoleUI.Repository;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;

CultureInfo culture = new CultureInfo("en-US");
List<Category> lstCategory = new List<Category>();
string? dateReference = string.Empty;
string? amount = string.Empty;
int numero = 0;

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
    if (!int.TryParse(amount, out numero) || numero == 0)
    {
        i--;
        Console.WriteLine("Invalid trade amount!");
    }
}

for (int i = 0; i < numero; i++)
{
    Category category = new Category();
    string? data = Console.ReadLine();

    if (Validated(data, ref category))
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        var resultado = categoryRepository.PostCategoryTradeAsync(category);

        resultado.ContinueWith(task =>
        {
            var cat = task.Result;
            lstCategory.Add(cat);
        },
        TaskContinuationOptions.OnlyOnRanToCompletion
        );
    }
    else
    {
        i--;
    }
}

bool Validated(string? data, ref Category category)
{
    if (string.IsNullOrEmpty(data))
    {
        Console.WriteLine("Data not filled!");
        return false;
    }
    else if (data.Split(" ").Count() < 3)
    {
        Console.WriteLine("Insufficient data!");
        return false;
    }
    else
    {
        string invalid = string.Empty;
        category.DateReference = Convert.ToDateTime(dateReference, culture);

        if (double.TryParse(data.Split(" ")[0], out double value))
        {
            category.ValuePortifolio = Convert.ToDouble(value);
        }
        else
        {
            invalid += "Invalid Portifolio Value!\n";
        }
        if (data.Split(" ")[1].ToString().ToLower() == "private" || data.Split(" ")[1].ToString().ToLower() == "public")
        {
            category.TypeCategory = data.Split(" ")[1].ToString().ToLower() == "private" ? 0 : 1;
        }
        else
        {
            invalid += "Invalid category type!\n";
        }
        if (DateTime.TryParse(data.Split(" ")[2], culture, DateTimeStyles.None, out DateTime datePortifolio))
        {
            category.DatePortifolio = Convert.ToDateTime(datePortifolio, culture);
        }
        else
        {
            invalid += "Invalid portifolio date!";
        }

        if (!string.IsNullOrEmpty(invalid))
        {
            Console.WriteLine(invalid);
            return false;
        }
    }

    return true;
}

Console.WriteLine();
for (int i = 0; i < numero; i++)
{
    Console.WriteLine((OutputCategory)lstCategory[i].OutputCategory);
}

Console.ReadKey();
