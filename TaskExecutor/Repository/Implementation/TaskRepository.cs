using TaskExecutor.Entities.Enum;
using TaskExecutor.Exceptions;
using TaskExecutor.Repository.Contract;
using Task = TaskExecutor.Entities.Task;

namespace TaskExecutor.Repository.Implementation;

public class TaskRepository : ITaskRepository
{
    private static readonly IList<Task> _tasks = new List<Task>();

    private static Queue<Task> _tasksToExecute = new Queue<Task>();

    private readonly INodeRepository _nodeRepository; 
    //
    // public delegate void ExecuteTaskEventHandler(object source, EventArgs eventArgs);
    // public event ExecuteTaskEventHandler TaskExecuted;
    //
    // protected virtual void OnTaskExecuted()
    // {
    //     
    // }
    public TaskRepository(INodeRepository nodeRepository)
    {
        _nodeRepository = nodeRepository;
    }

    private static void AddTaskToExecute(Task task)
    {
        _tasksToExecute.Enqueue(task);
    }

    private static Task GetTaskToExecute()
    {
        //Added this functionality to validate if a user has deleted the task before it was being processed we must not process it
        while (true)
        {
            var task = _tasksToExecute.Dequeue();
            
            if (_tasks.Contains(task))
            {
                return task;
            }
        }
    }

    public List<Task> GetAllTasks()
    {
        return _tasks.ToList();
    }

    public Task GetTaskById(Guid id)
    {
        var task = _tasks.FirstOrDefault(_ => _.Id == id);
        if (task == null) throw new TaskNotFoundException();

        return task;
    }

    public void ExecuteTask()
    {
        if (!_tasksToExecute.TryDequeue(out var taskToBeExecuted)) return;
        
        var availableNode = _nodeRepository.GetActiveNode();
        if (availableNode !=  null)
        {
            availableNode.ChangeStatus(NodeStatus.BUSY);   
            //call rest client worker api with this node address 
        }

    }
    public void AddAndExecuteTask(Task task, bool shouldExecute = true)
    {
        _tasks.Add(task);
        if (!shouldExecute) 
            return;
        
        var availableNode = _nodeRepository.GetActiveNode();
        if (availableNode != null)
        {
            availableNode.ChangeStatus(NodeStatus.BUSY);   
            //call rest client worker api with this node address 
        }
        else
        {
            AddTaskToExecute(task);
        }
    }
    
    public void DeleteTask(Task task)
    {
        if (!_tasks.Remove(task)) throw new TaskNotFoundException();
    }

    public void UpdateTask(Task updatedTask)
    {
        var task = GetTaskById(updatedTask.Id);
        DeleteTask(task);
        _tasks.Add(task);
    }
}