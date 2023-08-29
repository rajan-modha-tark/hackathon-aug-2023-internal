using TaskExecutor.Entities.Enum;

namespace TaskExecutor.Entities;

public class TaskDefinition
{
    public TaskDefinition(string name)
    {
        Id = new Guid();
        Name = name;
        CreatedDate = DateTime.Now;
        Status = TaskDefinitionStatus.PENDING;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    private TaskDefinitionStatus Status { get; set; }

    public TaskDefinitionStatus GetStatus()
    {
        return this.Status;
    }

    public void SetStatus(TaskDefinitionStatus status)
    {
        if (status == this.Status)
        {
            return;
        }

        this.Status = status;
    }
}