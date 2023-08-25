using Microsoft.AspNetCore.Mvc;
using TaskExecutor.Models;

namespace TaskExecutor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    public TaskRegistrationResponseModel RegisterTask(string taskName)
    {
        return new TaskRegistrationResponseModel();
    }
}