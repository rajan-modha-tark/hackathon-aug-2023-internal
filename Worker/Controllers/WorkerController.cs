using CommonModels;
using Microsoft.AspNetCore.Mvc;

namespace Worker.Controllers;

public class WorkerController : ControllerBase
{
    [HttpGet]
    public IActionResult Health()
    {
        return Ok();
    }
    [HttpPost]
    public WorkerExecutionResponseModel Execute()
    {
        //Call service to do the work in async manner and return the OK response from here.
        //once the service is done with its work it should call a API of TaskExecutor for updating the task status(failed or Passed) and node status
        return new WorkerExecutionResponseModel();
    }
}