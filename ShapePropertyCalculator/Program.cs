
namespace ShapePropertyCalculator
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Square - s, Cube - c, Circle - ci");
            Console.Write("Choose a figure: ");
            string? input = Console.ReadLine();
            Console.WriteLine();

            IShape s;
            double i;
            switch (input)
            {
                case "s":
                    Console.Write("Enter the length of side 'a': ");
                    i = double.Parse(Console.ReadLine());

                    s = new Square(i);
                    PrintResult(s, "square");
                    break;

                case "c":
                    Console.Write("Enter the length of side 'a': ");
                    i = double.Parse(Console.ReadLine());

                    s = new Cube(i);
                    PrintResult(s, "cube");
                    break;

                case "ci":
                    Console.Write("Enter diameter 'd': ");
                    i = double.Parse(Console.ReadLine());

                    s = new Circle(i);
                    PrintResult(s, "circle");
                    break;
                    /*
                    case "sp":
                        Console.Write("Enter diameter 'd': ");
                        i = double.Parse(Console.ReadLine());

                        s = new Circle(i);
                        PrintResult(s, "sphere");
                        break;*/
            }


        }
        private static void PrintResult(IShape s, string type)
        {
            Console.WriteLine($"\nPerimeter of a {type}: {s.CalculatePerimeter(out string formula)} ({formula})\nArea of a {type}: {s.CalculateArea(out formula)} ({formula})");
        }
    }

    interface IShape
    {
        public double CalculatePerimeter(out string formula);
        public double CalculateArea(out string formula);
    }

    class Square : IShape
    {
        public Square(double side)
        {
            Side = side;
        }

        public double Side { get; set; }

        public double CalculatePerimeter(out string formula)
        {
            formula = "a * 4";
            return Math.Round(Side * 4, 3);
        }

        public double CalculateArea(out string formula)
        {
            formula = "a * a";
            return Math.Round(Side * Side, 3);
        }
    }

    class Cube : IShape
    {
        public Cube(double side)
        {
            Side = side;
        }

        public double Side { get; set; }

        public double CalculatePerimeter(out string formula)
        {
            formula = "a * 12";
            return Math.Round(Side * 12, 3);
        }

        public double CalculateArea(out string formula)
        {
            formula = "a * a * a";
            return Math.Round(Side * Side * Side, 3);
        }
    }

    class Circle : IShape
    {
        public Circle(double diam)
        {
            Diameter = diam;
        }

        public double Diameter { get; set; }

        public double CalculatePerimeter(out string formula)
        {
            formula = "PI * d";
            return Math.Round(Math.PI * Diameter, 3);
        }

        public double CalculateArea(out string formula)
        {
            formula = "PI * (d/2) * (d/2)";
            return Math.Round(Math.PI * (Diameter * 0.5) * (Diameter * 0.5), 3);
        }
    }
    /*
    class Sphere : IShape
    {
        public Sphere(double diam)
        {
            Diameter = diam;
        }

        public double Diameter { get; set; }

        public double CalculatePerimeter(out string formula)
        {
            formula = "PI * d";
            return Math.Round(Math.PI * Diameter, 3);
        }

        public double CalculateArea(out string formula)
        {
            formula = "PI * d * d";
            return Math.Round(Math.PI * Diameter * Diameter, 3);
        }
    }*/
}