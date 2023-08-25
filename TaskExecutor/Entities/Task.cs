namespace TaskExecutor.Entities;

public class Task
{
    public Task(string name)
    {
        Id = new Guid();
        Name = name;
        CreatedDate = DateTime.Now;
        Status = TaskStatus.Created;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    private TaskStatus Status { get; set; }

    public TaskStatus GetStatus()
    {
        return this.Status;
    }

    public void SetStatus(TaskStatus status)
    {
        if (status == this.Status)
        {
            return;
        }

        this.Status = status;
    }
}