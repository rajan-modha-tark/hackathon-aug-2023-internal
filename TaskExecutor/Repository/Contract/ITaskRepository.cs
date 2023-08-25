using Task = TaskExecutor.Entities.Task;

namespace TaskExecutor.Repository.Contract;

public interface ITaskRepository
{
    public List<Task> GetAllTasks();
    public Task GetTaskById(Guid id);
    public void AddAndExecuteTask(Task task, bool shouldExecute = true);
    public void DeleteTask(Task task);
    public void UpdateTask(Task updatedTask);
}