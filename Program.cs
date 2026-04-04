using System;

class Program
{
    static List<string> taskList = new List<string> {"task1", "task2", "task3"};
    public static void Main()
    {
        ShowMenu();
        int userInput = int.Parse(Console.ReadLine());

        while (userInput != 0)
        {
            Console.Clear();
            SelectOperation(userInput);
            ShowMenu();
            userInput = int.Parse(Console.ReadLine());  
        }
    }

    public static void SelectOperation(int userInput)
    {
        int index;
        string task, newTask;
        switch (userInput)
        {
            case 1:
                Console.Write("Write the new task, what you want to added: ");
                task = Console.ReadLine();
                AddTask(task);
                break;
            case 2:
                Console.Write("Write the index of the task, what you want to changed: ");
                index = int.Parse(Console.ReadLine());
                Console.Write("Write the new task");
                newTask = Console.ReadLine();
                EditTask(index, newTask);
                break;
            case 3:
                Console.Write("Write the index of the task, what you want to changed: ");
                index = int.Parse(Console.ReadLine());
                DeleteTask(index);
                break;
            case 4:
                Console.WriteLine("List of tasks:");
                ShowList();
                break;
            default:
                break;
        }
    }

    public static void AddTask(string task)
    {
        taskList.Add(task);
    }

    public static void EditTask(int index, string newTask)
    {
        taskList[index] = newTask;
    }

    public static void DeleteTask(int index)
    {
        taskList.RemoveAt(index);
    }

    public static void ShowList()
    {
        foreach (string task in taskList)
        {
            Console.WriteLine(task);
        }
    }

    public static void ShowMenu()
{
    Console.WriteLine("\nHi, I'm console CRUD programm.\nChoose the option:\n" +
        "1. Add new task.\n" +
        "2. Edit task.\n" +
        "3. Remove task.\n" +
        "4. Show tasks list.\n"+
        "0. Exit program.");
}
}


