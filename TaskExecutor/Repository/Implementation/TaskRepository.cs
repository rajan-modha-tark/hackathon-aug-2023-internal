using TaskExecutor.Entities;
using TaskExecutor.Entities.Enum;
using TaskExecutor.Exceptions;
using TaskExecutor.Repository.Contract;

namespace TaskExecutor.Repository.Implementation;

public class TaskRepository : ITaskRepository
{
    private static readonly IList<TaskDefinition> _tasks = new List<TaskDefinition>();

    private static readonly Queue<TaskDefinition> TasksToExecute = new();

    private readonly INodeRepository _nodeRepository; 
    
    public TaskRepository(INodeRepository nodeRepository)
    {
        _nodeRepository = nodeRepository;
    }

    public void AddTaskToExecute(TaskDefinition taskDefinition)
    {
        TasksToExecute.Enqueue(taskDefinition);
    }

    public TaskDefinition GetTaskToExecute()
    {
        //Added this functionality to validate if a user has deleted the taskDefinition before it was being processed we must not process it
        while (true)
        {
            var task = TasksToExecute.Dequeue();
            
            if (_tasks.Contains(task))
            {
                return task;
            }
        }
    }

    public List<TaskDefinition> GetAllTasks()
    {
        return _tasks.ToList();
    }
    public List<TaskDefinition> GetAllTasksPendingForExecution()
    {
        return TasksToExecute.ToList();
    }

    public TaskDefinition GetTaskById(Guid id)
    {
        var task = _tasks.FirstOrDefault(_ => _.Id == id);
        if (task == null) throw new TaskNotFoundException();

        return task;
    }

    public void ExecuteTask()
    {
        if (!TasksToExecute.TryDequeue(out var taskToBeExecuted)) return;
        
        var availableNode = _nodeRepository.GetActiveNode();
        if (availableNode !=  null)
        {
            availableNode.ChangeStatus(NodeStatus.BUSY);   
            //call rest client worker api with this node address 
        }
    }
    
    public void AddTask(TaskDefinition taskDefinition)
    {
        _tasks.Add(taskDefinition);
    }
    
    public void DeleteTask(TaskDefinition taskDefinition)
    {
        if (!_tasks.Remove(taskDefinition)) throw new TaskNotFoundException();
    }

    public void UpdateTask(TaskDefinition updatedTaskDefinition)
    {
        var task = GetTaskById(updatedTaskDefinition.Id);
        DeleteTask(task);
        _tasks.Add(task);
    }
}