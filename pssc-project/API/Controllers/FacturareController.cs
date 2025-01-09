using Microsoft.AspNetCore.Mvc;
using pssc_project.Application.Commands;
using pssc_project.Application.Workflows;

namespace pssc_project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturareController : ControllerBase
    {
        private readonly FacturareWorkflow _facturareWorkflow;

        public FacturareController(FacturareWorkflow facturareWorkflow)
        {
            _facturareWorkflow = facturareWorkflow;
        }

        [HttpPost]
        public IActionResult FacturareComanda([FromBody] FacturareComandaCommand command)
        {
            _facturareWorkflow.ExecutaFacturare(command);
            return Ok("Facturare procesată.");
        }
    }
}