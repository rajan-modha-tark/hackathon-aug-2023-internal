using Microsoft.AspNetCore.Mvc;
using TaskExecutor.Models;
using TaskExecutor.Services.Contract;

namespace TaskExecutor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NodesController : ControllerBase
{
    private readonly INodeService _nodeService;

    public NodesController(INodeService nodeService)
    {
        _nodeService = nodeService;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult RegisterNode([FromBody] NodeRegistrationRequest node)
    {
        _nodeService.RegisterNode(node);
        return Ok();
    }

    [HttpDelete]
    [Route("unregister/{name}")]
    public IActionResult RegisterNode(string name)
    {
        _nodeService.DeregisterNode(name);
        return Ok();
    }
}