using TaskExecutor.Entities;

namespace TaskExecutor.Repository.Contract;

public interface INodeRepository
{
    Node GetNodeByName(string nodeName);
    public List<Node> GetAllInactiveNodes();
    public List<Node> GetAllActiveNodes();
    public Node? GetActiveNode();
    public List<Node> GetAllNodes();
    public void Delete(Node node);
    public void AddNode(Node node);
}