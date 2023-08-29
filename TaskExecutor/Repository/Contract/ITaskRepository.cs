using TaskExecutor.Entities;

namespace TaskExecutor.Repository.Contract;

public interface ITaskRepository
{
    public List<TaskDefinition> GetAllTasks();
    public TaskDefinition GetTaskById(Guid id);
    public TaskDefinition GetTaskToExecute();
    public void AddTask(TaskDefinition taskDefinition);
    public void AddTaskToExecute(TaskDefinition taskDefinition);
    public void DeleteTask(TaskDefinition taskDefinition);
    public void UpdateTask(TaskDefinition updatedTaskDefinition);
}