namespace TaskExecutor.Models;

public class TaskRegistrationResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Status { get; set; }
}