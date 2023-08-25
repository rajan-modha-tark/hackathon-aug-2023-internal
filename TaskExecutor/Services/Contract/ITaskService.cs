using TaskExecutor.Models;

namespace TaskExecutor.Services.Contract;

public interface ITaskService
{
    public TaskRegistrationResponseModel RegisterTask(string taskName);
}