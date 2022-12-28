using System.Text.RegularExpressions;

namespace BinHexDecConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string num = Console.ReadLine();

            string? input = "";
            Regex r = new(@"^[2-9]$");

            if (num.Any(i => char.IsLetter(i)))
            {
                Types.PrlongHex(num);
            }
            else if (num.Any(i => r.Match(i.ToString()).Success))
            {
                while (true)
                {
                    Console.Write("Is the number you entered decimal (d) or hexadecimal (h)?: ");
                    input = Console.ReadLine();
                    if (input == "h" || input == "d")
                        break;
                }

                if (input == "h")
                {
                    Types.PrlongHex(num);
                }
                else
                {
                    Types.PrlongDec(num);
                }
            }
            else
            {
                while (true)
                {
                    Console.Write("Is the number you entered decimal (d), hexadecimal (h) or binary (b)?: ");
                    input = Console.ReadLine();
                    if (input == "h" || input == "d" || input == "b")
                        break;
                }

                if (input == "h")
                {
                    Types.PrlongHex(num);
                }
                else if (input == "d")
                {
                    Types.PrlongDec(num);
                }
                else
                {
                    Types.PrlongBin(num);
                }
            }
        }
    }

    static class Types
    {
        public static void PrlongHex(string num)
        {
            Console.WriteLine();
            num = num.ToUpper();
            long decNum = Converters.ToDec("1", num);
            Console.WriteLine($"Hexadecimal number {num} is...\n{decNum} in decimal and...\n{Converters.ToBin("1", num)} in binary.");
        }

        public static void PrlongDec(string num)
        {
            Console.WriteLine();

            Console.WriteLine($"Decimal number {num} is...\n{Converters.ToHex("1", long.Parse(num))} in hexadecimal and...\n{Converters.ToBin("2", num)} in binary.");
        }

        public static void PrlongBin(string num)
        {
            Console.WriteLine();

            Console.WriteLine($"Binary number {num} is...\n{Converters.ToDec("2", num)} in decimal and...\n{Converters.ToHex("2", long.Parse(num))} in hexadecimal.");
        }
    }

    static class Converters
    {
        public static long ToDec(string type, string num)
        {
            return type switch
            {
                "1" => long.Parse(num, System.Globalization.NumberStyles.HexNumber),
                "2" => Convert.ToInt64(num, 2),
                _ => -1,
            };
        }
        public static string ToBin(string type, string num)
        {
            return type switch
            {
                "1" => Convert.ToString(ToDec("1", num), 2),
                "2" => Convert.ToString(long.Parse(num), 2),
                _ => "",
            };
        }
        public static string ToHex(string type, long num)
        {
            return type switch
            {
                "1" => num.ToString("X"),
                "2" => ToDec("2", num.ToString()).ToString("X"),
                _ => "",
            };
        }
    }
}