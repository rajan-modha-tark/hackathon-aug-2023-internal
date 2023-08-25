using CommonModels;
using Microsoft.AspNetCore.Mvc;

namespace Worker.Controllers;

public class WorkerController : ControllerBase
{
    [HttpPost]
    public WorkerExecutionResponseModel Execute()
    {
        return new WorkerExecutionResponseModel();
    }
}