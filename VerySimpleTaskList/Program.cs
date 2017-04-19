using System;
namespace VerySimpleTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to First VS program 1.0");
            TaskManager manager = new TaskManager();
            manager.Run();
        }
    }
}
