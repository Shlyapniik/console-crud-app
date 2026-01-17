using System;


List<string> tasksList = new List<string> { "task1", "task2", "task3"};
int index = 1;

while (true)
{
    ShowMenu();

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid input");
        continue;
    }
       
    if (choice == 0) break;

    ChooseSwitch(choice);
}

void ChooseSwitch(int choise)
{
    switch (choise)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Write the new task:\n");
            string task = Console.ReadLine();
            AddTask(task);
            return;
        case 2:
            Console.Clear();
            Console.WriteLine("Choose the task number, that you want to change:\n");
            index = 1;
            foreach (string a in tasksList)
            {
                Console.WriteLine($"{index}.{a}");
                index++;
            }
            index = 1;
            int editTaskNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Write the new task for change:\n");
            string newTaskForEdit = Console.ReadLine();
            EditTask(editTaskNumber, newTaskForEdit);
            return;
        case 3:
            Console.Clear();
            Console.WriteLine("Choose the task number, that you want to remove:\n");
            index = 1;
            foreach (string a in tasksList)
            {
                Console.WriteLine($"{index}.{a}");
                index++;
            }
            index = 1;
            int taskToRemove = int.Parse(Console.ReadLine());
            RemoveTask(taskToRemove);
            return;
        case 4:
            Console.Clear();
            Console.WriteLine("Tasks list:");
            index = 1;
            foreach (string a in tasksList)
            {
                Console.WriteLine($"{index}.{a}");
                index++;
            }
            index = 1;
            return;
    }
}

void AddTask(string task)
{
    tasksList.Add(task);
    Console.WriteLine("New task added!");
}

void EditTask(int taskNumber, string newTask)
{
    tasksList[taskNumber-1] = newTask;
    Console.WriteLine("Task edited!");
}

void RemoveTask(int taskNumber)
{
    tasksList.RemoveAt(taskNumber-1);
    Console.WriteLine("Task removed!");
}

void ShowMenu()
{
    Console.WriteLine("\nHi, I'm console CRUD programm.\nChoose the option:\n" +
    "1. Add new task.\n" +
    "2. Edit task.\n" +
    "3. Remove task.\n" +
    "4. Show tasks list.\n");
}