using TaskExecutor.Entities.Enum;
using TaskExecutor.Exceptions;
using TaskExecutor.Models;

namespace TaskExecutor.Entities;

public class Node
{
    public Node(NodeRegistrationRequest model)
    {
        Name = model.Name;
        Address = model.Address;
        CreatedDate = DateTime.Now;
        NodeStatus = NodeStatus.AVALIABLE;
    }

    public string Name { get; set; }
    public string Address { get; set; }
    private NodeStatus NodeStatus { get; }
    public DateTime CreatedDate { get; set; }

    public NodeStatus GetStatus()
    {
        return NodeStatus;
    }

    public void ChangeStatus(NodeStatus status)
    {
        if (NodeStatus == status) throw new InvalidStatusChangeRequest();

        if (status == NodeStatus.AVALIABLE)
        {
            //TODO: Call back to check for pending queue if available
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Node anotherModel) return false;

        return Equals(anotherModel);
    }

    protected bool Equals(Node other)
    {
        return
            Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase) &&
            Address.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase)
            ;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Address);
    }
}