using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Input a sentence: ");
        string input = Console.ReadLine();
        input = input.Replace(" ", "");

        List<string> palindromes = new();
        for (int i = 0; i < input.Length; i++)
        {
            for (int l = input.Length - 1; l > i; l--)
            {
                if (input[i] == input[l])
                {
                    string pal;
                    if (Search(input, i, l, out pal))
                    {
                        i = l;
                        if(!palindromes.Contains(pal))
                            palindromes.Add(pal);
                        break;
                    }
                }
            }
        }
        Console.WriteLine(palindromes.Count);
        string res = "";
        foreach(string pal in palindromes)
        {
            res += $"{pal}, ";
        }
        Console.Write(res.Remove(res.Length - 2));
    }

    private static bool Search(string input, int i, int l, out string res)
    {
        res = "";
        string palLeft = input[i].ToString();
        string palRight = input[l].ToString();
        for (int left = i + 1, right = l - 1; right >= left; left++, right--)
        {
            if (input[left] == input[right])
            {
                if (left == right)
                    palLeft += input[left].ToString();
                else
                {
                    palLeft += input[left].ToString();
                    palRight += input[right].ToString();
                }
            }
            else
            {
                return false;
            }
        }
        char[] arrHelp = palRight.ToCharArray();
        Array.Reverse(arrHelp);
        res = $"{palLeft}{new string(arrHelp)}";
        return true;
    }
}