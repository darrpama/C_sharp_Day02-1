using System.Runtime.CompilerServices;

public class Task
{
    public Task(string title, TaskType type, DateTime? dueDate = null, string? summary = null,
                 TaskPriority priority = TaskPriority.Normal)
    {
        Title = title;
        Summary = summary;
        DueDate = dueDate;
        Type = type;
        Priority = priority;
        State = TaskState.New;
    }

    public override string ToString()
    {
        string answer = "";
        if (DueDate == null) {
            answer = $"- {Title}\n" +
                     $"[{Type}] [{State}]\n" +
                     $"Priority: {Priority}\n" +
                     $"{Summary}";

        } else {
            answer = $"- {Title}\n" +
                     $"[{Type}] [{State}]\n" +
                     $"Priority: {Priority}, Due till {DueDate}\n" +
                     $"{Summary}";
        }
        return answer;
    }

    public void MarkAsCompleted()
    {
        if (State == TaskState.New) {
            State = TaskState.Completed;
            Console.WriteLine($"The task [{Title}] is completed!");
        }
    }

    public bool MarkAsIrrelevant()
    {
        bool answer = false;
        if (State == TaskState.New) {
            State = TaskState.Irrelevant;
            answer = true;
        }
        return answer;
    }

    public string Title { get; private set; }
    public string? Summary { get; private set; }
    public DateTime? DueDate { get; private set; }
    public TaskType Type { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskState State { get; private set; }

}