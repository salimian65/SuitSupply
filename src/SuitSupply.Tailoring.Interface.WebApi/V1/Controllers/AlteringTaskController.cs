using Microsoft.AspNetCore.Mvc;
using SuitSupply.Framework.Core.CommandHandling;
using SuitSupply.Tailoring.Application.Contracts;
using SuitSupply.Tailoring.Application.Contracts.AlteringTasks;
using SuitSupply.Tailoring.Query.Facade.Contracts;

namespace SuitSupply.Tailoring.Interface.WebApi.V1.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlteringTaskController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IAlteringTaskQueryFacade _alteringTaskQueryFacade;
        public AlteringTaskController(ICommandBus commandBus, IAlteringTaskQueryFacade alteringTaskQueryFacade)
        {
            _commandBus = commandBus;
            _alteringTaskQueryFacade = alteringTaskQueryFacade;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _alteringTaskQueryFacade.GetAll());
        }

        [HttpPut]
        [Route("pick")]
        public async Task<IActionResult> Pick([FromBody] PickAlteringTaskCommand command)
        {
            await _commandBus.DispatchAsync(command);
            return Ok();
        }

        [HttpPut]
        [Route("finish")]
        public async Task<IActionResult> Finish([FromBody] FinishAlteringTaskCommand command)
        {
            await _commandBus.DispatchAsync(command);
            return Ok();
        }
    }
}