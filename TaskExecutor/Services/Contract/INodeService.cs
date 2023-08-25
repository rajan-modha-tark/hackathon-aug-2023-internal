using TaskExecutor.Entities;
using TaskExecutor.Models;

namespace TaskExecutor.Services.Contract;

public interface INodeService
{
    public Node RegisterNode(NodeRegistrationRequest model);
    public Node DeregisterNode(string name);
}