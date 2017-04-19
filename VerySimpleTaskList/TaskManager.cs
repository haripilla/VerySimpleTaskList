using System;
using System.Collections.Generic;

namespace VerySimpleTaskList
{
    public class TaskManager
    {
        public TaskManager()
        {
            _tasks = new List<Task>();
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                int choice = GetNumberFromUser();
                choice = GetValidMenuFromUser(choice);
                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    DoAddTask();
                }
                else if (choice == 2)
                {
                    DoMarkTaskComplete();
                }
                else if (choice == 3)
                {
                    DoSetPriority();
                }
                else if (choice == 4)
                {
                    DoListAllTasks();
                }
                else if (choice == 5)
                {
                    DoRemoveTasks();
                }
            }
        }

        private void DoListAllTasks()
        {
            Console.Clear();
            Console.WriteLine("YOUR TASKS");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        private void DoSetPriority()
        {
            Console.Clear();
            Console.WriteLine("CHANGE TASK PRIORITY");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("What task do you want to change? ");

            //int index = GetNumberFromUser();
            //index = GetValidIndexFromUser(index);
            int index = GetValidIndexFromUser();
            Console.Write("What is the new task's priority? ");

            int newPriority = GetNumberFromUser();

            _tasks[index].SetPriority(newPriority);
        }



        private void DoMarkTaskComplete()
        {
            Console.Clear();
            Console.WriteLine("COMPLETE A TASK");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("What task did you complete? ");

            //int index = GetNumberFromUser();
            //index = GetValidIndexFromUser(index);
            int index = GetValidIndexFromUser();
            _tasks[index].MarkCompleted();
        }

        private void PrintNumberedTaskList()
        {
            for (int i = 0; i < _tasks.Count; i += 1)
            {
                Task task = _tasks[i];
                Console.WriteLine($"{i}. {task.DescribeYourself()}");
            }
        }

     
        private void DoAddTask()
        {
            Console.Clear();
            Console.WriteLine("ADD A TASK");
            Console.WriteLine("-------------------------");
            Console.WriteLine("What is your next task?");

            string description = GetStringFromUser();



            Console.WriteLine("Do you want to add a Reminder to Task ?");
            string Choice = GetStringFromUser();

            if (Choice == "yes")
            {
                Console.WriteLine("How Many Hours you want to set the Reminder for this Task ?");
                //int noOfHours = GetNumberFromUser();

                int noOfHours = GetValidHoursFromUser();
                Task newTask = new TaskWithReminder(description, noOfHours);
                _tasks.Add(newTask);
            }
            else
            {
                Task newTask = new Task(description);
                _tasks.Add(newTask);
            }

        }


        private void DoRemoveTasks()
        {

            PrintNumberedTaskList();
            Console.WriteLine("Enter Task Number To Remove From Above List");
            Console.WriteLine("--------------------------------------------");
            //int index = GetNumberFromUser();
            int index = GetValidIndexFromUser();

            if (index >= 0 && index <= _tasks.Count)
            {
                _tasks.RemoveAt(index);
            }
            
        }


        private string GetStringFromUser()
        {
            //return Console.ReadLine();

            string descp = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrEmpty(descp))
                {
                    Console.WriteLine("Invalid Entery - Enter correct Value ");
                    descp = GetStringFromUser();
                    
                }
                else
                {
                    return descp;
                }
            }

        }

        private int GetNumberFromUser()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        private int GetValidIndexFromUser()
        {
            int numT = GetNumberFromUser();
            while (true)
            {
                if (numT >= 0 && numT < _tasks.Count)
                {
                   return numT;
                }
                else 
                {
                    Console.WriteLine("Enter Valid Task Number");
                    numT = GetNumberFromUser();
                }
            }
            
        }


        private int GetValidHoursFromUser()
        {
            int numT = GetNumberFromUser();
            while (true)
            {
                if (numT >= 1 && numT < 24)
                {
                    return numT;
                }
                else
                {
                    Console.WriteLine("Enter Valid Reminder - Hours between 1 to 24");
                    numT = GetNumberFromUser();
                }
            }

        }

        private int GetValidMenuFromUser(int index)
        {
            int numT = index;
            while (true)
            {
                if (numT >= 0 && numT <= 5)
                {
                    return numT;
                }
                else
                {
                    Console.WriteLine("Enter Valid Number From Menu");
                    numT = GetNumberFromUser();
                }
            }

        }


        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("TASK MANAGEMENT!");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Currently you Have { _tasks.Count} task(s)");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Mark a task complete");
            Console.WriteLine("3. Set a task's priority");
            Console.WriteLine("4. List the tasks");
            Console.WriteLine("5. Remove the tasks");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            Console.WriteLine("-------------------------");
            Console.Write("What would you like to do? ");
        }

        private List<Task> _tasks;
    }
}
