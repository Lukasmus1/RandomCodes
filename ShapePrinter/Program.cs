internal class Program
{
    private static void Main(string[] args)
    {
        //Doesnt check for bad input /shrug
        Console.Write("Insert Width: ");
        int w = int.Parse(Console.ReadLine());
        Console.Write("Insert Height: ");
        int h = int.Parse(Console.ReadLine());

        IShape shape = new Rectangle(w, h);
        shape.PrintShape();
    }
}

interface IShape
{
    int Width { get; set; }

    int Height { get; set; }

    string Shape { get; set; }

    public void PrintShape();
}

class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public string Shape { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void PrintShape()
    {
        Build();
        Console.WriteLine(Shape);
    }

    private void BuildHor(bool up)
    {
        if (up)
            Shape += "┌";
        else
            Shape += "└";

        for (int i = 2; i < Width; i++)
        {
            Shape += " - ";
        }

        if (up)
            Shape += "┐";
        else
            Shape += "┘";
        Shape += "\n";
    }

    private void Build()
    {
        BuildHor(true);
        for (int i = 2; i < Height; i++)
        {
            for (int l = 0; l < Width; l++)
            {
                if (l == 0 || l == Width - 1)
                {
                    Shape += "|";
                }
                else
                {
                    Shape += "   ";
                }
            }
            Shape += "\n";
        }
        BuildHor(false);
    }
}

//The code can easily implement more shapes, not rn tho Okayge