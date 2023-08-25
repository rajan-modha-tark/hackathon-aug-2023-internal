using TaskExecutor.Entities;
using TaskExecutor.Entities.Enum;
using TaskExecutor.Exceptions;
using TaskExecutor.Repository.Contract;
using static System.StringComparison;

namespace TaskExecutor.Repository.Implementation;

public class NodeRepository : INodeRepository
{
    private static readonly IList<Node> _nodes = new List<Node>();
    private static readonly IList<Node> _deletedNodes = new List<Node>();

    public void AddNode(Node node)
    {
        _nodes.Add(node);
    }

    public void Delete(Node node)
    {
        var nodeToDelete = _nodes.FirstOrDefault(_ => _.Equals(node));
        if (nodeToDelete == null) throw new NodeNotFoundException();

        _nodes.Remove(nodeToDelete);
        _deletedNodes.Add(node);
    }

    public List<Node> GetAllNodes()
    {
        return _nodes.ToList();
    }

    public List<Node> GetAllActiveNodes()
    {
        return _nodes
            .Where(_ => _.GetStatus() == NodeStatus.AVALIABLE)
            .ToList();
    }
    
    public Node? GetActiveNode()
    {
        return GetAllActiveNodes().FirstOrDefault();
    }

    public List<Node> GetAllInactiveNodes()
    {
        return _nodes
            .Where(_ => _.GetStatus() == NodeStatus.AVALIABLE)
            .ToList();
    }

    public Node GetNodeByName(string nodeName)
    {
        var node = _nodes
            .FirstOrDefault(_ => _.Name.Equals(nodeName, InvariantCultureIgnoreCase));

        if (node == null) throw new NodeNotFoundException();

        return node;
    }
}