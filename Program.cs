class TaskItem
{
    public string Title {get; set;}
    public string Status {get; set;}
}

class Program
{
    static List<TaskItem> taskList = new List<TaskItem>();
    public static void Main()
    {
        ShowMenu();
        int userInput = ReadInt("Your operation choise: ");

        while (userInput != 0)
        {
            Console.Clear();
            SelectOperation(userInput);
            ShowMenu();
            userInput = ReadInt("Your operation choise: ");
        }
    }

    public static void SelectOperation(int userInput)
    {
        switch (userInput)
        {
            case 1:
                AddTask();
                break;
            case 2:
                EditTask();
                break;
            case 3:
                DeleteTask();
                break;
            case 4:
                Console.WriteLine("List of tasks:");
                ShowList();
                break;
            case 5:
                ChangeStatus();
                break;
            default:
                break;
        }
    }

    public static void AddTask()
    {
        Console.Write("Write the new task, what you want to added: ");
        string task = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Cannot add empty task");
            return;
        }

        taskList.Add(new TaskItem
        {
            Title = task,
            Status = "Pending"
        });
    }

    public static void EditTask()
    {
        int index = ReadInt("Write the index of task: ");
        
        if (index < 0 || index >= taskList.Count)
        {
            Console.WriteLine("Wrong index");
            return;
        }

        Console.Write("Write the new task: ");
        string newTask = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newTask))
        {
            Console.WriteLine("Cannot add empty task");
            return;
        }
   
        taskList[index] = new TaskItem{Title = newTask, Status = "Pending"};
    }

    public static void DeleteTask()
    {
        int index = ReadInt("Write the index of the task, what you want to changed: ");

        if (index < 0 || index >= taskList.Count)
        {
            Console.WriteLine("Wrong index");
            return;
        }

        taskList.RemoveAt(index);
    }

    public static void ShowList()
    {
        if (taskList.Count == 0)
        {
            Console.WriteLine("Not tasks yet");
            return;
        }

        for (int i = 0; i < taskList.Count; i++)
        {
            Console.WriteLine($"{i}. {taskList[i].Title} - {taskList[i].Status}");
        }
    }

    public static void ShowMenu()
    {
        Console.WriteLine("\nHi, I'm console CRUD programm.\nChoose the option:\n" +
            "1. Add new task.\n" +
            "2. Edit task.\n" +
            "3. Remove task.\n" +
            "4. Show tasks list.\n"+
            "5. Change status of task.\n"+
            "0. Exit program.\n");
    }

    public static int ReadInt(string message)
    {
        int number;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input. Try again: ");
        }
        return number;
    }

    public static void ChangeStatus()
    {
        int index = ReadInt("Write the index of the task, what you want to changed: ");

        if (index < 0 || index >= taskList.Count)
        {
            Console.WriteLine("Wrong index");
            return;
        }

        string newStatus = Console.ReadLine(); 

        if (string.IsNullOrWhiteSpace(newStatus))
        {
            Console.WriteLine("Cannot change to empty status");
            return;
        }

        taskList[index].Status = newStatus;
    }
}


