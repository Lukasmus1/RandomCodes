while(true)
{
    Console.Write("Input min and max (input just one number to go from 1): ");
    string[] inputArr;
    inputArr = (Console.ReadLine() + " 1").Split(" ");
    int minInt = 1, maxInt = 1;

    while (!int.TryParse(inputArr[0], out maxInt) || inputArr.Length > 3 || !int.TryParse(inputArr[1], out minInt))
    {
        Console.Write("Input one or two integer numbers seperated by space: ");
        inputArr = (Console.ReadLine() + " 1").Split(" ") ;
    }


    if (inputArr.Length == 3 && minInt > maxInt)
    {
        int t = minInt;
        minInt = maxInt;
        maxInt = t;
    }

    Console.WriteLine($"\nChosen number between {minInt} and {maxInt} is {new Random().Next(minInt, maxInt + 1)}");
}
