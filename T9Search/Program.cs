var contactList = new List<(string name, string number)>();

do
{
    bool helper = true;
    Console.Write("Input the path of the list (if located in the same folder as executable, input just the name): ");
	string path = Console.ReadLine();
    if (path == null || !File.Exists(path))
    {
        Console.WriteLine("The inputed path is not correct\n");
        continue;
    }

    string[] listInput = File.ReadAllLines(path);
    for(int i = 0; i < listInput.Length && helper; i++)
    {
        string c = listInput[i];
        int indexOfComma = c.IndexOf(',');
        if(indexOfComma == -1)
        {
            Console.WriteLine("The list is not formatted correctly\n");
            helper = false;
            continue;
        }
        contactList.Add((c[..indexOfComma], c[(indexOfComma + 2)..]));
    }
    if (helper)
        break;
} 
while (true);

string input;
do
{
    Console.Write("Input the number you want to search: ");
    input = Console.ReadLine();
    if(input.All(char.IsNumber))
    {
        break;
    }
    else
    {
        Console.WriteLine("Input contains forbidden characters\n");
    }

} 
while (true);

Console.WriteLine(NameSearch(contactList, input));

static int NameSearch(List<(string name, string number)> arr, string input)
{
    string[][] dic = 
    {
        new string[] {"0", "+"},
        new string[] {"2", "a", "b", "c"},
        new string[] {"3", "d", "e", "f"},
        new string[] {"4", "g", "h", "i"},
        new string[] {"5", "j", "k", "l"},
        new string[] {"6", "m", "n", "o"},
        new string[] {"7", "p", "q", "r", "s"},
        new string[] {"8", "t", "u", "v"},
        new string[] {"9", "x", "y", "y", "z"},

    };
    for (int i = 0; i < arr.Count; i++)
    {
        int index = 0;
        foreach (char c in arr[i].name.ToLower())
        {
            if (index + 1 > input.Length)
            {
                return i;
            }


        }
    }
    return 1;
}