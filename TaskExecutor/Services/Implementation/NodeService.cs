using TaskExecutor.Entities;
using TaskExecutor.Models;
using TaskExecutor.Repository.Contract;
using TaskExecutor.Services.Contract;

namespace TaskExecutor.Services.Implementation;

public class NodeService : INodeService
{
    private readonly INodeRepository _nodeRepository;

    public NodeService(INodeRepository nodeRepository)
    {
        _nodeRepository = nodeRepository;
    }

    public Node RegisterNode(NodeRegistrationRequest model)
    {
        var node = new Node(model);
        _nodeRepository.AddNode(node);
        return node;
    }

    public Node DeregisterNode(string name)
    {
        var node = _nodeRepository.GetNodeByName(name);
        _nodeRepository.Delete(node);
        return node;
    }

    public List<Node> GetAllNodes()
    {
        return _nodeRepository.GetAllNodes();
    }
}