string dec;
do
{
    Console.Write("How many points do you need to win?: ");
    int pointCeil;
    while (!int.TryParse(Console.ReadLine(), out pointCeil))
    {
        Console.WriteLine("Please input an integer number.\n");
        Console.Write("How many rounds points do you need to win?: ");
    }

    int userScore = 0, pcScore = 0, pc;
    for (int i = 1; pointCeil > userScore && pointCeil > pcScore; i++)
    {
        Console.WriteLine("\n----------------------------");
        Console.WriteLine($"ROUND {i}");
        Console.WriteLine($"PC Score: {pcScore} | User Score: {userScore} | Score to win: {pointCeil}");
        string input;
        do
        {
            Console.Write("Input Scissors (1), Rock (2) or Paper (3): ");
            input = Console.ReadLine();
        }
        while (input is not ("1" or "2" or "3"));

        Console.WriteLine();
        pc = new Random().Next(1, 4);
        switch (pc)
        {
            case 1:
                Console.Write("Opponent chose scissors");
                switch (input)
                {
                    case "1":
                        Console.WriteLine(", it's a draw!");
                        i--;
                        break;
                    case "2":
                        Console.WriteLine(", you win!");
                        userScore++;
                        break;
                    case "3":
                        Console.WriteLine(", you lost!");
                        pcScore++;
                        break;
                }
                break;
            case 2:
                Console.Write("Opponent chose a rock");
                switch (input)
                {
                    case "1":
                        Console.WriteLine(", you lost!");
                        pcScore++;
                        break;
                    case "2":
                        Console.WriteLine(", it's a draw!");
                        i--;
                        break;
                    case "3":
                        Console.WriteLine(", you win!");
                        userScore++;
                        break;
                }
                break;
            case 3:
                Console.Write("Opponent chose a paper");
                switch (input)
                {
                    case "1":
                        Console.WriteLine(", you win!");
                        userScore++;
                        break;
                    case "2":
                        Console.WriteLine(", you lost!");
                        pcScore++;
                        break;
                    case "3":
                        Console.WriteLine(", it's a draw!");
                        i--;
                        break;
                }
                break;
        }
    }

    Console.WriteLine();
    if (pcScore > userScore)
    {
        Console.WriteLine($"YOU LOST! PC: {pcScore} - You: {userScore}");
    }
    else
    {
        Console.WriteLine($"YOU WON! PC: {pcScore} - You: {userScore}");
    }

    do
    {
        Console.WriteLine("\nDo you want to play again? yes (y) or no (n): ");
        dec = Console.ReadLine();
    }
    while (dec is not ("y" or "n"));
}
while (dec != "n");