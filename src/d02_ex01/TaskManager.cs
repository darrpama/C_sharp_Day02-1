using System.Data;
using System.Diagnostics;

public class TaskManager
{
    private List<Task> tasks_ = new List<Task>();

    public void AddTask()
    {
        string title = TitleEntry();
        TaskType type = TypeEntry();
        DateTime? dueDate = DueDateEntry();
        string summary = SummaryEntry();
        TaskPriority priority = PriorityEntry();

        Console.WriteLine(title);
        Task task = new Task(title, type, dueDate, summary, priority);

        tasks_.Add(task);
    }

    public void PrintList()
    {
        if (tasks_.Count == 0)
        {
            Console.WriteLine("The task list is still empty.");
        }
        else
        {
            foreach (var task in tasks_)
            {
                Console.WriteLine(task.ToString());
            }
        }
    }

    public void TaskDone(string? title)
    {
        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("Input error. The task with this title was not found");
            return;
        }
        else
        {
            var task = findTask(title);
            if (task != null)
            {
                if (task.MarkAsCompleted())
                {
                    Console.WriteLine($"The task [{title}] is completed!");
                }
            }
            else
            {
                Console.WriteLine("Input error. The task with this title was not found");
            }
        }
    }

    public void TaskIrrelevant(string? title)
    {
        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("Input error. The task with this title was not found");
            return;
        }
        else
        {
            var task = findTask(title);
            if (task != null)
            {
                if (task.MarkAsIrrelevant())
                {
                    Console.WriteLine($"The task [{title}] is no longer relevant!");
                }
            }
            else
            {
                Console.WriteLine("Input error. The task with this title was not found");
            }
        }
    }

    private Task? findTask(string title)
    {
        foreach (var task in tasks_)
        {
            if (task.Title == title)
            {
                return task;
            }
        }
        return null;
    }

    private string TitleEntry()
    {
        Console.WriteLine("Enter a title");
        var title = Console.ReadLine();
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentNullException(nameof(title), "Title cannot be null.");
        }
        return title;
    }

    private string? SummaryEntry()
    {
        Console.WriteLine("Enter a description");
        var summary = Console.ReadLine();
        if (string.IsNullOrEmpty(summary))
        {
            return null;
        }
        return summary;
    }

    private DateTime? DueDateEntry()
    {
        Console.WriteLine("Enter a deadline (MM/dd/yyyy)");
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }
        var tokens = input.Split('/');
        if (tokens.Length == 3 &&
            int.TryParse(tokens[2], out int year) &&
            int.TryParse(tokens[0], out int month) &&
            (month is > 0 and <= 12) &&
            int.TryParse(tokens[1], out int day) &&
            (day is > 0 and <= 31))
        {
            return new DateTime(year, month, day);
        }
        else
        {
            Console.WriteLine("\bInput error. Check the input data and repeat the request.");
            return DueDateEntry();
        }
    }

    private TaskType TypeEntry()
    {
        Console.WriteLine("Choose task category:");
        Console.WriteLine("1 - Work");
        Console.WriteLine("2 - Study");
        Console.WriteLine("3 - Personal");
        char choice = Console.ReadKey().KeyChar;
        switch (choice)
        {
            case '1':
                Console.WriteLine("\bWork");
                return TaskType.Work;
            case '2':
                Console.WriteLine("\bStudy");
                return TaskType.Study;
            case '3':
                Console.WriteLine("\bPersonal");
                return TaskType.Personal;
            default:
                Console.WriteLine("\bInput error. Check the input data and repeat the request.");
                return TypeEntry();
        }
    }

    private TaskPriority PriorityEntry()
    {
        Console.WriteLine("Choose task priority:");
        Console.WriteLine("1 - Low");
        Console.WriteLine("2 - Normal");
        Console.WriteLine("3 - High");
        char choice = Console.ReadKey().KeyChar;
        switch (choice)
        {
            case '1':
                Console.WriteLine("\bLow");
                return TaskPriority.Low;
            case '2':
                Console.WriteLine("\bNormal");
                return TaskPriority.Normal;
            case '3':
                Console.WriteLine("\bHigh");
                return TaskPriority.High;
            default:
                return TaskPriority.Normal;
        }
    }
}