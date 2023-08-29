using TaskExecutor.Entities;
using TaskExecutor.Models;

namespace TaskExecutor.Services.Contract;

public interface ITaskService
{
    public TaskRegistrationResponseModel AddAndExecuteTask(string taskName);
    public void ExecutePendingTask();
    public List<TaskDefinition> GetAllTaskDefinitions();

}