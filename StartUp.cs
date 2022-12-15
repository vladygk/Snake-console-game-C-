namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;
    using System;
    using SimpleSnake.Core;
    using System.Transactions;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            int difficulty = SetDifficulty();
            Console.Clear();
            Field field = new Field(60,20);

            Snake snake = new Snake(field);
            IEngine engine = new Engine(field, snake, difficulty);
            engine.Run();
            
            Console.WriteLine();
            Console.WriteLine();

        }

        public static int SetDifficulty()
        {
            Console.WriteLine("Choose difficulty: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Enter choice: ");
            int input = int.Parse(Console.ReadLine());

            return input;
        }


    }
}
