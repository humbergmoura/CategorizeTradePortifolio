using CategorizeTradePortifolio.ConsoleUI.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeTradePortifolio.ConsoleUI.Validation
{
    public static class ValidationCategory
    {
        public static bool Validated(string? data, CultureInfo culture, string? dateReference, ref Category category)
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
    }
}
