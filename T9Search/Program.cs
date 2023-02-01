var arr = new List<(string name, string number)>();

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
        arr.Add((c[..indexOfComma], c[(indexOfComma + 2)..]));
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


} 
while (true);