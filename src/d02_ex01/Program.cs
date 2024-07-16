try
{
    TaskManager taskManager = new TaskManager();
    while (true)
    {
        Console.WriteLine("TASK MANAGER MENU:");
        Console.WriteLine("`add` - added new task");
        Console.WriteLine("`list` - print all tasks");
        Console.WriteLine("`done` - mark task as complited");
        Console.WriteLine("`wontdo` - mark task as irrelevant");
        Console.WriteLine("`quit` or `q` - close program\n");
        switch (Console.ReadLine())
        {
            case "add":
                taskManager.AddTask();
                break;
            case "list":
                taskManager.PrintList();
                break;
            case "done":
                Console.WriteLine("Enter a title");
                taskManager.TaskDone(Console.ReadLine());
                break;
            case "wontdo":
                Console.WriteLine("Enter a title");
                taskManager.TaskIrrelevant(Console.ReadLine());
                break;
            case "quit":
            case "q":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Input error. Check the input data and repeat the request.");
        }
        Console.WriteLine();
    }
} catch (Exception e) {
    Console.WriteLine(e.Message);
}

