using CQRS2.Command;
using CQRS2.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetTodoListById.Query(3));

            return Ok(result);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _mediator.Send(new GetTodoListByName.Query("salar"));

            return Ok(result);
        }
        [HttpPost("{name}")]
        public async Task<IActionResult> Post(string name)
        {
            var result = await _mediator.Send(new AddTodo.Command(name));

            return Ok(result);
        }
    }
}
