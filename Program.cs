using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
enum TaskStatus
{
    Pending,
    InProgress,        
    Done
}

class TaskItem
{
    
    public string Title {get; set;}
    public TaskStatus Status {get; set;}
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
                Console.Clear();
                AddTask();
                break;
            case 2:
                Console.Clear();
                EditTask();
                break;
            case 3:
                Console.Clear();
                DeleteTask();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("List of tasks:");
                ShowList();
                break;
            case 5:
                Console.Clear();
                ChangeStatus();
                break;
            case 6:
                Console.Clear();
                SaveToFile();
                break;
            case 7:
                Console.Clear();
                LoadFromFile();
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
            Status = TaskStatus.Pending
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
   
        taskList[index].Title = newTask;
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
            "6. Save tasks list in json file.\n"+
            "7. Load tasks from json file.\n"+
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
        if (taskList.Count == 0)
        {
            Console.WriteLine("No tasks yet");
            return;
        }

        int index = ReadInt("Write the index of the task, what you want to changed: ");

        if (index < 0 || index >= taskList.Count)
        {
            Console.WriteLine("Wrong index");
            return;
        }

        int choice = ReadInt(
            "Choose the new status:\n"+
            "1. Pending\n"+
            "2. InProgress\n"+
            "3. Done\n");

        switch (choice)
        {
            case 1:
                taskList[index].Status = TaskStatus.Pending;
                break;
            case 2:
                taskList[index].Status = TaskStatus.InProgress;
                break;
            case 3:
                taskList[index].Status = TaskStatus.Done;
                break;
            default:
                Console.WriteLine("Invalid status");
                break;
        }
    }

    public static void SaveToFile()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
            Converters = { new JsonStringEnumConverter() }
        };

        string jsonString = JsonSerializer.Serialize(taskList, options);
        File.WriteAllText("tasks.json", jsonString);
    }

    public static void LoadFromFile()
    {
        string jsonPath = "tasks.json";

        if (!File.Exists(jsonPath))
        {
            Console.WriteLine("No tasks in file yet.");
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(jsonPath);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
                Converters = { new JsonStringEnumConverter() }
            };

            taskList = JsonSerializer.Deserialize<List<TaskItem>>(jsonString, options);
            taskList ??= new List<TaskItem>();

            Console.WriteLine("Tasks loaded.");
        }
        catch
        {
            Console.WriteLine("Error when reading file.");
            taskList = new List<TaskItem>();
        }

        
    }
}


