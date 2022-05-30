using System;
using System.IO;
using System.Collections.Generic;

namespace challenge2
{
    class Program
    {
        public static List<int> Rolls = new List<int>();
        static void Main(string[] args)
        {
            // Hey there old data!
            if (File.Exists($@"{Environment.CurrentDirectory}\Rolls.csv"))
            {
                using StreamReader file = new StreamReader($@"{Environment.CurrentDirectory}\Rolls.csv");
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    string[] parts = ln.Split(',');
                    Rolls.Add(int.Parse(parts[0]));
                }
                file.Close();
            }
            // I have all the infinity loops...
            while (true)
            {
                Console.Clear();
                // Keyread!?! Nobody else seems to know how to use that!!
                Console.WriteLine("1. Roll\n2. Stats\n3. List rolls\n4. Save rolls\n5. Exit");
                switch (Console.ReadKey().Key.ToString())
                {
                    // Mapping keys to functions the lazy and inefficient way
                    case "D1":
                        Console.Clear();
                        Add();
                        Console.ReadKey();
                        continue;
                    case "D2":
                        Console.Clear();
                        Console.WriteLine($"Total: {Total()}");
                        Console.WriteLine($"Average: {Average(Total())}");
                        Console.ReadKey();
                        continue;
                    case "D3":
                        Console.Clear();
                        List();
                        Console.ReadKey();
                        continue;
                    case "D4":
                        Console.Clear();
                        Save();
                        Console.ReadKey();
                        continue;
                    case "D5":
                        Console.Clear();
                        Console.WriteLine("Thanks for using the dice rolling app");
                        Console.ReadKey();
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
        public static void Add()
        {
            Console.WriteLine("You've selected to roll the dice");
            Random gen = new Random();
            int x = 0;
            // making sure input is an int
            while(true) {
                Console.WriteLine("Please enter the amount of rolls you would like to make: ");
                bool success = int.TryParse(Console.ReadLine().ToString(), out x);
                Console.Clear();
                if(success || x > 0 ){
                    break;
                }
            }
            // Rollin', rollin', rollin' on the river
            for (int i = 0; i < x; i++) 
            {
                Rolls.Add(gen.Next(1,7));
            }
            
            Console.WriteLine($"You have successfully added {x} item{(x == 1 ? "" : "s")}");
        }
        public static void List()
        {
            Console.WriteLine($"Total: {Total()}");
            Console.WriteLine($"Average: {Average(Total())}");
            
            // That's a lot of words. Too bad I'm not readin' 'em.
            foreach (int roll in Rolls)
            {
                Console.WriteLine(roll);
            }
        }

        public static double Average(int total)
        {
            // Algebraic!
            double average = (double)total / (double)Rolls.Count;
            return average;
        }

        public static int Total()
        {
            // Mathematical!
            int sum = 0;
            foreach (int roll in Rolls)
            {
                sum += roll;
            }
            return sum;
        }

        public static void Save()
        {
            // Saving...
            StreamWriter writer = new StreamWriter($@"{Environment.CurrentDirectory}\Rolls.csv");
            foreach (int roll in Rolls)
            {
                writer.WriteLine(roll);
            }
            writer.Close();
            Console.WriteLine("Saved");
        }
    }
}