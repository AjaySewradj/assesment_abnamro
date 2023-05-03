using AbnAmroApp.BusinessLogic.Models;
using AbnAmroApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbnAmroApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/calculate")]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationManager _calculationManager;
        private readonly ILogger<CalculationController> _logger;

        public CalculationController(ICalculationManager calculationManager, ILogger<CalculationController> logger)
        {
            _calculationManager = calculationManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<Guid>> StartCalculation(string firstName, string lastName)
        {
            return await _calculationManager.StartCalculation(firstName, lastName);
        }

        [HttpGet]
        [Route("{id:guid}/status")]
        public async Task<ActionResult<StatusObject>> GetStatus(Guid id)
        {
            //var result = await _calculationManager.StartCalculation("floop", "poop");
            return new StatusObject(Status.Running, 20, null);
        }
    }
}