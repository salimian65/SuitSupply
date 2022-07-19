using Microsoft.AspNetCore.Mvc;
using SuitSupply.Framework.Core.CommandHandling;
using SuitSupply.Tailoring.Application.Contracts.Tailors;
using SuitSupply.Tailoring.Query.Facade.Contracts;

namespace SuitSupply.Tailoring.Interface.WebApi.V1.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TailorController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly ITailorQueryFacade _tailorQueryFacade;
        public TailorController(ICommandBus commandBus, ITailorQueryFacade tailorQueryFacade)
        {
            _commandBus = commandBus;
            _tailorQueryFacade = tailorQueryFacade;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _tailorQueryFacade.GetAll());
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTailorCommand command)
        {
            await _commandBus.DispatchAsync(command);
            return Ok();
        }
    }
}