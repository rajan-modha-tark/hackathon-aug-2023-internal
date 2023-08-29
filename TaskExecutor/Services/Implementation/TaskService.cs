using TaskExecutor.Entities;
using TaskExecutor.Models;
using TaskExecutor.Repository.Contract;
using TaskExecutor.Services.Contract;

namespace TaskExecutor.Services.Implementation;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly INodeRepository _nodeRepository;

    public TaskService(ITaskRepository taskRepository, INodeRepository nodeRepository)
    {
        _taskRepository = taskRepository;
        _nodeRepository = nodeRepository;
    }

    public TaskRegistrationResponseModel AddAndExecuteTask(string taskName)
    {
        throw new NotImplementedException();
    }

    public void ExecutePendingTask()
    {
        throw new NotImplementedException();
    }

    public List<TaskDefinition> GetAllTaskDefinitions()
    {
        throw new NotImplementedException();
    }
}